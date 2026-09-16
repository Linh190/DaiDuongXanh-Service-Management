using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _03_VuNgocLinh.DAL
{
    public static class NhanVienDAL
    {
        // Return table with columns the UI expects (aliases applied).
        public static DataTable GetAll()
        {
            string sql = @"
SELECT NV.MANV   AS maNhanVien,
       TK.TENDANGNHAP AS tenDangNhap,
       NV.TENNV  AS hoTen,
       NV.EMAILNV AS email,
       NV.DIACHINV AS diaChi,
       NV.SDTNV   AS soDienThoai,
       NV.VAITRO  AS vaiTro,
       NV.TRANGTHAI,
       NV.NGAYVAOLV
FROM NhanVien NV
LEFT JOIN TaiKhoan TK ON TK.MANV = NV.MANV
ORDER BY NV.MANV";
            return DataProvider.ExecuteQuery(sql);
        }

        public static DataRow GetById(string maNv)
        {
            var dt = DataProvider.ExecuteQuery(
                "SELECT * FROM (SELECT MANV, TENNV, EMAILNV, DIACHINV, SDTNV, VAITRO, TRANGTHAI, NGAYVAOLV FROM NhanVien) t WHERE MANV = @id",
                new SqlParameter("@id", maNv));
            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }

        public static List<Tuple<string, string>> GetActiveNhanVienSimple()
        {
            var list = new List<Tuple<string, string>>();
            var dt = DataProvider.ExecuteQuery("SELECT MANV, TENNV FROM NhanVien WHERE TRANGTHAI = N'Đang làm việc' ORDER BY MANV");
            foreach (DataRow r in dt.Rows)
                list.Add(Tuple.Create(Convert.ToString(r["MANV"]), Convert.ToString(r["TENNV"])));
            return list;
        }

        public static bool Update(string maNv, string ten, string email, string sdt, string diaChi, string vaiTro = null)
        {
            string sql = @"
UPDATE NhanVien
SET TENNV = @ten, EMAILNV = @email, SDTNV = @sdt, DIACHINV = @dc" +
                (vaiTro != null ? ", VAITRO = @vaiTro" : "") + @"
WHERE MANV = @ma";
            var parms = new List<SqlParameter>
            {
                new SqlParameter("@ten", ten),
                new SqlParameter("@email", email),
                new SqlParameter("@sdt", sdt),
                new SqlParameter("@dc", diaChi ?? string.Empty),
                new SqlParameter("@ma", maNv)
            };
            if (vaiTro != null) parms.Add(new SqlParameter("@vaiTro", vaiTro));
            int r = DataProvider.ExecuteNonQuery(sql, parms.ToArray());
            return r > 0;
        }

        // Sinh mã NV mới theo format NV001, NV002, ...
        public static string GenerateNewMaNV()
        {
            var dt = DataProvider.ExecuteQuery(
                "SELECT MAX(CAST(SUBSTRING(MANV,3,LEN(MANV)) AS INT)) AS maxNum " +
                "FROM NhanVien WHERE MANV LIKE 'NV%' AND ISNUMERIC(SUBSTRING(MANV,3,LEN(MANV)))=1");
            int next = 1;
            if (dt.Rows.Count > 0 && dt.Rows[0]["maxNum"] != DBNull.Value)
                next = Convert.ToInt32(dt.Rows[0]["maxNum"]) + 1;
            return "NV" + next.ToString("D3");
        }

        // Thêm nhân viên mới (chưa có tài khoản)
        public static bool Insert(string maNv, string ten, string email, string sdt, string diaChi, string vaiTro)
        {
            int r = DataProvider.ExecuteNonQuery(
                "INSERT INTO NhanVien (MANV, TENNV, EMAILNV, SDTNV, DIACHINV, VAITRO, TRANGTHAI, NGAYVAOLV) " +
                "VALUES (@ma, @ten, @email, @sdt, @dc, @vaiTro, N'Đang làm việc', CONVERT(DATE,GETDATE()))",
                new SqlParameter("@ma", maNv),
                new SqlParameter("@ten", ten),
                new SqlParameter("@email", email),
                new SqlParameter("@sdt", sdt),
                new SqlParameter("@dc", diaChi ?? string.Empty),
                new SqlParameter("@vaiTro", vaiTro));
            return r > 0;
        }

        // Xóa nhân viên (chỉ xóa được khi chưa có tài khoản hoặc không liên kết dữ liệu)
        public static (bool Success, string Error) Delete(string maNv)
        {
            try
            {
                // Kiểm tra có tài khoản không
                var dtTK = DataProvider.ExecuteQuery(
                    "SELECT COUNT(1) AS cnt FROM TaiKhoan WHERE MANV = @ma",
                    new SqlParameter("@ma", maNv));
                if (Convert.ToInt32(dtTK.Rows[0]["cnt"]) > 0)
                    return (false, "Nhân viên này đã có tài khoản. Hãy yêu cầu Admin xóa tài khoản trước.");

                int r = DataProvider.ExecuteNonQuery(
                    "DELETE FROM NhanVien WHERE MANV = @ma",
                    new SqlParameter("@ma", maNv));
                return r > 0 ? (true, null) : (false, "Không tìm thấy nhân viên để xóa.");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg.Contains("REFERENCE") || msg.Contains("FOREIGN KEY"))
                    return (false, "Không thể xóa vì nhân viên đã có dữ liệu liên quan (đơn hàng, chứng từ...).");
                return (false, "Lỗi: " + msg);
            }
        }

        // Lấy danh sách nhân viên chưa có tài khoản (dùng cho Admin tạo TK)
        public static DataTable GetNhanVienChuaCoTK()
        {
            return DataProvider.ExecuteQuery(
                "SELECT NV.MANV AS maNhanVien, NV.TENNV AS hoTen, NV.VAITRO AS vaiTro " +
                "FROM NhanVien NV " +
                "WHERE NV.TRANGTHAI = N'Đang làm việc' " +
                "  AND NOT EXISTS (SELECT 1 FROM TaiKhoan TK WHERE TK.MANV = NV.MANV) " +
                "ORDER BY NV.MANV");
        }
    }
}