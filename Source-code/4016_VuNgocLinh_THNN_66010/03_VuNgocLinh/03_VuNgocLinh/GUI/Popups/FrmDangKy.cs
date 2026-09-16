using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Popups
{
    public partial class FrmDangKy : Form
    {
        // ── Màu trạng thái ──────────────────────────────────────────────
        private static readonly Color ColorOk = Color.FromArgb(39, 174, 96);
        private static readonly Color ColorError = Color.FromArgb(231, 76, 60);
        private static readonly Color ColorMuted = Color.FromArgb(107, 143, 175);

        public FrmDangKy()
        {
            InitializeComponent();
        }

        // ══════════════════════════════════════════════════════════════════
        // LOAD
        // ══════════════════════════════════════════════════════════════════
        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '●';
            txtXacNhanMatKhau.PasswordChar = '●';

            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.SelectedIndex = 0;

            dtpNgaySinh.MaxDate = DateTime.Today.AddYears(-10);
            dtpNgaySinh.Value = DateTime.Today.AddYears(-20);

            // Real-time validate
            txtTenDangNhap.TextChanged += (s, ev) => ValidateTenDangNhap();
            txtMatKhau.TextChanged += (s, ev) => { ValidateMatKhau(); ValidateXacNhan(); };
            txtXacNhanMatKhau.TextChanged += (s, ev) => ValidateXacNhan();
            txtHoTen.TextChanged += (s, ev) => ValidateHoTen();
            txtEmail.TextChanged += (s, ev) => ValidateEmail();
            txtDiaChi.TextChanged += (s, ev) => ValidateDiaChi();
            mtbSoDienThoai.TextChanged += (s, ev) => ValidateSdt();
            chkHienMatKhau.CheckedChanged += ChkHienMatKhau_CheckedChanged;

            txtTenDangNhap.Focus();
        }

        // ══════════════════════════════════════════════════════════════════
        // HIỆN / ẨN MẬT KHẨU
        // ══════════════════════════════════════════════════════════════════
        private void ChkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            char c = chkHienMatKhau.Checked ? '\0' : '●';
            txtMatKhau.PasswordChar = c;
            txtXacNhanMatKhau.PasswordChar = c;
        }

        // ══════════════════════════════════════════════════════════════════
        // NÚT ĐĂNG KÝ
        // ══════════════════════════════════════════════════════════════════
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Validate tất cả fields
            bool ok = true;
            ok &= ValidateTenDangNhap();
            ok &= ValidateMatKhau();
            ok &= ValidateXacNhan();
            ok &= ValidateHoTen();
            ok &= ValidateEmail();
            ok &= ValidateSdt();
            ok &= ValidateDiaChi();

            if (!ok)
            {
                ShowStatus("Vui lòng kiểm tra lại các trường bị lỗi.", ColorError);
                return;
            }

            var bus = new TaiKhoanBUS();
            var kh = new KhachHangDTO();
            // Gán mã khách hàng mới
            kh.MaKhachHang = bus.GenerateNewMaKhachHang();
            // Gán các thuộc tính khác cho kh...
            kh.HoTen = txtHoTen.Text.Trim();
            kh.Email = txtEmail.Text.Trim();
            kh.SoDienThoai = LaySoDienThoaiThuanSo();
            kh.DiaChi = txtDiaChi.Text.Trim();
            kh.TrangThai = "Hoạt động";

            var tk = new TaiKhoanDTO
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim(),
                LoaiTaiKhoan = "Khách hàng",
                TrangThai = "Hoạt động"
            };

            btnDangKy.Enabled = false;
            btnDangKy.Text = "Đang xử lý...";
            Application.DoEvents();

            // Gọi DAL — nhận kết quả có message cụ thể
            var (success, errorMsg) = TaiKhoanDAL.DangKyTaiKhoan(tk, kh);

            btnDangKy.Enabled = true;
            btnDangKy.Text = "Đăng ký";

            if (success)
            {
                MessageBox.Show(
                    $"Đăng ký thành công!\nChào mừng {kh.HoTen} đến với Đại Dương Xanh.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Tag = tk.TenDangNhap;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Hiện đúng lỗi: trùng tên / trùng email / trùng SĐT / lỗi DB khác
                ShowStatus(errorMsg, ColorError);

                // Focus vào field bị trùng cho tiện
                if (errorMsg != null && errorMsg.Contains("Tên đăng nhập"))
                    txtTenDangNhap.Focus();
                else if (errorMsg != null && errorMsg.Contains("Email"))
                    txtEmail.Focus();
                else if (errorMsg != null && errorMsg.Contains("điện thoại"))
                    mtbSoDienThoai.Focus();
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // NÚT HỦY
        // ══════════════════════════════════════════════════════════════════
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ══════════════════════════════════════════════════════════════════
        // LINK "ĐÃ CÓ TÀI KHOẢN"
        // ══════════════════════════════════════════════════════════════════
        private void lnkDaCoTaiKhoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ══════════════════════════════════════════════════════════════════
        // VALIDATE TỪNG TRƯỜNG
        // ══════════════════════════════════════════════════════════════════
        private bool ValidateTenDangNhap()
        {
            string v = txtTenDangNhap.Text.Trim();
            if (string.IsNullOrWhiteSpace(v))
                return SetHint(lblHintTenDangNhap, "Bắt buộc nhập tên đăng nhập.", false);
            if (v.Length < 4)
                return SetHint(lblHintTenDangNhap, "Ít nhất 4 ký tự.", false);
            if (!Regex.IsMatch(v, @"^[a-zA-Z0-9_.]+$"))
                return SetHint(lblHintTenDangNhap, "Chỉ dùng chữ, số, dấu _ hoặc .", false);
            return SetHint(lblHintTenDangNhap, "✔", true);
        }

        private bool ValidateMatKhau()
        {
            string v = txtMatKhau.Text;
            if (string.IsNullOrEmpty(v))
                return SetHint(lblHintMatKhau, "Bắt buộc nhập mật khẩu.", false);
            if (v.Length < 6)
                return SetHint(lblHintMatKhau, "Ít nhất 6 ký tự.", false);
            return SetHint(lblHintMatKhau, "✔", true);
        }

        private bool ValidateXacNhan()
        {
            if (string.IsNullOrEmpty(txtXacNhanMatKhau.Text))
                return SetHint(lblHintXacNhan, "Bắt buộc xác nhận mật khẩu.", false);
            if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
                return SetHint(lblHintXacNhan, "Mật khẩu xác nhận không khớp.", false);
            return SetHint(lblHintXacNhan, "✔", true);
        }

        private bool ValidateHoTen()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                return SetHint(lblHintHoTen, "Bắt buộc nhập họ và tên.", false);
            return SetHint(lblHintHoTen, "✔", true);
        }

        private bool ValidateEmail()
        {
            string v = txtEmail.Text.Trim();
            if (!Regex.IsMatch(v, @"^[^@]+@[^@]+\.[^@]+$"))
                return SetHint(lblHintEmail, "Email không hợp lệ. (VD: ten@gmail.com)", false);
            return SetHint(lblHintEmail, "✔", true);
        }

        private bool ValidateSdt()
        {
            string sdt = LaySoDienThoaiThuanSo();
            if (sdt.Length < 9 || sdt.Length > 15)
                return SetHint(lblHintSdt, "Số điện thoại cần 9–15 chữ số.", false);
            return SetHint(lblHintSdt, "✔", true);
        }

        private bool ValidateDiaChi()
        {
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                return SetHint(lblHintDiaChi, "Bắt buộc nhập địa chỉ.", false);
            return SetHint(lblHintDiaChi, "✔", true);
        }

        // ══════════════════════════════════════════════════════════════════
        // HELPER
        // ══════════════════════════════════════════════════════════════════
        private bool SetHint(Label hint, string message, bool isValid)
        {
            hint.Text = message;
            hint.ForeColor = isValid ? ColorOk : ColorError;
            return isValid;
        }

        private void ShowStatus(string msg, Color color)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = color;
        }

        private string LaySoDienThoaiThuanSo()
            => Regex.Replace(mtbSoDienThoai.Text ?? string.Empty, @"[^0-9]", "");
    }
}