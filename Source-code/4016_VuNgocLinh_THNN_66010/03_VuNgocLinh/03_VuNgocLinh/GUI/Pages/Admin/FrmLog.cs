using _03_VuNgocLinh.DAL;
using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    public partial class FrmLog : Form
    {
        // MR07: ComboBox lọc theo tên nhân viên (thêm vào panel2 theo cách lập trình)
        private System.Windows.Forms.ComboBox _cboNhanVien;

        public FrmLog()
        {
            InitializeComponent();
            this.Load += FrmLog_Load;
        }

        // ─────────────────────────────────────────────
        // KHỞI TẠO
        // ─────────────────────────────────────────────
        private void FrmLog_Load(object sender, EventArgs e)
        {
            // Nếu bạn có một TableAdapter/ DataSet tương thích, giữ dòng Fill.
            // Nếu không (như trường hợp tên khác nhau trong partial classes),
            // an toàn hơn là bỏ / comment dòng auto-generated dưới đây:
            // this.lichSuTrangThaiDonTableAdapter1.Fill(this.quanLyDichVu_DaiDuongXanhDataSet3.LichSuTrangThaiDon);

            try
            {
                // Format DateTimePicker
                dtpTuNgay.Format = DateTimePickerFormat.Short;
                dtpDenNgay.Format = DateTimePickerFormat.Short;

                // Default: last 30 days, nhưng nếu DB có dữ liệu ngoài khoảng này
                // ta sẽ lấy min/max ngày thực tế trong DB để hiển thị dữ liệu.
                DateTime defaultFrom = DateTime.Today.AddDays(-30);
                DateTime defaultTo = DateTime.Today;

                // Lấy min/max ngày từ DB (an toàn: trong try/catch)
                try
                {
                    object minObj = DataProvider.ExecuteScalar("SELECT MIN(CONVERT(date, THOIGIANCAPNHAT)) FROM LichSuTrangThaiDon");
                    object maxObj = DataProvider.ExecuteScalar("SELECT MAX(CONVERT(date, THOIGIANCAPNHAT)) FROM LichSuTrangThaiDon");

                    if (minObj != null && minObj != DBNull.Value)
                    {
                        DateTime minDate = Convert.ToDateTime(minObj);
                        // nếu minDate lớn hơn defaultFrom, giữ defaultFrom (thường không cần)
                        defaultFrom = minDate < defaultFrom ? minDate : defaultFrom;
                    }

                    if (maxObj != null && maxObj != DBNull.Value)
                    {
                        DateTime maxDate = Convert.ToDateTime(maxObj);
                        // đảm bảo defaultTo không nhỏ hơn maxDate
                        defaultTo = maxDate > defaultTo ? maxDate : defaultTo;
                    }
                }
                catch
                {
                    // Nếu việc lấy min/max lỗi, fallback vẫn là last 30 days - không crash
                }

                // Gán giá trị cho DateTimePicker (safe: đảm bảo nằm trong giới hạn control)
                try { dtpTuNgay.Value = defaultFrom; } catch { dtpTuNgay.Value = DateTime.Today.AddDays(-30); }
                try { dtpDenNgay.Value = defaultTo; } catch { dtpDenNgay.Value = DateTime.Today; }

                // DateTimePicker chi tiết – chỉ hiển thị, không cho chỉnh
                dtpThoiGian.Format = DateTimePickerFormat.Custom;
                dtpThoiGian.CustomFormat = "dd/MM/yyyy HH:mm:ss";
                dtpThoiGian.Enabled = false;

                // Khóa các TextBox chi tiết (chỉ đọc)
                SetDetailReadOnly(true);

                CauHinhGrid();
                NapComboTrangThai();
                NapComboVaiTro();
                NapComboNhanVien(); // MR07

                // Wire sự kiện chọn dòng
                dgvLog.CellClick += DgvLog_CellClick;
                dgvLog.SelectionChanged += DgvLog_SelectionChanged;

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo Log: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDetailReadOnly(bool readOnly)
        {
            txtMaLichSu.ReadOnly = readOnly;
            txtMaDonDV.ReadOnly = readOnly;
            txtTrangThaiCu.ReadOnly = readOnly;
            txtTrangThaiMoi.ReadOnly = readOnly;
            txtTenNhanVien.ReadOnly = readOnly;
            txtGhiChu.ReadOnly = readOnly;
        }

        // ─────────────────────────────────────────────
        // CẤU HÌNH GRID
        // ─────────────────────────────────────────────
        private void CauHinhGrid()
        {
            if (dgvLog == null) return;

            dgvLog.AutoGenerateColumns = false;
            dgvLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLog.MultiSelect = false;
            dgvLog.ReadOnly = true;
            dgvLog.AllowUserToAddRows = false;
            dgvLog.Columns.Clear();

            dgvLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaLichSu",
                HeaderText = "Mã lịch sử",
                DataPropertyName = "MALICHSU",
                Width = 90
            });
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaDon",
                HeaderText = "Mã đơn",
                DataPropertyName = "MADON",
                Width = 120
            });
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenNV",
                HeaderText = "Nhân viên cập nhật",
                DataPropertyName = "TENNV",
                Width = 160
            });
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTrangThaiCu",
                HeaderText = "Trạng thái cũ",
                DataPropertyName = "TRANGTHAI_CU",
                Width = 140
            });
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTrangThaiMoi",
                HeaderText = "Trạng thái mới",
                DataPropertyName = "TRANGTHAI_MOI",
                Width = 140
            });
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colThoiGian",
                HeaderText = "Thời gian cập nhật",
                DataPropertyName = "THOIGIANCAPNHAT",
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGhiChu",
                HeaderText = "Ghi chú",
                DataPropertyName = "GHICHU",
                Width = 300,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        // ─────────────────────────────────────────────
        // MR07: thêm ComboBox tên NV vào panel2 theo cách lập trình
        // ─────────────────────────────────────────────
        private void NapComboNhanVien()
        {
            try
            {
                cboNhanVien.Items.Clear();
                cboNhanVien.Items.Add("-- Tất cả --");

                var dt = DataProvider.ExecuteQuery(
                    "SELECT TENNV FROM NhanVien ORDER BY TENNV");

                foreach (DataRow r in dt.Rows)
                {
                    cboNhanVien.Items.Add(r["TENNV"].ToString());
                }

                cboNhanVien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // ─────────────────────────────────────────────
        // NẠP COMBO
        // ─────────────────────────────────────────────
        /// <summary>
        /// ComboBox "Trạng thái" lọc theo TRANGTHAI_MOI
        /// (đúng với CHECK constraint trong schema)
        /// </summary>
        private void NapComboTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("-- Tất cả --");
            cboTrangThai.Items.Add(N("Chờ xác nhận"));
            cboTrangThai.Items.Add(N("Đã xác nhận"));
            cboTrangThai.Items.Add(N("Đang xử lý"));
            cboTrangThai.Items.Add(N("Hoàn thành"));
            cboTrangThai.Items.Add(N("Hủy"));
            cboTrangThai.SelectedIndex = 0;
        }

        /// <summary>
        /// ComboBox "Vai trò" theo CHECK constraint NhanVien.VAITRO
        /// </summary>
        private void NapComboVaiTro()
        {
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("-- Tất cả --");
            cboVaiTro.Items.Add(N("Nhân viên bán hàng"));
            cboVaiTro.Items.Add(N("Nhân viên văn phòng"));
            cboVaiTro.Items.Add(N("Nhân viên quản lý hệ thống"));
            cboVaiTro.Items.Add(N("Chủ doanh nghiệp"));
            cboVaiTro.SelectedIndex = 0;
        }

        // helper tránh nhầm lẫn về encoding khi so sánh chuỗi tiếng Việt
        private static string N(string s) => s;

        // ─────────────────────────────────────────────
        // TẢI DỮ LIỆU
        // ─────────────────────────────────────────────
        private void LoadData()
        {
            try
            {
                if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sql = new StringBuilder();
                var @params = new System.Collections.Generic.List<SqlParameter>();

                sql.AppendLine(@"
SELECT  LS.MALICHSU,
        LS.MADON,
        ISNULL(NV.TENNV, N'—')   AS TENNV,
        ISNULL(NV.VAITRO, N'—')  AS VAITRO,
        LS.TRANGTHAI_CU,
        LS.TRANGTHAI_MOI,
        LS.THOIGIANCAPNHAT,
        ISNULL(LS.GHICHU, '')    AS GHICHU
FROM    LichSuTrangThaiDon LS
LEFT JOIN NhanVien NV ON LS.MANV_CAPNHAT = NV.MANV
WHERE   1 = 1");

                // Lọc theo khoảng ngày
                sql.AppendLine("  AND CONVERT(date, LS.THOIGIANCAPNHAT) BETWEEN @tu AND @den");
                @params.Add(new SqlParameter("@tu", dtpTuNgay.Value.Date));
                @params.Add(new SqlParameter("@den", dtpDenNgay.Value.Date));

                // Lọc theo từ khóa (Mã đơn / Tên NV / Ghi chú)
                string kw = txtMaDon.Text?.Trim();
                if (!string.IsNullOrWhiteSpace(kw))
                {
                    sql.AppendLine("  AND (LS.MADON LIKE @kw OR NV.TENNV LIKE @kw OR LS.GHICHU LIKE @kw)");
                    @params.Add(new SqlParameter("@kw", "%" + kw + "%"));
                }

                // Lọc theo Trạng thái mới
                if (cboTrangThai.SelectedIndex > 0)
                {
                    sql.AppendLine("  AND LS.TRANGTHAI_MOI = @tt");
                    @params.Add(new SqlParameter("@tt", cboTrangThai.SelectedItem.ToString()));
                }

                // Lọc theo Vai trò nhân viên
                if (cboVaiTro.SelectedIndex > 0)
                {
                    sql.AppendLine("  AND NV.VAITRO = @vt");
                    @params.Add(new SqlParameter("@vt", cboVaiTro.SelectedItem.ToString()));
                }

                // Lọc theo tên nhân viên — MR07
                if (cboNhanVien.SelectedIndex > 0)
                {
                    sql.AppendLine("AND NV.TENNV = @tennv");
                    @params.Add(new SqlParameter("@tennv",
                        cboNhanVien.SelectedItem.ToString()));
                }

                sql.AppendLine("ORDER BY LS.THOIGIANCAPNHAT DESC");

                DataTable dt = DataProvider.ExecuteQuery(sql.ToString(), @params.ToArray());
                dgvLog.DataSource = dt;

                XoaChiTiet();   // Xóa panel chi tiết mỗi khi tải lại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu log: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        // HIỂN THỊ CHI TIẾT
        // ─────────────────────────────────────────────
        private void DgvLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            HienThiChiTiet(dgvLog.Rows[e.RowIndex]);
        }

        private void DgvLog_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLog.CurrentRow == null) { XoaChiTiet(); return; }
            HienThiChiTiet(dgvLog.CurrentRow);
        }

        private void HienThiChiTiet(DataGridViewRow row)
        {
            if (row == null || row.IsNewRow) { XoaChiTiet(); return; }

            try
            {
                // Đọc từ DataTable gốc để lấy đủ các cột kể cả cột không hiển thị
                string maLS = Val(row, "MALICHSU");
                string maDon = Val(row, "MADON");
                string ttCu = Val(row, "TRANGTHAI_CU");
                string ttMoi = Val(row, "TRANGTHAI_MOI");
                string tenNV = Val(row, "TENNV");
                string ghiChu = Val(row, "GHICHU");
                string tgStr = Val(row, "THOIGIANCAPNHAT");

                txtMaLichSu.Text = maLS;
                txtMaDonDV.Text = maDon;
                txtTrangThaiCu.Text = ttCu;
                txtTrangThaiMoi.Text = ttMoi;
                txtTenNhanVien.Text = tenNV;
                txtGhiChu.Text = ghiChu;

                // Set DateTimePicker chi tiết
                if (DateTime.TryParse(tgStr, out DateTime tg))
                {
                    dtpThoiGian.Value = tg;
                }
                else
                {
                    dtpThoiGian.Value = DateTime.Now;
                }
            }
            catch
            {
                XoaChiTiet();
            }
        }

        private void XoaChiTiet()
        {
            txtMaLichSu.Clear();
            txtMaDonDV.Clear();
            txtTrangThaiCu.Clear();
            txtTrangThaiMoi.Clear();
            txtTenNhanVien.Clear();
            txtGhiChu.Clear();
            dtpThoiGian.Value = DateTime.Now;
        }

        /// <summary>Lấy giá trị ô từ DataTable gốc qua tên cột thực (DataPropertyName).</summary>
        private string Val(DataGridViewRow row, string dataColName)
        {
            try
            {
                if (row.DataGridView?.DataSource is DataTable dt && dt.Columns.Contains(dataColName))
                    return Convert.ToString(dt.Rows[row.Index][dataColName]) ?? "";
                // fallback: tìm column theo DataPropertyName
                foreach (DataGridViewColumn col in row.DataGridView.Columns)
                {
                    if (col.DataPropertyName == dataColName)
                        return row.Cells[col.Index]?.Value?.ToString() ?? "";
                }
                return "";
            }
            catch { return ""; }
        }

        // ─────────────────────────────────────────────
        // SỰ KIỆN CÁC BỘ LỌC
        // ─────────────────────────────────────────────
        private void btnTimKiem_Click(object sender, EventArgs e) => LoadData();


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDon.Clear();
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;
            cboTrangThai.SelectedIndex = 0;
            cboVaiTro.SelectedIndex = 0;
            LoadData();
        }

        // Tìm kiếm ngay khi nhập từ khóa
        private void txtMaDon_TextChanged(object sender, EventArgs e) => LoadData();

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e) => LoadData();
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e) => LoadData();

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e) => LoadData();
        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e) => LoadData();

        // ─────────────────────────────────────────────
        // TẢI LẠI (btnTaiLai)
        // ─────────────────────────────────────────────
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtMaDon.Clear();
            dtpTuNgay.Value = new DateTime(2000, 1, 1);
            dtpDenNgay.Value = DateTime.Today;
            cboTrangThai.SelectedIndex = 0;
            cboVaiTro.SelectedIndex = 0;
            LoadData();
        }

        // ─────────────────────────────────────────────
        // XUẤT EXCEL (CSV)
        // ─────────────────────────────────────────────
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = dgvLog.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string defaultName = "LichSuTrangThaiDon_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";
                using (var sfd = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = defaultName
                })
                {
                    if (sfd.ShowDialog(this) != DialogResult.OK) return;
                    ExportLogToExcel(dt, sfd.FileName, dtpTuNgay.Value, dtpDenNgay.Value);
                    MessageBox.Show("Xuất file thành công:\n" + sfd.FileName,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static readonly string[] CsvCols =
        {
            "MALICHSU", "MADON", "TENNV", "VAITRO",
            "TRANGTHAI_CU", "TRANGTHAI_MOI", "THOIGIANCAPNHAT", "GHICHU"
        };

        private void ExportLogToExcel(DataTable table, string filename, DateTime tuNgay, DateTime denNgay)
        {
            const string companyName = "CÔNG TY TNHH TM DV VẬN TẢI QUỐC TẾ ĐẠI DƯƠNG XANH";
            const string companyAddress = "Địa chỉ: 84/10 Đường 49,Phường Hiệp Bình Chánh, Quận Thủ Đức, TP.HCM, Việt Nam";                       // TODO: điền địa chỉ thật
            const string companyContact = "ĐT: +84-28-62835558 - Email: thanh_duc@go-shipping.vn - MST: 0311234567";    // TODO: điền thông tin thật
            const string reportTitle = "BÁO CÁO LỊCH SỬ TRẠNG THÁI ĐƠN";

            var cols = System.Linq.Enumerable.ToList(
                System.Linq.Enumerable.Where(CsvCols, c => table.Columns.Contains(c)));

            string[] headerNames =
            {
        "Mã lịch sử","Mã đơn","Tên nhân viên","Vai trò",
        "Trạng thái cũ","Trạng thái mới","Thời gian cập nhật","Ghi chú"
    };
            var colNameList = new System.Collections.Generic.List<string>(CsvCols);
            var headers = new System.Collections.Generic.List<string>();
            foreach (var c in cols)
            {
                int idx = colNameList.IndexOf(c);
                headers.Add(idx >= 0 ? headerNames[idx] : c);
            }

            int colCount = cols.Count;
            string lastCol = ColLetter(colCount);

            using (var workbook = new XLWorkbook())
            {
                // ══ SHEET 1: TÓM TẮT THỐNG KÊ (MR07) ══
                var wsStat = workbook.Worksheets.Add("Tóm tắt");

                wsStat.Cell("A1").Value = companyName;
                wsStat.Cell("A1").Style.Font.Bold = true;
                wsStat.Cell("A1").Style.Font.FontSize = 12;
                wsStat.Range("A1:D1").Merge();

                wsStat.Cell("A2").Value = "BÁO CÁO TÓM TẮT - LỊCH SỬ TRẠNG THÁI ĐƤN DỊCH VỤ";
                wsStat.Range("A2:D2").Merge();
                wsStat.Cell("A2").Style.Font.Bold = true;
                wsStat.Cell("A2").Style.Font.FontSize = 14;
                wsStat.Cell("A2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                wsStat.Cell("A3").Value =
                    $"Kỳ: {tuNgay:dd/MM/yyyy} — {denNgay:dd/MM/yyyy}   |   Xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                wsStat.Range("A3:D3").Merge();
                wsStat.Cell("A3").Style.Font.Italic = true;
                wsStat.Cell("A3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Bảng 1: Phân bổ theo trạng thái mới
                wsStat.Cell("A5").Value = "Trạng thái mới";
                wsStat.Cell("B5").Value = "Số lượt";
                foreach (var cell in new[] { wsStat.Cell("A5"), wsStat.Cell("B5") })
                {
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#DCE6F1");
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
                var statTT = new System.Collections.Generic.Dictionary<string, int>();
                if (table.Columns.Contains("TRANGTHAI_MOI"))
                    foreach (System.Data.DataRow r in table.Rows)
                    {
                        string tt = Convert.ToString(r["TRANGTHAI_MOI"]);
                        if (!statTT.ContainsKey(tt)) statTT[tt] = 0;
                        statTT[tt]++;
                    }
                int ttRow = 6;
                foreach (var kv in statTT)
                {
                    wsStat.Cell(ttRow, 1).Value = kv.Key;
                    wsStat.Cell(ttRow, 2).Value = kv.Value;
                    wsStat.Cell(ttRow, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    wsStat.Cell(ttRow, 2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ttRow++;
                }
                wsStat.Cell(ttRow, 1).Value = "Tổng cộng";
                wsStat.Cell(ttRow, 2).Value = table.Rows.Count;
                wsStat.Cell(ttRow, 1).Style.Font.Bold = true;
                wsStat.Cell(ttRow, 2).Style.Font.Bold = true;

                // Bảng 2: Phân bổ theo nhân viên
                int nvR0 = ttRow + 3;
                wsStat.Cell(nvR0, 1).Value = "Nhân viên";
                wsStat.Cell(nvR0, 2).Value = "Số lượt cập nhật";
                foreach (var cell in new[] { wsStat.Cell(nvR0, 1), wsStat.Cell(nvR0, 2) })
                {
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#DCE6F1");
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
                var statNV = new System.Collections.Generic.Dictionary<string, int>();
                if (table.Columns.Contains("TENNV"))
                    foreach (System.Data.DataRow r in table.Rows)
                    {
                        string nv = Convert.ToString(r["TENNV"]);
                        if (string.IsNullOrWhiteSpace(nv)) nv = "(Hệ thống)";
                        if (!statNV.ContainsKey(nv)) statNV[nv] = 0;
                        statNV[nv]++;
                    }
                int nvRow = nvR0 + 1;
                foreach (var kv in statNV)
                {
                    wsStat.Cell(nvRow, 1).Value = kv.Key;
                    wsStat.Cell(nvRow, 2).Value = kv.Value;
                    wsStat.Cell(nvRow, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    wsStat.Cell(nvRow, 2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    nvRow++;
                }
                wsStat.Columns().AdjustToContents();

                // ══ SHEET 2: DỮ LIỆU CHI TIẼT (giữ nguyên logic cũ) ══
                var ws = workbook.Worksheets.Add("Chi tiết");

                // ----- Logo (góc trái trên) -----
                using (var ms = new MemoryStream())
                {
                    _03_VuNgocLinh.Properties.Resources.DDX.Save(ms, ImageFormat.Png);
                    ms.Position = 0;
                    ws.AddPicture(ms, XLPictureFormat.Png)
                      .MoveTo(ws.Cell("A1"))
                      .WithSize(60, 60);
                }

                // ----- Tiêu đề công ty (bắt đầu từ cột C để chừa chỗ logo) -----
                ws.Cell("C1").Value = companyName;
                ws.Range("C1:" + lastCol + "1").Merge();
                ws.Cell("C1").Style.Font.Bold = true;
                ws.Cell("C1").Style.Font.FontSize = 13;

                ws.Cell("C2").Value = companyAddress;
                ws.Range("C2:" + lastCol + "2").Merge();
                ws.Cell("C2").Style.Font.FontSize = 9;

                ws.Cell("C3").Value = companyContact;
                ws.Range("C3:" + lastCol + "3").Merge();
                ws.Cell("C3").Style.Font.FontSize = 9;
                ws.Cell("C3").Style.Font.FontColor = XLColor.Gray;

                // ----- Tiêu đề báo cáo -----
                ws.Cell("A5").Value = reportTitle;
                ws.Range("A5:" + lastCol + "5").Merge();
                ws.Cell("A5").Style.Font.Bold = true;
                ws.Cell("A5").Style.Font.FontSize = 16;
                ws.Cell("A5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell("A6").Value =
                    $"Từ ngày: {tuNgay:dd/MM/yyyy}   Đến ngày: {denNgay:dd/MM/yyyy}   -   Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                ws.Range("A6:" + lastCol + "6").Merge();
                ws.Cell("A6").Style.Font.FontSize = 9;
                ws.Cell("A6").Style.Font.Italic = true;
                ws.Cell("A6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // ----- Header bảng -----
                int headerRow = 8;
                for (int c = 0; c < colCount; c++)
                {
                    var cell = ws.Cell(headerRow, c + 1);
                    cell.Value = headers[c];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#DCE6F1");
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

                // ----- Dữ liệu -----
                int row = headerRow + 1;
                foreach (DataRow dr in table.Rows)
                {
                    for (int c = 0; c < colCount; c++)
                    {
                        var cell = ws.Cell(row, c + 1);
                        string colName = cols[c];

                        if (colName == "THOIGIANCAPNHAT" && DateTime.TryParse(Convert.ToString(dr[colName]), out DateTime dt))
                        {
                            cell.Value = dt;
                            cell.Style.DateFormat.Format = "dd/MM/yyyy HH:mm";
                        }
                        else
                        {
                            cell.Value = Convert.ToString(dr[colName]);
                        }
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    }
                    row++;
                }

                ws.Columns(1, colCount).AdjustToContents();
                ws.SheetView.FreezeRows(headerRow);

                workbook.SaveAs(filename);
            }
        }

        private static string ColLetter(int colCount)
        {
            int n = colCount;
            string result = "";
            while (n > 0)
            {
                int rem = (n - 1) % 26;
                result = (char)('A' + rem) + result;
                n = (n - 1) / 26;
            }
            return result;
        }
        // ─────────────────────────────────────────────
        // CÁC HANDLER RỖng (placeholder từ Designer)
        // ─────────────────────────────────────────────
        private void dgvLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            HienThiChiTiet(dgvLog.Rows[e.RowIndex]);
        }

        // TextBox chi tiết đều ReadOnly – không cần xử lý TextChanged
        private void txtMaDonDV_TextChanged(object sender, EventArgs e) { }
        private void txtTrangThaiCu_TextChanged(object sender, EventArgs e) { }
        private void txtTrangThaiMoi_TextChanged(object sender, EventArgs e) { }
        private void txtTenNhanVien_TextChanged(object sender, EventArgs e) { }
        private void dtpThoiGian_ValueChanged(object sender, EventArgs e) { }
        private void txtGhiChu_TextChanged(object sender, EventArgs e) { }

        // Add this method to handle the TextChanged event for txtMaLichSu
        private void txtMaLichSu_TextChanged(object sender, EventArgs e)
        {
            // Implement logic as needed, or leave empty if not required
        }

        private void pnlFilterBtns_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}