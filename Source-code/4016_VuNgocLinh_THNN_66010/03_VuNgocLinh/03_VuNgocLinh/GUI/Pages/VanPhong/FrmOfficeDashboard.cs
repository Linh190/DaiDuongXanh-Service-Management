using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _03_VuNgocLinh.GUI.Pages.VanPhong
{
    public partial class FrmOfficeDashboard : Form
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

        public FrmOfficeDashboard()
        {
            InitializeComponent();

            if (chartDoanhThu.Legends.Count == 0)
                chartDoanhThu.Legends.Add(new Legend("Legend1"));
            foreach (var s in chartDoanhThu.Series)
                if (chartDoanhThu.Legends.FindByName(s.Legend) == null)
                    s.Legend = chartDoanhThu.Legends[0].Name;

            dgvDonHangMoi.CellFormatting += DgvChungTu_CellFormatting;
        }

        private void FrmOfficeDashboard_Load(object sender, EventArgs e)
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

        // ── Hover effect cho các thẻ KPI
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

        // ── Hiển thị tên nhân viên đang đăng nhập
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
            LoadChungTuGrid();
            LoadChungTuByLoaiChart();
        }

        // ── 5 thẻ KPI theo nghiệp vụ văn phòng
        private void LoadOverviewCounts()
        {
            try
            {
                // KPI 1: Chứng từ đang chờ duyệt
                var choDuyet = Convert.ToInt32(DataProvider.ExecuteScalar(
                    "SELECT COUNT(*) FROM ChungTu WHERE TRANGTHAI = N'Chờ duyệt'") ?? 0);

                // KPI 2: Đơn hoàn thành chưa có chứng từ (cần lập chứng từ)
                var donChuaCT = Convert.ToInt32(DataProvider.ExecuteScalar(@"
                    SELECT COUNT(*)
                    FROM   DonDichVu D
                    WHERE  D.TRANGTHAI = N'Hoàn thành'
                      AND  NOT EXISTS (
                               SELECT 1 FROM ChungTu CT WHERE CT.MADON = D.MADON
                           )") ?? 0);

                // KPI 3: Chứng từ đã duyệt trong tháng hiện tại
                var daDuyetThang = Convert.ToInt32(DataProvider.ExecuteScalar(@"
                    SELECT COUNT(*)
                    FROM   ChungTu
                    WHERE  TRANGTHAI  = N'Đã duyệt'
                      AND  MONTH(NGAYDUYET) = MONTH(GETDATE())
                      AND  YEAR(NGAYDUYET)  = YEAR(GETDATE())") ?? 0);

                // KPI 4: Số hóa đơn đã phát trong tháng
                var hoaDonThang = Convert.ToInt32(DataProvider.ExecuteScalar(@"
                    SELECT COUNT(*)
                    FROM   HoaDon
                    WHERE  MONTH(NGAYHD) = MONTH(GETDATE())
                      AND  YEAR(NGAYHD)  = YEAR(GETDATE())") ?? 0);

                // KPI 5: Tổng giá trị hóa đơn trong tháng
                decimal giaTriThang = 0m;
                var gtObj = DataProvider.ExecuteScalar(@"
                    SELECT ISNULL(SUM(THANHTIEN), 0)
                    FROM   HoaDon
                    WHERE  MONTH(NGAYHD) = MONTH(GETDATE())
                      AND  YEAR(NGAYHD)  = YEAR(GETDATE())");
                if (gtObj != null && gtObj != DBNull.Value)
                    decimal.TryParse(gtObj.ToString(), out giaTriThang);

                // Gán vào các thẻ KPI (dùng lại label sẵn có trong Designer)
                lblChoXacNhanNum.Text = $"{choDuyet}";
                lblDangXuLyNum.Text = $"{donChuaCT}";
                lblHoanThanhNum.Text = $"{daDuyetThang}";
                lblKhachMoiNum.Text = $"{hoaDonThang}";
                lblDoanhThuNum.Text = $"{giaTriThang:N0} đ";

                // Cập nhật nhãn tiêu đề các thẻ cho đúng nghiệp vụ
                lblChoXacNhan.Text = "CT chờ duyệt";
                lblDangXuLy.Text = "Đơn chưa có CT";
                lblHoanThanh.Text = "CT đã duyệt (tháng)";
                lblKhachMoi.Text = "Hóa đơn (tháng)";
                lblDoanhThu.Text = "Doanh thu tháng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải số liệu tổng quan: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Bảng: danh sách chứng từ chờ duyệt và chứng từ mới nhất
        private void LoadChungTuGrid()
        {
            try
            {
                string sql = @"
    SELECT TOP 50
           CT.MACT,
           CT.SOCHUNGTU                        AS SoCT,
           CT.LOAICHUNGTU                      AS LoaiCT,
           CT.NGAYLAP                          AS NgayLap,
           ISNULL(NV.TENNV, CT.MANV_KIEMTRA)  AS NguoiLap,
           CT.TONGTIEN                         AS TongTien,
           CT.TRANGTHAI
    FROM   ChungTu CT
    LEFT   JOIN NhanVien NV ON NV.MANV = CT.MANV_KIEMTRA
    ORDER  BY
           CASE CT.TRANGTHAI WHEN N'Chờ duyệt' THEN 0 ELSE 1 END,
           CT.NGAYLAP DESC";

                DataTable dt = DataProvider.ExecuteQuery(sql);
                dgvDonHangMoi.DataSource = dt;

                if (dgvDonHangMoi.Columns["MACT"] != null) dgvDonHangMoi.Columns["MACT"].HeaderText = "Mã CT";
                if (dgvDonHangMoi.Columns["SoCT"] != null) dgvDonHangMoi.Columns["SoCT"].HeaderText = "Số CT";
                if (dgvDonHangMoi.Columns["LoaiCT"] != null) dgvDonHangMoi.Columns["LoaiCT"].HeaderText = "Loại chứng từ";
                if (dgvDonHangMoi.Columns["NgayLap"] != null) dgvDonHangMoi.Columns["NgayLap"].HeaderText = "Ngày lập";
                if (dgvDonHangMoi.Columns["NguoiLap"] != null) dgvDonHangMoi.Columns["NguoiLap"].HeaderText = "Người lập";
                if (dgvDonHangMoi.Columns["TongTien"] != null)
                {
                    dgvDonHangMoi.Columns["TongTien"].HeaderText = "Tổng tiền (đ)";
                    dgvDonHangMoi.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    dgvDonHangMoi.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvDonHangMoi.Columns["TRANGTHAI"] != null) dgvDonHangMoi.Columns["TRANGTHAI"].HeaderText = "Trạng thái";

                dgvDonHangMoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDonHangMoi.ReadOnly = true;
                dgvDonHangMoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Đếm chứng từ chờ duyệt để cập nhật tiêu đề bảng
                int choDuyet = 0;
                foreach (DataRow r in dt.Rows)
                    if (Convert.ToString(r["TRANGTHAI"]) == "Chờ duyệt")
                        choDuyet++;

                if (choDuyet > 0)
                {
                    lblDonTitle.Text = $"⚠  Chứng từ — {choDuyet} ĐANG CHỜ DUYỆT";
                    lblDonTitle.ForeColor = Color.FromArgb(255, 220, 200);
                    pnlDonHeader.BackColor = Color.FromArgb(180, 50, 30);
                }
                else
                {
                    lblDonTitle.Text = "Chứng từ — Danh sách gần đây";
                    lblDonTitle.ForeColor = Color.White;
                    pnlDonHeader.BackColor = CLR_NAVY;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chứng từ: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Biểu đồ: số lượng chứng từ theo loại
        private void LoadChungTuByLoaiChart()
        {
            try
            {
                string sql = @"
    SELECT LOAICHUNGTU       AS LoaiCT,
           COUNT(*)          AS SoLuong,
           ISNULL(SUM(TONGTIEN), 0) AS TongTien
    FROM   ChungTu
    GROUP  BY LOAICHUNGTU
    ORDER  BY COUNT(*) DESC";

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
                area.AxisX.LabelStyle.Angle = -30;
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8f);
                area.AxisY.LabelStyle.ForeColor = CLR_TEXT;
                area.AxisY.LabelStyle.Format = "0";
                area.AxisY.Title = "Số lượng chứng từ";
                area.AxisY.TitleFont = new Font("Segoe UI", 8f, FontStyle.Bold);
                area.AxisY.TitleForeColor = CLR_TEXT;
                area.AxisX.Interval = 1;
                area.BorderDashStyle = ChartDashStyle.NotSet;

                var series = chartDoanhThu.Series.Count > 0
                    ? chartDoanhThu.Series[0]
                    : chartDoanhThu.Series.Add("ChungTu");

                series.ChartType = SeriesChartType.Column;
                series.Color = CLR_TEAL;
                series.BorderWidth = 0;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "0";
                series.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                series.LabelForeColor = CLR_TEXT;
                series.LegendText = "Số lượng chứng từ theo loại";
                series.Points.Clear();

                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Legends.Clear();
                var legend = new Legend("LegendCT")
                {
                    Docking = Docking.Bottom,
                    LegendStyle = LegendStyle.Row,
                    Font = new Font("Segoe UI", 8f),
                    ForeColor = CLR_TEXT,
                    BackColor = Color.White,
                };
                chartDoanhThu.Legends.Add(legend);
                series.Legend = "LegendCT";

                // Cập nhật tiêu đề biểu đồ
                lblChartTitle.Text = "Thống kê chứng từ theo loại";

                Color[] barColors = {
                    CLR_TEAL,
                    CLR_OCEAN,
                    Color.FromArgb(0,  140, 195),
                    CLR_GREEN,
                    Color.FromArgb(26, 144, 204),
                };

                int ci = 0;
                foreach (DataRow r in dt.Rows)
                {
                    string loai = Convert.ToString(r["LoaiCT"]);
                    int soLuong = Convert.ToInt32(r["SoLuong"]);
                    decimal tongTien = r["TongTien"] == DBNull.Value ? 0m : Convert.ToDecimal(r["TongTien"]);

                    int idx = series.Points.AddY(soLuong);
                    var pt = series.Points[idx];
                    pt.Color = barColors[ci++ % barColors.Length];
                    pt.AxisLabel = loai;
                    pt.Label = $"{soLuong}";
                    pt.ToolTip = $"{loai}\nSố CT: {soLuong}\nTổng tiền: {tongTien:N0} đ";
                }

                if (chartDoanhThu.ChartAreas.Count > 0)
                    chartDoanhThu.ChartAreas[0].RecalculateAxesScale();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ chứng từ: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Tô màu dòng theo trạng thái chứng từ
        private void DgvChungTu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvDonHangMoi.Rows[e.RowIndex];
            if (!(row.DataBoundItem is System.Data.DataRowView drv)) return;
            if (!drv.Row.Table.Columns.Contains("TRANGTHAI")) return;

            string tt = Convert.ToString(drv.Row["TRANGTHAI"]);

            switch (tt)
            {
                case "Chờ duyệt":
                    e.CellStyle.BackColor = Color.FromArgb(255, 243, 205);
                    e.CellStyle.ForeColor = Color.FromArgb(133, 77, 14);
                    row.Cells[e.ColumnIndex].ToolTipText = "Chứng từ đang chờ chủ DN phê duyệt";
                    break;
                case "Trả lại":
                    e.CellStyle.BackColor = Color.FromArgb(255, 210, 200);
                    e.CellStyle.ForeColor = Color.FromArgb(150, 30, 30);
                    row.Cells[e.ColumnIndex].ToolTipText = "Chứng từ bị trả lại — cần chỉnh sửa";
                    break;
                case "Từ chối":
                    e.CellStyle.BackColor = Color.FromArgb(240, 200, 200);
                    e.CellStyle.ForeColor = Color.FromArgb(120, 20, 20);
                    row.Cells[e.ColumnIndex].ToolTipText = "Chứng từ bị từ chối";
                    break;
                case "Đã duyệt":
                    e.CellStyle.BackColor = Color.FromArgb(209, 241, 220);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 87, 36);
                    row.Cells[e.ColumnIndex].ToolTipText = "Chứng từ đã được phê duyệt";
                    break;
            }
        }

        // ── Event stubs (giữ nguyên để tương thích Designer)
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