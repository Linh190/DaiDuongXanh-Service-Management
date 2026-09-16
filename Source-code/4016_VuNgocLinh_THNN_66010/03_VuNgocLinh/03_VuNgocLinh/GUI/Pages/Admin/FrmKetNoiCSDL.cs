using _03_VuNgocLinh.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    public partial class FrmKetNoiCSDL : Form
    {
        public FrmKetNoiCSDL()
        {
            InitializeComponent();

            // Thiết lập dạng Popup
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void FrmKetNoiCSDL_Load(object sender, EventArgs e)
        {
            // Khởi tạo ComboBox Kiểu xác thực
            cboKieuXacThuc.Items.AddRange(new string[]
            {
                "Xác thực của Windows",
                "Xác thực của SQL Server"
            });
            cboKieuXacThuc.SelectedIndex = 0;

            // Load thông tin đã lưu trước đó
            txtTenServer.Text = Properties.Settings.Default.QuanLyDichVu_DaiDuongXanhConnectionString ?? "LAPTOP-0FBIHDMS\\SQLEXPRESS";

            // Ban đầu disable Database và nút Lưu
            cboDatabase.Enabled = false;
            btnLuuThongTin.Enabled = false;

            cboKieuXacThuc_SelectedIndexChanged(null, null);
        }

        private void cboKieuXacThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSqlAuth = cboKieuXacThuc.SelectedIndex == 1;
            txtTenDangNhap.Enabled = isSqlAuth;
            txtMatKhau.Enabled = isSqlAuth;

            if (!isSqlAuth)
            {
                txtTenDangNhap.Clear();
                txtMatKhau.Clear();
            }
        }

        // ==================== NÚT "KẾT NỐI" ====================
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenServer.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên server!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tempConnectionString = BuildTempConnectionString();

                // Lấy danh sách tất cả Database trên server
                List<string> databases = GetDatabaseList(tempConnectionString);

                if (databases.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy database nào trên server này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cboDatabase.DataSource = databases;
                cboDatabase.Enabled = true;
                btnLuuThongTin.Enabled = true;

                MessageBox.Show($"Kết nối thành công!\n\nTìm thấy {databases.Count} database.\nVui lòng chọn Database bên dưới.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại!\n\n" + ex.Message, "Thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lấy danh sách Database từ Server
        private List<string> GetDatabaseList(string connectionString)
        {
            List<string> dbList = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT name FROM sys.databases 
                                 WHERE state_desc = 'ONLINE' 
                                 AND name NOT IN ('master', 'tempdb', 'model', 'msdb')
                                 ORDER BY name";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dbList.Add(reader["name"].ToString());
                    }
                }
            }
            return dbList;
        }

        private string BuildTempConnectionString()
        {
            string serverValue = txtTenServer.Text.Trim();

            // If user pasted a full connection string, normalize it and set Initial Catalog=master
            if (serverValue.IndexOf("Data Source=", StringComparison.OrdinalIgnoreCase) >= 0
                || serverValue.IndexOf("Initial Catalog=", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var builder = new SqlConnectionStringBuilder(serverValue);
                builder.InitialCatalog = "master";
                return builder.ConnectionString;
            }

            // Otherwise build from server name and auth UI
            var sb = new SqlConnectionStringBuilder
            {
                DataSource = serverValue,
                InitialCatalog = "master",
                ConnectTimeout = 30
            };
            if (cboKieuXacThuc.SelectedIndex == 0)
                sb.IntegratedSecurity = true;
            else
            {
                sb.UserID = txtTenDangNhap.Text.Trim();
                sb.Password = txtMatKhau.Text;
                sb.IntegratedSecurity = false;
            }
            return sb.ConnectionString;
        }

        // ==================== NÚT "LƯU THÔNG TIN" ====================
        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboDatabase.Text))
            {
                MessageBox.Show("Vui lòng chọn Database!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string finalConnectionString = BuildFinalConnectionString();

                // Cập nhật ConnectionString cho toàn bộ chương trình
                DataProvider.ConnectionString = finalConnectionString;

                // Lưu vào Settings
                Properties.Settings.Default.Database = cboDatabase.Text.Trim();
                Properties.Settings.Default.UserID = txtTenDangNhap.Text.Trim();
                Properties.Settings.Default.Password = txtMatKhau.Text;
                Properties.Settings.Default.Save(); MessageBox.Show("Đã lưu kết nối cơ sở dữ liệu thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thông tin thất bại!\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildFinalConnectionString()
        {
            string serverValue = txtTenServer.Text.Trim();

            // If user pasted a full connection string, normalize it and set Initial Catalog = selected database
            if (serverValue.IndexOf("Data Source=", StringComparison.OrdinalIgnoreCase) >= 0
                || serverValue.IndexOf("Initial Catalog=", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                var builder = new SqlConnectionStringBuilder(serverValue);
                builder.InitialCatalog = cboDatabase.Text.Trim();
                return builder.ConnectionString;
            }

            var sb = new SqlConnectionStringBuilder
            {
                DataSource = serverValue,
                InitialCatalog = cboDatabase.Text.Trim(),
                ConnectTimeout = 30
            };
            if (cboKieuXacThuc.SelectedIndex == 0)
                sb.IntegratedSecurity = true;
            else
            {
                sb.UserID = txtTenDangNhap.Text.Trim();
                sb.Password = txtMatKhau.Text;
                sb.IntegratedSecurity = false;
            }
            return sb.ConnectionString;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Event rỗng
        private void txtTenServer_TextChanged(object sender, EventArgs e) { }
        private void txtTenDangNhap_TextChanged(object sender, EventArgs e) { }
        private void txtMatKhau_TextChanged(object sender, EventArgs e) { }
        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }

    }
}