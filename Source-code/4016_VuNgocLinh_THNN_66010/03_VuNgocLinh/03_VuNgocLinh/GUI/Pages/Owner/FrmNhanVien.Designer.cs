namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    partial class FrmNhanVien
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.label_ts = new System.Windows.Forms.Label();
            this.cboLocVaiTro = new System.Windows.Forms.ComboBox();
            this.label_vt = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label_search = new System.Windows.Forms.Label();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.pnlDetailHeader = new System.Windows.Forms.Panel();
            this.lblDetailHeader = new System.Windows.Forms.Label();
            this.pnlDetailBody = new System.Windows.Forms.Panel();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnDatLai = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.pnlSep = new System.Windows.Forms.Panel();
            this.lblTrangThaiVal = new System.Windows.Forms.Label();
            this.lblTrangThaiLbl = new System.Windows.Forms.Label();
            this.lblNgayVaoVal = new System.Windows.Forms.Label();
            this.lblNgayVaoLbl = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblVaiTroLbl = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChiLbl = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDTLbl = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmailLbl = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTenLbl = new System.Windows.Forms.Label();
            this.lblTenDN = new System.Windows.Forms.Label();
            this.lblTenDNLbl = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblMaNVLbl = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();

            this.panel2.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.pnlDetailHeader.SuspendLayout();
            this.pnlDetailBody.SuspendLayout();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();

            // ── panel2 ─────────────────────────────────────────────
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Name = "panel2";
            this.panel2.TabIndex = 0;
            this.panel2.Controls.Add(this.pnlList);
            this.panel2.Controls.Add(this.pnlDetail);
            this.panel2.Controls.Add(this.pnlSearch);
            this.panel2.Controls.Add(this.pnlHeader);

            // ── pnlHeader ──────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(11, 61, 120);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1126, 50);
            this.pnlHeader.Controls.Add(this.lblCount);
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";

            this.lblCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(187, 222, 251);
            this.lblCount.Name = "lblCount";
            this.lblCount.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblCount.Size = new System.Drawing.Size(260, 50);
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ── pnlSearch (72px) ───────────────────────────────────
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1126, 72);
            this.pnlSearch.Controls.Add(this.btnReset);
            this.pnlSearch.Controls.Add(this.btnTimKiem);
            this.pnlSearch.Controls.Add(this.cboLocTrangThai);
            this.pnlSearch.Controls.Add(this.label_ts);
            this.pnlSearch.Controls.Add(this.cboLocVaiTro);
            this.pnlSearch.Controls.Add(this.label_vt);
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Controls.Add(this.label_search);
            this.pnlSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSearch_Paint);

            this.label_search.AutoSize = true;
            this.label_search.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label_search.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.label_search.Location = new System.Drawing.Point(12, 27);
            this.label_search.Name = "label_search";
            this.label_search.Text = "Tìm kiếm:";

            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(90, 22);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 28);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.Text = "Tên, mã NV...";

            this.label_vt.AutoSize = true;
            this.label_vt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label_vt.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.label_vt.Location = new System.Drawing.Point(302, 27);
            this.label_vt.Name = "label_vt";
            this.label_vt.Text = "Vai trò:";

            this.cboLocVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocVaiTro.FormattingEnabled = true;
            this.cboLocVaiTro.Location = new System.Drawing.Point(362, 22);
            this.cboLocVaiTro.Name = "cboLocVaiTro";
            this.cboLocVaiTro.Size = new System.Drawing.Size(210, 28);
            this.cboLocVaiTro.TabIndex = 1;
            this.cboLocVaiTro.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            this.label_ts.AutoSize = true;
            this.label_ts.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label_ts.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.label_ts.Location = new System.Drawing.Point(583, 27);
            this.label_ts.Name = "label_ts";
            this.label_ts.Text = "Trạng thái:";

            this.cboLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Location = new System.Drawing.Point(667, 22);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(155, 28);
            this.cboLocTrangThai.TabIndex = 2;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);

            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Location = new System.Drawing.Point(836, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(105, 32);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "🔍  Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnReset.Location = new System.Drawing.Point(947, 20);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 32);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Đặt lại";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // ── pnlDetail (385px Dock=Right) ───────────────────────
            this.pnlDetail.BackColor = System.Drawing.Color.White;
            this.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(385, 649);
            this.pnlDetail.Controls.Add(this.pnlDetailBody);
            this.pnlDetail.Controls.Add(this.pnlDetailHeader);

            this.pnlDetailHeader.BackColor = System.Drawing.Color.FromArgb(11, 61, 120);
            this.pnlDetailHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailHeader.Name = "pnlDetailHeader";
            this.pnlDetailHeader.Size = new System.Drawing.Size(383, 36);
            this.pnlDetailHeader.Controls.Add(this.lblDetailHeader);

            this.lblDetailHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailHeader.ForeColor = System.Drawing.Color.White;
            this.lblDetailHeader.Name = "lblDetailHeader";
            this.lblDetailHeader.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblDetailHeader.Text = "CHI TIẾT NHÂN VIÊN";
            this.lblDetailHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── pnlDetailBody (Dock=Fill, AutoScroll) ──────────────
            this.pnlDetailBody.AutoScroll = true;
            this.pnlDetailBody.BackColor = System.Drawing.Color.White;
            this.pnlDetailBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailBody.Name = "pnlDetailBody";
            this.pnlDetailBody.Controls.Add(this.lblMaNVLbl);
            this.pnlDetailBody.Controls.Add(this.lblMaNV);
            this.pnlDetailBody.Controls.Add(this.lblTenDNLbl);
            this.pnlDetailBody.Controls.Add(this.lblTenDN);
            this.pnlDetailBody.Controls.Add(this.lblHoTenLbl);
            this.pnlDetailBody.Controls.Add(this.txtHoTen);
            this.pnlDetailBody.Controls.Add(this.lblEmailLbl);
            this.pnlDetailBody.Controls.Add(this.txtEmail);
            this.pnlDetailBody.Controls.Add(this.lblSDTLbl);
            this.pnlDetailBody.Controls.Add(this.txtSDT);
            this.pnlDetailBody.Controls.Add(this.lblDiaChiLbl);
            this.pnlDetailBody.Controls.Add(this.txtDiaChi);
            this.pnlDetailBody.Controls.Add(this.lblVaiTroLbl);
            this.pnlDetailBody.Controls.Add(this.cboVaiTro);
            this.pnlDetailBody.Controls.Add(this.lblNgayVaoLbl);
            this.pnlDetailBody.Controls.Add(this.lblNgayVaoVal);
            this.pnlDetailBody.Controls.Add(this.lblTrangThaiLbl);
            this.pnlDetailBody.Controls.Add(this.lblTrangThaiVal);
            this.pnlDetailBody.Controls.Add(this.pnlSep);
            this.pnlDetailBody.Controls.Add(this.btnLuu);
            this.pnlDetailBody.Controls.Add(this.btnDatLai);
            this.pnlDetailBody.Controls.Add(this.btnToggle);
            this.pnlDetailBody.Controls.Add(this.btnXoa);
            this.pnlDetailBody.Controls.Add(this.btnThem);

            // Row 1: Ma NV (readonly label)
            this.lblMaNVLbl.AutoSize = true;
            this.lblMaNVLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaNVLbl.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.lblMaNVLbl.Location = new System.Drawing.Point(12, 12);
            this.lblMaNVLbl.Name = "lblMaNVLbl";
            this.lblMaNVLbl.Text = "Mã nhân viên";

            this.lblMaNV.AutoSize = false;
            this.lblMaNV.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblMaNV.ForeColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.lblMaNV.Location = new System.Drawing.Point(12, 28);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(170, 22);
            this.lblMaNV.Text = "—";

            // Row 1b: Ten dang nhap (readonly label)
            this.lblTenDNLbl.AutoSize = true;
            this.lblTenDNLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenDNLbl.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.lblTenDNLbl.Location = new System.Drawing.Point(196, 12);
            this.lblTenDNLbl.Name = "lblTenDNLbl";
            this.lblTenDNLbl.Text = "Tên đăng nhập";

            this.lblTenDN.AutoSize = false;
            this.lblTenDN.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenDN.ForeColor = System.Drawing.Color.FromArgb(28, 48, 70);
            this.lblTenDN.Location = new System.Drawing.Point(196, 28);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(172, 22);
            this.lblTenDN.Text = "—";

            // Row 2: Ho va ten (TextBox)
            this.lblHoTenLbl.AutoSize = true;
            this.lblHoTenLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHoTenLbl.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.lblHoTenLbl.Location = new System.Drawing.Point(12, 58);
            this.lblHoTenLbl.Name = "lblHoTenLbl";
            this.lblHoTenLbl.Text = "Họ và tên *";

            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.txtHoTen.Location = new System.Drawing.Point(12, 74);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(361, 26);
            this.txtHoTen.TabIndex = 10;

            // Row 3: Email
            this.lblEmailLbl.AutoSize = true;
            this.lblEmailLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmailLbl.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.lblEmailLbl.Location = new System.Drawing.Point(12, 108);
            this.lblEmailLbl.Name = "lblEmailLbl";
            this.lblEmailLbl.Text = "Email *";

            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(12, 124);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(361, 26);
            this.txtEmail.TabIndex = 11;

            // Row 4: SDT
            this.lblSDTLbl.AutoSize = true;
            this.lblSDTLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSDTLbl.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.lblSDTLbl.Location = new System.Drawing.Point(12, 158);
            this.lblSDTLbl.Name = "lblSDTLbl";
            this.lblSDTLbl.Text = "Số điện thoại *";

            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Location = new System.Drawing.Point(12, 174);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(361, 26);
            this.txtSDT.TabIndex = 12;

            // Row 5: Dia chi
            this.lblDiaChiLbl.AutoSize = true;
            this.lblDiaChiLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiaChiLbl.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.lblDiaChiLbl.Location = new System.Drawing.Point(12, 208);
            this.lblDiaChiLbl.Name = "lblDiaChiLbl";
            this.lblDiaChiLbl.Text = "Địa chỉ";

            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Location = new System.Drawing.Point(12, 224);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(361, 26);
            this.txtDiaChi.TabIndex = 13;

            // Row 6: Vai tro (ComboBox)
            this.lblVaiTroLbl.AutoSize = true;
            this.lblVaiTroLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVaiTroLbl.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.lblVaiTroLbl.Location = new System.Drawing.Point(12, 258);
            this.lblVaiTroLbl.Name = "lblVaiTroLbl";
            this.lblVaiTroLbl.Text = "Vai trò";

            this.cboVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(12, 274);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(361, 28);
            this.cboVaiTro.TabIndex = 14;

            // Row 7: Ngay vao lam | Trang thai
            this.lblNgayVaoLbl.AutoSize = true;
            this.lblNgayVaoLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayVaoLbl.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.lblNgayVaoLbl.Location = new System.Drawing.Point(12, 310);
            this.lblNgayVaoLbl.Name = "lblNgayVaoLbl";
            this.lblNgayVaoLbl.Text = "Ngày vào làm";

            this.lblNgayVaoVal.AutoSize = false;
            this.lblNgayVaoVal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayVaoVal.ForeColor = System.Drawing.Color.FromArgb(28, 48, 70);
            this.lblNgayVaoVal.Location = new System.Drawing.Point(12, 326);
            this.lblNgayVaoVal.Name = "lblNgayVaoVal";
            this.lblNgayVaoVal.Size = new System.Drawing.Size(170, 22);

            this.lblTrangThaiLbl.AutoSize = true;
            this.lblTrangThaiLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTrangThaiLbl.ForeColor = System.Drawing.Color.FromArgb(84, 110, 122);
            this.lblTrangThaiLbl.Location = new System.Drawing.Point(196, 310);
            this.lblTrangThaiLbl.Name = "lblTrangThaiLbl";
            this.lblTrangThaiLbl.Text = "Trạng thái";

            this.lblTrangThaiVal.AutoSize = false;
            this.lblTrangThaiVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiVal.Location = new System.Drawing.Point(196, 326);
            this.lblTrangThaiVal.Name = "lblTrangThaiVal";
            this.lblTrangThaiVal.Size = new System.Drawing.Size(177, 22);

            // Separator line
            this.pnlSep.BackColor = System.Drawing.Color.FromArgb(207, 216, 220);
            this.pnlSep.Location = new System.Drawing.Point(12, 356);
            this.pnlSep.Name = "pnlSep";
            this.pnlSep.Size = new System.Drawing.Size(361, 1);

            // Button row 1: Luu + Dat lai
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Location = new System.Drawing.Point(12, 366);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(176, 36);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "💾  Lưu thay đổi";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            this.btnDatLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatLai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDatLai.Location = new System.Drawing.Point(196, 366);
            this.btnDatLai.Name = "btnDatLai";
            this.btnDatLai.Size = new System.Drawing.Size(177, 36);
            this.btnDatLai.TabIndex = 16;
            this.btnDatLai.Text = "🔄  Đặt lại";
            this.btnDatLai.UseVisualStyleBackColor = false;
            this.btnDatLai.Click += new System.EventHandler(this.btnDatLai_Click);

            // Button row 2: Toggle trang thai (full width)
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnToggle.Location = new System.Drawing.Point(12, 410);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(361, 36);
            this.btnToggle.TabIndex = 17;
            this.btnToggle.Text = "⏸  Đổi trạng thái";
            this.btnToggle.UseVisualStyleBackColor = false;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);

            // Button row 3: Xóa NV | Thêm mới NV
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Location = new System.Drawing.Point(12, 456);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(176, 36);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "🗑  Xóa nhân viên";
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(211, 47, 47);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(183, 28, 28);
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(196, 456);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(177, 36);
            this.btnThem.TabIndex = 19;
            this.btnThem.Text = "➕  Thêm nhân viên";
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(56, 142, 60);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(27, 94, 32);
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // ── pnlList (Dock=Fill) ────────────────────────────────
            this.pnlList.BackColor = System.Drawing.Color.White;
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Name = "pnlList";
            this.pnlList.Controls.Add(this.dgvNhanVien);

            // ── dgvNhanVien ────────────────────────────────────────
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.AllowUserToResizeRows = false;
            this.dgvNhanVien.AutoGenerateColumns = false;
            this.dgvNhanVien.ColumnHeadersHeight = 36;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.RowTemplate.Height = 34;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.SelectionChanged += new System.EventHandler(this.dgvNhanVien_SelectionChanged);

            // ── Form ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(238, 242, 247);
            this.ClientSize = new System.Drawing.Size(1126, 771);
            this.Controls.Add(this.panel2);
            this.Name = "FrmNhanVien";
            this.Text = "Quản lý nhân viên";
            this.Load += new System.EventHandler(this.FrmNhanVien_Load);

            this.panel2.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetailHeader.ResumeLayout(false);
            this.pnlDetailBody.ResumeLayout(false);
            this.pnlDetailBody.PerformLayout();
            this.pnlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel panel2, pnlHeader, pnlSearch;
        private System.Windows.Forms.Panel pnlDetail, pnlDetailHeader, pnlDetailBody;
        private System.Windows.Forms.Panel pnlList, pnlSep;
        private System.Windows.Forms.Label lblTitle, lblCount, lblDetailHeader;
        private System.Windows.Forms.Label label_search, label_vt, label_ts;
        private System.Windows.Forms.Label lblMaNVLbl, lblMaNV, lblTenDNLbl, lblTenDN;
        private System.Windows.Forms.Label lblHoTenLbl, lblEmailLbl, lblSDTLbl;
        private System.Windows.Forms.Label lblDiaChiLbl, lblVaiTroLbl;
        private System.Windows.Forms.Label lblNgayVaoLbl, lblNgayVaoVal;
        private System.Windows.Forms.Label lblTrangThaiLbl, lblTrangThaiVal;
        private System.Windows.Forms.TextBox txtTimKiem, txtHoTen, txtEmail, txtSDT, txtDiaChi;
        private System.Windows.Forms.ComboBox cboLocVaiTro, cboLocTrangThai, cboVaiTro;
        private System.Windows.Forms.Button btnTimKiem, btnReset, btnLuu, btnDatLai, btnToggle, btnXoa, btnThem;
        private System.Windows.Forms.DataGridView dgvNhanVien;
    }
}