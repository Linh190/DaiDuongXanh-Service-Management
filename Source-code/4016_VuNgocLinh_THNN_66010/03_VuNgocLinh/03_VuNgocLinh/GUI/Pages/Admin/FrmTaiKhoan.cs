using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.GUI.Popups;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    public partial class FrmTaiKhoan : Form
    {
        // ── State ────────────────────────────────────────────────────────
        private bool isAdding = false;
        private string selectedMatk = null;
        private string selectedMaNV = null;   // NV được chọn từ popup (Add mode)

        public FrmTaiKhoan()
        {
            InitializeComponent();
            this.Load += FrmTaiKhoan_Load;
        }

        // ─────────────────────────────────────────────────────────────────
        // KHỞI TẠO
        // ─────────────────────────────────────────────────────────────────
        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            this.taiKhoanTableAdapter.Fill(this.quanLyDichVu_DaiDuongXanhDataSet.TaiKhoan);
            try
            {
                CauHinhForm();
                KhoiTaoBang();
                NapComboLoaiTaiKhoan();
                NapComboEdit();

                gridKetQua.CellClick += GridKetQua_CellClick;
                gridKetQua.SelectionChanged += GridKetQua_SelectionChanged;

                TaiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CauHinhForm()
        {
            txtMatKhau.PasswordChar = '●';
            SetEditPanelEnabled(false);

            chkTen.Checked = false;
            chkLoaiTK.Checked = false;
            txtTen.Enabled = false;
            cboLoaiTK.Enabled = false;

            // Panel thông tin NV được chọn — ẩn lúc đầu
            pnlNhanVienChon.Visible = false;
        }

        private void KhoiTaoBang()
        {
            if (gridKetQua == null) return;

            gridKetQua.AutoGenerateColumns = false;
            gridKetQua.ReadOnly = true;
            gridKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridKetQua.AllowUserToAddRows = false;
            gridKetQua.AllowUserToDeleteRows = false;
            gridKetQua.MultiSelect = false;
            gridKetQua.Columns.Clear();

            gridKetQua.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colTenDangNhap", HeaderText = "Tên đăng nhập", DataPropertyName = "tenDangNhap", Width = 180 });
            gridKetQua.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colLoaiTaiKhoan", HeaderText = "Loại TK", DataPropertyName = "loaiTaiKhoan", Width = 160 });
            gridKetQua.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colTrangThai", HeaderText = "Trạng thái", DataPropertyName = "trangThai", Width = 120 });
            gridKetQua.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colTenNguoiDung", HeaderText = "Người dùng", DataPropertyName = "tenNguoiDung", Width = 200 });
            gridKetQua.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colMaTaiKhoan", HeaderText = "MãTK", DataPropertyName = "maTaiKhoan", Visible = false });
        }

        private void NapComboLoaiTaiKhoan()
        {
            cboLoaiTK.Items.Clear();
            cboLoaiTK.Items.AddRange(new object[]
            {
                "-- Tất cả --",
                "Khách hàng",
                "Nhân viên bán hàng",
                "Nhân viên văn phòng",
                "Nhân viên quản lý hệ thống",
                "Chủ doanh nghiệp"
            });
            cboLoaiTK.SelectedIndex = 0;
        }

        private void NapComboEdit()
        {
            cboVaiTroEdit.Items.Clear();
            cboVaiTroEdit.Items.AddRange(new object[]
            {
                "Nhân viên bán hàng",
                "Nhân viên văn phòng",
                "Nhân viên quản lý hệ thống",
                "Chủ doanh nghiệp"
            });

            cboTrangThaiEdit.Items.Clear();
            cboTrangThaiEdit.Items.AddRange(new object[] { "Hoạt động", "Khóa" });
        }

        // ─────────────────────────────────────────────────────────────────
        // TẢI DỮ LIỆU
        // ─────────────────────────────────────────────────────────────────
        private void TaiDuLieu()
        {
            try
            {
                string sql = @"
SELECT tk.MATK          AS maTaiKhoan,
       tk.TENDANGNHAP   AS tenDangNhap,
       tk.LOAITAIKHOAN  AS loaiTaiKhoan,
       tk.TRANGTHAI     AS trangThai,
       ISNULL(kh.TENKH, nv.TENNV) AS tenNguoiDung,
       tk.MAKH, tk.MANV
FROM TaiKhoan tk
LEFT JOIN KhachHang kh ON tk.MAKH = kh.MAKH
LEFT JOIN NhanVien  nv ON tk.MANV = nv.MANV
WHERE 1=1";

                var parameters = new System.Collections.Generic.List<SqlParameter>();

                if (chkTen.Checked && !string.IsNullOrWhiteSpace(txtTen.Text))
                {
                    sql += " AND tk.TENDANGNHAP LIKE @ten";
                    parameters.Add(new SqlParameter("@ten", "%" + txtTen.Text.Trim() + "%"));
                }
                if (chkLoaiTK.Checked && cboLoaiTK.SelectedIndex > 0)
                {
                    sql += " AND tk.LOAITAIKHOAN = @loai";
                    parameters.Add(new SqlParameter("@loai", cboLoaiTK.SelectedItem.ToString()));
                }

                sql += " ORDER BY tk.TENDANGNHAP";

                DataTable dt = DataProvider.ExecuteQuery(sql, parameters.ToArray());
                gridKetQua.DataSource = dt;
                lblTong.Text = $"Tổng: {dt.Rows.Count} tài khoản";

                ClearEditPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải tài khoản: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // PANEL EDIT — helpers
        // ─────────────────────────────────────────────────────────────────
        private void ClearEditPanel()
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboTrangThaiEdit.SelectedIndex = -1;
            cboVaiTroEdit.SelectedIndex = -1;
            lblPhanQuyen.Text = "[Role] — …";

            isAdding = false;
            selectedMatk = null;
            selectedMaNV = null;

            txtTenDangNhap.Enabled = false;
            txtMatKhau.PasswordChar = '●';

            // Ẩn panel NV được chọn
            pnlNhanVienChon.Visible = false;
            lblNVChon.Text = "";
            lblMatKhauRo.Text = "";

            SetEditPanelEnabled(false);
        }

        private void SetEditPanelEnabled(bool enabled)
        {
            cboTrangThaiEdit.Enabled = enabled;
            cboVaiTroEdit.Enabled = enabled;
            txtMatKhau.Enabled = enabled;
            btnLuuThongTin.Enabled = enabled;
            btnHuyBo.Enabled = enabled;
        }

        private void UpdatePhanQuyenLabel()
        {
            lblPhanQuyen.Text =
                $"{(cboVaiTroEdit.SelectedItem ?? "[Role]")} — {(cboTrangThaiEdit.SelectedItem ?? "")}";
        }

        // ─────────────────────────────────────────────────────────────────
        // AUTO-GENERATE username + password
        // ─────────────────────────────────────────────────────────────────
        /// <summary>
        /// Sinh tên đăng nhập dạng nv_ten.ho (bỏ dấu, chữ thường).
        /// Ví dụ: "Nguyễn Văn Anh" → "nv_anh.nguyen"
        /// </summary>
        private static string SinhTenDangNhap(string hoTen, string prefix = "nv")
        {
            if (string.IsNullOrWhiteSpace(hoTen)) return "";

            // Bỏ dấu tiếng Việt
            string normalized = hoTen.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char c in normalized)
            {
                var cat = CharUnicodeInfo.GetUnicodeCategory(c);
                if (cat != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            string noDiacritic = sb.ToString().Normalize(NormalizationForm.FormC).ToLowerInvariant();

            // Regex chỉ giữ a-z và space
            noDiacritic = Regex.Replace(noDiacritic, @"[^a-z\s]", "").Trim();

            // Tách từ: phần tên (token cuối) và họ (token đầu)
            var parts = noDiacritic.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return prefix + "_user";

            string ten = parts[parts.Length - 1];            // từ cuối = tên
            string ho = parts.Length > 1 ? parts[0] : "";  // từ đầu  = họ

            return string.IsNullOrEmpty(ho)
                ? $"{prefix}_{ten}"
                : $"{prefix}_{ten}.{ho}";
        }

        /// <summary>
        /// Sinh mật khẩu ngẫu nhiên 10 ký tự (chữ + số + ký tự đặc biệt).
        /// </summary>
        private static string SinhMatKhau()
        {
            const string chars =
                "abcdefghijklmnopqrstuvwxyz" +
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "0123456789" +
                "@#$!&*";

            var rng = new Random();
            var result = new char[10];
            for (int i = 0; i < 10; i++)
                result[i] = chars[rng.Next(chars.Length)];

            // Đảm bảo ít nhất 1 hoa, 1 thường, 1 số, 1 ký tự đặc biệt
            result[0] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[rng.Next(26)];
            result[1] = "abcdefghijklmnopqrstuvwxyz"[rng.Next(26)];
            result[2] = "0123456789"[rng.Next(10)];
            result[3] = "@#$!&*"[rng.Next(6)];

            // Xáo trộn
            for (int i = result.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var tmp = result[i]; result[i] = result[j]; result[j] = tmp;
            }
            return new string(result);
        }

        private static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                var sb = new StringBuilder();
                foreach (var b in hash) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // EVENT HANDLERS — Filter
        // ─────────────────────────────────────────────────────────────────
        private void chkTen_CheckedChanged(object sender, EventArgs e)
        {
            txtTen.Enabled = chkTen.Checked;
            if (!chkTen.Checked) txtTen.Clear();
            TaiDuLieu();
        }

        private void chkLoaiTK_CheckedChanged(object sender, EventArgs e)
        {
            cboLoaiTK.Enabled = chkLoaiTK.Checked;
            if (!chkLoaiTK.Checked) cboLoaiTK.SelectedIndex = 0;
            TaiDuLieu();
        }

        private void txtTen_TextChanged(object sender, EventArgs e) => TaiDuLieu();
        private void cboLoaiTK_SelectedIndexChanged(object sender, EventArgs e) => TaiDuLieu();

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (chkTen.Checked && string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }
            TaiDuLieu();
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkTen.Checked = false;
            chkLoaiTK.Checked = false;
            txtTen.Clear();
            cboLoaiTK.SelectedIndex = 0;
            TaiDuLieu();
        }

        // ─────────────────────────────────────────────────────────────────
        // THÊM MỚI — mở popup chọn NV, auto-fill
        // ─────────────────────────────────────────────────────────────────
        private void btnThemMoi_Click(object sender, EventArgs e) => MoPopupChonNV();
        private void btnThem_Click(object sender, EventArgs e) => MoPopupChonNV();

        private void MoPopupChonNV()
        {
            using (var popup = new FrmChonNhanVien())
            {
                if (popup.ShowDialog(this) != DialogResult.OK) return;

                // ── Có NV được chọn ────────────────────────────────────
                string maNV = popup.SelectedMaNV;
                string hoTen = popup.SelectedHoTen;
                string vaiTro = popup.SelectedVaiTro;

                // Sinh thông tin đăng nhập tự động
                string tenDangNhap = SinhTenDangNhap(hoTen, "nv");
                string matKhauRaw = SinhMatKhau();

                // Điền vào form chính
                isAdding = true;
                selectedMatk = null;
                selectedMaNV = maNV;

                txtTenDangNhap.Text = tenDangNhap;
                txtTenDangNhap.Enabled = true;   // cho phép admin chỉnh nếu cần

                // Hiện mật khẩu plaintext (không dùng PasswordChar khi Add)
                txtMatKhau.PasswordChar = '\0';
                txtMatKhau.Text = matKhauRaw;

                // Cài vai trò theo NV
                if (cboVaiTroEdit.Items.Contains(vaiTro))
                    cboVaiTroEdit.SelectedItem = vaiTro;
                else
                    cboVaiTroEdit.SelectedIndex = 0;

                cboTrangThaiEdit.SelectedIndex = 0; // Hoạt động

                // Hiện panel thông tin NV được chọn
                pnlNhanVienChon.Visible = true;
                lblNVChon.Text = $"👤  [{maNV}]  {hoTen}";
                lblMatKhauRo.Text =
                    $"Mật khẩu khởi tạo: {matKhauRaw}   " +
                    $"(hãy copy và gửi cho nhân viên)";

                UpdatePhanQuyenLabel();
                SetEditPanelEnabled(true);
                txtTenDangNhap.Focus();
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // XÓA
        // ─────────────────────────────────────────────────────────────────
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridKetQua.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string matk = Convert.ToString(gridKetQua.CurrentRow.Cells["colMaTaiKhoan"].Value);
            string ten = Convert.ToString(gridKetQua.CurrentRow.Cells["colTenDangNhap"].Value);

            if (string.IsNullOrWhiteSpace(matk))
            {
                MessageBox.Show("Không tìm thấy mã tài khoản.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản '{ten}'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                int rows = DataProvider.ExecuteNonQuery(
                    "DELETE FROM TaiKhoan WHERE MATK = @matk",
                    new SqlParameter("@matk", matk));

                if (rows > 0)
                {
                    MessageBox.Show("Xóa tài khoản thành công.", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDuLieu();
                }
                else
                {
                    MessageBox.Show("Không thể xóa tài khoản.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(
                    "Không thể xóa tài khoản do ràng buộc dữ liệu.\n" +
                    "Bạn có thể khóa tài khoản thay thế.\nChi tiết: " + sqlEx.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // LƯU THÔNG TIN
        // ─────────────────────────────────────────────────────────────────
        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDangNhap = txtTenDangNhap.Text?.Trim() ?? "";
                string matKhau = txtMatKhau.Text;
                string loai = cboVaiTroEdit.SelectedItem?.ToString() ?? "";
                string trangthai = cboTrangThaiEdit.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(tenDangNhap))
                {
                    MessageBox.Show("Tên đăng nhập không được để trống.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus(); return;
                }
                if (string.IsNullOrWhiteSpace(loai))
                {
                    MessageBox.Show("Vui lòng chọn loại tài khoản.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboVaiTroEdit.Focus(); return;
                }
                if (string.IsNullOrWhiteSpace(trangthai))
                {
                    MessageBox.Show("Vui lòng chọn trạng thái.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboTrangThaiEdit.Focus(); return;
                }

                // ── ADD ────────────────────────────────────────────────
                if (isAdding)
                {
                    if (string.IsNullOrEmpty(matKhau))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu cho tài khoản mới.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMatKhau.Focus(); return;
                    }
                    if (string.IsNullOrWhiteSpace(selectedMaNV))
                    {
                        MessageBox.Show("Chưa chọn nhân viên. Vui lòng bấm 'Thêm mới' và chọn lại.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string hashed = HashPassword(matKhau);
                    var (ok, errMsg) = TaiKhoanDAL.TaoTaiKhoanNhanVien(
                        selectedMaNV, tenDangNhap, hashed, loai);

                    if (ok)
                    {
                        MessageBox.Show(
                            $"Đã cấp tài khoản '{tenDangNhap}' cho nhân viên [{selectedMaNV}] thành công.\n\n" +
                            $"Mật khẩu khởi tạo: {matKhau}\n(Hãy ghi lại để gửi cho nhân viên)",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDuLieu();
                    }
                    else
                    {
                        MessageBox.Show(errMsg ?? "Thêm tài khoản thất bại.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // ── UPDATE ─────────────────────────────────────────────
                else
                {
                    if (string.IsNullOrWhiteSpace(selectedMatk))
                    {
                        MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var sql = new StringBuilder(
                        "UPDATE TaiKhoan SET LOAITAIKHOAN = @loai, TRANGTHAI = @trangthai");
                    var parameters = new System.Collections.Generic.List<SqlParameter>
                    {
                        new SqlParameter("@loai",      loai),
                        new SqlParameter("@trangthai", trangthai),
                        new SqlParameter("@m",         selectedMatk)
                    };

                    if (!string.IsNullOrEmpty(matKhau))
                    {
                        sql.Append(", MATKHAU_HASH = @pass");
                        parameters.Add(new SqlParameter("@pass", HashPassword(matKhau)));
                    }
                    sql.Append(" WHERE MATK = @m");

                    int rows = DataProvider.ExecuteNonQuery(sql.ToString(), parameters.ToArray());
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công.", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDuLieu();
                    }
                    else
                    {
                        MessageBox.Show("Không có thay đổi hoặc cập nhật thất bại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            ClearEditPanel();
            TaiDuLieu();
        }

        // ─────────────────────────────────────────────────────────────────
        // GRID — chọn dòng
        // ─────────────────────────────────────────────────────────────────
        private void gridKetQua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            ApplySelectionFromGrid(e.RowIndex);
        }

        private void GridKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            ApplySelectionFromGrid(e.RowIndex);
        }

        private void GridKetQua_SelectionChanged(object sender, EventArgs e)
        {
            if (gridKetQua.CurrentRow == null) { ClearEditPanel(); return; }
            ApplySelectionFromGrid(gridKetQua.CurrentRow.Index);
        }

        private void ApplySelectionFromGrid(int rowIndex)
        {
            if (gridKetQua.Columns["colLoaiTaiKhoan"] == null ||
                gridKetQua.Columns["colTenDangNhap"] == null ||
                gridKetQua.Columns["colMaTaiKhoan"] == null) return;

            if (rowIndex < 0 || rowIndex >= gridKetQua.Rows.Count) return;

            try
            {
                var row = gridKetQua.Rows[rowIndex];
                txtTenDangNhap.Text = Convert.ToString(row.Cells["colTenDangNhap"].Value);
                cboVaiTroEdit.SelectedItem = Convert.ToString(row.Cells["colLoaiTaiKhoan"].Value);
                cboTrangThaiEdit.SelectedItem = Convert.ToString(row.Cells["colTrangThai"].Value);

                string nguoiDung = Convert.ToString(row.Cells["colTenNguoiDung"].Value);
                lblPhanQuyen.Text =
                    $"{cboVaiTroEdit.SelectedItem} — " +
                    $"{(string.IsNullOrWhiteSpace(nguoiDung) ? "—" : nguoiDung)}";

                SetEditPanelEnabled(true);
                txtTenDangNhap.Enabled = false;
                txtMatKhau.PasswordChar = '●';
                txtMatKhau.Clear();

                selectedMatk = Convert.ToString(row.Cells["colMaTaiKhoan"].Value);
                selectedMaNV = null;
                isAdding = false;

                // Ẩn panel NV chọn (chỉ hiện khi Add mode)
                pnlNhanVienChon.Visible = false;
                lblNVChon.Text = "";
                lblMatKhauRo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn tài khoản: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────────
        // COMBO / LABEL — event handlers nhỏ
        // ─────────────────────────────────────────────────────────────────
        private void cboTrangThaiEdit_SelectedIndexChanged(object sender, EventArgs e) => UpdatePhanQuyenLabel();
        private void cboVaiTroEdit_SelectedIndexChanged(object sender, EventArgs e) => UpdatePhanQuyenLabel();
        private void txtTenDangNhap_TextChanged(object sender, EventArgs e) { }
        private void txtMatKhau_TextChanged(object sender, EventArgs e) { }
        private void lblTong_Click(object sender, EventArgs e) { }
        private void lblPhanQuyen_Click(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
    }
}