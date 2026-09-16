using System;
using System.Collections.Generic;

namespace _03_VuNgocLinh.DTO
{
    public class ChungTuBanHangData
    {
        public string MaDonHang { get; set; }
        public string MaKhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayChungTu { get; set; } = DateTime.Today;
        public string DiemDi { get; set; }
        public string DiemDen { get; set; }
        public string DienGiai { get; set; }
        public string TrangThai { get; set; } = "Chờ xác nhận";
        public string MaHoaDon { get; set; }
        public decimal ThueVat { get; set; } = 10m;
        public string PhuongThucThanhToan { get; set; } = "Tiền mặt";
        public decimal ThanhTienTruocThue { get; set; }
        public string MaChungTu { get; set; }  // override MACT, null = tự sinh
        public List<ChungTuChiTietData> ChiTiet { get; set; } = new List<ChungTuChiTietData>();
    }

    /// <summary>DTO cho một dòng chi tiết của DonDichVu/ChiTietDonDichVu</summary>
    public class ChungTuChiTietData
    {
        public string MaDon { get; set; }  // MADON  (FK → DonDichVu)
        public string MaDichVu { get; set; }  // MADV   (FK → DichVu)
        public int SoLuong { get; set; }  // SOLUONG > 0
        public decimal DonGia { get; set; }  // DONGIA >= 0
        public string GhiChu { get; set; }  // GHICHU (nullable)
    }
}