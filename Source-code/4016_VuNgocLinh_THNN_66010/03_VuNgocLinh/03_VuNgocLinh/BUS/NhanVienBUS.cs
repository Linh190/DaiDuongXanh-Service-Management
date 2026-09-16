using _03_VuNgocLinh.DAL;
using System;
using System.Data;

namespace _03_VuNgocLinh.BUS
{
    public class NhanVienBUS
    {
        public DataTable GetAllTable() => NhanVienDAL.GetAll();

        public DataRow GetById(string maNv)
        {
            if (string.IsNullOrWhiteSpace(maNv)) return null;
            return NhanVienDAL.GetById(maNv);
        }

        public bool UpdateNhanVien(string maNv, string hoTen, string email, string soDienThoai, string diaChi, string vaiTro = null)
        {
            if (string.IsNullOrWhiteSpace(maNv)) return false;
            return NhanVienDAL.Update(maNv, hoTen, email, soDienThoai, diaChi, vaiTro);
        }

        public string GenerateNewMaNV() => NhanVienDAL.GenerateNewMaNV();

        public bool ThemNhanVien(string maNv, string hoTen, string email, string sdt, string diaChi, string vaiTro)
        {
            if (string.IsNullOrWhiteSpace(maNv) || string.IsNullOrWhiteSpace(hoTen)) return false;
            return NhanVienDAL.Insert(maNv, hoTen, email, sdt, diaChi, vaiTro);
        }

        public (bool Success, string Error) XoaNhanVien(string maNv)
        {
            if (string.IsNullOrWhiteSpace(maNv)) return (false, "Mã nhân viên không hợp lệ.");
            return NhanVienDAL.Delete(maNv);
        }

        public DataTable GetNhanVienChuaCoTK() => NhanVienDAL.GetNhanVienChuaCoTK();
    }
}