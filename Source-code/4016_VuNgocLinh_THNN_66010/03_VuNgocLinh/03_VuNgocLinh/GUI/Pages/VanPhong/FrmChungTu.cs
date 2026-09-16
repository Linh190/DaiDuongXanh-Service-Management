using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using Microsoft.VisualBasic;

namespace _03_VuNgocLinh.GUI.Pages.VanPhong
{
    public partial class FrmChungTu : Form
    {
        // ── Dataset ──────────────────────────────────────────────────────
        private List<ChungTuKhachHangItem> _dsKH = new List<ChungTuKhachHangItem>();
        private List<ChungTuDonDichVuItem> _dsDon = new List<ChungTuDonDichVuItem>();
        private bool _isUpdating = false;

        // Thông tin NV văn phòng đang đăng nhập (người lập chứng từ).
        // Được lấy 1 lần khi form load từ Session.UserID, không thay đổi trong suốt form.
        // MANV_KIEMTRA trong DB để NULL khi lập — Chủ doanh nghiệp tự vào duyệt sau.
        private string _maNVLap = null;
        private string _tenNVLap = null;
        private string _emailNVLap = null;

        // ── Grid columns ─────────────────────────────────────────────────
        private DataGridViewTextBoxColumn colMaDV;
        private DataGridViewTextBoxColumn colTenDV;
        private DataGridViewTextBoxColumn colDVT;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThueSuat;
        private DataGridViewTextBoxColumn colThanhTien;
        private DataGridViewTextBoxColumn colGhiChu;

        public FrmChungTu()
        {
            InitializeComponent();
            InitGridColumns();
            WireEvents();
        }

