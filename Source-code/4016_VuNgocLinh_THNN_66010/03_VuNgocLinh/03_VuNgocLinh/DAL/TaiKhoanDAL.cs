using System;
using System.Data;
using System.Data.SqlClient;
using _03_VuNgocLinh.DTO;

namespace _03_VuNgocLinh.DAL
{
    public static class TaiKhoanDAL
    {
        // ════════════════════════════════════════════════════════════════
        // CHECK constraint values (từ DB):
        // CK_TaiKhoan_LOAI     : 'Khách hàng' | 'Nhân viên bán hàng' |
        //                        'Nhân viên văn phòng' |
        //                        'Nhân viên quản lý hệ thống' | 'Chủ doanh nghiệp'
        // CK_TaiKhoan_TRANGTHAI: 'Hoạt động' | 'Khóa'
        // CK_KhachHang_TRANGTHAI:'Hoạt động' | 'Khóa'
        // ════════════════════════════════════════════════════════════════

        public static TaiKhoanDTO Login(string tenDangNhap, string matKhauPlain)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhauPlain))
                return null;

            var dt = DataProvider.ExecuteQuery(
                "SELECT MATK, TENDANGNHAP, MATKHAU_HASH, LOAITAIKHOAN, TRANGTHAI, MAKH, MANV " +
                "FROM TaiKhoan " +
                "WHERE TENDANGNHAP = @u AND MATKHAU_HASH = @p AND TRANGTHAI = N'Hoạt động'",
                new SqlParameter("@u", tenDangNhap),
                new SqlParameter("@p", matKhauPlain));

            if (dt.Rows.Count == 0) return null;

            var r = dt.Rows[0];
            return new TaiKhoanDTO
            {
                MaTaiKhoan = Convert.ToString(r["MATK"]),
                TenDangNhap = Convert.ToString(r["TENDANGNHAP"]),
                MatKhauHash = Convert.ToString(r["MATKHAU_HASH"]),
                LoaiTaiKhoan = Convert.ToString(r["LOAITAIKHOAN"]),
                TrangThai = Convert.ToString(r["TRANGTHAI"]),
                MaKhachHang = r["MAKH"] == DBNull.Value ? null : Convert.ToString(r["MAKH"]),
                MaNhanVien = r["MANV"] == DBNull.Value ? null : Convert.ToString(r["MANV"])
            };
        }

        public static string GetUserId(string tenDangNhap)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap)) return null;
            object result = DataProvider.ExecuteScalar(
                "SELECT COALESCE(MAKH, MANV) FROM TaiKhoan WHERE TENDANGNHAP = @u",
                new SqlParameter("@u", tenDangNhap));
            return result?.ToString();
        }

        public static bool UpdatePassword(string tenDangNhap, string matKhauHash)
        {
            int rows = DataProvider.ExecuteNonQuery(
                "UPDATE TaiKhoan SET MATKHAU_HASH = @p WHERE TENDANGNHAP = @u",
                new SqlParameter("@p", matKhauHash),
                new SqlParameter("@u", tenDangNhap));
            return rows > 0;
        }

        // ── Sinh mã ─────────────────────────────────────────────────────
        // Dùng ISNUMERIC + CAST để so sánh theo số thật, không theo ký tự.
        // Overload (conn, tran) dùng bên trong transaction để tránh race condition.

        public static string GenerateNewMaKhachHang()
        {
            object v = DataProvider.ExecuteScalar(
                "SELECT ISNULL(MAX(CAST(SUBSTRING(MAKH, 3, LEN(MAKH)) AS INT)), 0) " +
                "FROM KhachHang WHERE MAKH LIKE 'KH%' AND ISNUMERIC(SUBSTRING(MAKH, 3, LEN(MAKH))) = 1");
            int next = Convert.ToInt32(v) + 1;
            return "KH" + next.ToString("D5");
        }

        private static string GenerateNewMaKhachHang(SqlConnection conn, SqlTransaction tran)
        {
            using (var cmd = new SqlCommand(
                "SELECT ISNULL(MAX(CAST(SUBSTRING(MAKH, 3, LEN(MAKH)) AS INT)), 0) " +
                "FROM KhachHang WHERE MAKH LIKE 'KH%' AND ISNUMERIC(SUBSTRING(MAKH, 3, LEN(MAKH))) = 1",
                conn, tran))
            {
                int next = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                return "KH" + next.ToString("D5");
            }
        }

        public static string GenerateNewMaTaiKhoan()
        {
            object v = DataProvider.ExecuteScalar(
                "SELECT ISNULL(MAX(CAST(SUBSTRING(MATK, 3, LEN(MATK)) AS INT)), 0) " +
                "FROM TaiKhoan WHERE MATK LIKE 'TK%' AND ISNUMERIC(SUBSTRING(MATK, 3, LEN(MATK))) = 1");
            int next = Convert.ToInt32(v) + 1;
            return "TK" + next.ToString("D5");
        }

        private static string GenerateNewMaTaiKhoan(SqlConnection conn, SqlTransaction tran)
        {
            using (var cmd = new SqlCommand(
                "SELECT ISNULL(MAX(CAST(SUBSTRING(MATK, 3, LEN(MATK)) AS INT)), 0) " +
                "FROM TaiKhoan WHERE MATK LIKE 'TK%' AND ISNUMERIC(SUBSTRING(MATK, 3, LEN(MATK))) = 1",
                conn, tran))
            {
                int next = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                return "TK" + next.ToString("D5");
            }
        }

        // ── Đăng ký ─────────────────────────────────────────────────────

        /// <summary>
        /// Đăng ký tài khoản mới.
        /// Trả về (true, null) nếu thành công.
        /// Trả về (false, message) nếu thất bại — message mô tả nguyên nhân cụ thể.
        /// </summary>
        public static (bool Success, string ErrorMessage) DangKyTaiKhoan(TaiKhoanDTO tk, KhachHangDTO kh)
        {
            if (tk == null) throw new ArgumentNullException(nameof(tk));
            if (kh == null) throw new ArgumentNullException(nameof(kh));

            try
            {
                DataProvider.ExecuteTransaction((conn, tran) =>
                {
                    // Kiểm tra tên đăng nhập trùng
                    using (var cmd = new SqlCommand(
                        "SELECT 1 FROM TaiKhoan WHERE TENDANGNHAP = @u", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@u", tk.TenDangNhap);
                        if (cmd.ExecuteScalar() != null)
                            throw new Exception("DUPLICATE_USERNAME");
                    }

                    // Kiểm tra email trùng
                    using (var cmd = new SqlCommand(
                        "SELECT 1 FROM KhachHang WHERE EMAILKH = @e", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@e", kh.Email);
                        if (cmd.ExecuteScalar() != null)
                            throw new Exception("DUPLICATE_EMAIL");
                    }

                    // Kiểm tra SĐT trùng (chỉ khi SĐT không rỗng)
                    string sdt = kh.SoDienThoai ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(sdt))
                    {
                        using (var cmd = new SqlCommand(
                            "SELECT 1 FROM KhachHang WHERE DIENTHOAIKH = @s", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@s", sdt);
                            if (cmd.ExecuteScalar() != null)
                                throw new Exception("DUPLICATE_SDT");
                        }
                    }

                    // Insert KhachHang — sinh mã BÊN TRONG transaction để tránh race condition
                    string makh = GenerateNewMaKhachHang(conn, tran);
                    kh.MaKhachHang = makh;   // cập nhật lại DTO để MATK dùng cùng makh

                    using (var cmd = new SqlCommand(
                        "INSERT INTO KhachHang " +
                        "(MAKH, TENKH, DIACHIKH, DIENTHOAIKH, EMAILKH, TRANGTHAI, NGAYDANGKY) " +
                        "VALUES (@makh, @ten, @dc, @sdt, @email, @trangthai, CONVERT(DATE,GETDATE()))",
                        conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@makh", kh.MaKhachHang);
                        cmd.Parameters.AddWithValue("@ten", kh.HoTen ?? string.Empty);
                        cmd.Parameters.AddWithValue("@dc", kh.DiaChi ?? string.Empty);
                        cmd.Parameters.AddWithValue("@sdt", sdt);
                        cmd.Parameters.AddWithValue("@email", kh.Email ?? string.Empty);
                        cmd.Parameters.AddWithValue("@trangthai", "Hoạt động");
                        cmd.ExecuteNonQuery();
                    }

                    // Insert TaiKhoan — sinh MATK BÊN TRONG transaction
                    string matk = GenerateNewMaTaiKhoan(conn, tran);
                    using (var cmd = new SqlCommand(
                        "INSERT INTO TaiKhoan " +
                        "(MATK, TENDANGNHAP, MATKHAU_HASH, LOAITAIKHOAN, TRANGTHAI, MAKH, MANV) " +
                        "VALUES (@matk, @ten, @pass, @loai, @trangthai, @makh, NULL)",
                        conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@matk", matk);
                        cmd.Parameters.AddWithValue("@ten", tk.TenDangNhap);
                        cmd.Parameters.AddWithValue("@pass", tk.MatKhauHash ?? tk.MatKhau ?? string.Empty);
                        cmd.Parameters.AddWithValue("@loai", "Khách hàng");
                        cmd.Parameters.AddWithValue("@trangthai", "Hoạt động");
                        cmd.Parameters.AddWithValue("@makh", kh.MaKhachHang);
                        cmd.ExecuteNonQuery();
                    }
                });

                return (true, null);
            }
            catch (Exception ex)
            {
                // Lấy message gốc (ExecuteTransaction re-throw nên unwrap nếu cần)
                string msg = ex.InnerException?.Message ?? ex.Message;

                switch (msg)
                {
                    case "DUPLICATE_USERNAME":
                        return (false, "Tên đăng nhập đã tồn tại.");
                    case "DUPLICATE_EMAIL":
                        return (false, "Email đã được đăng ký bởi tài khoản khác.");
                    case "DUPLICATE_SDT":
                        return (false, "Số điện thoại đã được đăng ký bởi tài khoản khác.");
                    default:
                        // Ghi log để debug, hiện thông báo thân thiện
                        System.Diagnostics.Debug.WriteLine("[DangKy] Lỗi DB: " + ex);
                        return (false, "Lỗi hệ thống: " + msg);
                }
            }
        }

        // ════════════════════════════════════════════════════════════════
        // TẠO TÀI KHOẢN CHO NHÂN VIÊN (Admin thực hiện)
        // Chọn NV từ danh sách NV chưa có TK
        // ════════════════════════════════════════════════════════════════
        public static (bool Success, string ErrorMessage) TaoTaiKhoanNhanVien(
            string maNV, string tenDangNhap, string matKhauHash, string loaiTaiKhoan)
        {
            try
            {
                DataProvider.ExecuteTransaction((conn, tran) =>
                {
                    // Kiểm tra tên đăng nhập trùng
                    using (var cmd = new SqlCommand(
                        "SELECT 1 FROM TaiKhoan WHERE TENDANGNHAP = @u", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@u", tenDangNhap);
                        if (cmd.ExecuteScalar() != null)
                            throw new Exception("DUPLICATE_USERNAME");
                    }

                    // Kiểm tra NV đã có TK chưa
                    using (var cmd = new SqlCommand(
                        "SELECT 1 FROM TaiKhoan WHERE MANV = @ma", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@ma", maNV);
                        if (cmd.ExecuteScalar() != null)
                            throw new Exception("NV_ALREADY_HAS_ACCOUNT");
                    }

                    // Sinh MATK bên trong transaction
                    string matk = GenerateNewMaTaiKhoan(conn, tran);

                    using (var cmd = new SqlCommand(
                        "INSERT INTO TaiKhoan (MATK, TENDANGNHAP, MATKHAU_HASH, LOAITAIKHOAN, TRANGTHAI, MAKH, MANV) " +
                        "VALUES (@matk, @ten, @pass, @loai, N'Hoạt động', NULL, @manv)",
                        conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@matk", matk);
                        cmd.Parameters.AddWithValue("@ten", tenDangNhap);
                        cmd.Parameters.AddWithValue("@pass", matKhauHash);
                        cmd.Parameters.AddWithValue("@loai", loaiTaiKhoan);
                        cmd.Parameters.AddWithValue("@manv", maNV);
                        cmd.ExecuteNonQuery();
                    }
                });

                return (true, null);
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException?.Message ?? ex.Message;
                switch (msg)
                {
                    case "DUPLICATE_USERNAME":
                        return (false, "Tên đăng nhập đã tồn tại.");
                    case "NV_ALREADY_HAS_ACCOUNT":
                        return (false, "Nhân viên này đã có tài khoản rồi.");
                    default:
                        return (false, "Lỗi hệ thống: " + msg);
                }
            }
        }

        // ════════════════════════════════════════════════════════════════
        // HELPER (đã dùng overload nội bộ bên trên thay cho GenerateNextId)
        // ════════════════════════════════════════════════════════════════
    }
}