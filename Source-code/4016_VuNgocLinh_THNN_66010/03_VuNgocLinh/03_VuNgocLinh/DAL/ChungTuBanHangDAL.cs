using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using _03_VuNgocLinh.DTO;

namespace _03_VuNgocLinh.DAL
{
    public static class ChungTuBanHangDAL
    {
        // ════════════════════════════════════════════════════════════════
        // LOOKUP
        // ════════════════════════════════════════════════════════════════

        public static List<ChungTuKhachHangItem> GetAllKhachHang()
        {
            var list = new List<ChungTuKhachHangItem>();
            // FIX: cột SĐT khách hàng trong DB là DIENTHOAIKH (không phải SODIENTHOAI/SDT/...
            // như danh sách candidate cũ), nên trước đây luôn không khớp và trả về rỗng.
            var dt = DataProvider.ExecuteQuery(
                "SELECT * FROM KhachHang WHERE TRANGTHAI = N'Hoạt động' ORDER BY MAKH");

            foreach (DataRow r in dt.Rows)
            {
                string phone = dt.Columns.Contains("DIENTHOAIKH") && r["DIENTHOAIKH"] != DBNull.Value
                    ? Convert.ToString(r["DIENTHOAIKH"])
                    : "";
                string email = dt.Columns.Contains("EMAILKH") && r["EMAILKH"] != DBNull.Value
                    ? Convert.ToString(r["EMAILKH"])
                    : "";
                string diaChi = dt.Columns.Contains("DIACHIKH") && r["DIACHIKH"] != DBNull.Value
                    ? Convert.ToString(r["DIACHIKH"])
                    : "";

                list.Add(new ChungTuKhachHangItem
                {
                    MaKhachHang = Convert.ToString(r["MAKH"]),
                    HoTen = Convert.ToString(r["TENKH"]),
                    SoDienThoai = phone,
                    Email = email,
                    DiaChi = diaChi
                });
            }

            return list;
        }

        public static List<ChungTuNhanVienItem> GetAllNhanVien()
        {
            var list = new List<ChungTuNhanVienItem>();
            // FIX: cột Email nhân viên trong DB là EMAILNV (không phải EMAIL/E_MAIL/MAIL
            // như danh sách candidate cũ), nên trước đây luôn không khớp và trả về rỗng.
            var dt = DataProvider.ExecuteQuery(
                "SELECT * FROM NhanVien WHERE TRANGTHAI = N'Đang làm việc' AND VAITRO = N'Nhân viên bán hàng' ORDER BY MANV");

            foreach (DataRow r in dt.Rows)
            {
                string email = dt.Columns.Contains("EMAILNV") && r["EMAILNV"] != DBNull.Value
                    ? Convert.ToString(r["EMAILNV"])
                    : "";

                list.Add(new ChungTuNhanVienItem
                {
                    MaNhanVien = Convert.ToString(r["MANV"]),
                    HoTen = Convert.ToString(r["TENNV"]),
                    Email = email
                });
            }

            return list;
        }

        public static List<ChungTuDichVuItem> GetAllDichVu()
        {
            var list = new List<ChungTuDichVuItem>();
            var dt = DataProvider.ExecuteQuery(
                "SELECT MADV, TENDV, DONVITINH, GIABAN FROM DichVu WHERE TRANGTHAI = N'Đang cung cấp' ORDER BY MADV");

            foreach (DataRow r in dt.Rows)
            {
                decimal.TryParse(Convert.ToString(r["GIABAN"]), out decimal gia);
                list.Add(new ChungTuDichVuItem
                {
                    MaDichVu = Convert.ToString(r["MADV"]),
                    TenDichVu = Convert.ToString(r["TENDV"]),
                    DonViTinh = Convert.ToString(r["DONVITINH"]),
                    GiaBan = gia
                });
            }

            return list;
        }

        [Obsolete("Dùng GetAllDichVu() thay thế.")]
        public static List<ChungTuDichVuItem> GetAllSanPham() => GetAllDichVu();

        // ════════════════════════════════════════════════════════════════
        // LƯU ĐƠN DỊCH VỤ MỚI (DonDichVu + ChiTietDonDichVu)
        // ════════════════════════════════════════════════════════════════

