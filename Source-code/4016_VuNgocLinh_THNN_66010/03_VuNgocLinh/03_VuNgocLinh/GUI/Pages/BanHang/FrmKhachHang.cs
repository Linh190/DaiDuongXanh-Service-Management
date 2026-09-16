using _03_VuNgocLinh.BUS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using _03_VuNgocLinh.DAL;

namespace _03_VuNgocLinh.GUI.Pages.BanHang
{
    public partial class FrmKhachHang : Form
    {
        private readonly KhachHangBUS _bus = new KhachHangBUS();

        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            InitComboBox();
            LoadTatCaKhachHang();
            ResetForm();
        }

        private void InitComboBox()
        {
            cbbTrangThai.Items.Clear();
            cbbTrangThai.Items.Add("Hoạt động");
            cbbTrangThai.Items.Add("Khóa");

            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
            cbbGioiTinh.Items.Add("Khác");

            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("Khác");

            cboTrangThaiKH.Items.Clear();
            cboTrangThaiKH.Items.Add("Hoạt động");
            cboTrangThaiKH.Items.Add("Khóa");
        }

        private void LoadTatCaKhachHang()
        {
            DataTable dt = _bus.GetAllTable();
            gridKetQua.DataSource = null;
            gridKetQua.DataSource = dt;
            gridKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblTongCong.Text = "Tổng cộng: " + dt.Rows.Count + " khách hàng";
        }

        private void ResetForm()
        {
            chkMaKH.Checked = true;
            chkTenKH.Checked = false;
            chkGioiTinh.Checked = false;
            chkTrangThai.Checked = false;

            txtMaKhachHang.Clear();
            textBox2.Clear();
            txHoTen.Clear();
            textBox1.Clear();

            cboGioiTinh.SelectedIndex = -1;
            cbbGioiTinh.SelectedIndex = -1;
            cboTrangThaiKH.SelectedIndex = -1;
            cbbTrangThai.SelectedIndex = -1;

            txtTenDangNhap.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();

            dtpNgayTao.Value = DateTime.Today;
            dtpNgaySinh.Value = DateTime.Today;

            LoadTatCaKhachHang();
        }

