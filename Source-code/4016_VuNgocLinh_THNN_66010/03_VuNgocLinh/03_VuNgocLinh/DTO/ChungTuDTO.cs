using System;

namespace _03_VuNgocLinh.DTO
{
    public class ChungTuDTO
    {
        // MACT VARCHAR(20) NOT NULL – PK
        public string MaChungTu { get; set; }

        // LOAICHUNGTU — CK: 'Vận đơn' | 'Hợp đồng' | 'Biên bản giao nhận'
        //                     | 'Chứng từ xuất nhập khẩu' | 'Khác'
        public string LoaiChungTu { get; set; }

        // SOCHUNGTU — UNIQUE
        public string SoChungTu { get; set; }

        // NGAYLAP
        public DateTime NgayLap { get; set; } = DateTime.Today;

        // TONGTIEN — nullable, >= 0
        public decimal? TongTien { get; set; }

        // TRANGTHAI — CK: 'Chờ duyệt' | 'Đã duyệt' | 'Trả lại' | 'Từ chối'
        public string TrangThai { get; set; } = "Chờ duyệt";

        // GHICHU
        public string GhiChu { get; set; }

        // NGAYDUYET
        public DateTime? NgayDuyet { get; set; }

        // MADON — FK → DonDichVu
        public string MaDon { get; set; }

        // MANV_KIEMTRA — FK → NhanVien (chỉ Chủ doanh nghiệp, theo trigger)
        public string MaNhanVienKiemTra { get; set; }

        // Thông tin hiển thị (JOIN)
        public string TenNhanVienKiemTra { get; set; }
        public string TrangThaiDon { get; set; }
    }
}
