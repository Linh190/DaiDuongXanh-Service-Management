using _03_VuNgocLinh.BUS;
using System;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    /// <summary>
    /// Dialog thêm nhân viên mới (chỉ thông tin, chưa tạo tài khoản).
    /// Chủ doanh nghiệp dùng. MANV được sinh tự động.
    /// </summary>
    public partial class FrmThemNhanVien : Form
    {
        private readonly NhanVienBUS _bus;

        /// <summary>Mã NV vừa được tạo, đọc sau khi DialogResult == OK.</summary>
        public string MaNVMoi { get; private set; }

        public FrmThemNhanVien(NhanVienBUS bus)
        {
            _bus = bus;
            InitializeComponent();
        }

        private void FrmThemNhanVien_Load(object sender, EventArgs e)
        {
            // Sinh mã NV và hiển thị
            string maSinh = _bus.GenerateNewMaNV();
            lblMaNVVal.Text = maSinh + "  (tự động)";

            // Vai trò
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("Nhân viên bán hàng");
            cboVaiTro.Items.Add("Nhân viên văn phòng");
            cboVaiTro.Items.Add("Nhân viên quản lý hệ thống");
            cboVaiTro.Items.Add("Chủ doanh nghiệp");
            cboVaiTro.SelectedIndex = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus(); return;
            }
            if (cboVaiTro.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn vai trò.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVaiTro.Focus(); return;
            }

            try
            {
                // Sinh lại mã để tránh race condition
                string maNV = _bus.GenerateNewMaNV();
                MaNVMoi = maNV;

                bool ok = _bus.ThemNhanVien(
                    maNV,
                    txtHoTen.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtSDT.Text.Trim(),
                    txtDiaChi.Text.Trim(),
                    cboVaiTro.SelectedItem.ToString());

                if (ok)
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Không thể thêm nhân viên. Vui lòng thử lại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}