        /// <summary>
        /// Lưu đơn dịch vụ mới (DonDichVu + ChiTietDonDichVu).
        /// LƯU Ý: KHÔNG tạo ChungTu ở đây — chứng từ chỉ được lập cho đơn dịch vụ
        /// đã hoàn thành (thực hiện tại FrmChungTu, không phải khi thêm đơn mới).
        /// Tên hàm "SaveChungTu" là tên lịch sử/legacy, giữ lại để tránh phải
        /// sửa toàn bộ chỗ gọi; hàm này chỉ thao tác trên DonDichVu.
        /// </summary>
        public static string SaveChungTu(ChungTuBanHangData chungTu, List<ChungTuChiTietData> chiTiet)
        {
            if (chungTu == null)
                throw new ArgumentNullException(nameof(chungTu));
            if (string.IsNullOrWhiteSpace(chungTu.MaDonHang))
                throw new ArgumentException("Mã đơn hàng không được để trống.");
            if (string.IsNullOrWhiteSpace(chungTu.MaKhachHang))
                throw new ArgumentException("Khách hàng không được để trống (MAKH NOT NULL).");
            if (string.IsNullOrWhiteSpace(chungTu.DiemDi))
                throw new ArgumentException("Điểm đi không được để trống.");
            if (string.IsNullOrWhiteSpace(chungTu.DiemDen))
                throw new ArgumentException("Điểm đến không được để trống.");
            if (chiTiet == null || chiTiet.Count == 0)
                throw new ArgumentException("Đơn phải có ít nhất một dịch vụ.");

            string trangThai = string.IsNullOrWhiteSpace(chungTu.TrangThai)
                ? "Chờ xác nhận"
                : chungTu.TrangThai;

            string insertedMact = null;

            DataProvider.ExecuteTransaction((conn, tran) =>
            {
                // Kiểm tra MADON trùng
                using (var cmdCheck = new SqlCommand(
                    "SELECT 1 FROM DonDichVu WHERE MADON = @madon", conn, tran))
                {
                    cmdCheck.Parameters.AddWithValue("@madon", chungTu.MaDonHang);
                    if (cmdCheck.ExecuteScalar() != null)
                        throw new Exception("Mã đơn '" + chungTu.MaDonHang + "' đã tồn tại.");
                }

                // Insert DonDichVu — use provided NgayChungTu for both NGAYDAT and NGAYTHUCHIEN
                using (var cmd = new SqlCommand(
                    "INSERT INTO DonDichVu (MADON, NGAYDAT, NGAYTHUCHIEN, DIEMDI, DIEMDEN, GHICHU, TRANGTHAI, MAKH, MANV_TIEPNHAN) " +
                    "VALUES (@madon, @ngaydat, @ngaythuchien, @diemdi, @diemden, @ghichu, @trangthai, @makh, @manv)",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@madon", chungTu.MaDonHang);
                    cmd.Parameters.AddWithValue("@ngaydat", chungTu.NgayChungTu);
                    cmd.Parameters.AddWithValue("@ngaythuchien", chungTu.NgayChungTu);
                    cmd.Parameters.AddWithValue("@diemdi", chungTu.DiemDi.Trim());
                    cmd.Parameters.AddWithValue("@diemden", chungTu.DiemDen.Trim());
                    cmd.Parameters.AddWithValue("@ghichu", string.IsNullOrWhiteSpace(chungTu.DienGiai)
                                                                ? (object)DBNull.Value
                                                                : chungTu.DienGiai);
                    cmd.Parameters.AddWithValue("@trangthai", trangThai);
                    cmd.Parameters.AddWithValue("@makh", chungTu.MaKhachHang);
                    cmd.Parameters.AddWithValue("@manv", string.IsNullOrWhiteSpace(chungTu.MaNhanVien)
                                                                ? (object)DBNull.Value
                                                                : chungTu.MaNhanVien);
                    cmd.ExecuteNonQuery();
                }

                // Insert ChiTietDonDichVu (unchanged)
                foreach (var ct in chiTiet)
                {
                    string maDV = ct.MaDichVu;
                    if (string.IsNullOrWhiteSpace(maDV))
                        throw new Exception("Chi tiết đơn thiếu mã dịch vụ.");
                    if (ct.SoLuong <= 0)
                        throw new Exception("Số lượng dịch vụ '" + maDV + "' phải lớn hơn 0.");
                    if (ct.DonGia < 0)
                        throw new Exception("Đơn giá dịch vụ '" + maDV + "' không được âm.");

                    using (var cmd = new SqlCommand(
                        "INSERT INTO ChiTietDonDichVu (MADON, MADV, SOLUONG, DONGIA, GHICHU) " +
                        "VALUES (@madon, @madv, @soluong, @dongia, @ghichu)",
                        conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@madon", chungTu.MaDonHang);
                        cmd.Parameters.AddWithValue("@madv", maDV);
                        cmd.Parameters.AddWithValue("@soluong", ct.SoLuong);
                        cmd.Parameters.AddWithValue("@dongia", ct.DonGia);
                        cmd.Parameters.AddWithValue("@ghichu", string.IsNullOrWhiteSpace(ct.GhiChu)
                                                                ? (object)DBNull.Value
                                                                : ct.GhiChu);
                        cmd.ExecuteNonQuery();
                    }
                }

                // KHÔNG insert vào bảng ChungTu tại đây.
                // Chứng từ (ChungTu) chỉ được lập khi đơn dịch vụ đã HOÀN THÀNH,
                // qua màn hình FrmChungTu (Văn phòng) — không phải khi tạo đơn mới.
                // Trước đây đoạn này insert cứng TRANGTHAI = "Chờ kiểm tra", trong khi
                // CK_ChungTu_TRANGTHAI chỉ cho phép: Chờ duyệt | Đã duyệt | Trả lại | Từ chối
                // → luôn vi phạm CHECK constraint. Đã bỏ hoàn toàn bước tạo ChungTu ở đây.
                insertedMact = chungTu.MaDonHang;
            });

            return insertedMact;
        }

        // ════════════════════════════════════════════════════════════════
        // SINH MÃ TỰ ĐỘNG
        // ════════════════════════════════════════════════════════════════

        public static string GenerateNewMaHoaDon()
        {
            object v = DataProvider.ExecuteScalar("SELECT MAX(MAHD) FROM HoaDon");
            return GenerateNextId(Convert.ToString(v), "HD", 5);
        }

        public static string GenerateNewMaDonHang()
        {
            object v = DataProvider.ExecuteScalar("SELECT MAX(MADON) FROM DonDichVu");
            return GenerateNextId(Convert.ToString(v), "DDV", 4);
        }

        public static bool MaHoaDonExists(string ma)
        {
            object v = DataProvider.ExecuteScalar(
                "SELECT 1 FROM HoaDon WHERE MAHD = @m",
                new SqlParameter("@m", ma));
            return v != null;
        }

        public static bool MaDonHangExists(string ma)
        {
            object v = DataProvider.ExecuteScalar(
                "SELECT 1 FROM DonDichVu WHERE MADON = @m",
                new SqlParameter("@m", ma));
            return v != null;
        }

        // Generate MACT using same helper but requires connection/transaction
        private static string GenerateNewMaChungTu(SqlConnection conn, SqlTransaction tran)
        {
            object v;
            using (var cmd = new SqlCommand("SELECT MAX(MACT) FROM ChungTu", conn, tran))
                v = cmd.ExecuteScalar();

            string candidate = GenerateNextId(Convert.ToString(v), "CT", 5);

            // Bảo vệ trùng: kiểm tra trong cùng transaction
            while (true)
            {
                using (var chk = new SqlCommand(
                    "SELECT COUNT(*) FROM ChungTu WHERE MACT = @m", conn, tran))
                {
                    chk.Parameters.AddWithValue("@m", candidate);
                    int cnt = (int)chk.ExecuteScalar();
                    if (cnt == 0) break;
                }
                candidate = GenerateNextId(candidate, "CT", 5);
            }

            return candidate;
        }
        // ════════════════════════════════════════════════════════════════
        // HELPER
        // ════════════════════════════════════════════════════════════════

        private static string GenerateNextId(string maxId, string prefix, int numberLength)
        {
            if (string.IsNullOrWhiteSpace(maxId))
                return prefix + "1".PadLeft(numberLength, '0');

            try
            {
                int i = maxId.Length - 1;
                while (i >= 0 && char.IsDigit(maxId[i])) i--;
                string numPart = (i < maxId.Length - 1) ? maxId.Substring(i + 1) : "0";
                int nextVal = int.Parse(numPart) + 1;
                string newNum = nextVal.ToString().PadLeft(Math.Max(numberLength, numPart.Length), '0');
                return (i >= 0 ? maxId.Substring(0, i + 1) : prefix) + newNum;
            }
            catch
            {
                return prefix + DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }
    }
}