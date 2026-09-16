using _03_VuNgocLinh.GUI.Pages.Admin;
using _03_VuNgocLinh.GUI.Pages.BanHang;
using _03_VuNgocLinh.GUI.Pages.KhachHang;
using _03_VuNgocLinh.GUI.Pages.Owner;
using _03_VuNgocLinh.GUI.Pages.TroGiup;
using _03_VuNgocLinh.GUI.Pages.VanPhong;
using _03_VuNgocLinh.GUI.Popups;
using System.Windows.Forms;

namespace _03_VuNgocLinh
{
    public static class GlobalPages
    {
        // ── ADMIN ──────────────────────────────────────────────────
        public static Form KetNoiCSDL { get; set; } = null;
        public static Form QuanLyTaiKhoan { get; set; } = null;
        public static Form Log { get; set; } = null;
        public static Form SaoluuPhucHoi { get; set; } = null;


        // ── BÁN HÀNG ──────────────────────────────────────────────
        public static Form DonHang { get; set; } = null;
        public static Form KhachHang { get; set; } = null;
        public static Form SalesDashboard { get; set; } = null;

        // ── KHÁCH HÀNG ────────────────────────────────────────────
        public static Form TrangChu { get; set; } = null;
        public static Form LichSuDonHang { get; set; } = null;

        // ── OWNER / ADMIN DASHBOARD ───────────────────────────────
        public static Form DanhMuc { get; set; } = null;
        public static Form OwnerDashboard { get; set; } = null;
        public static Form NhanVien { get; set; } = null; // NEW: FrmNhanVien

        public static Form ThongTinTrungTam { get; set; } = null; // FIX: was never loaded → NULL crash

        public static Form KTChungTu { get; set; } = null;        // FrmKTChungTu (kiểm tra chứng từ)
        // NOTE: BaoCaoChuSieuThi đã xóa — dead code, không bao giờ được dùng

        // ── VĂN PHÒNG ─────────────────────────────────────────────
        public static Form ChungTu { get; set; } = null;
        public static Form DonHangOffice { get; set; } = null;  // FrmDonHangVanPhong
        public static Form OfficeDashboard { get; set; } = null;

        // ── TRỢ GIÚP ──────────────────────────────────────────────
        public static Form TrangMoDau { get; set; } = null;
        public static Form ThongTinPhanMem { get; set; } = null;

        // ── POPUP DÙNG CHUNG ──────────────────────────────────────
        public static Form DoiMatKhau { get; set; } = null;

        // ──────────────────────────────────────────────────────────
        /// <summary>
        /// Khởi tạo tất cả pages cần thiết sau khi session/role được xác định.
        /// Gọi từ FrmMain sau khi đăng nhập thành công.
        /// </summary>
        public static void LoadEssentialPages()
        {
            // TRỢ GIÚP / DÙNG CHUNG
            if (TrangMoDau == null)
                TrangMoDau = CreatePage(new FrmTrangMoDau());

            if (ThongTinPhanMem == null)
                ThongTinPhanMem = CreatePage(new FrmThongTinPhanMem());

            if (DoiMatKhau == null)
                DoiMatKhau = CreatePage(new FrmDoimatkhau(""));

            // ADMIN / OWNER
            if (KetNoiCSDL == null)
                KetNoiCSDL = CreatePage(new FrmKetNoiCSDL());

            if (QuanLyTaiKhoan == null)
                QuanLyTaiKhoan = CreatePage(new FrmTaiKhoan());

            if (Log == null)
                Log = CreatePage(new FrmLog());

            if (DanhMuc == null)
                DanhMuc = CreatePage(new FrmDanhMuc());

            if (OwnerDashboard == null)
                OwnerDashboard = CreatePage(new FrmOwnerDash());

            if (KTChungTu == null)
                KTChungTu = CreatePage(new FrmKTChungTu());


            if (ThongTinTrungTam == null)
                ThongTinTrungTam = CreatePage(new FrmThongTinTrungTam());


            if (NhanVien == null)
                NhanVien = CreatePage(new FrmNhanVien());

            // BÁN HÀNG
            if (DonHang == null)
                DonHang = CreatePage(new FrmDonHang());

            if (KhachHang == null)
                KhachHang = CreatePage(new FrmKhachHang());

            if (SalesDashboard == null)
                SalesDashboard = CreatePage(new FrmSalesDashboard());

            // KHÁCH HÀNG
            if (TrangChu == null)
                TrangChu = CreatePage(new FrmTrangChu());

            if (LichSuDonHang == null)
                LichSuDonHang = CreatePage(new FrmLichSuDonHang());

            // VĂN PHÒNG
            if (ChungTu == null)
                ChungTu = CreatePage(new FrmChungTu());

            if (DonHangOffice == null)
                DonHangOffice = CreatePage(new FrmDonHangVanPhong());

            if (OfficeDashboard == null)
                OfficeDashboard = CreatePage(new FrmOfficeDashboard());
        }

        /// <summary>
        /// Giải phóng tất cả pages khi đăng xuất,
        /// để lần đăng nhập sau load lại đúng role.
        /// </summary>
        public static void DisposeAllPages()
        {
            Form[] all = {
                KetNoiCSDL, QuanLyTaiKhoan, Log, ThongTinTrungTam, NhanVien,
                DonHang, KhachHang, SalesDashboard,
                TrangChu, LichSuDonHang,
                DanhMuc, OwnerDashboard, KTChungTu,
                ChungTu, DonHangOffice, OfficeDashboard,
                TrangMoDau, ThongTinPhanMem,
                DoiMatKhau
            };
            foreach (var f in all)
            {
                if (f != null && !f.IsDisposed) f.Dispose();
            }
            KetNoiCSDL = QuanLyTaiKhoan = Log = ThongTinTrungTam = NhanVien =
            DonHang = KhachHang = SalesDashboard =
            TrangChu = LichSuDonHang =
            DanhMuc = OwnerDashboard = KTChungTu =
            ChungTu = DonHangOffice = OfficeDashboard =
            TrangMoDau = ThongTinPhanMem =
            DoiMatKhau = null;
        }

        private static Form CreatePage(Form form)
        {
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            return form;
        }
    }
}