using _03_VuNgocLinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace _03_VuNgocLinh.DAL
{
    public static class DonHangDAL
    {
        /// <summary>Return all DonDichVu with customer/employee display names.</summary>
        public static DataTable GetAllDonHang()
        {
            string sql = @"
SELECT DDV.MADON,
       DDV.NGAYDAT,
       DDV.NGAYTHUCHIEN,
       DDV.DIEMDI,
       DDV.DIEMDEN,
       DDV.GHICHU,
       DDV.TRANGTHAI,
       DDV.MAKH,
       DDV.MANV_TIEPNHAN,
       ISNULL(KH.TENKH, DDV.MAKH) AS TENKH,
       ISNULL(NV.TENNV, DDV.MANV_TIEPNHAN) AS TENNV
FROM DonDichVu DDV
LEFT JOIN KhachHang KH ON KH.MAKH = DDV.MAKH
LEFT JOIN NhanVien NV ON NV.MANV = DDV.MANV_TIEPNHAN
ORDER BY DDV.NGAYDAT DESC, DDV.MADON";
            return DataProvider.ExecuteQuery(sql);
        }

        /// <summary>Return single DonDichVu row by MADON or null.</summary>
        public static DataRow GetDonHangById(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon)) return null;
            string sql = @"
SELECT DDV.MADON,
       DDV.NGAYDAT,
       DDV.NGAYTHUCHIEN,
       DDV.DIEMDI,
       DDV.DIEMDEN,
       DDV.GHICHU,
       DDV.TRANGTHAI,
       DDV.MAKH,
       DDV.MANV_TIEPNHAN
FROM DonDichVu DDV
WHERE DDV.MADON = @madon";
            var dt = DataProvider.ExecuteQuery(sql, new SqlParameter("@madon", maDon));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Insert DonDichVu and its ChiTietDonDichVu in a transaction.
        /// Throws on validation or if MADON already exists.
        /// </summary>
        public static bool InsertDonHang(string maDon, DateTime ngayThucHien, string diemDi, string diemDen,
                                         string ghiChu, string trangThai, string maKh, string maNvTiepNhan,
                                         List<ChiTietDonDichVuDTO> chiTiet)
        {
            if (string.IsNullOrWhiteSpace(maDon)) throw new ArgumentException("MADON required.");
            if (string.IsNullOrWhiteSpace(diemDi)) throw new ArgumentException("DIEMDI required.");
            if (string.IsNullOrWhiteSpace(diemDen)) throw new ArgumentException("DIEMDEN required.");
            if (chiTiet == null || chiTiet.Count == 0) throw new ArgumentException("Order must have at least one detail.");

            DataProvider.ExecuteTransaction((conn, tran) =>
            {
                // check duplicate MADON
                using (var chk = new SqlCommand("SELECT 1 FROM DonDichVu WHERE MADON = @m", conn, tran))
                {
                    chk.Parameters.AddWithValue("@m", maDon);
                    if (chk.ExecuteScalar() != null)
                        throw new Exception("Mã đơn đã tồn tại.");
                }

                using (var cmd = new SqlCommand(
                    "INSERT INTO DonDichVu (MADON, NGAYDAT, NGAYTHUCHIEN, DIEMDI, DIEMDEN, GHICHU, TRANGTHAI, MAKH, MANV_TIEPNHAN) " +
                    "VALUES (@madon, GETDATE(), @ngaythuchien, @diemdi, @diemden, @ghichu, @trangthai, @makh, @manv)",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@madon", maDon);
                    cmd.Parameters.AddWithValue("@ngaythuchien", ngayThucHien);
                    cmd.Parameters.AddWithValue("@diemdi", diemDi.Trim());
                    cmd.Parameters.AddWithValue("@diemden", diemDen.Trim());
                    cmd.Parameters.AddWithValue("@ghichu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu);
                    cmd.Parameters.AddWithValue("@trangthai", string.IsNullOrWhiteSpace(trangThai) ? "Chờ xác nhận" : trangThai);
                    cmd.Parameters.AddWithValue("@makh", maKh);
                    cmd.Parameters.AddWithValue("@manv", string.IsNullOrWhiteSpace(maNvTiepNhan) ? (object)DBNull.Value : maNvTiepNhan);
                    cmd.ExecuteNonQuery();
                }

                // insert details
                foreach (var d in chiTiet)
                {
                    if (string.IsNullOrWhiteSpace(d.MaDichVu)) throw new Exception("Chi tiết thiếu MADV.");
                    if (d.SoLuong <= 0) throw new Exception("Số lượng phải > 0.");
                    if (d.DonGia < 0) throw new Exception("Đơn giá không được âm.");

                    using (var cmd = new SqlCommand(
                        "INSERT INTO ChiTietDonDichVu (MADON, MADV, SOLUONG, DONGIA, GHICHU) " +
                        "VALUES (@madon, @madv, @soluong, @dongia, @ghichu)",
                        conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@madon", maDon);
                        cmd.Parameters.AddWithValue("@madv", d.MaDichVu);
                        cmd.Parameters.AddWithValue("@soluong", d.SoLuong);
                        cmd.Parameters.AddWithValue("@dongia", d.DonGia);
                        cmd.Parameters.AddWithValue("@ghichu", string.IsNullOrWhiteSpace(d.GhiChu) ? (object)DBNull.Value : d.GhiChu);
                        cmd.ExecuteNonQuery();
                    }
                }
            });

            return true;
        }

        /// <summary>
        /// Update DonDichVu and optionally replace its detail lines.
        /// If details list is provided, existing ChiTiet rows for MADON are deleted and new ones inserted.
        /// </summary>
        public static bool UpdateDonHang(string maDon, DateTime? ngayThucHien, string diemDi, string diemDen,
                                         string ghiChu, string trangThai, string maKh, string maNvTiepNhan,
                                         List<ChiTietDonDichVuDTO> chiTiet = null)
        {
            if (string.IsNullOrWhiteSpace(maDon)) throw new ArgumentException("MADON required.");

            DataProvider.ExecuteTransaction((conn, tran) =>
            {
                // ✅ Bước 1: Lấy NGAYDAT gốc từ DB
                DateTime ngayDatGoc;
                using (var cmdGet = new SqlCommand(
                    "SELECT NGAYDAT FROM DonDichVu WHERE MADON = @madon", conn, tran))
                {
                    cmdGet.Parameters.AddWithValue("@madon", maDon);
                    var result = cmdGet.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                        throw new Exception("Không tìm thấy đơn để cập nhật.");
                    ngayDatGoc = Convert.ToDateTime(result);
                }

                // ✅ Bước 2: Nếu không truyền NGAYTHUCHIEN thì giữ nguyên,
                //           nếu có truyền thì kiểm tra >= NGAYDAT gốc
                DateTime ngayThucHienFinal;
                if (ngayThucHien.HasValue)
                {
                    if (ngayThucHien.Value < ngayDatGoc)
                        throw new Exception(
                            $"Ngày thực hiện ({ngayThucHien.Value:dd/MM/yyyy}) " +
                            $"không được trước ngày đặt ({ngayDatGoc:dd/MM/yyyy}).");
                    ngayThucHienFinal = ngayThucHien.Value;
                }
                else
                {
                    // Giữ nguyên NGAYTHUCHIEN cũ trong DB
                    using (var cmdNth = new SqlCommand(
                        "SELECT NGAYTHUCHIEN FROM DonDichVu WHERE MADON = @madon", conn, tran))
                    {
                        cmdNth.Parameters.AddWithValue("@madon", maDon);
                        ngayThucHienFinal = Convert.ToDateTime(cmdNth.ExecuteScalar());
                    }
                }

                // ✅ Bước 3: UPDATE — không đụng NGAYDAT
                using (var cmd = new SqlCommand(@"
            UPDATE DonDichVu
            SET NGAYTHUCHIEN  = @ngaythuchien,
                DIEMDI        = @diemdi,
                DIEMDEN       = @diemden,
                GHICHU        = @ghichu,
                TRANGTHAI     = @trangthai,
                MAKH          = @makh,
                MANV_TIEPNHAN = @manv
            WHERE MADON = @madon",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@ngaythuchien", ngayThucHienFinal);
                    cmd.Parameters.AddWithValue("@diemdi", string.IsNullOrWhiteSpace(diemDi) ? (object)DBNull.Value : diemDi.Trim());
                    cmd.Parameters.AddWithValue("@diemden", string.IsNullOrWhiteSpace(diemDen) ? (object)DBNull.Value : diemDen.Trim());
                    cmd.Parameters.AddWithValue("@ghichu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu);
                    cmd.Parameters.AddWithValue("@trangthai", string.IsNullOrWhiteSpace(trangThai) ? (object)DBNull.Value : trangThai);
                    cmd.Parameters.AddWithValue("@makh", string.IsNullOrWhiteSpace(maKh) ? (object)DBNull.Value : maKh);
                    cmd.Parameters.AddWithValue("@manv", string.IsNullOrWhiteSpace(maNvTiepNhan) ? (object)DBNull.Value : maNvTiepNhan);
                    cmd.Parameters.AddWithValue("@madon", maDon);
                    cmd.ExecuteNonQuery();
                }

                // Bước 4: Cập nhật chi tiết nếu có
                if (chiTiet != null)
                {
                    using (var del = new SqlCommand(
                        "DELETE FROM ChiTietDonDichVu WHERE MADON = @madon", conn, tran))
                    {
                        del.Parameters.AddWithValue("@madon", maDon);
                        del.ExecuteNonQuery();
                    }

                    foreach (var d in chiTiet)
                    {
                        if (string.IsNullOrWhiteSpace(d.MaDichVu)) throw new Exception("Chi tiết thiếu MADV.");
                        if (d.SoLuong <= 0) throw new Exception("Số lượng phải > 0.");
                        if (d.DonGia < 0) throw new Exception("Đơn giá không được âm.");

                        using (var cmd = new SqlCommand(
                            "INSERT INTO ChiTietDonDichVu (MADON, MADV, SOLUONG, DONGIA, GHICHU) " +
                            "VALUES (@madon, @madv, @soluong, @dongia, @ghichu)",
                            conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@madon", maDon);
                            cmd.Parameters.AddWithValue("@madv", d.MaDichVu);
                            cmd.Parameters.AddWithValue("@soluong", d.SoLuong);
                            cmd.Parameters.AddWithValue("@dongia", d.DonGia);
                            cmd.Parameters.AddWithValue("@ghichu", string.IsNullOrWhiteSpace(d.GhiChu) ? (object)DBNull.Value : d.GhiChu);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            });

            // Đơn dịch vụ chuyển sang "Hoàn thành" (qua FrmDonHang → CapNhatDonHang → đây)
            // → tự động lập hóa đơn và lưu vào CSDL (nếu đơn chưa có hóa đơn).
            // Lỗi lập hóa đơn KHÔNG được làm hỏng thao tác cập nhật đơn.
            if (!string.IsNullOrWhiteSpace(trangThai) && trangThai == "Hoàn thành")
            {
                try { HoaDonDAL.AutoCreateIfNotExists(maDon); }
                catch { /* không chặn luồng cập nhật đơn */ }
            }

            return true;
        }
        /// <summary>Delete DonDichVu and its ChiTiet rows.</summary>
        public static bool DeleteDonHang(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon))
                throw new ArgumentException("MADON required.");

            DataProvider.ExecuteTransaction((conn, tran) =>
            {
                using (var delDetails = new SqlCommand(
                    "DELETE FROM ChiTietDonDichVu WHERE MADON = @madon",
                    conn, tran))
                {
                    delDetails.Parameters.AddWithValue("@madon", maDon);
                    delDetails.ExecuteNonQuery();
                }

                using (var del = new SqlCommand(
                    "DELETE FROM DonDichVu WHERE MADON = @madon",
                    conn, tran))
                {
                    del.Parameters.AddWithValue("@madon", maDon);

                    int affected = del.ExecuteNonQuery();

                    if (affected == 0)
                        throw new Exception("Không tìm thấy đơn để xóa.");
                }
            });

            return true;
        }
        /// <summary>Return detail rows for given MADON (includes service name and computed THANHTIEN).</summary>
        public static DataTable GetChiTietByMaDon(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon)) return new DataTable();
            string sql = @"
SELECT ct.MADON, ct.MADV, dv.TENDV, ct.SOLUONG, ct.DONGIA, ct.THANHTIEN, ct.GHICHU
FROM ChiTietDonDichVu ct
LEFT JOIN DichVu dv ON dv.MADV = ct.MADV
WHERE ct.MADON = @madon";
            return DataProvider.ExecuteQuery(sql, new SqlParameter("@madon", maDon));
        }

        /// <summary>Quick update of DonDichVu.TRANGTHAI and optional MANV_TIEPNHAN.
        /// Khi chuyển sang "Hoàn thành", tự động lập hóa đơn (nếu đơn chưa có hóa đơn).</summary>
        public static bool UpdateTrangThai(string maDon, string trangThai, string maNvTiepNhan = null)
        {
            if (string.IsNullOrWhiteSpace(maDon)) throw new ArgumentException("MADON required.");
            if (string.IsNullOrWhiteSpace(trangThai)) throw new ArgumentException("TRANGTHAI required.");

            int rows = DataProvider.ExecuteNonQuery(
                "UPDATE DonDichVu SET TRANGTHAI = @trangthai, MANV_TIEPNHAN = @manv WHERE MADON = @madon",
                new SqlParameter("@trangthai", trangThai),
                new SqlParameter("@manv", string.IsNullOrWhiteSpace(maNvTiepNhan) ? (object)DBNull.Value : maNvTiepNhan),
                new SqlParameter("@madon", maDon));

            // Đơn dịch vụ đã "Hoàn thành" → tự động lập hóa đơn và lưu vào CSDL.
            // Lỗi lập hóa đơn (nếu có) KHÔNG được làm hỏng thao tác đổi trạng thái đơn —
            // chỉ ghi nhận âm thầm để nhân viên văn phòng có thể lập tay lại sau qua HoaDonDAL.
            if (rows > 0 && trangThai == "Hoàn thành")
            {
                try { HoaDonDAL.AutoCreateIfNotExists(maDon); }
                catch { /* không chặn luồng cập nhật trạng thái đơn */ }
            }

            return rows > 0;
        }
    }

    // Helper overload to allow ExecuteTransaction returning success flag
}