        private bool ValidateDetailInput()
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng.");
                textBox2.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng.");
                textBox1.Focus();
                return false;
            }
            if (cbbTrangThai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái khách hàng.");
                cbbTrangThai.Focus();
                return false;
            }
            return true;
        }

        // ----------------------------------------------------------------
        // TÌM KIẾM — chỉ dùng cột thực có trong bảng KhachHang
        // Bỏ filter GIOITINHKH vì cột không tồn tại trong schema
        // ----------------------------------------------------------------
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder(@"
SELECT KH.MAKH          AS maKhachHang,
       TK.TENDANGNHAP   AS tenDangNhap,
       KH.TENKH         AS hoTen,
       KH.EMAILKH       AS email,
       KH.DIACHIKH      AS diaChi,
       KH.DIENTHOAIKH   AS soDienThoai,
       KH.TRANGTHAI     AS loaiKhachHang,
       KH.NGAYDANGKY    AS ngayTao
FROM KhachHang KH
LEFT JOIN TaiKhoan TK ON TK.MAKH = KH.MAKH
WHERE 1 = 1");

            var cmd = new SqlCommand();

            string Pick(params string[] values)
            {
                foreach (var v in values)
                    if (!string.IsNullOrWhiteSpace(v)) return v.Trim();
                return null;
            }

            if (chkMaKH.Checked)
            {
                string ma = Pick(txtMaKhachHang?.Text, textBox2?.Text);
                if (!string.IsNullOrWhiteSpace(ma))
                {
                    sql.Append(" AND KH.MAKH LIKE @maKhachHang");
                    cmd.Parameters.AddWithValue("@maKhachHang", "%" + ma + "%");
                }
            }

            if (chkTenKH.Checked)
            {
                string ten = Pick(txHoTen?.Text, textBox1?.Text);
                if (!string.IsNullOrWhiteSpace(ten))
                {
                    sql.Append(" AND KH.TENKH LIKE @hoTen");
                    cmd.Parameters.AddWithValue("@hoTen", "%" + ten + "%");
                }
            }

            // chkGioiTinh: bảng KhachHang không có cột GIOITINHKH → bỏ qua

            if (chkTrangThai.Checked)
            {
                string loai = Pick(cboTrangThaiKH?.SelectedItem?.ToString(),
                                   cbbTrangThai?.SelectedItem?.ToString());
                if (!string.IsNullOrWhiteSpace(loai))
                {
                    sql.Append(" AND KH.TRANGTHAI = @loaiKhachHang");
                    cmd.Parameters.AddWithValue("@loaiKhachHang", loai.Trim());
                }
            }

            sql.Append(" ORDER BY KH.MAKH");

            DataTable dt;
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnectionString))
            {
                cmd.Connection = conn;
                cmd.CommandText = sql.ToString();
                var da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }

            gridKetQua.DataSource = dt;
            lblTongCong.Text = "Tổng cộng: " + dt.Rows.Count + " khách hàng";
        }

        private void btnDatLai_Click(object sender, EventArgs e) => ResetForm();
        private void btnXemTatCa_Click(object sender, EventArgs e) => LoadTatCaKhachHang();

        // ----------------------------------------------------------------
        // THÊM — gọi BUS.Create (BUS gọi DAL.InsertWithOptionalAccount)
        // ----------------------------------------------------------------
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateDetailInput()) return;

            string maKh = textBox2.Text.Trim();
            string tenKh = textBox1.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string trangThai = cbbTrangThai.SelectedItem?.ToString();
            DateTime ngayTao = dtpNgayTao.Value.Date;
            string tenDangNhap = string.IsNullOrWhiteSpace(txtTenDangNhap.Text)
                                    ? null
                                    : txtTenDangNhap.Text.Trim();

            try
            {
                bool ok = _bus.Create(maKh, tenKh, diaChi, sdt, email, trangThai, ngayTao, tenDangNhap);
                if (ok)
                {
                    MessageBox.Show("Thêm khách hàng thành công.");
                    LoadTatCaKhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message);
            }
        }

        // ----------------------------------------------------------------
        // SỬA — gọi BUS.Update
        // ----------------------------------------------------------------
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateDetailInput()) return;

            string maKh = textBox2.Text.Trim();
            string tenKh = textBox1.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string trangThai = cbbTrangThai.SelectedItem?.ToString();

            try
            {
                bool ok = _bus.Update(maKh, tenKh, diaChi, sdt, email, trangThai);
                if (ok)
                {
                    MessageBox.Show("Sửa khách hàng thành công.");
                    LoadTatCaKhachHang();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa khách hàng: " + ex.Message);
            }
        }

        // ----------------------------------------------------------------
        // XÓA — gọi BUS.Delete
        // ----------------------------------------------------------------
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                bool ok = _bus.Delete(textBox2.Text.Trim());
                if (ok)
                {
                    MessageBox.Show("Xóa khách hàng thành công.");
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng cần xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa khách hàng: " + ex.Message);
            }
        }

        // ----------------------------------------------------------------
        // CLICK DÒNG TRÊN GRID — chỉ đọc cột thực có trong kết quả
        // Bỏ ngaySinh, gioiTinh vì không còn trong SELECT
        // ----------------------------------------------------------------
        private void gridKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = gridKetQua.Rows[e.RowIndex];

            textBox2.Text = Convert.ToString(row.Cells["maKhachHang"].Value);
            txtTenDangNhap.Text = Convert.ToString(row.Cells["tenDangNhap"].Value);
            textBox1.Text = Convert.ToString(row.Cells["hoTen"].Value);
            txtSoDienThoai.Text = Convert.ToString(row.Cells["soDienThoai"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["email"].Value);
            txtDiaChi.Text = Convert.ToString(row.Cells["diaChi"].Value);

            string loai = Convert.ToString(row.Cells["loaiKhachHang"].Value);
            cbbTrangThai.SelectedIndex = cbbTrangThai.Items.IndexOf(loai);

            if (DateTime.TryParse(Convert.ToString(row.Cells["ngayTao"].Value), out DateTime ngayTao))
                dtpNgayTao.Value = ngayTao;

            // ngaySinh và gioiTinh không có trong schema KhachHang
            // → reset về giá trị mặc định cho rõ ràng
            dtpNgaySinh.Value = DateTime.Today;
            cbbGioiTinh.SelectedIndex = -1;
        }

        // Empty handlers giữ nguyên để Designer không báo lỗi
        private void label2_Click(object sender, EventArgs e) { }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void chkMaKH_CheckedChanged(object sender, EventArgs e) { }
        private void txtMaKhachHang_TextChanged(object sender, EventArgs e) { }
        private void txHoTen_TextChanged(object sender, EventArgs e) { }
        private void chkTenKH_CheckedChanged(object sender, EventArgs e) { }
        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e) { }
        private void chkGioiTinh_CheckedChanged(object sender, EventArgs e) { }
        private void cbbLoaiKhachHang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void chkLoaiKH_CheckedChanged(object sender, EventArgs e) { }
        private void lblTongCong_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void txtTenDangNhap_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtSoDienThoai_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtDiaChi_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpNgayTao_ValueChanged(object sender, EventArgs e) { }
        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e) { }
        private void cbbGioiTinh_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbbTrangThai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboTrangThaiKH_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}