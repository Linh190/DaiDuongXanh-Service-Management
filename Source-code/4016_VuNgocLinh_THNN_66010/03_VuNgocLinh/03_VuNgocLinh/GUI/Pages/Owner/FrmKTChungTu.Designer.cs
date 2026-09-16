namespace _03_VuNgocLinh.GUI.Pages.Owner
{
    partial class FrmKTChungTu
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.pnlKPI = new System.Windows.Forms.Panel();
            this.pnlKpiCardKHL = new System.Windows.Forms.Panel();
            this.lblKpiKHLTitle = new System.Windows.Forms.Label();
            this.lblKpiKhongHL = new System.Windows.Forms.Label();
            this.pnlKpiCardHL = new System.Windows.Forms.Panel();
            this.lblKpiHLTitle = new System.Windows.Forms.Label();
            this.lblKpiHopLe = new System.Windows.Forms.Label();
            this.pnlKpiCardCho = new System.Windows.Forms.Panel();
            this.lblKpiChoTitle = new System.Windows.Forms.Label();
            this.lblKpiChoKT = new System.Windows.Forms.Label();
            this.pnlKpiCardTong = new System.Windows.Forms.Panel();
            this.lblKpiTongTitle = new System.Windows.Forms.Label();
            this.lblKpiTong = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblFilterLoai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblFilterTT = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.pnlChiTiet = new System.Windows.Forms.Panel();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.lblChiTietDichVuHeader = new System.Windows.Forms.Label();
            this.pnlChiTietInfo = new System.Windows.Forms.Panel();
            this.lblLblMaCT = new System.Windows.Forms.Label();
            this.lblChiTietMaCT = new System.Windows.Forms.Label();
            this.lblLblSoCT = new System.Windows.Forms.Label();
            this.lblChiTietSoCT = new System.Windows.Forms.Label();
            this.lblLblLoai = new System.Windows.Forms.Label();
            this.lblChiTietLoai = new System.Windows.Forms.Label();
            this.lblLblNgayLap = new System.Windows.Forms.Label();
            this.lblChiTietNgayLap = new System.Windows.Forms.Label();
            this.lblLblMaDon = new System.Windows.Forms.Label();
            this.lblChiTietMaDon = new System.Windows.Forms.Label();
            this.lblLblTongTien = new System.Windows.Forms.Label();
            this.lblChiTietTongTien = new System.Windows.Forms.Label();
            this.lblLblTrangThai = new System.Windows.Forms.Label();
            this.lblChiTietTrangThai = new System.Windows.Forms.Label();
            this.lblLblNVKT = new System.Windows.Forms.Label();
            this.lblChiTietNVKT = new System.Windows.Forms.Label();
            this.lblChiTietHeader = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnDuyetHangLoat = new System.Windows.Forms.Button();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlKPI.SuspendLayout();
            this.pnlKpiCardKHL.SuspendLayout();
            this.pnlKpiCardHL.SuspendLayout();
            this.pnlKpiCardCho.SuspendLayout();
            this.pnlKpiCardTong.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.pnlChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlChiTietInfo.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblNguoiDung);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1280, 64);
            this.pnlHeader.TabIndex = 4;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(16, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(460, 64);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "🔍  Kiểm Tra & Duyệt Chứng Từ";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNguoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.lblNguoiDung.Location = new System.Drawing.Point(904, 0);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(360, 64);
            this.lblNguoiDung.TabIndex = 1;
            this.lblNguoiDung.Text = "Chủ doanh nghiệp";
            this.lblNguoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlKPI
            // 
            this.pnlKPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlKPI.Controls.Add(this.pnlKpiCardKHL);
            this.pnlKPI.Controls.Add(this.pnlKpiCardHL);
            this.pnlKPI.Controls.Add(this.pnlKpiCardCho);
            this.pnlKPI.Controls.Add(this.pnlKpiCardTong);
            this.pnlKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKPI.Location = new System.Drawing.Point(0, 64);
            this.pnlKPI.Name = "pnlKPI";
            this.pnlKPI.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlKPI.Size = new System.Drawing.Size(1280, 90);
            this.pnlKPI.TabIndex = 3;
            // 
            // pnlKpiCardKHL
            // 
            this.pnlKpiCardKHL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlKpiCardKHL.Controls.Add(this.lblKpiKHLTitle);
            this.pnlKpiCardKHL.Controls.Add(this.lblKpiKhongHL);
            this.pnlKpiCardKHL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlKpiCardKHL.Location = new System.Drawing.Point(528, 10);
            this.pnlKpiCardKHL.Name = "pnlKpiCardKHL";
            this.pnlKpiCardKHL.Size = new System.Drawing.Size(160, 68);
            this.pnlKpiCardKHL.TabIndex = 0;
            // 
            // lblKpiKHLTitle
            // 
            this.lblKpiKHLTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiKHLTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiKHLTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.lblKpiKHLTitle.Location = new System.Drawing.Point(0, 0);
            this.lblKpiKHLTitle.Name = "lblKpiKHLTitle";
            this.lblKpiKHLTitle.Size = new System.Drawing.Size(160, 26);
            this.lblKpiKHLTitle.TabIndex = 0;
            this.lblKpiKHLTitle.Text = "KHÔNG HỢP LỆ";
            this.lblKpiKHLTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblKpiKhongHL
            // 
            this.lblKpiKhongHL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiKhongHL.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiKhongHL.ForeColor = System.Drawing.Color.White;
            this.lblKpiKhongHL.Location = new System.Drawing.Point(0, 0);
            this.lblKpiKhongHL.Name = "lblKpiKhongHL";
            this.lblKpiKhongHL.Size = new System.Drawing.Size(160, 68);
            this.lblKpiKhongHL.TabIndex = 1;
            this.lblKpiKhongHL.Text = "0";
            this.lblKpiKhongHL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlKpiCardHL
            // 
            this.pnlKpiCardHL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlKpiCardHL.Controls.Add(this.lblKpiHLTitle);
            this.pnlKpiCardHL.Controls.Add(this.lblKpiHopLe);
            this.pnlKpiCardHL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlKpiCardHL.Location = new System.Drawing.Point(356, 10);
            this.pnlKpiCardHL.Name = "pnlKpiCardHL";
            this.pnlKpiCardHL.Size = new System.Drawing.Size(160, 68);
            this.pnlKpiCardHL.TabIndex = 1;
            // 
            // lblKpiHLTitle
            // 
            this.lblKpiHLTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiHLTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiHLTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.lblKpiHLTitle.Location = new System.Drawing.Point(0, 0);
            this.lblKpiHLTitle.Name = "lblKpiHLTitle";
            this.lblKpiHLTitle.Size = new System.Drawing.Size(160, 26);
            this.lblKpiHLTitle.TabIndex = 0;
            this.lblKpiHLTitle.Text = "HỢP LỆ";
            this.lblKpiHLTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblKpiHopLe
            // 
            this.lblKpiHopLe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiHopLe.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiHopLe.ForeColor = System.Drawing.Color.White;
            this.lblKpiHopLe.Location = new System.Drawing.Point(0, 0);
            this.lblKpiHopLe.Name = "lblKpiHopLe";
            this.lblKpiHopLe.Size = new System.Drawing.Size(160, 68);
            this.lblKpiHopLe.TabIndex = 1;
            this.lblKpiHopLe.Text = "0";
            this.lblKpiHopLe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlKpiCardCho
            // 
            this.pnlKpiCardCho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.pnlKpiCardCho.Controls.Add(this.lblKpiChoTitle);
            this.pnlKpiCardCho.Controls.Add(this.lblKpiChoKT);
            this.pnlKpiCardCho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlKpiCardCho.Location = new System.Drawing.Point(184, 10);
            this.pnlKpiCardCho.Name = "pnlKpiCardCho";
            this.pnlKpiCardCho.Size = new System.Drawing.Size(160, 68);
            this.pnlKpiCardCho.TabIndex = 2;
            // 
            // lblKpiChoTitle
            // 
            this.lblKpiChoTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiChoTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiChoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.lblKpiChoTitle.Location = new System.Drawing.Point(0, 0);
            this.lblKpiChoTitle.Name = "lblKpiChoTitle";
            this.lblKpiChoTitle.Size = new System.Drawing.Size(160, 26);
            this.lblKpiChoTitle.TabIndex = 0;
            this.lblKpiChoTitle.Text = "CHỜ KIỂM TRA";
            this.lblKpiChoTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblKpiChoKT
            // 
            this.lblKpiChoKT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiChoKT.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiChoKT.ForeColor = System.Drawing.Color.White;
            this.lblKpiChoKT.Location = new System.Drawing.Point(0, 0);
            this.lblKpiChoKT.Name = "lblKpiChoKT";
            this.lblKpiChoKT.Size = new System.Drawing.Size(160, 68);
            this.lblKpiChoKT.TabIndex = 1;
            this.lblKpiChoKT.Text = "0";
            this.lblKpiChoKT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlKpiCardTong
            // 
            this.pnlKpiCardTong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlKpiCardTong.Controls.Add(this.lblKpiTongTitle);
            this.pnlKpiCardTong.Controls.Add(this.lblKpiTong);
            this.pnlKpiCardTong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlKpiCardTong.Location = new System.Drawing.Point(12, 10);
            this.pnlKpiCardTong.Name = "pnlKpiCardTong";
            this.pnlKpiCardTong.Size = new System.Drawing.Size(160, 68);
            this.pnlKpiCardTong.TabIndex = 3;
            // 
            // lblKpiTongTitle
            // 
            this.lblKpiTongTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiTongTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTongTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblKpiTongTitle.Location = new System.Drawing.Point(0, 0);
            this.lblKpiTongTitle.Name = "lblKpiTongTitle";
            this.lblKpiTongTitle.Size = new System.Drawing.Size(160, 26);
            this.lblKpiTongTitle.TabIndex = 0;
            this.lblKpiTongTitle.Text = "TỔNG CHỨNG TỪ";
            this.lblKpiTongTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblKpiTong
            // 
            this.lblKpiTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiTong.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiTong.ForeColor = System.Drawing.Color.White;
            this.lblKpiTong.Location = new System.Drawing.Point(0, 0);
            this.lblKpiTong.Name = "lblKpiTong";
            this.lblKpiTong.Size = new System.Drawing.Size(160, 68);
            this.lblKpiTong.TabIndex = 1;
            this.lblKpiTong.Text = "0";
            this.lblKpiTong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.pnlFilter.Controls.Add(this.lblSoLuong);
            this.pnlFilter.Controls.Add(this.btnLamMoi);
            this.pnlFilter.Controls.Add(this.cboLoai);
            this.pnlFilter.Controls.Add(this.lblFilterLoai);
            this.pnlFilter.Controls.Add(this.cboTrangThai);
            this.pnlFilter.Controls.Add(this.lblFilterTT);
            this.pnlFilter.Controls.Add(this.btnTimKiem);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.lblTimKiem);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 154);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlFilter.Size = new System.Drawing.Size(1280, 50);
            this.pnlFilter.TabIndex = 2;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.lblSoLuong.Location = new System.Drawing.Point(1128, 8);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(140, 34);
            this.lblSoLuong.TabIndex = 0;
            this.lblSoLuong.Text = "Tổng: 0 chứng từ";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(864, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 28);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "↺ Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLoai.Location = new System.Drawing.Point(630, 11);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(220, 28);
            this.cboLoai.TabIndex = 2;
            // 
            // lblFilterLoai
            // 
            this.lblFilterLoai.AutoSize = true;
            this.lblFilterLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblFilterLoai.Location = new System.Drawing.Point(592, 15);
            this.lblFilterLoai.Name = "lblFilterLoai";
            this.lblFilterLoai.Size = new System.Drawing.Size(40, 20);
            this.lblFilterLoai.TabIndex = 3;
            this.lblFilterLoai.Text = "Loại:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTrangThai.Location = new System.Drawing.Point(410, 11);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(168, 28);
            this.cboTrangThai.TabIndex = 4;
            // 
            // lblFilterTT
            // 
            this.lblFilterTT.AutoSize = true;
            this.lblFilterTT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterTT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblFilterTT.Location = new System.Drawing.Point(330, 15);
            this.lblFilterTT.Name = "lblFilterTT";
            this.lblFilterTT.Size = new System.Drawing.Size(78, 20);
            this.lblFilterTT.TabIndex = 5;
            this.lblFilterTT.Text = "Trạng thái:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(234, 10);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(80, 28);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(48, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(180, 27);
            this.txtSearch.TabIndex = 7;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblTimKiem.Location = new System.Drawing.Point(12, 15);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(37, 20);
            this.lblTimKiem.TabIndex = 8;
            this.lblTimKiem.Text = "Tìm:";
            // 
            // splitMain
            // 
            this.splitMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 204);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.splitMain.Panel1.Controls.Add(this.dgvDanhSach);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(8, 6, 4, 6);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.splitMain.Panel2.Controls.Add(this.pnlChiTiet);
            this.splitMain.Panel2.Padding = new System.Windows.Forms.Padding(4, 6, 8, 6);
            this.splitMain.Size = new System.Drawing.Size(1280, 464);
            this.splitMain.SplitterDistance = 1032;
            this.splitMain.SplitterWidth = 5;
            this.splitMain.TabIndex = 0;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhSach.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDanhSach.ColumnHeadersHeight = 34;
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDanhSach.Location = new System.Drawing.Point(8, 6);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 30;
            this.dgvDanhSach.Size = new System.Drawing.Size(1020, 452);
            this.dgvDanhSach.TabIndex = 0;
            // 
            // pnlChiTiet
            // 
            this.pnlChiTiet.BackColor = System.Drawing.Color.White;
            this.pnlChiTiet.Controls.Add(this.dgvChiTiet);
            this.pnlChiTiet.Controls.Add(this.lblChiTietDichVuHeader);
            this.pnlChiTiet.Controls.Add(this.pnlChiTietInfo);
            this.pnlChiTiet.Controls.Add(this.lblChiTietHeader);
            this.pnlChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChiTiet.Location = new System.Drawing.Point(4, 6);
            this.pnlChiTiet.Name = "pnlChiTiet";
            this.pnlChiTiet.Size = new System.Drawing.Size(231, 452);
            this.pnlChiTiet.TabIndex = 0;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ColumnHeadersHeight = 30;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.dgvChiTiet.Location = new System.Drawing.Point(0, 264);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 28;
            this.dgvChiTiet.Size = new System.Drawing.Size(231, 188);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // lblChiTietDichVuHeader
            // 
            this.lblChiTietDichVuHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.lblChiTietDichVuHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChiTietDichVuHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblChiTietDichVuHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.lblChiTietDichVuHeader.Location = new System.Drawing.Point(0, 236);
            this.lblChiTietDichVuHeader.Name = "lblChiTietDichVuHeader";
            this.lblChiTietDichVuHeader.Size = new System.Drawing.Size(231, 28);
            this.lblChiTietDichVuHeader.TabIndex = 1;
            this.lblChiTietDichVuHeader.Text = "  Dịch vụ trong đơn";
            this.lblChiTietDichVuHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlChiTietInfo
            // 
            this.pnlChiTietInfo.BackColor = System.Drawing.Color.White;
            this.pnlChiTietInfo.Controls.Add(this.lblLblMaCT);
            this.pnlChiTietInfo.Controls.Add(this.lblChiTietMaCT);
            this.pnlChiTietInfo.Controls.Add(this.lblLblSoCT);
            this.pnlChiTietInfo.Controls.Add(this.lblChiTietSoCT);
            this.pnlChiTietInfo.Controls.Add(this.lblLblLoai);
            this.pnlChiTietInfo.Controls.Add(this.lblChiTietLoai);
            this.pnlChiTietInfo.Controls.Add(this.lblLblNgayLap);
            this.pnlChiTietInfo.Controls.Add(this.lblChiTietNgayLap);
            this.pnlChiTietInfo.Controls.Add(this.lblLblMaDon);
            this.pnlChiTietInfo.Controls.Add(this.lblChiTietMaDon);
            this.pnlChiTietInfo.Controls.Add(this.lblLblTongTien);
            this.pnlChiTietInfo.Controls.Add(this.lblChiTietTongTien);
            this.pnlChiTietInfo.Controls.Add(this.lblLblTrangThai);
            this.pnlChiTietInfo.Controls.Add(this.lblChiTietTrangThai);
            this.pnlChiTietInfo.Controls.Add(this.lblLblNVKT);
            this.pnlChiTietInfo.Controls.Add(this.lblChiTietNVKT);
            this.pnlChiTietInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChiTietInfo.Location = new System.Drawing.Point(0, 36);
            this.pnlChiTietInfo.Name = "pnlChiTietInfo";
            this.pnlChiTietInfo.Padding = new System.Windows.Forms.Padding(12, 8, 12, 4);
            this.pnlChiTietInfo.Size = new System.Drawing.Size(231, 200);
            this.pnlChiTietInfo.TabIndex = 2;
            // 
            // lblLblMaCT
            // 
            this.lblLblMaCT.AutoSize = true;
            this.lblLblMaCT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLblMaCT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblLblMaCT.Location = new System.Drawing.Point(12, 10);
            this.lblLblMaCT.Name = "lblLblMaCT";
            this.lblLblMaCT.Size = new System.Drawing.Size(103, 20);
            this.lblLblMaCT.TabIndex = 0;
            this.lblLblMaCT.Text = "Mã chứng từ:";
            // 
            // lblChiTietMaCT
            // 
            this.lblChiTietMaCT.AutoSize = true;
            this.lblChiTietMaCT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblChiTietMaCT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.lblChiTietMaCT.Location = new System.Drawing.Point(115, 10);
            this.lblChiTietMaCT.Name = "lblChiTietMaCT";
            this.lblChiTietMaCT.Size = new System.Drawing.Size(0, 21);
            this.lblChiTietMaCT.TabIndex = 1;
            // 
            // lblLblSoCT
            // 
            this.lblLblSoCT.AutoSize = true;
            this.lblLblSoCT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLblSoCT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblLblSoCT.Location = new System.Drawing.Point(220, 10);
            this.lblLblSoCT.Name = "lblLblSoCT";
            this.lblLblSoCT.Size = new System.Drawing.Size(52, 20);
            this.lblLblSoCT.TabIndex = 2;
            this.lblLblSoCT.Text = "Số CT:";
            // 
            // lblChiTietSoCT
            // 
            this.lblChiTietSoCT.AutoSize = true;
            this.lblChiTietSoCT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblChiTietSoCT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblChiTietSoCT.Location = new System.Drawing.Point(265, 10);
            this.lblChiTietSoCT.Name = "lblChiTietSoCT";
            this.lblChiTietSoCT.Size = new System.Drawing.Size(0, 21);
            this.lblChiTietSoCT.TabIndex = 3;
            // 
            // lblLblLoai
            // 
            this.lblLblLoai.AutoSize = true;
            this.lblLblLoai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLblLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblLblLoai.Location = new System.Drawing.Point(12, 38);
            this.lblLblLoai.Name = "lblLblLoai";
            this.lblLblLoai.Size = new System.Drawing.Size(64, 20);
            this.lblLblLoai.TabIndex = 4;
            this.lblLblLoai.Text = "Loại CT:";
            // 
            // lblChiTietLoai
            // 
            this.lblChiTietLoai.AutoSize = true;
            this.lblChiTietLoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChiTietLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblChiTietLoai.Location = new System.Drawing.Point(75, 38);
            this.lblChiTietLoai.Name = "lblChiTietLoai";
            this.lblChiTietLoai.Size = new System.Drawing.Size(0, 20);
            this.lblChiTietLoai.TabIndex = 5;
            // 
            // lblLblNgayLap
            // 
            this.lblLblNgayLap.AutoSize = true;
            this.lblLblNgayLap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLblNgayLap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblLblNgayLap.Location = new System.Drawing.Point(220, 38);
            this.lblLblNgayLap.Name = "lblLblNgayLap";
            this.lblLblNgayLap.Size = new System.Drawing.Size(75, 20);
            this.lblLblNgayLap.TabIndex = 6;
            this.lblLblNgayLap.Text = "Ngày lập:";
            // 
            // lblChiTietNgayLap
            // 
            this.lblChiTietNgayLap.AutoSize = true;
            this.lblChiTietNgayLap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChiTietNgayLap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblChiTietNgayLap.Location = new System.Drawing.Point(282, 38);
            this.lblChiTietNgayLap.Name = "lblChiTietNgayLap";
            this.lblChiTietNgayLap.Size = new System.Drawing.Size(0, 20);
            this.lblChiTietNgayLap.TabIndex = 7;
            // 
            // lblLblMaDon
            // 
            this.lblLblMaDon.AutoSize = true;
            this.lblLblMaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLblMaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblLblMaDon.Location = new System.Drawing.Point(12, 66);
            this.lblLblMaDon.Name = "lblLblMaDon";
            this.lblLblMaDon.Size = new System.Drawing.Size(91, 20);
            this.lblLblMaDon.TabIndex = 8;
            this.lblLblMaDon.Text = "Mã đơn DV:";
            // 
            // lblChiTietMaDon
            // 
            this.lblChiTietMaDon.AutoSize = true;
            this.lblChiTietMaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblChiTietMaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.lblChiTietMaDon.Location = new System.Drawing.Point(95, 66);
            this.lblChiTietMaDon.Name = "lblChiTietMaDon";
            this.lblChiTietMaDon.Size = new System.Drawing.Size(0, 21);
            this.lblChiTietMaDon.TabIndex = 9;
            // 
            // lblLblTongTien
            // 
            this.lblLblTongTien.AutoSize = true;
            this.lblLblTongTien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblLblTongTien.Location = new System.Drawing.Point(220, 66);
            this.lblLblTongTien.Name = "lblLblTongTien";
            this.lblLblTongTien.Size = new System.Drawing.Size(80, 20);
            this.lblLblTongTien.TabIndex = 10;
            this.lblLblTongTien.Text = "Tổng tiền:";
            // 
            // lblChiTietTongTien
            // 
            this.lblChiTietTongTien.AutoSize = true;
            this.lblChiTietTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChiTietTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.lblChiTietTongTien.Location = new System.Drawing.Point(290, 66);
            this.lblChiTietTongTien.Name = "lblChiTietTongTien";
            this.lblChiTietTongTien.Size = new System.Drawing.Size(0, 23);
            this.lblChiTietTongTien.TabIndex = 11;
            // 
            // lblLblTrangThai
            // 
            this.lblLblTrangThai.AutoSize = true;
            this.lblLblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblLblTrangThai.Location = new System.Drawing.Point(12, 100);
            this.lblLblTrangThai.Name = "lblLblTrangThai";
            this.lblLblTrangThai.Size = new System.Drawing.Size(84, 20);
            this.lblLblTrangThai.TabIndex = 12;
            this.lblLblTrangThai.Text = "Trạng thái:";
            // 
            // lblChiTietTrangThai
            // 
            this.lblChiTietTrangThai.AutoSize = true;
            this.lblChiTietTrangThai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChiTietTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.lblChiTietTrangThai.Location = new System.Drawing.Point(90, 100);
            this.lblChiTietTrangThai.Name = "lblChiTietTrangThai";
            this.lblChiTietTrangThai.Size = new System.Drawing.Size(0, 25);
            this.lblChiTietTrangThai.TabIndex = 13;
            // 
            // lblLblNVKT
            // 
            this.lblLblNVKT.AutoSize = true;
            this.lblLblNVKT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLblNVKT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblLblNVKT.Location = new System.Drawing.Point(12, 134);
            this.lblLblNVKT.Name = "lblLblNVKT";
            this.lblLblNVKT.Size = new System.Drawing.Size(97, 20);
            this.lblLblNVKT.TabIndex = 14;
            this.lblLblNVKT.Text = "NV kiểm tra:";
            // 
            // lblChiTietNVKT
            // 
            this.lblChiTietNVKT.AutoSize = true;
            this.lblChiTietNVKT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChiTietNVKT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblChiTietNVKT.Location = new System.Drawing.Point(100, 134);
            this.lblChiTietNVKT.Name = "lblChiTietNVKT";
            this.lblChiTietNVKT.Size = new System.Drawing.Size(0, 20);
            this.lblChiTietNVKT.TabIndex = 15;
            // 
            // lblChiTietHeader
            // 
            this.lblChiTietHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.lblChiTietHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChiTietHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChiTietHeader.ForeColor = System.Drawing.Color.White;
            this.lblChiTietHeader.Location = new System.Drawing.Point(0, 0);
            this.lblChiTietHeader.Name = "lblChiTietHeader";
            this.lblChiTietHeader.Size = new System.Drawing.Size(231, 36);
            this.lblChiTietHeader.TabIndex = 3;
            this.lblChiTietHeader.Text = "  Chi tiết chứng từ";
            this.lblChiTietHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.pnlAction.Controls.Add(this.btnDuyetHangLoat);
            this.pnlAction.Controls.Add(this.btnTuChoi);
            this.pnlAction.Controls.Add(this.btnDuyet);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(0, 668);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlAction.Size = new System.Drawing.Size(1280, 92);
            this.pnlAction.TabIndex = 1;
            // 
            // btnDuyetHangLoat
            // 
            this.btnDuyetHangLoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(196)))));
            this.btnDuyetHangLoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuyetHangLoat.Enabled = false;
            this.btnDuyetHangLoat.FlatAppearance.BorderSize = 0;
            this.btnDuyetHangLoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuyetHangLoat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDuyetHangLoat.ForeColor = System.Drawing.Color.White;
            this.btnDuyetHangLoat.Location = new System.Drawing.Point(346, 10);
            this.btnDuyetHangLoat.Name = "btnDuyetHangLoat";
            this.btnDuyetHangLoat.Size = new System.Drawing.Size(200, 32);
            this.btnDuyetHangLoat.TabIndex = 0;
            this.btnDuyetHangLoat.Text = "⚡  DUYỆT HÀNG LOẠT (Chờ KT)";
            this.btnDuyetHangLoat.UseVisualStyleBackColor = false;
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnTuChoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTuChoi.Enabled = false;
            this.btnTuChoi.FlatAppearance.BorderSize = 0;
            this.btnTuChoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Location = new System.Drawing.Point(174, 10);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(160, 32);
            this.btnTuChoi.TabIndex = 1;
            this.btnTuChoi.Text = "✘  TỪ CHỐI (Không hợp lệ)";
            this.btnTuChoi.UseVisualStyleBackColor = false;
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnDuyet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuyet.Enabled = false;
            this.btnDuyet.FlatAppearance.BorderSize = 0;
            this.btnDuyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.Location = new System.Drawing.Point(12, 10);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(150, 32);
            this.btnDuyet.TabIndex = 2;
            this.btnDuyet.Text = "✔  DUYỆT (Hợp lệ)";
            this.btnDuyet.UseVisualStyleBackColor = false;
            // 
            // FrmKTChungTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlKPI);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1060, 660);
            this.Name = "FrmKTChungTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm Tra & Duyệt Chứng Từ — Đại Dương Xanh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmKTChungTu_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlKPI.ResumeLayout(false);
            this.pnlKpiCardKHL.ResumeLayout(false);
            this.pnlKpiCardHL.ResumeLayout(false);
            this.pnlKpiCardCho.ResumeLayout(false);
            this.pnlKpiCardTong.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.pnlChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlChiTietInfo.ResumeLayout(false);
            this.pnlChiTietInfo.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // ── Control declarations ─────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblNguoiDung;

        private System.Windows.Forms.Panel pnlKPI;
        private System.Windows.Forms.Panel pnlKpiCardTong;
        private System.Windows.Forms.Label lblKpiTongTitle;
        private System.Windows.Forms.Label lblKpiTong;
        private System.Windows.Forms.Panel pnlKpiCardCho;
        private System.Windows.Forms.Label lblKpiChoTitle;
        private System.Windows.Forms.Label lblKpiChoKT;
        private System.Windows.Forms.Panel pnlKpiCardHL;
        private System.Windows.Forms.Label lblKpiHLTitle;
        private System.Windows.Forms.Label lblKpiHopLe;
        private System.Windows.Forms.Panel pnlKpiCardKHL;
        private System.Windows.Forms.Label lblKpiKHLTitle;
        private System.Windows.Forms.Label lblKpiKhongHL;

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblFilterTT;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblFilterLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblSoLuong;

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.DataGridView dgvDanhSach;

        private System.Windows.Forms.Panel pnlChiTiet;
        private System.Windows.Forms.Label lblChiTietHeader;
        private System.Windows.Forms.Panel pnlChiTietInfo;
        private System.Windows.Forms.Label lblLblMaCT;
        private System.Windows.Forms.Label lblChiTietMaCT;
        private System.Windows.Forms.Label lblLblSoCT;
        private System.Windows.Forms.Label lblChiTietSoCT;
        private System.Windows.Forms.Label lblLblLoai;
        private System.Windows.Forms.Label lblChiTietLoai;
        private System.Windows.Forms.Label lblLblNgayLap;
        private System.Windows.Forms.Label lblChiTietNgayLap;
        private System.Windows.Forms.Label lblLblMaDon;
        private System.Windows.Forms.Label lblChiTietMaDon;
        private System.Windows.Forms.Label lblLblTongTien;
        private System.Windows.Forms.Label lblChiTietTongTien;
        private System.Windows.Forms.Label lblLblTrangThai;
        private System.Windows.Forms.Label lblChiTietTrangThai;
        private System.Windows.Forms.Label lblLblNVKT;
        private System.Windows.Forms.Label lblChiTietNVKT;
        private System.Windows.Forms.Label lblChiTietDichVuHeader;
        private System.Windows.Forms.DataGridView dgvChiTiet;

        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnDuyetHangLoat;
    }
}