using System.Drawing;

namespace _03_VuNgocLinh
{
    /// <summary>
    /// Bảng màu thương hiệu Đại Dương Xanh — lấy từ go-shipping.vn
    /// Sử dụng class này khi cần set màu động trong code (.cs), không phải Designer.
    /// </summary>
    public static class AppTheme
    {
        // ── Màu chủ đạo (Primary) ────────────────────────────────────────────
        /// <summary>Xanh hải quân đậm — header, sidebar, status bar (#1C3664)</summary>
        public static readonly Color Navy = Color.FromArgb(28, 54, 100);

        /// <summary>Xanh hải quân tối hơn — hover/active trên Navy (#122449)</summary>
        public static readonly Color NavyDark = Color.FromArgb(18, 36, 73);

        /// <summary>Xanh đại dương — ribbon, button chính (#0078B4)</summary>
        public static readonly Color OceanBlue = Color.FromArgb(0, 120, 180);

        /// <summary>Xanh đại dương sáng hơn — hover trên OceanBlue (#1A90CC)</summary>
        public static readonly Color OceanBlueLight = Color.FromArgb(26, 144, 204);

        /// <summary>Xanh ngọc — accent, highlight (#00A3C4)</summary>
        public static readonly Color Teal = Color.FromArgb(0, 163, 196);

        // ── Màu nền (Background) ─────────────────────────────────────────────
        /// <summary>Nền workspace — xanh nhạt (#EBF5FB)</summary>
        public static readonly Color BackgroundLight = Color.FromArgb(235, 245, 251);

        /// <summary>Nền search/panel phụ — xanh dương nhạt (#D2EBFC)</summary>
        public static readonly Color BackgroundBlue = Color.FromArgb(210, 235, 252);

        /// <summary>Đường kẻ phân cách — xanh nhạt (#C8DDED)</summary>
        public static readonly Color BorderLight = Color.FromArgb(200, 221, 237);

        // ── Màu KPI Cards (Dashboard) ────────────────────────────────────────
        /// <summary>Card Doanh thu — xanh đại dương</summary>
        public static readonly Color CardRevenue = Color.FromArgb(0, 120, 180);

        /// <summary>Card Khách mới — teal</summary>
        public static readonly Color CardCustomer = Color.FromArgb(0, 163, 196);

        /// <summary>Card Hoàn thành — xanh lá (#27AE60)</summary>
        public static readonly Color CardDone = Color.FromArgb(39, 174, 96);

        /// <summary>Card Đang xử lý — cam (#F39C12)</summary>
        public static readonly Color CardProcessing = Color.FromArgb(243, 156, 18);

        /// <summary>Card Chờ xác nhận — đỏ (#E74C3C)</summary>
        public static readonly Color CardPending = Color.FromArgb(231, 76, 60);

        // ── Màu ngữ nghĩa (Semantic) ─────────────────────────────────────────
        /// <summary>Thành công / Hoàn thành (#27AE60)</summary>
        public static readonly Color Success = Color.FromArgb(39, 174, 96);

        /// <summary>Cảnh báo / Đang xử lý (#F39C12)</summary>
        public static readonly Color Warning = Color.FromArgb(243, 156, 18);

        /// <summary>Nguy hiểm / Lỗi / Chờ (#E74C3C)</summary>
        public static readonly Color Danger = Color.FromArgb(231, 76, 60);

        // ── Màu chữ (Text) ────────────────────────────────────────────────────
        /// <summary>Chữ đen hải quân — tiêu đề, nhãn chính (#1C3046)</summary>
        public static readonly Color TextDark = Color.FromArgb(28, 48, 70);

        /// <summary>Chữ trắng — trên nền tối</summary>
        public static readonly Color TextWhite = Color.White;

        /// <summary>Chữ xám phụ — placeholder, mô tả (#6B8FAF)</summary>
        public static readonly Color TextMuted = Color.FromArgb(107, 143, 175);

        // ── Màu nút (Buttons) ────────────────────────────────────────────────
        /// <summary>Nút chính (Lưu, Tìm, Thêm, v.v.) = OceanBlue</summary>
        public static Color ButtonPrimary => OceanBlue;

        /// <summary>Nút phụ / Thoát — nền nhạt</summary>
        public static Color ButtonSecondary => BackgroundLight;

        /// <summary>Màu khi hover trên nút chính</summary>
        public static Color ButtonPrimaryHover => OceanBlueLight;

        /// <summary>Màu khi hover trên nút phụ</summary>
        public static readonly Color ButtonHoverGray = Color.FromArgb(200, 221, 237);

        // ── Helper ────────────────────────────────────────────────────────────
        /// <summary>Áp dụng toàn bộ theme cho 1 form (gọi trong Form_Load hoặc constructor)</summary>
        public static void Apply(System.Windows.Forms.Form form)
        {
            form.BackColor = BackgroundLight;
        }
    }
}
