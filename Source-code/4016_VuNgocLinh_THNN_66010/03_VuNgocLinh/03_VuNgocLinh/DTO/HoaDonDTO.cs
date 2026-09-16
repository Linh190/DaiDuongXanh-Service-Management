using System;

namespace _03_VuNgocLinh.DTO
{
    public class HoaDonDTO
    {
        public string MaHoaDon { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public decimal TongTien { get; set; }
        public decimal ThueVAT { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal ThanhTien { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string TinhTrangThanhToan { get; set; }
        public string MaDon { get; set; }
        public string MaNhanVienLap { get; set; }
    }
}