using System.Data;

namespace _03_VuNgocLinh.DAL
{
    public static class NhomDichVuRepository
    {
        public static DataTable GetAll()
        {
            const string sql = @"
SELECT MANHOM, TENNHOM, MOTA, TRANGTHAI
FROM NhomDichVu
ORDER BY TENNHOM";
            return DataProvider.ExecuteQuery(sql);
        }
    }
}
