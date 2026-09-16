using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _03_VuNgocLinh.GUI.Pages.BanHang
{
    public partial class FrmSalesDashboard : Form
    {
        private readonly NhanVienBUS _nvBus = new NhanVienBUS();

        private static readonly Color CLR_NAVY = Color.FromArgb(28, 54, 100);
        private static readonly Color CLR_OCEAN = Color.FromArgb(0, 120, 180);
        private static readonly Color CLR_TEAL = Color.FromArgb(0, 163, 196);
        private static readonly Color CLR_GREEN = Color.FromArgb(39, 174, 96);
        private static readonly Color CLR_ORANGE = Color.FromArgb(243, 156, 18);
        private static readonly Color CLR_RED = Color.FromArgb(231, 76, 60);
        private static readonly Color CLR_BG = Color.FromArgb(235, 245, 251);
        private static readonly Color CLR_BORDER = Color.FromArgb(200, 221, 237);
        private static readonly Color CLR_TEXT = Color.FromArgb(28, 48, 70);

        public FrmSalesDashboard()
        {
            InitializeComponent();

            if (chartDoanhThu.Legends.Count == 0)
                chartDoanhThu.Legends.Add(new Legend("Legend1"));
            foreach (var s in chartDoanhThu.Series)
                if (chartDoanhThu.Legends.FindByName(s.Legend) == null)
                    s.Legend = chartDoanhThu.Legends[0].Name;

            dgvDonHangMoi.CellFormatting += DgvDonHangMoi_CellFormatting;
        }

        private void FrmSalesDashboard_Load(object sender, EventArgs e)
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

        // ── hover effects
        private void ApplyRuntimeTheme()
        {
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

        // ── greet
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
                    ? display : $"{display}    •    Vai trò: {role}";
            }
            catch { lblNhanVien.Text = "Xin chào"; }
        }

        private void LoadDashboard()
        {
            LoadOverviewCounts();
            LoadNewOrdersGrid();
            LoadRevenueChart();
        }

        // ── KPI counts
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
                if (dtObj != null && dtObj != DBNull.Value) decimal.TryParse(dtObj.ToString(), out doanhThu);

                lblChoXacNhanNum.Text = $"{choXac}";
                lblDangXuLyNum.Text = $"{dangXuLy}";
                lblHoanThanhNum.Text = $"{hoanThanh}";
                lblKhachMoiNum.Text = $"{khachMoi}";
                lblDoanhThuNum.Text = $"{doanhThu:N0} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải số liệu tổng quan: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── DGV: active orders
        private void LoadNewOrdersGrid()
        {
            try
            {
                string sql = @"
    SELECT D.MADON,
           ISNULL(KH.TENKH, D.MAKH) AS TENKH,
           D.NGAYDAT,
           D.NGAYTHUCHIEN,
           D.TRANGTHAI
    FROM DonDichVu D
    LEFT JOIN KhachHang KH ON D.MAKH = KH.MAKH
    WHERE D.TRANGTHAI NOT IN (N'Hoàn thành', N'Hủy')
    ORDER BY D.NGAYTHUCHIEN ASC";
                DataTable dt = DataProvider.ExecuteQuery(sql);
                dgvDonHangMoi.DataSource = dt;

                if (dgvDonHangMoi.Columns["MADON"] != null) dgvDonHangMoi.Columns["MADON"].HeaderText = "Mã đơn";
                if (dgvDonHangMoi.Columns["TENKH"] != null) dgvDonHangMoi.Columns["TENKH"].HeaderText = "Khách hàng";
                if (dgvDonHangMoi.Columns["NGAYDAT"] != null) dgvDonHangMoi.Columns["NGAYDAT"].HeaderText = "Ngày đặt";
                if (dgvDonHangMoi.Columns["NGAYTHUCHIEN"] != null) dgvDonHangMoi.Columns["NGAYTHUCHIEN"].HeaderText = "Ngày TH";
                if (dgvDonHangMoi.Columns["TRANGTHAI"] != null) dgvDonHangMoi.Columns["TRANGTHAI"].HeaderText = "Trạng thái";

                dgvDonHangMoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDonHangMoi.ReadOnly = true;
                dgvDonHangMoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                int quaHan = 0;
                foreach (DataRow r in dt.Rows)
                    if (r["NGAYTHUCHIEN"] != DBNull.Value &&
                        Convert.ToDateTime(r["NGAYTHUCHIEN"]).Date < DateTime.Today)
                        quaHan++;

                if (quaHan > 0)
                {
                    lblDonTitle.Text = $"⚠  Đơn đang hoạt động  ({quaHan} QUÁ HẠN)";
                    lblDonTitle.ForeColor = Color.FromArgb(255, 220, 200);
                    pnlDonHeader.BackColor = Color.FromArgb(180, 50, 30);
                }
                else
                {
                    lblDonTitle.Text = "Đơn đang hoạt động";
                    lblDonTitle.ForeColor = Color.White;
                    pnlDonHeader.BackColor = CLR_NAVY;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Chart
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

                if (chartDoanhThu.ChartAreas.Count == 0)
                    chartDoanhThu.ChartAreas.Add(new ChartArea("ChartArea1"));

                var area = chartDoanhThu.ChartAreas[0];
                area.BackColor = Color.White;
                area.AxisX.LineColor = CLR_BORDER;
                area.AxisY.LineColor = CLR_BORDER;
                area.AxisX.MajorGrid.LineColor = CLR_BG;
                area.AxisY.MajorGrid.LineColor = CLR_BG;
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8f);
                area.AxisX.LabelStyle.ForeColor = CLR_TEXT;
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8f);
                area.AxisY.LabelStyle.ForeColor = CLR_TEXT;
                area.AxisY.LabelStyle.Format = "N0";
                area.AxisY.Title = "Doanh thu (đ)";
                area.AxisY.TitleFont = new Font("Segoe UI", 8f, FontStyle.Bold);
                area.AxisY.TitleForeColor = CLR_TEXT;
                area.AxisX.Interval = 1;
                area.AxisX.LabelStyle.Angle = -40;
                area.BorderDashStyle = ChartDashStyle.NotSet;

                var series = chartDoanhThu.Series.Count > 0
                    ? chartDoanhThu.Series[0]
                    : chartDoanhThu.Series.Add("DoanhThu");

                series.ChartType = SeriesChartType.Column;
                series.Color = CLR_OCEAN;
                series.BorderWidth = 0;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N0";
                series.Font = new Font("Segoe UI", 7.5f);
                series.LabelForeColor = CLR_TEXT;
                series.LegendText = "Doanh thu theo dịch vụ";
                series.Points.Clear();

                Color[] barColors = {
                    CLR_OCEAN, Color.FromArgb(0,130,190), Color.FromArgb(0,140,195),
                    CLR_TEAL,  Color.FromArgb(0,155,200), Color.FromArgb(26,144,204),
                    Color.FromArgb(0,148,196), Color.FromArgb(0,153,196),
                    Color.FromArgb(39,174,150), Color.FromArgb(0,160,200),
                };

                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Legends.Clear();
                var legend = new Legend("LegendDoanhThu")
                {
                    Docking = Docking.Bottom,
                    LegendStyle = LegendStyle.Row,
                    Font = new Font("Segoe UI", 8f),
                    ForeColor = CLR_TEXT,
                    BackColor = Color.White,
                };
                chartDoanhThu.Legends.Add(legend);
                series.Legend = "LegendDoanhThu";

                decimal total = 0m;
                foreach (DataRow r in dt.Rows)
                    if (r["TongTien"] != DBNull.Value)
                        try { total += Convert.ToDecimal(r["TongTien"]); } catch { }

                int ci = 0;
                foreach (DataRow r in dt.Rows)
                {
                    var name = Convert.ToString(r["TenDichVu"]);
                    var value = r["TongTien"] == DBNull.Value ? 0m : Convert.ToDecimal(r["TongTien"]);
                    int idx = series.Points.AddY(Convert.ToDouble(value));
                    var pt = series.Points[idx];
                    pt.Color = barColors[ci++ % barColors.Length];
                    pt.AxisLabel = name;
                    pt.Label = $"{value:N0}";
                    double pct = total > 0m ? (double)(value / total) : 0.0;
                    pt.ToolTip = $"{name}\n{value:N0} đ  ({pct:P1})";
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

        // ── deadline row colouring (CellFormatting)
        private void DgvDonHangMoi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvDonHangMoi.Rows[e.RowIndex];
            if (!(row.DataBoundItem is System.Data.DataRowView drv)) return;
            if (!drv.Row.Table.Columns.Contains("NGAYTHUCHIEN")) return;
            if (drv.Row["NGAYTHUCHIEN"] == DBNull.Value) return;

            DateTime ngayTH = Convert.ToDateTime(drv.Row["NGAYTHUCHIEN"]);
            int soNgay = (DateTime.Today - ngayTH.Date).Days;

            if (ngayTH.Date < DateTime.Today)
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 200, 200);
                e.CellStyle.ForeColor = Color.FromArgb(150, 30, 30);
                row.Cells[e.ColumnIndex].ToolTipText = $"⚠ Quá hạn {soNgay} ngày!";
            }
            else if (ngayTH.Date <= DateTime.Today.AddDays(2))
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 248, 200);
                e.CellStyle.ForeColor = Color.FromArgb(160, 90, 0);
                row.Cells[e.ColumnIndex].ToolTipText = "⚠ Sắp đến hạn thực hiện!";
            }
        }

        // ── event stubs
        private void lblNhanVien_Click(object sender, EventArgs e) { }
        private void pnlChoXacNhan_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void pnlDangXuLy_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void pnlHoanThanh_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void pnlKhachMoi_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void pnlDoanhThu_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void lblChoXacNhan_Click(object sender, EventArgs e) { }
        private void lblDangXuLy_Click(object sender, EventArgs e) { }
        private void lblHoanThanh_Click(object sender, EventArgs e) { }
        private void lblKhachMoi_Click(object sender, EventArgs e) { }
        private void lblDoanhThu_Click(object sender, EventArgs e) { }
        private void chartDoanhThu_Click(object sender, EventArgs e) { }
        private void dgvDonHangMoi_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}