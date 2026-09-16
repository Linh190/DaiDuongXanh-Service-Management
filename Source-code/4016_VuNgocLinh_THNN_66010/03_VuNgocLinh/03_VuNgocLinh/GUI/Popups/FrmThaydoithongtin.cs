using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Popups
{
    public partial class FrmThaydoithongtin : Form
    {
        private readonly NhanVienBUS _nvBus = new NhanVienBUS();
        private string _maNv;
        private string _originalUsername;

        public FrmThaydoithongtin()
        {
            InitializeComponent();
        }

        public FrmThaydoithongtin(string maNv, string initialUsername = null) : this()
        {
            _maNv = maNv;
            _originalUsername = initialUsername;
            this.Load += FrmThaydoithongtin_Load;
        }

        private void FrmThaydoithongtin_Load(object sender, EventArgs e)
        {
            try
            {
                // Populate gender choices
                cbGioiTinh.Items.Clear();
                cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
                cbGioiTinh.SelectedIndex = -1;

                // If called with an employee id, load data
                if (!string.IsNullOrWhiteSpace(_maNv))
                    LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                DataRow r = _nvBus.GetById(_maNv);
                if (r == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                txtHoTen.Text = Convert.ToString(r["TENNV"]);
                txtEmail.Text = Convert.ToString(r["EMAILNV"]);
                txtDiaChi.Text = Convert.ToString(r["DIACHINV"]);
                txtSDT.Text = Convert.ToString(r["SDTNV"]);
                txtVaitro.Text = Convert.ToString(r["VAITRO"]);

                if (r["NGAYVAOLV"] != DBNull.Value)
                {
                    DateTime nvDate = Convert.ToDateTime(r["NGAYVAOLV"]);
                    dtpNgayVaoLam.Value = nvDate;
                }

                // Try to find the username in TaiKhoan (if any)
                object uname = DataProvider.ExecuteScalar(
                    "SELECT TENDANGNHAP FROM TaiKhoan WHERE MANV = @manv",
                    new SqlParameter("@manv", _maNv));
                txtTenDangNhap.Text = uname?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(_originalUsername))
                    _originalUsername = txtTenDangNhap.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_maNv))
                {
                    MessageBox.Show("Không có mã nhân viên để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string hoTen = txtHoTen.Text?.Trim() ?? string.Empty;
                string email = txtEmail.Text?.Trim() ?? string.Empty;
                string diaChi = txtDiaChi.Text?.Trim() ?? string.Empty;
                string sdtRaw = txtSDT.Text?.Trim() ?? string.Empty;
                string sdt = Regex.Replace(sdtRaw, @"[^0-9]", "");
                string vaiTro = txtVaitro.Text?.Trim() ?? string.Empty;
                DateTime ngaySinh = dtNgaysinh.Value.Date;
                DateTime ngayVaoLam = dtpNgayVaoLam.Value.Date;
                string tenDangNhapNew = txtTenDangNhap.Text?.Trim() ?? string.Empty;

                // Basic validation
                if (string.IsNullOrWhiteSpace(hoTen))
                {
                    MessageBox.Show("Vui lòng nhập Họ và tên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }

                if (!Regex.IsMatch(email, @"^[^@]+@[^@]+\.[^@]+$"))
                {
                    MessageBox.Show("Email không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (sdt.Length < 9 || sdt.Length > 15)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ (9–15 chữ số).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                if (ngaySinh != DateTime.MinValue && ngaySinh >= ngayVaoLam)
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày vào làm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtNgaysinh.Focus();
                    return;
                }

                // Update NhanVien
                bool ok = _nvBus.UpdateNhanVien(_maNv, hoTen, email, sdt, diaChi, vaiTro);
                if (!ok)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If username changed, update TaiKhoan (check uniqueness)
                if (!string.Equals(_originalUsername ?? string.Empty, tenDangNhapNew, StringComparison.Ordinal))
                {
                    if (!string.IsNullOrWhiteSpace(tenDangNhapNew))
                    {
                        object exists = DataProvider.ExecuteScalar(
                            "SELECT 1 FROM TaiKhoan WHERE TENDANGNHAP = @u",
                            new SqlParameter("@u", tenDangNhapNew));
                        if (exists != null)
                        {
                            MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenDangNhap.Focus();
                            return;
                        }

                        int rows = DataProvider.ExecuteNonQuery(
                            "UPDATE TaiKhoan SET TENDANGNHAP = @new WHERE MANV = @manv",
                            new SqlParameter("@new", tenDangNhapNew),
                            new SqlParameter("@manv", _maNv));
                        if (rows <= 0)
                        {
                            MessageBox.Show("Không thể cập nhật tên đăng nhập (tài khoản có thể không tồn tại).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        // If new username is empty, we simply skip updating (avoid blank username)
                    }
                }

                MessageBox.Show("Cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Designer stubs (no-op)
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtTenDangNhap_TextChanged(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtNgaysinh_ValueChanged(object sender, EventArgs e) { }
        private void txtDiaChi_TextChanged(object sender, EventArgs e) { }
        private void txtSDT_TextChanged(object sender, EventArgs e) { }
        private void dtpNgayVaoLam_ValueChanged(object sender, EventArgs e) { }
    }
}
