using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using _03_VuNgocLinh.DAL;

namespace _03_VuNgocLinh.GUI.Pages.Owner
{
    public partial class FrmThemNhomDichVu : Form
    {
        private readonly string _maNhomEdit;
        public bool Saved { get; private set; }
        public string SavedMaNhom { get; private set; }

        public FrmThemNhomDichVu(string maNhomEdit = null)
        {
            InitializeComponent();
            _maNhomEdit = maNhomEdit;
            Saved = false;
            SavedMaNhom = null;
        }

        private void FrmThemNhomDichVu_Load(object sender, EventArgs e)
        {
            try
            {
                // Populate trạng thái
                cbbTrangThai.Items.Clear();
                cbbTrangThai.Items.Add("Hoạt động");
                cbbTrangThai.Items.Add("Ẩn");
                cbbTrangThai.SelectedIndex = 0;

                // Ensure input fields editable for add/edit
                txtTenNhom.Enabled = true;
                txtMoTa.Enabled = true;
                cbbTrangThai.Enabled = true;
                txtMaNhom.Enabled = false; // MANHOM generated / readonly

                if (!string.IsNullOrWhiteSpace(_maNhomEdit))
                {
                    // Edit mode - load data
                    LoadNhomForEdit(_maNhomEdit);
                }
                else
                {
                    // Add mode - propose a new MANHOM
                    txtMaNhom.Text = GenerateNewMaNhom();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhomForEdit(string maNhom)
        {
            const string sql = "SELECT MANHOM, TENNHOM, MOTA, TRANGTHAI FROM NhomDichVu WHERE MANHOM = @MANHOM";
            var dt = DataProvider.ExecuteQuery(sql, new SqlParameter("@MANHOM", System.Data.SqlDbType.VarChar) { Value = maNhom });
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhóm dịch vụ để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            var row = dt.Rows[0];
            txtMaNhom.Text = Convert.ToString(row["MANHOM"]);
            txtTenNhom.Text = Convert.ToString(row["TENNHOM"]);
            txtMoTa.Text = Convert.ToString(row["MOTA"]);
            var trangThai = Convert.ToString(row["TRANGTHAI"]);
            if (!string.IsNullOrWhiteSpace(trangThai))
            {
                int idx = cbbTrangThai.Items.IndexOf(trangThai);
                cbbTrangThai.SelectedIndex = idx >= 0 ? idx : 0;
            }
        }

        private string GenerateNewMaNhom()
        {
            // Simple generator: find existing MANHOM values with numeric suffix and increment.
            // Fallback: use "NH" + ticks if no numeric pattern found or collision.
            try
            {
                var dt = NhomDichVuRepository.GetAll(); // MANHOM, TENNHOM, MOTA, TRANGTHAI
                if (dt == null || dt.Rows.Count == 0)
                    return "NH0001";

                var maList = dt.AsEnumerable().Select(r => Convert.ToString(r["MANHOM"]) ?? "").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                int maxNum = -1;
                foreach (var m in maList)
                {
                    // try to get trailing number
                    int i = m.Length - 1;
                    while (i >= 0 && char.IsDigit(m[i])) i--;
                    var suffix = m.Substring(i + 1);
                    int n;
                    if (suffix.Length > 0 && int.TryParse(suffix, out n))
                    {
                        if (n > maxNum) maxNum = n;
                    }
                }

                if (maxNum >= 0)
                {
                    // keep same width as max suffix length (min 4)
                    int width = Math.Max(4, maList.Select(m =>
                    {
                        int i = m.Length - 1;
                        while (i >= 0 && char.IsDigit(m[i])) i--;
                        return m.Length - 1 - i;
                    }).DefaultIfEmpty(4).Max());

                    var next = maxNum + 1;
                    string candidate = "NH" + next.ToString().PadLeft(width, '0');

                    // ensure uniqueness
                    while (maList.Contains(candidate))
                    {
                        next++;
                        candidate = "NH" + next.ToString().PadLeft(width, '0');
                    }
                    return candidate;
                }

                // If no numeric suffix patterns, fallback:
                string fallback;
                do
                {
                    fallback = "NH" + DateTime.Now.Ticks.ToString().Substring(9); // short unique
                } while (maList.Contains(fallback));
                return fallback;
            }
            catch
            {
                // final fallback
                return "NH" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                var tenNhom = txtTenNhom.Text?.Trim();
                var moTa = txtMoTa.Text?.Trim();
                var trangThai = cbbTrangThai.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(tenNhom))
                {
                    MessageBox.Show("Vui lòng nhập tên nhóm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNhom.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(_maNhomEdit))
                {
                    // Insert new
                    var maNhom = txtMaNhom.Text;
                    if (string.IsNullOrWhiteSpace(maNhom))
                        maNhom = GenerateNewMaNhom();

                    int rows = DataProvider.ExecuteNonQuery(
                        @"INSERT INTO NhomDichVu (MANHOM, TENNHOM, MOTA, TRANGTHAI) 
                          VALUES (@MANHOM, @TENNHOM, @MOTA, @TRANGTHAI)",
                        new SqlParameter("@MANHOM", System.Data.SqlDbType.VarChar) { Value = maNhom },
                        new SqlParameter("@TENNHOM", System.Data.SqlDbType.NVarChar) { Value = tenNhom },
                        new SqlParameter("@MOTA", System.Data.SqlDbType.NVarChar) { Value = (object)moTa ?? DBNull.Value },
                        new SqlParameter("@TRANGTHAI", System.Data.SqlDbType.NVarChar) { Value = (object)trangThai ?? DBNull.Value }
                    );

                    if (rows > 0)
                    {
                        Saved = true;
                        SavedMaNhom = maNhom;
                        MessageBox.Show("Thêm nhóm dịch vụ thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm nhóm dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Update existing
                    int rows = DataProvider.ExecuteNonQuery(
                        @"UPDATE NhomDichVu 
                          SET TENNHOM = @TENNHOM, MOTA = @MOTA, TRANGTHAI = @TRANGTHAI
                          WHERE MANHOM = @MANHOM",
                        new SqlParameter("@TENNHOM", System.Data.SqlDbType.NVarChar) { Value = tenNhom },
                        new SqlParameter("@MOTA", System.Data.SqlDbType.NVarChar) { Value = (object)moTa ?? DBNull.Value },
                        new SqlParameter("@TRANGTHAI", System.Data.SqlDbType.NVarChar) { Value = (object)trangThai ?? DBNull.Value },
                        new SqlParameter("@MANHOM", System.Data.SqlDbType.VarChar) { Value = _maNhomEdit }
                    );

                    if (rows > 0)
                    {
                        Saved = true;
                        SavedMaNhom = _maNhomEdit;
                        MessageBox.Show("Cập nhật nhóm dịch vụ thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhóm để cập nhật hoặc không có thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Designer-wired no-op handlers kept for compatibility
        private void txtMaNhom_TextChanged(object sender, EventArgs e) { }
        private void txtTenNhom_TextChanged(object sender, EventArgs e) { }
        private void txtMoTa_TextChanged(object sender, EventArgs e) { }
        private void txtTrangThai_TextChanged(object sender, EventArgs e) { }
    }
}
