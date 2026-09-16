using _03_VuNgocLinh.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
// PdfSharp is required for PDF export. Install-Package PdfSharp -Version 1.50.5147
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace _03_VuNgocLinh.GUI.Pages.Owner
{
    public partial class FrmDanhMuc : Form
    {
        // "DICHVU" hoặc "NHOMDICHVU" — để btnSua / btnXoa biết đang thao tác loại nào
        private string _currentViewMode = "DICHVU";
        private bool _isBinding;

        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────────────────────
        // LOAD FORM
        // ─────────────────────────────────────────────────────────
        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNhomDichVu();
                LoadDichVu();       // gọi UpdateFooterCounts bên trong
                SetDefaultTrangThai();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────
        // LOAD DỮ LIỆU
        // ─────────────────────────────────────────────────────────
        private void LoadNhomDichVu()
        {
            const string sql = "SELECT MANHOM, TENNHOM FROM NhomDichVu ORDER BY TENNHOM";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            cbbNhomDichVu.DataSource = dt;
            cbbNhomDichVu.DisplayMember = "TENNHOM";
            cbbNhomDichVu.ValueMember = "MANHOM";
            cbbNhomDichVu.SelectedIndex = -1;
        }

        private void LoadDichVu()
        {
            const string sql = @"
SELECT 
    dv.MADV,
    dv.TENDV,
    dv.MANHOM,
    nh.TENNHOM,
    dv.GIABAN,
    dv.DONVITINH,
    dv.MOTA,
    dv.TRANGTHAI
FROM DichVu dv
LEFT JOIN NhomDichVu nh ON dv.MANHOM = nh.MANHOM
ORDER BY dv.MADV";
            gridThongKe.AutoGenerateColumns = true;
            gridThongKe.DataSource = DataProvider.ExecuteQuery(sql);
            gridThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _currentViewMode = "DICHVU";
            UpdateFooterCounts();
        }

        private void LoadNhomDichVuGrid()
        {
            const string sql = "SELECT MANHOM, TENNHOM, MOTA, TRANGTHAI FROM NhomDichVu ORDER BY MANHOM";
            gridThongKe.AutoGenerateColumns = true;
            gridThongKe.DataSource = DataProvider.ExecuteQuery(sql);
            gridThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _currentViewMode = "NHOMDICHVU";
            UpdateFooterCounts();
        }

        // ─────────────────────────────────────────────────────────
        // CẬP NHẬT FOOTER — đếm từ DB, không phụ thuộc vào grid
        // ─────────────────────────────────────────────────────────
        private void UpdateFooterCounts()
        {
            try
            {
                var dtDV = DataProvider.ExecuteQuery("SELECT COUNT(*) AS CNT FROM DichVu");
                var dtNhom = DataProvider.ExecuteQuery("SELECT COUNT(*) AS CNT FROM NhomDichVu");

                int tongDV = dtDV.Rows.Count > 0 ? Convert.ToInt32(dtDV.Rows[0]["CNT"]) : 0;
                int tongNhom = dtNhom.Rows.Count > 0 ? Convert.ToInt32(dtNhom.Rows[0]["CNT"]) : 0;

                lblTongDV.Text = $"Tổng dịch vụ: {tongDV}";
                lblTongNhom.Text = $"Tổng nhóm dịch vụ: {tongNhom}";
            }
            catch { /* không làm crash form nếu lỗi đếm */ }
        }

        private void SetDefaultTrangThai()
        {
            if (string.IsNullOrWhiteSpace(txtTrangThai.Text))
                txtTrangThai.Text = "Đang cung cấp";
        }

        private void ClearForm()
        {
            txtMoTa.Clear();
            txtTrangThai.Text = "Đang cung cấp";
            cbbNhomDichVu.SelectedIndex = -1;
            gridThongKe.ClearSelection();
        }

        // ─────────────────────────────────────────────────────────
        // NÚT THÊM — hỏi loại rồi mở dialog tương ứng
        // ─────────────────────────────────────────────────────────
        private void btnThem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn muốn thêm một nhóm dịch vụ mới?\n\n  Yes  = Thêm nhóm dịch vụ\n  No   = Thêm dịch vụ",
                "Chọn loại thêm mới",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Cancel) return;

            try
            {
                if (result == DialogResult.Yes)
                {
                    // Mở form thêm Nhóm Dịch Vụ
                    using (var frm = new FrmThemNhomDichVu())
                    {
                        frm.ShowDialog(this);
                        if (frm.Saved)
                        {
                            LoadNhomDichVu();
                            LoadNhomDichVuGrid();   // hiển thị danh sách nhóm

                            // Hỏi có muốn thêm dịch vụ cho nhóm vừa tạo không
                            if (MessageBox.Show(
                                "Nhóm đã được thêm. Bạn có muốn thêm dịch vụ thuộc nhóm này ngay bây giờ?",
                                "Thêm dịch vụ?",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                using (var frmDV = new FrmThemDichVu(maNhomDefault: frm.SavedMaNhom))
                                {
                                    frmDV.ShowDialog(this);
                                    if (frmDV.Saved)
                                        LoadDichVu();
                                }
                            }
                        }
                    }
                }
                else // No = thêm Dịch Vụ
                {
                    string maNhomDefault = cbbNhomDichVu.SelectedValue?.ToString();
                    using (var frm = new FrmThemDichVu(maNhomDefault: maNhomDefault))
                    {
                        frm.ShowDialog(this);
                        if (frm.Saved)
                        {
                            LoadDichVu();
                            ClearForm();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────
        // NÚT SỬA — tự nhận biết đang sửa Nhóm hay Dịch Vụ
        // ─────────────────────────────────────────────────────────
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gridThongKe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa trong danh sách.", "Không có lựa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var drv = gridThongKe.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            try
            {
                if (_currentViewMode == "NHOMDICHVU")
                {
                    string maNhom = drv["MANHOM"]?.ToString();
                    if (string.IsNullOrWhiteSpace(maNhom)) return;

                    using (var frm = new FrmThemNhomDichVu(maNhomEdit: maNhom))
                    {
                        frm.ShowDialog(this);
                        if (frm.Saved)
                        {
                            LoadNhomDichVu();
                            LoadNhomDichVuGrid();
                        }
                    }
                }
                else
                {
                    string maDV = drv["MADV"]?.ToString();
                    if (string.IsNullOrWhiteSpace(maDV)) return;

                    using (var frm = new FrmThemDichVu(maDVEdit: maDV))
                    {
                        frm.ShowDialog(this);
                        if (frm.Saved)
                        {
                            LoadNhomDichVu();
                            LoadDichVu();
                            ClearForm();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────
        // NÚT XÓA
        // ─────────────────────────────────────────────────────────
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridThongKe.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Không có lựa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var drv = gridThongKe.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            try
            {
                if (_currentViewMode == "NHOMDICHVU")
                {
                    string maNhom = drv["MANHOM"]?.ToString();
                    string tenNhom = drv["TENNHOM"]?.ToString();
                    if (string.IsNullOrWhiteSpace(maNhom)) return;

                    if (MessageBox.Show(
                        $"Bạn có chắc muốn xóa nhóm '{tenNhom}'?\n(Chỉ xóa được nếu nhóm chưa có dịch vụ nào)",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                    int rows = DataProvider.ExecuteNonQuery(
                        "DELETE FROM NhomDichVu WHERE MANHOM = @MANHOM",
                        new SqlParameter("@MANHOM", System.Data.SqlDbType.VarChar) { Value = maNhom });

                    MessageBox.Show(rows > 0 ? "Xóa nhóm dịch vụ thành công." : "Không tìm thấy nhóm để xóa.",
                        "Thông báo", MessageBoxButtons.OK,
                        rows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (rows > 0) { LoadNhomDichVu(); LoadNhomDichVuGrid(); }
                }
                else
                {
                    var maDVObj = gridThongKe.CurrentRow.Cells["MADV"].Value;
                    if (maDVObj == null)
                    {
                        MessageBox.Show("Không tìm thấy mã dịch vụ trên dòng đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string maDV = maDVObj.ToString();
                    string tenDV = gridThongKe.CurrentRow.Cells["TENDV"].Value?.ToString() ?? maDV;

                    if (MessageBox.Show(
                        $"Bạn có chắc muốn xóa dịch vụ '{tenDV}'?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                    int rows = DataProvider.ExecuteNonQuery(
                        "DELETE FROM DichVu WHERE MADV = @MADV",
                        new SqlParameter("@MADV", System.Data.SqlDbType.VarChar) { Value = maDV });

                    MessageBox.Show(rows > 0 ? "Xóa dịch vụ thành công." : "Không tìm thấy dịch vụ để xóa.",
                        "Thông báo", MessageBoxButtons.OK,
                        rows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (rows > 0) { LoadDichVu(); ClearForm(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────
        // TÌM KIẾM (chỉ áp dụng cho Dịch Vụ)
        // ─────────────────────────────────────────────────────────
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                var sqlBase = @"
SELECT 
    dv.MADV,
    dv.TENDV,
    dv.MANHOM,
    nh.TENNHOM,
    dv.GIABAN,
    dv.DONVITINH,
    dv.MOTA,
    dv.TRANGTHAI
FROM DichVu dv
LEFT JOIN NhomDichVu nh ON dv.MANHOM = nh.MANHOM
WHERE 1=1";

                var whereClauses = new List<string>();
                var parameters = new List<SqlParameter>();

                if (cbbNhomDichVu.SelectedValue != null && cbbNhomDichVu.SelectedValue != DBNull.Value)
                {
                    whereClauses.Add("dv.MANHOM = @MANHOM");
                    parameters.Add(new SqlParameter("@MANHOM", System.Data.SqlDbType.VarChar) { Value = cbbNhomDichVu.SelectedValue });
                }

                var keyword = txtMoTa.Text?.Trim();
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    whereClauses.Add("(dv.TENDV LIKE @KW OR dv.MOTA LIKE @KW)");
                    parameters.Add(new SqlParameter("@KW", System.Data.SqlDbType.NVarChar, 4000) { Value = "%" + keyword + "%" });
                }

                var status = txtTrangThai.Text?.Trim();
                if (!string.IsNullOrWhiteSpace(status))
                {
                    whereClauses.Add("dv.TRANGTHAI LIKE @TRANGTHAI");
                    parameters.Add(new SqlParameter("@TRANGTHAI", System.Data.SqlDbType.NVarChar, 200) { Value = "%" + status + "%" });
                }

                var finalSql = sqlBase;
                if (whereClauses.Count > 0)
                    finalSql += Environment.NewLine + "AND " + string.Join(" AND ", whereClauses);
                finalSql += Environment.NewLine + "ORDER BY dv.MADV";

                DataTable dt = DataProvider.ExecuteQuery(finalSql, parameters.ToArray());
                gridThongKe.AutoGenerateColumns = true;
                gridThongKe.DataSource = dt;
                gridThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                _currentViewMode = "DICHVU";

                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy bản ghi nào khớp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────
        // ĐẶT LẠI / THOÁT / XUẤT PDF
        // ─────────────────────────────────────────────────────────
        private void btnDatLai_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDichVu();
        }

        private void btnExit_Click(object sender, EventArgs e) => Close();

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            if (gridThongKe.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF files (*.pdf)|*.pdf", FileName = "BaoCao_DichVu.pdf" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    ExportGridToPdf((DataTable)gridThongKe.DataSource, sfd.FileName, "Báo cáo dịch vụ");
                    MessageBox.Show("Báo cáo đã được xuất thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo báo cáo PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ExportGridToPdf(DataTable table, string filename, string title)
        {
            using (PdfDocument doc = new PdfDocument())
            using (var ms = new System.IO.MemoryStream())
            {
                doc.Info.Title = title;

                // ====== THÔNG TIN CÔNG TY — chỉnh lại cho đúng thực tế ======
                const string companyName = "CÔNG TY TNHH TM DV VẬN TẢI QUỐC TẾ ĐẠI DƯƠNG XANH";
                const string companyAddress = "Địa chỉ: 84/10 Đường 49,Phường Hiệp Bình Chánh, Quận Thủ Đức, TP.HCM, Việt Nam";                       // TODO: điền địa chỉ thật
                const string companyContact = "ĐT: +84-28-62835558 - Email: thanh_duc@go-shipping.vn - MST: 0311234567";    // TODO: điền thông tin thật

                XFont companyFont = new XFont("Verdana", 11, XFontStyle.Bold);
                XFont infoFont = new XFont("Verdana", 8, XFontStyle.Regular);
                XFont titleFont = new XFont("Verdana", 16, XFontStyle.Bold);
                XFont dateFont = new XFont("Verdana", 8, XFontStyle.Italic);
                XFont headerFont = new XFont("Verdana", 8, XFontStyle.Bold);
                XFont rowFont = new XFont("Verdana", 8, XFontStyle.Regular);
                XFont footerFont = new XFont("Verdana", 8, XFontStyle.Regular);

                // Load logo into memory stream + XImage, keep them alive until doc saved
                _03_VuNgocLinh.Properties.Resources.DDX.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                using (XImage logoImage = XImage.FromStream(ms))
                {
                    const double logoSize = 50;
                    const double margin = 30, lineHeight = 16;
                    int colCount = Math.Min(8, table.Columns.Count);

                    PdfPage firstPage = doc.AddPage();
                    firstPage.Size = PdfSharp.PageSize.A4;
                    firstPage.Orientation = PdfSharp.PageOrientation.Landscape;

                    double pageWidth = firstPage.Width;
                    double pageHeight = firstPage.Height;
                    double usableWidth = pageWidth - margin * 2;

                    // ====== Đo & tính độ rộng cột theo nội dung thực tế ======
                    double[] colWidths = new double[colCount];
                    using (XGraphics measureGfx = XGraphics.FromPdfPage(firstPage))
                    {
                        for (int c = 0; c < colCount; c++)
                        {
                            double maxW = measureGfx.MeasureString(table.Columns[c].ColumnName, headerFont).Width;
                            foreach (DataRow row in table.Rows)
                            {
                                string text = row[c]?.ToString() ?? "";
                                double w = measureGfx.MeasureString(text, rowFont).Width;
                                if (w > maxW) maxW = w;
                            }
                            colWidths[c] = maxW + 10; // đệm padding 2 bên
                        }
                    } // measureGfx disposed here so we can create gfx instances later

                    double totalNeeded = 0;
                    foreach (double w in colWidths) totalNeeded += w;

                    const double minColWidth = 40;
                    if (totalNeeded > usableWidth)
                    {
                        // không đủ chỗ → co tỉ lệ lại, không cho nhỏ hơn minColWidth
                        double scale = usableWidth / totalNeeded;
                        for (int c = 0; c < colCount; c++)
                            colWidths[c] = Math.Max(minColWidth, colWidths[c] * scale);
                    }
                    else
                    {
                        // dư chỗ → giãn đều ra cho vừa khít trang
                        double extra = (usableWidth - totalNeeded) / colCount;
                        for (int c = 0; c < colCount; c++)
                            colWidths[c] += extra;
                    }

                    // ====== Vẽ nội dung — tạo trang, vẽ header & rows, đảm bảo mọi XGraphics được disposed ======
                    var pages = new List<PdfPage>();
                    int rowIndex = 0;
                    bool first = true;

                    while (first || rowIndex < table.Rows.Count)
                    {
                        PdfPage page;
                        if (first)
                        {
                            page = firstPage;
                            first = false;
                        }
                        else
                        {
                            page = doc.AddPage();
                            page.Size = PdfSharp.PageSize.A4;
                            page.Orientation = PdfSharp.PageOrientation.Landscape;
                        }

                        pages.Add(page);

                        using (XGraphics gfx = XGraphics.FromPdfPage(page))
                        {
                            double y = DrawPageHeader(gfx, page, margin, companyName, companyAddress, companyContact,
                                                       companyFont, infoFont, title, titleFont, dateFont, logoImage, logoSize);
                            y = DrawTableHeader(gfx, margin, y, colWidths, table, colCount, headerFont, lineHeight);

                            // draw rows on this page
                            while (rowIndex < table.Rows.Count)
                            {
                                if (y + lineHeight > pageHeight - margin - 20)
                                    break; // page full

                                double x = margin;
                                for (int c = 0; c < colCount; c++)
                                {
                                    string text = TruncateToFit(gfx, table.Rows[rowIndex][c]?.ToString() ?? "", rowFont, colWidths[c] - 6);
                                    gfx.DrawString(text, rowFont, XBrushes.Black,
                                        new XRect(x + 3, y, colWidths[c] - 6, lineHeight), XStringFormats.TopLeft);
                                    x += colWidths[c];
                                }

                                y += lineHeight;
                                rowIndex++;
                            }
                        } // gfx disposed here
                    }

                    // ====== Footer: số trang ======
                    for (int i = 0; i < pages.Count; i++)
                    {
                        using (XGraphics fgfx = XGraphics.FromPdfPage(pages[i]))
                        {
                            string footerText = $"Trang {i + 1}/{pages.Count}";
                            fgfx.DrawString(footerText, footerFont, XBrushes.Gray,
                                new XRect(margin, pageHeight - margin + 5, usableWidth, 16), XStringFormats.TopRight);
                        } // fgfx disposed here
                    }

                    doc.Save(filename);
                } // logoImage disposed here
            }
        }

        private double DrawPageHeader(XGraphics gfx, PdfPage page, double margin,
            string companyName, string companyAddress, string companyContact,
            XFont companyFont, XFont infoFont, string title, XFont titleFont, XFont dateFont,
            XImage logo, double logoSize)
        {
            double y = margin;
            double usableWidth = page.Width - margin * 2;

            // Logo bên trái
            gfx.DrawImage(logo, margin, y, logoSize, logoSize);

            double textX = margin + logoSize + 10;
            double textWidth = usableWidth - logoSize - 10;

            gfx.DrawString(companyName, companyFont, XBrushes.Black,
                new XRect(textX, y, textWidth, 16), XStringFormats.TopLeft);
            y += 16;
            gfx.DrawString(companyAddress, infoFont, XBrushes.Black,
                new XRect(textX, y, textWidth, 12), XStringFormats.TopLeft);
            y += 12;
            gfx.DrawString(companyContact, infoFont, XBrushes.Black,
                new XRect(textX, y, textWidth, 12), XStringFormats.TopLeft);
            y += 16;

            // đảm bảo nội dung tiếp theo nằm dưới logo, kể cả khi khối text thấp hơn logo
            y = Math.Max(y, margin + logoSize + 6);

            gfx.DrawString(title.ToUpper(), titleFont, XBrushes.Black,
                new XRect(margin, y, usableWidth, 24), XStringFormats.TopCenter);
            y += 22;

            string dateText = "Ngày in: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            gfx.DrawString(dateText, dateFont, XBrushes.Gray,
                new XRect(margin, y, usableWidth, 14), XStringFormats.TopRight);
            y += 16;

            gfx.DrawLine(XPens.Black, margin, y, page.Width - margin, y);
            y += 6;

            return y;
        }
        private double DrawTableHeader(XGraphics gfx, double margin, double y, double[] colWidths,
            DataTable table, int colCount, XFont headerFont, double lineHeight)
        {
            double x = margin;
            for (int c = 0; c < colCount; c++)
            {
                gfx.DrawRectangle(XBrushes.LightGray, x, y, colWidths[c], lineHeight);
                gfx.DrawString(table.Columns[c].ColumnName, headerFont, XBrushes.Black,
                    new XRect(x + 3, y, colWidths[c] - 6, lineHeight), XStringFormats.TopLeft);
                x += colWidths[c];
            }
            gfx.DrawLine(XPens.Black, margin, y + lineHeight, margin + colWidths.Sum(), y + lineHeight);
            return y + lineHeight;
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
        // ─────────────────────────────────────────────────────────
        // GRID — click dòng điền vào filter panel (chỉ khi xem DichVu)
        // ─────────────────────────────────────────────────────────
        private void gridThongKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _currentViewMode != "DICHVU") return;

            var drv = gridThongKe.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (drv != null)
            {
                txtMoTa.Text = Convert.ToString(drv["MOTA"]);
                txtTrangThai.Text = Convert.ToString(drv["TRANGTHAI"]);

                try
                {
                    var maNhomObj = drv["MANHOM"];
                    if (maNhomObj != null && cbbNhomDichVu.DataSource != null)
                    {
                        _isBinding = true;
                        cbbNhomDichVu.SelectedValue = maNhomObj;
                        _isBinding = false;
                    }
                }
                catch { _isBinding = false; }
            }
            else
            {
                // fallback theo DataPropertyName
                try
                {
                    txtMoTa.Text = Convert.ToString(
                        gridThongKe.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>()
                        .FirstOrDefault(c => string.Equals(c.OwningColumn?.DataPropertyName, "MOTA", StringComparison.OrdinalIgnoreCase))?.Value);
                    txtTrangThai.Text = Convert.ToString(
                        gridThongKe.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>()
                        .FirstOrDefault(c => string.Equals(c.OwningColumn?.DataPropertyName, "TRANGTHAI", StringComparison.OrdinalIgnoreCase))?.Value);
                }
                catch { /* ignore */ }
            }
        }

        // ─────────────────────────────────────────────────────────
        // CLICK LABEL FOOTER — chuyển grid sang xem tương ứng
        // ─────────────────────────────────────────────────────────

        /// <summary>
        /// Click "Tổng dịch vụ: N" → load toàn bộ danh sách Dịch Vụ vào grid.
        /// </summary>
        private void lblTongDV_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDichVu();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Click "Tổng nhóm dịch vụ: N" → load toàn bộ danh sách Nhóm Dịch Vụ vào grid.
        /// </summary>
        private void lblTongNhom_Click(object sender, EventArgs e)
        {
            try
            {
                LoadNhomDichVuGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────
        // Designer-wired no-ops
        // ─────────────────────────────────────────────────────────
        private void cbbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isBinding) return;
        }
        private void txtMoTa_TextChanged(object sender, EventArgs e) { }
        private void txtTrangThai_TextChanged(object sender, EventArgs e) { }
    }
}