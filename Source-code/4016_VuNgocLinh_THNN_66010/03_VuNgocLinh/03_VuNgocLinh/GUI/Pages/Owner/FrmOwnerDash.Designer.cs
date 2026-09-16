namespace _03_VuNgocLinh.GUI.Pages.Owner
{
    partial class FrmOwnerDash
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderLine = new System.Windows.Forms.Panel();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.pnlReportHeader = new System.Windows.Forms.Panel();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.btnBaocaoDonDV = new System.Windows.Forms.Button();
            this.btnBaocaoKH = new System.Windows.Forms.Button();
            this.btnBaocaoNV = new System.Windows.Forms.Button();
            this.pnlDoanhThu = new System.Windows.Forms.Panel();
            this.lblDoanhThuNum = new System.Windows.Forms.Label();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.pnlKhachMoi = new System.Windows.Forms.Panel();
            this.lblKhachMoiNum = new System.Windows.Forms.Label();
            this.lblKhachMoi = new System.Windows.Forms.Label();
            this.pnlHoanThanh = new System.Windows.Forms.Panel();
            this.lblHoanThanhNum = new System.Windows.Forms.Label();
            this.lblHoanThanh = new System.Windows.Forms.Label();
            this.pnlDangXuLy = new System.Windows.Forms.Panel();
            this.lblDangXuLyNum = new System.Windows.Forms.Label();
            this.lblDangXuLy = new System.Windows.Forms.Label();
            this.pnlChoXacNhan = new System.Windows.Forms.Panel();
            this.lblChoXacNhanNum = new System.Windows.Forms.Label();
            this.lblChoXacNhan = new System.Windows.Forms.Label();
            this.pnlNVContainer = new System.Windows.Forms.Panel();
            this.dgvHieuSuatNV = new System.Windows.Forms.DataGridView();
            this.pnlNVHeader = new System.Windows.Forms.Panel();
            this.lblNVTitle = new System.Windows.Forms.Label();
            this.pnlVertSep = new System.Windows.Forms.Panel();
            this.pnlChartContainer = new System.Windows.Forms.Panel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlChartHeader = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlReport.SuspendLayout();
            this.pnlReportHeader.SuspendLayout();
            this.pnlDoanhThu.SuspendLayout();
            this.pnlKhachMoi.SuspendLayout();
            this.pnlHoanThanh.SuspendLayout();
            this.pnlDangXuLy.SuspendLayout();
            this.pnlChoXacNhan.SuspendLayout();
            this.pnlNVContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHieuSuatNV)).BeginInit();
            this.pnlNVHeader.SuspendLayout();
            this.pnlChartContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.pnlChartHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlHeader.Controls.Add(this.pnlHeaderLine);
            this.pnlHeader.Controls.Add(this.lblNhanVien);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.panel1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1730, 84);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlHeaderLine
            // 
            this.pnlHeaderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(196)))));
            this.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderLine.Location = new System.Drawing.Point(0, 81);
            this.pnlHeaderLine.Name = "pnlHeaderLine";
            this.pnlHeaderLine.Size = new System.Drawing.Size(1730, 3);
            this.pnlHeaderLine.TabIndex = 10;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.lblNhanVien.Location = new System.Drawing.Point(22, 55);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(80, 23);
            this.lblNhanVien.TabIndex = 2;
            this.lblNhanVien.Text = "Xin chào:";
            this.lblNhanVien.Click += new System.EventHandler(this.lblNhanVien_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(719, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CÔNG TY TNHH TM DV VẬN TẢI QUỐC TẾ ĐẠI DƯƠNG XANH";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlMenu.Controls.Add(this.pnlReport);
            this.pnlMenu.Controls.Add(this.pnlDoanhThu);
            this.pnlMenu.Controls.Add(this.pnlKhachMoi);
            this.pnlMenu.Controls.Add(this.pnlHoanThanh);
            this.pnlMenu.Controls.Add(this.pnlDangXuLy);
            this.pnlMenu.Controls.Add(this.pnlChoXacNhan);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 84);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1730, 116);
            this.pnlMenu.TabIndex = 1;
            // 
            // pnlReport
            // 
            this.pnlReport.BackColor = System.Drawing.Color.White;
            this.pnlReport.Controls.Add(this.pnlReportHeader);
            this.pnlReport.Controls.Add(this.btnBaocaoDonDV);
            this.pnlReport.Controls.Add(this.btnBaocaoKH);
            this.pnlReport.Controls.Add(this.btnBaocaoNV);
            this.pnlReport.Location = new System.Drawing.Point(1142, 4);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(420, 108);
            this.pnlReport.TabIndex = 5;
            // 
            // pnlReportHeader
            // 
            this.pnlReportHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlReportHeader.Controls.Add(this.lblReportTitle);
            this.pnlReportHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlReportHeader.Name = "pnlReportHeader";
            this.pnlReportHeader.Size = new System.Drawing.Size(420, 32);
            this.pnlReportHeader.TabIndex = 3;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.White;
            this.lblReportTitle.Location = new System.Drawing.Point(10, 8);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(202, 20);
            this.lblReportTitle.TabIndex = 0;
            this.lblReportTitle.Text = "Xuất báo cáo doanh thu theo";
            // 
            // btnBaocaoDonDV
            // 
            this.btnBaocaoDonDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnBaocaoDonDV.FlatAppearance.BorderSize = 0;
            this.btnBaocaoDonDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaocaoDonDV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaocaoDonDV.ForeColor = System.Drawing.Color.White;
            this.btnBaocaoDonDV.Location = new System.Drawing.Point(278, 40);
            this.btnBaocaoDonDV.Name = "btnBaocaoDonDV";
            this.btnBaocaoDonDV.Size = new System.Drawing.Size(136, 34);
            this.btnBaocaoDonDV.TabIndex = 2;
            this.btnBaocaoDonDV.Text = "Đơn dịch vụ";
            this.btnBaocaoDonDV.UseVisualStyleBackColor = false;
            this.btnBaocaoDonDV.Click += new System.EventHandler(this.btnBaocaoDonDV_Click);
            // 
            // btnBaocaoKH
            // 
            this.btnBaocaoKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(196)))));
            this.btnBaocaoKH.FlatAppearance.BorderSize = 0;
            this.btnBaocaoKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaocaoKH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaocaoKH.ForeColor = System.Drawing.Color.White;
            this.btnBaocaoKH.Location = new System.Drawing.Point(142, 40);
            this.btnBaocaoKH.Name = "btnBaocaoKH";
            this.btnBaocaoKH.Size = new System.Drawing.Size(124, 34);
            this.btnBaocaoKH.TabIndex = 1;
            this.btnBaocaoKH.Text = "Khách hàng";
            this.btnBaocaoKH.UseVisualStyleBackColor = false;
            this.btnBaocaoKH.Click += new System.EventHandler(this.btnBaocaoKH_Click);
            // 
            // btnBaocaoNV
            // 
            this.btnBaocaoNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnBaocaoNV.FlatAppearance.BorderSize = 0;
            this.btnBaocaoNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaocaoNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaocaoNV.ForeColor = System.Drawing.Color.White;
            this.btnBaocaoNV.Location = new System.Drawing.Point(6, 40);
            this.btnBaocaoNV.Name = "btnBaocaoNV";
            this.btnBaocaoNV.Size = new System.Drawing.Size(124, 34);
            this.btnBaocaoNV.TabIndex = 0;
            this.btnBaocaoNV.Text = "Nhân viên";
            this.btnBaocaoNV.UseVisualStyleBackColor = false;
            this.btnBaocaoNV.Click += new System.EventHandler(this.btnBaocaoNV_Click);
            // 
            // pnlDoanhThu
            // 
            this.pnlDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuNum);
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThu);
            this.pnlDoanhThu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDoanhThu.Location = new System.Drawing.Point(880, 0);
            this.pnlDoanhThu.Name = "pnlDoanhThu";
            this.pnlDoanhThu.Size = new System.Drawing.Size(260, 116);
            this.pnlDoanhThu.TabIndex = 4;
            // 
            // lblDoanhThuNum
            // 
            this.lblDoanhThuNum.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuNum.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuNum.Location = new System.Drawing.Point(16, 12);
            this.lblDoanhThuNum.Name = "lblDoanhThuNum";
            this.lblDoanhThuNum.Size = new System.Drawing.Size(228, 50);
            this.lblDoanhThuNum.TabIndex = 1;
            this.lblDoanhThuNum.Text = "—";
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblDoanhThu.Location = new System.Drawing.Point(16, 72);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(228, 36);
            this.lblDoanhThu.TabIndex = 0;
            this.lblDoanhThu.Text = "Tổng doanh thu";
            this.lblDoanhThu.Click += new System.EventHandler(this.lblDoanhThu_Click);
            // 
            // pnlKhachMoi
            // 
            this.pnlKhachMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(196)))));
            this.pnlKhachMoi.Controls.Add(this.lblKhachMoiNum);
            this.pnlKhachMoi.Controls.Add(this.lblKhachMoi);
            this.pnlKhachMoi.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKhachMoi.Location = new System.Drawing.Point(660, 0);
            this.pnlKhachMoi.Name = "pnlKhachMoi";
            this.pnlKhachMoi.Size = new System.Drawing.Size(220, 116);
            this.pnlKhachMoi.TabIndex = 3;
            // 
            // lblKhachMoiNum
            // 
            this.lblKhachMoiNum.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhachMoiNum.ForeColor = System.Drawing.Color.White;
            this.lblKhachMoiNum.Location = new System.Drawing.Point(16, 12);
            this.lblKhachMoiNum.Name = "lblKhachMoiNum";
            this.lblKhachMoiNum.Size = new System.Drawing.Size(188, 50);
            this.lblKhachMoiNum.TabIndex = 1;
            this.lblKhachMoiNum.Text = "—";
            // 
            // lblKhachMoi
            // 
            this.lblKhachMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhachMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lblKhachMoi.Location = new System.Drawing.Point(16, 72);
            this.lblKhachMoi.Name = "lblKhachMoi";
            this.lblKhachMoi.Size = new System.Drawing.Size(190, 36);
            this.lblKhachMoi.TabIndex = 0;
            this.lblKhachMoi.Text = "Khách hàng mới (tháng)";
            this.lblKhachMoi.Click += new System.EventHandler(this.lblKhachMoi_Click);
            // 
            // pnlHoanThanh
            // 
            this.pnlHoanThanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlHoanThanh.Controls.Add(this.lblHoanThanhNum);
            this.pnlHoanThanh.Controls.Add(this.lblHoanThanh);
            this.pnlHoanThanh.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHoanThanh.Location = new System.Drawing.Point(440, 0);
            this.pnlHoanThanh.Name = "pnlHoanThanh";
            this.pnlHoanThanh.Size = new System.Drawing.Size(220, 116);
            this.pnlHoanThanh.TabIndex = 2;
            // 
            // lblHoanThanhNum
            // 
            this.lblHoanThanhNum.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoanThanhNum.ForeColor = System.Drawing.Color.White;
            this.lblHoanThanhNum.Location = new System.Drawing.Point(16, 12);
            this.lblHoanThanhNum.Name = "lblHoanThanhNum";
            this.lblHoanThanhNum.Size = new System.Drawing.Size(188, 50);
            this.lblHoanThanhNum.TabIndex = 1;
            this.lblHoanThanhNum.Text = "—";
            // 
            // lblHoanThanh
            // 
            this.lblHoanThanh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoanThanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.lblHoanThanh.Location = new System.Drawing.Point(16, 72);
            this.lblHoanThanh.Name = "lblHoanThanh";
            this.lblHoanThanh.Size = new System.Drawing.Size(190, 36);
            this.lblHoanThanh.TabIndex = 0;
            this.lblHoanThanh.Text = "Đơn hoàn thành";
            this.lblHoanThanh.Click += new System.EventHandler(this.lblHoanThanh_Click);
            // 
            // pnlDangXuLy
            // 
            this.pnlDangXuLy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.pnlDangXuLy.Controls.Add(this.lblDangXuLyNum);
            this.pnlDangXuLy.Controls.Add(this.lblDangXuLy);
            this.pnlDangXuLy.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDangXuLy.Location = new System.Drawing.Point(220, 0);
            this.pnlDangXuLy.Name = "pnlDangXuLy";
            this.pnlDangXuLy.Size = new System.Drawing.Size(220, 116);
            this.pnlDangXuLy.TabIndex = 1;
            // 
            // lblDangXuLyNum
            // 
            this.lblDangXuLyNum.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangXuLyNum.ForeColor = System.Drawing.Color.White;
            this.lblDangXuLyNum.Location = new System.Drawing.Point(16, 12);
            this.lblDangXuLyNum.Name = "lblDangXuLyNum";
            this.lblDangXuLyNum.Size = new System.Drawing.Size(188, 50);
            this.lblDangXuLyNum.TabIndex = 1;
            this.lblDangXuLyNum.Text = "—";
            // 
            // lblDangXuLy
            // 
            this.lblDangXuLy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangXuLy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.lblDangXuLy.Location = new System.Drawing.Point(16, 72);
            this.lblDangXuLy.Name = "lblDangXuLy";
            this.lblDangXuLy.Size = new System.Drawing.Size(190, 36);
            this.lblDangXuLy.TabIndex = 0;
            this.lblDangXuLy.Text = "Đơn đang xử lý";
            this.lblDangXuLy.Click += new System.EventHandler(this.lblDangXuLy_Click);
            // 
            // pnlChoXacNhan
            // 
            this.pnlChoXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlChoXacNhan.Controls.Add(this.lblChoXacNhanNum);
            this.pnlChoXacNhan.Controls.Add(this.lblChoXacNhan);
            this.pnlChoXacNhan.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlChoXacNhan.Location = new System.Drawing.Point(0, 0);
            this.pnlChoXacNhan.Name = "pnlChoXacNhan";
            this.pnlChoXacNhan.Size = new System.Drawing.Size(220, 116);
            this.pnlChoXacNhan.TabIndex = 0;
            // 
            // lblChoXacNhanNum
            // 
            this.lblChoXacNhanNum.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoXacNhanNum.ForeColor = System.Drawing.Color.White;
            this.lblChoXacNhanNum.Location = new System.Drawing.Point(16, 12);
            this.lblChoXacNhanNum.Name = "lblChoXacNhanNum";
            this.lblChoXacNhanNum.Size = new System.Drawing.Size(188, 50);
            this.lblChoXacNhanNum.TabIndex = 1;
            this.lblChoXacNhanNum.Text = "—";
            // 
            // lblChoXacNhan
            // 
            this.lblChoXacNhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(216)))));
            this.lblChoXacNhan.Location = new System.Drawing.Point(16, 72);
            this.lblChoXacNhan.Name = "lblChoXacNhan";
            this.lblChoXacNhan.Size = new System.Drawing.Size(190, 36);
            this.lblChoXacNhan.TabIndex = 0;
            this.lblChoXacNhan.Text = "Đơn chờ xác nhận";
            this.lblChoXacNhan.Click += new System.EventHandler(this.lblChoXacNhan_Click);
            // 
            // pnlNVContainer
            // 
            this.pnlNVContainer.BackColor = System.Drawing.Color.White;
            this.pnlNVContainer.Controls.Add(this.dgvHieuSuatNV);
            this.pnlNVContainer.Controls.Add(this.pnlNVHeader);
            this.pnlNVContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNVContainer.Location = new System.Drawing.Point(0, 200);
            this.pnlNVContainer.Name = "pnlNVContainer";
            this.pnlNVContainer.Size = new System.Drawing.Size(857, 461);
            this.pnlNVContainer.TabIndex = 2;
            // 
            // dgvHieuSuatNV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.dgvHieuSuatNV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHieuSuatNV.BackgroundColor = System.Drawing.Color.White;
            this.dgvHieuSuatNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHieuSuatNV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHieuSuatNV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHieuSuatNV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHieuSuatNV.ColumnHeadersHeight = 38;
            this.dgvHieuSuatNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHieuSuatNV.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHieuSuatNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHieuSuatNV.EnableHeadersVisualStyles = false;
            this.dgvHieuSuatNV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.dgvHieuSuatNV.Location = new System.Drawing.Point(0, 36);
            this.dgvHieuSuatNV.Name = "dgvHieuSuatNV";
            this.dgvHieuSuatNV.RowHeadersVisible = false;
            this.dgvHieuSuatNV.RowHeadersWidth = 51;
            this.dgvHieuSuatNV.RowTemplate.Height = 30;
            this.dgvHieuSuatNV.Size = new System.Drawing.Size(857, 425);
            this.dgvHieuSuatNV.TabIndex = 1;
            this.dgvHieuSuatNV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHieuSuatNV_CellContentClick);
            // 
            // pnlNVHeader
            // 
            this.pnlNVHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlNVHeader.Controls.Add(this.lblNVTitle);
            this.pnlNVHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNVHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlNVHeader.Name = "pnlNVHeader";
            this.pnlNVHeader.Size = new System.Drawing.Size(857, 36);
            this.pnlNVHeader.TabIndex = 0;
            // 
            // lblNVTitle
            // 
            this.lblNVTitle.AutoSize = true;
            this.lblNVTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVTitle.ForeColor = System.Drawing.Color.White;
            this.lblNVTitle.Location = new System.Drawing.Point(12, 9);
            this.lblNVTitle.Name = "lblNVTitle";
            this.lblNVTitle.Size = new System.Drawing.Size(164, 23);
            this.lblNVTitle.TabIndex = 0;
            this.lblNVTitle.Text = "Hiệu suất nhân viên";
            // 
            // pnlVertSep
            // 
            this.pnlVertSep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.pnlVertSep.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlVertSep.Location = new System.Drawing.Point(857, 200);
            this.pnlVertSep.Name = "pnlVertSep";
            this.pnlVertSep.Size = new System.Drawing.Size(1, 461);
            this.pnlVertSep.TabIndex = 3;
            // 
            // pnlChartContainer
            // 
            this.pnlChartContainer.BackColor = System.Drawing.Color.White;
            this.pnlChartContainer.Controls.Add(this.chartDoanhThu);
            this.pnlChartContainer.Controls.Add(this.pnlChartHeader);
            this.pnlChartContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartContainer.Location = new System.Drawing.Point(858, 200);
            this.pnlChartContainer.Name = "pnlChartContainer";
            this.pnlChartContainer.Size = new System.Drawing.Size(872, 461);
            this.pnlChartContainer.TabIndex = 4;
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.chartDoanhThu.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
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
            this.chartDoanhThu.Size = new System.Drawing.Size(872, 425);
            this.chartDoanhThu.TabIndex = 1;
            this.chartDoanhThu.Text = "Doanh thu theo dịch vụ";
            this.chartDoanhThu.Click += new System.EventHandler(this.chartDoanhThu_Click);
            // 
            // pnlChartHeader
            // 
            this.pnlChartHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlChartHeader.Controls.Add(this.lblChartTitle);
            this.pnlChartHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChartHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlChartHeader.Name = "pnlChartHeader";
            this.pnlChartHeader.Size = new System.Drawing.Size(872, 36);
            this.pnlChartHeader.TabIndex = 0;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartTitle.ForeColor = System.Drawing.Color.White;
            this.lblChartTitle.Location = new System.Drawing.Point(12, 9);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(319, 23);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "Biểu đồ doanh thu theo dịch vụ (Top 10)";
            // 
            // FrmOwnerDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1730, 661);
            this.Controls.Add(this.pnlChartContainer);
            this.Controls.Add(this.pnlVertSep);
            this.Controls.Add(this.pnlNVContainer);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmOwnerDash";
            this.Text = "FrmOwnerDash";
            this.Load += new System.EventHandler(this.FrmOwnerDash_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlReport.ResumeLayout(false);
            this.pnlReportHeader.ResumeLayout(false);
            this.pnlReportHeader.PerformLayout();
            this.pnlDoanhThu.ResumeLayout(false);
            this.pnlKhachMoi.ResumeLayout(false);
            this.pnlHoanThanh.ResumeLayout(false);
            this.pnlDangXuLy.ResumeLayout(false);
            this.pnlChoXacNhan.ResumeLayout(false);
            this.pnlNVContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHieuSuatNV)).EndInit();
            this.pnlNVHeader.ResumeLayout(false);
            this.pnlNVHeader.PerformLayout();
            this.pnlChartContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.pnlChartHeader.ResumeLayout(false);
            this.pnlChartHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ── Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNhanVien;
        // ── KPI cards
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
        // ── Report section
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Panel pnlReportHeader;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Button btnBaocaoNV;
        private System.Windows.Forms.Button btnBaocaoKH;
        private System.Windows.Forms.Button btnBaocaoDonDV;
        // ── NV performance
        private System.Windows.Forms.Panel pnlNVContainer;
        private System.Windows.Forms.Panel pnlNVHeader;
        private System.Windows.Forms.Label lblNVTitle;
        private System.Windows.Forms.Panel pnlVertSep;
        private System.Windows.Forms.DataGridView dgvHieuSuatNV;
        // ── Chart
        private System.Windows.Forms.Panel pnlChartContainer;
        private System.Windows.Forms.Panel pnlChartHeader;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
    }
}
