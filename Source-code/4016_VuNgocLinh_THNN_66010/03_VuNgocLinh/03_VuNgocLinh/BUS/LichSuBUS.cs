using _03_VuNgocLinh.DAL;

namespace _03_VuNgocLinh.BUS
{
    public class LichSuBUS
    {
        public void InsertLichSuTrangThai(string maDon, string trangThaiCu, string trangThaiMoi, string maNvCapNhat = null, string ghiChu = null)
        {
            LichSuTrangThaiDonDAL.Insert(maDon, trangThaiCu, trangThaiMoi, maNvCapNhat, ghiChu);
        }
    }
}