namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    partial class FrmThemNhanVien
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblMaNVLbl = new System.Windows.Forms.Label();
            this.lblMaNVVal = new System.Windows.Forms.Label();
            this.lblHoTenLbl = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblEmailLbl = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSDTLbl = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblDiaChiLbl = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblVaiTroLbl = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(11, 61, 120);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 50;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "THÊM NHÂN VIÊN MỚI";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 10);
            this.lblTitle.Name = "lblTitle";

            // ── pnlFooter ─────────────────────────────────────────
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 56;
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Controls.Add(this.btnHuy);
            this.pnlFooter.Controls.Add(this.btnLuu);

            this.btnHuy.Text = "Hủy";
            this.btnHuy.Size = new System.Drawing.Size(110, 36);
            this.btnHuy.Location = new System.Drawing.Point(20, 10);
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            this.btnLuu.Text = "💾  Lưu nhân viên";
            this.btnLuu.Size = new System.Drawing.Size(160, 36);
            this.btnLuu.Location = new System.Drawing.Point(262, 10);
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(11, 61, 120);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.TabIndex = 11;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // ── pnlBody ───────────────────────────────────────────
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.pnlBody.Padding = new System.Windows.Forms.Padding(20, 14, 20, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Controls.Add(this.lblMaNVLbl);
            this.pnlBody.Controls.Add(this.lblMaNVVal);
            this.pnlBody.Controls.Add(this.lblHoTenLbl);
            this.pnlBody.Controls.Add(this.txtHoTen);
            this.pnlBody.Controls.Add(this.lblEmailLbl);
            this.pnlBody.Controls.Add(this.txtEmail);
            this.pnlBody.Controls.Add(this.lblSDTLbl);
            this.pnlBody.Controls.Add(this.txtSDT);
            this.pnlBody.Controls.Add(this.lblDiaChiLbl);
            this.pnlBody.Controls.Add(this.txtDiaChi);
            this.pnlBody.Controls.Add(this.lblVaiTroLbl);
            this.pnlBody.Controls.Add(this.cboVaiTro);
            this.pnlBody.Controls.Add(this.lblNote);

            // Helpers: label style
            System.Drawing.Font fLbl = new System.Drawing.Font("Segoe UI", 9.5F);
            System.Drawing.Color cLbl = System.Drawing.Color.FromArgb(84, 110, 122);

            // Row 0 – Mã NV (auto)
            this.lblMaNVLbl.Text = "Mã nhân viên:";
            this.lblMaNVLbl.Font = fLbl; this.lblMaNVLbl.ForeColor = cLbl;
            this.lblMaNVLbl.Location = new System.Drawing.Point(20, 18);
            this.lblMaNVLbl.Size = new System.Drawing.Size(110, 22);
            this.lblMaNVLbl.Name = "lblMaNVLbl";

            this.lblMaNVVal.Text = "...";
            this.lblMaNVVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaNVVal.ForeColor = System.Drawing.Color.FromArgb(11, 61, 120);
            this.lblMaNVVal.Location = new System.Drawing.Point(138, 18);
            this.lblMaNVVal.Size = new System.Drawing.Size(280, 22);
            this.lblMaNVVal.Name = "lblMaNVVal";
            this.lblMaNVVal.AutoSize = true;

            // Row 1 – Họ tên
            this.lblHoTenLbl.Text = "Họ và tên *:";
            this.lblHoTenLbl.Font = fLbl; this.lblHoTenLbl.ForeColor = cLbl;
            this.lblHoTenLbl.Location = new System.Drawing.Point(20, 52);
            this.lblHoTenLbl.Size = new System.Drawing.Size(110, 22);
            this.lblHoTenLbl.Name = "lblHoTenLbl";

            this.txtHoTen.Location = new System.Drawing.Point(138, 48);
            this.txtHoTen.Size = new System.Drawing.Size(290, 28);
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.TabIndex = 0;

            // Row 2 – Email
            this.lblEmailLbl.Text = "Email *:";
            this.lblEmailLbl.Font = fLbl; this.lblEmailLbl.ForeColor = cLbl;
            this.lblEmailLbl.Location = new System.Drawing.Point(20, 92);
            this.lblEmailLbl.Size = new System.Drawing.Size(110, 22);
            this.lblEmailLbl.Name = "lblEmailLbl";

            this.txtEmail.Location = new System.Drawing.Point(138, 88);
            this.txtEmail.Size = new System.Drawing.Size(290, 28);
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.TabIndex = 1;

            // Row 3 – SĐT
            this.lblSDTLbl.Text = "Số điện thoại *:";
            this.lblSDTLbl.Font = fLbl; this.lblSDTLbl.ForeColor = cLbl;
            this.lblSDTLbl.Location = new System.Drawing.Point(20, 132);
            this.lblSDTLbl.Size = new System.Drawing.Size(110, 22);
            this.lblSDTLbl.Name = "lblSDTLbl";

            this.txtSDT.Location = new System.Drawing.Point(138, 128);
            this.txtSDT.Size = new System.Drawing.Size(290, 28);
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.TabIndex = 2;

            // Row 4 – Địa chỉ
            this.lblDiaChiLbl.Text = "Địa chỉ:";
            this.lblDiaChiLbl.Font = fLbl; this.lblDiaChiLbl.ForeColor = cLbl;
            this.lblDiaChiLbl.Location = new System.Drawing.Point(20, 172);
            this.lblDiaChiLbl.Size = new System.Drawing.Size(110, 22);
            this.lblDiaChiLbl.Name = "lblDiaChiLbl";

            this.txtDiaChi.Location = new System.Drawing.Point(138, 168);
            this.txtDiaChi.Size = new System.Drawing.Size(290, 28);
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.TabIndex = 3;

            // Row 5 – Vai trò
            this.lblVaiTroLbl.Text = "Vai trò *:";
            this.lblVaiTroLbl.Font = fLbl; this.lblVaiTroLbl.ForeColor = cLbl;
            this.lblVaiTroLbl.Location = new System.Drawing.Point(20, 212);
            this.lblVaiTroLbl.Size = new System.Drawing.Size(110, 22);
            this.lblVaiTroLbl.Name = "lblVaiTroLbl";

            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVaiTro.Location = new System.Drawing.Point(138, 208);
            this.cboVaiTro.Size = new System.Drawing.Size(290, 31);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.TabIndex = 4;

            // Note
            this.lblNote.Text = "📌 NV được tạo với trạng thái 'Đang làm việc'.\r\n" +
                                 "    Để cấp tài khoản đăng nhập, hãy yêu cầu Admin thực hiện.";
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(120, 144, 156);
            this.lblNote.Location = new System.Drawing.Point(20, 256);
            this.lblNote.Size = new System.Drawing.Size(408, 40);
            this.lblNote.Name = "lblNote";

            // ── Form ──────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 360);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmThemNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm nhân viên mới";
            this.AcceptButton = this.btnLuu;
            this.CancelButton = this.btnHuy;
            this.Load += new System.EventHandler(this.FrmThemNhanVien_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblMaNVLbl;
        private System.Windows.Forms.Label lblMaNVVal;
        private System.Windows.Forms.Label lblHoTenLbl;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblEmailLbl;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSDTLbl;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblDiaChiLbl;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblVaiTroLbl;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
    }
}