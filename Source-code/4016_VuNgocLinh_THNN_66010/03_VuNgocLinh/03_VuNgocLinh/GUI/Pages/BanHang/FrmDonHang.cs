using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using _03_VuNgocLinh.GUI.Pages.Owner;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _03_VuNgocLinh.GUI.Pages.BanHang
{
    public partial class FrmDonHang : Form
    {
        // ── BUS ────────────────────────────────────────────────────────────
        private readonly DonHangBUS _donHangBus = new DonHangBUS();
        private readonly KhachHangBUS _khBus = new KhachHangBUS();
        private readonly NhanVienBUS _nvBus = new NhanVienBUS();
        private readonly DichVuBUS _dvBus = new DichVuBUS();

        // ── STATE ──────────────────────────────────────────────────────────
        private DataTable _dtDonHang;           // toàn bộ đơn đã load
        private DataTable _dtChiTietHienTai;    // chi tiết đơn đang chọn
        private string _maDonDangChon;       // MADON đang hiển thị

        // MR02: cho phép Dashboard truyền filter trạng thái vào khi mở form
        public string PresetTrangThai { get; set; }

        // ══════════════════════════════════════════════════════════════════
        // CONSTRUCTOR
        // ══════════════════════════════════════════════════════════════════
        public FrmDonHang()
        {
            InitializeComponent();
            dgvKetQua.SelectionChanged += DgvKetQua_SelectionChanged;
        }

        // ══════════════════════════════════════════════════════════════════
        // LOAD
        // ══════════════════════════════════════════════════════════════════
        private void FrmDonHang_Load(object sender, EventArgs e)
        {
            try
            {
                // Áp dụng theme DataGrid
                UITheme.ApplyDataGrid(dgvKetQua);

                NapComboKhachHang();
                NapComboNhanVien();
                NapComboTrangThai();
                LoadGrid();
                XoaChiTietPanel();
                // MR02: áp filter từ Dashboard nếu được truyền vào
                if (!string.IsNullOrWhiteSpace(PresetTrangThai))
                {
                    cboTrangThai.SelectedItem = PresetTrangThai;
                    ApplyFilters();
                }
            }
            catch (Exception ex) { Err("Lỗi khởi tạo form", ex); }
        }

        // ══════════════════════════════════════════════════════════════════
        // NẠP COMBO
        // ══════════════════════════════════════════════════════════════════

        /// <summary>Chỉ load KH đã có đơn trong DB.</summary>
        private void NapComboKhachHang()
        {
            try
            {
                const string sql = @"
            SELECT DISTINCT KH.MAKH, KH.TENKH
            FROM   KhachHang KH
            INNER  JOIN DonDichVu D ON D.MAKH = KH.MAKH
            ORDER  BY KH.TENKH";
                DataTable dt = DataProvider.ExecuteQuery(sql);

                DataRow all = dt.NewRow();
                all["MAKH"] = DBNull.Value;
                all["TENKH"] = "-- Tất cả --";
                dt.Rows.InsertAt(all, 0);

                // ← DisplayMember/ValueMember phải set TRƯỚC DataSource
                cboKhachHang.DisplayMember = "TENKH";
                cboKhachHang.ValueMember = "MAKH";
                cboKhachHang.DataSource = dt;
                cboKhachHang.SelectedIndex = 0;
            }
            catch { cboKhachHang.DataSource = null; }
        }

        private void NapComboNhanVien()
        {
            try
            {
                const string sql = @"
            SELECT MANV, TENNV
            FROM   NhanVien
            WHERE  TRANGTHAI = N'Đang làm việc'
              AND  VAITRO    IN (N'Nhân viên bán hàng', N'Nhân viên văn phòng')
            ORDER  BY TENNV";
                DataTable dt = DataProvider.ExecuteQuery(sql);

                DataRow all = dt.NewRow();
                all["MANV"] = DBNull.Value;
                all["TENNV"] = "-- Tất cả --";
                dt.Rows.InsertAt(all, 0);

                cboNhanVien.DisplayMember = "TENNV";
                cboNhanVien.ValueMember = "MANV";
                cboNhanVien.DataSource = dt;
                cboNhanVien.SelectedIndex = 0;
            }
            catch { cboNhanVien.DataSource = null; }
        }
        private void NapComboTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("-- Tất cả --");
            cboTrangThai.Items.Add("Chờ xác nhận");
            cboTrangThai.Items.Add("Đã xác nhận");
            cboTrangThai.Items.Add("Đang xử lý");
            cboTrangThai.Items.Add("Hoàn thành");
            cboTrangThai.Items.Add("Hủy");
            cboTrangThai.SelectedIndex = 0;
        }

        // ══════════════════════════════════════════════════════════════════
        // TẢI GRID CHÍNH
        // ══════════════════════════════════════════════════════════════════
        private void LoadGrid()
        {
            try
            {
                _dtDonHang = _donHangBus.LoadDanhSachDonHang();
                dgvKetQua.DataSource = _dtDonHang;
                lblTongTien.Text = $"Tổng: {_dtDonHang?.Rows.Count ?? 0} đơn";

                // Update status counters after load
                UpdateStatusCounts();
            }
            catch (Exception ex) { Err("Lỗi tải danh sách đơn hàng", ex); }
        }
        /// <summary>Sau LoadGrid(), quay focus về đúng đơn vừa thao tác.</summary>
        private void SelectRowByMaDon(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon)) return;
            foreach (DataGridViewRow r in dgvKetQua.Rows)
            {
                if (r.DataBoundItem is DataRowView drv &&
                    string.Equals(drv.Row["MADON"]?.ToString(), maDon,
                                  StringComparison.OrdinalIgnoreCase))
                {
                    dgvKetQua.ClearSelection();
                    r.Selected = true;
                    if (r.Cells.Count > 0) dgvKetQua.CurrentCell = r.Cells[0];
                    break;
                }
            }
        }
        // ══════════════════════════════════════════════════════════════════
        // CHỌN DÒNG TRONG GRID → HIỆN THÔNG TIN
        // ══════════════════════════════════════════════════════════════════
        private void DgvKetQua_SelectionChanged(object sender, EventArgs e)
        {
            // Guard: if no current row, clear detail panel
            if (dgvKetQua.CurrentRow?.DataBoundItem == null)
            {
                XoaChiTietPanel();
                return;
            }

            var row = ((DataRowView)dgvKetQua.CurrentRow.DataBoundItem).Row;
            // Keep current MADON in sync early so other handlers (Xóa, Lưu) can use it even if display fails
            _maDonDangChon = row["MADON"]?.ToString();
            txtMaDonHang.Text = _maDonDangChon;

            // Show main info + details. Wrap in try so selection doesn't break UI when one fails.
            try { HienThiThongTinDon(row); } catch { /* ignore */ }
            try { HienThiChiTietDon(_maDonDangChon); } catch { /* ignore */ }
        }

        // ── Điền thông tin đơn lên pnlSearch ──────────────────────────────
        private void HienThiThongTinDon(DataRow row)
        {
            try
            {
                _maDonDangChon = row["MADON"]?.ToString();
                txtMaDonHang.Text = _maDonDangChon;

                if (DateTime.TryParse(row["NGAYDAT"]?.ToString(), out DateTime nd))
                {
                    dtpNgayDat.Value = nd;
                    dtpNgayThucHien.MinDate = nd; // ← chặn chọn ngày trước ngày đặt
                }
                if (DateTime.TryParse(row["NGAYTHUCHIEN"]?.ToString(), out DateTime nth))
                {
                    dtpNgayThucHien.Value = nth; // ← hiển thị đúng ngày gốc từ DB
                }
                txtDiemDi.Text = row["DIEMDI"]?.ToString();
                txtDiemDen.Text = row["DIEMDEN"]?.ToString();
                txtGhiChu.Text = row["GHICHU"]?.ToString();

                // Khách hàng
                string makh = row["MAKH"]?.ToString();
                TrySetCombo(cboKhachHang, makh, 0);

                // Nhân viên tiếp nhận: nếu DB có MANV thì chọn, nếu không và có đăng nhập thì chọn User hiện tại
                // Nhân viên tiếp nhận
                string manv = row["MANV_TIEPNHAN"]?.ToString();

                if (!string.IsNullOrWhiteSpace(manv))
                {
                    // Đơn đã có NV tiếp nhận → hiển thị đúng người đó
                    TrySetCombo(cboNhanVien, manv, 0);
                }
                else
                {
                    // Đơn chưa có NV (Chờ xác nhận) → mặc định người đang đăng nhập
                    if (!string.IsNullOrWhiteSpace(Session.UserID))
                        TrySetCombo(cboNhanVien, Session.UserID, 0);
                    else
                        cboNhanVien.SelectedIndex = 0;
                }
                // Trạng thái
                string tt = row["TRANGTHAI"]?.ToString();
                if (!string.IsNullOrWhiteSpace(tt) && cboTrangThai.Items.Contains(tt))
                    cboTrangThai.SelectedItem = tt;
                else
                    cboTrangThai.SelectedIndex = 0;
            }
            catch { /* ignore UI hiccups */ }
        }

        // ── Điền chi tiết dịch vụ lên pnlProductDetail ────────────────────
        private void HienThiChiTietDon(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon)) { XoaChiTietPanel(); return; }

            try
            {
                const string sql = @"
            SELECT CT.MADV,
                   DV.TENDV,
                   NDV.TENNHOM,
                   CT.SOLUONG,
                   CT.DONGIA,
                   CT.THANHTIEN,
                   ISNULL(CT.GHICHU, '') AS GHICHU,
                   ISNULL(DV.MOTA, '')   AS MOTA
            FROM   ChiTietDonDichVu CT
            INNER  JOIN DichVu     DV  ON DV.MADV    = CT.MADV
            INNER  JOIN NhomDichVu NDV ON NDV.MANHOM = DV.MANHOM
            WHERE  CT.MADON = @madon
            ORDER  BY CT.MADV";

                _dtChiTietHienTai = DataProvider.ExecuteQuery(sql,
                    new SqlParameter("@madon", maDon));

                if (_dtChiTietHienTai.Rows.Count == 0)
                {
                    // ✅ Không gọi XoaChiTietPanel() — chỉ reset phần chi tiết,
                    //    KHÔNG xóa _maDonDangChon để btnLuu/btnXoa vẫn hoạt động
                    lblTenDV.Text = "(chưa có dịch vụ)";
                    lblGiaBan.Text = "-";
                    lblGhiChu.Text = "-";
                    lblNhomDV.Text = "-";
                    richTextBox1.Text = $"Đơn hàng {maDon} chưa có dịch vụ nào.\n" +
                                         "Nhấn [Thêm] để thêm dịch vụ vào đơn.";
                    lblTongTien.Text = "Tổng tiền:  0 đ";
                    _dtChiTietHienTai = null;
                    return;
                }

                // ... phần còn lại giữ nguyên như cũ ...
                var r0 = _dtChiTietHienTai.Rows[0];
                lblTenDV.Text = r0["TENDV"]?.ToString() ?? "";
                lblNhomDV.Text = r0["TENNHOM"]?.ToString() ?? "";
                lblGiaBan.Text = Convert.ToDecimal(r0["DONGIA"]).ToString("N0") + " đ";
                lblGhiChu.Text = r0["GHICHU"]?.ToString() ?? "";

                var sb = new StringBuilder();
                string mota = r0["MOTA"]?.ToString() ?? "";
                if (!string.IsNullOrWhiteSpace(mota))
                    sb.AppendLine(mota).AppendLine();

                sb.AppendLine("── Danh sách dịch vụ ──");
                decimal tongTien = 0;
                foreach (DataRow r in _dtChiTietHienTai.Rows)
                {
                    int sl = r["SOLUONG"] == DBNull.Value ? 0 : Convert.ToInt32(r["SOLUONG"]);
                    decimal donGia = r["DONGIA"] == DBNull.Value ? 0m : Convert.ToDecimal(r["DONGIA"]);
                    decimal thanhTien = r["THANHTIEN"] == DBNull.Value ? sl * donGia : Convert.ToDecimal(r["THANHTIEN"]);
                    string ghichu = r["GHICHU"]?.ToString() ?? "";

                    sb.Append($"• {r["TENDV"]}  x{sl}  @{donGia:N0} đ  =  {thanhTien:N0} đ");
                    if (!string.IsNullOrWhiteSpace(ghichu)) sb.Append($"  ({ghichu})");
                    sb.AppendLine();
                    tongTien += thanhTien;
                }

                richTextBox1.Text = sb.ToString();
                lblTongTien.Text = $"Tổng tiền:  {tongTien:N0} đ";
            }
            catch (Exception ex) { Err("Lỗi tải chi tiết đơn", ex); }
        }
        private void XoaChiTietPanel()
        {
            lblTenDV.Text = "<name>";
            lblGiaBan.Text = "<name>";
            lblGhiChu.Text = "<name>";
            lblNhomDV.Text = "<name>";
            richTextBox1.Text = "";
            lblTongTien.Text = "Tổng tiền:  0 đ";
            _dtChiTietHienTai = null;
        }

        // ══════════════════════════════════════════════════════════════════
        // TÌM KIẾM / LỌC
        // ══════════════════════════════════════════════════════════════════
        private void btnTimKiem_Click(object sender, EventArgs e) => ApplyFilters();

        private void ApplyFilters()
        {
            if (_dtDonHang == null) return;

            var filters = new List<string>();

            string maDon = txtMaDonHang.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(maDon))
                filters.Add($"MADON LIKE '%{Esc(maDon)}%'");

            string diemDi = txtDiemDi.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(diemDi))
                filters.Add($"DIEMDI LIKE '%{Esc(diemDi)}%'");

            string diemDen = txtDiemDen.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(diemDen))
                filters.Add($"DIEMDEN LIKE '%{Esc(diemDen)}%'");

            if (cboKhachHang.SelectedIndex > 0 && cboKhachHang.SelectedValue != DBNull.Value)
                filters.Add($"MAKH = '{Esc(cboKhachHang.SelectedValue?.ToString())}'");

            if (cboNhanVien.SelectedIndex > 0 && cboNhanVien.SelectedValue != DBNull.Value)
                filters.Add($"MANV_TIEPNHAN = '{Esc(cboNhanVien.SelectedValue?.ToString())}'");

            if (cboTrangThai.SelectedIndex > 0)
                filters.Add($"TRANGTHAI = '{Esc(cboTrangThai.SelectedItem?.ToString())}'");

            _dtDonHang.DefaultView.RowFilter = string.Join(" AND ", filters);
            lblTongTien.Text = $"Tổng: {_dtDonHang.DefaultView.Count} đơn";

            // Update counters for currently-visible rows
            UpdateStatusCounts();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaDonHang.Clear();
            txtDiemDi.Clear();
            txtDiemDen.Clear();
            txtGhiChu.Clear();
            cboKhachHang.SelectedIndex = 0;
            NapComboNhanVien();
            cboTrangThai.SelectedIndex = 0;
            if (_dtDonHang != null) _dtDonHang.DefaultView.RowFilter = "";
            lblTongTien.Text = $"Tổng: {_dtDonHang?.Rows.Count ?? 0} đơn";
            _maDonDangChon = null; // ← thêm dòng này
            XoaChiTietPanel();

            // Update status counters after reset
            UpdateStatusCounts();
        }

        // ══════════════════════════════════════════════════════════════════
        // LƯU — cập nhật đơn đang chọn vào database
        // ══════════════════════════════════════════════════════════════════
        private void btnLuu_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("=== btnLuu_Click ===");
            System.Diagnostics.Debug.WriteLine("_maDonDangChon = " + _maDonDangChon);
            System.Diagnostics.Debug.WriteLine("DiemDi = " + txtDiemDi.Text);
            System.Diagnostics.Debug.WriteLine("DiemDen = " + txtDiemDen.Text);
            System.Diagnostics.Debug.WriteLine("TrangThai = " + cboTrangThai.SelectedItem);
            System.Diagnostics.Debug.WriteLine("NhanVien index = " + cboNhanVien.SelectedIndex);
            System.Diagnostics.Debug.WriteLine("NhanVien value = " + cboNhanVien.SelectedValue);
            System.Diagnostics.Debug.WriteLine("_dtChiTietHienTai = " + (_dtChiTietHienTai == null ? "NULL" : _dtChiTietHienTai.Rows.Count + " dòng"));

            if (string.IsNullOrWhiteSpace(_maDonDangChon))
            {
                MessageBox.Show("Chưa chọn đơn hàng nào để lưu.");
                return;
            }

            if (dtpNgayThucHien.Value.Date < dtpNgayDat.Value.Date)
            {
                MessageBox.Show("Ngày thực hiện không được trước ngày đặt.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Validate: chuyển sang Đã xác nhận/Đang xử lý → bắt buộc có NV tiếp nhận
            string trangThaiMoi = cboTrangThai.SelectedIndex > 0
                                  ? cboTrangThai.SelectedItem?.ToString() : null;

            if (trangThaiMoi == "Đã xác nhận" || trangThaiMoi == "Đang xử lý" || trangThaiMoi == "Hoàn thành")
            {
                if (cboNhanVien.SelectedIndex <= 0 || cboNhanVien.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Phải chọn Nhân viên tiếp nhận trước khi xác nhận đơn.",
                        "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboNhanVien.Focus();
                    return;
                }
            }

            var dto = new DonDichVuDTO
            {
                MaDon = _maDonDangChon,
                NgayThucHien = dtpNgayThucHien.Value,
                DiemDi = txtDiemDi.Text?.Trim(),
                DiemDen = txtDiemDen.Text?.Trim(),
                GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim(),
                TrangThai = trangThaiMoi,
                MaKhachHang = cboKhachHang.SelectedIndex > 0 ? cboKhachHang.SelectedValue?.ToString() : null,
                MaNhanVienTiepNhan = cboNhanVien.SelectedIndex > 0 ? cboNhanVien.SelectedValue?.ToString() : null
            };

            // Build chiTietList — null nếu không có thay đổi chi tiết
            List<ChiTietDonDichVuDTO> chiTietList = null;
            if (_dtChiTietHienTai != null)
            {
                chiTietList = new List<ChiTietDonDichVuDTO>();
                foreach (DataRow r in _dtChiTietHienTai.Rows)
                {
                    if (r.RowState == DataRowState.Deleted) continue;
                    chiTietList.Add(new ChiTietDonDichVuDTO
                    {
                        MaDon = _maDonDangChon,
                        MaDichVu = r["MADV"]?.ToString(),
                        SoLuong = r["SOLUONG"] == DBNull.Value ? 0 : Convert.ToInt32(r["SOLUONG"]),
                        DonGia = r["DONGIA"] == DBNull.Value ? 0m : Convert.ToDecimal(r["DONGIA"]),
                        GhiChu = r["GHICHU"]?.ToString()
                    });
                }
            }

            try
            {
                // --- Read old state for logging ---
                string oldStatus = null;
                string oldManv = null;
                try
                {
                    var oldRow = DonHangDAL.GetDonHangById(dto.MaDon);
                    if (oldRow != null)
                    {
                        oldStatus = oldRow["TRANGTHAI"]?.ToString();
                        oldManv = oldRow["MANV_TIEPNHAN"]?.ToString();
                    }
                }
                catch
                {
                    // ignore failures reading old state, still proceed with update
                }

                string thongBao;
                bool ok = _donHangBus.CapNhatDonHang(dto, chiTietList, out thongBao);

                if (ok)
                {
                    // Insert history only when something relevant changed (status or assigned NV)
                    try
                    {
                        string newStatus = dto.TrangThai;
                        string newManv = dto.MaNhanVienTiepNhan;

                        bool statusChanged = !string.Equals(oldStatus ?? "", newStatus ?? "", StringComparison.OrdinalIgnoreCase);
                        bool manvChanged = !string.Equals(oldManv ?? "", newManv ?? "", StringComparison.OrdinalIgnoreCase);

                        if (statusChanged || manvChanged)
                        {
                            // Prefer Session.UserID as the actor (who clicked Lưu). Fallback to selected NV.
                            string actorManv = !string.IsNullOrWhiteSpace(Session.UserID) ? Session.UserID : newManv;
                            var lsBus = new LichSuBUS();
                            lsBus.InsertLichSuTrangThai(dto.MaDon, oldStatus, newStatus, actorManv, $"Cập nhật bởi {(Session.UserName ?? actorManv)}");
                        }
                    }
                    catch
                    {
                        // Logging must not block save — swallow errors silently (or log to file if you add logging)
                    }

                    MessageBox.Show(
                        thongBao ?? "Cập nhật đơn hàng thành công.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    string saved = _maDonDangChon;
                    LoadGrid();
                    SelectRowByMaDon(saved);
                }
                else
                {
                    MessageBox.Show(
                        thongBao ?? "Cập nhật thất bại, vui lòng thử lại.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { Err("Lỗi khi lưu đơn hàng", ex); }

        }        // ══════════════════════════════════════════════════════════════════
        // THÊM / SỬA / XÓA
        // ══════════════════════════════════════════════════════════════════
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FrmThemDonDV())
                {
                    var dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        // Reload grid so the newly created order appears
                        LoadGrid();

                        // Try to select the new order if the created form exposes the MADON.
                        // FrmThemDonDV currently closes with DialogResult.OK but does not expose the MADON,
                        // so this reflection is a safe no-op if the property doesn't exist.
                        try
                        {
                            var prop = frm.GetType().GetProperty("CreatedMaDon");
                            if (prop != null)
                            {
                                var created = prop.GetValue(frm) as string;
                                if (!string.IsNullOrWhiteSpace(created))
                                    SelectRowByMaDon(created);
                            }
                        }
                        catch
                        {
                            // ignore - selecting is best-effort
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form tạo đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_maDonDangChon))
            {
                MessageBox.Show("Chọn một đơn hàng để thao tác.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Nếu có chi tiết → hỏi xóa dòng chi tiết hay xóa cả đơn
            if (_dtChiTietHienTai != null && _dtChiTietHienTai.Rows.Count > 0)
            {
                var choice = MessageBox.Show(
                    "Chọn YES để xóa một dòng dịch vụ.\nChọn NO để xóa toàn bộ đơn hàng.",
                    "Xác nhận xóa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (choice == DialogResult.Yes) { XoaDongChiTiet(); return; }
                if (choice == DialogResult.No) { XoaDon(); return; }
                // Cancel → không làm gì
                return;
            }

            XoaDon();
        }

        private void XoaDongChiTiet()
        {
            if (_dtChiTietHienTai == null) return;

            var tenList = new List<string>();
            foreach (DataRow r in _dtChiTietHienTai.Rows)
                if (r.RowState != DataRowState.Deleted)
                    tenList.Add($"{r["MADV"]} - {r["TENDV"]}");

            if (tenList.Count == 0) return;

            string chon = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập STT dòng cần xóa:\n" +
                string.Join("\n", System.Linq.Enumerable.Select(tenList, (t, i) => $"{i + 1}. {t}")),
                "Xóa dịch vụ", "1");

            if (!int.TryParse(chon, out int stt) || stt < 1 || stt > tenList.Count) return;

            _dtChiTietHienTai.Rows[stt - 1].Delete();
            HienThiChiTietDonTuDtHienTai();

            MessageBox.Show("Đã xóa dòng. Nhấn Lưu để lưu vào database.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void XoaDon()
        {
            if (MessageBox.Show($"Xóa đơn '{_maDonDangChon}'? Thao tác không thể hoàn tác.",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                string tb;
                bool ok = _donHangBus.XoaDonHang(_maDonDangChon, out tb);
                MessageBox.Show(tb, ok ? "Thành công" : "Thất bại",
                    MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (ok)
                {
                    _maDonDangChon = null; // ← clear tường minh ở đây, không phải trong XoaChiTietPanel
                    XoaChiTietPanel();
                    LoadGrid();
                }
            }
            catch (Exception ex) { Err("Lỗi khi xóa đơn", ex); }
        }
        // ══════════════════════════════════════════════════════════════════
        // REFRESH CHI TIẾT TỪ _dtChiTietHienTai (sau khi thêm/sửa local)
        // ══════════════════════════════════════════════════════════════════
        private void HienThiChiTietDonTuDtHienTai()
        {
            if (_dtChiTietHienTai == null) { XoaChiTietPanel(); return; }

            var sb = new StringBuilder();
            decimal tongTien = 0;
            bool first = true;

            foreach (DataRow r in _dtChiTietHienTai.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;

                if (first)
                {
                    lblTenDV.Text = r["TENDV"]?.ToString() ?? "";
                    lblNhomDV.Text = r["TENNHOM"]?.ToString() ?? "";
                    lblGiaBan.Text = Convert.ToDecimal(r["DONGIA"]).ToString("N0") + " đ";
                    lblGhiChu.Text = r["GHICHU"]?.ToString() ?? "";

                    string mota = r["MOTA"]?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(mota))
                        sb.AppendLine(mota).AppendLine();

                    sb.AppendLine("── Danh sách dịch vụ ──");
                    first = false;
                }

                int sl = r["SOLUONG"] == DBNull.Value ? 0 : Convert.ToInt32(r["SOLUONG"]);
                decimal donGia = r["DONGIA"] == DBNull.Value ? 0m : Convert.ToDecimal(r["DONGIA"]);
                decimal thanhTien = r["THANHTIEN"] == DBNull.Value ? sl * donGia : Convert.ToDecimal(r["THANHTIEN"]);
                string ghichu = r["GHICHU"]?.ToString() ?? "";

                sb.Append($"• {r["TENDV"]}  x{sl}  @{donGia:N0} đ  =  {thanhTien:N0} đ");
                if (!string.IsNullOrWhiteSpace(ghichu)) sb.Append($"  ({ghichu})");
                sb.AppendLine();
                tongTien += thanhTien;
            }

            richTextBox1.Text = sb.ToString();
            lblTongTien.Text = $"Tổng tiền:  {tongTien:N0} đ";
        }

        // ══════════════════════════════════════════════════════════════════
        // HELPER
        // ══════════════════════════════════════════════════════════════════
        private DataTable TaoBangChiTietRong()
        {
            var dt = new DataTable();
            dt.Columns.Add("MADV", typeof(string));
            dt.Columns.Add("TENDV", typeof(string));
            dt.Columns.Add("TENNHOM", typeof(string));
            dt.Columns.Add("SOLUONG", typeof(int));
            dt.Columns.Add("DONGIA", typeof(decimal));
            dt.Columns.Add("THANHTIEN", typeof(decimal));
            dt.Columns.Add("GHICHU", typeof(string));
            dt.Columns.Add("MOTA", typeof(string));
            return dt;
        }

        /// <summary>
        /// Try set combo by value more robustly: search the DataSource rows for a matching value.
        /// If fallbackIndex >= 0 and no match, set that index.
        /// </summary>
        private static void TrySetCombo(ComboBox cbo, string value, int fallbackIndex)
        {
            if (cbo == null) return;

            try
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    if (fallbackIndex >= 0) cbo.SelectedIndex = fallbackIndex;
                    return;
                }

                // If DataSource is a DataTable or BindingSource to DataTable, search for the value in ValueMember column
                var ds = cbo.DataSource;
                if (ds is DataTable dt && !string.IsNullOrWhiteSpace(cbo.ValueMember))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var v = dt.Rows[i][cbo.ValueMember];
                        if (v != DBNull.Value && string.Equals(Convert.ToString(v), value, StringComparison.OrdinalIgnoreCase))
                        {
                            cbo.SelectedIndex = i;
                            return;
                        }
                    }
                }
                else if (ds is System.Windows.Forms.BindingSource bs && bs.DataSource is DataTable bdt && !string.IsNullOrWhiteSpace(cbo.ValueMember))
                {
                    for (int i = 0; i < bdt.Rows.Count; i++)
                    {
                        var v = bdt.Rows[i][cbo.ValueMember];
                        if (v != DBNull.Value && string.Equals(Convert.ToString(v), value, StringComparison.OrdinalIgnoreCase))
                        {
                            cbo.SelectedIndex = i;
                            return;
                        }
                    }
                }
                // fallback to setting SelectedValue (existing behavior)
                cbo.SelectedValue = value;
                if (cbo.SelectedIndex >= 0) return;

                if (fallbackIndex >= 0) cbo.SelectedIndex = fallbackIndex;
            }
            catch
            {
                if (fallbackIndex >= 0) cbo.SelectedIndex = fallbackIndex;
            }
        }

        /// <summary>
        /// Heuristic: check if order details indicate transport-type services requiring DiemDi/DiemDen.
        /// </summary>
        private bool OrderRequiresTransport(DataTable dtDetails)
        {
            if (dtDetails == null || dtDetails.Rows.Count == 0) return false;
            var keywords = new[] { "vận chuyển", "vận tải", "giao nhận", "chuyển phát", "door-to-door", "door to door" };
            foreach (DataRow r in dtDetails.Rows)
            {
                string tenNhom = (r["TENNHOM"]?.ToString() ?? "").ToLowerInvariant();
                string tenDv = (r["TENDV"]?.ToString() ?? "").ToLowerInvariant();
                foreach (var k in keywords)
                {
                    if (tenNhom.Contains(k) || tenDv.Contains(k)) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Escapes single quotes for use in DataTable.RowFilter expressions.
        /// </summary>
        private static string Esc(string input)
        {
            return input?.Replace("'", "''") ?? "";
        }

        /// <summary>
        /// Update the four status labels showing counts for each status.
        /// Uses the current DataView (filtered view) if available so counts reflect visible rows.
        /// Falls back to counting all loaded rows.
        /// </summary>
        private void UpdateStatusCounts()
        {
            int cho = 0, daXacNhan = 0, dangXuLy = 0, daHoanThanh = 0;

            if (_dtDonHang == null)
            {
                lblChoXacNhan.Text = "Chờ xác nhận: 0";
                lblDaXacNhan.Text = "Đã xác nhận: 0";
                lblDangXuLy.Text = "Đang xử lý: 0";
                lblDaHoanThanh.Text = "Hoàn thành: 0";
                return;
            }

            // Prefer counting visible rows (DefaultView) so the badges reflect current filter.
            var view = _dtDonHang.DefaultView;
            foreach (DataRowView drv in view)
            {
                var tt = (drv["TRANGTHAI"]?.ToString() ?? "").Trim();
                if (string.Equals(tt, "Chờ xác nhận", StringComparison.OrdinalIgnoreCase))
                    cho++;
                else if (string.Equals(tt, "Đã xác nhận", StringComparison.OrdinalIgnoreCase))
                    daXacNhan++;
                else if (string.Equals(tt, "Đang xử lý", StringComparison.OrdinalIgnoreCase))
                    dangXuLy++;
                else if (string.Equals(tt, "Hoàn thành", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(tt, "Đã hoàn thành", StringComparison.OrdinalIgnoreCase))
                    daHoanThanh++;
            }

            lblChoXacNhan.Text = $"Chờ xác nhận: {cho}";
            lblDaXacNhan.Text = $"Đã xác nhận: {daXacNhan}";
            lblDangXuLy.Text = $"Đang xử lý: {dangXuLy}";
            lblDaHoanThanh.Text = $"Hoàn thành: {daHoanThanh}";
        }

        // ══════════════════════════════════════════════════════════════════
        // NO-OP HANDLERS (Designer)
        // ══════════════════════════════════════════════════════════════════
        private void label2_Click(object sender, EventArgs e) { }
        private void txtMaDonHang_TextChanged(object sender, EventArgs e) { }
        private void dtpNgayDat_ValueChanged(object sender, EventArgs e) { }
        private void dtpNgayThucHien_ValueChanged(object sender, EventArgs e) { }
        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtGhiChu_TextChanged(object sender, EventArgs e) { }
        private void txtDiemDi_TextChanged(object sender, EventArgs e) { }
        private void txtDiemDen_TextChanged(object sender, EventArgs e) { }
        private void lblTenDV_Click(object sender, EventArgs e) { }
        private void lblGiaBan_Click(object sender, EventArgs e) { }
        private void lblGhiChu_Click(object sender, EventArgs e) { }
        private void lblNhomDV_Click(object sender, EventArgs e) { }
        private void lblTongTien_Click(object sender, EventArgs e) { }

        private void lblChoXacNhan_Click(object sender, EventArgs e)
        {
            // Quick filter: set TrangThai to "Chờ xác nhận" and apply filters
            if (cboTrangThai.Items.Contains("Chờ xác nhận"))
            {
                cboTrangThai.SelectedItem = "Chờ xác nhận";
                ApplyFilters();
            }
        }

        private void lblDaXacNhan_Click(object sender, EventArgs e)
        {
            if (cboTrangThai.Items.Contains("Đã xác nhận"))
            {
                cboTrangThai.SelectedItem = "Đã xác nhận";
                ApplyFilters();
            }
        }

        private void lblDangXuLy_Click(object sender, EventArgs e)
        {
            if (cboTrangThai.Items.Contains("Đang xử lý"))
            {
                cboTrangThai.SelectedItem = "Đang xử lý";
                ApplyFilters();
            }
        }

        private void lblDaHoanThanh_Click(object sender, EventArgs e)
        {
            // Note: NapComboTrangThai uses "Hoàn thành" (without "Đã"), accept both
            if (cboTrangThai.Items.Contains("Hoàn thành"))
            {
                cboTrangThai.SelectedItem = "Hoàn thành";
                ApplyFilters();
            }
            else if (cboTrangThai.Items.Contains("Đã hoàn thành"))
            {
                cboTrangThai.SelectedItem = "Đã hoàn thành";
                ApplyFilters();
            }
        }

        /// <summary>
        /// Show error message and optionally log exception details.
        /// </summary>
        private void Err(string message, Exception ex)
        {
            MessageBox.Show($"{message}\n\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Optionally log ex.ToString() to a file or logging system here if needed.
        }

        private void btnXuatBaoCaoPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Prepare data
                var statuses = new[] { "Chờ xác nhận", "Đã xác nhận", "Đang xử lý", "Hoàn thành", "Hủy" };
                var statusCounts = new Dictionary<string, int>();
                foreach (var s in statuses) statusCounts[s] = 0;
                var dtStatus = DataProvider.ExecuteQuery("SELECT TRANGTHAI, COUNT(*) AS CNT FROM DonDichVu GROUP BY TRANGTHAI");
                foreach (DataRow r in dtStatus.Rows)
                {
                    var t = Convert.ToString(r["TRANGTHAI"]);
                    int c = r["CNT"] == DBNull.Value ? 0 : Convert.ToInt32(r["CNT"]);
                    if (statusCounts.ContainsKey(t)) statusCounts[t] = c;
                    else statusCounts[t] = c;
                }

                string sqlTopNV = @"
                    SELECT TOP 10 ISNULL(NV.TENNV, N'(Không xác định)') AS TenNV, COUNT(*) AS CNT
                    FROM DonDichVu D
                    LEFT JOIN NhanVien NV ON D.MANV_TIEPNHAN = NV.MANV
                    GROUP BY NV.TENNV
                    ORDER BY CNT DESC, NV.TENNV";
                var dtTopNV = DataProvider.ExecuteQuery(sqlTopNV);

                string sqlTopKH = @"
                    SELECT TOP 10 ISNULL(KH.TENKH, N'(Không xác định)') AS TenKH, COUNT(*) AS CNT
                    FROM DonDichVu D
                    LEFT JOIN KhachHang KH ON D.MAKH = KH.MAKH
                    GROUP BY KH.TENKH
                    ORDER BY CNT DESC, KH.TENKH";
                var dtTopKH = DataProvider.ExecuteQuery(sqlTopKH);

                string sqlOrders = @"
                    SELECT D.MADON, D.NGAYDAT, ISNULL(KH.TENKH, N'') AS TENKH, ISNULL(NV.TENNV, N'') AS TENNV_TIEPNHAN, D.TRANGTHAI
                    FROM DonDichVu D
                    LEFT JOIN KhachHang KH ON D.MAKH = KH.MAKH
                    LEFT JOIN NhanVien NV ON D.MANV_TIEPNHAN = NV.MANV
                    ORDER BY D.NGAYDAT DESC, D.MADON";
                var dtOrders = DataProvider.ExecuteQuery(sqlOrders);

                // 2) Create charts into PNG memory streams
                using (var chartStatusImg = CreateChartImage(statusCounts.Select(kv => Tuple.Create(kv.Key, kv.Value)).ToList(),
                                                            "Trạng thái đơn", "Trạng thái", "Số lượng", 900, 340))
                using (var chartNVImg = CreateChartImage(dtTopNV.AsEnumerable()
                                                            .Select(r => Tuple.Create(Convert.ToString(r["TenNV"]), Convert.ToInt32(r["CNT"])))
                                                            .ToList(),
                                                          "Hiệu suất nhân viên (Top 10)", "Nhân viên", "Số đơn", 900, 340))
                using (var chartKHImg = CreateChartImage(dtTopKH.AsEnumerable()
                                                            .Select(r => Tuple.Create(Convert.ToString(r["TenKH"]), Convert.ToInt32(r["CNT"])))
                                                            .ToList(),
                                                          "Khách hàng (Top 10)", "Khách hàng", "Số đơn", 900, 340))
                {
                    string fileName = $"BaoCaoDonDichVu_{DateTime.Now:yyyyMMdd}.pdf";
                    using (SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF files (*.pdf)|*.pdf", FileName = fileName })
                    {
                        if (sfd.ShowDialog() != DialogResult.OK) return;

                        using (PdfDocument doc = new PdfDocument())
                        {
                            doc.Info.Title = "Báo cáo thống kê đơn dịch vụ";

                            var titleFont = new XFont("Verdana", 16, XFontStyle.Bold);
                            var headerFont = new XFont("Verdana", 10, XFontStyle.Bold);
                            var normalFont = new XFont("Verdana", 9, XFontStyle.Regular);
                            var smallFont = new XFont("Verdana", 8, XFontStyle.Regular);

                            const double margin = 30;

                            // first page
                            PdfPage page = doc.AddPage();
                            page.Size = PdfSharp.PageSize.A4;
                            page.Orientation = PdfSharp.PageOrientation.Landscape;
                            double pageW = page.Width;
                            double pageH = page.Height;
                            double usableW = pageW - margin * 2;

                            using (XGraphics gfx = XGraphics.FromPdfPage(page))
                            {
                                double y = margin;

                                string companyName = "CÔNG TY TNHH TM DV VẬN TẢI QUỐC TẾ ĐẠI DƯƠNG XANH";
                                string companyAddr = "Địa chỉ: 84/10 Đường 49,Phường Hiệp Bình Chánh, Quận Thủ Đức, TP.HCM, Việt Nam";
                                string companyPhone = "ĐT: +84-28-62835558 ";
                                string companyEmail = "Email: thanh_duc@go-shipping.vn ";

                                // logo size and company text start X
                                const double logoSize = 60;
                                double xCompany = margin + logoSize + 10;

                                // Draw logo from embedded resources (PNG)
                                try
                                {
                                    using (var msLogo = new MemoryStream())
                                    {
                                        _03_VuNgocLinh.Properties.Resources.DDX.Save(msLogo, ImageFormat.Png);
                                        msLogo.Position = 0;
                                        using (XImage logoImage = XImage.FromStream(msLogo))
                                        {
                                            gfx.DrawImage(logoImage, margin, y, logoSize, logoSize);
                                        }
                                    }
                                }
                                catch
                                {
                                    // if logo fails, continue and draw text only
                                }

                                // Draw company text to the right of logo
                                gfx.DrawString(companyName, headerFont, XBrushes.Black, new XRect(xCompany, y, usableW - (logoSize + 10), 16), XStringFormats.TopLeft);
                                y += 16;
                                gfx.DrawString(companyAddr, normalFont, XBrushes.Black, new XRect(xCompany, y, usableW - (logoSize + 10), 12), XStringFormats.TopLeft);
                                y += 12;
                                gfx.DrawString(companyPhone, normalFont, XBrushes.Black, new XRect(xCompany, y, usableW - (logoSize + 10), 12), XStringFormats.TopLeft);
                                y += 12;
                                gfx.DrawString(companyEmail, normalFont, XBrushes.Black, new XRect(xCompany, y, usableW - (logoSize + 10), 12), XStringFormats.TopLeft);

                                // Make room below logo for the title/charts
                                y = margin + Math.Max(logoSize, 16 + 12 + 12 + 12) + 10;

                                // Date right-aligned (unchanged)
                                string dateText = "Ngày xuất báo cáo: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                                gfx.DrawString(dateText, smallFont, XBrushes.Gray, new XRect(margin, margin, usableW - 10, 12), XStringFormats.TopRight);

                                y += 20;

                                string title = "BÁO CÁO THỐNG KÊ ĐƠN DỊCH VỤ";
                                gfx.DrawString(title, titleFont, XBrushes.Black, new XRect(margin, y, usableW, 28), XStringFormats.TopCenter);
                                y += 34;

                                gfx.DrawString("PHẦN 1: THỐNG KÊ TỔNG QUAN", headerFont, XBrushes.Black, new XRect(margin, y, usableW, 14), XStringFormats.TopLeft);
                                y += 18;

                                using (var imgStream = new MemoryStream(chartStatusImg.ToArray()))
                                using (var img = XImage.FromStream(imgStream))
                                {
                                    double imgH = Math.Min(260, (img.PixelHeight * (usableW / img.PixelWidth)));
                                    gfx.DrawImage(img, margin, y, usableW, imgH);
                                    y += imgH + 12;
                                }

                                // optionally draw NV/KH charts on same page if space; otherwise added on next pages below
                            }

                            // always add a second page with NV + KH charts to avoid layout complexity
                            PdfPage page2 = doc.AddPage();
                            page2.Size = PdfSharp.PageSize.A4;
                            page2.Orientation = PdfSharp.PageOrientation.Landscape;
                            using (XGraphics gfx2 = XGraphics.FromPdfPage(page2))
                            {
                                double y2 = margin;
                                gfx2.DrawString("PHẦN 1.1: BIỂU ĐỒ HIỆU SUẤT NHÂN VIÊN (Top 10)", headerFont, XBrushes.Black, new XRect(margin, y2, usableW, 14), XStringFormats.TopLeft);
                                y2 += 18;
                                using (var imgStream = new MemoryStream(chartNVImg.ToArray()))
                                using (var img = XImage.FromStream(imgStream))
                                {
                                    gfx2.DrawImage(img, margin, y2, usableW, 260);
                                    y2 += 260 + 12;
                                }

                                gfx2.DrawString("PHẦN 1.2: BIỂU ĐỒ KHÁCH HÀNG (Top 10)", headerFont, XBrushes.Black, new XRect(margin, y2, usableW, 14), XStringFormats.TopLeft);
                                y2 += 18;
                                using (var imgStream = new MemoryStream(chartKHImg.ToArray()))
                                using (var img = XImage.FromStream(imgStream))
                                {
                                    gfx2.DrawImage(img, margin, y2, usableW, 260);
                                    y2 += 260 + 12;
                                }
                            }

                            // 4) Orders table (paginated)
                            DrawDataTableAsPdf(doc, dtOrders, new[] { "MADON", "NGAYDAT", "TENKH", "TENNV_TIEPNHAN", "TRANGTHAI" },
                                              new[] { "Mã đơn", "Ngày đặt", "Khách hàng", "Nhân viên tiếp nhận", "Trạng thái" },
                                              "PHẦN 2: DANH SÁCH ĐƠN DỊCH VỤ", "Danh sách đơn dịch vụ", margin);

                            // 5) Employee stats table
                            DrawDataTableAsPdf(doc, dtTopNV, new[] { "TenNV", "CNT" },
                                              new[] { "Nhân viên", "Số lượng đơn" },
                                              "PHẦN 3: THỐNG KÊ THEO NHÂN VIÊN", "Thống kê theo nhân viên (Top 10)", margin);

                            // 6) Customer stats table
                            DrawDataTableAsPdf(doc, dtTopKH, new[] { "TenKH", "CNT" },
                                              new[] { "Khách hàng", "Số lượng đơn" },
                                              "PHẦN 4: THỐNG KÊ THEO KHÁCH HÀNG", "Thống kê theo khách hàng (Top 10)", margin);

                            // 7) Signature page
                            PdfPage sigPage = doc.AddPage();
                            sigPage.Size = PdfSharp.PageSize.A4;
                            sigPage.Orientation = PdfSharp.PageOrientation.Landscape;
                            using (XGraphics gfx = XGraphics.FromPdfPage(sigPage))
                            {
                                double y = sigPage.Height / 2;

                                // Label
                                string signerLabel = "Người lập báo cáo:";
                                gfx.DrawString(signerLabel, headerFont, XBrushes.Black, new XRect(400, y, 300, 20), XStringFormats.TopCenter);

                                // Try to resolve full display name from DB:
                                // 1) If Session.UserName contains login (TENDANGNHAP) -> lookup TaiKhoan -> NhanVien.TENNV
                                // 2) Otherwise if Session.UserID contains MANV -> lookup NhanVien.TENNV
                                string displayName = null;
                                try
                                {
                                    if (!string.IsNullOrWhiteSpace(Session.UserName))
                                    {
                                        var dt = DataProvider.ExecuteQuery(@"
                SELECT ISNULL(NV.TENNV, '') AS TENNV
                FROM TaiKhoan TK
                LEFT JOIN NhanVien NV ON TK.MANV = NV.MANV
                WHERE TK.TENDANGNHAP = @login",
                new SqlParameter("@login", Session.UserName));
                                        if (dt.Rows.Count > 0 && dt.Rows[0]["TENNV"] != DBNull.Value)
                                            displayName = dt.Rows[0]["TENNV"].ToString();
                                    }

                                    if (string.IsNullOrWhiteSpace(displayName) && !string.IsNullOrWhiteSpace(Session.UserID))
                                    {
                                        var dt2 = DataProvider.ExecuteQuery(
                                            "SELECT TENNV FROM NhanVien WHERE MANV = @manv",
                                            new SqlParameter("@manv", Session.UserID));
                                        if (dt2.Rows.Count > 0 && dt2.Rows[0]["TENNV"] != DBNull.Value)
                                            displayName = dt2.Rows[0]["TENNV"].ToString();
                                    }
                                }
                                catch
                                {
                                    // ignore DB lookup errors — fallback below
                                }

                                // Fallbacks
                                if (string.IsNullOrWhiteSpace(displayName))
                                    displayName = !string.IsNullOrWhiteSpace(Session.UserName)
                                        ? Session.UserName
                                        : (!string.IsNullOrWhiteSpace(Session.UserID) ? Session.UserID : "(Chưa đăng nhập)");

                                // Draw resolved display name
                                y += 24;
                                gfx.DrawString(displayName, titleFont, XBrushes.Black, new XRect(400, y, 300, 20), XStringFormats.TopCenter);
                            }

                            doc.Save(sfd.FileName);
                        }
                    }
                }

                MessageBox.Show("Báo cáo đã được xuất thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất báo cáo PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper: create chart image from pairs (returns MemoryStream PNG)
        private MemoryStream CreateChartImage(List<Tuple<string, int>> items, string chartTitle, string xTitle, string yTitle, int width, int height)
        {
            var ms = new MemoryStream();
            using (var chart = new Chart())
            {
                chart.Width = width;
                chart.Height = height;

                var area = new ChartArea("ca");
                area.BackColor = System.Drawing.Color.White;
                area.AxisX.LabelStyle.Angle = -45;
                area.AxisX.Interval = 1;
                area.AxisY.LabelStyle.Format = "N0";
                chart.ChartAreas.Add(area);

                var series = new Series("s")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true,
                    Font = new System.Drawing.Font("Segoe UI", 9F)
                };

                foreach (var it in items)
                {
                    double val = Convert.ToDouble(it.Item2);
                    int idx = series.Points.AddY(val);
                    series.Points[idx].AxisLabel = it.Item1;
                    series.Points[idx].ToolTip = $"{it.Item1}: {val:N0}";
                    series.Points[idx].Label = $"{val:N0}";
                }

                chart.Series.Add(series);
                chart.Titles.Add(chartTitle);

                chart.SaveImage(ms, ChartImageFormat.Png);
                ms.Position = 0;
            }
            return ms;
        }

        // Helper: draw DataTable as paged PDF table
        private void DrawDataTableAsPdf(PdfDocument doc, DataTable table, string[] columnNames, string[] headers, string sectionTitle, string tableTitle, double margin)
        {
            if (table == null) return;
            const double lineHeight = 16;
            var fontHeader = new XFont("Verdana", 11, XFontStyle.Bold);
            var fontCell = new XFont("Verdana", 9, XFontStyle.Regular);
            var fontSmall = new XFont("Verdana", 8, XFontStyle.Regular);

            int colCount = columnNames.Length;

            PdfPage page = doc.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            double pageW = page.Width;
            double pageH = page.Height;
            double usableW = pageW - margin * 2;

            double[] colWidths = new double[colCount];
            for (int i = 0; i < colCount; i++) colWidths[i] = usableW / colCount;

            int rowIndex = 0;
            bool firstPage = true;

            while (firstPage || rowIndex < table.Rows.Count)
            {
                PdfPage p;
                if (firstPage) { p = page; firstPage = false; }
                else
                {
                    p = doc.AddPage();
                    p.Size = PdfSharp.PageSize.A4;
                    p.Orientation = PdfSharp.PageOrientation.Landscape;
                }

                using (XGraphics gfx = XGraphics.FromPdfPage(p))
                {
                    double y = margin;

                    gfx.DrawString(sectionTitle, fontHeader, XBrushes.Black, new XRect(margin, y, usableW, 16), XStringFormats.TopLeft);
                    y += 20;
                    gfx.DrawString(tableTitle, new XFont("Verdana", 10, XFontStyle.Bold), XBrushes.Black, new XRect(margin, y, usableW, 14), XStringFormats.TopLeft);
                    y += 18;

                    double x = margin;
                    for (int c = 0; c < colCount; c++)
                    {
                        gfx.DrawRectangle(XPens.Black, XBrushes.LightGray, x, y, colWidths[c], lineHeight);
                        gfx.DrawString(headers[c], fontCell, XBrushes.Black, new XRect(x + 4, y + 2, colWidths[c] - 8, lineHeight), XStringFormats.TopLeft);
                        x += colWidths[c];
                    }
                    y += lineHeight;

                    while (rowIndex < table.Rows.Count)
                    {
                        if (y + lineHeight > p.Height - margin - 40) break;
                        x = margin;
                        var row = table.Rows[rowIndex];
                        for (int c = 0; c < colCount; c++)
                        {
                            string text = "";
                            try
                            {
                                var obj = row[columnNames[c]];
                                if (obj == DBNull.Value || obj == null) text = "";
                                else if (obj is DateTime dt) text = dt.ToString("dd/MM/yyyy");
                                else text = obj.ToString();
                            }
                            catch { text = ""; }

                            gfx.DrawRectangle(XPens.Black, x, y, colWidths[c], lineHeight);
                            gfx.DrawString(TruncateToFit(gfx, text, fontCell, colWidths[c] - 8), fontCell, XBrushes.Black, new XRect(x + 4, y + 2, colWidths[c] - 8, lineHeight), XStringFormats.TopLeft);
                            x += colWidths[c];
                        }
                        y += lineHeight;
                        rowIndex++;
                    }

                    // Footer page number (use current total pages as page index)
                    string footer = $"Trang {doc.Pages.Count}";
                    gfx.DrawString(footer, fontSmall, XBrushes.Gray, new XRect(margin, p.Height - margin + 5, usableW, 14), XStringFormats.TopRight);
                }
            }
        }
        private string TruncateToFit(XGraphics gfx, string text, XFont font, double maxWidth)
        {
            if (string.IsNullOrEmpty(text)) return text;
            if (gfx.MeasureString(text, font).Width <= maxWidth) return text;

            string ellipsis = "...";
            int len = text.Length;
            while (len > 0)
            {
                string candidate = text.Substring(0, len) + ellipsis;
                if (gfx.MeasureString(candidate, font).Width <= maxWidth)
                    return candidate;
                len--;
            }
            return ellipsis;
        }

    }
}