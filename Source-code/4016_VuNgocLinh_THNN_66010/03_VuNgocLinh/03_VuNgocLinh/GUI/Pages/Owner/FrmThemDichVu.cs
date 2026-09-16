using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using _03_VuNgocLinh.DAL;

namespace _03_VuNgocLinh.GUI.Pages.Owner
{
    public partial class FrmThemDichVu : Form
    {
        private readonly string _maDVEdit;
        private readonly string _maNhomDefault;
        public bool Saved { get; private set; }
        public string SavedMaDV { get; private set; }

        public FrmThemDichVu(string maNhomDefault = null, string maDVEdit = null)
        {
            InitializeComponent();
            _maNhomDefault = maNhomDefault;
            _maDVEdit = maDVEdit;
            Saved = false;
            SavedMaDV = null;
        }

        private void FrmThemDichVu_Load(object sender, EventArgs e)
        {
            try
            {
                // Populate trạng thái
                cbbTrangThai.Items.Clear();
                cbbTrangThai.Items.Add("Đang cung cấp");
                cbbTrangThai.Items.Add("Ngưng cung cấp");
                cbbTrangThai.SelectedIndex = 0;

                // Enable inputs (designer had some disabled)
                txtTenDV.Enabled = true;
                txtGiaBan.Enabled = true;
                txtDonViTinh.Enabled = true;
                txtMoTa.Enabled = true;
                cbbTrangThai.Enabled = true;
                cbbNhom.Enabled = true;
                txtMaDV.Enabled = false; // generated or readonly

                LoadNhomDichVu();

                if (!string.IsNullOrWhiteSpace(_maDVEdit))
                {
                    LoadDichVuForEdit(_maDVEdit);
                }
                else
                {
                    txtMaDV.Text = GenerateNewMaDV();
                    if (!string.IsNullOrWhiteSpace(_maNhomDefault))
                    {
                        try { cbbNhom.SelectedValue = _maNhomDefault; } catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhomDichVu()
        {
            try
            {
                var dt = NhomDichVuRepository.GetAll(); // MANHOM, TENNHOM, ...
                cbbNhom.DataSource = null;
                cbbNhom.DisplayMember = "TENNHOM";
                cbbNhom.ValueMember = "MANHOM";
                cbbNhom.DataSource = dt;
                cbbNhom.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải nhóm dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDichVuForEdit(string maDV)
        {
            const string sql = @"
SELECT MADV, TENDV, MANHOM, GIABAN, DONVITINH, MOTA, TRANGTHAI
FROM DichVu
WHERE MADV = @MADV";
            var dt = DataProvider.ExecuteQuery(sql, new SqlParameter("@MADV", System.Data.SqlDbType.VarChar) { Value = maDV });
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dịch vụ để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            var row = dt.Rows[0];
            txtMaDV.Text = Convert.ToString(row["MADV"]);
            txtTenDV.Text = Convert.ToString(row["TENDV"]);
            txtGiaBan.Text = Convert.ToString(row["GIABAN"]);
            txtDonViTinh.Text = Convert.ToString(row["DONVITINH"]);
            txtMoTa.Text = Convert.ToString(row["MOTA"]);
            var trangThai = Convert.ToString(row["TRANGTHAI"]);
            if (!string.IsNullOrWhiteSpace(trangThai))
            {
                int idx = cbbTrangThai.Items.IndexOf(trangThai);
                cbbTrangThai.SelectedIndex = idx >= 0 ? idx : 0;
            }

            try
            {
                var maNhom = Convert.ToString(row["MANHOM"]);
                if (!string.IsNullOrWhiteSpace(maNhom) && cbbNhom.DataSource != null)
                    cbbNhom.SelectedValue = maNhom;
            }
            catch { /* ignore selection errors */ }
        }

        private string GenerateNewMaDV()
        {
            try
            {
                const string sql = "SELECT MADV FROM DichVu";
                var dt = DataProvider.ExecuteQuery(sql);
                if (dt == null || dt.Rows.Count == 0)
                    return "DV0001";

                var list = dt.AsEnumerable().Select(r => Convert.ToString(r["MADV"]) ?? "").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                int maxNum = -1;
                foreach (var s in list)
                {
                    int i = s.Length - 1;
                    while (i >= 0 && char.IsDigit(s[i])) i--;
                    var suffix = s.Substring(i + 1);
                    int n;
                    if (suffix.Length > 0 && int.TryParse(suffix, out n))
                        if (n > maxNum) maxNum = n;
                }

                if (maxNum >= 0)
                {
                    int width = Math.Max(4, list.Select(m =>
                    {
                        int i = m.Length - 1;
                        while (i >= 0 && char.IsDigit(m[i])) i--;
                        return m.Length - 1 - i;
                    }).DefaultIfEmpty(4).Max());

                    int next = maxNum + 1;
                    string cand = "DV" + next.ToString().PadLeft(width, '0');
                    while (list.Contains(cand))
                    {
                        next++;
                        cand = "DV" + next.ToString().PadLeft(width, '0');
                    }
                    return cand;
                }

                return "DV" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            }
            catch
            {
                return "DV" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                var tenDV = txtTenDV.Text?.Trim();
                var maNhom = cbbNhom.SelectedValue?.ToString();
                var donVi = txtDonViTinh.Text?.Trim();
                var moTa = txtMoTa.Text?.Trim();
                var trangThai = cbbTrangThai.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(tenDV))
                {
                    MessageBox.Show("Vui lòng nhập tên dịch vụ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDV.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(maNhom))
                {
                    MessageBox.Show("Vui lòng chọn nhóm dịch vụ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbNhom.Focus();
                    return;
                }

                decimal giaBan = 0;
                var giaText = txtGiaBan.Text?.Trim();
                if (!string.IsNullOrWhiteSpace(giaText))
                {
                    if (!decimal.TryParse(giaText, NumberStyles.Number, CultureInfo.CurrentCulture, out giaBan))
                    {
                        // try invariant
                        if (!decimal.TryParse(giaText, NumberStyles.Number, CultureInfo.InvariantCulture, out giaBan))
                        {
                            MessageBox.Show("Giá bán không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtGiaBan.Focus();
                            return;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(_maDVEdit))
                {
                    // Insert new
                    var maDV = txtMaDV.Text;
                    if (string.IsNullOrWhiteSpace(maDV))
                        maDV = GenerateNewMaDV();

                    int rows = DataProvider.ExecuteNonQuery(
                        @"INSERT INTO DichVu (MADV, TENDV, MANHOM, GIABAN, DONVITINH, MOTA, TRANGTHAI)
                          VALUES (@MADV, @TENDV, @MANHOM, @GIABAN, @DONVITINH, @MOTA, @TRANGTHAI)",
                        new SqlParameter("@MADV", System.Data.SqlDbType.VarChar) { Value = maDV },
                        new SqlParameter("@TENDV", System.Data.SqlDbType.NVarChar) { Value = tenDV },
                        new SqlParameter("@MANHOM", System.Data.SqlDbType.VarChar) { Value = maNhom },
                        new SqlParameter("@GIABAN", System.Data.SqlDbType.Decimal) { Value = giaBan },
                        new SqlParameter("@DONVITINH", System.Data.SqlDbType.NVarChar) { Value = (object)donVi ?? DBNull.Value },
                        new SqlParameter("@MOTA", System.Data.SqlDbType.NVarChar) { Value = (object)moTa ?? DBNull.Value },
                        new SqlParameter("@TRANGTHAI", System.Data.SqlDbType.NVarChar) { Value = (object)trangThai ?? DBNull.Value }
                    );

                    if (rows > 0)
                    {
                        Saved = true;
                        SavedMaDV = maDV;
                        MessageBox.Show("Thêm dịch vụ thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Update existing
                    int rows = DataProvider.ExecuteNonQuery(
                        @"UPDATE DichVu
                          SET TENDV = @TENDV, MANHOM = @MANHOM, GIABAN = @GIABAN, DONVITINH = @DONVITINH, MOTA = @MOTA, TRANGTHAI = @TRANGTHAI
                          WHERE MADV = @MADV",
                        new SqlParameter("@TENDV", System.Data.SqlDbType.NVarChar) { Value = tenDV },
                        new SqlParameter("@MANHOM", System.Data.SqlDbType.VarChar) { Value = maNhom },
                        new SqlParameter("@GIABAN", System.Data.SqlDbType.Decimal) { Value = giaBan },
                        new SqlParameter("@DONVITINH", System.Data.SqlDbType.NVarChar) { Value = (object)donVi ?? DBNull.Value },
                        new SqlParameter("@MOTA", System.Data.SqlDbType.NVarChar) { Value = (object)moTa ?? DBNull.Value },
                        new SqlParameter("@TRANGTHAI", System.Data.SqlDbType.NVarChar) { Value = (object)trangThai ?? DBNull.Value },
                        new SqlParameter("@MADV", System.Data.SqlDbType.VarChar) { Value = _maDVEdit }
                    );

                    if (rows > 0)
                    {
                        Saved = true;
                        SavedMaDV = _maDVEdit;
                        MessageBox.Show("Cập nhật dịch vụ thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dịch vụ để cập nhật hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Designer-wired no-op handlers kept for compatibility
        private void label9_Click(object sender, EventArgs e) { }
        private void txtMoTa_TextChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void cbbTrangThai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbbNhom_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtMaDV_TextChanged(object sender, EventArgs e) { }
        private void txtTenDV_TextChanged(object sender, EventArgs e) { }
        private void txtGiaBan_TextChanged(object sender, EventArgs e) { }
        private void txtDonViTinh_TextChanged(object sender, EventArgs e) { }
    }
}