        // ══════════════════════════════════════════════════════════════════
        // KHỞI TẠO CỘT GRID
        // ══════════════════════════════════════════════════════════════════
        private void InitGridColumns()
        {
            dgvDichVu.Columns.Clear();
            dgvDichVu.AutoGenerateColumns = false;

            colMaDV = new DataGridViewTextBoxColumn
            { Name = "colMaDV", HeaderText = "Mã DV", ReadOnly = true, Width = 90 };
            colTenDV = new DataGridViewTextBoxColumn
            { Name = "colTenDV", HeaderText = "Tên dịch vụ", ReadOnly = true, Width = 220 };
            colDVT = new DataGridViewTextBoxColumn
            { Name = "colDVT", HeaderText = "ĐVT", ReadOnly = true, Width = 70 };
            colSoLuong = new DataGridViewTextBoxColumn
            { Name = "colSoLuong", HeaderText = "SL", ReadOnly = true, Width = 60 };
            colDonGia = new DataGridViewTextBoxColumn
            {
                Name = "colDonGia",
                HeaderText = "Đơn giá (đ)",
                ReadOnly = true,
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            };
            colThueSuat = new DataGridViewTextBoxColumn
            { Name = "colThueSuat", HeaderText = "VAT%", ReadOnly = true, Width = 55 };
            colThanhTien = new DataGridViewTextBoxColumn
            {
                Name = "colThanhTien",
                HeaderText = "Thành tiền (đ)",
                ReadOnly = true,
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            };
            colGhiChu = new DataGridViewTextBoxColumn
            {
                Name = "colGhiChu",
                HeaderText = "Ghi chú",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dgvDichVu.Columns.AddRange(new DataGridViewColumn[]
            { colMaDV, colTenDV, colDVT, colSoLuong, colDonGia, colThueSuat, colThanhTien, colGhiChu });
        }

        // ══════════════════════════════════════════════════════════════════
        // WIRE EVENTS
        // ══════════════════════════════════════════════════════════════════
        private void WireEvents()
        {
            cboLoaiChungTu.SelectedIndexChanged += CboLoaiCT_Changed;
            dgvDichVu.CellValueChanged += DgvDichVu_CellValueChanged;
            dgvDichVu.DataError += (s, e) => e.Cancel = true;
        }

        // ══════════════════════════════════════════════════════════════════
        // FORM LOAD
        // ══════════════════════════════════════════════════════════════════
        private void FrmChungTu_Load(object sender, EventArgs e)
        {
            if (!DataProvider.TestConnection())
            {
                var res = MessageBox.Show(
                    "Không kết nối được SQL Server!\nBạn có muốn nhập lại connection string không?",
                    "Lỗi kết nối", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes) ShowConnectionDialog();
            }

            LoadNhanVienDangNhap(); // load thông tin NV trước
            LoadData();
            ResetForm();
        }

        // ══════════════════════════════════════════════════════════════════
        // LẤY THÔNG TIN NV VĂN PHÒNG ĐANG ĐĂNG NHẬP
        // Session.UserID = MANV của người đang login
        // ══════════════════════════════════════════════════════════════════
        private void LoadNhanVienDangNhap()
        {
            _maNVLap = null;
            _tenNVLap = null;
            _emailNVLap = null;

            string manv = Session.UserID;
            if (string.IsNullOrWhiteSpace(manv)) return;

            try
            {
                var dt = DataProvider.ExecuteQuery(
                    "SELECT MANV, TENNV, EMAILNV, VAITRO, TRANGTHAI " +
                    "FROM NhanVien WHERE MANV = @manv",
                    new SqlParameter("@manv", manv));

                if (dt.Rows.Count == 0) return;

                var r = dt.Rows[0];
                _maNVLap = Convert.ToString(r["MANV"]);
                _tenNVLap = Convert.ToString(r["TENNV"]);
                _emailNVLap = r["EMAILNV"] == DBNull.Value ? "" : Convert.ToString(r["EMAILNV"]);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[FrmChungTu] LoadNhanVienDangNhap lỗi: " + ex.Message);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // LOAD DATA
        // ══════════════════════════════════════════════════════════════════
        private void LoadData()
        {
            try
            {
                // Khách hàng
                _dsKH = ChungTuDAL.GetAllKhachHang();

                // Đơn dịch vụ
                _dsDon = DonDichVuDAL.GetAllForChungTu();

                // Bind Đơn dịch vụ
                cboMaDon.DataSource = null;
                cboMaDon.DataSource = _dsDon;
                cboMaDon.ValueMember = "MaDon";
                cboMaDon.SelectedIndex = -1;

                // Bind Khách hàng (chỉ hiển thị — tự điền theo đơn được chọn)
                cboMaKH.DataSource = null;
                cboMaKH.DataSource = _dsKH;
                cboMaKH.DisplayMember = "HoTen";
                cboMaKH.ValueMember = "MaKhachHang";
                cboMaKH.SelectedIndex = -1;
                cboMaKH.Enabled = false; // tự điền theo đơn, không cho sửa tay

                // Bind cboMaNV — chỉ 1 item là NV văn phòng đang đăng nhập.
                // Hiển thị "NV001 - Nguyễn Văn A", khóa Enabled = false.
                BindCboMaNV();

                // Loại chứng từ — khớp CK_ChungTu_LOAI
                cboLoaiChungTu.Items.Clear();
                cboLoaiChungTu.Items.AddRange(ChungTuDAL.LoaiHopLe);
                if (cboLoaiChungTu.Items.Count > 0)
                    cboLoaiChungTu.SelectedIndex = 0;

                // Thuế suất
                cboThueSuat.Items.Clear();
                cboThueSuat.Items.AddRange(new object[] { "0%", "5%", "8%", "10%" });
                cboThueSuat.SelectedItem = "10%";

                // Phương thức thanh toán — khớp CK_HoaDon_PHUONGTHUC:
                // 'Tiền mặt' | 'Chuyển khoản' | 'Online'
                cbPTTT.Items.Clear();
                cbPTTT.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Online" });
                if (cbPTTT.Items.Count > 0)
                    cbPTTT.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu (LoadData):\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // RESET FORM
        // ══════════════════════════════════════════════════════════════════
        private void ResetForm()
        {
            try { txtMaCT.Text = ChungTuDAL.GenerateNewMaCT(); }
            catch { txtMaCT.Text = "CT00001"; }

            RegenerateSOCT();

            try { dtNgayChungTu.Value = DateTime.Today; } catch { }

            cboMaDon.SelectedIndex = -1;
            cboMaKH.SelectedIndex = -1;
            cboMaKH.Enabled = false;

            txtDiemDi.Clear();
            txtDiemDen.Clear();

            if (cboLoaiChungTu.Items.Count > 0)
                cboLoaiChungTu.SelectedIndex = 0;

            if (cboThueSuat.Items.Contains("10%"))
                cboThueSuat.SelectedItem = "10%";
            else if (cboThueSuat.Items.Count > 0)
                cboThueSuat.SelectedIndex = 0;

            if (cbPTTT.Items.Count > 0)
                cbPTTT.SelectedIndex = 0;

            txtTenKH.Clear();
            txtSDTKH.Clear();
            txtDienGiai.Clear();

            // cboMaNV hiển thị đúng NV đang login, readonly
            BindCboMaNV();
            txtTenNV.Text = _tenNVLap ?? "";
            txtEmailNV.Text = _emailNVLap ?? "";

            dgvDichVu.Rows.Clear();
            RecalcAll();
        }

        // ══════════════════════════════════════════════════════════════════
        // BIND cboMaNV — NV VĂN PHÒNG ĐANG ĐĂNG NHẬP, READONLY
        // ══════════════════════════════════════════════════════════════════

        /// <summary>
        /// Bind cboMaNV với đúng 1 item là NV văn phòng đang login.
        /// Format hiển thị: "NV001 - Nguyễn Văn A"
        /// Khóa Enabled = false — không cho chọn người khác.
        /// Gọi lại mỗi khi ResetForm() để đảm bảo luôn đúng người.
        /// </summary>
        private void BindCboMaNV()
        {
            // Tạo danh sách chỉ 1 item — chính NV đang đăng nhập
            var dsNVLap = new List<ChungTuNhanVienItem>();
            if (!string.IsNullOrWhiteSpace(_maNVLap))
            {
                dsNVLap.Add(new ChungTuNhanVienItem
                {
                    MaNhanVien = _maNVLap,
                    HoTen = _tenNVLap ?? "",
                    Email = _emailNVLap ?? "",
                    // MaVaTen = DisplayMember → "NV001 - Nguyễn Văn A"
                    MaVaTen = _maNVLap + " - " + (_tenNVLap ?? "")
                });
            }

            cboMaNV.DataSource = null;
            cboMaNV.DataSource = dsNVLap;
            cboMaNV.DisplayMember = "MaVaTen";   // hiện cả mã lẫn tên
            cboMaNV.ValueMember = "MaNhanVien";

            if (dsNVLap.Count > 0)
                cboMaNV.SelectedIndex = 0;       // tự động chọn người đang login

            cboMaNV.Enabled = false;             // readonly — không cho chọn người khác
        }

        // ══════════════════════════════════════════════════════════════════
        // COMBO EVENTS
        // ══════════════════════════════════════════════════════════════════

        /// <summary>
        /// Chọn Đơn dịch vụ → tự điền KH, Điểm đi/đến và tải chi tiết dịch vụ.
        /// </summary>
        private void CboMaDon_Changed(object sender, EventArgs e)
        {
            if (cboMaDon.SelectedItem is ChungTuDonDichVuItem don)
            {
                cboMaKH.SelectedValue = don.MaKhachHang;
                txtDiemDi.Text = don.DiemDi ?? "";
                txtDiemDen.Text = don.DiemDen ?? "";
                LoadChiTietTheoDon(don.MaDon);
            }
            else
            {
                txtDiemDi.Clear();
                txtDiemDen.Clear();
                dgvDichVu.Rows.Clear();
                RecalcAll();
            }
        }

        private void LoadChiTietTheoDon(string maDon)
        {
            dgvDichVu.Rows.Clear();
            if (string.IsNullOrWhiteSpace(maDon)) { RecalcAll(); return; }

            List<ChungTuDonDichVuChiTietItem> chiTiet;
            try
            {
                chiTiet = ChiTietDonDichVuDAL.GetFullByDon(maDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết đơn dịch vụ:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RecalcAll();
                return;
            }

            if (chiTiet.Count == 0)
                Warn("Đơn dịch vụ '" + maDon + "' chưa có dịch vụ chi tiết nào!");

            _isUpdating = true;
            foreach (var dv in chiTiet)
            {
                int idx = dgvDichVu.Rows.Add();
                var row = dgvDichVu.Rows[idx];
                row.Cells[colMaDV.Index].Value = dv.MaDichVu;
                row.Cells[colTenDV.Index].Value = dv.TenDichVu;
                row.Cells[colDVT.Index].Value = dv.DonViTinh;
                row.Cells[colSoLuong.Index].Value = dv.SoLuong;
                row.Cells[colDonGia.Index].Value = dv.DonGia;
                row.Cells[colThanhTien.Index].Value = dv.SoLuong * dv.DonGia;
                row.Cells[colGhiChu.Index].Value = dv.GhiChu;
                UpdateThueSuatRow(row);
            }
            _isUpdating = false;
            RecalcAll();
        }

        private void CboMaKH_Changed(object sender, EventArgs e)
        {
            if (cboMaKH.SelectedItem is ChungTuKhachHangItem kh)
            {
                txtTenKH.Text = kh.HoTen ?? "";
                txtSDTKH.Text = kh.SoDienThoai ?? "";
                if (string.IsNullOrWhiteSpace(txtDienGiai.Text))
                    txtDienGiai.Text = "Dịch vụ cho " + kh.HoTen;
            }
            else
            {
                txtTenKH.Clear();
                txtSDTKH.Clear();
            }
        }

        private void CboLoaiCT_Changed(object sender, EventArgs e) => RegenerateSOCT();

        private void RegenerateSOCT()
        {
            try
            {
                string loai = cboLoaiChungTu.SelectedItem?.ToString() ?? "Khác";
                txtSoCT.Text = ChungTuDAL.GenerateNewSoCT(loai);
            }
            catch { txtSoCT.Text = "CT00001"; }
        }

        // ══════════════════════════════════════════════════════════════════
        // GRID EVENTS
        // ══════════════════════════════════════════════════════════════════
        private void DgvDichVu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _isUpdating) return;
            RecalcRow(dgvDichVu.Rows[e.RowIndex]);
            RecalcAll();
        }

        // ══════════════════════════════════════════════════════════════════
        // TÍNH TIỀN
        // ══════════════════════════════════════════════════════════════════
        private decimal GetThueSuat()
        {
            switch (cboThueSuat.SelectedItem?.ToString())
            {
                case "0%": return 0.00m;
                case "5%": return 0.05m;
                case "8%": return 0.08m;
                case "10%": return 0.10m;
                default: return 0.10m;
            }
        }

        private void RecalcRow(DataGridViewRow row)
        {
            if (_isUpdating) return;
            decimal sl = ToDecimal(row.Cells[colSoLuong.Index].Value);
            decimal dg = ToDecimal(row.Cells[colDonGia.Index].Value);
            _isUpdating = true;
            row.Cells[colThanhTien.Index].Value = sl * dg;
            UpdateThueSuatRow(row);
            _isUpdating = false;
        }

        private void UpdateThueSuatRow(DataGridViewRow row)
        {
            row.Cells[colThueSuat.Index].Value =
                ((int)(GetThueSuat() * 100)).ToString() + "%";
        }

        private void RecalcAll()
        {
            decimal tongSL = 0, tongTien = 0, tongThue = 0;
            decimal vat = GetThueSuat();

            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                if (row.IsNewRow) continue;
                decimal sl = ToDecimal(row.Cells[colSoLuong.Index].Value);
                decimal dg = ToDecimal(row.Cells[colDonGia.Index].Value);
                decimal tt = sl * dg;
                tongSL += sl;
                tongTien += tt;
                tongThue += tt * vat;
                UpdateThueSuatRow(row);
            }

            lblTongSoLuong.Text = tongSL.ToString("N0");
            lblTongTien.Text = tongTien.ToString("N0") + " đ";
            lblTongThueGTGT.Text = tongThue.ToString("N0") + " đ";
        }

        private decimal ToDecimal(object val)
        {
            if (val == null || val == DBNull.Value) return 0;
            decimal d;
            return decimal.TryParse(val.ToString(), out d) ? d : 0;
        }

        // ══════════════════════════════════════════════════════════════════
        // VALIDATE
        // ══════════════════════════════════════════════════════════════════
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtMaCT.Text))
            { Warn("Vui lòng nhập mã chứng từ!"); txtMaCT.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtSoCT.Text))
            { Warn("Vui lòng nhập số chứng từ!"); txtSoCT.Focus(); return false; }

