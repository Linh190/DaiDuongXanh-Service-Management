using System;

namespace _03_VuNgocLinh.DTO
{
    public class KhachHangDTO
    {
        public string MaKhachHang { get; set; }    // MAKH
        public string TenKhachHang { get; set; }   // TENKH

        // Backwards-compatible alias used in forms/code (HoTen)
        public string HoTen
        {
            get => TenKhachHang;
            set => TenKhachHang = value;
        }

        public string DiaChi { get; set; }        // DIACHIKH

        // Primary phone property
        public string DienThoai { get; set; }     // DIENTHOAIKH

        // Alias kept for older code (SoDienThoai)
        public string SoDienThoai
        {
            get => DienThoai;
            set => DienThoai = value;
        }

        public string Email { get; set; }         // EMAILKH

        // Some code stores the linked username on the customer
        public string TenDangNhap { get; set; }

        public string TrangThai { get; set; }     // TRANGTHAI
        public DateTime NgayDangKy { get; set; } = DateTime.Today; // NGAYDANGKY

    }
}