using System;

namespace _03_VuNgocLinh.DTO
{
    public class LichSuTrangThaiDonDTO
    {
        public int MaLichSu { get; set; }
        public string MaDon { get; set; }
        public string TrangThaiCu { get; set; }
        public string TrangThaiMoi { get; set; }
        public string MaNhanVienCapNhat { get; set; }
        public DateTime ThoiGianCapNhat { get; set; }
        public string GhiChu { get; set; }
    }
}