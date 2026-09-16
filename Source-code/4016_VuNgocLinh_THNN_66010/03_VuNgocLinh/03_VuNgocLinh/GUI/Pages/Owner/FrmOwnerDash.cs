using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace _03_VuNgocLinh.GUI.Pages.Owner
{
    public partial class FrmOwnerDash : Form
    {
        private readonly NhanVienBUS _nvBus = new NhanVienBUS();

        // ── Brand colours (mirror AppTheme để không cần thêm dependency) ──
        private static readonly Color CLR_NAVY = Color.FromArgb(28, 54, 100);
        private static readonly Color CLR_OCEAN = Color.FromArgb(0, 120, 180);
        private static readonly Color CLR_TEAL = Color.FromArgb(0, 163, 196);
        private static readonly Color CLR_GREEN = Color.FromArgb(39, 174, 96);
        private static readonly Color CLR_ORANGE = Color.FromArgb(243, 156, 18);
        private static readonly Color CLR_RED = Color.FromArgb(231, 76, 60);
        private static readonly Color CLR_BG = Color.FromArgb(235, 245, 251);
        private static readonly Color CLR_TEXT_DARK = Color.FromArgb(28, 48, 70);
        private static readonly Color CLR_BORDER = Color.FromArgb(200, 221, 237);

        public FrmOwnerDash()
        {
            InitializeComponent();

            // Chart legend guard
            if (chartDoanhThu.Legends.Count == 0)
                chartDoanhThu.Legends.Add(new Legend("Legend1"));

            foreach (var s in chartDoanhThu.Series)
                if (chartDoanhThu.Legends.FindByName(s.Legend) == null)
                    s.Legend = chartDoanhThu.Legends[0].Name;
        }

        // ─────────────────────────────────────────────────────────────────────
        // FORM LOAD
        // ─────────────────────────────────────────────────────────────────────
        private void FrmOwnerDash_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyRuntimeTheme();
                LoadNhanVienInfo();
                LoadDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dashboard: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // RUNTIME THEME (hover effects, DGV row colours by XepLoai, chart style)
        // ─────────────────────────────────────────────────────────────────────
        private void ApplyRuntimeTheme()
        {
            // Button hover: lighten on MouseEnter, restore on MouseLeave
            void AddHover(Button btn, Color baseColor)
            {
                Color lighter = ControlPaint.Light(baseColor, 0.2f);
                btn.MouseEnter += (s, _) => btn.BackColor = lighter;
                btn.MouseLeave += (s, _) => btn.BackColor = baseColor;
            }
            AddHover(btnBaocaoNV, CLR_GREEN);
            AddHover(btnBaocaoKH, CLR_TEAL);
            AddHover(btnBaocaoDonDV, CLR_ORANGE);

            // KPI card hover: slightly lighten entire card
            void AddCardHover(Panel pnl, Color baseColor)
            {
                Color hover = ControlPaint.Light(baseColor, 0.15f);
                pnl.MouseEnter += (s, _) => pnl.BackColor = hover;
                pnl.MouseLeave += (s, _) => pnl.BackColor = baseColor;
            }
            AddCardHover(pnlChoXacNhan, CLR_RED);
            AddCardHover(pnlDangXuLy, CLR_ORANGE);
            AddCardHover(pnlHoanThanh, CLR_GREEN);
            AddCardHover(pnlKhachMoi, CLR_TEAL);
            AddCardHover(pnlDoanhThu, CLR_OCEAN);
        }

        // ─────────────────────────────────────────────────────────────────────
        // LOAD USER INFO
        // ─────────────────────────────────────────────────────────────────────
        private void LoadNhanVienInfo()
        {
            try
            {
                var manv = Session.UserID;
                var role = Session.Role ?? "";
                string display = "Xin chào";

                if (!string.IsNullOrWhiteSpace(manv))
                {
                    var row = _nvBus.GetById(manv);
                    if (row != null)
                    {
                        var hoten = row["TENNV"]?.ToString();
                        display = "Xin chào, " + (string.IsNullOrWhiteSpace(hoten) ? manv : hoten);
                    }
                }

                lblNhanVien.Text = string.IsNullOrWhiteSpace(role)
                    ? display
                    : $"{display}    •    Vai trò: {role}";
            }
            catch
            {
                lblNhanVien.Text = "Xin chào";
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // DASHBOARD ORCHESTRATOR
        // ─────────────────────────────────────────────────────────────────────
        private void LoadDashboard()
        {
            LoadOverviewCounts();
            LoadHieuSuatNhanVien();
            LoadRevenueChart();
        }

        // ─────────────────────────────────────────────────────────────────────
        // KPI CARDS — số liệu tổng quan
        // ─────────────────────────────────────────────────────────────────────
        private void LoadOverviewCounts()
        {
            try
            {
                var choXac = Convert.ToInt32(DataProvider.ExecuteScalar(
                    "SELECT COUNT(*) FROM DonDichVu WHERE TRANGTHAI = N'Chờ xác nhận'") ?? 0);
                var dangXuLy = Convert.ToInt32(DataProvider.ExecuteScalar(
                    "SELECT COUNT(*) FROM DonDichVu WHERE TRANGTHAI = N'Đang xử lý'") ?? 0);
                var hoanThanh = Convert.ToInt32(DataProvider.ExecuteScalar(
                    "SELECT COUNT(*) FROM DonDichVu WHERE TRANGTHAI = N'Hoàn thành'") ?? 0);
                var khachMoi = Convert.ToInt32(DataProvider.ExecuteScalar(
                    "SELECT COUNT(*) FROM KhachHang " +
                    "WHERE MONTH(NGAYDANGKY)=MONTH(GETDATE()) AND YEAR(NGAYDANGKY)=YEAR(GETDATE())") ?? 0);

                decimal doanhThu = 0;
                var dtObj = DataProvider.ExecuteScalar("SELECT ISNULL(SUM(THANHTIEN),0) FROM HoaDon");
                if (dtObj != null && dtObj != DBNull.Value)
                    decimal.TryParse(dtObj.ToString(), out doanhThu);

                // Số (to, đậm) — set qua lblXxxNum
                lblChoXacNhanNum.Text = $"{choXac}";
                lblDangXuLyNum.Text = $"{dangXuLy}";
                lblHoanThanhNum.Text = $"{hoanThanh}";
                lblKhachMoiNum.Text = $"{khachMoi}";
                lblDoanhThuNum.Text = $"{doanhThu:N0} đ";

                // Caption (nhỏ) đã đặt sẵn trong Designer, không cần set lại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải số liệu tổng quan: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // BẢNG HIỆU SUẤT NHÂN VIÊN
        // ─────────────────────────────────────────────────────────────────────
        private void LoadHieuSuatNhanVien()
        {
            try
            {
                string sql = @"
WITH Agg AS (
    SELECT NV.MANV, NV.TENNV, NV.VAITRO,
           ISNULL(dv.SoDonXuLy,0)          AS SoDonXuLy,
           ISNULL(hd.SoHoaDonLap,0)        AS SoHoaDonLap,
           ISNULL(ct.SoChungTuKiemTra,0)   AS SoChungTuKiemTra,
           (ISNULL(dv.SoDonXuLy,0) + ISNULL(hd.SoHoaDonLap,0) + ISNULL(ct.SoChungTuKiemTra,0)) AS TongCongViec
    FROM NhanVien NV
    LEFT JOIN (SELECT MANV_TIEPNHAN, COUNT(*) AS SoDonXuLy
               FROM DonDichVu GROUP BY MANV_TIEPNHAN) dv ON dv.MANV_TIEPNHAN = NV.MANV
    LEFT JOIN (SELECT MANV_LAP,      COUNT(*) AS SoHoaDonLap
               FROM HoaDon          GROUP BY MANV_LAP)      hd ON hd.MANV_LAP      = NV.MANV
    LEFT JOIN (SELECT MANV_KIEMTRA,  COUNT(*) AS SoChungTuKiemTra
               FROM ChungTu         GROUP BY MANV_KIEMTRA)  ct ON ct.MANV_KIEMTRA  = NV.MANV
)
SELECT MANV, TENNV, VAITRO, SoDonXuLy, SoHoaDonLap, SoChungTuKiemTra, TongCongViec,
       CASE WHEN TongCongViec >= 100 THEN 100
            WHEN TongCongViec BETWEEN 80 AND 99  THEN 90
            WHEN TongCongViec BETWEEN 50 AND 79  THEN 80
            WHEN TongCongViec BETWEEN 30 AND 49  THEN 70
            WHEN TongCongViec BETWEEN 10 AND 29  THEN 60
            ELSE 50 END AS DiemHieuSuat,
       CASE WHEN TongCongViec >= 90             THEN N'Xuất sắc'
            WHEN TongCongViec BETWEEN 80 AND 89 THEN N'Tốt'
            WHEN TongCongViec BETWEEN 65 AND 79 THEN N'Khá'
            ELSE N'Cần cải thiện' END AS XepLoai
FROM Agg
ORDER BY TongCongViec DESC, MANV;";

                DataTable dt = DataProvider.ExecuteQuery(sql);
                dgvHieuSuatNV.DataSource = dt;

                // Tiêu đề cột thân thiện
                var headers = new Dictionary<string, string>
                {
                    ["MANV"] = "Mã NV",
                    ["TENNV"] = "Họ tên nhân viên",
                    ["VAITRO"] = "Vai trò",
                    ["SoDonXuLy"] = "Đơn xử lý",
                    ["SoHoaDonLap"] = "Hóa đơn lập",
                    ["SoChungTuKiemTra"] = "Chứng từ KT",
                    ["TongCongViec"] = "Tổng KL công việc",
                    ["DiemHieuSuat"] = "Điểm HS",
                    ["XepLoai"] = "Xếp loại",
                };
                foreach (var kv in headers)
                    if (dgvHieuSuatNV.Columns[kv.Key] != null)
                        dgvHieuSuatNV.Columns[kv.Key].HeaderText = kv.Value;

                dgvHieuSuatNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHieuSuatNV.ReadOnly = true;
                dgvHieuSuatNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Tô màu hàng theo xếp loại
                ColorRowsByXepLoai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hiệu suất nhân viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorRowsByXepLoai()
        {
            foreach (DataGridViewRow row in dgvHieuSuatNV.Rows)
            {
                string xl = row.Cells["XepLoai"]?.Value?.ToString() ?? "";
                Color bg;
                switch (xl)
                {
                    case "Xuất sắc": bg = Color.FromArgb(207, 242, 222); break; // xanh lá nhạt
                    case "Tốt": bg = Color.FromArgb(210, 240, 255); break; // xanh dương nhạt
                    case "Khá": bg = Color.FromArgb(255, 243, 205); break; // vàng nhạt
                    case "Cần cải thiện": bg = Color.FromArgb(255, 224, 220); break; // đỏ nhạt
                    default: bg = Color.White; break;
                }
                row.DefaultCellStyle.BackColor = bg;
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // BIỂU ĐỒ DOANH THU
        // ─────────────────────────────────────────────────────────────────────
        private void LoadRevenueChart()
        {
            try
            {
                string sql = @"
SELECT TOP 10 dv.TENDV AS TenDichVu,
       SUM(ct.SOLUONG * ct.DONGIA) AS TongTien
FROM ChiTietDonDichVu ct
INNER JOIN DichVu    dv ON dv.MADV = ct.MADV
INNER JOIN DonDichVu d  ON d.MADON = ct.MADON
INNER JOIN HoaDon    h  ON h.MADON = d.MADON
GROUP BY dv.TENDV
ORDER BY SUM(ct.SOLUONG * ct.DONGIA) DESC";

                DataTable dt = DataProvider.ExecuteQuery(sql);

                // ── Style chart area ──────────────────────────────────
                if (chartDoanhThu.ChartAreas.Count == 0)
                    chartDoanhThu.ChartAreas.Add(new ChartArea("ChartArea1"));

                var area = chartDoanhThu.ChartAreas[0];
                area.BackColor = Color.White;
                area.AxisX.LineColor = CLR_BORDER;
                area.AxisY.LineColor = CLR_BORDER;
                area.AxisX.MajorGrid.LineColor = CLR_BG;
                area.AxisY.MajorGrid.LineColor = CLR_BG;
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8f);
                area.AxisX.LabelStyle.ForeColor = CLR_TEXT_DARK;
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8f);
                area.AxisY.LabelStyle.ForeColor = CLR_TEXT_DARK;
                area.AxisY.LabelStyle.Format = "N0";
                area.AxisY.Title = "Doanh thu (đ)";
                area.AxisY.TitleFont = new Font("Segoe UI", 8f, FontStyle.Bold);
                area.AxisY.TitleForeColor = CLR_TEXT_DARK;
                area.AxisX.Interval = 1;
                area.AxisX.LabelStyle.Angle = -40;
                area.BorderDashStyle = ChartDashStyle.NotSet;

                // ── Series ───────────────────────────────────────────
                var series = chartDoanhThu.Series.Count > 0
                    ? chartDoanhThu.Series[0]
                    : chartDoanhThu.Series.Add("DoanhThu");

                series.ChartType = SeriesChartType.Column;
                series.Color = CLR_OCEAN;
                series.BorderColor = Color.FromArgb(0, 100, 160);
                series.BorderWidth = 0;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N0";
                series.Font = new Font("Segoe UI", 7.5f);
                series.LabelForeColor = CLR_TEXT_DARK;
                series.LegendText = "Doanh thu theo dịch vụ";
                series.Points.Clear();

                // ── Gradient colours for bars (Ocean→Teal) ───────────
                Color[] barColors = {
                    CLR_OCEAN,
                    Color.FromArgb(0, 130, 190),
                    Color.FromArgb(0, 140, 195),
                    CLR_TEAL,
                    Color.FromArgb(0, 155, 200),
                    Color.FromArgb(0, 160, 200),
                    Color.FromArgb(26, 144, 204),
                    Color.FromArgb(0, 148, 196),
                    Color.FromArgb(0, 153, 196),
                    Color.FromArgb(39, 174, 150),
                };

                // ── Legend ───────────────────────────────────────────
                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Legends.Clear();
                var legend = new Legend("LegendDoanhThu")
                {
                    Docking = Docking.Bottom,
                    LegendStyle = LegendStyle.Row,
                    Font = new Font("Segoe UI", 8f),
                    ForeColor = CLR_TEXT_DARK,
                    BackColor = Color.White,
                };
                chartDoanhThu.Legends.Add(legend);
                series.Legend = "LegendDoanhThu";

                // ── Compute total for percentage tooltips ─────────────
                decimal total = 0m;
                foreach (DataRow r in dt.Rows)
                    if (r["TongTien"] != DBNull.Value)
                        try { total += Convert.ToDecimal(r["TongTien"]); } catch { }

                int colorIdx = 0;
                foreach (DataRow r in dt.Rows)
                {
                    var name = Convert.ToString(r["TenDichVu"]);
                    var value = r["TongTien"] == DBNull.Value ? 0m : Convert.ToDecimal(r["TongTien"]);

                    int idx = series.Points.AddY(Convert.ToDouble(value));
                    var pt = series.Points[idx];
                    pt.Color = barColors[colorIdx % barColors.Length];
                    pt.AxisLabel = name;
                    pt.Label = $"{value:N0}";
                    double pct = total > 0m ? (double)(value / total) : 0.0;
                    pt.ToolTip = $"{name}\n{value:N0} đ  ({pct:P1})";
                    colorIdx++;
                }

                if (chartDoanhThu.ChartAreas.Count > 0)
                    chartDoanhThu.ChartAreas[0].RecalculateAxesScale();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ doanh thu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // EVENT STUBS (kept for Designer compatibility)
        // ─────────────────────────────────────────────────────────────────────
        private void lblNhanVien_Click(object sender, EventArgs e) { }
        private void lblChoXacNhan_Click(object sender, EventArgs e) { }
        private void lblDangXuLy_Click(object sender, EventArgs e) { }
        private void lblHoanThanh_Click(object sender, EventArgs e) { }
        private void lblKhachMoi_Click(object sender, EventArgs e) { }
        private void lblDoanhThu_Click(object sender, EventArgs e) { }
        private void dgvHieuSuatNV_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void chartDoanhThu_Click(object sender, EventArgs e) { }

        // ─────────────────────────────────────────────────────────────────────
        // BÁO CÁO PDF — DOANH THU THEO NHÂN VIÊN
        // ─────────────────────────────────────────────────────────────────────
        private void btnBaocaoNV_Click(object sender, EventArgs e)
        {
            try
            {
                XuatBaoCaoPdf(BuildBaoCaoDoanhThuNhanVien(),
                    "BaoCao_DoanhThu_NhanVien.pdf", "Báo cáo doanh thu theo nhân viên");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable BuildBaoCaoDoanhThuNhanVien()
        {
            return DataProvider.ExecuteQuery(@"
SELECT NV.MANV AS [Mã NV], NV.TENNV AS [Họ tên NV], NV.VAITRO AS [Vai trò],
       ISNULL(HD.SoHoaDon,0) AS [Số HĐ lập],
       FORMAT(ISNULL(HD.DoanhThu,0),'N0') + N' đ' AS [Doanh thu]
FROM NhanVien NV
LEFT JOIN (SELECT MANV_LAP, COUNT(*) AS SoHoaDon, SUM(THANHTIEN) AS DoanhThu
           FROM HoaDon GROUP BY MANV_LAP) HD ON HD.MANV_LAP = NV.MANV
WHERE NV.VAITRO NOT IN (N'Nhân viên quản lý hệ thống', N'Chủ doanh nghiệp')
ORDER BY ISNULL(HD.DoanhThu,0) DESC, NV.MANV;");
        }

        // ─────────────────────────────────────────────────────────────────────
        // BÁO CÁO PDF — DOANH THU THEO KHÁCH HÀNG
        // ─────────────────────────────────────────────────────────────────────
        private void btnBaocaoKH_Click(object sender, EventArgs e)
        {
            try
            {
                XuatBaoCaoPdf(BuildBaoCaoDoanhThuKhachHang(),
                    "BaoCao_DoanhThu_KhachHang.pdf", "Báo cáo doanh thu theo khách hàng");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable BuildBaoCaoDoanhThuKhachHang()
        {
            return DataProvider.ExecuteQuery(@"
SELECT KH.MAKH AS [Mã KH], KH.TENKH AS [Họ tên KH],
       ISNULL(DH.SoDon,0) AS [Số đơn],
       FORMAT(ISNULL(DH.DoanhThu,0),'N0') + N' đ' AS [Doanh thu]
FROM KhachHang KH
LEFT JOIN (SELECT D.MAKH, COUNT(DISTINCT D.MADON) AS SoDon,
                  SUM(ISNULL(HD.THANHTIEN,0)) AS DoanhThu
           FROM DonDichVu D LEFT JOIN HoaDon HD ON HD.MADON = D.MADON
           GROUP BY D.MAKH) DH ON DH.MAKH = KH.MAKH
ORDER BY ISNULL(DH.DoanhThu,0) DESC, KH.MAKH;");
        }

        // ─────────────────────────────────────────────────────────────────────
        // BÁO CÁO PDF — DOANH THU THEO ĐƠN DỊCH VỤ
        // ─────────────────────────────────────────────────────────────────────
        private void btnBaocaoDonDV_Click(object sender, EventArgs e)
        {
            try
            {
                XuatBaoCaoPdf(BuildBaoCaoDoanhThuDonDichVu(),
                    "BaoCao_DoanhThu_DonDichVu.pdf", "Báo cáo doanh thu theo đơn dịch vụ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable BuildBaoCaoDoanhThuDonDichVu()
        {
            return DataProvider.ExecuteQuery(@"
SELECT D.MADON AS [Mã đơn],
       CONVERT(VARCHAR(10),D.NGAYDAT,103)      AS [Ngày đặt],
       CONVERT(VARCHAR(10),D.NGAYTHUCHIEN,103) AS [Ngày TH],
       ISNULL(KH.TENKH,N'')  AS [Khách hàng],
       ISNULL(NV.TENNV,N'')  AS [NV tiếp nhận],
       D.TRANGTHAI            AS [Trạng thái],
       FORMAT(ISNULL(CT.TongTienDichVu,0),'N0') + N' đ' AS [T.tiền DV],
       FORMAT(ISNULL(HD.THANHTIEN,0),'N0')      + N' đ' AS [T.tiền HĐ]
FROM DonDichVu D
LEFT JOIN KhachHang KH ON KH.MAKH = D.MAKH
LEFT JOIN NhanVien  NV ON NV.MANV = D.MANV_TIEPNHAN
LEFT JOIN (SELECT MADON, SUM(SOLUONG*DONGIA) AS TongTienDichVu
           FROM ChiTietDonDichVu GROUP BY MADON) CT ON CT.MADON = D.MADON
LEFT JOIN HoaDon HD ON HD.MADON = D.MADON
ORDER BY D.NGAYDAT DESC;");
        }

        // ─────────────────────────────────────────────────────────────────────
        // HÀM CHUNG: hỏi nơi lưu rồi xuất DataTable ra PDF
        // ─────────────────────────────────────────────────────────────────────
        private void XuatBaoCaoPdf(DataTable dt, string defaultFile, string title)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var sfd = new SaveFileDialog { Filter = "PDF|*.pdf", FileName = defaultFile })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    ExportGridToPdf(dt, sfd.FileName, title);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo PDF: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // XUẤT PDF
        // ─────────────────────────────────────────────────────────────────────
        private void ExportGridToPdf(DataTable table, string filename, string title)
        {
            using (PdfDocument doc = new PdfDocument())
            using (var ms = new System.IO.MemoryStream())
            {
                doc.Info.Title = title;

                const string companyName = "CÔNG TY TNHH TM DV VẬN TẢI QUỐC TẾ ĐẠI DƯƠNG XANH";
                const string companyAddress = "84/10 Đường 49, P.Hiệp Bình Chánh, Q.Thủ Đức, TP.HCM";
                const string companyContact = "ĐT: +84-28-62835558  |  Email: thanh_duc@go-shipping.vn";

                XFont fontCompany = new XFont("Verdana", 11, XFontStyle.Bold);
                XFont fontInfo = new XFont("Verdana", 8, XFontStyle.Regular);
                XFont fontTitle = new XFont("Verdana", 15, XFontStyle.Bold);
                XFont fontDate = new XFont("Verdana", 8, XFontStyle.Italic);
                XFont fontHeader = new XFont("Verdana", 8, XFontStyle.Bold);
                XFont fontRow = new XFont("Verdana", 8, XFontStyle.Regular);
                XFont fontFooter = new XFont("Verdana", 8, XFontStyle.Regular);

                _03_VuNgocLinh.Properties.Resources.DDX.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;

                using (XImage logo = XImage.FromStream(ms))
                {
                    const double logoSize = 50;
                    const double margin = 30;
                    const double lineH = 16;
                    int colCount = Math.Min(8, table.Columns.Count);

                    PdfPage firstPage = doc.AddPage();
                    firstPage.Size = PdfSharp.PageSize.A4;
                    firstPage.Orientation = PdfSharp.PageOrientation.Landscape;

                    double pageW = firstPage.Width;
                    double pageH = firstPage.Height;
                    double usableW = pageW - margin * 2;

                    // Measure column widths
                    double[] colW = new double[colCount];
                    using (XGraphics mg = XGraphics.FromPdfPage(firstPage))
                    {
                        for (int c = 0; c < colCount; c++)
                        {
                            double mx = mg.MeasureString(table.Columns[c].ColumnName, fontHeader).Width;
                            foreach (DataRow r in table.Rows)
                            {
                                double w = mg.MeasureString(r[c]?.ToString() ?? "", fontRow).Width;
                                if (w > mx) mx = w;
                            }
                            colW[c] = mx + 10;
                        }
                    }

                    double totalW = colW.Sum();
                    const double minW = 40;
                    if (totalW > usableW)
                    {
                        double scale = usableW / totalW;
                        for (int c = 0; c < colCount; c++)
                            colW[c] = Math.Max(minW, colW[c] * scale);
                    }
                    else
                    {
                        double extra = (usableW - totalW) / colCount;
                        for (int c = 0; c < colCount; c++) colW[c] += extra;
                    }

                    var pages = new List<PdfPage>();
                    int rowIdx = 0;
                    bool first = true;

                    while (first || rowIdx < table.Rows.Count)
                    {
                        PdfPage page = first ? firstPage : doc.AddPage();
                        if (!first) { page.Size = PdfSharp.PageSize.A4; page.Orientation = PdfSharp.PageOrientation.Landscape; }
                        first = false;
                        pages.Add(page);

                        using (XGraphics gfx = XGraphics.FromPdfPage(page))
                        {
                            double y = DrawPageHeader(gfx, page, margin, companyName, companyAddress,
                                companyContact, fontCompany, fontInfo, title, fontTitle, fontDate, logo, logoSize);
                            y = DrawTableHeader(gfx, margin, y, colW, table, colCount, fontHeader, lineH);

                            while (rowIdx < table.Rows.Count)
                            {
                                if (y + lineH > pageH - margin - 20) break;
                                double x = margin;
                                for (int c = 0; c < colCount; c++)
                                {
                                    string txt = Truncate(gfx, table.Rows[rowIdx][c]?.ToString() ?? "", fontRow, colW[c] - 6);
                                    gfx.DrawString(txt, fontRow, XBrushes.Black,
                                        new XRect(x + 3, y, colW[c] - 6, lineH), XStringFormats.TopLeft);
                                    x += colW[c];
                                }
                                y += lineH;
                                rowIdx++;
                            }
                        }
                    }

                    for (int i = 0; i < pages.Count; i++)
                        using (XGraphics fg = XGraphics.FromPdfPage(pages[i]))
                            fg.DrawString($"Trang {i + 1}/{pages.Count}", fontFooter, XBrushes.Gray,
                                new XRect(margin, pageH - margin + 5, usableW, 16), XStringFormats.TopRight);

                    doc.Save(filename);
                }
            }
        }

        private double DrawPageHeader(XGraphics gfx, PdfPage page, double margin,
            string co, string addr, string contact,
            XFont fCo, XFont fInfo, string title, XFont fTitle, XFont fDate,
            XImage logo, double logoSize)
        {
            double usableW = page.Width - margin * 2;
            double y = margin;
            gfx.DrawImage(logo, margin, y, logoSize, logoSize);
            double tx = margin + logoSize + 10, tw = usableW - logoSize - 10;
            gfx.DrawString(co, fCo, XBrushes.Black, new XRect(tx, y, tw, 16), XStringFormats.TopLeft); y += 16;
            gfx.DrawString(addr, fInfo, XBrushes.Black, new XRect(tx, y, tw, 12), XStringFormats.TopLeft); y += 12;
            gfx.DrawString(contact, fInfo, XBrushes.Black, new XRect(tx, y, tw, 12), XStringFormats.TopLeft); y += 16;
            y = Math.Max(y, margin + logoSize + 6);
            gfx.DrawString(title.ToUpper(), fTitle, XBrushes.Black,
                new XRect(margin, y, usableW, 24), XStringFormats.TopCenter); y += 22;
            gfx.DrawString("Ngày in: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fDate, XBrushes.Gray,
                new XRect(margin, y, usableW, 14), XStringFormats.TopRight); y += 16;
            gfx.DrawLine(XPens.Black, margin, y, page.Width - margin, y); y += 6;
            return y;
        }

        private double DrawTableHeader(XGraphics gfx, double margin, double y,
            double[] colW, DataTable table, int colCount, XFont font, double lineH)
        {
            double x = margin;
            for (int c = 0; c < colCount; c++)
            {
                gfx.DrawRectangle(XBrushes.LightGray, x, y, colW[c], lineH);
                gfx.DrawString(table.Columns[c].ColumnName, font, XBrushes.Black,
                    new XRect(x + 3, y, colW[c] - 6, lineH), XStringFormats.TopLeft);
                x += colW[c];
            }
            gfx.DrawLine(XPens.Black, margin, y + lineH, margin + colW.Sum(), y + lineH);
            return y + lineH;
        }

        private string Truncate(XGraphics gfx, string text, XFont font, double maxW)
        {
            if (string.IsNullOrEmpty(text) || gfx.MeasureString(text, font).Width <= maxW) return text;
            int len = text.Length;
            while (len > 0)
            {
                string c = text.Substring(0, len) + "...";
                if (gfx.MeasureString(c, font).Width <= maxW) return c;
                len--;
            }
            return "...";
        }
    }
}
