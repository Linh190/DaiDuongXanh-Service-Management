using System;

namespace _03_VuNgocLinh.DTO
{
    public class DichVuDTO
    {
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal GiaBan { get; set; }
        public string DonViTinh { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }
        public string MaNhom { get; set; }

        // Added for UI binding in FrmProductView:
        public string TenNhom { get; set; }
    }
}