using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.Helpers;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Popups
{
    /// <summary>
    /// Form quên mật khẩu — 2 bước:
    ///   Bước 1: Nhập tên đăng nhập + email → nhấn "Gửi mã xác thực"
    ///   Bước 2: Nhập mã OTP 6 chữ số + mật khẩu mới → nhấn "Xác nhận"
    /// </summary>
    public partial class FrmQuenmatkhau : Form
    {
        private string _verificationCode;   // mã OTP đang chờ xác nhận
        private DateTime _codeGeneratedAt;    // thời điểm sinh mã (để kiểm tra hết hạn)
        private string _targetUsername;     // tên đăng nhập đã xác minh tồn tại trong DB
        private string _targetEmail;        // email đã xác minh khớp với tài khoản

        // ── Constructors ──────────────────────────────────────────────────────
        public FrmQuenmatkhau()
        {
            InitializeComponent();
        }

        /// <summary>Gọi từ FrmLogin khi đã biết username trước.</summary>
        public FrmQuenmatkhau(string username) : this()
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                _targetUsername = username;
                txtTenDangNhap.Text = username;
                // Nhảy thẳng sang ô email cho nhanh
                txtEmail.Focus();
            }
        }

        // ── Load ──────────────────────────────────────────────────────────────
        private void FrmQuenmatkhau_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                txtTenDangNhap.Focus();
            else
                txtEmail.Focus();
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }

        // ══════════════════════════════════════════════════════════════════════
        //  BƯỚC 1 — Gửi mã xác minh qua email
        // ══════════════════════════════════════════════════════════════════════
        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtTenDangNhap.Text.Trim();
                string email = txtEmail.Text.Trim();

                // ── 1. Validate đầu vào ───────────────────────────────────
                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Vui lòng nhập Tên đăng nhập.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Vui lòng nhập Email đã đăng ký.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không hợp lệ. Ví dụ: abc@gmail.com", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                // ── 2. Kiểm tra cặp (username, email) trong DB ────────────
                //    Hỗ trợ cả tài khoản Khách hàng (EMAILKH)
                //    lẫn Nhân viên (EMAILNV)
                object ok = DataProvider.ExecuteScalar(
                    "SELECT 1 FROM TaiKhoan TK " +
                    "JOIN KhachHang KH ON TK.MAKH = KH.MAKH " +
                    "WHERE TK.TENDANGNHAP = @u AND KH.EMAILKH = @e " +
                    "UNION " +
                    "SELECT 1 FROM TaiKhoan TK " +
                    "JOIN NhanVien NV ON TK.MANV = NV.MANV " +
                    "WHERE TK.TENDANGNHAP = @u AND NV.EMAILNV = @e",
                    new SqlParameter("@u", username),
                    new SqlParameter("@e", email));

                if (ok == null)
                {
                    MessageBox.Show(
                        "Tên đăng nhập và Email không khớp với bất kỳ tài khoản nào.\n" +
                        "Vui lòng kiểm tra lại thông tin đã nhập.",
                        "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _targetUsername = username;
                _targetEmail = email;

                // ── 3. Sinh mã OTP 6 chữ số ──────────────────────────────
                _verificationCode = new Random().Next(100000, 999999).ToString();
                _codeGeneratedAt = DateTime.Now;

                // ── 4. Gửi email (disable nút tránh double-click) ─────────
                SetGuiMaState(loading: true);
                Application.DoEvents();

                bool sent = EmailHelper.GuiMaXacMinh(_targetEmail, _verificationCode);

                SetGuiMaState(loading: false);

                if (!sent)
                {
                    MessageBox.Show(
                        "Gửi email thất bại.\n\n" +
                        "Nguyên nhân thường gặp:\n" +
                        "  • SENDER_PASS trong EmailHelper.cs chưa được cấu hình\n" +
                        "  • Chưa bật App Password trên Gmail\n" +
                        "  • Mất kết nối mạng\n\n" +
                        "Xem chi tiết lỗi trong Output window của Visual Studio.",
                        "Lỗi gửi email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ── 5. Chuyển sang Bước 2 ────────────────────────────────
                lblCodeHint.Text =
                    $"\u2709 Mã xác minh đã gửi tới:\n{_targetEmail}\n" +
                    "Vui lòng kiểm tra hộp thư (kể cả Spam). " +
                    "Mã có hiệu lực trong 10 phút.";
                GoToStep2();
            }
            catch (Exception ex)
            {
                SetGuiMaState(loading: false);
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        //  BƯỚC 2 — Xác minh OTP + đặt mật khẩu mới
        // ══════════════════════════════════════════════════════════════════════
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                string inputCode = txtMaXacNhan.Text.Trim();
                string newPwd = txtMatKhauMoi.Text;
                string confirmPwd = txtXacNhanMK.Text;

                // ── 1. Kiểm tra ô mã không rỗng ──────────────────────────
                if (string.IsNullOrWhiteSpace(inputCode))
                {
                    MessageBox.Show("Vui lòng nhập mã xác minh 6 chữ số.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaXacNhan.Focus();
                    return;
                }

                // ── 2. Kiểm tra hết hạn (10 phút) ────────────────────────
                if ((DateTime.Now - _codeGeneratedAt).TotalMinutes > 10)
                {
                    MessageBox.Show(
                        "Mã xác minh đã hết hạn (quá 10 phút).\n" +
                        "Vui lòng nhấn 'Quay lại' và gửi mã mới.",
                        "Hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ── 3. So sánh mã ────────────────────────────────────────
                if (!string.Equals(inputCode, _verificationCode, StringComparison.Ordinal))
                {
                    MessageBox.Show("Mã xác minh không đúng. Vui lòng thử lại.",
                        "Sai mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaXacNhan.SelectAll();
                    txtMaXacNhan.Focus();
                    return;
                }

                // ── 4. Kiểm tra mật khẩu mới ─────────────────────────────
                if (string.IsNullOrEmpty(newPwd) || newPwd.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhauMoi.Focus();
                    return;
                }

                if (!string.Equals(newPwd, confirmPwd, StringComparison.Ordinal))
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp. Vui lòng nhập lại.",
                        "Không khớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtXacNhanMK.SelectAll();
                    txtXacNhanMK.Focus();
                    return;
                }

                // ── 5. Cập nhật DB ────────────────────────────────────────
                bool updated = TaiKhoanDAL.UpdatePassword(_targetUsername, newPwd);
                if (updated)
                {
                    MessageBox.Show(
                        "✅ Đặt lại mật khẩu thành công!\n" +
                        "Bạn có thể đăng nhập bằng mật khẩu mới.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Cập nhật mật khẩu thất bại. Vui lòng thử lại sau.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── btnGuiLai — quay về Bước 1 ───────────────────────────────────────
        private void btnGuiLai_Click(object sender, EventArgs e)
        {
            GoToStep1();
        }

        // ── btnHuy ───────────────────────────────────────────────────────────
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ══════════════════════════════════════════════════════════════════════
        //  Helpers — điều hướng bước
        // ══════════════════════════════════════════════════════════════════════
        private void GoToStep2()
        {
            // Ẩn step 1, hiện step 2
            pnlStep1.Visible = false;
            pnlStep2.Visible = true;
            // Đổi nút
            btnGuiMa.Visible = false;
            btnXacNhan.Visible = true;
            btnGuiLai.Visible = true;
            // Xóa sạch input bước 2
            txtMaXacNhan.Clear();
            txtMatKhauMoi.Clear();
            txtXacNhanMK.Clear();
            txtMaXacNhan.Focus();
        }

        private void GoToStep1()
        {
            // Ẩn step 2, hiện step 1
            pnlStep2.Visible = false;
            pnlStep1.Visible = true;
            // Đổi nút
            btnXacNhan.Visible = false;
            btnGuiLai.Visible = false;
            btnGuiMa.Visible = true;
            // Xóa mã cũ để bắt buộc gửi lại
            _verificationCode = null;
            txtTenDangNhap.Focus();
        }

        private void SetGuiMaState(bool loading)
        {
            btnGuiMa.Enabled = !loading;
            btnGuiMa.Text = loading ? "Đang gửi..." : "Gửi mã xác thực";
        }
    }
}