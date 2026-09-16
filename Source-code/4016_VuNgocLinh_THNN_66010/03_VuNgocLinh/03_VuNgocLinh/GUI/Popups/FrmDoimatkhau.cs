using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using System;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Popups
{
    public partial class FrmDoimatkhau : Form
    {
        private readonly string _initialUserName;

        public FrmDoimatkhau()
        {
            InitializeComponent();
        }

        // Allow caller to prefill username (common usage from FrmMain)
        public FrmDoimatkhau(string userName) : this()
        {
            _initialUserName = userName;
        }

        private void FrmDoimatkhau_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_initialUserName))
            {
                txtTenDangNhap.Text = _initialUserName;
                lblUserName.Text = _initialUserName;
            }
            else
            {
                lblUserName.Text = "<user name>";
            }
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            // Designer stub - no runtime action required
        }

        private void txtMatKhauCu_TextChanged(object sender, EventArgs e)
        {
            // Designer stub - no runtime action required
        }

        private void txtMatKhauMoi_TextChanged(object sender, EventArgs e)
        {
            // Designer stub - no runtime action required
        }

        private void txtMatKhauMoiAgain_TextChanged(object sender, EventArgs e)
        {
            // Designer stub - no runtime action required
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtTenDangNhap.Text?.Trim() ?? string.Empty;
                string oldPwd = txtMatKhauCu.Text ?? string.Empty;
                string newPwd = txtMatKhauMoi.Text ?? string.Empty;
                string newPwdAgain = txtMatKhauMoiAgain.Text ?? string.Empty;

                if (string.IsNullOrWhiteSpace(user))
                {
                    MessageBox.Show("Không xác định tên đăng nhập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(oldPwd))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu cũ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhauCu.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(newPwd) || newPwd.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhauMoi.Focus();
                    return;
                }

                if (!string.Equals(newPwd, newPwdAgain, StringComparison.Ordinal))
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhauMoiAgain.Focus();
                    return;
                }
        
                // Verify current password (login must succeed and account be active)
                TaiKhoanDTO tk = TaiKhoanDAL.Login(user, oldPwd);
                if (tk == null)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng hoặc tài khoản không hoạt động.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update password (DAL stores MATKHAU_HASH field; current project stores plain/hash as given)
                bool ok = TaiKhoanDAL.UpdatePassword(user, newPwd);
                if (ok)
                {
                    MessageBox.Show("Đổi mật khẩu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
