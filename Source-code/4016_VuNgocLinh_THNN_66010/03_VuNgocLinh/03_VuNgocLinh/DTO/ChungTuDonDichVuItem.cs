using System;

namespace _03_VuNgocLinh.DTO
{
    /// <summary>
    /// Đại diện 1 Đơn dịch vụ (DonDichVu) đã tồn tại trong CSDL,
    /// dùng để đổ vào cboMaDon trên FrmChungTu — người dùng CHỌN một đơn
    /// dịch vụ có sẵn để lập chứng từ cho đơn đó (không tạo đơn mới).
    /// </summary>
    public class ChungTuDonDichVuItem
    {
        public string MaDon { get; set; }          // MADON
        public string MaKhachHang { get; set; }     // MAKH
        public string TenKhachHang { get; set; }    // TENKH (join)
        public string DiemDi { get; set; }          // DIEMDI
        public string DiemDen { get; set; }         // DIEMDEN
        public DateTime NgayDat { get; set; }        // NGAYDAT
        public DateTime NgayThucHien { get; set; }   // NGAYTHUCHIEN
        public string TrangThai { get; set; }        // TRANGTHAI

        public override string ToString() =>
            $"{MaDon} - {TenKhachHang} ({DiemDi} → {DiemDen})";
    }
}
