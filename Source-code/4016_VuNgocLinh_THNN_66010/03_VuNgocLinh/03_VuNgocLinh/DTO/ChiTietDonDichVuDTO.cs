using System;

namespace _03_VuNgocLinh.DTO
{
    public class ChiTietDonDichVuDTO
    {
        public string MaDon { get; set; }
        public string MaDichVu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
        public string GhiChu { get; set; }
    }
}