            if (cboLoaiChungTu.SelectedItem == null)
            { Warn("Vui lòng chọn loại chứng từ!"); cboLoaiChungTu.Focus(); return false; }

            if (cboMaDon.SelectedItem == null)
            { Warn("Vui lòng chọn đơn dịch vụ!"); cboMaDon.Focus(); return false; }

            // Người lập phải là NV văn phòng đang đăng nhập — bắt buộc
            if (string.IsNullOrWhiteSpace(_maNVLap))
            {
                Warn("Không xác định được nhân viên đang đăng nhập!\n" +
                     "Vui lòng đăng xuất và đăng nhập lại.");
                return false;
            }

            if (dgvDichVu.Rows.Count == 0)
            { Warn("Đơn dịch vụ này chưa có dịch vụ nào, không thể lập chứng từ!"); return false; }

            for (int i = 0; i < dgvDichVu.Rows.Count; i++)
            {
                var row = dgvDichVu.Rows[i];
                if (row.IsNewRow) continue;
                if (ToDecimal(row.Cells[colSoLuong.Index].Value) <= 0)
                { Warn("Dòng " + (i + 1) + ": Số lượng phải > 0!"); return false; }
            }
            return true;
        }

        // ══════════════════════════════════════════════════════════════════
        // LƯU CHỨNG TỪ
        // ══════════════════════════════════════════════════════════════════
        private void LuuChungTu()
        {
            if (!ValidateForm()) return;

            var don = (ChungTuDonDichVuItem)cboMaDon.SelectedItem;

            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                if (row.IsNewRow) continue;
                tongTien += ToDecimal(row.Cells[colSoLuong.Index].Value)
                          * ToDecimal(row.Cells[colDonGia.Index].Value);
            }

