using _03_VuNgocLinh.DAL;
using System;
using System.Data;

namespace _03_VuNgocLinh.BUS
{
    public class KhachHangBUS
    {
        // ----------------------------------------------------------------
        // READ
        // ----------------------------------------------------------------
        public DataTable GetAllTable() => KhachHangDAL.GetAll();

        public DataRow GetById(string maKh)
        {
            if (string.IsNullOrWhiteSpace(maKh)) return null;
            return KhachHangDAL.GetById(maKh);
        }

        // ----------------------------------------------------------------
        // CREATE — dùng InsertWithOptionalAccount để Form chỉ cần gọi BUS
        // tenDangNhap = null/empty → không tạo tài khoản
        // ----------------------------------------------------------------
        public bool Create(
            string maKh,
            string tenKh,
            string diaChi,
            string sdt,
            string email,
            string trangThai = "Hoạt động",
            DateTime? ngayTao = null,
            string tenDangNhap = null)
        {
            if (string.IsNullOrWhiteSpace(maKh)) return false;
            if (string.IsNullOrWhiteSpace(tenKh)) return false;

            return KhachHangDAL.InsertWithOptionalAccount(
                maKh, tenKh, diaChi, sdt, email,
                trangThai,
                ngayTao ?? DateTime.Today,
                ngaySinh: null,   // bảng KhachHang không có cột này
                gioiTinh: null,   // bảng KhachHang không có cột này
                tenDangNhap: tenDangNhap);
        }

        // ----------------------------------------------------------------
        // UPDATE
        // ----------------------------------------------------------------
        public bool Update(
            string maKh,
            string tenKh,
            string diaChi,
            string sdt,
            string email,
            string trangThai = null)
        {
            if (string.IsNullOrWhiteSpace(maKh)) return false;
            return KhachHangDAL.Update(maKh, tenKh, diaChi, sdt, email, trangThai);
        }

        // ----------------------------------------------------------------
        // DELETE
        // ----------------------------------------------------------------
        public bool Delete(string maKh)
        {
            if (string.IsNullOrWhiteSpace(maKh)) return false;
            return KhachHangDAL.Delete(maKh);
        }
    }
}