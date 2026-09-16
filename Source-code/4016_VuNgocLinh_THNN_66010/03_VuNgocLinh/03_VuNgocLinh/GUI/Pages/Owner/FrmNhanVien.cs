using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    public partial class FrmNhanVien : Form
    {
        private readonly NhanVienBUS _bus = new NhanVienBUS();
        private DataTable _fullTable;          // bảng gốc để filter
        private string _selectedMaNV;       // NV đang chọn
        private DataRow _originalRow;        // để reset

        public FrmNhanVien() => InitializeComponent();

        // ─── Load ─────────────────────────────────────────────────
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadRoleFilter();
            ConfigureDataGrid();
            LoadData();
            ClearDetail();
        }

        private void ApplyTheme()
        {
            pnlHeader.BackColor = UITheme.Navy;
            lblTitle.ForeColor = Color.White;
            lblCount.ForeColor = Color.FromArgb(187, 222, 251);
            pnlDetailHeader.BackColor = UITheme.Navy;
            lblDetailHeader.ForeColor = Color.White;
            pnlDetailBody.BackColor = UITheme.Surface;
            pnlDetail.BackColor = UITheme.Surface;
            pnlSearch.BackColor = UITheme.Surface;

            UITheme.ApplyPrimaryButton(btnLuu);
            UITheme.ApplyGhostButton(btnDatLai);
            UITheme.ApplyGhostButton(btnReset);
            UITheme.ApplyPrimaryButton(btnTimKiem);

            // btnXoa và btnThem giữ màu riêng (đỏ/xanh), không override bằng theme chung
            UITheme.ApplyTextBox(txtTimKiem);
            UITheme.ApplyTextBox(txtHoTen);
            UITheme.ApplyTextBox(txtEmail);
            UITheme.ApplyTextBox(txtSDT);
            UITheme.ApplyTextBox(txtDiaChi);
            UITheme.ApplyComboBox(cboLocVaiTro);
            UITheme.ApplyComboBox(cboLocTrangThai);
            UITheme.ApplyComboBox(cboVaiTro);

            btnToggle.BackColor = UITheme.Teal;
            btnToggle.ForeColor = Color.White;
            btnToggle.FlatAppearance.BorderSize = 0;
        }

        private void ConfigureDataGrid()
        {
            UITheme.ApplyDataGrid(dgvNhanVien);
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.Columns.Clear();

            // Tên cột DataPropertyName = alias từ NhanVienDAL.GetAll()
            dgvNhanVien.Columns.AddRange(
                Col("colMaNV", "maNhanVien", "Mã NV", 75, false),
                Col("colTenDN", "tenDangNhap", "Tên đăng nhập", 130, false),
                Col("colHoTen", "hoTen", "Họ và tên", 0, true),   // Fill
                Col("colEmail", "email", "Email", 175, false),
                Col("colSDT", "soDienThoai", "SĐT", 105, false),
                Col("colVaiTro", "vaiTro", "Vai trò", 155, false),
                Col("colTS", "TRANGTHAI", "Trạng thái", 115, false));
        }

        private static DataGridViewTextBoxColumn Col(string name, string prop,
            string header, int w, bool fill)
        {
            var c = new DataGridViewTextBoxColumn
            {
                Name = name,
                DataPropertyName = prop,
                HeaderText = header,
            };
            if (fill)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                c.MinimumWidth = 150;
            }
            else
            {
                c.Width = w;
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            return c;
        }

        private void LoadRoleFilter()
        {
            // --- Filter: Vai trò ---
            cboLocVaiTro.Items.Clear();
            cboLocVaiTro.Items.Add("-- Tất cả --");
            cboLocVaiTro.Items.Add("Nhân viên bán hàng");
            cboLocVaiTro.Items.Add("Nhân viên văn phòng");
            cboLocVaiTro.Items.Add("Nhân viên quản lý hệ thống");
            cboLocVaiTro.Items.Add("Chủ doanh nghiệp");
            cboLocVaiTro.SelectedIndex = 0;

            // --- Filter: Trạng thái (giá trị khớp CK_NhanVien_TRANGTHAI trong DB) ---
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.Add("-- Tất cả --");
            cboLocTrangThai.Items.Add("Đang làm việc");
            cboLocTrangThai.Items.Add("Nghỉ việc");
            cboLocTrangThai.SelectedIndex = 0;

            // --- Detail panel: Vai trò (khớp CK_NhanVien_VAITRO trong DB) ---
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("Nhân viên bán hàng");
            cboVaiTro.Items.Add("Nhân viên văn phòng");
            cboVaiTro.Items.Add("Nhân viên quản lý hệ thống");
            cboVaiTro.Items.Add("Chủ doanh nghiệp");
        }

        // ─── Load & Filter ────────────────────────────────────────
        private void LoadData()
        {
            try
            {
                _fullTable = _bus.GetAllTable();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu nhân viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            if (_fullTable == null) return;

            string keyword = txtTimKiem.Text.Trim().ToLowerInvariant();
            string vaiTro = cboLocVaiTro.SelectedIndex <= 0
                              ? null : cboLocVaiTro.SelectedItem.ToString();
            string trangThai = cboLocTrangThai.SelectedIndex <= 0
                              ? null : cboLocTrangThai.SelectedItem.ToString();

            var view = _fullTable.DefaultView;
            var filters = new System.Collections.Generic.List<string>();

            if (!string.IsNullOrWhiteSpace(keyword))
                filters.Add($"(Convert(maNhanVien,'System.String') LIKE '%{keyword}%'" +
                            $" OR Convert(hoTen,'System.String') LIKE '%{keyword}%'" +
                            $" OR Convert(tenDangNhap,'System.String') LIKE '%{keyword}%')");
            if (vaiTro != null)
                filters.Add($"vaiTro = '{vaiTro}'");
            if (trangThai != null)
                filters.Add($"TRANGTHAI = '{trangThai}'");

            view.RowFilter = string.Join(" AND ", filters);
            dgvNhanVien.DataSource = view;

            ApplyRowColors();
            lblCount.Text = $"Hiển thị: {view.Count} / {_fullTable.Rows.Count} nhân viên";
        }

        private void ApplyRowColors()
        {
            foreach (DataGridViewRow r in dgvNhanVien.Rows)
            {
                if (r.IsNewRow) continue;
                var cell = r.Cells["colTS"];
                if (cell?.Value?.ToString() == "Đang làm việc")
                {
                    cell.Style.ForeColor = UITheme.Success;
                    cell.Style.BackColor = UITheme.SuccessLight;
                    cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
                else
                {
                    cell.Style.ForeColor = UITheme.Danger;
                    cell.Style.BackColor = UITheme.DangerLight;
                    cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
            }
        }

        // ─── Selection → Detail panel ────────────────────────────
        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;
            var row = (dgvNhanVien.CurrentRow.DataBoundItem as DataRowView)?.Row;
            if (row == null) return;

            _selectedMaNV = row["maNhanVien"]?.ToString();
            _originalRow = row;
            PopulateDetail(row);
        }

        private void PopulateDetail(DataRow row)
        {
            lblMaNV.Text = row["maNhanVien"]?.ToString() ?? "—";
            lblTenDN.Text = row["tenDangNhap"]?.ToString() ?? "(chưa có TK)";
            txtHoTen.Text = row["hoTen"]?.ToString() ?? "";
            txtEmail.Text = row["email"]?.ToString() ?? "";
            txtSDT.Text = row["soDienThoai"]?.ToString() ?? "";
            txtDiaChi.Text = row["diaChi"]?.ToString() ?? "";

            // Vai trò – chọn đúng item
            string vaiTro = row["vaiTro"]?.ToString() ?? "";
            cboVaiTro.SelectedItem = cboVaiTro.Items.Contains(vaiTro) ? (object)vaiTro : null;

            // Ngày vào làm
            lblNgayVaoVal.Text = row["NGAYVAOLV"] != DBNull.Value
                ? Convert.ToDateTime(row["NGAYVAOLV"]).ToString("dd/MM/yyyy")
                : "—";

            // Trạng thái với màu
            string ts = row["TRANGTHAI"]?.ToString() ?? "—";
            bool active = ts == "Đang làm việc";
            lblTrangThaiVal.Text = active ? "✔ Đang làm việc" : "✖ Nghỉ việc";
            lblTrangThaiVal.ForeColor = active ? UITheme.Success : UITheme.Danger;

            // Nút toggle
            btnToggle.Text = active
                ? "⏸  Chuyển sang Nghỉ việc"
                : "▶  Kích hoạt lại – Đang làm việc";
            btnToggle.BackColor = active ? UITheme.Warning : UITheme.Teal;
        }

        private void ClearDetail()
        {
            _selectedMaNV = null;
            _originalRow = null;
            lblMaNV.Text = "— Chưa chọn nhân viên —";
            lblTenDN.Text = "—";
            txtHoTen.Text = txtEmail.Text = txtSDT.Text = txtDiaChi.Text = "";
            cboVaiTro.SelectedIndex = -1;
            lblNgayVaoVal.Text = "—";
            lblTrangThaiVal.Text = "—";
            lblTrangThaiVal.ForeColor = UITheme.TextLight;
        }

        // ─── Search events ────────────────────────────────────────
        private void btnTimKiem_Click(object sender, EventArgs e) => ApplyFilter();

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocVaiTro.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;
            ApplyFilter();
        }

        private void Filter_Changed(object sender, EventArgs e) => ApplyFilter();

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ApplyFilter();
        }

        private void pnlSearch_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(UITheme.Border, 1))
                e.Graphics.DrawLine(pen, 0, pnlSearch.Height - 1,
                    pnlSearch.Width, pnlSearch.Height - 1);
        }

        // ─── Lưu thay đổi ────────────────────────────────────────
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!HasSelection()) return;
            if (!ValidateDetail()) return;

            try
            {
                bool ok = _bus.UpdateNhanVien(
                    _selectedMaNV,
                    txtHoTen.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtSDT.Text.Trim(),
                    txtDiaChi.Text.Trim(),
                    cboVaiTro.SelectedItem?.ToString());

                if (ok)
                {
                    MessageBox.Show($"Cập nhật thông tin nhân viên {_selectedMaNV} thành công.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // refresh grid
                }
                else
                    MessageBox.Show("Không tìm thấy nhân viên để cập nhật.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            if (_originalRow != null) PopulateDetail(_originalRow);
        }

        // ─── Toggle trạng thái ────────────────────────────────────
        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (!HasSelection()) return;

            string current = lblTrangThaiVal.Text.Contains("Đang") ? "Đang làm việc" : "Nghỉ việc";
            string newState = current == "Đang làm việc" ? "Nghỉ việc" : "Đang làm việc";

            string confirm = newState == "Nghỉ việc"
                ? $"Bạn có chắc muốn chuyển nhân viên {_selectedMaNV} sang 'Nghỉ việc'?\n" +
                  "Tài khoản đăng nhập của họ sẽ không thể đăng nhập được nữa."
                : $"Kích hoạt lại nhân viên {_selectedMaNV} sang 'Đang làm việc'?";

            if (MessageBox.Show(confirm, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            try
            {
                DataProvider.ExecuteNonQuery(
                    "UPDATE NhanVien SET TRANGTHAI = @ts WHERE MANV = @ma",
                    new SqlParameter("@ts", newState),
                    new SqlParameter("@ma", _selectedMaNV));

                // Đồng bộ trạng thái TaiKhoan
                if (newState == "Nghỉ việc")
                    DataProvider.ExecuteNonQuery(
                        "UPDATE TaiKhoan SET TRANGTHAI = N'Khóa' WHERE MANV = @ma",
                        new SqlParameter("@ma", _selectedMaNV));
                else
                    DataProvider.ExecuteNonQuery(
                        "UPDATE TaiKhoan SET TRANGTHAI = N'Hoạt động' WHERE MANV = @ma",
                        new SqlParameter("@ma", _selectedMaNV));

                MessageBox.Show($"Đã cập nhật trạng thái nhân viên {_selectedMaNV} → {newState}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi trạng thái: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Xóa nhân viên ───────────────────────────────────────
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!HasSelection()) return;

            string tenNV = txtHoTen.Text.Trim();
            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn XÓA nhân viên [{_selectedMaNV}] {tenNV} không?\n\n" +
                "⚠ Lưu ý: Chỉ xóa được nhân viên chưa có tài khoản và chưa có dữ liệu liên quan.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var (ok, error) = _bus.XoaNhanVien(_selectedMaNV);
                if (ok)
                {
                    MessageBox.Show($"Đã xóa nhân viên [{_selectedMaNV}] {tenNV} thành công.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearDetail();
                    LoadData();
                }
                else
                {
                    MessageBox.Show(error ?? "Không thể xóa nhân viên này.",
                        "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Thêm nhân viên mới ───────────────────────────────────
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmThemNhanVien(_bus))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show(
                        $"Đã thêm nhân viên mới [{dlg.MaNVMoi}] thành công!\n\n" +
                        "📌 Nhân viên chưa có tài khoản. Để cấp tài khoản, hãy yêu cầu Admin tạo tài khoản cho nhân viên này.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        // ─── Validation & helpers ─────────────────────────────────
        private bool HasSelection()
        {
            if (string.IsNullOrWhiteSpace(_selectedMaNV))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách.",
                    "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private bool ValidateDetail()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus(); return false;
            }
            return true;
        }
    }
}