            var ct = new ChungTuDTO
            {
                MaChungTu = txtMaCT.Text.Trim(),
                SoChungTu = txtSoCT.Text.Trim(),
                LoaiChungTu = cboLoaiChungTu.SelectedItem.ToString(),
                NgayLap = dtNgayChungTu.Value,
                TongTien = tongTien,
                // Trạng thái ban đầu: 'Chờ duyệt' — Chủ doanh nghiệp duyệt sau
                TrangThai = "Chờ duyệt",
                GhiChu = string.IsNullOrWhiteSpace(txtDienGiai.Text)
                                 ? null : txtDienGiai.Text.Trim(),
                MaDon = don.MaDon,
                // MANV_KIEMTRA để NULL khi lập — trigger chỉ validate khi != NULL
                MaNhanVienKiemTra = null
            };

            try
            {
                bool ok = ChungTuDAL.Insert(ct);
                if (ok)
                {
                    MessageBox.Show(
                        "✅ Lập chứng từ '" + ct.MaChungTu + "' thành công!\n" +
                        "Người lập: " + _tenNVLap + " (" + _maNVLap + ")\n" +
                        "Mã đơn dịch vụ: " + don.MaDon + "\n" +
                        "Tổng tiền: " + lblTongTien.Text + "\n" +
                        "Trạng thái: Chờ duyệt",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    Warn("Lưu chứng từ không thành công, vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // XUẤT HÓA ĐƠN PDF
        // ══════════════════════════════════════════════════════════════════
        private void XuatHoaDon()
        {
            if (string.IsNullOrWhiteSpace(txtMaCT.Text))
            { Warn("Chưa có chứng từ để xuất hóa đơn!"); return; }

            if (cboMaDon.SelectedItem == null)
            { Warn("Chưa chọn đơn dịch vụ để xuất hóa đơn!"); return; }

            if (dgvDichVu.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            { Warn("Chưa có dịch vụ nào để xuất!"); return; }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.FileName = "HoaDon_" + txtMaCT.Text.Trim()
                               + "_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";
                sfd.Title = "Lưu hóa đơn PDF";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    XuatHoaDonPDF(sfd.FileName);
                    var res = MessageBox.Show(
                        "✅ Xuất hóa đơn thành công!\n" + sfd.FileName + "\n\nMở file ngay?",
                        "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                        System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    Warn("Lỗi xuất PDF:\n" + ex.Message);
                }
            }
        }

        private void XuatHoaDonPDF(string filePath)
        {
            string fontPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            if (!File.Exists(fontPath))
                fontPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");

            var baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(
                fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, true);

            var fCompany = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 45, 112));
            var fTitle = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(255, 255, 255));
            var fSectionTitle = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 45, 112));
            var fBold = new iTextSharp.text.Font(baseFont, 9, iTextSharp.text.Font.BOLD);
            var fNormal = new iTextSharp.text.Font(baseFont, 9);
            var fSmall = new iTextSharp.text.Font(baseFont, 8);
            var fWhiteBold = new iTextSharp.text.Font(baseFont, 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE);

