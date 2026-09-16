using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Popups
{
    public partial class FrmThaydoithongtinKH : Form
    {
        private readonly KhachHangBUS _khBus = new KhachHangBUS();
        private string _maKh = null;
        private string _originalUsername = null;

        public FrmThaydoithongtinKH() 
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create form for editing specific customer by MAKH.
        /// </summary>
        public FrmThaydoithongtinKH(string maKh) : this()
        {
            _maKh = maKh;
            this.Load += (s, e) => LoadData();
        }

        private void FrmThaydoithongtinKH_Load(object sender, EventArgs e)
        {
            // If constructed without MAKH, do nothing until caller sets fields manually.
            if (!string.IsNullOrWhiteSpace(_maKh))
                LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_maKh))
                    return;

                DataRow r = _khBus.GetById(_maKh);
                if (r == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                txtMaKH.Text = Convert.ToString(r["maKhachHang"]);
                txtHoTen.Text = Convert.ToString(r["hoTen"]);
                txtDiaChi.Text = Convert.ToString(r["diaChi"]);
                txtSDT.Text = Convert.ToString(r["soDienThoai"]);
                txtEmail.Text = Convert.ToString(r["email"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    MessageBox.Show("Mã khách hàng không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validation
                string diaChi = txtDiaChi.Text?.Trim() ?? string.Empty;
                string email = txtEmail.Text?.Trim() ?? string.Empty;
                string sdtRaw = txtSDT.Text?.Trim() ?? string.Empty;
                string sdt = Regex.Replace(sdtRaw, @"[^0-9]", "");

                if (string.IsNullOrWhiteSpace(diaChi))
                {
                    MessageBox.Show("Vui lòng nhập Địa chỉ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return;
                }

                // Email validation
                if (!Regex.IsMatch(email, @"^[^@]+@[^@]+\.[^@]+$"))
                {
                    MessageBox.Show("Email không hợp lệ! (Ví dụ: ten@email.com)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                // Phone validation: 9-15 digits
                if (sdt.Length < 9 || sdt.Length > 15)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ! (9–15 chữ số)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                // Update KhachHang
                bool khOk = _khBus.Update(txtMaKH.Text.Trim(), txtHoTen.Text.Trim(), diaChi, sdt, email);
                if (!khOk)
                {
                    MessageBox.Show("Cập nhật thông tin Khách hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // Update password if provided (store as-is, DAL expects "hash" field; existing code stores plain text in examples)

                MessageBox.Show("Cập nhật thông tin thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Designer event stubs (no-op)
        private void txtMaKH_TextChanged(object sender, EventArgs e) { }
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void txtMatKhau_TextChanged(object sender, EventArgs e) { }
        private void txtTenDangNhap_TextChanged(object sender, EventArgs e) { }
        private void txtDiaChi_TextChanged(object sender, EventArgs e) { }
        private void txtSDT_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
