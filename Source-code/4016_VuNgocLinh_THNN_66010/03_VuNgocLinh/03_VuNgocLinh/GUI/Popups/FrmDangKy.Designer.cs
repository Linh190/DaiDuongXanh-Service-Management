namespace _03_VuNgocLinh.GUI.Popups
{
    partial class FrmDangKy
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();

            this.lblSecAccount = new System.Windows.Forms.Label();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblHintTenDangNhap = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblHintMatKhau = new System.Windows.Forms.Label();
            this.lblXacNhan = new System.Windows.Forms.Label();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.lblHintXacNhan = new System.Windows.Forms.Label();
            this.chkHienMatKhau = new System.Windows.Forms.CheckBox();

            this.lblSecInfo = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHintHoTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblHintEmail = new System.Windows.Forms.Label();
            this.lblSdt = new System.Windows.Forms.Label();
            this.mtbSoDienThoai = new System.Windows.Forms.MaskedTextBox();
            this.lblHintSdt = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblHintDiaChi = new System.Windows.Forms.Label();

            this.lblStatus = new System.Windows.Forms.Label();
            this.lnkDaCoTaiKhoan = new System.Windows.Forms.LinkLabel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();

            // ── Màu & font dùng chung ───────────────────────────────────
            System.Drawing.Color navy = System.Drawing.Color.FromArgb(28, 54, 100);
            System.Drawing.Color ocean = System.Drawing.Color.FromArgb(0, 120, 180);
            System.Drawing.Color bgLight = System.Drawing.Color.FromArgb(235, 245, 251);
            System.Drawing.Color bgBlue = System.Drawing.Color.FromArgb(210, 235, 252);
            System.Drawing.Color border = System.Drawing.Color.FromArgb(200, 221, 237);
            System.Drawing.Color textDark = System.Drawing.Color.FromArgb(28, 48, 70);
            System.Drawing.Color muted = System.Drawing.Color.FromArgb(107, 143, 175);
            System.Drawing.Font fntBase = new System.Drawing.Font("Segoe UI", 9.5F);
            System.Drawing.Font fntSm = new System.Drawing.Font("Segoe UI", 8F);
            System.Drawing.Font fntSec = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            // ════════════════════════════════════════════════════════════
            // FORM
            // ════════════════════════════════════════════════════════════
            this.Text = "Đăng ký tài khoản — Đại Dương Xanh";
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = bgLight;
            this.Font = fntBase;
            this.Load += new System.EventHandler(this.FrmDangKy_Load);

            // ════════════════════════════════════════════════════════════
            // HEADER
            // ════════════════════════════════════════════════════════════
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(700, 72);
            this.pnlHeader.BackColor = navy;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Text = "  Đăng ký tài khoản mới";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Text = "  Hệ thống quản lý dịch vụ vận chuyển Đại Dương Xanh";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblSubtitle.Location = new System.Drawing.Point(20, 44);

            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // ════════════════════════════════════════════════════════════
            // FOOTER
            // ════════════════════════════════════════════════════════════
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Size = new System.Drawing.Size(700, 62);
            this.pnlFooter.BackColor = bgBlue;

            this.lblStatus.AutoSize = false;
            this.lblStatus.Size = new System.Drawing.Size(380, 20);
            this.lblStatus.Text = "";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblStatus.Location = new System.Drawing.Point(12, 22);

            this.btnHuy.Text = "Hủy bỏ";
            this.btnHuy.Size = new System.Drawing.Size(110, 38);
            this.btnHuy.Location = new System.Drawing.Point(462, 12);
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.FlatAppearance.BorderSize = 1;
            this.btnHuy.FlatAppearance.BorderColor = border;
            this.btnHuy.FlatAppearance.MouseOverBackColor = border;
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.ForeColor = textDark;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuyBo_Click);

            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.Size = new System.Drawing.Size(118, 38);
            this.btnDangKy.Location = new System.Drawing.Point(580, 12);
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(26, 144, 204);
            this.btnDangKy.BackColor = ocean;
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);

            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Controls.Add(this.btnHuy);
            this.pnlFooter.Controls.Add(this.btnDangKy);

            // ════════════════════════════════════════════════════════════
            // BODY — CỘT TRÁI (x=16) · CỘT PHẢI (x=362)
            // ════════════════════════════════════════════════════════════
            this.pnlBody.BackColor = bgLight;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.AutoScroll = true;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(16, 12, 16, 8);

            int c1 = 16;   // cột trái X
            int c2 = 362;  // cột phải X
            int fw = 306;  // field width

            // ── SECTION: Tài khoản ──────────────────────────────────────
            this.lblSecAccount.Text = "  Thông tin tài khoản";
            this.lblSecAccount.Font = fntSec;
            this.lblSecAccount.ForeColor = ocean;
            this.lblSecAccount.Location = new System.Drawing.Point(c1, 8);
            this.lblSecAccount.AutoSize = true;

            // Tên đăng nhập
            this.lblTenDangNhap.Text = "Tên đăng nhập *";
            this.lblTenDangNhap.Font = fntBase;
            this.lblTenDangNhap.ForeColor = textDark;
            this.lblTenDangNhap.Location = new System.Drawing.Point(c1, 36);
            this.lblTenDangNhap.AutoSize = true;

            this.txtTenDangNhap.Location = new System.Drawing.Point(c1, 56);
            this.txtTenDangNhap.Size = new System.Drawing.Size(fw, 28);
            this.txtTenDangNhap.Font = fntBase;
            this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDangNhap.BackColor = System.Drawing.Color.White;

            this.lblHintTenDangNhap.Text = "";
            this.lblHintTenDangNhap.Font = fntSm;
            this.lblHintTenDangNhap.ForeColor = muted;
            this.lblHintTenDangNhap.Location = new System.Drawing.Point(c1, 86);
            this.lblHintTenDangNhap.Size = new System.Drawing.Size(fw, 16);

            // Mật khẩu
            this.lblMatKhau.Text = "Mật khẩu *";
            this.lblMatKhau.Font = fntBase;
            this.lblMatKhau.ForeColor = textDark;
            this.lblMatKhau.Location = new System.Drawing.Point(c1, 110);
            this.lblMatKhau.AutoSize = true;

            this.txtMatKhau.Location = new System.Drawing.Point(c1, 130);
            this.txtMatKhau.Size = new System.Drawing.Size(fw, 28);
            this.txtMatKhau.Font = fntBase;
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhau.BackColor = System.Drawing.Color.White;

            this.lblHintMatKhau.Text = "";
            this.lblHintMatKhau.Font = fntSm;
            this.lblHintMatKhau.ForeColor = muted;
            this.lblHintMatKhau.Location = new System.Drawing.Point(c1, 160);
            this.lblHintMatKhau.Size = new System.Drawing.Size(fw, 16);

            // Xác nhận mật khẩu
            this.lblXacNhan.Text = "Xác nhận mật khẩu *";
            this.lblXacNhan.Font = fntBase;
            this.lblXacNhan.ForeColor = textDark;
            this.lblXacNhan.Location = new System.Drawing.Point(c1, 184);
            this.lblXacNhan.AutoSize = true;

            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(c1, 204);
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(fw, 28);
            this.txtXacNhanMatKhau.Font = fntBase;
            this.txtXacNhanMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXacNhanMatKhau.BackColor = System.Drawing.Color.White;

            this.lblHintXacNhan.Text = "";
            this.lblHintXacNhan.Font = fntSm;
            this.lblHintXacNhan.ForeColor = muted;
            this.lblHintXacNhan.Location = new System.Drawing.Point(c1, 234);
            this.lblHintXacNhan.Size = new System.Drawing.Size(fw, 16);

            // Checkbox hiện mật khẩu
            this.chkHienMatKhau.Text = "Hiển thị mật khẩu";
            this.chkHienMatKhau.Font = fntSm;
            this.chkHienMatKhau.ForeColor = muted;
            this.chkHienMatKhau.Location = new System.Drawing.Point(c1, 258);
            this.chkHienMatKhau.AutoSize = true;
            this.chkHienMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;

            // ── SECTION: Thông tin cá nhân ─────────────────────────────
            this.lblSecInfo.Text = "  Thông tin cá nhân";
            this.lblSecInfo.Font = fntSec;
            this.lblSecInfo.ForeColor = ocean;
            this.lblSecInfo.Location = new System.Drawing.Point(c2, 8);
            this.lblSecInfo.AutoSize = true;

            // Họ và tên
            this.lblHoTen.Text = "Họ và tên *";
            this.lblHoTen.Font = fntBase;
            this.lblHoTen.ForeColor = textDark;
            this.lblHoTen.Location = new System.Drawing.Point(c2, 36);
            this.lblHoTen.AutoSize = true;

            this.txtHoTen.Location = new System.Drawing.Point(c2, 56);
            this.txtHoTen.Size = new System.Drawing.Size(fw, 28);
            this.txtHoTen.Font = fntBase;
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoTen.BackColor = System.Drawing.Color.White;

            this.lblHintHoTen.Text = "";
            this.lblHintHoTen.Font = fntSm;
            this.lblHintHoTen.ForeColor = muted;
            this.lblHintHoTen.Location = new System.Drawing.Point(c2, 86);
            this.lblHintHoTen.Size = new System.Drawing.Size(fw, 16);

            // Ngày sinh
            this.lblNgaySinh.Text = "Ngày sinh";
            this.lblNgaySinh.Font = fntBase;
            this.lblNgaySinh.ForeColor = textDark;
            this.lblNgaySinh.Location = new System.Drawing.Point(c2, 110);
            this.lblNgaySinh.AutoSize = true;

            this.dtpNgaySinh.Location = new System.Drawing.Point(c2, 130);
            this.dtpNgaySinh.Size = new System.Drawing.Size(fw, 28);
            this.dtpNgaySinh.Font = fntBase;
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Giới tính
            this.lblGioiTinh.Text = "Giới tính";
            this.lblGioiTinh.Font = fntBase;
            this.lblGioiTinh.ForeColor = textDark;
            this.lblGioiTinh.Location = new System.Drawing.Point(c2, 170);
            this.lblGioiTinh.AutoSize = true;

            this.cboGioiTinh.Location = new System.Drawing.Point(c2, 190);
            this.cboGioiTinh.Size = new System.Drawing.Size(fw, 28);
            this.cboGioiTinh.Font = fntBase;
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGioiTinh.Cursor = System.Windows.Forms.Cursors.Hand;

            // Email
            this.lblEmail.Text = "Email *";
            this.lblEmail.Font = fntBase;
            this.lblEmail.ForeColor = textDark;
            this.lblEmail.Location = new System.Drawing.Point(c2, 228);
            this.lblEmail.AutoSize = true;

            this.txtEmail.Location = new System.Drawing.Point(c2, 248);
            this.txtEmail.Size = new System.Drawing.Size(fw, 28);
            this.txtEmail.Font = fntBase;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.BackColor = System.Drawing.Color.White;

            this.lblHintEmail.Text = "";
            this.lblHintEmail.Font = fntSm;
            this.lblHintEmail.ForeColor = muted;
            this.lblHintEmail.Location = new System.Drawing.Point(c2, 278);
            this.lblHintEmail.Size = new System.Drawing.Size(fw, 16);

            // Số điện thoại
            this.lblSdt.Text = "Số điện thoại *";
            this.lblSdt.Font = fntBase;
            this.lblSdt.ForeColor = textDark;
            this.lblSdt.Location = new System.Drawing.Point(c2, 302);
            this.lblSdt.AutoSize = true;

            this.mtbSoDienThoai.Location = new System.Drawing.Point(c2, 322);
            this.mtbSoDienThoai.Size = new System.Drawing.Size(fw, 28);
            this.mtbSoDienThoai.Font = fntBase;
            this.mtbSoDienThoai.Mask = "0000000000";
            this.mtbSoDienThoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblHintSdt.Text = "";
            this.lblHintSdt.Font = fntSm;
            this.lblHintSdt.ForeColor = muted;
            this.lblHintSdt.Location = new System.Drawing.Point(c2, 352);
            this.lblHintSdt.Size = new System.Drawing.Size(fw, 16);

            // Địa chỉ
            this.lblDiaChi.Text = "Địa chỉ *";
            this.lblDiaChi.Font = fntBase;
            this.lblDiaChi.ForeColor = textDark;
            this.lblDiaChi.Location = new System.Drawing.Point(c2, 376);
            this.lblDiaChi.AutoSize = true;

            this.txtDiaChi.Location = new System.Drawing.Point(c2, 396);
            this.txtDiaChi.Size = new System.Drawing.Size(fw, 28);
            this.txtDiaChi.Font = fntBase;
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaChi.BackColor = System.Drawing.Color.White;

            this.lblHintDiaChi.Text = "";
            this.lblHintDiaChi.Font = fntSm;
            this.lblHintDiaChi.ForeColor = muted;
            this.lblHintDiaChi.Location = new System.Drawing.Point(c2, 426);
            this.lblHintDiaChi.Size = new System.Drawing.Size(fw, 16);

            // Link "Đã có tài khoản"
            this.lnkDaCoTaiKhoan.Text = "Đã có tài khoản? Đăng nhập tại đây";
            this.lnkDaCoTaiKhoan.Font = fntSm;
            this.lnkDaCoTaiKhoan.AutoSize = true;
            this.lnkDaCoTaiKhoan.Location = new System.Drawing.Point(c2, 452);
            this.lnkDaCoTaiKhoan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDaCoTaiKhoan_LinkClicked);

            // ── Thêm controls vào pnlBody ──────────────────────────────
            this.pnlBody.Controls.Add(this.lblSecAccount);
            this.pnlBody.Controls.Add(this.lblTenDangNhap);
            this.pnlBody.Controls.Add(this.txtTenDangNhap);
            this.pnlBody.Controls.Add(this.lblHintTenDangNhap);
            this.pnlBody.Controls.Add(this.lblMatKhau);
            this.pnlBody.Controls.Add(this.txtMatKhau);
            this.pnlBody.Controls.Add(this.lblHintMatKhau);
            this.pnlBody.Controls.Add(this.lblXacNhan);
            this.pnlBody.Controls.Add(this.txtXacNhanMatKhau);
            this.pnlBody.Controls.Add(this.lblHintXacNhan);
            this.pnlBody.Controls.Add(this.chkHienMatKhau);
            this.pnlBody.Controls.Add(this.lblSecInfo);
            this.pnlBody.Controls.Add(this.lblHoTen);
            this.pnlBody.Controls.Add(this.txtHoTen);
            this.pnlBody.Controls.Add(this.lblHintHoTen);
            this.pnlBody.Controls.Add(this.lblNgaySinh);
            this.pnlBody.Controls.Add(this.dtpNgaySinh);
            this.pnlBody.Controls.Add(this.lblGioiTinh);
            this.pnlBody.Controls.Add(this.cboGioiTinh);
            this.pnlBody.Controls.Add(this.lblEmail);
            this.pnlBody.Controls.Add(this.txtEmail);
            this.pnlBody.Controls.Add(this.lblHintEmail);
            this.pnlBody.Controls.Add(this.lblSdt);
            this.pnlBody.Controls.Add(this.mtbSoDienThoai);
            this.pnlBody.Controls.Add(this.lblHintSdt);
            this.pnlBody.Controls.Add(this.lblDiaChi);
            this.pnlBody.Controls.Add(this.txtDiaChi);
            this.pnlBody.Controls.Add(this.lblHintDiaChi);
            this.pnlBody.Controls.Add(this.lnkDaCoTaiKhoan);

            // ── Thêm vào Form (thứ tự: Fill trước, Top/Bottom sau) ────
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlFooter;

        private System.Windows.Forms.Label lblSecAccount;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblHintTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblHintMatKhau;
        private System.Windows.Forms.Label lblXacNhan;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.Label lblHintXacNhan;
        private System.Windows.Forms.CheckBox chkHienMatKhau;

        private System.Windows.Forms.Label lblSecInfo;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHintHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblHintEmail;
        private System.Windows.Forms.Label lblSdt;
        private System.Windows.Forms.MaskedTextBox mtbSoDienThoai;
        private System.Windows.Forms.Label lblHintSdt;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblHintDiaChi;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.LinkLabel lnkDaCoTaiKhoan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDangKy;
    }
}