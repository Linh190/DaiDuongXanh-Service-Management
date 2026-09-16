namespace _03_VuNgocLinh.DTO
{
    /// <summary>
    /// Item dùng để bind ComboBox nhân viên kiểm tra chứng từ.
    /// Theo trigger tg_ChungTu_KiemTraNguoiKiemTra:
    ///   chỉ VAITRO = 'Chủ doanh nghiệp' mới được duyệt chứng từ.
    /// Ánh xạ đúng các cột trong bảng NhanVien:
    ///   MANV, TENNV, EMAILNV, VAITRO
    /// </summary>
    public class ChungTuNhanVienItem
    {
        // MANV VARCHAR(20)
        public string MaNhanVien { get; set; }

        // TENNV NVARCHAR(100)
        public string HoTen { get; set; }

        // EMAILNV VARCHAR(100)
        public string Email { get; set; }

        // VAITRO — để hiển thị phân biệt trong ComboBox (tuỳ chọn)
        public string VaiTro { get; set; }

        /// <summary>
        /// Dùng làm DisplayMember cho ComboBox: "NV001 - Nguyễn Văn A"
        /// Hiển thị cả mã lẫn tên để người dùng nhận biết đúng nhân viên.
        /// </summary>
        public string MaVaTen { get; set; }
    }
}
