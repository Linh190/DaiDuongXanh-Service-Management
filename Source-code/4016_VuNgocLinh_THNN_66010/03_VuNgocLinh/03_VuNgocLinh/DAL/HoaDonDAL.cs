using System;
using System.Data;
using System.Data.SqlClient;

namespace _03_VuNgocLinh.DAL
{
    public static class HoaDonDAL
    {
        /// <summary>
        /// Tạo hóa đơn cho một đơn dịch vụ đã xác định (tính tổng tiền từ ChiTietDonDichVu).
        /// </summary>
        public static string CreateHoaDonForDon(string maHoaDon, string maDon, string phuongThuc, decimal thueVatPercent, decimal chietKhauPercent, string maNvLap)
        {
            // compute totals from ChiTietDonDichVu
            object totalObj = DataProvider.ExecuteScalar("SELECT ISNULL(SUM(SOLUONG * DONGIA), 0) FROM ChiTietDonDichVu WHERE MADON = @m", new SqlParameter("@m", maDon));
            decimal tongTien = Math.Round(Convert.ToDecimal(totalObj ?? 0m), 2);

            decimal thue = tongTien * thueVatPercent / 100m;
            decimal chietkhau = tongTien * chietKhauPercent / 100m;
            decimal thanhTien = tongTien + thue - chietkhau;

            int r = DataProvider.ExecuteNonQuery(@"
INSERT INTO HoaDon (MAHD, NGAYHD, TONGTIEN, THUEVAT, CHIETKHAU, THANHTIEN, PHUONGTHUCTHANHTOAN, TINHTRANGTHANHTOAN, MADON, MANV_LAP)
VALUES (@mahd, GETDATE(), @tong, @thue, @ck, @thanhtien, @pt, N'Chưa thanh toán', @madon, @manvlap)",
                new SqlParameter("@mahd", maHoaDon),
                new SqlParameter("@tong", tongTien),
                new SqlParameter("@thue", thueVatPercent),
                new SqlParameter("@ck", chietKhauPercent),
                new SqlParameter("@thanhtien", thanhTien),
                new SqlParameter("@pt", string.IsNullOrWhiteSpace(phuongThuc) ? (object)DBNull.Value : phuongThuc),
                new SqlParameter("@madon", maDon),
                new SqlParameter("@manvlap", string.IsNullOrWhiteSpace(maNvLap) ? (object)DBNull.Value : maNvLap));
            if (r <= 0) throw new Exception("Không thể tạo hóa đơn.");
            return maHoaDon;
        }

        public static DataRow GetById(string maHd)
        {
            var dt = DataProvider.ExecuteQuery("SELECT * FROM HoaDon WHERE MAHD = @m", new SqlParameter("@m", maHd));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>Lấy hóa đơn theo Mã đơn dịch vụ (1 đơn thường chỉ có 1 hóa đơn).</summary>
        public static DataRow GetByMaDon(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon)) return null;
            var dt = DataProvider.ExecuteQuery("SELECT * FROM HoaDon WHERE MADON = @m", new SqlParameter("@m", maDon));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static bool ExistsForDon(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon)) return false;
            object v = DataProvider.ExecuteScalar(
                "SELECT 1 FROM HoaDon WHERE MADON = @m", new SqlParameter("@m", maDon));
            return v != null;
        }

        /// <summary>
        /// Tự động lập hóa đơn cho đơn dịch vụ khi đơn chuyển trạng thái "Hoàn thành"
        /// (gọi từ DonHangDAL.UpdateTrangThai). Bỏ qua nếu đơn đã có hóa đơn rồi
        /// (tránh tạo trùng khi cập nhật trạng thái nhiều lần).
        /// Người lập mặc định = nhân viên tiếp nhận đơn (MANV_TIEPNHAN).
        /// Thuế GTGT mặc định 10%, chiết khấu mặc định 0% — nhân viên văn phòng có
        /// thể chỉnh lại tay sau (UPDATE HoaDon) nếu cần áp dụng khuyến mãi/giảm giá.
        /// </summary>
        public static void AutoCreateIfNotExists(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon)) return;
            if (ExistsForDon(maDon)) return; // đã có hóa đơn rồi, không tạo trùng

            object manvObj = DataProvider.ExecuteScalar(
                "SELECT MANV_TIEPNHAN FROM DonDichVu WHERE MADON = @m", new SqlParameter("@m", maDon));
            string maNvLap = (manvObj == null || manvObj == DBNull.Value) ? null : Convert.ToString(manvObj);

            string maHd = ChungTuBanHangDAL.GenerateNewMaHoaDon();
            CreateHoaDonForDon(maHd, maDon, "Chuyển khoản", 10m, 0m, maNvLap);
        }
    }
}
