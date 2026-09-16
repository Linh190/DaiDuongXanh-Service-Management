using _03_VuNgocLinh.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.Owner
{
    public partial class FrmThongTinTrungTam : Form
    {
        // MACTY mặc định chỉ dùng khi INSERT lần đầu (DB chưa có record nào)
        private const string DEFAULT_MACTY = "CTY001";

        public FrmThongTinTrungTam() => InitializeComponent();

        // ─── Load ─────────────────────────────────────────────────
        private void FrmThongTinTrungTam_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadCompanyInfo();
        }

        private void ApplyTheme()
        {
            // Populate ComboBox (phải làm trước LoadCompanyInfo để SelectedItem khớp)
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Hoạt động");
            cboTrangThai.Items.Add("Đóng cửa");
            cboTrangThai.SelectedIndex = 0;

            pnlHeader.BackColor = UITheme.Navy;
            lblTitle.ForeColor = Color.White;
            lblSubtitle.ForeColor = Color.FromArgb(187, 222, 251);
            pnlFooter.BackColor = UITheme.Surface;

            UITheme.ApplyPrimaryButton(btnLuu);
            UITheme.ApplyGhostButton(btnDatLai);

            grpBasic.BackColor = grpContact.BackColor = UITheme.Surface;

            foreach (Control c in grpBasic.Controls)
            {
                if (c is TextBox t) UITheme.ApplyTextBox(t);
                if (c is ComboBox cb) UITheme.ApplyComboBox(cb);
            }
            foreach (Control c in grpContact.Controls)
                if (c is TextBox t) UITheme.ApplyTextBox(t);
        }

        // ─── Đọc dữ liệu ─────────────────────────────────────────
        private void LoadCompanyInfo()
        {
            try
            {
                DataRow row = GetCongTy();
                if (row != null)
                    PopulateFromRow(row);
                else
                    FillDefaults();

                SetStatus("Đã tải thông tin công ty.", UITheme.Success);
            }
            catch (Exception ex)
            {
                FillDefaults();
                SetStatus("Lỗi tải DB – hiển thị thông tin mặc định: " + ex.Message, UITheme.Warning);
            }
        }

        private void PopulateFromRow(DataRow row)
        {
            txtTenCty.Text = Val(row, "TENCONGTY");
            txtVietTat.Text = Val(row, "TENVIETTAT");
            txtTenQuocTe.Text = Val(row, "TENQUOCTE");
            txtMST.Text = Val(row, "MASOTHUE");
            txtNguoiDD.Text = Val(row, "NGUOIDAIDIEN");
            txtDiaChi.Text = Val(row, "DIACHI");
            txtDienThoai.Text = Val(row, "DIENTHOAI");
            txtEmail.Text = Val(row, "EMAIL");
            txtWebsite.Text = Val(row, "WEBSITE");
            txtLinhVuc.Text = Val(row, "LINHVUC");

            // Trạng thái
            string ts = Val(row, "TRANGTHAI");
            if (cboTrangThai.Items.Contains(ts)) cboTrangThai.SelectedItem = ts;
            else cboTrangThai.SelectedIndex = 0;

            // Ngày thành lập
            if (row["NGAYTHANHLAP"] != DBNull.Value)
                dtpNgayTL.Value = Convert.ToDateTime(row["NGAYTHANHLAP"]);
        }

        private void FillDefaults()
        {
            txtTenCty.Text = "Công ty TNHH Thương mại Dịch vụ Vận tải Quốc tế Đại Dương Xanh";
            txtVietTat.Text = "Đại Dương Xanh";
            txtTenQuocTe.Text = "GREEN OCEAN INTERNATIONAL TRANSPORT SERVICE TRADING CO., LTD";
            txtMST.Text = "";
            txtNguoiDD.Text = "";
            txtDiaChi.Text = "TP. Hồ Chí Minh, Việt Nam";
            txtDienThoai.Text = "0938.202.369";
            txtEmail.Text = "";
            txtWebsite.Text = "go-shipping.vn";
            txtLinhVuc.Text = "Vận tải biển, vận tải hàng không, khai thuê hải quan, vận chuyển nội địa";
            cboTrangThai.SelectedIndex = 0;
            dtpNgayTL.Value = DateTime.Today;
        }

        // ─── Lưu ──────────────────────────────────────────────────
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            try
            {
                UpsertCongTy();
                SetStatus("✔  Lưu thông tin công ty thành công!", UITheme.Success);
                MessageBox.Show("Lưu thông tin công ty thành công.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SetStatus("✖  Lỗi: " + ex.Message, UITheme.Danger);
                MessageBox.Show("Lỗi khi lưu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatLai_Click(object sender, EventArgs e) => LoadCompanyInfo();

        // ─── Core: GetCongTy & UpsertCongTy ─────────────────────
        /// <summary>
        /// Lấy record CongTy đầu tiên trong DB — KHÔNG filter MACTY cứng.
        /// Tránh bug: record tồn tại nhưng MACTY ≠ 'CTY001' → GetCongTy trả null
        /// → UpsertCongTy INSERT → vi phạm UNIQUE MST.
        /// </summary>
        private DataRow GetCongTy()
        {
            var dt = DataProvider.ExecuteQuery("SELECT TOP 1 * FROM CongTy");
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        private void UpsertCongTy()
        {
            // Build danh sách param dùng chung cho cả UPDATE & INSERT
            var ps = new List<SqlParameter>
            {
                new SqlParameter("@ten", txtTenCty.Text.Trim()),
                new SqlParameter("@vt",  NullIf(txtVietTat.Text)),
                new SqlParameter("@tqt", NullIf(txtTenQuocTe.Text)),
                new SqlParameter("@mst", NullIf(txtMST.Text)),
                new SqlParameter("@ntl", (object)dtpNgayTL.Value.Date),
                new SqlParameter("@ndd", NullIf(txtNguoiDD.Text)),
                new SqlParameter("@dc",  txtDiaChi.Text.Trim()),
                new SqlParameter("@dt",  NullIf(txtDienThoai.Text)),
                new SqlParameter("@em",  NullIf(txtEmail.Text)),
                new SqlParameter("@wb",  NullIf(txtWebsite.Text)),
                new SqlParameter("@lv",  NullIf(txtLinhVuc.Text)),
                new SqlParameter("@ts",  cboTrangThai.SelectedItem?.ToString() ?? "Hoạt động"),
            };

            // FIX: lấy lại row mới nhất để có MACTY thực tế trong DB
            DataRow existing = GetCongTy();

            if (existing != null)
            {
                // ── UPDATE: dùng MACTY từ DB (không giả định = 'CTY001') ──
                string maCtyDB = existing["MACTY"].ToString();
                ps.Add(new SqlParameter("@ma", maCtyDB));

                DataProvider.ExecuteNonQuery(
                    @"UPDATE CongTy SET
                        TENCONGTY    = @ten,
                        TENVIETTAT   = @vt,
                        TENQUOCTE    = @tqt,
                        MASOTHUE     = @mst,
                        NGAYTHANHLAP = @ntl,
                        NGUOIDAIDIEN = @ndd,
                        DIACHI       = @dc,
                        DIENTHOAI    = @dt,
                        EMAIL        = @em,
                        WEBSITE      = @wb,
                        LINHVUC      = @lv,
                        TRANGTHAI    = @ts
                      WHERE MACTY = @ma",
                    ps.ToArray());
            }
            else
            {
                // ── INSERT: lần đầu tạo record (DB thực sự chưa có gì) ──
                ps.Add(new SqlParameter("@ma", DEFAULT_MACTY));

                DataProvider.ExecuteNonQuery(
                    @"INSERT INTO CongTy
                        (MACTY, TENCONGTY, TENVIETTAT, TENQUOCTE, MASOTHUE,
                         NGAYTHANHLAP, NGUOIDAIDIEN, DIACHI, DIENTHOAI,
                         EMAIL, WEBSITE, LINHVUC, TRANGTHAI)
                      VALUES
                        (@ma, @ten, @vt, @tqt, @mst,
                         @ntl, @ndd, @dc, @dt,
                         @em, @wb, @lv, @ts)",
                    ps.ToArray());
            }
        }

        // ─── Validation ───────────────────────────────────────────
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTenCty.Text))
            {
                MessageBox.Show("Vui lòng nhập tên công ty.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCty.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ công ty.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus(); return false;
            }
            return true;
        }

        // ─── Helpers ──────────────────────────────────────────────
        private static string Val(DataRow r, string col)
            => r.Table.Columns.Contains(col) && r[col] != DBNull.Value
               ? Convert.ToString(r[col]) : "";

        private static object NullIf(string s)
            => string.IsNullOrWhiteSpace(s) ? (object)DBNull.Value : s.Trim();

        private void SetStatus(string msg, Color color)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = color;
        }
    }
}