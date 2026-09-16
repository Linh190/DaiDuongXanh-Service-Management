using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _03_VuNgocLinh.DAL
{
    public static class DichVuDAL
    {
        public static DataTable GetAll()
        {
            string sql = "SELECT MADV, TENDV, GIABAN, DONVITINH, MOTA, TRANGTHAI, MANHOM FROM DichVu ORDER BY MADV";
            return DataProvider.ExecuteQuery(sql);
        }

        public static DataRow GetById(string maDv)
        {
            var dt = DataProvider.ExecuteQuery("SELECT MADV, TENDV, GIABAN, DONVITINH, MOTA, TRANGTHAI, MANHOM FROM DichVu WHERE MADV = @id",
                new SqlParameter("@id", maDv));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static bool Exists(string maDv)
        {
            return DataProvider.ExecuteScalar("SELECT 1 FROM DichVu WHERE MADV = @id", new SqlParameter("@id", maDv)) != null;
        }

        public static bool Insert(string maDv, string tenDv, decimal giaBan, string donViTinh, string moTa, string maNhom)
        {
            string sql = @"INSERT INTO DichVu (MADV, TENDV, GIABAN, DONVITINH, MOTA, TRANGTHAI, MANHOM)
                           VALUES (@madv, @tendv, @gia, @dvt, @mota, N'?ang cung c?p', @manhom)";
            int r = DataProvider.ExecuteNonQuery(sql,
                new SqlParameter("@madv", maDv),
                new SqlParameter("@tendv", tenDv),
                new SqlParameter("@gia", giaBan),
                new SqlParameter("@dvt", donViTinh),
                new SqlParameter("@mota", (object)moTa ?? DBNull.Value),
                new SqlParameter("@manhom", maNhom));
            return r > 0;
        }

        public static bool Update(string maDv, string tenDv, decimal giaBan, string donViTinh, string moTa, string trangThai, string maNhom)
        {
            string sql = @"UPDATE DichVu
                           SET TENDV=@tendv, GIABAN=@gia, DONVITINH=@dvt, MOTA=@mota, TRANGTHAI=@tt, MANHOM=@manhom
                           WHERE MADV = @madv";
            int r = DataProvider.ExecuteNonQuery(sql,
                new SqlParameter("@tendv", tenDv),
                new SqlParameter("@gia", giaBan),
                new SqlParameter("@dvt", donViTinh),
                new SqlParameter("@mota", (object)moTa ?? DBNull.Value),
                new SqlParameter("@tt", trangThai),
                new SqlParameter("@manhom", maNhom),
                new SqlParameter("@madv", maDv));
            return r > 0;
        }

        public static bool Delete(string maDv)
        {
            int r = DataProvider.ExecuteNonQuery("DELETE FROM DichVu WHERE MADV = @id", new SqlParameter("@id", maDv));
            return r > 0;
        }
    }
}