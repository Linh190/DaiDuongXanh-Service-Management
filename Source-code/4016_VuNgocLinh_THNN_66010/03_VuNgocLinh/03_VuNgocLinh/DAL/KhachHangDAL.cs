using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _03_VuNgocLinh.DAL
{
    public static class KhachHangDAL
    {
        // ----------------------------------------------------------------
        // Sinh MATK tự động theo format TKxxx (tối đa VARCHAR(20))
        // Đọc MAX hiện tại trong DB để tránh trùng
        // ----------------------------------------------------------------
        private static string GenerateMatk(SqlConnection conn, SqlTransaction tran)
        {
            string sql = @"
SELECT ISNULL(MAX(CAST(SUBSTRING(MATK, 3, LEN(MATK)) AS INT)), 0)
FROM TaiKhoan
WHERE MATK LIKE 'TK%'
  AND ISNUMERIC(SUBSTRING(MATK, 3, LEN(MATK))) = 1";

            using (var cmd = new SqlCommand(sql, conn, tran))
            {
                int maxNum = Convert.ToInt32(cmd.ExecuteScalar());
                // TK001..TK999 → 7 ký tự, an toàn với VARCHAR(20)
                return "TK" + (maxNum + 1).ToString("D3");
            }
        }

        // ----------------------------------------------------------------
        // SELECT dùng chung — chỉ lấy cột thực có trong bảng KhachHang
        // KhachHang KHÔNG có NGAYSINHKH, GIOITINHKH → bỏ 2 cột đó
        // ----------------------------------------------------------------
        private static string BaseSelect => @"
SELECT KH.MAKH          AS maKhachHang,
       TK.TENDANGNHAP   AS tenDangNhap,
       KH.TENKH         AS hoTen,
       KH.EMAILKH       AS email,
       KH.DIACHIKH      AS diaChi,
       KH.DIENTHOAIKH   AS soDienThoai,
       KH.TRANGTHAI     AS loaiKhachHang,
       KH.NGAYDANGKY    AS ngayTao
FROM KhachHang KH
LEFT JOIN TaiKhoan TK ON TK.MAKH = KH.MAKH";

        public static DataTable GetAll()
        {
            string sql = BaseSelect + " ORDER BY KH.MAKH";
            return DataProvider.ExecuteQuery(sql);
        }

        public static DataRow GetById(string maKh)
        {
            string sql = BaseSelect + " WHERE KH.MAKH = @ma";
            var dt = DataProvider.ExecuteQuery(sql, new SqlParameter("@ma", maKh));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // ----------------------------------------------------------------
        // Insert KhachHang + tạo TaiKhoan trong 1 transaction
        // Bỏ NGAYSINHKH, GIOITINHKH vì không có trong schema
        // ----------------------------------------------------------------
        public static bool InsertWithOptionalAccount(
            string maKh,
            string tenKh,
            string diaChi,
            string sdt,
            string email,
            string trangThai,
            DateTime ngayTao,
            DateTime? ngaySinh,       // giữ tham số để Form không phải đổi chữ ký
            string gioiTinh,          // giữ tham số để Form không phải đổi chữ ký
            string tenDangNhap)
        {
            bool success = false;
            DataProvider.ExecuteTransaction((conn, tran) =>
            {
                // 1. Insert KhachHang — chỉ ghi các cột có trong schema
                using (var cmd = new SqlCommand(@"
INSERT INTO KhachHang (MAKH, TENKH, DIACHIKH, DIENTHOAIKH, EMAILKH, TRANGTHAI, NGAYDANGKY)
VALUES (@ma, @ten, @dc, @sdt, @email, @trangthai, @ngayTao)", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@ma", maKh);
                    cmd.Parameters.AddWithValue("@ten", tenKh);
                    cmd.Parameters.AddWithValue("@dc", (object)diaChi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@sdt", (object)sdt ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@trangthai", (object)trangThai ?? "Hoạt động");
                    cmd.Parameters.AddWithValue("@ngayTao", ngayTao.Date);

                    int r1 = cmd.ExecuteNonQuery();
                    if (r1 <= 0) throw new Exception("Thêm khách hàng vào DB thất bại.");
                }

                // 2. Tạo TaiKhoan nếu người dùng nhập tên đăng nhập
                if (!string.IsNullOrWhiteSpace(tenDangNhap))
                {
                    // Sinh MATK dạng TKxxx — tối đa 7 ký tự, an toàn với VARCHAR(20)
                    string matk = GenerateMatk(conn, tran);

                    using (var cmd2 = new SqlCommand(@"
INSERT INTO TaiKhoan (MATK, TENDANGNHAP, MATKHAU_HASH, LOAITAIKHOAN, TRANGTHAI, MAKH, MANV)
VALUES (@matk, @tendn, @hash, N'Khách hàng', N'Hoạt động', @makh, NULL)", conn, tran))
                    {
                        cmd2.Parameters.AddWithValue("@matk", matk);
                        cmd2.Parameters.AddWithValue("@tendn", tenDangNhap.Trim());
                        // Placeholder hash — thực tế nên dùng BCrypt; NOT NULL nên không để trống
                        cmd2.Parameters.AddWithValue("@hash", "$2b$12$placeholder");
                        cmd2.Parameters.AddWithValue("@makh", maKh);

                        int r2 = cmd2.ExecuteNonQuery();
                        if (r2 <= 0) throw new Exception("Tạo tài khoản thất bại.");
                    }
                }

                success = true;
            });

            return success;
        }

        // ----------------------------------------------------------------
        // Update — bỏ NGAYSINHKH, GIOITINHKH vì không có trong schema
        // Giữ tham số ngaySinh, gioiTinh để Form không phải sửa
        // ----------------------------------------------------------------
        public static bool Update(
            string maKh,
            string tenKh,
            string diaChi,
            string sdt,
            string email,
            string trangThai = null,
            DateTime? ngaySinh = null,   // chưa dùng — schema không có cột này
            string gioiTinh = null)      // chưa dùng — schema không có cột này
        {
            string sql = @"
UPDATE KhachHang
SET TENKH       = @ten,
    DIACHIKH    = @dc,
    DIENTHOAIKH = @sdt,
    EMAILKH     = @email"
                + (trangThai != null ? ", TRANGTHAI = @trangThai" : "") + @"
WHERE MAKH = @ma";

            var parms = new List<SqlParameter>
            {
                new SqlParameter("@ten",  tenKh),
                new SqlParameter("@dc",   (object)diaChi ?? DBNull.Value),
                new SqlParameter("@sdt",  (object)sdt    ?? DBNull.Value),
                new SqlParameter("@email",(object)email  ?? DBNull.Value),
                new SqlParameter("@ma",   maKh)
            };
            if (trangThai != null)
                parms.Add(new SqlParameter("@trangThai", trangThai));

            int r = DataProvider.ExecuteNonQuery(sql, parms.ToArray());
            return r > 0;
        }

        public static bool Delete(string maKh)
        {
            int r = DataProvider.ExecuteNonQuery(
                "DELETE FROM KhachHang WHERE MAKH = @ma",
                new SqlParameter("@ma", maKh));
            return r > 0;
        }

        public static List<Tuple<string, string>> GetActiveCustomersSimple()
        {
            var list = new List<Tuple<string, string>>();
            var dt = DataProvider.ExecuteQuery(
                "SELECT MAKH, TENKH FROM KhachHang WHERE TRANGTHAI = N'Hoạt động' ORDER BY MAKH");
            foreach (DataRow row in dt.Rows)
                list.Add(Tuple.Create(Convert.ToString(row["MAKH"]), Convert.ToString(row["TENKH"])));
            return list;
        }
    }
}