using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;

namespace _03_VuNgocLinh.GUI.Pages.Owner
{
    /// <summary>
    /// FrmKTChungTu — Kiểm tra và duyệt chứng từ (dành cho Chủ doanh nghiệp).
    /// Chức năng:
    ///   - Xem danh sách toàn bộ chứng từ, lọc theo trạng thái / loại / từ khóa
    ///   - Xem chi tiết chứng từ được chọn (thông tin đơn dịch vụ + dịch vụ con)
    ///   - Duyệt (→ "Đã duyệt") hoặc Từ chối (→ "Từ chối") từng chứng từ
    ///   - Duyệt hàng loạt các chứng từ "Chờ duyệt" đang được chọn
    ///   - Xem lịch sử: đã duyệt / đã từ chối
    /// </summary>
    public partial class FrmKTChungTu : Form
    {
        // ── Màu brand (mirror AppTheme) ──────────────────────────────────────
        private static readonly Color CLR_NAVY = Color.FromArgb(28, 54, 100);
        private static readonly Color CLR_OCEAN = Color.FromArgb(0, 120, 180);
        private static readonly Color CLR_OCEAN_LITE = Color.FromArgb(26, 144, 204);
        private static readonly Color CLR_TEAL = Color.FromArgb(0, 163, 196);
        private static readonly Color CLR_GREEN = Color.FromArgb(39, 174, 96);
        private static readonly Color CLR_ORANGE = Color.FromArgb(243, 156, 18);
        private static readonly Color CLR_RED = Color.FromArgb(231, 76, 60);
        private static readonly Color CLR_BG = Color.FromArgb(235, 245, 251);
        private static readonly Color CLR_BORDER = Color.FromArgb(200, 221, 237);
        private static readonly Color CLR_TEXT_DARK = Color.FromArgb(28, 48, 70);

        // ── State ────────────────────────────────────────────────────────────
        private List<ChungTuDTO> _dsFull = new List<ChungTuDTO>();
        private ChungTuDTO _selected = null;

        // ── Constructor ──────────────────────────────────────────────────────
        public FrmKTChungTu()
        {
            InitializeComponent();
            InitGridDanhSach();
            InitGridChiTiet();
            WireEvents();
        }

        // ════════════════════════════════════════════════════════════════════
        // KHỞI TẠO GRID CỘT
        // ════════════════════════════════════════════════════════════════════