            var colorBlue = new iTextSharp.text.BaseColor(0, 70, 127);
            var colorAlt = new iTextSharp.text.BaseColor(240, 248, 255);

            var donHienTai = cboMaDon.SelectedItem as ChungTuDonDichVuItem;
            var khHienTai = cboMaKH.SelectedItem as ChungTuKhachHangItem;

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 36, 36, 36, 36);
                var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // ── Header ──────────────────────────────────────────────
                var topTbl = new iTextSharp.text.pdf.PdfPTable(2) { WidthPercentage = 100 };
                topTbl.SetWidths(new float[] { 0.9f, 4f });
                topTbl.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                iTextSharp.text.Image logoImg = null;
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        _03_VuNgocLinh.Properties.Resources.DDX
                            .Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ms.Position = 0;
                        logoImg = iTextSharp.text.Image.GetInstance(ms);
                        logoImg.ScaleToFit(80f, 80f);
                    }
                }
                catch { logoImg = null; }

                var logoCell = new iTextSharp.text.pdf.PdfPCell
                {
                    Border = iTextSharp.text.Rectangle.NO_BORDER,
                    VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                };
                if (logoImg != null)
                    logoCell.AddElement(logoImg);
                else
                    logoCell.AddElement(new iTextSharp.text.Paragraph("DAI DUONG XANH", fBold));
                topTbl.AddCell(logoCell);

                var compCell = new iTextSharp.text.pdf.PdfPCell
                {
                    Border = iTextSharp.text.Rectangle.NO_BORDER,
                    VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                };
                compCell.AddElement(new iTextSharp.text.Paragraph(
                    "CÔNG TY TNHH TM DV VẬN TẢI QUỐC TẾ ĐẠI DƯƠNG XANH", fCompany));
                compCell.AddElement(new iTextSharp.text.Paragraph(
                    "(DAI DUONG XANH INTERNATIONAL LOGISTICS CO., LTD)", fNormal));
                compCell.AddElement(new iTextSharp.text.Paragraph(
                    "Địa chỉ: 84/10 Đường 49, Phường Hiệp Bình Chánh, Quận Thủ Đức, TP.HCM", fSmall));
                compCell.AddElement(new iTextSharp.text.Paragraph(
                    "ĐT: +84-28-62835558   Email: thanh_duc@go-shipping.vn", fSmall));
                topTbl.AddCell(compCell);
                doc.Add(topTbl);
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 4 });

                // ── Title bar ───────────────────────────────────────────
                var titleTbl = new iTextSharp.text.pdf.PdfPTable(1) { WidthPercentage = 100 };
                titleTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("CHỨNG TỪ LOGISTICS", fTitle))
                {
                    BackgroundColor = colorBlue,
                    HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                    Padding = 8,
                    Border = iTextSharp.text.Rectangle.NO_BORDER
                });
                doc.Add(titleTbl);
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 6 });

                // ── Thông tin chứng từ ──────────────────────────────────
                var infoTbl = new iTextSharp.text.pdf.PdfPTable(2) { WidthPercentage = 100 };
                infoTbl.SetWidths(new float[] { 1f, 1f });
                infoTbl.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                Action<string, string> addInfo = (label, value) =>
                {
                    var p = new iTextSharp.text.Paragraph();
                    p.Add(new iTextSharp.text.Chunk(label + ": ", fBold));
                    p.Add(new iTextSharp.text.Chunk(value ?? "", fNormal));
                    infoTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(p)
                    { Border = iTextSharp.text.Rectangle.NO_BORDER, PaddingBottom = 4 });
                };

                addInfo("Mã chứng từ", txtMaCT.Text.Trim());
                addInfo("Loại chứng từ", cboLoaiChungTu.SelectedItem?.ToString() ?? "");
                addInfo("Số chứng từ", txtSoCT.Text.Trim());
                addInfo("Ngày lập", dtNgayChungTu.Value.ToString("dd/MM/yyyy"));
                addInfo("Mã đơn dịch vụ", donHienTai?.MaDon ?? "");
                addInfo("Trạng thái", "Chờ duyệt");
                // Người lập = NV văn phòng đang đăng nhập
                addInfo("Người lập", (_tenNVLap ?? "") + " (" + (_maNVLap ?? "") + ")");
                doc.Add(infoTbl);
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 6 });

                // ── Thông tin KH + vận chuyển ───────────────────────────
                var custTbl = new iTextSharp.text.pdf.PdfPTable(2) { WidthPercentage = 100 };
                custTbl.SetWidths(new float[] { 1f, 1f });
                custTbl.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                var custBlock = new iTextSharp.text.pdf.PdfPTable(1) { WidthPercentage = 100 };
                custBlock.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                custBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Thông tin khách hàng", fSectionTitle))
                { Border = iTextSharp.text.Rectangle.NO_BORDER, PaddingBottom = 4 });
                custBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Tên: " + (txtTenKH.Text ?? ""), fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                custBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Địa chỉ: " + (khHienTai?.DiaChi ?? ""), fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                custBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Điện thoại: " + (txtSDTKH.Text ?? ""), fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                custBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Email: " + (khHienTai?.Email ?? ""), fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                custTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(custBlock)
                { Border = iTextSharp.text.Rectangle.NO_BORDER });

                var transBlock = new iTextSharp.text.pdf.PdfPTable(1) { WidthPercentage = 100 };
                transBlock.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                transBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Thông tin vận chuyển", fSectionTitle))
                { Border = iTextSharp.text.Rectangle.NO_BORDER, PaddingBottom = 4 });

                string diemDi = string.IsNullOrWhiteSpace(txtDiemDi.Text) ? "(Chưa xác định)" : txtDiemDi.Text.Trim();
                string diemDen = string.IsNullOrWhiteSpace(txtDiemDen.Text) ? "(Chưa xác định)" : txtDiemDen.Text.Trim();
                string ngayDat = donHienTai?.NgayDat.ToString("dd/MM/yyyy") ?? dtNgayChungTu.Value.ToString("dd/MM/yyyy");
                string ngayThucHien = donHienTai?.NgayThucHien.ToString("dd/MM/yyyy") ?? dtNgayChungTu.Value.ToString("dd/MM/yyyy");

                transBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Điểm đi: " + diemDi, fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                transBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Điểm đến: " + diemDen, fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                transBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Ngày đặt: " + ngayDat, fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                transBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Ngày thực hiện: " + ngayThucHien, fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                custTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(transBlock)
                { Border = iTextSharp.text.Rectangle.NO_BORDER });

                doc.Add(custTbl);
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 6 });

                // ── Bảng chi tiết dịch vụ ──────────────────────────────
                var tblDV = new iTextSharp.text.pdf.PdfPTable(7) { WidthPercentage = 100 };
                tblDV.SetWidths(new float[] { 0.5f, 3f, 0.8f, 0.8f, 1.2f, 0.7f, 1.5f });

                foreach (string h in new[] { "STT", "Tên dịch vụ", "ĐVT", "SL", "Đơn giá (đ)", "VAT%", "Thành tiền (đ)" })
                    tblDV.AddCell(new iTextSharp.text.pdf.PdfPCell(
                        new iTextSharp.text.Phrase(h, fWhiteBold))
                    {
                        BackgroundColor = colorBlue,
                        HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        Padding = 6,
                        Border = iTextSharp.text.Rectangle.BOX
                    });

                int stt = 0;
                decimal totalQty = 0, totalAmount = 0;
                foreach (DataGridViewRow row in dgvDichVu.Rows)
                {
                    if (row.IsNewRow) continue;
                    stt++;
                    var bg = (stt % 2 == 0) ? colorAlt : iTextSharp.text.BaseColor.WHITE;

                    Func<string, int, iTextSharp.text.pdf.PdfPCell> mkCell = (text, align) =>
                        new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(text, fNormal))
                        {
                            BackgroundColor = bg,
                            HorizontalAlignment = align,
                            Padding = 6,
                            Border = iTextSharp.text.Rectangle.BOX
                        };

                    decimal dg = ToDecimal(row.Cells[colDonGia.Index].Value);
                    decimal thanh = ToDecimal(row.Cells[colThanhTien.Index].Value);
                    string sl = row.Cells[colSoLuong.Index].Value?.ToString() ?? "0";
                    string vat = row.Cells[colThueSuat.Index].Value?.ToString() ?? "0%";

                    tblDV.AddCell(mkCell(stt.ToString(), iTextSharp.text.Element.ALIGN_CENTER));
                    tblDV.AddCell(mkCell(row.Cells[colTenDV.Index].Value?.ToString() ?? "", iTextSharp.text.Element.ALIGN_LEFT));
                    tblDV.AddCell(mkCell(row.Cells[colDVT.Index].Value?.ToString() ?? "", iTextSharp.text.Element.ALIGN_CENTER));
                    tblDV.AddCell(mkCell(sl, iTextSharp.text.Element.ALIGN_CENTER));
                    tblDV.AddCell(mkCell(dg.ToString("N0"), iTextSharp.text.Element.ALIGN_RIGHT));
                    tblDV.AddCell(mkCell(vat, iTextSharp.text.Element.ALIGN_CENTER));
                    tblDV.AddCell(mkCell(thanh.ToString("N0"), iTextSharp.text.Element.ALIGN_RIGHT));

                    totalQty += ToDecimal(sl);
                    totalAmount += thanh;
                }
                doc.Add(tblDV);
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 6 });

                // ── Tổng kết ────────────────────────────────────────────
                var summaryTbl = new iTextSharp.text.pdf.PdfPTable(2)
                {
                    WidthPercentage = 45,
                    HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                };
                summaryTbl.SetWidths(new float[] { 1.4f, 1f });

                Action<string, string, bool> addSum = (label, value, highlight) =>
                {
                    var bg2 = highlight ? colorBlue : iTextSharp.text.BaseColor.WHITE;
                    var fL = highlight ? fWhiteBold : fBold;
                    var fV = highlight ? fWhiteBold : fNormal;
                    summaryTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(label, fL))
                    { BackgroundColor = bg2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, Padding = 6, Border = iTextSharp.text.Rectangle.BOX });
                    summaryTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(value, fV))
                    { BackgroundColor = bg2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Padding = 6, Border = iTextSharp.text.Rectangle.BOX });
                };

                decimal vatRate = GetThueSuat();
                decimal totalVat = totalAmount * vatRate;
                decimal grandTotal = totalAmount + totalVat;

                addSum("Tổng số lượng:", totalQty.ToString("N0"), false);
                addSum("Tổng tiền dịch vụ:", totalAmount.ToString("N0") + " đ", false);
                addSum("Thuế GTGT:", totalVat.ToString("N0") + " đ", false);
                addSum("TỔNG THANH TOÁN:", grandTotal.ToString("N0") + " đ", true);
                doc.Add(summaryTbl);

                // ── Chữ ký ─────────────────────────────────────────────
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 18 });
                var signTbl = new iTextSharp.text.pdf.PdfPTable(2) { WidthPercentage = 100 };
                signTbl.SetWidths(new float[] { 1f, 1f });

                Func<string, string, iTextSharp.text.pdf.PdfPCell> mkSign = (title, name) =>
                {
                    var p = new iTextSharp.text.Paragraph();
                    p.Add(new iTextSharp.text.Chunk(title + "\n\n", fBold));
                    p.Add(new iTextSharp.text.Chunk(name + "\n", fNormal));
                    return new iTextSharp.text.pdf.PdfPCell(p)
                    {
                        Border = iTextSharp.text.Rectangle.NO_BORDER,
                        HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                    };
                };

                signTbl.AddCell(mkSign("Khách hàng", ""));
                // Chữ ký người lập = NV văn phòng đang đăng nhập
                signTbl.AddCell(mkSign("Người lập chứng từ", _tenNVLap ?? ""));
                doc.Add(signTbl);

                doc.Close();
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // HELPERS
        // ══════════════════════════════════════════════════════════════════
        private void Warn(string msg) =>
            MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private bool Confirm(string msg) =>
            MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes;

        private void ShowConnectionDialog()
        {
            try
            {
                var f = new _03_VuNgocLinh.GUI.Pages.Admin.FrmKetNoiCSDL();
                f.ShowDialog(this);
                LoadData();
            }
            catch
            {
                string input = Interaction.InputBox(
                    "Nhập Connection String:", "Cấu hình Database",
                    DataProvider.ConnectionString);
                if (!string.IsNullOrWhiteSpace(input))
                { DataProvider.ConnectionString = input; LoadData(); }
            }
        }

        // ── Designer adapters ─────────────────────────────────────────────
        private void cboMaDon_SelectedIndexChanged(object sender, EventArgs e) => CboMaDon_Changed(sender, e);
        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e) => CboMaKH_Changed(sender, e);
        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e) { /* không dùng */ }
        private void cbThanhTien_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtMaCT_TextChanged(object sender, EventArgs e) { }
        private void txtSoCT_TextChanged(object sender, EventArgs e) { }
        private void dtNgayChungTu_ValueChanged(object sender, EventArgs e) { }
        private void cboThueSuat_SelectedIndexChanged(object sender, EventArgs e) => RecalcAll();
        private void txtTenNV_TextChanged(object sender, EventArgs e) { }
        private void txtDienGiai_TextChanged(object sender, EventArgs e) { }
        private void txtTenKH_TextChanged(object sender, EventArgs e) { }
        private void btnLuu_Click(object sender, EventArgs e) => LuuChungTu();
        private void btnThoat_Click(object sender, EventArgs e) => this.Close();
        private void btnXuatHD_Click(object sender, EventArgs e) => XuatHoaDon();
        private void btnLamMoi_Click(object sender, EventArgs e) { if (Confirm("Làm mới form?")) ResetForm(); }
        private void dgvDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cbPTTT_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtSDTKH_TextChanged(object sender, EventArgs e) { }
        private void txtEmailNV_TextChanged(object sender, EventArgs e) { }
        private void txtDiemDi_TextChanged(object sender, EventArgs e) { }
        private void txtDiemDen_TextChanged(object sender, EventArgs e) { }
    }
}
