using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using System;

namespace _03_VuNgocLinh.BUS
{
    public class TaiKhoanBUS
    {
        public TaiKhoanDTO Login(string tenDangNhap, string matKhau)
        {
            return TaiKhoanDAL.Login(tenDangNhap, matKhau);
        }
        /// <summary>
        /// Return the associated user id (MAKH or MANV) for a username, or null when not found.
        /// Used by UI code: new TaiKhoanBUS().GetUserID(username)
        /// </summary>
        public string GetUserID(string tenDangNhap)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap)) return null;
            try
            {
                return TaiKhoanDAL.GetUserId(tenDangNhap);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdatePassword(string tenDangNhap, string matKhauHash)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhauHash)) return false;
            return TaiKhoanDAL.UpdatePassword(tenDangNhap, matKhauHash);
        }

        public bool DangKyTaiKhoan(
            TaiKhoanDTO tk,
            KhachHangDTO kh)
        {
            if (tk == null || kh == null)
                return false;

            var result = TaiKhoanDAL.DangKyTaiKhoan(tk, kh);
            return result.Success;
        }
        public string GenerateNewMaKhachHang()
        {
            return TaiKhoanDAL.GenerateNewMaKhachHang();
        }
    }
}
