using _03_VuNgocLinh;
using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DTO;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.KhachHang
{
    public partial class FrmTrangChu : Form
    {
        // ═══ Fields ═══════════════════════════════════════════════════
        private readonly DichVuBUS _dvBus = new DichVuBUS();
        private readonly DonDichVuBUS _donBus = new DonDichVuBUS();

        private DichVuDTO _selectedDichVu;
        private List<DichVuDTO> _searchResults = new List<DichVuDTO>();
        private string _phuongThucThanhToan;
        private string _ptttDetails;

        // ═══ Constructor ══════════════════════════════════════════════
        public FrmTrangChu()
        {
            InitializeComponent();
            dgvKetQua.SelectionChanged += DgvKetQua_SelectionChanged;
        }

        // ═══ Load ════════════════════════════════════════════════════
        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyTheme();
                ConfigureDataGrid();
                LoadNhomCombo();
                LoadTenDichVuCombo();
                LoadPaymentMethods();

                // Ngày mặc định = ngày mai (NGAYTHUCHIEN phải >= NGAYDAT)
                dtpNgayThucHien.MinDate = DateTime.Today.AddDays(1);
                dtpNgayThucHien.Value = DateTime.Today.AddDays(1);

 
                DoSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo trang chủ: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ═══ Theme ═══════════════════════════════════════════════════
        private void ApplyTheme()
        {
            // Header
            pnlHeader.BackColor = UITheme.Navy;
            lblHeaderTitle.ForeColor = Color.White;

            // Search bar – bottom separator
            pnlSearch.BackColor = UITheme.Surface;

            // Service-info section header (navy strip)
            label12.BackColor = UITheme.Navy;
            label12.ForeColor = Color.White;

            // Booking-form section header (primary-blue strip)
            lblBookingHeader.BackColor = UITheme.Primary;
            lblBookingHeader.ForeColor = Color.White;

            // Booking-form background
            pnlBookingForm.BackColor = UITheme.PrimaryXLight;

            // Buttons
            UITheme.ApplyPrimaryButton(btnTimKiem);
            UITheme.ApplyGhostButton(btnReset);
            UITheme.ApplyPrimaryButton(btnMuaNgay);
            btnMuaNgay.Font = new Font("Segoe UI", 11f, FontStyle.Bold);

            // TextBoxes & ComboBoxes
            UITheme.ApplyTextBox(txtGiaTu);
            UITheme.ApplyTextBox(txtGiaDen);
            UITheme.ApplyTextBox(txtDiemDi);
            UITheme.ApplyTextBox(txtDiemDen);
            UITheme.ApplyTextBox(txtGhiChu);
            UITheme.ApplyComboBox(cboNhom);
            UITheme.ApplyComboBox(cbTenDV);
            UITheme.ApplyComboBox(cbPTTT);

            // Panels background
            this.BackColor = UITheme.Background;
            pnlProductList.BackColor = UITheme.Surface;
            pnlSvcInfo.BackColor = UITheme.Surface;
            pnlProductDetail.BackColor = UITheme.Surface;

            // Price label accent
            lblGiaBan.ForeColor = UITheme.Primary;
        }

        // ═══ DataGrid column config ═══════════════════════════════════
        private void ConfigureDataGrid()
        {
            UITheme.ApplyDataGrid(dgvKetQua);
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.Columns.Clear();

            dgvKetQua.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "colMaDV",
                    DataPropertyName = "MaDichVu",
                    HeaderText = "Mã DV",
                    Width = 80,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colTenDV",
                    DataPropertyName = "TenDichVu",
                    HeaderText = "Tên dịch vụ",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100,
                    MinimumWidth = 180
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colNhom",
                    DataPropertyName = "TenNhom",
                    HeaderText = "Nhóm dịch vụ",
                    Width = 145,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colDVT",
                    DataPropertyName = "DonViTinh",
                    HeaderText = "Đơn vị",
                    Width = 80,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colGia",
                    DataPropertyName = "GiaBan",
                    HeaderText = "Giá bán (đ)",
                    Width = 130,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "N0"
                    }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colTrangThai",
                    DataPropertyName = "TrangThai",
                    HeaderText = "Trạng thái",
                    Width = 125,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                }
            );
        }

        // ═══ Load combos ══════════════════════════════════════════════
        private void LoadNhomCombo()
        {
            try
            {
                var dt = _dvBus.GetAllNhom();
                cboNhom.DataSource = dt;
                cboNhom.DisplayMember = "TenNhom";
                cboNhom.ValueMember = "MaNhom";
                cboNhom.SelectedIndex = -1;
            }
            catch { cboNhom.DataSource = null; }
        }

        private void LoadTenDichVuCombo()
        {
            try
            {
                var list = _dvBus.GetAllDichVu();
                cbTenDV.DataSource = list.Select(x => x.TenDichVu).Distinct().ToList();
                cbTenDV.SelectedIndex = -1;
            }
            catch { cbTenDV.DataSource = null; }
        }

        private void LoadPaymentMethods()
        {
            cbPTTT.Items.Clear();
            cbPTTT.Items.Add("-- Chọn phương thức --");
            cbPTTT.Items.Add("Tiền mặt");
            cbPTTT.Items.Add("Chuyển khoản");
            cbPTTT.SelectedIndex = 0;
        }

        // ═══ Search ══════════════════════════════════════════════════
        private void DoSearch()
        {
            decimal? giaTu = null, giaDen = null;
            if (decimal.TryParse(txtGiaTu.Text.Replace(",", ""), out var gt)) giaTu = gt;
            if (decimal.TryParse(txtGiaDen.Text.Replace(",", ""), out var gd)) giaDen = gd;

            string ten = cbTenDV.SelectedItem as string;
            string manhom = cboNhom.SelectedValue as string;

            try
            {
                _searchResults = _dvBus.TimKiemDichVu(ten, manhom, giaTu, giaDen);
                dgvKetQua.DataSource = _searchResults;
                ApplyRowStyles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tô màu cột trạng thái sau mỗi lần bind
        private void ApplyRowStyles()
        {
            foreach (DataGridViewRow row in dgvKetQua.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["colTrangThai"];
                if (cell?.Value?.ToString() == "Đang cung cấp")
                {
                    cell.Style.ForeColor = UITheme.Success;
                    cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    cell.Style.BackColor = UITheme.SuccessLight;
                }
                else
                {
                    cell.Style.ForeColor = UITheme.Danger;
                    cell.Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    cell.Style.BackColor = UITheme.DangerLight;
                }
            }
        }

        // ═══ Selection → show service detail ═════════════════════════
        private void DgvKetQua_SelectionChanged(object sender, EventArgs e)
            => ShowSelectedServiceDetails();

        private void dgvKetQua_CellContentClick(object sender, DataGridViewCellEventArgs e)
            => ShowSelectedServiceDetails();

        private void ShowSelectedServiceDetails()
        {
            try
            {
                if (dgvKetQua.CurrentRow == null) return;
                var item = dgvKetQua.CurrentRow.DataBoundItem;
                if (item == null) return;

                // Direct cast hoặc dynamic mapping
                if (item is DichVuDTO direct)
                {
                    _selectedDichVu = direct;
                }
                else
                {
                    var mapped = new DichVuDTO();
                    foreach (var p in item.GetType().GetProperties())
                    {
                        var v = p.GetValue(item);
                        switch (p.Name)
                        {
                            case "MaDichVu": mapped.MaDichVu = Convert.ToString(v); break;
                            case "TenDichVu": mapped.TenDichVu = Convert.ToString(v); break;
                            case "GiaBan": if (v != null) mapped.GiaBan = Convert.ToDecimal(v); break;
                            case "DonViTinh": mapped.DonViTinh = Convert.ToString(v); break;
                            case "TrangThai": mapped.TrangThai = Convert.ToString(v); break;
                            case "TenNhom": mapped.TenNhom = Convert.ToString(v); break;
                            case "MaNhom": mapped.MaNhom = Convert.ToString(v); break;
                            case "MoTa": mapped.MoTa = Convert.ToString(v); break;
                        }
                    }
                    _selectedDichVu = mapped;
                }

                // ── Cập nhật panel thông tin dịch vụ ──────────────────
                lblTenDV.Text = _selectedDichVu.TenDichVu ?? "—";
                lblNhom.Text = _selectedDichVu.TenNhom ?? "—";
                lblDonViTinh.Text = _selectedDichVu.DonViTinh ?? "—";
                lblGiaBan.Text = _selectedDichVu.GiaBan.ToString("N0") + " đ";
                richTextBox1.Text = !string.IsNullOrWhiteSpace(_selectedDichVu.MoTa)
                    ? _selectedDichVu.MoTa
                    : "(Không có mô tả)";

                // Trạng thái kèm màu sắc
                bool isActive = _selectedDichVu.TrangThai == "Đang cung cấp";
                lblTrangthai.Text = isActive ? "✔ Đang cung cấp" : "✖ Ngừng cung cấp";
                lblTrangthai.ForeColor = isActive ? UITheme.Success : UITheme.Danger;

                // ── Reset booking form ──────────────────────────────────
                dtpNgayThucHien.Value = DateTime.Today.AddDays(1);
                txtDiemDi.Clear();
                txtDiemDen.Clear();
                txtGhiChu.Clear();
                nudSoLuong.Value = 1;
                cbPTTT.SelectedIndex = 0;
                _phuongThucThanhToan = null;

                // ── Bật/tắt nút đặt dịch vụ ────────────────────────────
                btnMuaNgay.Enabled = isActive;
                btnMuaNgay.BackColor = isActive ? UITheme.Primary : UITheme.TextLight;
                btnMuaNgay.Text = isActive
                    ? "🚢  ĐẶT DỊCH VỤ NGAY"
                    : "⛔  Dịch vụ hiện tạm ngừng";
            }
            catch { /* bỏ qua lỗi UI nhỏ */ }
        }

        // ═══ Search events ════════════════════════════════════════════
        private void btnTimKiem_Click(object sender, EventArgs e) => DoSearch();

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbTenDV.SelectedIndex = -1;
            cboNhom.SelectedIndex = -1;
            txtGiaTu.Clear();
            txtGiaDen.Clear();
            DoSearch();
        }

        // Live filter khi chọn nhóm/tên dịch vụ
        private void cbTenDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTenDV.SelectedIndex >= 0) DoSearch();
        }

        private void cboNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhom.SelectedIndex >= 0) DoSearch();
        }

        private void txtGiaTu_TextChanged(object sender, EventArgs e) { /* lọc khi nhấn Tìm kiếm */ }
        private void txtGiaDen_TextChanged(object sender, EventArgs e) { /* lọc khi nhấn Tìm kiếm */ }

        // ═══ Phương thức thanh toán ═══════════════════════════════════
        private void cbPTTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = cbPTTT.SelectedItem?.ToString();
            _phuongThucThanhToan = (sel == "-- Chọn phương thức --") ? null : sel;

            // Gợi ý điền ghi chú khi chọn chuyển khoản
            if (_phuongThucThanhToan == "Chuyển khoản" && string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                txtGhiChu.Text = "Số TK nhận: ... | Ngân hàng: ...";
                txtGhiChu.ForeColor = UITheme.TextLight;
            }
        }

        // ═══ Đặt dịch vụ ═════════════════════════════════════════════
        private void btnMuaNgay_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đã chọn dịch vụ
            if (_selectedDichVu == null || string.IsNullOrWhiteSpace(_selectedDichVu.MaDichVu))
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ từ danh sách.",
                    "Chưa chọn dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_selectedDichVu.TrangThai != "Đang cung cấp")
            {
                MessageBox.Show("Dịch vụ này hiện không còn được cung cấp.",
                    "Dịch vụ không khả dụng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy mã khách hàng từ session
            string maKh = Session.UserID;
            if (string.IsNullOrWhiteSpace(maKh))
            {
                MessageBox.Show("Phiên đăng nhập hết hạn. Vui lòng đăng nhập lại.",
                    "Yêu cầu đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Thu thập dữ liệu form
            DateTime ngayThucHien = dtpNgayThucHien.Value.Date;
            string diemDi = txtDiemDi.Text.Trim();
            string diemDen = txtDiemDen.Text.Trim();
            int soLuong = (int)nudSoLuong.Value;
            string ghiChu = txtGhiChu.ForeColor == UITheme.TextLight
                                    ? ""                          // placeholder text – bỏ qua
                                    : txtGhiChu.Text.Trim();

            // 4. Validate
            if (!ValidateBookingForm(ngayThucHien, diemDi, diemDen)) return;

            // 5. Gắn phương thức thanh toán vào ghi chú
            if (!string.IsNullOrWhiteSpace(_phuongThucThanhToan))
            {
                ghiChu = string.IsNullOrWhiteSpace(ghiChu)
                    ? $"PTTT: {_phuongThucThanhToan}"
                    : $"PTTT: {_phuongThucThanhToan} | {ghiChu}";
            }

            // 6. Tạo mã đơn (timestamp-based)
            string maDon = "DDV" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // 7. Chi tiết đơn
            var details = new List<Tuple<string, int, decimal, string>>
            {
                Tuple.Create(_selectedDichVu.MaDichVu, soLuong, _selectedDichVu.GiaBan, (string)null)
            };
            // BUG FIX: ghi nhận phương thức thanh toán vào ghi chú đơn
            // Trước đây _phuongThucThanhToan bị bỏ qua hoàn toàn khi gọi CreateDon
            string ghiChuDon = null;
            if (!string.IsNullOrWhiteSpace(_phuongThucThanhToan)
                && _phuongThucThanhToan != "-- Chọn phương thức --")
            {
                ghiChuDon = "Phương thức TT: " + _phuongThucThanhToan;
                if (!string.IsNullOrWhiteSpace(_ptttDetails))
                    ghiChuDon += " (" + _ptttDetails + ")";
            }
            // 8. Gọi BUS tạo đơn
            try
            {
                _donBus.CreateDon(maDon, ngayThucHien, diemDi, diemDen,
                    ghiChu, "Chờ xác nhận", maKh, null, details);

                decimal tongTien = _selectedDichVu.GiaBan * soLuong;

                MessageBox.Show(
                    $"✅  Đặt dịch vụ thành công!\n\n" +
                    $"   Mã đơn:          {maDon}\n" +
                    $"   Dịch vụ:          {_selectedDichVu.TenDichVu}\n" +
                    $"   Ngày thực hiện: {ngayThucHien:dd/MM/yyyy}\n" +
                    $"   Điểm đi:          {(string.IsNullOrEmpty(diemDi) ? "(không có)" : diemDi)}\n" +
                    $"   Điểm đến:        {(string.IsNullOrEmpty(diemDen) ? "(không có)" : diemDen)}\n" +
                    $"   Số lượng:        {soLuong} {_selectedDichVu.DonViTinh}\n" +
                    $"   Tổng tiền:        {tongTien:N0} đ\n\n" +
                    "Nhân viên sẽ liên hệ để xác nhận đơn hàng của bạn.",
                    "Đặt dịch vụ thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset booking form sau khi đặt thành công
                ResetBookingForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ═══ Validation ══════════════════════════════════════════════
        private bool ValidateBookingForm(DateTime ngayThucHien, string diemDi, string diemDen)
        {
            // Ngày thực hiện không được là quá khứ (NGAYTHUCHIEN >= NGAYDAT trong DB)
            if (ngayThucHien < DateTime.Today)
            {
                MessageBox.Show("Ngày thực hiện không được là ngày trong quá khứ.",
                    "Ngày không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayThucHien.Focus();
                return false;
            }

            // Dịch vụ vận chuyển bắt buộc điểm đi + điểm đến
            if (IsTransportService(_selectedDichVu))
            {
                if (string.IsNullOrWhiteSpace(diemDi))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ / cảng điểm đi.",
                        "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiemDi.Focus();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(diemDen))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ / cảng điểm đến.",
                        "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiemDen.Focus();
                    return false;
                }
            }
            return true;
        }

        // ═══ Helpers ══════════════════════════════════════════════════
        private void ResetBookingForm()
        {
            dtpNgayThucHien.Value = DateTime.Today.AddDays(1);
            txtDiemDi.Clear();
            txtDiemDen.Clear();
            txtGhiChu.Clear();
            txtGhiChu.ForeColor = UITheme.TextPrimary;
            nudSoLuong.Value = 1;
            cbPTTT.SelectedIndex = 0;
            _phuongThucThanhToan = null;
        }

        /// <summary>
        /// Heuristic: kiểm tra dịch vụ có phải loại vận chuyển không.
        /// Dịch vụ vận chuyển bắt buộc nhập điểm đi / điểm đến.
        /// </summary>
        private bool IsTransportService(DichVuDTO dv)
        {
            if (dv == null) return false;
            try
            {
                // Nhóm vận chuyển theo MaNhom (cập nhật theo seed data thực tế)
                var transportGroups = new[] { "NDV001", "NDV002", "NDV005" };
                if (!string.IsNullOrWhiteSpace(dv.MaNhom)
                    && transportGroups.Contains(dv.MaNhom, StringComparer.OrdinalIgnoreCase))
                    return true;

                // Fallback theo keyword
                string s = ((dv.TenDichVu ?? "") + " " + (dv.TenNhom ?? "")).ToLowerInvariant();
                string[] keywords = { "vận chuyển", "vận tải", "giao nhận",
                                      "door-to-door", "biển", "hàng không", "nội địa" };
                return keywords.Any(k => s.Contains(k));
            }
            catch { return false; }
        }

        // ═══ Unused stubs (giữ lại để tương thích) ═══════════════════
        private void pnlSearch_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ đường kẻ dưới của search panel
            using (var pen = new Pen(UITheme.Border, 1))
                e.Graphics.DrawLine(pen, 0, pnlSearch.Height - 1,
                    pnlSearch.Width, pnlSearch.Height - 1);
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e) { }
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void lblTenDV_Click(object sender, EventArgs e) { }
        private void lblNhom_Click(object sender, EventArgs e) { }
        private void lblDonViTinh_Click(object sender, EventArgs e) { }
        private void lblTrangthai_Click(object sender, EventArgs e) { }
        private void lblGiaBan_Click(object sender, EventArgs e) { }

        private void lblHeaderTitle_Click(object sender, EventArgs e)
        {

        }
    }
}