using System;

namespace _03_VuNgocLinh.DTO
{
    public class TaiKhoanDTO
    {
        public string MaTaiKhoan { get; set; }    // MATK
        public string TenDangNhap { get; set; }   // TENDANGNHAP

        // keep canonical storage name used by DB code
        public string MatKhauHash { get; set; }   // MATKHAU_HASH

        // Backwards-compatible alias: allow code to set MatKhau (plain or hashed)
        public string MatKhau
        {
            get => MatKhauHash;
            set => MatKhauHash = value;
        }

        public string LoaiTaiKhoan { get; set; }  // LOAITAIKHOAN
        public string TrangThai { get; set; }     // TRANGTHAI

        public string MaKhachHang { get; set; }
        public string MaNhanVien { get; set; } = string.Empty;

        public string VaiTro
        {
            get => LoaiTaiKhoan;
            set => LoaiTaiKhoan = value;
        }

    }
}