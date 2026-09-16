using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.KhachHang
{
    public partial class FrmLichSuDonHang : Form
    {
        private DataTable _dtOrders;
        private readonly LichSuBUS _lichSuBus = new LichSuBUS();

        public FrmLichSuDonHang()
        {
            InitializeComponent();
            dgvKetQua.SelectionChanged += DgvKetQua_SelectionChanged;
        }

        // ════════════════════════════════════════════════════════════════════
        // LOAD
        // ════════════════════════════════════════════════════════════════════

        private void FrmLichSuDonHang_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyTheme();
                ConfigureDataGrid();
                PopulateTrangThaiCombo();
                LoadOrdersForCurrentCustomer();
                ClearDetailPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // THEME — áp dụng UITheme đồng bộ với cả project
        // ════════════════════════════════════════════════════════════════════

        private void ApplyTheme()
        {
            // Form & panels
            this.BackColor = UITheme.Background;
            this.Text = "Lịch sử đơn hàng — Đại Dương Xanh";

            pnlSearch.BackColor = UITheme.Surface;

        

            // Label "Trạng thái đơn hàng"
            label7.ForeColor = UITheme.TextSecondary;
            label7.Font = UITheme.FontBody;

            // Label "Kết quả tìm kiếm"
            label5.ForeColor = UITheme.TextLight;
            label5.Font = UITheme.FontSmall;

            // ComboBox
            UITheme.ApplyComboBox(cbTenDV);

            // Nút tìm kiếm / đặt lại
            UITheme.ApplyPrimaryButton(btnTimKiem);
            UITheme.ApplyGhostButton(btnReset);

            // Panel detail — trắng, viền nhẹ
            pnlProductDetail.BackColor = UITheme.Surface;

 

            // Labels nhãn (Mã đơn, Đơn giá …)
            foreach (Label lbl in new[] { label13, label4, label17, label19 })
            {
                lbl.ForeColor = UITheme.TextSecondary;
                lbl.Font = UITheme.FontBody;
            }

            // Labels giá trị — đậm, màu chính
            foreach (Label lbl in new[] { lblMaDon, lblDonGia, lblThanhtien })
            {
                lbl.ForeColor = UITheme.TextPrimary;
                lbl.Font = UITheme.FontBold;
            }

            // lblTrangthai sẽ được set màu động khi chọn đơn
            lblTrangthai.Font = new Font("Segoe UI", 10f, FontStyle.Bold);

            // GroupBox "Chi tiết dịch vụ"
            groupBox1.ForeColor = UITheme.Navy;
            groupBox1.Font = new Font("Segoe UI", 10f, FontStyle.Bold);

            // Labels trong groupBox
            foreach (Label lbl in new[] { label8, label10, label11, label14 })
            {
                lbl.ForeColor = UITheme.TextSecondary;
                lbl.Font = UITheme.FontBody;
            }
            foreach (Label lbl in new[] { lblGiaBan, lblDonViTinh, lblNhomdv, lblTenDichvu })
            {
                lbl.ForeColor = UITheme.TextPrimary;
                lbl.Font = UITheme.FontBold;
            }

            // Nút hủy / xem hóa đơn — sẽ set lại ở ClearDetailPanel/ShowSelectedOrderDetails
            btnHuyDon.FlatStyle = FlatStyle.Flat;
            btnHuyDon.FlatAppearance.BorderSize = 0;
            btnHuyDon.Font = UITheme.FontBody;

            btnXemHoaDon.FlatStyle = FlatStyle.Flat;
            btnXemHoaDon.FlatAppearance.BorderSize = 0;
            btnXemHoaDon.Font = UITheme.FontBody;
        }

        // ════════════════════════════════════════════════════════════════════
        // DATAGRIDVIEW — cấu hình cột & style
        // ════════════════════════════════════════════════════════════════════

        private void ConfigureDataGrid()
        {
            UITheme.ApplyDataGrid(dgvKetQua);

            // Ẩn toàn bộ cột auto-generate, rồi định nghĩa lại
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.Columns.Clear();

            dgvKetQua.Columns.Add(MakeCol("MADON", "Mã đơn", 130));
            dgvKetQua.Columns.Add(MakeCol("NGAYDAT", "Ngày đặt", 110, DataGridViewContentAlignment.MiddleCenter));
            dgvKetQua.Columns.Add(MakeCol("DIEMDI", "Điểm đi", 160));
            dgvKetQua.Columns.Add(MakeCol("DIEMDEN", "Điểm đến", 160));
            dgvKetQua.Columns.Add(MakeCol("TRANGTHAI", "Trạng thái", 130, DataGridViewContentAlignment.MiddleCenter));

            dgvKetQua.CellFormatting += DgvKetQua_CellFormatting;
        }

        private static DataGridViewTextBoxColumn MakeCol(
            string field, string header, int width,
            DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = field,
                HeaderText = header,
                Width = width,
                DefaultCellStyle = { Alignment = align, Padding = new Padding(4, 0, 4, 0) },
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            };
        }

        // ── Color-code cột Trạng thái & format ngày ───────────────────────
        private void DgvKetQua_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvKetQua.Columns[e.ColumnIndex];

            // Format ngày
            if (col.DataPropertyName == "NGAYDAT" && e.Value is DateTime dt)
            {
                e.Value = dt.ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
                return;
            }

            // Color-code trạng thái
            if (col.DataPropertyName == "TRANGTHAI" && e.Value != null)
            {
                var cell = dgvKetQua.Rows[e.RowIndex].Cells[e.ColumnIndex];
                ApplyTrangThaiCellStyle(cell, e.Value.ToString());
            }
        }

        private static void ApplyTrangThaiCellStyle(DataGridViewCell cell, string trangThai)
        {
            switch (trangThai)
            {
                case "Hoàn thành":
                    cell.Style.BackColor = Color.FromArgb(232, 245, 233);
                    cell.Style.ForeColor = Color.FromArgb(46, 125, 50);
                    cell.Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    break;
                case "Hủy":
                    cell.Style.BackColor = Color.FromArgb(255, 235, 238);
                    cell.Style.ForeColor = Color.FromArgb(198, 40, 40);
                    cell.Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    break;
                case "Đang xử lý":
                    cell.Style.BackColor = Color.FromArgb(255, 248, 225);
                    cell.Style.ForeColor = Color.FromArgb(245, 127, 23);
                    cell.Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    break;
                case "Đã xác nhận":
                    cell.Style.BackColor = Color.FromArgb(187, 222, 251);
                    cell.Style.ForeColor = Color.FromArgb(21, 101, 192);
                    cell.Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    break;
                case "Chờ xác nhận":
                    cell.Style.BackColor = Color.FromArgb(207, 216, 220);
                    cell.Style.ForeColor = Color.FromArgb(55, 71, 79);
                    cell.Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    break;
                default:
                    cell.Style.BackColor = Color.Empty;
                    cell.Style.ForeColor = Color.Empty;
                    break;
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // DATA
        // ════════════════════════════════════════════════════════════════════

        private void PopulateTrangThaiCombo()
        {
            cbTenDV.Items.Clear();
            cbTenDV.Items.Add("Tất cả");
            cbTenDV.Items.Add("Chờ xác nhận");
            cbTenDV.Items.Add("Đã xác nhận");
            cbTenDV.Items.Add("Đang xử lý");
            cbTenDV.Items.Add("Hoàn thành");
            cbTenDV.Items.Add("Hủy");
            cbTenDV.SelectedIndex = 0;
        }

        private string GetCurrentMaKh() => Session.UserID;

        private void LoadOrdersForCurrentCustomer()
        {
            var maKh = GetCurrentMaKh();
            if (string.IsNullOrWhiteSpace(maKh))
            {
                MessageBox.Show("Không xác định khách hàng đang đăng nhập.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _dtOrders = new DataTable();
                dgvKetQua.DataSource = _dtOrders;
                label5.Text = "0 đơn hàng";
                return;
            }

            // Chỉ lấy các cột cần thiết thay vì SELECT *
            string sql = @"
SELECT MADON, NGAYDAT, DIEMDI, DIEMDEN, TRANGTHAI
FROM DonDichVu
WHERE MAKH = @makh
ORDER BY NGAYDAT DESC";
            _dtOrders = DataProvider.ExecuteQuery(sql, new SqlParameter("@makh", maKh));
            dgvKetQua.DataSource = _dtOrders;
            label5.Text = _dtOrders.Rows.Count + " kết quả";
        }

        // ════════════════════════════════════════════════════════════════════
        // TÌM KIẾM
        // ════════════════════════════════════════════════════════════════════

        private void btnTimKiem_Click(object sender, EventArgs e) => ApplySearch();

        private void ApplySearch()
        {
            var maKh = GetCurrentMaKh();
            if (string.IsNullOrWhiteSpace(maKh))
            {
                MessageBox.Show("Không xác định khách hàng.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selected = cbTenDV.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selected) || selected == "Tất cả")
            {
                LoadOrdersForCurrentCustomer();
                return;
            }

            string sql = @"
SELECT MADON, NGAYDAT, DIEMDI, DIEMDEN, TRANGTHAI
FROM DonDichVu
WHERE MAKH = @makh AND TRANGTHAI = @tt
ORDER BY NGAYDAT DESC";
            _dtOrders = DataProvider.ExecuteQuery(sql,
                new SqlParameter("@makh", maKh),
                new SqlParameter("@tt", selected));
            dgvKetQua.DataSource = _dtOrders;
            label5.Text = _dtOrders.Rows.Count + " kết quả";
            ClearDetailPanel();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbTenDV.SelectedIndex = 0;
            LoadOrdersForCurrentCustomer();
            ClearDetailPanel();
        }

        // ════════════════════════════════════════════════════════════════════
        // CHI TIẾT ĐƠN HÀNG
        // ════════════════════════════════════════════════════════════════════

        private void DgvKetQua_SelectionChanged(object sender, EventArgs e) => ShowSelectedOrderDetails();
        private void dgvKetQua_CellContentClick(object sender, DataGridViewCellEventArgs e) => ShowSelectedOrderDetails();

        private void ShowSelectedOrderDetails()
        {
            try
            {
                if (dgvKetQua.CurrentRow == null) { ClearDetailPanel(); return; }

                DataRow row = null;
                var drv = dgvKetQua.CurrentRow.DataBoundItem;
                if (drv is DataRowView drvView) row = drvView.Row;
                else if (drv is DataRow r) row = r;
                else
                {
                    var cell = dgvKetQua.CurrentRow.Cells["MADON"];
                    if (cell != null)
                        row = DonHangDAL.GetDonHangById(cell.Value?.ToString());
                }

                if (row == null) { ClearDetailPanel(); return; }

                string maDon = Convert.ToString(row["MADON"]);
                string trangThai = Convert.ToString(row["TRANGTHAI"]);

                lblMaDon.Text = maDon;
                SetTrangThaiLabel(trangThai);

                // ── Cập nhật trạng thái nút ──
                bool coTheHuy = trangThai == "Chờ xác nhận" || trangThai == "Đã xác nhận";
                SetButtonState(btnHuyDon, coTheHuy, isDanger: true);
                SetButtonState(btnXemHoaDon, trangThai == "Hoàn thành", isDanger: false);

                // ── Chi tiết dịch vụ ──
                var dtDetails = ChiTietDonDichVuDAL.GetByDon(maDon);
                if (dtDetails.Rows.Count > 0)
                {
                    decimal total = 0m;
                    decimal firstDonGia = 0m;
                    foreach (DataRow d in dtDetails.Rows)
                    {
                        if (d["THANHTIEN"] != DBNull.Value)
                            total += Convert.ToDecimal(d["THANHTIEN"]);
                        else
                        {
                            decimal sl = d["SOLUONG"] != DBNull.Value ? Convert.ToDecimal(d["SOLUONG"]) : 0m;
                            decimal dg = d["DONGIA"] != DBNull.Value ? Convert.ToDecimal(d["DONGIA"]) : 0m;
                            total += sl * dg;
                        }
                    }
                    firstDonGia = dtDetails.Rows[0]["DONGIA"] != DBNull.Value
                        ? Convert.ToDecimal(dtDetails.Rows[0]["DONGIA"]) : 0m;

                    lblDonGia.Text = firstDonGia.ToString("N0") + " đ";
                    lblThanhtien.Text = total.ToString("N0") + " đ";

                    // Dịch vụ đầu tiên
                    string maDv = Convert.ToString(dtDetails.Rows[0]["MADV"]);
                    var dvRow = DichVuDAL.GetById(maDv);
                    if (dvRow != null)
                    {
                        lblTenDichvu.Text = Convert.ToString(dvRow["TENDV"]);
                        lblDonViTinh.Text = Convert.ToString(dvRow["DONVITINH"]);
                        lblGiaBan.Text = dvRow["GIABAN"] != DBNull.Value
                            ? Convert.ToDecimal(dvRow["GIABAN"]).ToString("N0") + " đ" : "—";

                        string maNhom = Convert.ToString(dvRow["MANHOM"]);
                        var dtNhom = DataProvider.ExecuteQuery(
                            "SELECT TENNHOM FROM NhomDichVu WHERE MANHOM = @m",
                            new SqlParameter("@m", maNhom));
                        lblNhomdv.Text = dtNhom.Rows.Count > 0
                            ? Convert.ToString(dtNhom.Rows[0]["TENNHOM"]) : "—";
                    }
                    else
                    {
                        lblTenDichvu.Text = maDv;
                        lblNhomdv.Text = "—";
                        lblDonViTinh.Text = "—";
                        lblGiaBan.Text = "—";
                    }
                }
                else
                {
                    lblDonGia.Text = "—";
                    lblThanhtien.Text = "0 đ";
                    lblTenDichvu.Text = "—";
                    lblNhomdv.Text = "—";
                    lblDonViTinh.Text = "—";
                    lblGiaBan.Text = "—";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị chi tiết: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Màu badge trạng thái trong panel detail ───────────────────────
        private void SetTrangThaiLabel(string trangThai)
        {
            lblTrangthai.Text = trangThai;
            switch (trangThai)
            {
                case "Hoàn thành":
                    lblTrangthai.ForeColor = Color.FromArgb(46, 125, 50);
                    break;
                case "Hủy":
                    lblTrangthai.ForeColor = Color.FromArgb(198, 40, 40);
                    break;
                case "Đang xử lý":
                    lblTrangthai.ForeColor = Color.FromArgb(245, 127, 23);
                    break;
                case "Đã xác nhận":
                    lblTrangthai.ForeColor = Color.FromArgb(21, 101, 192);
                    break;
                case "Chờ xác nhận":
                    lblTrangthai.ForeColor = Color.FromArgb(55, 71, 79);
                    break;
                default:
                    lblTrangthai.ForeColor = UITheme.TextPrimary;
                    break;
            }
        }

        // ── Enable/Disable nút với màu phù hợp ───────────────────────────
        private static void SetButtonState(Button btn, bool enabled, bool isDanger)
        {
            btn.Enabled = enabled;
            if (enabled)
            {
                if (isDanger)
                {
                    btn.BackColor = UITheme.Danger;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                }
                else
                {
                    btn.BackColor = UITheme.Success;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
            else
            {
                btn.BackColor = UITheme.Border;
                btn.ForeColor = UITheme.TextLight;
                btn.FlatAppearance.BorderSize = 0;
            }
        }

        private void ClearDetailPanel()
        {
            lblMaDon.Text = "—";
            lblDonGia.Text = "—";
            lblThanhtien.Text = "—";
            lblTrangthai.Text = "—";
            lblTrangthai.ForeColor = UITheme.TextLight;
            lblTenDichvu.Text = "—";
            lblNhomdv.Text = "—";
            lblDonViTinh.Text = "—";
            lblGiaBan.Text = "—";

            SetButtonState(btnHuyDon, false, isDanger: true);
            SetButtonState(btnXemHoaDon, false, isDanger: false);
        }

        // ════════════════════════════════════════════════════════════════════
        // HỦY ĐƠN
        // ════════════════════════════════════════════════════════════════════

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKetQua.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng cần hủy.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var drv = dgvKetQua.CurrentRow.DataBoundItem as DataRowView;
                string maDon = drv != null
                    ? Convert.ToString(drv.Row["MADON"])
                    : dgvKetQua.CurrentRow.Cells["MADON"]?.Value?.ToString();

                if (string.IsNullOrWhiteSpace(maDon))
                {
                    MessageBox.Show("Mã đơn không hợp lệ.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var row = DonHangDAL.GetDonHangById(maDon);
                if (row == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string currentStatus = Convert.ToString(row["TRANGTHAI"]);
                if (currentStatus != "Chờ xác nhận" && currentStatus != "Đã xác nhận")
                {
                    MessageBox.Show(
                        "Đơn ở trạng thái \"" + currentStatus + "\" không thể hủy.\n" +
                        "Chỉ hủy được khi đơn đang Chờ xác nhận hoặc Đã xác nhận.",
                        "Không thể hủy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy đơn " + maDon + "?",
                    "Xác nhận hủy đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                bool ok = DonHangDAL.UpdateTrangThai(maDon, "Hủy", null);
                if (ok)
                {
                    _lichSuBus.InsertLichSuTrangThai(maDon, currentStatus, "Hủy", null, "Khách hàng hủy đơn");
                    MessageBox.Show("Hủy đơn thành công.", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ApplySearch();
                }
                else
                {
                    MessageBox.Show("Hủy đơn thất bại. Vui lòng thử lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // XEM HÓA ĐƠN PDF
        // ════════════════════════════════════════════════════════════════════

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKetQua.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var drv = dgvKetQua.CurrentRow.DataBoundItem as DataRowView;
                string maDon = drv != null
                    ? Convert.ToString(drv.Row["MADON"])
                    : dgvKetQua.CurrentRow.Cells["MADON"]?.Value?.ToString();

                if (string.IsNullOrWhiteSpace(maDon))
                {
                    MessageBox.Show("Mã đơn không hợp lệ.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow hoaDonRow = HoaDonDAL.GetByMaDon(maDon);
                if (hoaDonRow == null)
                {
                    MessageBox.Show(
                        "Đơn này chưa có hóa đơn.\nHóa đơn sẽ được tự động lập khi đơn chuyển sang trạng thái \"Hoàn thành\".",
                        "Chưa có hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow donRow = DonHangDAL.GetDonHangById(maDon);
                var chiTiet = ChiTietDonDichVuDAL.GetFullByDon(maDon);
                var maKh = GetCurrentMaKh();
                DataRow khRow = string.IsNullOrWhiteSpace(maKh) ? null : KhachHangDAL.GetById(maKh);

                string downloadsFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                if (!Directory.Exists(downloadsFolder))
                    downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                string maHd = Convert.ToString(hoaDonRow["MAHD"]);
                string filePath = Path.Combine(downloadsFolder, "HoaDon_" + maHd + ".pdf");

                XuatHoaDonPDF(filePath, hoaDonRow, donRow, khRow, chiTiet);
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // XUẤT HÓA ĐƠN PDF
        // ════════════════════════════════════════════════════════════════════

        private void XuatHoaDonPDF(string filePath, DataRow hoaDonRow, DataRow donRow, DataRow khRow,
            System.Collections.Generic.List<ChungTuDonDichVuChiTietItem> chiTiet)
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

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 36, 36, 36, 36);
                var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // ── Header công ty ──
                var topTbl = new iTextSharp.text.pdf.PdfPTable(2) { WidthPercentage = 100 };
                topTbl.SetWidths(new float[] { 0.9f, 4f });
                topTbl.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                iTextSharp.text.Image logoImg = null;
                try
                {
                    using (var ms = new MemoryStream())
                    {
                        _03_VuNgocLinh.Properties.Resources.DDX.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
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
                if (logoImg != null) logoCell.AddElement(logoImg);
                else logoCell.AddElement(new iTextSharp.text.Paragraph("DAI DUONG XANH", fBold));
                topTbl.AddCell(logoCell);

                var compCell = new iTextSharp.text.pdf.PdfPCell
                {
                    Border = iTextSharp.text.Rectangle.NO_BORDER,
                    VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                };
                compCell.AddElement(new iTextSharp.text.Paragraph("CÔNG TY TNHH TM DV VẬN TẢI QUỐC TẾ ĐẠI DƯƠNG XANH", fCompany));
                compCell.AddElement(new iTextSharp.text.Paragraph("(DAI DUONG XANH INTERNATIONAL LOGISTICS CO., LTD)", fNormal));
                compCell.AddElement(new iTextSharp.text.Paragraph("Địa chỉ: 84/10 Đường 49, Phường Hiệp Bình Chánh, Quận Thủ Đức, TP.HCM", fSmall));
                compCell.AddElement(new iTextSharp.text.Paragraph("ĐT: +84-28-62835558   Email: thanh_duc@go-shipping.vn", fSmall));
                topTbl.AddCell(compCell);
                doc.Add(topTbl);
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 4 });

                var titleTbl = new iTextSharp.text.pdf.PdfPTable(1) { WidthPercentage = 100 };
                titleTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("HÓA ĐƠN DỊCH VỤ", fTitle))
                {
                    BackgroundColor = colorBlue,
                    HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                    Padding = 8,
                    Border = iTextSharp.text.Rectangle.NO_BORDER
                });
                doc.Add(titleTbl);
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 6 });

                // ── Thông tin hóa đơn ──
                string maHd = Convert.ToString(hoaDonRow["MAHD"]);
                string maDon = Convert.ToString(hoaDonRow["MADON"]);
                DateTime ngayHd = hoaDonRow["NGAYHD"] != DBNull.Value ? Convert.ToDateTime(hoaDonRow["NGAYHD"]) : DateTime.Today;
                string tinhTrang = hoaDonRow["TINHTRANGTHANHTOAN"] != DBNull.Value ? Convert.ToString(hoaDonRow["TINHTRANGTHANHTOAN"]) : "";
                string phuongThuc = hoaDonRow["PHUONGTHUCTHANHTOAN"] != DBNull.Value ? Convert.ToString(hoaDonRow["PHUONGTHUCTHANHTOAN"]) : "";

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

                addInfo("Mã hóa đơn", maHd);
                addInfo("Ngày lập", ngayHd.ToString("dd/MM/yyyy"));
                addInfo("Mã đơn dịch vụ", maDon);
                addInfo("Phương thức thanh toán", phuongThuc);
                addInfo("Tình trạng thanh toán", tinhTrang);
                doc.Add(infoTbl);
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 6 });

                // ── Thông tin khách hàng + vận chuyển ──
                var custTbl = new iTextSharp.text.pdf.PdfPTable(2) { WidthPercentage = 100 };
                custTbl.SetWidths(new float[] { 1f, 1f });
                custTbl.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                var custBlock = new iTextSharp.text.pdf.PdfPTable(1) { WidthPercentage = 100 };
                custBlock.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                custBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Thông tin khách hàng", fSectionTitle))
                { Border = iTextSharp.text.Rectangle.NO_BORDER, PaddingBottom = 4 });
                custBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Tên: " + (khRow != null ? Convert.ToString(khRow["hoTen"]) : ""), fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                custBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Địa chỉ: " + (khRow != null ? Convert.ToString(khRow["diaChi"]) : ""), fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                custBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Điện thoại: " + (khRow != null ? Convert.ToString(khRow["soDienThoai"]) : ""), fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                custBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Email: " + (khRow != null ? Convert.ToString(khRow["email"]) : ""), fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                custTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(custBlock)
                { Border = iTextSharp.text.Rectangle.NO_BORDER });

                var transBlock = new iTextSharp.text.pdf.PdfPTable(1) { WidthPercentage = 100 };
                transBlock.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                transBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Thông tin vận chuyển", fSectionTitle))
                { Border = iTextSharp.text.Rectangle.NO_BORDER, PaddingBottom = 4 });
                string diemDi = donRow != null && donRow["DIEMDI"] != DBNull.Value ? Convert.ToString(donRow["DIEMDI"]) : "";
                string diemDen = donRow != null && donRow["DIEMDEN"] != DBNull.Value ? Convert.ToString(donRow["DIEMDEN"]) : "";
                transBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Điểm đi: " + diemDi, fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                transBlock.AddCell(new iTextSharp.text.pdf.PdfPCell(
                    new iTextSharp.text.Phrase("Điểm đến: " + diemDen, fNormal))
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                custTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(transBlock)
                { Border = iTextSharp.text.Rectangle.NO_BORDER });
                doc.Add(custTbl);
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 6 });

                // ── Bảng dịch vụ ──
                var tblDV = new iTextSharp.text.pdf.PdfPTable(6) { WidthPercentage = 100 };
                tblDV.SetWidths(new float[] { 0.5f, 3f, 0.8f, 0.8f, 1.2f, 1.5f });
                string[] pdfHeaders = { "STT", "Tên dịch vụ", "ĐVT", "SL", "Đơn giá (đ)", "Thành tiền (đ)" };
                foreach (string h in pdfHeaders)
                    tblDV.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(h, fWhiteBold))
                    {
                        BackgroundColor = colorBlue,
                        HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                        Padding = 6,
                        Border = iTextSharp.text.Rectangle.BOX
                    });

                int stt = 0;
                foreach (var dv in chiTiet)
                {
                    stt++;
                    var bg = (stt % 2 == 0) ? colorAlt : iTextSharp.text.BaseColor.WHITE;

                    Func<string, int, iTextSharp.text.pdf.PdfPCell> makeCell = (text, align) =>
                        new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(text, fNormal))
                        { BackgroundColor = bg, HorizontalAlignment = align, Padding = 6, Border = iTextSharp.text.Rectangle.BOX };

                    tblDV.AddCell(makeCell(stt.ToString(), iTextSharp.text.Element.ALIGN_CENTER));
                    tblDV.AddCell(makeCell(dv.TenDichVu, iTextSharp.text.Element.ALIGN_LEFT));
                    tblDV.AddCell(makeCell(dv.DonViTinh, iTextSharp.text.Element.ALIGN_CENTER));
                    tblDV.AddCell(makeCell(dv.SoLuong.ToString(), iTextSharp.text.Element.ALIGN_CENTER));
                    tblDV.AddCell(makeCell(dv.DonGia.ToString("N0"), iTextSharp.text.Element.ALIGN_RIGHT));
                    tblDV.AddCell(makeCell(dv.ThanhTien.ToString("N0"), iTextSharp.text.Element.ALIGN_RIGHT));
                }
                doc.Add(tblDV);
                doc.Add(new iTextSharp.text.Paragraph(" ") { SpacingAfter = 6 });

                // ── Tổng kết ──
                decimal tongTien = hoaDonRow["TONGTIEN"] != DBNull.Value ? Convert.ToDecimal(hoaDonRow["TONGTIEN"]) : 0m;
                decimal thueVat = hoaDonRow["THUEVAT"] != DBNull.Value ? Convert.ToDecimal(hoaDonRow["THUEVAT"]) : 0m;
                decimal chietKhau = hoaDonRow["CHIETKHAU"] != DBNull.Value ? Convert.ToDecimal(hoaDonRow["CHIETKHAU"]) : 0m;
                decimal thanhTien = hoaDonRow["THANHTIEN"] != DBNull.Value ? Convert.ToDecimal(hoaDonRow["THANHTIEN"]) : 0m;

                var summaryTbl = new iTextSharp.text.pdf.PdfPTable(2)
                {
                    WidthPercentage = 45,
                    HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
                };
                summaryTbl.SetWidths(new float[] { 1.4f, 1f });

                Action<string, string, bool> addSumRow = (label, value, highlight) =>
                {
                    var bg2 = highlight ? colorBlue : iTextSharp.text.BaseColor.WHITE;
                    var fL = highlight ? fWhiteBold : fBold;
                    var fV = highlight ? fWhiteBold : fNormal;
                    summaryTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(label, fL))
                    { BackgroundColor = bg2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, Padding = 6, Border = iTextSharp.text.Rectangle.BOX });
                    summaryTbl.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(value, fV))
                    { BackgroundColor = bg2, HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Padding = 6, Border = iTextSharp.text.Rectangle.BOX });
                };

                addSumRow("Tổng tiền dịch vụ:", tongTien.ToString("N0") + " đ", false);
                addSumRow("Thuế GTGT (" + thueVat.ToString("0.##") + "%):",
                    (tongTien * thueVat / 100m).ToString("N0") + " đ", false);
                addSumRow("Chiết khấu (" + chietKhau.ToString("0.##") + "%):",
                    (tongTien * chietKhau / 100m).ToString("N0") + " đ", false);
                addSumRow("THÀNH TIỀN:", thanhTien.ToString("N0") + " đ", true);

                doc.Add(summaryTbl);
                doc.Close();
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // EMPTY STUBS — giữ để thỏa sự kiện từ Designer
        // ════════════════════════════════════════════════════════════════════

        private void cbTenDV_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblTenDV_Click(object sender, EventArgs e) { }
        private void lblDonGia_Click(object sender, EventArgs e) { }
        private void lblThanhtien_Click(object sender, EventArgs e) { }
        private void lblTrangthai_Click(object sender, EventArgs e) { }
        private void lblTenDichvu_Click(object sender, EventArgs e) { }
        private void lblNhomdv_Click(object sender, EventArgs e) { }
        private void lblDonViTinh_Click(object sender, EventArgs e) { }
        private void lblGiaBan_Click(object sender, EventArgs e) { }
        private void pnlSearch_Paint(object sender, PaintEventArgs e) { }
    }
}