using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Popups
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            lblNotification.Text = "";

            // Load Remember Me
            chkSave.Checked = Properties.Settings.Default.RememberMe;

            if (chkSave.Checked)
            {
                txtUsername.Text = Properties.Settings.Default.UserID ?? "";
                txtPassword.Text = Properties.Settings.Default.Password ?? "";
            }
        }

        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RememberMe = chkSave.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiKhoanBUS bus = new TaiKhoanBUS();
            TaiKhoanDTO tk = bus.Login(username, password);

            if (tk != null)
            {
                Session.UserName = tk.TenDangNhap;
                Session.Role = tk.VaiTro;
                Session.UserID = bus.GetUserID(tk.TenDangNhap);

                // === LƯU REMEMBER ME NẾU ĐƯỢC CHECK ===
                if (chkSave.Checked)
                {
                    Properties.Settings.Default.UserID = username;
                    Properties.Settings.Default.Password = password;   // Lưu plain text (tạm thời)
                    Properties.Settings.Default.Save();
                }
                else
                {
                    // Nếu không check Remember Me → xóa dữ liệu cũ
                    Properties.Settings.Default.UserID = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.RememberMe = false;
                    Properties.Settings.Default.Save();
                }

                this.Tag = tk;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblNotification.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                lblNotification.ForeColor = Color.Red;
            }
        }

        // ==================== CHỨC NĂNG QUÊN MẬT KHẨU ====================
        // ==================== CHỨC NĂNG QUÊN MẬT KHẨU ====================
        // ==================== CHỨC NĂNG QUÊN MẬT KHẨU ====================
        private void lnkQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập trước khi lấy lại mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            using (FrmQuenmatkhau frm = new FrmQuenmatkhau(txtUsername.Text.Trim()))
            {
                frm.ShowDialog(this);
            }
        }
        private void lnkDangKy_LinkClicked(object sender, EventArgs e)
        {
            using (FrmDangKy frmDangKy = new FrmDangKy())
            {
                // Mở form đăng ký dạng modal
                DialogResult result = frmDangKy.ShowDialog(this);

                // Nếu đăng ký thành công, tự động điền tên đăng nhập vào ô login
                if (result == DialogResult.OK && frmDangKy.Tag != null)
                {
                    txtUsername.Text = frmDangKy.Tag.ToString();
                    txtPassword.Focus();   // Chuyển focus sang mật khẩu
                }
            }

        }

    }
}
