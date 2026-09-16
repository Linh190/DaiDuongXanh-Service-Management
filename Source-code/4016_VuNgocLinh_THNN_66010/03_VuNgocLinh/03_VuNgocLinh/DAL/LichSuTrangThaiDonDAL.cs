using System;
using System.Data.SqlClient;

namespace _03_VuNgocLinh.DAL
{
    public static class LichSuTrangThaiDonDAL
    {
        public static void Insert(string maDon, string trangThaiCu, string trangThaiMoi, string manvCapNhat = null, string ghiChu = null)
        {
            DataProvider.ExecuteNonQuery(@"
INSERT INTO LichSuTrangThaiDon (MADON, TRANGTHAI_CU, TRANGTHAI_MOI, MANV_CAPNHAT, GHICHU)
VALUES (@madon, @cu, @moi, @manv, @ghichu)",
                new SqlParameter("@madon", maDon),
                new SqlParameter("@cu", (object)trangThaiCu ?? DBNull.Value),
                new SqlParameter("@moi", trangThaiMoi),
                new SqlParameter("@manv", (object)manvCapNhat ?? DBNull.Value),
                new SqlParameter("@ghichu", (object)ghiChu ?? DBNull.Value));
        }
    }
}