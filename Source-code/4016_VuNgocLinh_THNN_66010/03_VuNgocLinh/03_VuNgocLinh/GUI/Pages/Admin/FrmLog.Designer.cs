namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    partial class FrmLog
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.pnlGridTop = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.pnlGridBtns = new System.Windows.Forms.Panel();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.pnlDetailCard = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaLichSu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaDonDV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTrangThaiCu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTrangThaiMoi = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpThoiGian = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.pnlFilterCard = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.pnlFilterBtns = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lichSuTrangThaiDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyDichVu_DaiDuongXanhDataSet4 = new _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSet4();
            this.lichSuTrangThaiDonTableAdapter = new _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSet4TableAdapters.LichSuTrangThaiDonTableAdapter();
            this.label15 = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.pnlRoot.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.pnlGridTop.SuspendLayout();
            this.pnlGridBtns.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.pnlDetailCard.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilterCard.SuspendLayout();
            this.pnlFilterBtns.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lichSuTrangThaiDonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyDichVu_DaiDuongXanhDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlRoot.Controls.Add(this.pnlBody);
            this.pnlRoot.Controls.Add(this.pnlHeader);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Size = new System.Drawing.Size(1488, 700);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlGrid);
            this.pnlBody.Controls.Add(this.panel6);
            this.pnlBody.Controls.Add(this.pnlDetail);
            this.pnlBody.Controls.Add(this.panel3);
            this.pnlBody.Controls.Add(this.pnlFilter);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 64);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1488, 636);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvLog);
            this.pnlGrid.Controls.Add(this.pnlGridTop);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(322, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(14);
            this.pnlGrid.Size = new System.Drawing.Size(824, 636);
            this.pnlGrid.TabIndex = 12;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.dgvLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLog.ColumnHeadersHeight = 38;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLog.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            this.dgvLog.Location = new System.Drawing.Point(14, 64);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowHeadersWidth = 51;
            this.dgvLog.RowTemplate.Height = 34;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(796, 558);
            this.dgvLog.TabIndex = 66;
            this.dgvLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLog_CellContentClick);
            // 
            // pnlGridTop
            // 
            this.pnlGridTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlGridTop.Controls.Add(this.lblGridTitle);
            this.pnlGridTop.Controls.Add(this.pnlGridBtns);
            this.pnlGridTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridTop.Location = new System.Drawing.Point(14, 14);
            this.pnlGridTop.Name = "pnlGridTop";
            this.pnlGridTop.Size = new System.Drawing.Size(796, 50);
            this.pnlGridTop.TabIndex = 0;
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.lblGridTitle.Location = new System.Drawing.Point(0, 14);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(160, 25);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "Danh sách lịch sử";
            // 
            // pnlGridBtns
            // 
            this.pnlGridBtns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGridBtns.BackColor = System.Drawing.Color.Transparent;
            this.pnlGridBtns.Controls.Add(this.btnTaiLai);
            this.pnlGridBtns.Controls.Add(this.btnXuatExcel);
            this.pnlGridBtns.Location = new System.Drawing.Point(520, 7);
            this.pnlGridBtns.Name = "pnlGridBtns";
            this.pnlGridBtns.Size = new System.Drawing.Size(276, 36);
            this.pnlGridBtns.TabIndex = 1;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.btnTaiLai.FlatAppearance.BorderSize = 0;
            this.btnTaiLai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnTaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTaiLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnTaiLai.Location = new System.Drawing.Point(0, 0);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(130, 36);
            this.btnTaiLai.TabIndex = 77;
            this.btnTaiLai.Text = "↺  Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = false;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(80)))));
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(138, 0);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(138, 36);
            this.btnXuatExcel.TabIndex = 78;
            this.btnXuatExcel.Text = "📥  Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1146, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2, 636);
            this.panel6.TabIndex = 11;
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.White;
            this.pnlDetail.Controls.Add(this.lblDetailTitle);
            this.pnlDetail.Controls.Add(this.pnlDetailCard);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Location = new System.Drawing.Point(1148, 0);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.pnlDetail.Size = new System.Drawing.Size(340, 636);
            this.pnlDetail.TabIndex = 13;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(16, 14);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(308, 30);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "📝  Chi tiết bản ghi";
            // 
            // pnlDetailCard
            // 
            this.pnlDetailCard.AutoScroll = true;
            this.pnlDetailCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlDetailCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetailCard.Controls.Add(this.label5);
            this.pnlDetailCard.Controls.Add(this.txtMaLichSu);
            this.pnlDetailCard.Controls.Add(this.label8);
            this.pnlDetailCard.Controls.Add(this.txtMaDonDV);
            this.pnlDetailCard.Controls.Add(this.label7);
            this.pnlDetailCard.Controls.Add(this.txtTrangThaiCu);
            this.pnlDetailCard.Controls.Add(this.label10);
            this.pnlDetailCard.Controls.Add(this.txtTrangThaiMoi);
            this.pnlDetailCard.Controls.Add(this.label12);
            this.pnlDetailCard.Controls.Add(this.txtTenNhanVien);
            this.pnlDetailCard.Controls.Add(this.label13);
            this.pnlDetailCard.Controls.Add(this.dtpThoiGian);
            this.pnlDetailCard.Controls.Add(this.label14);
            this.pnlDetailCard.Controls.Add(this.txtGhiChu);
            this.pnlDetailCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailCard.Location = new System.Drawing.Point(16, 14);
            this.pnlDetailCard.Name = "pnlDetailCard";
            this.pnlDetailCard.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.pnlDetailCard.Size = new System.Drawing.Size(308, 608);
            this.pnlDetailCard.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label5.Location = new System.Drawing.Point(14, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 80;
            this.label5.Text = "MÃ LỊCH SỬ";
            // 
            // txtMaLichSu
            // 
            this.txtMaLichSu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaLichSu.Location = new System.Drawing.Point(14, 34);
            this.txtMaLichSu.Name = "txtMaLichSu";
            this.txtMaLichSu.Size = new System.Drawing.Size(262, 30);
            this.txtMaLichSu.TabIndex = 1;
            this.txtMaLichSu.TextChanged += new System.EventHandler(this.txtMaLichSu_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label8.Location = new System.Drawing.Point(14, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 83;
            this.label8.Text = "MÃ ĐƠN";
            // 
            // txtMaDonDV
            // 
            this.txtMaDonDV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaDonDV.Location = new System.Drawing.Point(14, 98);
            this.txtMaDonDV.Name = "txtMaDonDV";
            this.txtMaDonDV.Size = new System.Drawing.Size(262, 30);
            this.txtMaDonDV.TabIndex = 2;
            this.txtMaDonDV.TextChanged += new System.EventHandler(this.txtMaDonDV_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label7.Location = new System.Drawing.Point(14, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 81;
            this.label7.Text = "TRẠNG THÁI CŨ";
            // 
            // txtTrangThaiCu
            // 
            this.txtTrangThaiCu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTrangThaiCu.Location = new System.Drawing.Point(14, 162);
            this.txtTrangThaiCu.Name = "txtTrangThaiCu";
            this.txtTrangThaiCu.Size = new System.Drawing.Size(262, 30);
            this.txtTrangThaiCu.TabIndex = 3;
            this.txtTrangThaiCu.TextChanged += new System.EventHandler(this.txtTrangThaiCu_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label10.Location = new System.Drawing.Point(14, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 20);
            this.label10.TabIndex = 85;
            this.label10.Text = "TRẠNG THÁI MỚI";
            // 
            // txtTrangThaiMoi
            // 
            this.txtTrangThaiMoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTrangThaiMoi.Location = new System.Drawing.Point(14, 226);
            this.txtTrangThaiMoi.Name = "txtTrangThaiMoi";
            this.txtTrangThaiMoi.Size = new System.Drawing.Size(262, 30);
            this.txtTrangThaiMoi.TabIndex = 4;
            this.txtTrangThaiMoi.TextChanged += new System.EventHandler(this.txtTrangThaiMoi_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label12.Location = new System.Drawing.Point(14, 268);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 20);
            this.label12.TabIndex = 87;
            this.label12.Text = "TÊN NHÂN VIÊN";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenNhanVien.Location = new System.Drawing.Point(14, 290);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(262, 30);
            this.txtTenNhanVien.TabIndex = 5;
            this.txtTenNhanVien.TextChanged += new System.EventHandler(this.txtTenNhanVien_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label13.Location = new System.Drawing.Point(14, 332);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 20);
            this.label13.TabIndex = 89;
            this.label13.Text = "THỜI GIAN CẬP NHẬT";
            // 
            // dtpThoiGian
            // 
            this.dtpThoiGian.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpThoiGian.Location = new System.Drawing.Point(14, 354);
            this.dtpThoiGian.Name = "dtpThoiGian";
            this.dtpThoiGian.Size = new System.Drawing.Size(262, 30);
            this.dtpThoiGian.TabIndex = 6;
            this.dtpThoiGian.ValueChanged += new System.EventHandler(this.dtpThoiGian_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label14.Location = new System.Drawing.Point(14, 396);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 20);
            this.label14.TabIndex = 91;
            this.label14.Text = "GHI CHÚ";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(14, 418);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(262, 30);
            this.txtGhiChu.TabIndex = 7;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(320, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 636);
            this.panel3.TabIndex = 10;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.lblFilterTitle);
            this.pnlFilter.Controls.Add(this.pnlFilterCard);
            this.pnlFilter.Controls.Add(this.pnlFilterBtns);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.pnlFilter.Size = new System.Drawing.Size(320, 636);
            this.pnlFilter.TabIndex = 9;
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFilterTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblFilterTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.lblFilterTitle.Location = new System.Drawing.Point(16, 14);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(288, 30);
            this.lblFilterTitle.TabIndex = 0;
            this.lblFilterTitle.Text = "🔍  Bộ lọc tìm kiếm";
            // 
            // pnlFilterCard
            // 
            this.pnlFilterCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlFilterCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterCard.Controls.Add(this.label15);
            this.pnlFilterCard.Controls.Add(this.cboNhanVien);
            this.pnlFilterCard.Controls.Add(this.label2);
            this.pnlFilterCard.Controls.Add(this.txtMaDon);
            this.pnlFilterCard.Controls.Add(this.label9);
            this.pnlFilterCard.Controls.Add(this.cboTrangThai);
            this.pnlFilterCard.Controls.Add(this.label6);
            this.pnlFilterCard.Controls.Add(this.cboVaiTro);
            this.pnlFilterCard.Controls.Add(this.label1);
            this.pnlFilterCard.Controls.Add(this.dtpTuNgay);
            this.pnlFilterCard.Controls.Add(this.label4);
            this.pnlFilterCard.Controls.Add(this.dtpDenNgay);
            this.pnlFilterCard.Location = new System.Drawing.Point(16, 44);
            this.pnlFilterCard.Name = "pnlFilterCard";
            this.pnlFilterCard.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlFilterCard.Size = new System.Drawing.Size(288, 406);
            this.pnlFilterCard.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "MÃ ĐƠN";
            // 
            // txtMaDon
            // 
            this.txtMaDon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaDon.Location = new System.Drawing.Point(12, 36);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(250, 30);
            this.txtMaDon.TabIndex = 51;
            this.txtMaDon.TextChanged += new System.EventHandler(this.txtMaDon_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label9.Location = new System.Drawing.Point(12, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 20);
            this.label9.TabIndex = 52;
            this.label9.Text = "TRẠNG THÁI";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(12, 100);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(250, 31);
            this.cboTrangThai.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label6.Location = new System.Drawing.Point(12, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 54;
            this.label6.Text = "VAI TRÒ";
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(12, 164);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(250, 31);
            this.cboVaiTro.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(12, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "TỪ NGÀY";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTuNgay.Location = new System.Drawing.Point(12, 228);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(250, 30);
            this.dtpTuNgay.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label4.Location = new System.Drawing.Point(12, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 58;
            this.label4.Text = "ĐẾN NGÀY";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDenNgay.Location = new System.Drawing.Point(12, 292);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(250, 30);
            this.dtpDenNgay.TabIndex = 59;
            // 
            // pnlFilterBtns
            // 
            this.pnlFilterBtns.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilterBtns.Controls.Add(this.btnTimKiem);
            this.pnlFilterBtns.Controls.Add(this.btnLamMoi);
            this.pnlFilterBtns.Location = new System.Drawing.Point(19, 456);
            this.pnlFilterBtns.Name = "pnlFilterBtns";
            this.pnlFilterBtns.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlFilterBtns.Size = new System.Drawing.Size(288, 54);
            this.pnlFilterBtns.TabIndex = 2;
            this.pnlFilterBtns.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFilterBtns_Paint);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(73)))));
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(144)))), ((int)(((byte)(204)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(0, 10);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(138, 36);
            this.btnTimKiem.TabIndex = 62;
            this.btnTimKiem.Text = "🔍  Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnLamMoi.Location = new System.Drawing.Point(146, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(138, 36);
            this.btnLamMoi.TabIndex = 63;
            this.btnLamMoi.Text = "↺  Đặt lại";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1488, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(323, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LỊCH SỬ TRẠNG THÁI ĐƠN";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.lblSubTitle.Location = new System.Drawing.Point(22, 38);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(321, 20);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Theo dõi lịch sử thay đổi trạng thái đơn dịch vụ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Visible = false;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 0;
            this.label11.Visible = false;
            // 
            // lichSuTrangThaiDonBindingSource
            // 
            this.lichSuTrangThaiDonBindingSource.DataMember = "LichSuTrangThaiDon";
            this.lichSuTrangThaiDonBindingSource.DataSource = this.quanLyDichVu_DaiDuongXanhDataSet4;
            // 
            // quanLyDichVu_DaiDuongXanhDataSet4
            // 
            this.quanLyDichVu_DaiDuongXanhDataSet4.DataSetName = "QuanLyDichVu_DaiDuongXanhDataSet4";
            this.quanLyDichVu_DaiDuongXanhDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lichSuTrangThaiDonTableAdapter
            // 
            this.lichSuTrangThaiDonTableAdapter.ClearBeforeFill = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label15.Location = new System.Drawing.Point(12, 339);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 20);
            this.label15.TabIndex = 60;
            this.label15.Text = "THEO NHÂN VIÊN";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(12, 361);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(250, 31);
            this.cboNhanVien.TabIndex = 61;
            this.cboNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboNhanVien_SelectedIndexChanged);
            // 
            // FrmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1488, 700);
            this.Controls.Add(this.pnlRoot);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 620);
            this.Name = "FrmLog";
            this.Text = "Lịch sử trạng thái đơn";
            this.Load += new System.EventHandler(this.FrmLog_Load);
            this.pnlRoot.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.pnlGridTop.ResumeLayout(false);
            this.pnlGridTop.PerformLayout();
            this.pnlGridBtns.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetailCard.ResumeLayout(false);
            this.pnlDetailCard.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilterCard.ResumeLayout(false);
            this.pnlFilterCard.PerformLayout();
            this.pnlFilterBtns.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lichSuTrangThaiDonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyDichVu_DaiDuongXanhDataSet4)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        // ── Fields ────────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel pnlBody;

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.Panel pnlFilterCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Panel pnlFilterBtns;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlGridTop;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Panel pnlGridBtns;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DataGridView dgvLog;

        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Panel pnlDetailCard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaLichSu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaDonDV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTrangThaiCu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTrangThaiMoi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpThoiGian;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtGhiChu;

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;

        // Legacy
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSet4 quanLyDichVu_DaiDuongXanhDataSet4;
        private System.Windows.Forms.BindingSource lichSuTrangThaiDonBindingSource;
        private _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSet4TableAdapters.LichSuTrangThaiDonTableAdapter lichSuTrangThaiDonTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mALICHSUDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mADONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRANGTHAICUDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRANGTHAIMOIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mANVCAPNHATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tHOIGIANCAPNHATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gHICHUDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboNhanVien;
    }
}