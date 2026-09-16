using System;

namespace _03_VuNgocLinh.DTO
{
    /// <summary>
    /// Một dòng dịch vụ thuộc về một Đơn dịch vụ (ChiTietDonDichVu JOIN DichVu),
    /// hiển thị ĐẦY ĐỦ thông tin dịch vụ trong dgvDichVu của FrmChungTu khi
    /// người dùng chọn Mã đơn dịch vụ. Chỉ để HIỂN THỊ — không ghi ngược lại CSDL.
    /// </summary>
    public class ChungTuDonDichVuChiTietItem
    {
        public string MaDichVu { get; set; }     // MADV
        public string TenDichVu { get; set; }    // TENDV (join DichVu)
        public string DonViTinh { get; set; }    // DONVITINH (join DichVu)
        public int SoLuong { get; set; }         // SOLUONG
        public decimal DonGia { get; set; }      // DONGIA
        public decimal ThanhTien => SoLuong * DonGia;
        public string GhiChu { get; set; }       // GHICHU
    }
}
