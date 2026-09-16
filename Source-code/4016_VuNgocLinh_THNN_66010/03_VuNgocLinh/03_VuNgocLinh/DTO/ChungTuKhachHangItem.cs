namespace _03_VuNgocLinh.DTO
{
    /// <summary>
    /// Item dùng để bind ComboBox / hiển thị thông tin khách hàng trên form ChungTu.
    /// Ánh xạ đúng các cột trong bảng KhachHang của DB:
    ///   MAKH, TENKH, DIENTHOAIKH, EMAILKH, DIACHIKH
    /// </summary>
    public class ChungTuKhachHangItem
    {
        // MAKH VARCHAR(20)
        public string MaKhachHang { get; set; }

        // TENKH NVARCHAR(100)
        public string HoTen { get; set; }

        // DIENTHOAIKH VARCHAR(15)
        public string SoDienThoai { get; set; }

        // EMAILKH VARCHAR(100)
        public string Email { get; set; }

        // DIACHIKH NVARCHAR(200)
        public string DiaChi { get; set; }
    }
}
