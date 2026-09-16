namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    partial class FrmSaoLuuPhucHoi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSaoLuuPhucHoi = new System.Windows.Forms.TabPage();
            this.lvDanhSachBackup = new System.Windows.Forms.ListView();
            this.colTenFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colThoiGian = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDungLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDanhSachBackup = new System.Windows.Forms.Label();
            this.btnXoaBackup = new System.Windows.Forms.Button();
            this.btnMoThuMuc = new System.Windows.Forms.Button();
            this.btnLamMoiDanhSach = new System.Windows.Forms.Button();
            this.groupBoxPhucHoi = new System.Windows.Forms.GroupBox();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.btnChonFileRestore = new System.Windows.Forms.Button();
            this.txtFileRestore = new System.Windows.Forms.TextBox();
            this.lblFileRestore = new System.Windows.Forms.Label();
            this.groupBoxSaoLuu = new System.Windows.Forms.GroupBox();
            this.btnSaoLuuNgay = new System.Windows.Forms.Button();
            this.btnChonThuMuc = new System.Windows.Forms.Button();
            this.txtThuMucBackup = new System.Windows.Forms.TextBox();
            this.lblThuMucBackup = new System.Windows.Forms.Label();
            this.tabLichTuDong = new System.Windows.Forms.TabPage();
            this.lblGhiChuLich = new System.Windows.Forms.Label();
            this.chkBatLichTuDong = new System.Windows.Forms.CheckBox();
            this.lblDinhKy = new System.Windows.Forms.Label();
            this.cboDinhKy = new System.Windows.Forms.ComboBox();
            this.lblGioChay = new System.Windows.Forms.Label();
            this.dtpGioChay = new System.Windows.Forms.DateTimePicker();
            this.btnLuuLich = new System.Windows.Forms.Button();
            this.lblTrangThaiLich = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblDatabaseHienTai = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSaoLuuPhucHoi.SuspendLayout();
            this.groupBoxPhucHoi.SuspendLayout();
            this.groupBoxSaoLuu.SuspendLayout();
            this.tabLichTuDong.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSaoLuuPhucHoi);
            this.tabControl1.Controls.Add(this.tabLichTuDong);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 90);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 470);
            this.tabControl1.TabIndex = 1;
            // 
            // tabSaoLuuPhucHoi
            // 
            this.tabSaoLuuPhucHoi.BackColor = System.Drawing.Color.White;
            this.tabSaoLuuPhucHoi.Controls.Add(this.lvDanhSachBackup);
            this.tabSaoLuuPhucHoi.Controls.Add(this.lblDanhSachBackup);
            this.tabSaoLuuPhucHoi.Controls.Add(this.btnXoaBackup);
            this.tabSaoLuuPhucHoi.Controls.Add(this.btnMoThuMuc);
            this.tabSaoLuuPhucHoi.Controls.Add(this.btnLamMoiDanhSach);
            this.tabSaoLuuPhucHoi.Controls.Add(this.groupBoxPhucHoi);
            this.tabSaoLuuPhucHoi.Controls.Add(this.groupBoxSaoLuu);
            this.tabSaoLuuPhucHoi.Location = new System.Drawing.Point(4, 32);
            this.tabSaoLuuPhucHoi.Name = "tabSaoLuuPhucHoi";
            this.tabSaoLuuPhucHoi.Padding = new System.Windows.Forms.Padding(12);
            this.tabSaoLuuPhucHoi.Size = new System.Drawing.Size(692, 434);
            this.tabSaoLuuPhucHoi.TabIndex = 0;
            this.tabSaoLuuPhucHoi.Text = "Sao lưu / Phục hồi";
            // 
            // lvDanhSachBackup
            // 
            this.lvDanhSachBackup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTenFile,
            this.colThoiGian,
            this.colDungLuong});
            this.lvDanhSachBackup.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lvDanhSachBackup.FullRowSelect = true;
            this.lvDanhSachBackup.GridLines = true;
            this.lvDanhSachBackup.HideSelection = false;
            this.lvDanhSachBackup.Location = new System.Drawing.Point(15, 254);
            this.lvDanhSachBackup.MultiSelect = false;
            this.lvDanhSachBackup.Name = "lvDanhSachBackup";
            this.lvDanhSachBackup.Size = new System.Drawing.Size(660, 130);
            this.lvDanhSachBackup.TabIndex = 3;
            this.lvDanhSachBackup.UseCompatibleStateImageBehavior = false;
            this.lvDanhSachBackup.View = System.Windows.Forms.View.Details;
            this.lvDanhSachBackup.SelectedIndexChanged += new System.EventHandler(this.lvDanhSachBackup_SelectedIndexChanged);
            // 
            // colTenFile
            // 
            this.colTenFile.Text = "Tên file";
            this.colTenFile.Width = 320;
            // 
            // colThoiGian
            // 
            this.colThoiGian.Text = "Thời gian tạo";
            this.colThoiGian.Width = 180;
            // 
            // colDungLuong
            // 
            this.colDungLuong.Text = "Dung lượng";
            this.colDungLuong.Width = 120;
            // 
            // lblDanhSachBackup
            // 
            this.lblDanhSachBackup.AutoSize = true;
            this.lblDanhSachBackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDanhSachBackup.Location = new System.Drawing.Point(17, 228);
            this.lblDanhSachBackup.Name = "lblDanhSachBackup";
            this.lblDanhSachBackup.Size = new System.Drawing.Size(246, 23);
            this.lblDanhSachBackup.TabIndex = 2;
            this.lblDanhSachBackup.Text = "Danh sách bản backup đã tạo";
            // 
            // btnXoaBackup
            // 
            this.btnXoaBackup.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoaBackup.FlatAppearance.BorderSize = 0;
            this.btnXoaBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnXoaBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaBackup.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnXoaBackup.ForeColor = System.Drawing.Color.White;
            this.btnXoaBackup.Location = new System.Drawing.Point(545, 392);
            this.btnXoaBackup.Name = "btnXoaBackup";
            this.btnXoaBackup.Size = new System.Drawing.Size(130, 32);
            this.btnXoaBackup.TabIndex = 6;
            this.btnXoaBackup.Text = "Xóa file đã chọn";
            this.btnXoaBackup.UseVisualStyleBackColor = false;
            this.btnXoaBackup.Click += new System.EventHandler(this.btnXoaBackup_Click);
            // 
            // btnMoThuMuc
            // 
            this.btnMoThuMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.btnMoThuMuc.FlatAppearance.BorderSize = 0;
            this.btnMoThuMuc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMoThuMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoThuMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnMoThuMuc.Location = new System.Drawing.Point(133, 392);
            this.btnMoThuMuc.Name = "btnMoThuMuc";
            this.btnMoThuMuc.Size = new System.Drawing.Size(130, 32);
            this.btnMoThuMuc.TabIndex = 5;
            this.btnMoThuMuc.Text = "Mở thư mục";
            this.btnMoThuMuc.UseVisualStyleBackColor = false;
            this.btnMoThuMuc.Click += new System.EventHandler(this.btnMoThuMuc_Click);
            // 
            // btnLamMoiDanhSach
            // 
            this.btnLamMoiDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.btnLamMoiDanhSach.FlatAppearance.BorderSize = 0;
            this.btnLamMoiDanhSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLamMoiDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLamMoiDanhSach.Location = new System.Drawing.Point(15, 392);
            this.btnLamMoiDanhSach.Name = "btnLamMoiDanhSach";
            this.btnLamMoiDanhSach.Size = new System.Drawing.Size(110, 32);
            this.btnLamMoiDanhSach.TabIndex = 4;
            this.btnLamMoiDanhSach.Text = "Làm mới";
            this.btnLamMoiDanhSach.UseVisualStyleBackColor = false;
            this.btnLamMoiDanhSach.Click += new System.EventHandler(this.btnLamMoiDanhSach_Click);
            // 
            // groupBoxPhucHoi
            // 
            this.groupBoxPhucHoi.Controls.Add(this.btnPhucHoi);
            this.groupBoxPhucHoi.Controls.Add(this.btnChonFileRestore);
            this.groupBoxPhucHoi.Controls.Add(this.txtFileRestore);
            this.groupBoxPhucHoi.Controls.Add(this.lblFileRestore);
            this.groupBoxPhucHoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxPhucHoi.Location = new System.Drawing.Point(15, 120);
            this.groupBoxPhucHoi.Name = "groupBoxPhucHoi";
            this.groupBoxPhucHoi.Size = new System.Drawing.Size(660, 95);
            this.groupBoxPhucHoi.TabIndex = 1;
            this.groupBoxPhucHoi.TabStop = false;
            this.groupBoxPhucHoi.Text = "Phục hồi dữ liệu (Restore)";
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.BackColor = System.Drawing.Color.Firebrick;
            this.btnPhucHoi.FlatAppearance.BorderSize = 0;
            this.btnPhucHoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnPhucHoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhucHoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhucHoi.ForeColor = System.Drawing.Color.White;
            this.btnPhucHoi.Location = new System.Drawing.Point(566, 29);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(80, 30);
            this.btnPhucHoi.TabIndex = 3;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.UseVisualStyleBackColor = false;
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // btnChonFileRestore
            // 
            this.btnChonFileRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.btnChonFileRestore.FlatAppearance.BorderSize = 0;
            this.btnChonFileRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnChonFileRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonFileRestore.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnChonFileRestore.Location = new System.Drawing.Point(518, 29);
            this.btnChonFileRestore.Name = "btnChonFileRestore";
            this.btnChonFileRestore.Size = new System.Drawing.Size(36, 30);
            this.btnChonFileRestore.TabIndex = 2;
            this.btnChonFileRestore.Text = "...";
            this.btnChonFileRestore.UseVisualStyleBackColor = false;
            this.btnChonFileRestore.Click += new System.EventHandler(this.btnChonFileRestore_Click);
            // 
            // txtFileRestore
            // 
            this.txtFileRestore.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFileRestore.Location = new System.Drawing.Point(130, 31);
            this.txtFileRestore.Name = "txtFileRestore";
            this.txtFileRestore.ReadOnly = true;
            this.txtFileRestore.Size = new System.Drawing.Size(380, 29);
            this.txtFileRestore.TabIndex = 1;
            // 
            // lblFileRestore
            // 
            this.lblFileRestore.AutoSize = true;
            this.lblFileRestore.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFileRestore.Location = new System.Drawing.Point(15, 35);
            this.lblFileRestore.Name = "lblFileRestore";
            this.lblFileRestore.Size = new System.Drawing.Size(91, 21);
            this.lblFileRestore.TabIndex = 0;
            this.lblFileRestore.Text = "File backup:";
            // 
            // groupBoxSaoLuu
            // 
            this.groupBoxSaoLuu.Controls.Add(this.btnSaoLuuNgay);
            this.groupBoxSaoLuu.Controls.Add(this.btnChonThuMuc);
            this.groupBoxSaoLuu.Controls.Add(this.txtThuMucBackup);
            this.groupBoxSaoLuu.Controls.Add(this.lblThuMucBackup);
            this.groupBoxSaoLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxSaoLuu.Location = new System.Drawing.Point(15, 15);
            this.groupBoxSaoLuu.Name = "groupBoxSaoLuu";
            this.groupBoxSaoLuu.Size = new System.Drawing.Size(660, 95);
            this.groupBoxSaoLuu.TabIndex = 0;
            this.groupBoxSaoLuu.TabStop = false;
            this.groupBoxSaoLuu.Text = "Sao lưu dữ liệu (Backup)";
            // 
            // btnSaoLuuNgay
            // 
            this.btnSaoLuuNgay.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSaoLuuNgay.FlatAppearance.BorderSize = 0;
            this.btnSaoLuuNgay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSaoLuuNgay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaoLuuNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaoLuuNgay.ForeColor = System.Drawing.Color.White;
            this.btnSaoLuuNgay.Location = new System.Drawing.Point(566, 29);
            this.btnSaoLuuNgay.Name = "btnSaoLuuNgay";
            this.btnSaoLuuNgay.Size = new System.Drawing.Size(80, 30);
            this.btnSaoLuuNgay.TabIndex = 3;
            this.btnSaoLuuNgay.Text = "Sao lưu";
            this.btnSaoLuuNgay.UseVisualStyleBackColor = false;
            this.btnSaoLuuNgay.Click += new System.EventHandler(this.btnSaoLuuNgay_Click);
            // 
            // btnChonThuMuc
            // 
            this.btnChonThuMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.btnChonThuMuc.FlatAppearance.BorderSize = 0;
            this.btnChonThuMuc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnChonThuMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonThuMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnChonThuMuc.Location = new System.Drawing.Point(518, 29);
            this.btnChonThuMuc.Name = "btnChonThuMuc";
            this.btnChonThuMuc.Size = new System.Drawing.Size(36, 30);
            this.btnChonThuMuc.TabIndex = 2;
            this.btnChonThuMuc.Text = "...";
            this.btnChonThuMuc.UseVisualStyleBackColor = false;
            this.btnChonThuMuc.Click += new System.EventHandler(this.btnChonThuMuc_Click);
            // 
            // txtThuMucBackup
            // 
            this.txtThuMucBackup.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtThuMucBackup.Location = new System.Drawing.Point(130, 31);
            this.txtThuMucBackup.Name = "txtThuMucBackup";
            this.txtThuMucBackup.ReadOnly = true;
            this.txtThuMucBackup.Size = new System.Drawing.Size(380, 29);
            this.txtThuMucBackup.TabIndex = 1;
            // 
            // lblThuMucBackup
            // 
            this.lblThuMucBackup.AutoSize = true;
            this.lblThuMucBackup.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblThuMucBackup.Location = new System.Drawing.Point(15, 35);
            this.lblThuMucBackup.Name = "lblThuMucBackup";
            this.lblThuMucBackup.Size = new System.Drawing.Size(99, 21);
            this.lblThuMucBackup.TabIndex = 0;
            this.lblThuMucBackup.Text = "Thư mục lưu:";
            // 
            // tabLichTuDong
            // 
            this.tabLichTuDong.BackColor = System.Drawing.Color.White;
            this.tabLichTuDong.Controls.Add(this.lblGhiChuLich);
            this.tabLichTuDong.Controls.Add(this.chkBatLichTuDong);
            this.tabLichTuDong.Controls.Add(this.lblDinhKy);
            this.tabLichTuDong.Controls.Add(this.cboDinhKy);
            this.tabLichTuDong.Controls.Add(this.lblGioChay);
            this.tabLichTuDong.Controls.Add(this.dtpGioChay);
            this.tabLichTuDong.Controls.Add(this.btnLuuLich);
            this.tabLichTuDong.Controls.Add(this.lblTrangThaiLich);
            this.tabLichTuDong.Location = new System.Drawing.Point(4, 32);
            this.tabLichTuDong.Name = "tabLichTuDong";
            this.tabLichTuDong.Padding = new System.Windows.Forms.Padding(20);
            this.tabLichTuDong.Size = new System.Drawing.Size(692, 434);
            this.tabLichTuDong.TabIndex = 1;
            this.tabLichTuDong.Text = "Lịch tự động";
            // 
            // lblGhiChuLich
            // 
            this.lblGhiChuLich.AutoSize = true;
            this.lblGhiChuLich.ForeColor = System.Drawing.Color.Red;
            this.lblGhiChuLich.Location = new System.Drawing.Point(24, 270);
            this.lblGhiChuLich.MaximumSize = new System.Drawing.Size(620, 0);
            this.lblGhiChuLich.Name = "lblGhiChuLich";
            this.lblGhiChuLich.Size = new System.Drawing.Size(617, 46);
            this.lblGhiChuLich.TabIndex = 7;
            this.lblGhiChuLich.Text = "Lưu ý: lịch tự động chỉ chạy khi phần mềm đang được mở. Backup sẽ dùng thư mục đã" +
    " chọn ở tab \"Sao lưu / Phục hồi\".";
            // 
            // chkBatLichTuDong
            // 
            this.chkBatLichTuDong.AutoSize = true;
            this.chkBatLichTuDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.chkBatLichTuDong.Location = new System.Drawing.Point(24, 30);
            this.chkBatLichTuDong.Name = "chkBatLichTuDong";
            this.chkBatLichTuDong.Size = new System.Drawing.Size(282, 29);
            this.chkBatLichTuDong.TabIndex = 0;
            this.chkBatLichTuDong.Text = "Bật tự động sao lưu định kỳ";
            this.chkBatLichTuDong.UseVisualStyleBackColor = true;
            this.chkBatLichTuDong.CheckedChanged += new System.EventHandler(this.chkBatLichTuDong_CheckedChanged);
            // 
            // lblDinhKy
            // 
            this.lblDinhKy.AutoSize = true;
            this.lblDinhKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDinhKy.Location = new System.Drawing.Point(45, 80);
            this.lblDinhKy.Name = "lblDinhKy";
            this.lblDinhKy.Size = new System.Drawing.Size(71, 23);
            this.lblDinhKy.TabIndex = 1;
            this.lblDinhKy.Text = "Định kỳ:";
            // 
            // cboDinhKy
            // 
            this.cboDinhKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDinhKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDinhKy.FormattingEnabled = true;
            this.cboDinhKy.Location = new System.Drawing.Point(160, 76);
            this.cboDinhKy.Name = "cboDinhKy";
            this.cboDinhKy.Size = new System.Drawing.Size(180, 31);
            this.cboDinhKy.TabIndex = 2;
            // 
            // lblGioChay
            // 
            this.lblGioChay.AutoSize = true;
            this.lblGioChay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGioChay.Location = new System.Drawing.Point(45, 124);
            this.lblGioChay.Name = "lblGioChay";
            this.lblGioChay.Size = new System.Drawing.Size(80, 23);
            this.lblGioChay.TabIndex = 3;
            this.lblGioChay.Text = "Giờ chạy:";
            // 
            // dtpGioChay
            // 
            this.dtpGioChay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpGioChay.Location = new System.Drawing.Point(160, 120);
            this.dtpGioChay.Name = "dtpGioChay";
            this.dtpGioChay.Size = new System.Drawing.Size(120, 30);
            this.dtpGioChay.TabIndex = 4;
            // 
            // btnLuuLich
            // 
            this.btnLuuLich.BackColor = System.Drawing.Color.SeaGreen;
            this.btnLuuLich.FlatAppearance.BorderSize = 0;
            this.btnLuuLich.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLuuLich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuLich.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuuLich.ForeColor = System.Drawing.Color.White;
            this.btnLuuLich.Location = new System.Drawing.Point(45, 170);
            this.btnLuuLich.Name = "btnLuuLich";
            this.btnLuuLich.Size = new System.Drawing.Size(160, 38);
            this.btnLuuLich.TabIndex = 5;
            this.btnLuuLich.Text = "Lưu cấu hình lịch";
            this.btnLuuLich.UseVisualStyleBackColor = false;
            this.btnLuuLich.Click += new System.EventHandler(this.btnLuuLich_Click);
            // 
            // lblTrangThaiLich
            // 
            this.lblTrangThaiLich.AutoSize = true;
            this.lblTrangThaiLich.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblTrangThaiLich.Location = new System.Drawing.Point(45, 225);
            this.lblTrangThaiLich.Name = "lblTrangThaiLich";
            this.lblTrangThaiLich.Size = new System.Drawing.Size(214, 21);
            this.lblTrangThaiLich.TabIndex = 6;
            this.lblTrangThaiLich.Text = "Đang tắt lịch tự động sao lưu.";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelTop.Controls.Add(this.lblTrangThai);
            this.panelTop.Controls.Add(this.lblDatabaseHienTai);
            this.panelTop.Controls.Add(this.lblTieuDe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(700, 90);
            this.panelTop.TabIndex = 0;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblTrangThai.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTrangThai.Location = new System.Drawing.Point(450, 56);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(0, 21);
            this.lblTrangThai.TabIndex = 2;
            this.lblTrangThai.Visible = false;
            // 
            // lblDatabaseHienTai
            // 
            this.lblDatabaseHienTai.AutoSize = true;
            this.lblDatabaseHienTai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDatabaseHienTai.Location = new System.Drawing.Point(22, 52);
            this.lblDatabaseHienTai.Name = "lblDatabaseHienTai";
            this.lblDatabaseHienTai.Size = new System.Drawing.Size(237, 23);
            this.lblDatabaseHienTai.TabIndex = 1;
            this.lblDatabaseHienTai.Text = "Database hiện tại: (đang tải...)";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.lblTieuDe.Location = new System.Drawing.Point(20, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(307, 35);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Sao lưu & Phục hồi dữ liệu";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.panelBottom.Controls.Add(this.btnDong);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 560);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(700, 56);
            this.panelBottom.TabIndex = 2;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDong.Location = new System.Drawing.Point(578, 10);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(107, 37);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmSaoLuuPhucHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 616);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSaoLuuPhucHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao lưu & Phục hồi dữ liệu";
            this.Load += new System.EventHandler(this.FrmSaoLuuPhucHoi_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSaoLuuPhucHoi.ResumeLayout(false);
            this.tabSaoLuuPhucHoi.PerformLayout();
            this.groupBoxPhucHoi.ResumeLayout(false);
            this.groupBoxPhucHoi.PerformLayout();
            this.groupBoxSaoLuu.ResumeLayout(false);
            this.groupBoxSaoLuu.PerformLayout();
            this.tabLichTuDong.ResumeLayout(false);
            this.tabLichTuDong.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSaoLuuPhucHoi;
        private System.Windows.Forms.GroupBox groupBoxSaoLuu;
        private System.Windows.Forms.Label lblThuMucBackup;
        private System.Windows.Forms.TextBox txtThuMucBackup;
        private System.Windows.Forms.Button btnChonThuMuc;
        private System.Windows.Forms.Button btnSaoLuuNgay;
        private System.Windows.Forms.GroupBox groupBoxPhucHoi;
        private System.Windows.Forms.Label lblFileRestore;
        private System.Windows.Forms.TextBox txtFileRestore;
        private System.Windows.Forms.Button btnChonFileRestore;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Label lblDanhSachBackup;
        private System.Windows.Forms.ListView lvDanhSachBackup;
        private System.Windows.Forms.ColumnHeader colTenFile;
        private System.Windows.Forms.ColumnHeader colThoiGian;
        private System.Windows.Forms.ColumnHeader colDungLuong;
        private System.Windows.Forms.Button btnLamMoiDanhSach;
        private System.Windows.Forms.Button btnMoThuMuc;
        private System.Windows.Forms.Button btnXoaBackup;
        private System.Windows.Forms.TabPage tabLichTuDong;
        private System.Windows.Forms.CheckBox chkBatLichTuDong;
        private System.Windows.Forms.Label lblDinhKy;
        private System.Windows.Forms.ComboBox cboDinhKy;
        private System.Windows.Forms.Label lblGioChay;
        private System.Windows.Forms.DateTimePicker dtpGioChay;
        private System.Windows.Forms.Button btnLuuLich;
        private System.Windows.Forms.Label lblTrangThaiLich;
        private System.Windows.Forms.Label lblGhiChuLich;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblDatabaseHienTai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnDong;
    }
}
