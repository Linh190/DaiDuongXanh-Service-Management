using _03_VuNgocLinh;

namespace _03_VuNgocLinh.GUI.Pages.VanPhong
{
    partial class FrmDonHangVanPhong
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMoTaQuyen = new System.Windows.Forms.Label();
            this.pnlThongKe = new System.Windows.Forms.Panel();
            this.lblChoXacNhan = new System.Windows.Forms.Label();
            this.lblDaXacNhan = new System.Windows.Forms.Label();
            this.lblDangXuLy = new System.Windows.Forms.Label();
            this.lblHoanThanh = new System.Windows.Forms.Label();
            this.lblHuy = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblLoc = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTongDon = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.pnlChiTiet = new System.Windows.Forms.Panel();
            this.tabChiTiet = new System.Windows.Forms.TabControl();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.lblTongTienChiTiet = new System.Windows.Forms.Label();
            this.tabLichSu = new System.Windows.Forms.TabPage();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.pnlThongTinDon = new System.Windows.Forms.Panel();
            this.lblTieuDeChiTiet = new System.Windows.Forms.Label();
            this.lblMaDon = new System.Windows.Forms.Label();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.lblNgayDat = new System.Windows.Forms.Label();
            this.txtNgayDat = new System.Windows.Forms.TextBox();
            this.lblKhachHangChiTiet = new System.Windows.Forms.Label();
            this.txtKhachHang = new System.Windows.Forms.TextBox();
            this.lblNhanVienChiTiet = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.lblDiemDi = new System.Windows.Forms.Label();
            this.txtDiemDi = new System.Windows.Forms.TextBox();
            this.lblDiemDen = new System.Windows.Forms.Label();
            this.txtDiemDen = new System.Windows.Forms.TextBox();
            this.lblTrangThaiLabel = new System.Windows.Forms.Label();
            this.lblTrangThaiHienTai = new System.Windows.Forms.Label();
            this.lblNgayThucHien = new System.Windows.Forms.Label();
            this.dtpNgayThucHien = new System.Windows.Forms.DateTimePicker();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnCapNhatGhiChu = new System.Windows.Forms.Button();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnXuatDanhSach = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlThongKe.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.pnlChiTiet.SuspendLayout();
            this.tabChiTiet.SuspendLayout();
            this.tabDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.tabLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.pnlThongTinDon.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblMoTaQuyen);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1831, 64);
            this.pnlHeader.TabIndex = 4;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(16, 10);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(304, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "📋  Danh Sách Đơn Hàng";
            // 
            // lblMoTaQuyen
            // 
            this.lblMoTaQuyen.AutoSize = true;
            this.lblMoTaQuyen.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMoTaQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.lblMoTaQuyen.Location = new System.Drawing.Point(16, 38);
            this.lblMoTaQuyen.Name = "lblMoTaQuyen";
            this.lblMoTaQuyen.Size = new System.Drawing.Size(669, 20);
            this.lblMoTaQuyen.TabIndex = 1;
            this.lblMoTaQuyen.Text = "Quyền: Xem toàn bộ đơn  •  Cập nhật ghi chú & lịch thực hiện  •  Không được thêm " +
    "/ xóa / đổi dịch vụ";
            // 
            // pnlThongKe
            // 
            this.pnlThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.pnlThongKe.Controls.Add(this.lblChoXacNhan);
            this.pnlThongKe.Controls.Add(this.lblDaXacNhan);
            this.pnlThongKe.Controls.Add(this.lblDangXuLy);
            this.pnlThongKe.Controls.Add(this.lblHoanThanh);
            this.pnlThongKe.Controls.Add(this.lblHuy);
            this.pnlThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongKe.Location = new System.Drawing.Point(0, 64);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlThongKe.Size = new System.Drawing.Size(1831, 36);
            this.pnlThongKe.TabIndex = 3;
            // 
            // lblChoXacNhan
            // 
            this.lblChoXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChoXacNhan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChoXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblChoXacNhan.Location = new System.Drawing.Point(16, 4);
            this.lblChoXacNhan.Name = "lblChoXacNhan";
            this.lblChoXacNhan.Size = new System.Drawing.Size(180, 28);
            this.lblChoXacNhan.TabIndex = 0;
            this.lblChoXacNhan.Text = "Chờ xác nhận: 0";
            this.lblChoXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChoXacNhan.Click += new System.EventHandler(this.lblChoXacNhan_Click);
            // 
            // lblDaXacNhan
            // 
            this.lblDaXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDaXacNhan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDaXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblDaXacNhan.Location = new System.Drawing.Point(206, 4);
            this.lblDaXacNhan.Name = "lblDaXacNhan";
            this.lblDaXacNhan.Size = new System.Drawing.Size(180, 28);
            this.lblDaXacNhan.TabIndex = 1;
            this.lblDaXacNhan.Text = "Đã xác nhận: 0";
            this.lblDaXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDaXacNhan.Click += new System.EventHandler(this.lblDaXacNhan_Click);
            // 
            // lblDangXuLy
            // 
            this.lblDangXuLy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDangXuLy.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDangXuLy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(127)))), ((int)(((byte)(23)))));
            this.lblDangXuLy.Location = new System.Drawing.Point(396, 4);
            this.lblDangXuLy.Name = "lblDangXuLy";
            this.lblDangXuLy.Size = new System.Drawing.Size(180, 28);
            this.lblDangXuLy.TabIndex = 2;
            this.lblDangXuLy.Text = "Đang xử lý: 0";
            this.lblDangXuLy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDangXuLy.Click += new System.EventHandler(this.lblDangXuLy_Click);
            // 
            // lblHoanThanh
            // 
            this.lblHoanThanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHoanThanh.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHoanThanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblHoanThanh.Location = new System.Drawing.Point(586, 4);
            this.lblHoanThanh.Name = "lblHoanThanh";
            this.lblHoanThanh.Size = new System.Drawing.Size(180, 28);
            this.lblHoanThanh.TabIndex = 3;
            this.lblHoanThanh.Text = "Hoàn thành: 0";
            this.lblHoanThanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHoanThanh.Click += new System.EventHandler(this.lblHoanThanh_Click);
            // 
            // lblHuy
            // 
            this.lblHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHuy.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHuy.ForeColor = System.Drawing.Color.Gray;
            this.lblHuy.Location = new System.Drawing.Point(776, 4);
            this.lblHuy.Name = "lblHuy";
            this.lblHuy.Size = new System.Drawing.Size(180, 28);
            this.lblHuy.TabIndex = 4;
            this.lblHuy.Text = "Đã hủy: 0";
            this.lblHuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHuy.Click += new System.EventHandler(this.lblHuy_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.pnlFilter.Controls.Add(this.lblLoc);
            this.pnlFilter.Controls.Add(this.txtTimKiem);
            this.pnlFilter.Controls.Add(this.lblKhachHang);
            this.pnlFilter.Controls.Add(this.cboKhachHang);
            this.pnlFilter.Controls.Add(this.lblTrangThai);
            this.pnlFilter.Controls.Add(this.cboTrangThai);
            this.pnlFilter.Controls.Add(this.lblTuNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.lblDenNgay);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.btnTimKiem);
            this.pnlFilter.Controls.Add(this.btnReset);
            this.pnlFilter.Controls.Add(this.lblTongDon);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 100);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.pnlFilter.Size = new System.Drawing.Size(1831, 52);
            this.pnlFilter.TabIndex = 2;
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLoc.Location = new System.Drawing.Point(8, 16);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(78, 20);
            this.lblLoc.TabIndex = 0;
            this.lblLoc.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(80, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 27);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(290, 16);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(89, 20);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Location = new System.Drawing.Point(374, 12);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(180, 28);
            this.cboKhachHang.TabIndex = 3;
            this.cboKhachHang.SelectedIndexChanged += new System.EventHandler(this.cboKhachHang_SelectedIndexChanged);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(564, 16);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(78, 20);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location = new System.Drawing.Point(642, 12);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(148, 28);
            this.cboTrangThai.TabIndex = 5;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(800, 16);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(65, 20);
            this.lblTuNgay.TabIndex = 6;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Checked = false;
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(864, 12);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.ShowCheckBox = true;
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 27);
            this.dtpTuNgay.TabIndex = 7;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(994, 16);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(39, 20);
            this.lblDenNgay.TabIndex = 8;
            this.lblDenNgay.Text = "Đến:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Checked = false;
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(1034, 12);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.ShowCheckBox = true;
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 27);
            this.dtpDenNgay.TabIndex = 9;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(1164, 10);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(80, 30);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.btnReset.Location = new System.Drawing.Point(1254, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(72, 30);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "↺ Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTongDon
            // 
            this.lblTongDon.AutoSize = true;
            this.lblTongDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.lblTongDon.Location = new System.Drawing.Point(1336, 16);
            this.lblTongDon.Name = "lblTongDon";
            this.lblTongDon.Size = new System.Drawing.Size(93, 20);
            this.lblTongDon.TabIndex = 12;
            this.lblTongDon.Text = "Tổng: 0 đơn";
            // 
            // splitMain
            // 
            this.splitMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 152);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.dgvKetQua);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.pnlChiTiet);
            this.splitMain.Size = new System.Drawing.Size(1831, 551);
            this.splitMain.SplitterDistance = 1477;
            this.splitMain.TabIndex = 0;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKetQua.ColumnHeadersHeight = 29;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(0, 0);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(1477, 551);
            this.dgvKetQua.TabIndex = 0;
            this.dgvKetQua.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKetQua_CellFormatting);
            // 
            // pnlChiTiet
            // 
            this.pnlChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlChiTiet.Controls.Add(this.tabChiTiet);
            this.pnlChiTiet.Controls.Add(this.pnlThongTinDon);
            this.pnlChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChiTiet.Location = new System.Drawing.Point(0, 0);
            this.pnlChiTiet.Name = "pnlChiTiet";
            this.pnlChiTiet.Size = new System.Drawing.Size(350, 551);
            this.pnlChiTiet.TabIndex = 0;
            // 
            // tabChiTiet
            // 
            this.tabChiTiet.Controls.Add(this.tabDichVu);
            this.tabChiTiet.Controls.Add(this.tabLichSu);
            this.tabChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabChiTiet.Location = new System.Drawing.Point(0, 395);
            this.tabChiTiet.Name = "tabChiTiet";
            this.tabChiTiet.SelectedIndex = 0;
            this.tabChiTiet.Size = new System.Drawing.Size(350, 156);
            this.tabChiTiet.TabIndex = 0;
            // 
            // tabDichVu
            // 
            this.tabDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.tabDichVu.Controls.Add(this.dgvChiTiet);
            this.tabDichVu.Controls.Add(this.lblTongTienChiTiet);
            this.tabDichVu.Location = new System.Drawing.Point(4, 29);
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.Size = new System.Drawing.Size(342, 123);
            this.tabDichVu.TabIndex = 0;
            this.tabDichVu.Text = "  📦 Dịch vụ trong đơn  ";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.ColumnHeadersHeight = 29;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(0, 0);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(342, 95);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // lblTongTienChiTiet
            // 
            this.lblTongTienChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.lblTongTienChiTiet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTongTienChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTongTienChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.lblTongTienChiTiet.Location = new System.Drawing.Point(0, 95);
            this.lblTongTienChiTiet.Name = "lblTongTienChiTiet";
            this.lblTongTienChiTiet.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblTongTienChiTiet.Size = new System.Drawing.Size(342, 28);
            this.lblTongTienChiTiet.TabIndex = 1;
            this.lblTongTienChiTiet.Text = "Tổng tiền: --";
            this.lblTongTienChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabLichSu
            // 
            this.tabLichSu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.tabLichSu.Controls.Add(this.dgvLichSu);
            this.tabLichSu.Location = new System.Drawing.Point(4, 29);
            this.tabLichSu.Name = "tabLichSu";
            this.tabLichSu.Size = new System.Drawing.Size(18, 0);
            this.tabLichSu.TabIndex = 1;
            this.tabLichSu.Text = "  🕐 Lịch sử trạng thái  ";
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLichSu.ColumnHeadersHeight = 29;
            this.dgvLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSu.Location = new System.Drawing.Point(0, 0);
            this.dgvLichSu.MultiSelect = false;
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.RowHeadersWidth = 51;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.Size = new System.Drawing.Size(18, 0);
            this.dgvLichSu.TabIndex = 0;
            // 
            // pnlThongTinDon
            // 
            this.pnlThongTinDon.BackColor = System.Drawing.Color.White;
            this.pnlThongTinDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTinDon.Controls.Add(this.lblTieuDeChiTiet);
            this.pnlThongTinDon.Controls.Add(this.lblMaDon);
            this.pnlThongTinDon.Controls.Add(this.txtMaDon);
            this.pnlThongTinDon.Controls.Add(this.lblNgayDat);
            this.pnlThongTinDon.Controls.Add(this.txtNgayDat);
            this.pnlThongTinDon.Controls.Add(this.lblKhachHangChiTiet);
            this.pnlThongTinDon.Controls.Add(this.txtKhachHang);
            this.pnlThongTinDon.Controls.Add(this.lblNhanVienChiTiet);
            this.pnlThongTinDon.Controls.Add(this.txtNhanVien);
            this.pnlThongTinDon.Controls.Add(this.lblDiemDi);
            this.pnlThongTinDon.Controls.Add(this.txtDiemDi);
            this.pnlThongTinDon.Controls.Add(this.lblDiemDen);
            this.pnlThongTinDon.Controls.Add(this.txtDiemDen);
            this.pnlThongTinDon.Controls.Add(this.lblTrangThaiLabel);
            this.pnlThongTinDon.Controls.Add(this.lblTrangThaiHienTai);
            this.pnlThongTinDon.Controls.Add(this.lblNgayThucHien);
            this.pnlThongTinDon.Controls.Add(this.dtpNgayThucHien);
            this.pnlThongTinDon.Controls.Add(this.lblGhiChu);
            this.pnlThongTinDon.Controls.Add(this.txtGhiChu);
            this.pnlThongTinDon.Controls.Add(this.btnCapNhatGhiChu);
            this.pnlThongTinDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongTinDon.Location = new System.Drawing.Point(0, 0);
            this.pnlThongTinDon.Name = "pnlThongTinDon";
            this.pnlThongTinDon.Padding = new System.Windows.Forms.Padding(12);
            this.pnlThongTinDon.Size = new System.Drawing.Size(350, 395);
            this.pnlThongTinDon.TabIndex = 1;
            // 
            // lblTieuDeChiTiet
            // 
            this.lblTieuDeChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.lblTieuDeChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.lblTieuDeChiTiet.Location = new System.Drawing.Point(12, 12);
            this.lblTieuDeChiTiet.Name = "lblTieuDeChiTiet";
            this.lblTieuDeChiTiet.Size = new System.Drawing.Size(324, 32);
            this.lblTieuDeChiTiet.TabIndex = 0;
            this.lblTieuDeChiTiet.Text = "  Thông tin đơn hàng";
            this.lblTieuDeChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaDon
            // 
            this.lblMaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblMaDon.Location = new System.Drawing.Point(12, 44);
            this.lblMaDon.Name = "lblMaDon";
            this.lblMaDon.Size = new System.Drawing.Size(120, 22);
            this.lblMaDon.TabIndex = 1;
            this.lblMaDon.Text = "Mã đơn:";
            this.lblMaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaDon
            // 
            this.txtMaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.txtMaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaDon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaDon.Location = new System.Drawing.Point(135, 44);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.ReadOnly = true;
            this.txtMaDon.Size = new System.Drawing.Size(198, 27);
            this.txtMaDon.TabIndex = 2;
            // 
            // lblNgayDat
            // 
            this.lblNgayDat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNgayDat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblNgayDat.Location = new System.Drawing.Point(12, 74);
            this.lblNgayDat.Name = "lblNgayDat";
            this.lblNgayDat.Size = new System.Drawing.Size(120, 22);
            this.lblNgayDat.TabIndex = 3;
            this.lblNgayDat.Text = "Ngày đặt:";
            this.lblNgayDat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNgayDat
            // 
            this.txtNgayDat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.txtNgayDat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayDat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNgayDat.Location = new System.Drawing.Point(135, 74);
            this.txtNgayDat.Name = "txtNgayDat";
            this.txtNgayDat.ReadOnly = true;
            this.txtNgayDat.Size = new System.Drawing.Size(198, 27);
            this.txtNgayDat.TabIndex = 4;
            // 
            // lblKhachHangChiTiet
            // 
            this.lblKhachHangChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKhachHangChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblKhachHangChiTiet.Location = new System.Drawing.Point(12, 104);
            this.lblKhachHangChiTiet.Name = "lblKhachHangChiTiet";
            this.lblKhachHangChiTiet.Size = new System.Drawing.Size(120, 22);
            this.lblKhachHangChiTiet.TabIndex = 5;
            this.lblKhachHangChiTiet.Text = "Khách hàng:";
            this.lblKhachHangChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKhachHang
            // 
            this.txtKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.txtKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKhachHang.Location = new System.Drawing.Point(135, 104);
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.ReadOnly = true;
            this.txtKhachHang.Size = new System.Drawing.Size(198, 27);
            this.txtKhachHang.TabIndex = 6;
            // 
            // lblNhanVienChiTiet
            // 
            this.lblNhanVienChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNhanVienChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblNhanVienChiTiet.Location = new System.Drawing.Point(12, 134);
            this.lblNhanVienChiTiet.Name = "lblNhanVienChiTiet";
            this.lblNhanVienChiTiet.Size = new System.Drawing.Size(120, 22);
            this.lblNhanVienChiTiet.TabIndex = 7;
            this.lblNhanVienChiTiet.Text = "NV phụ trách:";
            this.lblNhanVienChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.txtNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNhanVien.Location = new System.Drawing.Point(135, 134);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.ReadOnly = true;
            this.txtNhanVien.Size = new System.Drawing.Size(198, 27);
            this.txtNhanVien.TabIndex = 8;
            // 
            // lblDiemDi
            // 
            this.lblDiemDi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiemDi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblDiemDi.Location = new System.Drawing.Point(12, 164);
            this.lblDiemDi.Name = "lblDiemDi";
            this.lblDiemDi.Size = new System.Drawing.Size(120, 22);
            this.lblDiemDi.TabIndex = 9;
            this.lblDiemDi.Text = "Điểm đi:";
            this.lblDiemDi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiemDi
            // 
            this.txtDiemDi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.txtDiemDi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiemDi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiemDi.Location = new System.Drawing.Point(135, 164);
            this.txtDiemDi.Name = "txtDiemDi";
            this.txtDiemDi.ReadOnly = true;
            this.txtDiemDi.Size = new System.Drawing.Size(198, 27);
            this.txtDiemDi.TabIndex = 10;
            // 
            // lblDiemDen
            // 
            this.lblDiemDen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiemDen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblDiemDen.Location = new System.Drawing.Point(12, 194);
            this.lblDiemDen.Name = "lblDiemDen";
            this.lblDiemDen.Size = new System.Drawing.Size(120, 22);
            this.lblDiemDen.TabIndex = 11;
            this.lblDiemDen.Text = "Điểm đến:";
            this.lblDiemDen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiemDen
            // 
            this.txtDiemDen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.txtDiemDen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiemDen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiemDen.Location = new System.Drawing.Point(135, 194);
            this.txtDiemDen.Name = "txtDiemDen";
            this.txtDiemDen.ReadOnly = true;
            this.txtDiemDen.Size = new System.Drawing.Size(198, 27);
            this.txtDiemDen.TabIndex = 12;
            // 
            // lblTrangThaiLabel
            // 
            this.lblTrangThaiLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblTrangThaiLabel.Location = new System.Drawing.Point(12, 224);
            this.lblTrangThaiLabel.Name = "lblTrangThaiLabel";
            this.lblTrangThaiLabel.Size = new System.Drawing.Size(120, 22);
            this.lblTrangThaiLabel.TabIndex = 13;
            this.lblTrangThaiLabel.Text = "Trạng thái:";
            this.lblTrangThaiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrangThaiHienTai
            // 
            this.lblTrangThaiHienTai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiHienTai.Location = new System.Drawing.Point(135, 225);
            this.lblTrangThaiHienTai.Name = "lblTrangThaiHienTai";
            this.lblTrangThaiHienTai.Size = new System.Drawing.Size(198, 22);
            this.lblTrangThaiHienTai.TabIndex = 14;
            this.lblTrangThaiHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgayThucHien
            // 
            this.lblNgayThucHien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNgayThucHien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblNgayThucHien.Location = new System.Drawing.Point(12, 254);
            this.lblNgayThucHien.Name = "lblNgayThucHien";
            this.lblNgayThucHien.Size = new System.Drawing.Size(120, 22);
            this.lblNgayThucHien.TabIndex = 15;
            this.lblNgayThucHien.Text = "Ngày thực hiện:";
            this.lblNgayThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayThucHien
            // 
            this.dtpNgayThucHien.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThucHien.Location = new System.Drawing.Point(135, 254);
            this.dtpNgayThucHien.Name = "dtpNgayThucHien";
            this.dtpNgayThucHien.Size = new System.Drawing.Size(198, 27);
            this.dtpNgayThucHien.TabIndex = 16;
            this.dtpNgayThucHien.ValueChanged += new System.EventHandler(this.dtpNgayThucHien_ValueChanged);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblGhiChu.Location = new System.Drawing.Point(12, 284);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(120, 22);
            this.lblGhiChu.TabIndex = 17;
            this.lblGhiChu.Text = "Ghi chú:";
            this.lblGhiChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGhiChu.Location = new System.Drawing.Point(135, 284);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(198, 68);
            this.txtGhiChu.TabIndex = 18;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            // 
            // btnCapNhatGhiChu
            // 
            this.btnCapNhatGhiChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCapNhatGhiChu.Enabled = false;
            this.btnCapNhatGhiChu.FlatAppearance.BorderSize = 0;
            this.btnCapNhatGhiChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCapNhatGhiChu.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatGhiChu.Location = new System.Drawing.Point(53, 357);
            this.btnCapNhatGhiChu.Name = "btnCapNhatGhiChu";
            this.btnCapNhatGhiChu.Size = new System.Drawing.Size(238, 32);
            this.btnCapNhatGhiChu.TabIndex = 19;
            this.btnCapNhatGhiChu.Text = "💾  Lưu ghi chú & lịch thực hiện";
            this.btnCapNhatGhiChu.UseVisualStyleBackColor = false;
            this.btnCapNhatGhiChu.Click += new System.EventHandler(this.btnCapNhatGhiChu_Click);
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.pnlAction.Controls.Add(this.btnXuatDanhSach);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(0, 703);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlAction.Size = new System.Drawing.Size(1831, 70);
            this.pnlAction.TabIndex = 1;
            // 
            // btnXuatDanhSach
            // 
            this.btnXuatDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnXuatDanhSach.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXuatDanhSach.FlatAppearance.BorderSize = 0;
            this.btnXuatDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatDanhSach.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatDanhSach.ForeColor = System.Drawing.Color.White;
            this.btnXuatDanhSach.Location = new System.Drawing.Point(1578, 6);
            this.btnXuatDanhSach.Name = "btnXuatDanhSach";
            this.btnXuatDanhSach.Size = new System.Drawing.Size(245, 58);
            this.btnXuatDanhSach.TabIndex = 0;
            this.btnXuatDanhSach.Text = "📤 Xuất danh sách CSV";
            this.btnXuatDanhSach.UseVisualStyleBackColor = false;
            this.btnXuatDanhSach.Click += new System.EventHandler(this.btnXuatDanhSach_Click);
            // 
            // FrmDonHangVanPhong
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1831, 773);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlThongKe);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmDonHangVanPhong";
            this.Text = "Quản lý Đơn Hàng — Nhân viên Văn phòng";
            this.Load += new System.EventHandler(this.FrmDonHangVanPhong_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlThongKe.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.pnlChiTiet.ResumeLayout(false);
            this.tabChiTiet.ResumeLayout(false);
            this.tabDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.tabLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.pnlThongTinDon.ResumeLayout(false);
            this.pnlThongTinDon.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // ── Controls declarations ─────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTaQuyen;

        private System.Windows.Forms.Panel pnlThongKe;
        private System.Windows.Forms.Label lblChoXacNhan;
        private System.Windows.Forms.Label lblDaXacNhan;
        private System.Windows.Forms.Label lblDangXuLy;
        private System.Windows.Forms.Label lblHoanThanh;
        private System.Windows.Forms.Label lblHuy;

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTongDon;

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.DataGridView dgvKetQua;

        private System.Windows.Forms.Panel pnlChiTiet;
        private System.Windows.Forms.Panel pnlThongTinDon;
        private System.Windows.Forms.Label lblTieuDeChiTiet;

        private System.Windows.Forms.Label lblMaDon;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label lblNgayDat;
        private System.Windows.Forms.TextBox txtNgayDat;
        private System.Windows.Forms.Label lblNgayThucHien;
        private System.Windows.Forms.DateTimePicker dtpNgayThucHien;
        private System.Windows.Forms.Label lblKhachHangChiTiet;
        private System.Windows.Forms.TextBox txtKhachHang;
        private System.Windows.Forms.Label lblNhanVienChiTiet;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.Label lblDiemDi;
        private System.Windows.Forms.TextBox txtDiemDi;
        private System.Windows.Forms.Label lblDiemDen;
        private System.Windows.Forms.TextBox txtDiemDen;
        private System.Windows.Forms.Label lblTrangThaiLabel;
        private System.Windows.Forms.Label lblTrangThaiHienTai;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnCapNhatGhiChu;

        private System.Windows.Forms.TabControl tabChiTiet;
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblTongTienChiTiet;
        private System.Windows.Forms.TabPage tabLichSu;
        private System.Windows.Forms.DataGridView dgvLichSu;

        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Button btnXuatDanhSach;
    }
}