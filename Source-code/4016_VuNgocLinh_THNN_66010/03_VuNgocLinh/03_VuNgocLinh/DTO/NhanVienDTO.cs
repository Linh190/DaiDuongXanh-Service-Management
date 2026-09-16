using System;

namespace _03_VuNgocLinh.DTO
{
    public class NhanVienDTO
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string VaiTro { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayVaoLam { get; set; }
    }
}