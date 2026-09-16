using System;

namespace _03_VuNgocLinh.DTO
{
    // Đổi tên class "Models" → "KhachHangDTO" cho đúng convention

    public class ChungTuModel
    {
        public string MACT { get; set; }
        public string LOAICHUNGTU { get; set; }
        public string SOCHUNGTU { get; set; }
        public DateTime NGAYLAP { get; set; }
        public string MADON { get; set; }
        public string MANV_KIEMTRA { get; set; }
        public decimal? TONGTIEN { get; set; }
        public string TRANGTHAI { get; set; }
    }

    public class DonDichVuModel
    {
        public string MADON { get; set; }
        public DateTime NGAYDAT { get; set; }
        public DateTime NGAYTHUCHIEN { get; set; }
        public string DIEMDI { get; set; }
        public string DIEMDEN { get; set; }
        public string GHICHU { get; set; }
        public string TRANGTHAI { get; set; }
        public string MAKH { get; set; }
        public string MANV_TIEPNHAN { get; set; }
    }

    public class ChiTietDonDV
    {
        public string MADON { get; set; }
        public string MADV { get; set; }
        public int SOLUONG { get; set; }
        public decimal DONGIA { get; set; }
        public decimal THANHTIEN => SOLUONG * DONGIA;
        public string GHICHU { get; set; }
    }
}