        private void InitGridDanhSach()
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.Columns.Clear();

            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaCT",
                HeaderText = "Mã CT",
                DataPropertyName = "MaChungTu",
                Width = 90,
                ReadOnly = true
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoCT",
                HeaderText = "Số chứng từ",
                DataPropertyName = "SoChungTu",
                Width = 120,
                ReadOnly = true
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLoai",
                HeaderText = "Loại",
                DataPropertyName = "LoaiChungTu",
                Width = 160,
                ReadOnly = true
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgayLap",
                HeaderText = "Ngày lập",
                DataPropertyName = "NgayLap",
                Width = 95,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaDon",
                HeaderText = "Mã đơn",
                DataPropertyName = "MaDon",
                Width = 90,
                ReadOnly = true
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTongTien",
                HeaderText = "Tổng tiền (đ)",
                DataPropertyName = "TongTien",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTrangThai",
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai",
                Width = 120,
                ReadOnly = true
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNVKiemTra",
                HeaderText = "NV kiểm tra",
                DataPropertyName = "TenNhanVienKiemTra",
                Width = 150,
                ReadOnly = true
            });
        }

        private void InitGridChiTiet()
        {
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ctColMaDV",
                HeaderText = "Mã DV",
                Width = 90,
                ReadOnly = true
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ctColTenDV",
                HeaderText = "Tên dịch vụ",
                Width = 200,
                ReadOnly = true
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ctColDVT",
                HeaderText = "ĐVT",
                Width = 70,
                ReadOnly = true
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ctColSL",
                HeaderText = "SL",
                Width = 55,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ctColDonGia",
                HeaderText = "Đơn giá (đ)",
                Width = 110,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ctColThanhTien",
                HeaderText = "Thành tiền (đ)",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ctColGhiChu",
                HeaderText = "Ghi chú",
                Width = 160,
                ReadOnly = true
            });
        }

        // ════════════════════════════════════════════════════════════════════
        // WIRE EVENTS
        // ════════════════════════════════════════════════════════════════════

        // ── Placeholder watermark (thay thế PlaceholderText — không hỗ trợ .NET Framework) ─
        private const string SEARCH_PLACEHOLDER = "Mã CT / Số CT / Mã đơn...";

        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == SEARCH_PLACEHOLDER)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = System.Drawing.Color.FromArgb(28, 48, 70);
            }
        }

        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = SEARCH_PLACEHOLDER;
                txtSearch.ForeColor = System.Drawing.Color.FromArgb(107, 143, 175);
            }
        }

        private void WireEvents()
        {
            this.Load += FrmKTChungTu_Load;
            btnLamMoi.Click += (s, e) => LoadDanhSach();
            btnTimKiem.Click += (s, e) => ApplyFilter();
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) ApplyFilter(); };
            txtSearch.GotFocus += TxtSearch_GotFocus;
            txtSearch.LostFocus += TxtSearch_LostFocus;
            cboTrangThai.SelectedIndexChanged += (s, e) => ApplyFilter();
            cboLoai.SelectedIndexChanged += (s, e) => ApplyFilter();
            dgvDanhSach.SelectionChanged += DgvDanhSach_SelectionChanged;
            btnDuyet.Click += BtnDuyet_Click;
            btnTuChoi.Click += BtnTuChoi_Click;
            btnDuyetHangLoat.Click += BtnDuyetHangLoat_Click;

            // Hover effects
            void AddHover(Button btn, Color baseColor)
            {
                Color lite = ControlPaint.Light(baseColor, 0.2f);
                btn.MouseEnter += (s, _) => btn.BackColor = lite;
                btn.MouseLeave += (s, _) => btn.BackColor = baseColor;
            }
            AddHover(btnLamMoi, CLR_OCEAN);
            AddHover(btnTimKiem, CLR_OCEAN);
            AddHover(btnDuyet, CLR_GREEN);
            AddHover(btnTuChoi, CLR_RED);
            AddHover(btnDuyetHangLoat, CLR_TEAL);
        }

        // ════════════════════════════════════════════════════════════════════
        // FORM LOAD
        // ════════════════════════════════════════════════════════════════════

        private void FrmKTChungTu_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo placeholder watermark cho ô tìm kiếm
                txtSearch.Text = SEARCH_PLACEHOLDER;
                txtSearch.ForeColor = System.Drawing.Color.FromArgb(107, 143, 175);

                ApplyRuntimeTheme();
                InitFilterCombos();
                LoadUserInfo();
                LoadDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRuntimeTheme()
        {
            // DGV danh sách
            dgvDanhSach.BackgroundColor = CLR_BG;
            dgvDanhSach.GridColor = CLR_BORDER;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.BackColor = CLR_NAVY;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvDanhSach.EnableHeadersVisualStyles = false;
            dgvDanhSach.RowHeadersVisible = false;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.MultiSelect = true;
            dgvDanhSach.ReadOnly = true;
            dgvDanhSach.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 250, 255);

            // DGV chi tiết
            dgvChiTiet.BackgroundColor = CLR_BG;
            dgvChiTiet.GridColor = CLR_BORDER;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 180);
            dgvChiTiet.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvChiTiet.EnableHeadersVisualStyles = false;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        }

        private void InitFilterCombos()
        {
            // Lọc trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("-- Tất cả trạng thái --");
            cboTrangThai.Items.Add("Chờ duyệt");
            cboTrangThai.Items.Add("Đã duyệt");
            cboTrangThai.Items.Add("Từ chối");
            cboTrangThai.Items.Add("Trả lại");
            cboTrangThai.SelectedIndex = 0;

            // Lọc loại
            cboLoai.Items.Clear();
            cboLoai.Items.Add("-- Tất cả loại --");
            cboLoai.Items.Add("Vận đơn");
            cboLoai.Items.Add("Hợp đồng");
            cboLoai.Items.Add("Biên bản giao nhận");
            cboLoai.Items.Add("Chứng từ xuất nhập khẩu");
            cboLoai.Items.Add("Khác");
            cboLoai.SelectedIndex = 0;
        }

        private void LoadUserInfo()
        {
            try
            {
                string manv = Session.UserID;
                string role = Session.Role ?? "Chủ doanh nghiệp";
                string tenNV = Session.UserName ?? "";

                if (!string.IsNullOrWhiteSpace(manv))
                {
                    var dt = DataProvider.ExecuteQuery(
                        "SELECT TENNV FROM NhanVien WHERE MANV = @manv",
                        new SqlParameter("@manv", manv));
                    if (dt.Rows.Count > 0)
                        tenNV = dt.Rows[0]["TENNV"]?.ToString() ?? tenNV;
                }

                lblNguoiDung.Text = string.IsNullOrWhiteSpace(tenNV)
                    ? $"Vai trò: {role}"
                    : $"Xin chào, {tenNV}    •    {role}";
            }
            catch
            {
                lblNguoiDung.Text = "Chủ doanh nghiệp";
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // TẢI VÀ LỌC DỮ LIỆU
        // ════════════════════════════════════════════════════════════════════

        private void LoadDanhSach()
        {
            try
            {
                _dsFull = ChungTuDAL.GetAll();
                ApplyFilter();
                UpdateKPICards();
                ClearChiTiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chứng từ:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            var filtered = _dsFull.AsEnumerable();

            // Lọc trạng thái
            string tt = cboTrangThai.SelectedIndex > 0
                ? cboTrangThai.SelectedItem.ToString() : "";
            if (!string.IsNullOrEmpty(tt))
                filtered = filtered.Where(c => c.TrangThai == tt);

            // Lọc loại
            string loai = cboLoai.SelectedIndex > 0
                ? cboLoai.SelectedItem.ToString() : "";
            if (!string.IsNullOrEmpty(loai))
                filtered = filtered.Where(c => c.LoaiChungTu == loai);

            // Tìm kiếm từ khóa
            string kw = (txtSearch.Text == SEARCH_PLACEHOLDER ? "" : txtSearch.Text).Trim().ToLower();
            if (!string.IsNullOrEmpty(kw))
                filtered = filtered.Where(c =>
                    (c.MaChungTu ?? "").ToLower().Contains(kw) ||
                    (c.SoChungTu ?? "").ToLower().Contains(kw) ||
                    (c.MaDon ?? "").ToLower().Contains(kw));

            var result = filtered.ToList();
            BindDanhSach(result);
            lblSoLuong.Text = $"Tổng: {result.Count} chứng từ";
        }

        private void BindDanhSach(List<ChungTuDTO> list)
        {
            dgvDanhSach.DataSource = null;
            dgvDanhSach.DataSource = list;

            // Tô màu dòng theo trạng thái
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.DataBoundItem is ChungTuDTO ct)
                {
                    switch (ct.TrangThai)
                    {
                        case "Đã duyệt":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 237);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(21, 110, 58);
                            break;
                        case "Từ chối":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(160, 30, 30);
                            break;
                        case "Chờ duyệt":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 220);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(140, 80, 0);
                            break;
                        case "Trả lại":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 210);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(150, 60, 0);
                            break;
                    }
                }
            }
        }

        private void UpdateKPICards()
        {
            int choKT = _dsFull.Count(c => c.TrangThai == "Chờ duyệt");
            int hopLe = _dsFull.Count(c => c.TrangThai == "Đã duyệt");
            int khongHL = _dsFull.Count(c => c.TrangThai == "Từ chối");
            int total = _dsFull.Count;

            lblKpiChoKT.Text = choKT.ToString();
            lblKpiHopLe.Text = hopLe.ToString();
            lblKpiKhongHL.Text = khongHL.ToString();
            lblKpiTong.Text = total.ToString();
        }

        // ════════════════════════════════════════════════════════════════════
        // CHỌN DÒNG → HIỂN THỊ CHI TIẾT
        // ════════════════════════════════════════════════════════════════════

        private void DgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow?.DataBoundItem is ChungTuDTO ct)
            {
                _selected = ct;
                HienThiChiTiet(ct);
                UpdateButtonStates();
            }
            else
            {
                _selected = null;
                ClearChiTiet();
                UpdateButtonStates();
            }
        }

        private void HienThiChiTiet(ChungTuDTO ct)
        {
            // Thông tin header
            lblChiTietMaCT.Text = ct.MaChungTu ?? "";
            lblChiTietSoCT.Text = ct.SoChungTu ?? "";
            lblChiTietLoai.Text = ct.LoaiChungTu ?? "";
            lblChiTietNgayLap.Text = ct.NgayLap.ToString("dd/MM/yyyy");
            lblChiTietMaDon.Text = ct.MaDon ?? "";
            lblChiTietTongTien.Text = ct.TongTien.HasValue
                ? ct.TongTien.Value.ToString("N0") + " đ"
                : "(chưa có)";
            lblChiTietTrangThai.Text = ct.TrangThai ?? "";
            lblChiTietNVKT.Text = ct.TenNhanVienKiemTra ?? "(chưa phân công)";

            // Màu trạng thái label
            switch (ct.TrangThai)
            {
                case "Đã duyệt":
                    lblChiTietTrangThai.ForeColor = CLR_GREEN;
                    break;
                case "Từ chối":
                    lblChiTietTrangThai.ForeColor = CLR_RED;
                    break;
                case "Trả lại":
                    lblChiTietTrangThai.ForeColor = CLR_ORANGE;
                    break;
                default:
                    lblChiTietTrangThai.ForeColor = CLR_ORANGE;
                    break;
            }

            // Tải chi tiết dịch vụ của đơn dịch vụ liên quan
            LoadChiTietDichVu(ct.MaDon);
        }

        private void LoadChiTietDichVu(string maDon)
        {
            dgvChiTiet.Rows.Clear();
            if (string.IsNullOrWhiteSpace(maDon)) return;

            try
            {
                // Dùng lại DAL có sẵn — đúng tên cột: DONVITINH, ThanhTien là computed property
                var list = ChiTietDonDichVuDAL.GetFullByDon(maDon);

                if (list.Count == 0)
                {
                    dgvChiTiet.Rows.Add("", "(Không có chi tiết dịch vụ)", "", "", "", "", "");
                    return;
                }

                foreach (var dv in list)
                {
                    dgvChiTiet.Rows.Add(
                        dv.MaDichVu,
                        dv.TenDichVu,
                        dv.DonViTinh,
                        dv.SoLuong,
                        dv.DonGia,
                        dv.ThanhTien,
                        dv.GhiChu ?? ""
                    );
                }
            }
            catch (Exception ex)
            {
                dgvChiTiet.Rows.Clear();
                dgvChiTiet.Rows.Add("", "Lỗi tải chi tiết: " + ex.Message, "", "", "", "", "");
            }
        }

        private void ClearChiTiet()
        {
            lblChiTietMaCT.Text = "";
            lblChiTietSoCT.Text = "";
            lblChiTietLoai.Text = "";
            lblChiTietNgayLap.Text = "";
            lblChiTietMaDon.Text = "";
            lblChiTietTongTien.Text = "";
            lblChiTietTrangThai.Text = "";
            lblChiTietNVKT.Text = "";
            dgvChiTiet.Rows.Clear();
        }

        private void UpdateButtonStates()
        {
            bool hasSelected = _selected != null;
            bool isCho = hasSelected && _selected.TrangThai == "Chờ duyệt";

            btnDuyet.Enabled = isCho;
            btnTuChoi.Enabled = isCho;
            btnDuyet.BackColor = isCho ? CLR_GREEN : Color.FromArgb(160, 200, 170);
            btnTuChoi.BackColor = isCho ? CLR_RED : Color.FromArgb(210, 170, 170);

            // Nút duyệt hàng loạt: chỉ hiện nếu có ≥1 chứng từ "Chờ duyệt" trong list hiển thị
            int cntCho = _dsFull.Count(c => c.TrangThai == "Chờ duyệt");
            btnDuyetHangLoat.Enabled = cntCho > 0;
        }

        // ════════════════════════════════════════════════════════════════════
        // DUYỆT / TỪ CHỐI ĐƠN LẺ
        // ════════════════════════════════════════════════════════════════════

        private void BtnDuyet_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (_selected.TrangThai != "Chờ duyệt")
            {
                MessageBox.Show("Chỉ có thể duyệt chứng từ đang ở trạng thái 'Chờ duyệt'.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Xác nhận DUYỆT chứng từ [{_selected.MaChungTu}] — {_selected.SoChungTu}?\n" +
                "Trạng thái sẽ chuyển sang: Đã duyệt",
                "Xác nhận duyệt",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            DoiTrangThai(_selected.MaChungTu, "Đã duyệt");
        }

        private void BtnTuChoi_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (_selected.TrangThai != "Chờ duyệt")
            {
                MessageBox.Show("Chỉ có thể từ chối chứng từ đang ở trạng thái 'Chờ duyệt'.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Yêu cầu nhập lý do từ chối (tuỳ chọn — lưu vào txtGhiChu nếu có)
            string lyDo = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập lý do từ chối (có thể để trống):",
                "Lý do từ chối", "");

            var confirm = MessageBox.Show(
                $"Xác nhận TỪ CHỐI chứng từ [{_selected.MaChungTu}] — {_selected.SoChungTu}?\n" +
                "Trạng thái sẽ chuyển sang: Từ chối",
                "Xác nhận từ chối",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            DoiTrangThai(_selected.MaChungTu, "Từ chối");
        }

        private void DoiTrangThai(string maCT, string trangThaiMoi)
        {
            try
            {
                string maNVKT = Session.UserID ?? "";
                bool ok = ChungTuDAL.UpdateTrangThai(maCT, trangThaiMoi, maNVKT);
                if (ok)
                {
                    string msg = trangThaiMoi == "Đã duyệt"
                        ? "✔ Chứng từ đã được duyệt thành công."
                        : "✘ Chứng từ đã được đánh dấu Từ chối.";
                    MessageBox.Show(msg, "Kết quả",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSach();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật trạng thái. Vui lòng thử lại.",
                        "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // DUYỆT HÀNG LOẠT
        // ════════════════════════════════════════════════════════════════════

        private void BtnDuyetHangLoat_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các chứng từ "Chờ duyệt" từ dữ liệu đang hiển thị
            var danhSachHienThi = (dgvDanhSach.DataSource as List<ChungTuDTO>) ?? _dsFull;
            var choCho = danhSachHienThi.Where(c => c.TrangThai == "Chờ duyệt").ToList();

            if (choCho.Count == 0)
            {
                MessageBox.Show("Không có chứng từ nào ở trạng thái 'Chờ duyệt' trong danh sách hiện tại.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Xác nhận duyệt HÀNG LOẠT {choCho.Count} chứng từ 'Chờ duyệt'?\n" +
                "Tất cả sẽ chuyển sang trạng thái: Đã duyệt",
                "Duyệt hàng loạt",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            int thanhCong = 0;
            int thatBai = 0;
            string maNVKT = Session.UserID ?? "";

            foreach (var ct in choCho)
            {
                try
                {
                    bool ok = ChungTuDAL.UpdateTrangThai(ct.MaChungTu, "Đã duyệt", maNVKT);
                    if (ok) thanhCong++;
                    else thatBai++;
                }
                catch
                {
                    thatBai++;
                }
            }

            MessageBox.Show(
                $"Hoàn tất duyệt hàng loạt.\n" +
                $"✔ Thành công: {thanhCong}  |  ✘ Thất bại: {thatBai}",
                "Kết quả",
                MessageBoxButtons.OK,
                thanhCong > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            LoadDanhSach();
        }
    }
}