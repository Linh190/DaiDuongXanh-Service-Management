using _03_VuNgocLinh;
using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.VanPhong
{
    /// <summary>
    /// Form quản lý đơn hàng dành riêng cho Nhân viên Văn phòng.
    /// 
    /// Nghiệp vụ nhân viên văn phòng:
    ///   ✅ Xem toàn bộ danh sách đơn hàng (tìm kiếm, lọc)
    ///   ✅ Xem chi tiết dịch vụ của từng đơn
    ///   ✅ Xem lịch sử thay đổi trạng thái
    ///   ✅ Ghi chú nội bộ / cập nhật ghi chú hành chính
    ///   ✅ Cập nhật ngày thực hiện (điều phối lịch)
    ///   ✅ Xem thông tin khách hàng và nhân viên phụ trách
    ///   ❌ KHÔNG được thêm / xóa đơn  (quyền nhân viên bán hàng)
    ///   ❌ KHÔNG được thay đổi dịch vụ / đơn giá / số lượng
    ///   ❌ KHÔNG được đổi trạng thái sang Đã xác nhận / Hủy
    ///       (trạng thái nghiệp vụ thuộc quyền bán hàng)
    /// </summary>
    public partial class FrmDonHangVanPhong : Form
    {
        // ── BUS ────────────────────────────────────────────────────────────
        private readonly DonHangBUS _donHangBus = new DonHangBUS();

        // ── STATE ──────────────────────────────────────────────────────────
        private DataTable _dtDonHang;
        private string _maDonDangChon;

        // ══════════════════════════════════════════════════════════════════
        // CONSTRUCTOR
        // ══════════════════════════════════════════════════════════════════
        public FrmDonHangVanPhong()
        {
            InitializeComponent();
            dgvKetQua.SelectionChanged += DgvKetQua_SelectionChanged;
        }

        // ══════════════════════════════════════════════════════════════════
        // LOAD
        // ══════════════════════════════════════════════════════════════════
        private void FrmDonHangVanPhong_Load(object sender, EventArgs e)
        {
            try
            {
                UITheme.ApplyDataGrid(dgvKetQua);
                UITheme.ApplyDataGrid(dgvChiTiet);
                UITheme.ApplyDataGrid(dgvLichSu);

                NapComboKhachHang();
                NapComboTrangThai();
                LoadGrid();
                XoaChiTietPanel();
            }
            catch (Exception ex) { Err("Lỗi khởi tạo form", ex); }
        }

        // ══════════════════════════════════════════════════════════════════
        // NẠP COMBO
        // ══════════════════════════════════════════════════════════════════
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

                cboKhachHang.DisplayMember = "TENKH";
                cboKhachHang.ValueMember = "MAKH";
                cboKhachHang.DataSource = dt;
                cboKhachHang.SelectedIndex = 0;
            }
            catch { cboKhachHang.DataSource = null; }
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
                lblTongDon.Text = $"Tổng: {_dtDonHang?.Rows.Count ?? 0} đơn";
                CapNhatSoLuongTrangThai();
            }
            catch (Exception ex) { Err("Lỗi tải danh sách đơn hàng", ex); }
        }

        private void CapNhatSoLuongTrangThai()
        {
            if (_dtDonHang == null) return;
            int choXacNhan = 0, daXacNhan = 0, dangXuLy = 0, hoanThanh = 0, huy = 0;
            foreach (DataRow r in _dtDonHang.Rows)
            {
                string tt = r["TRANGTHAI"]?.ToString() ?? "";
                if (tt == "Chờ xác nhận") choXacNhan++;
                else if (tt == "Đã xác nhận") daXacNhan++;
                else if (tt == "Đang xử lý") dangXuLy++;
                else if (tt == "Hoàn thành") hoanThanh++;
                else if (tt == "Hủy") huy++;
            }
            lblChoXacNhan.Text = $"Chờ xác nhận: {choXacNhan}";
            lblDaXacNhan.Text = $"Đã xác nhận: {daXacNhan}";
            lblDangXuLy.Text = $"Đang xử lý: {dangXuLy}";
            lblHoanThanh.Text = $"Hoàn thành: {hoanThanh}";
            lblHuy.Text = $"Đã hủy: {huy}";
        }

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
            if (dgvKetQua.CurrentRow?.DataBoundItem == null)
            {
                XoaChiTietPanel();
                return;
            }

            var row = ((DataRowView)dgvKetQua.CurrentRow.DataBoundItem).Row;
            _maDonDangChon = row["MADON"]?.ToString();

            try { HienThiThongTinDon(row); } catch { }
            try { HienThiChiTietDon(_maDonDangChon); } catch { }
            try { HienThiLichSu(_maDonDangChon); } catch { }
        }

        private void HienThiThongTinDon(DataRow row)
        {
            txtMaDon.Text = row["MADON"]?.ToString();

            if (DateTime.TryParse(row["NGAYDAT"]?.ToString(), out DateTime nd))
                txtNgayDat.Text = nd.ToString("dd/MM/yyyy");
            else
                txtNgayDat.Text = "";

            if (DateTime.TryParse(row["NGAYTHUCHIEN"]?.ToString(), out DateTime nth))
                dtpNgayThucHien.Value = nth;
            else
                dtpNgayThucHien.Value = DateTime.Today;

            txtDiemDi.Text = row["DIEMDI"]?.ToString();
            txtDiemDen.Text = row["DIEMDEN"]?.ToString();
            txtGhiChu.Text = row["GHICHU"]?.ToString();

            txtKhachHang.Text = row["TENKH"]?.ToString() ?? row["MAKH"]?.ToString();
            txtNhanVien.Text = row["TENNV"]?.ToString() ?? row["MANV_TIEPNHAN"]?.ToString();

            // Trạng thái hiện tại — hiển thị có màu
            string tt = row["TRANGTHAI"]?.ToString() ?? "";
            lblTrangThaiHienTai.Text = tt;
            lblTrangThaiHienTai.ForeColor = MauTrangThai(tt);

            // Chỉ cho cập nhật ghi chú & ngày thực hiện nếu đơn chưa hoàn thành/hủy
            bool coTheCapNhat = tt != "Hoàn thành" && tt != "Hủy";
            dtpNgayThucHien.Enabled = coTheCapNhat;
            txtGhiChu.ReadOnly = !coTheCapNhat;
            btnCapNhatGhiChu.Enabled = coTheCapNhat;
            btnCapNhatGhiChu.BackColor = coTheCapNhat
                ? UITheme.OceanBlue
                : Color.FromArgb(180, 180, 180);
        }

        private Color MauTrangThai(string tt)
        {
            switch (tt)
            {
                case "Chờ xác nhận": return UITheme.Danger;
                case "Đã xác nhận": return UITheme.OceanBlue;
                case "Đang xử lý": return UITheme.Warning;
                case "Hoàn thành": return UITheme.Success;
                case "Hủy": return Color.Gray;
                default: return UITheme.TextDark;
            }
        }

        private void HienThiChiTietDon(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon)) { dgvChiTiet.DataSource = null; return; }

            try
            {
                const string sql = @"
                    SELECT DV.TENDV              AS [Tên dịch vụ],
                           NDV.TENNHOM           AS [Nhóm],
                           CT.SOLUONG            AS [Số lượng],
                           CT.DONGIA             AS [Đơn giá],
                           CT.THANHTIEN          AS [Thành tiền],
                           ISNULL(CT.GHICHU,'') AS [Ghi chú]
                    FROM   ChiTietDonDichVu CT
                    INNER  JOIN DichVu     DV  ON DV.MADV    = CT.MADV
                    INNER  JOIN NhomDichVu NDV ON NDV.MANHOM = DV.MANHOM
                    WHERE  CT.MADON = @madon
                    ORDER  BY CT.MADV";

                var dt = DataProvider.ExecuteQuery(sql, new SqlParameter("@madon", maDon));
                dgvChiTiet.DataSource = dt;

                // Định dạng cột tiền
                FormatTienColumn(dgvChiTiet, "Đơn giá");
                FormatTienColumn(dgvChiTiet, "Thành tiền");

                // Tổng tiền
                decimal tongTien = 0;
                foreach (DataRow r in dt.Rows)
                    if (r["Thành tiền"] != DBNull.Value)
                        tongTien += Convert.ToDecimal(r["Thành tiền"]);
                lblTongTienChiTiet.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
            }
            catch (Exception ex) { Err("Lỗi tải chi tiết đơn", ex); }
        }

        private void HienThiLichSu(string maDon)
        {
            if (string.IsNullOrWhiteSpace(maDon)) { dgvLichSu.DataSource = null; return; }

            try
            {
                const string sql = @"
                    SELECT LS.THOIGIAN           AS [Thời gian],
                           ISNULL(LS.TRANGTHAI_CU, '(mới)')  AS [Từ trạng thái],
                           LS.TRANGTHAI_MOI      AS [Sang trạng thái],
                           ISNULL(NV.TENNV, LS.MANV_THUCHIEN) AS [Người thực hiện],
                           ISNULL(LS.GHICHU,'') AS [Ghi chú]
                    FROM   LichSuTrangThaiDon LS
                    LEFT   JOIN NhanVien NV ON NV.MANV = LS.MANV_THUCHIEN
                    WHERE  LS.MADON = @madon
                    ORDER  BY LS.THOIGIAN DESC";

                var dt = DataProvider.ExecuteQuery(sql, new SqlParameter("@madon", maDon));
                dgvLichSu.DataSource = dt;
            }
            catch
            {
                // Bảng LichSuTrangThaiDon có thể chưa có dữ liệu — bỏ qua
                dgvLichSu.DataSource = null;
            }
        }

        private void XoaChiTietPanel()
        {
            _maDonDangChon = null;
            txtMaDon.Text = "";
            txtNgayDat.Text = "";
            txtKhachHang.Text = "";
            txtNhanVien.Text = "";
            txtDiemDi.Text = "";
            txtDiemDen.Text = "";
            txtGhiChu.Text = "";
            lblTrangThaiHienTai.Text = "";
            lblTongTienChiTiet.Text = "Tổng tiền: --";
            dtpNgayThucHien.Value = DateTime.Today;
            dgvChiTiet.DataSource = null;
            dgvLichSu.DataSource = null;
            btnCapNhatGhiChu.Enabled = false;
            btnCapNhatGhiChu.BackColor = Color.FromArgb(180, 180, 180);
        }

        // ══════════════════════════════════════════════════════════════════
        // TÌM KIẾM / LỌC
        // ══════════════════════════════════════════════════════════════════
        private void btnTimKiem_Click(object sender, EventArgs e) => ApplyFilters();

        private void ApplyFilters()
        {
            if (_dtDonHang == null) return;

            string keyword = txtTimKiem.Text.Trim().ToLower();
            string trangThai = cboTrangThai.SelectedIndex > 0
                               ? cboTrangThai.SelectedItem?.ToString() : null;
            string makh = null;
            if (cboKhachHang.SelectedIndex > 0 && cboKhachHang.SelectedValue != null
                && cboKhachHang.SelectedValue != DBNull.Value)
                makh = cboKhachHang.SelectedValue.ToString();

            string filter = "";
            var parts = new List<string>();

            if (!string.IsNullOrEmpty(keyword))
                parts.Add($"(CONVERT(MADON, System.Type.GetType('System.String')).ToLower() LIKE '%{keyword}%' " +
                          $"OR CONVERT(TENKH, System.Type.GetType('System.String')).ToLower() LIKE '%{keyword}%' " +
                          $"OR CONVERT(TENNV, System.Type.GetType('System.String')).ToLower() LIKE '%{keyword}%')");

            if (!string.IsNullOrEmpty(trangThai))
                parts.Add($"TRANGTHAI = '{trangThai}'");

            if (!string.IsNullOrEmpty(makh))
                parts.Add($"MAKH = '{makh}'");

            if (dtpTuNgay.Checked)
                parts.Add($"NGAYDAT >= #{dtpTuNgay.Value.Date:yyyy-MM-dd}#");
            if (dtpDenNgay.Checked)
                parts.Add($"NGAYDAT <= #{dtpDenNgay.Value.Date:yyyy-MM-dd}#");

            try
            {
                _dtDonHang.DefaultView.RowFilter = string.Join(" AND ", parts);
            }
            catch
            {
                // Fallback: tìm theo MADON + TENKH + TENNV bằng cách reload
                try
                {
                    _dtDonHang.DefaultView.RowFilter = string.IsNullOrEmpty(trangThai)
                        ? ""
                        : $"TRANGTHAI = '{trangThai}'";
                }
                catch { _dtDonHang.DefaultView.RowFilter = ""; }
            }

            lblTongDon.Text = $"Tổng: {_dtDonHang.DefaultView.Count} đơn";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            cboTrangThai.SelectedIndex = 0;
            cboKhachHang.SelectedIndex = 0;
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
            if (_dtDonHang != null)
                _dtDonHang.DefaultView.RowFilter = "";
            lblTongDon.Text = $"Tổng: {_dtDonHang?.Rows.Count ?? 0} đơn";
            LoadGrid();
        }

        // ══════════════════════════════════════════════════════════════════
        // CẬP NHẬT GHI CHÚ & NGÀY THỰC HIỆN (nghiệp vụ văn phòng)
        // ══════════════════════════════════════════════════════════════════

        /// <summary>
        /// Nhân viên văn phòng được cập nhật:
        ///   - Ghi chú hành chính (GHICHU)
        ///   - Ngày thực hiện (điều phối lịch vận chuyển)
        /// Không thay đổi trạng thái, không chỉnh dịch vụ, không đổi KH/NV phụ trách.
        /// </summary>
        private void btnCapNhatGhiChu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_maDonDangChon))
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng trước.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra ngày thực hiện >= ngày đặt
            if (DateTime.TryParse(txtNgayDat.Text, out DateTime ngayDat))
            {
                if (dtpNgayThucHien.Value.Date < ngayDat.Date)
                {
                    MessageBox.Show("Ngày thực hiện không được trước ngày đặt hàng.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                // Chỉ cập nhật GHICHU và NGAYTHUCHIEN — giữ nguyên toàn bộ thông tin khác
                string sql = @"
                    UPDATE DonDichVu
                    SET    GHICHU        = @ghichu,
                           NGAYTHUCHIEN  = @ngaythuchien
                    WHERE  MADON = @madon";

                int rows = DataProvider.ExecuteNonQuery(sql,
                    new SqlParameter("@ghichu", string.IsNullOrWhiteSpace(txtGhiChu.Text)
                                                ? (object)DBNull.Value
                                                : txtGhiChu.Text.Trim()),
                    new SqlParameter("@ngaythuchien", dtpNgayThucHien.Value.Date),
                    new SqlParameter("@madon", _maDonDangChon));

                if (rows > 0)
                {
                    // Ghi lịch sử nếu ngày thay đổi
                    try
                    {
                        var lsBus = new LichSuBUS();
                        string actor = Session.UserID ?? "VP";
                        lsBus.InsertLichSuTrangThai(
                            _maDonDangChon,
                            null, null, // không đổi trạng thái
                            actor,
                            $"Cập nhật ghi chú & lịch thực hiện bởi NV văn phòng ({Session.UserName ?? actor})");
                    }
                    catch { /* logging không chặn save */ }

                    MessageBox.Show(
                        $"✅ Cập nhật thành công đơn '{_maDonDangChon}'.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string saved = _maDonDangChon;
                    LoadGrid();
                    SelectRowByMaDon(saved);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công, vui lòng thử lại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { Err("Lỗi khi cập nhật ghi chú", ex); }
        }

        // ══════════════════════════════════════════════════════════════════
        // XUẤT DANH SÁCH ĐƠN (Excel CSV đơn giản)
        // ══════════════════════════════════════════════════════════════════
        private void btnXuatDanhSach_Click(object sender, EventArgs e)
        {
            if (_dtDonHang == null || _dtDonHang.DefaultView.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = $"DanhSachDonHang_{DateTime.Now:yyyyMMdd_HHmm}.csv"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var sb = new System.Text.StringBuilder();
                    // Header
                    sb.AppendLine("Mã đơn,Ngày đặt,Ngày thực hiện,Khách hàng,Nhân viên,Điểm đi,Điểm đến,Trạng thái,Ghi chú");

                    foreach (DataRowView drv in _dtDonHang.DefaultView)
                    {
                        var r = drv.Row;
                        string FormatDate(object o) =>
                            DateTime.TryParse(o?.ToString(), out DateTime d) ? d.ToString("dd/MM/yyyy") : "";
                        string Escape(object o) =>
                            "\"" + (o?.ToString() ?? "").Replace("\"", "\"\"") + "\"";

                        sb.AppendLine(string.Join(",", new[]
                        {
                            Escape(r["MADON"]),
                            FormatDate(r["NGAYDAT"]),
                            FormatDate(r["NGAYTHUCHIEN"]),
                            Escape(r["TENKH"]),
                            Escape(r["TENNV"]),
                            Escape(r["DIEMDI"]),
                            Escape(r["DIEMDEN"]),
                            Escape(r["TRANGTHAI"]),
                            Escape(r["GHICHU"])
                        }));
                    }

                    System.IO.File.WriteAllText(sfd.FileName, sb.ToString(),
                        System.Text.Encoding.UTF8);

                    MessageBox.Show($"Xuất thành công: {sfd.FileName}",
                        "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { Err("Lỗi khi xuất danh sách", ex); }
            }
        }

        // ══════════════════════════════════════════════════════════════════
        // CLICK NHANH LÊN LABEL TRẠNG THÁI (lọc nhanh)
        // ══════════════════════════════════════════════════════════════════
        private void lblChoXacNhan_Click(object sender, EventArgs e)
        {
            cboTrangThai.SelectedItem = "Chờ xác nhận";
            ApplyFilters();
        }
        private void lblDaXacNhan_Click(object sender, EventArgs e)
        {
            cboTrangThai.SelectedItem = "Đã xác nhận";
            ApplyFilters();
        }
        private void lblDangXuLy_Click(object sender, EventArgs e)
        {
            cboTrangThai.SelectedItem = "Đang xử lý";
            ApplyFilters();
        }
        private void lblHoanThanh_Click(object sender, EventArgs e)
        {
            cboTrangThai.SelectedItem = "Hoàn thành";
            ApplyFilters();
        }
        private void lblHuy_Click(object sender, EventArgs e)
        {
            cboTrangThai.SelectedItem = "Hủy";
            ApplyFilters();
        }

        // ══════════════════════════════════════════════════════════════════
        // HELPERS
        // ══════════════════════════════════════════════════════════════════
        private void FormatTienColumn(DataGridView dgv, string colName)
        {
            if (dgv.Columns.Contains(colName))
            {
                dgv.Columns[colName].DefaultCellStyle.Format = "N0";
                dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void Err(string message, Exception ex)
        {
            MessageBox.Show($"{message}\n\n{ex.Message}", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ── No-op designer handlers ────────────────────────────────────────
        private void txtTimKiem_TextChanged(object sender, EventArgs e) { }
        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtGhiChu_TextChanged(object sender, EventArgs e) { }
        private void dtpNgayThucHien_ValueChanged(object sender, EventArgs e) { }
        private void dgvKetQua_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tô màu dòng theo trạng thái
            if (dgvKetQua.Columns.Count == 0) return;
            if (!dgvKetQua.Columns.Contains("TRANGTHAI")) return;
            if (e.RowIndex < 0 || e.RowIndex >= dgvKetQua.Rows.Count) return;

            var row = dgvKetQua.Rows[e.RowIndex];
            string tt = row.Cells["TRANGTHAI"]?.Value?.ToString() ?? "";
            Color bg;
            switch (tt)
            {
                case "Chờ xác nhận": bg = Color.FromArgb(255, 245, 245); break;
                case "Đã xác nhận": bg = Color.FromArgb(240, 248, 255); break;
                case "Đang xử lý": bg = Color.FromArgb(255, 253, 235); break;
                case "Hoàn thành": bg = Color.FromArgb(240, 255, 244); break;
                case "Hủy": bg = Color.FromArgb(245, 245, 245); break;
                default: bg = Color.White; break;
            }
            if (!row.Selected)
                row.DefaultCellStyle.BackColor = bg;
        }

        private void lblTongTienChiTiet_Click(object sender, EventArgs e)
        {

        }
    }
}