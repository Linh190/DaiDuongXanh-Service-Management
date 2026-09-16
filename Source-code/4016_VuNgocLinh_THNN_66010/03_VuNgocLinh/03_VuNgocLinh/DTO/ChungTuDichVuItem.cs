using System;

namespace _03_VuNgocLinh.DTO
{
    /// <summary>
    /// Lightweight DTO used by FrmChungTu to represent a service (DichVu).
    /// Matches DB columns: MADV, TENDV, DONVITINH, GIABAN.
    /// </summary>
    public class ChungTuDichVuItem
    {
        public string MaDichVu { get; set; }     // MADV
        public string TenDichVu { get; set; }    // TENDV
        public string DonViTinh { get; set; }    // DONVITINH
        public decimal GiaBan { get; set; }      // GIABAN

        public override string ToString() => $"{MaDichVu} - {TenDichVu}";
    }
}
