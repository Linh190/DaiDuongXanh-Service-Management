namespace _03_VuNgocLinh.GUI.Pages.VanPhong
{
    partial class FrmOfficeDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvAltStyle = new System.Windows.Forms.DataGridViewCellStyle();

            // ── Header
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderLine = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            // ── KPI strip
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlChoXacNhan = new System.Windows.Forms.Panel();
            this.lblChoXacNhanNum = new System.Windows.Forms.Label();
            this.lblChoXacNhan = new System.Windows.Forms.Label();
            this.pnlDangXuLy = new System.Windows.Forms.Panel();
            this.lblDangXuLyNum = new System.Windows.Forms.Label();
            this.lblDangXuLy = new System.Windows.Forms.Label();
            this.pnlHoanThanh = new System.Windows.Forms.Panel();
            this.lblHoanThanhNum = new System.Windows.Forms.Label();
            this.lblHoanThanh = new System.Windows.Forms.Label();
            this.pnlKhachMoi = new System.Windows.Forms.Panel();
            this.lblKhachMoiNum = new System.Windows.Forms.Label();
            this.lblKhachMoi = new System.Windows.Forms.Label();
            this.pnlDoanhThu = new System.Windows.Forms.Panel();
            this.lblDoanhThuNum = new System.Windows.Forms.Label();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            // ── Left: orders DGV
            this.pnlDonContainer = new System.Windows.Forms.Panel();
            this.pnlDonHeader = new System.Windows.Forms.Panel();
            this.lblDonTitle = new System.Windows.Forms.Label();
            this.pnlVertSep = new System.Windows.Forms.Panel();
            this.dgvDonHangMoi = new System.Windows.Forms.DataGridView();
            // ── Right: chart
            this.pnlChartContainer = new System.Windows.Forms.Panel();
            this.pnlChartHeader = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlChoXacNhan.SuspendLayout();
            this.pnlDangXuLy.SuspendLayout();
            this.pnlHoanThanh.SuspendLayout();
            this.pnlKhachMoi.SuspendLayout();
            this.pnlDoanhThu.SuspendLayout();
            this.pnlDonContainer.SuspendLayout();
            this.pnlDonHeader.SuspendLayout();
            this.pnlChartContainer.SuspendLayout();
            this.pnlChartHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHangMoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader (Navy, h=84)
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlHeader.Controls.Add(this.pnlHeaderLine);
            this.pnlHeader.Controls.Add(this.lblNhanVien);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.panel1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1328, 84);
            this.pnlHeader.TabIndex = 0;
            //
            this.pnlHeaderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(196)))));
            this.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderLine.Location = new System.Drawing.Point(0, 81);
            this.pnlHeaderLine.Name = "pnlHeaderLine";
            this.pnlHeaderLine.Size = new System.Drawing.Size(1328, 3);
            this.pnlHeaderLine.TabIndex = 10;
            //
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CÔNG TY TNHH TM DV VẬN TẢI QUỐC TẾ ĐẠI DƯƠNG XANH";
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(22, 40);
            this.label2.Name = "label2";
            this.label2.TabIndex = 1;
            this.label2.Text = "Bảng điều khiển — Nhân viên Văn phòng";
            //
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.lblNhanVien.Location = new System.Drawing.Point(22, 60);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.TabIndex = 2;
            this.lblNhanVien.Text = "Xin chào:";
            this.lblNhanVien.Click += new System.EventHandler(this.lblNhanVien_Click);

            // ── pnlMenu (KPI strip, Dock=Top, h=116)
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlMenu.Controls.Add(this.pnlDoanhThu);
            this.pnlMenu.Controls.Add(this.pnlKhachMoi);
            this.pnlMenu.Controls.Add(this.pnlHoanThanh);
            this.pnlMenu.Controls.Add(this.pnlDangXuLy);
            this.pnlMenu.Controls.Add(this.pnlChoXacNhan);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 84);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1328, 116);
            this.pnlMenu.TabIndex = 1;

            // Card 1 – Red
            this.pnlChoXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlChoXacNhan.Controls.Add(this.lblChoXacNhanNum);
            this.pnlChoXacNhan.Controls.Add(this.lblChoXacNhan);
            this.pnlChoXacNhan.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlChoXacNhan.Name = "pnlChoXacNhan";
            this.pnlChoXacNhan.Size = new System.Drawing.Size(220, 116);
            this.pnlChoXacNhan.TabIndex = 0;
            this.pnlChoXacNhan.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChoXacNhan_Paint);
            //
            this.lblChoXacNhanNum.AutoSize = false;
            this.lblChoXacNhanNum.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoXacNhanNum.ForeColor = System.Drawing.Color.White;
            this.lblChoXacNhanNum.Location = new System.Drawing.Point(16, 12);
            this.lblChoXacNhanNum.Name = "lblChoXacNhanNum";
            this.lblChoXacNhanNum.Size = new System.Drawing.Size(188, 50);
            this.lblChoXacNhanNum.TabIndex = 1;
            this.lblChoXacNhanNum.Text = "—";
            //
            this.lblChoXacNhan.AutoSize = false;
            this.lblChoXacNhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(216)))));
            this.lblChoXacNhan.Location = new System.Drawing.Point(16, 72);
            this.lblChoXacNhan.Name = "lblChoXacNhan";
            this.lblChoXacNhan.Size = new System.Drawing.Size(190, 36);
            this.lblChoXacNhan.TabIndex = 0;
            this.lblChoXacNhan.Text = "CT chờ duyệt";
            this.lblChoXacNhan.Click += new System.EventHandler(this.lblChoXacNhan_Click);

            // Card 2 – Orange
            this.pnlDangXuLy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.pnlDangXuLy.Controls.Add(this.lblDangXuLyNum);
            this.pnlDangXuLy.Controls.Add(this.lblDangXuLy);
            this.pnlDangXuLy.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDangXuLy.Name = "pnlDangXuLy";
            this.pnlDangXuLy.Size = new System.Drawing.Size(220, 116);
            this.pnlDangXuLy.TabIndex = 1;
            this.pnlDangXuLy.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDangXuLy_Paint);
            //
            this.lblDangXuLyNum.AutoSize = false;
            this.lblDangXuLyNum.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangXuLyNum.ForeColor = System.Drawing.Color.White;
            this.lblDangXuLyNum.Location = new System.Drawing.Point(16, 12);
            this.lblDangXuLyNum.Name = "lblDangXuLyNum";
            this.lblDangXuLyNum.Size = new System.Drawing.Size(188, 50);
            this.lblDangXuLyNum.TabIndex = 1;
            this.lblDangXuLyNum.Text = "—";
            //
            this.lblDangXuLy.AutoSize = false;
            this.lblDangXuLy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangXuLy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.lblDangXuLy.Location = new System.Drawing.Point(16, 72);
            this.lblDangXuLy.Name = "lblDangXuLy";
            this.lblDangXuLy.Size = new System.Drawing.Size(190, 36);
            this.lblDangXuLy.TabIndex = 0;
            this.lblDangXuLy.Text = "Đơn chưa có CT";
            this.lblDangXuLy.Click += new System.EventHandler(this.lblDangXuLy_Click);

            // Card 3 – Green
            this.pnlHoanThanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlHoanThanh.Controls.Add(this.lblHoanThanhNum);
            this.pnlHoanThanh.Controls.Add(this.lblHoanThanh);
            this.pnlHoanThanh.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHoanThanh.Name = "pnlHoanThanh";
            this.pnlHoanThanh.Size = new System.Drawing.Size(220, 116);
            this.pnlHoanThanh.TabIndex = 2;
            this.pnlHoanThanh.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHoanThanh_Paint);
            //
            this.lblHoanThanhNum.AutoSize = false;
            this.lblHoanThanhNum.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoanThanhNum.ForeColor = System.Drawing.Color.White;
            this.lblHoanThanhNum.Location = new System.Drawing.Point(16, 12);
            this.lblHoanThanhNum.Name = "lblHoanThanhNum";
            this.lblHoanThanhNum.Size = new System.Drawing.Size(188, 50);
            this.lblHoanThanhNum.TabIndex = 1;
            this.lblHoanThanhNum.Text = "—";
            //
            this.lblHoanThanh.AutoSize = false;
            this.lblHoanThanh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoanThanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.lblHoanThanh.Location = new System.Drawing.Point(16, 72);
            this.lblHoanThanh.Name = "lblHoanThanh";
            this.lblHoanThanh.Size = new System.Drawing.Size(190, 36);
            this.lblHoanThanh.TabIndex = 0;
            this.lblHoanThanh.Text = "CT đã duyệt (tháng)";
            this.lblHoanThanh.Click += new System.EventHandler(this.lblHoanThanh_Click);

            // Card 4 – Teal
            this.pnlKhachMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(196)))));
            this.pnlKhachMoi.Controls.Add(this.lblKhachMoiNum);
            this.pnlKhachMoi.Controls.Add(this.lblKhachMoi);
            this.pnlKhachMoi.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKhachMoi.Name = "pnlKhachMoi";
            this.pnlKhachMoi.Size = new System.Drawing.Size(220, 116);
            this.pnlKhachMoi.TabIndex = 3;
            this.pnlKhachMoi.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlKhachMoi_Paint);
            //
            this.lblKhachMoiNum.AutoSize = false;
            this.lblKhachMoiNum.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhachMoiNum.ForeColor = System.Drawing.Color.White;
            this.lblKhachMoiNum.Location = new System.Drawing.Point(16, 12);
            this.lblKhachMoiNum.Name = "lblKhachMoiNum";
            this.lblKhachMoiNum.Size = new System.Drawing.Size(188, 50);
            this.lblKhachMoiNum.TabIndex = 1;
            this.lblKhachMoiNum.Text = "—";
            //
            this.lblKhachMoi.AutoSize = false;
            this.lblKhachMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhachMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lblKhachMoi.Location = new System.Drawing.Point(16, 72);
            this.lblKhachMoi.Name = "lblKhachMoi";
            this.lblKhachMoi.Size = new System.Drawing.Size(190, 36);
            this.lblKhachMoi.TabIndex = 0;
            this.lblKhachMoi.Text = "Hóa đơn (tháng)";
            this.lblKhachMoi.Click += new System.EventHandler(this.lblKhachMoi_Click);

            // Card 5 – Ocean Blue (wider, shows revenue)
            this.pnlDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuNum);
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThu);
            this.pnlDoanhThu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDoanhThu.Name = "pnlDoanhThu";
            this.pnlDoanhThu.Size = new System.Drawing.Size(248, 116);
            this.pnlDoanhThu.TabIndex = 4;
            this.pnlDoanhThu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDoanhThu_Paint);
            //
            this.lblDoanhThuNum.AutoSize = false;
            this.lblDoanhThuNum.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuNum.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuNum.Location = new System.Drawing.Point(16, 12);
            this.lblDoanhThuNum.Name = "lblDoanhThuNum";
            this.lblDoanhThuNum.Size = new System.Drawing.Size(216, 50);
            this.lblDoanhThuNum.TabIndex = 1;
            this.lblDoanhThuNum.Text = "—";
            //
            this.lblDoanhThu.AutoSize = false;
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblDoanhThu.Location = new System.Drawing.Point(16, 72);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(216, 36);
            this.lblDoanhThu.TabIndex = 0;
            this.lblDoanhThu.Text = "Doanh thu tháng";
            this.lblDoanhThu.Click += new System.EventHandler(this.lblDoanhThu_Click);

            // ── pnlDonContainer (left, Dock=Left, replaces grpDonHangMoi)
            this.pnlDonContainer.BackColor = System.Drawing.Color.White;
            this.pnlDonContainer.Controls.Add(this.dgvDonHangMoi);
            this.pnlDonContainer.Controls.Add(this.pnlDonHeader);
            this.pnlDonContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDonContainer.Location = new System.Drawing.Point(0, 200);
            this.pnlDonContainer.Name = "pnlDonContainer";
            this.pnlDonContainer.Size = new System.Drawing.Size(691, 461);
            this.pnlDonContainer.TabIndex = 2;
            //
            this.pnlDonHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlDonHeader.Controls.Add(this.lblDonTitle);
            this.pnlDonHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDonHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDonHeader.Name = "pnlDonHeader";
            this.pnlDonHeader.Size = new System.Drawing.Size(691, 36);
            this.pnlDonHeader.TabIndex = 0;
            //
            this.lblDonTitle.AutoSize = true;
            this.lblDonTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonTitle.ForeColor = System.Drawing.Color.White;
            this.lblDonTitle.Location = new System.Drawing.Point(12, 9);
            this.lblDonTitle.Name = "lblDonTitle";
            this.lblDonTitle.TabIndex = 0;
            this.lblDonTitle.Text = "Đơn đang hoạt động";
            //
            // dgvDonHangMoi
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            dgvHeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.White;
            dgvAltStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.dgvDonHangMoi.AlternatingRowsDefaultCellStyle = dgvAltStyle;
            this.dgvDonHangMoi.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonHangMoi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonHangMoi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDonHangMoi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDonHangMoi.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvDonHangMoi.ColumnHeadersHeight = 38;
            this.dgvDonHangMoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDonHangMoi.DefaultCellStyle = dgvRowStyle;
            this.dgvDonHangMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDonHangMoi.EnableHeadersVisualStyles = false;
            this.dgvDonHangMoi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.dgvDonHangMoi.Location = new System.Drawing.Point(0, 36);
            this.dgvDonHangMoi.Name = "dgvDonHangMoi";
            this.dgvDonHangMoi.RowHeadersVisible = false;
            this.dgvDonHangMoi.RowTemplate.Height = 30;
            this.dgvDonHangMoi.Size = new System.Drawing.Size(691, 425);
            this.dgvDonHangMoi.TabIndex = 1;

            // ── pnlVertSep (1px divider)
            this.pnlVertSep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.pnlVertSep.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlVertSep.Name = "pnlVertSep";
            this.pnlVertSep.Size = new System.Drawing.Size(1, 461);
            this.pnlVertSep.TabIndex = 3;

            // ── pnlChartContainer (Dock=Fill, replaces groupBox1)
            this.pnlChartContainer.BackColor = System.Drawing.Color.White;
            this.pnlChartContainer.Controls.Add(this.chartDoanhThu);
            this.pnlChartContainer.Controls.Add(this.pnlChartHeader);
            this.pnlChartContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartContainer.Location = new System.Drawing.Point(692, 200);
            this.pnlChartContainer.Name = "pnlChartContainer";
            this.pnlChartContainer.Size = new System.Drawing.Size(636, 461);
            this.pnlChartContainer.TabIndex = 4;
            //
            this.pnlChartHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlChartHeader.Controls.Add(this.lblChartTitle);
            this.pnlChartHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChartHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlChartHeader.Name = "pnlChartHeader";
            this.pnlChartHeader.Size = new System.Drawing.Size(636, 36);
            this.pnlChartHeader.TabIndex = 0;
            //
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartTitle.ForeColor = System.Drawing.Color.White;
            this.lblChartTitle.Location = new System.Drawing.Point(12, 9);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "Thống kê chứng từ theo loại";
            //
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.chartDoanhThu.BorderlineColor = System.Drawing.Color.Transparent;
            this.chartDoanhThu.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(0, 36);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(636, 425);
            this.chartDoanhThu.TabIndex = 1;
            this.chartDoanhThu.Text = "Doanh thu theo dịch vụ";
            this.chartDoanhThu.Click += new System.EventHandler(this.chartDoanhThu_Click);

            // ── FrmSalesDashboard (Form)
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1328, 661);
            this.Controls.Add(this.pnlChartContainer);
            this.Controls.Add(this.pnlVertSep);
            this.Controls.Add(this.pnlDonContainer);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmOfficeDashboard";
            this.Text = "FrmOfficeDashboard";
            this.Load += new System.EventHandler(this.FrmOfficeDashboard_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlChoXacNhan.ResumeLayout(false);
            this.pnlDangXuLy.ResumeLayout(false);
            this.pnlHoanThanh.ResumeLayout(false);
            this.pnlKhachMoi.ResumeLayout(false);
            this.pnlDoanhThu.ResumeLayout(false);
            this.pnlDonContainer.ResumeLayout(false);
            this.pnlDonHeader.ResumeLayout(false);
            this.pnlDonHeader.PerformLayout();
            this.pnlChartContainer.ResumeLayout(false);
            this.pnlChartHeader.ResumeLayout(false);
            this.pnlChartHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHangMoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlChoXacNhan;
        private System.Windows.Forms.Label lblChoXacNhanNum;
        private System.Windows.Forms.Label lblChoXacNhan;
        private System.Windows.Forms.Panel pnlDangXuLy;
        private System.Windows.Forms.Label lblDangXuLyNum;
        private System.Windows.Forms.Label lblDangXuLy;
        private System.Windows.Forms.Panel pnlHoanThanh;
        private System.Windows.Forms.Label lblHoanThanhNum;
        private System.Windows.Forms.Label lblHoanThanh;
        private System.Windows.Forms.Panel pnlKhachMoi;
        private System.Windows.Forms.Label lblKhachMoiNum;
        private System.Windows.Forms.Label lblKhachMoi;
        private System.Windows.Forms.Panel pnlDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuNum;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Panel pnlDonContainer;
        private System.Windows.Forms.Panel pnlDonHeader;
        private System.Windows.Forms.Label lblDonTitle;
        private System.Windows.Forms.Panel pnlVertSep;
        private System.Windows.Forms.DataGridView dgvDonHangMoi;
        private System.Windows.Forms.Panel pnlChartContainer;
        private System.Windows.Forms.Panel pnlChartHeader;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
    }
}