using _03_VuNgocLinh.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    public partial class FrmSaoLuuPhucHoi : Form
    {
        // Cấu hình lịch tự động backup được lưu ra file XML cạnh thư mục cài đặt
        // (tránh phải sửa Properties.Settings.settings của project).
        private static readonly string ConfigFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "03_VuNgocLinh", "BackupSchedule.xml");

        // Timer chạy nền để kiểm tra lịch tự động backup (chỉ hoạt động khi app đang mở)
        private static System.Threading.Timer _scheduleTimer;
        private static readonly object _timerLock = new object();

        private BackupScheduleConfig _scheduleConfig;
        private bool _isBusy = false;

        public FrmSaoLuuPhucHoi()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        #region Khởi tạo

        private void FrmSaoLuuPhucHoi_Load(object sender, EventArgs e)
        {
            string dbName = GetCurrentDatabaseName();
            lblDatabaseHienTai.Text = "Database hiện tại: " + (string.IsNullOrEmpty(dbName) ? "(chưa kết nối)" : dbName);

            // Thư mục backup mặc định: My Documents\03_VuNgocLinh_Backup
            string defaultFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "03_VuNgocLinh_Backup");

            _scheduleConfig = LoadScheduleConfig();

            txtThuMucBackup.Text = string.IsNullOrWhiteSpace(_scheduleConfig.ThuMucBackup)
                ? defaultFolder
                : _scheduleConfig.ThuMucBackup;

            cboDinhKy.Items.Clear();
            cboDinhKy.Items.AddRange(new string[] { "Mỗi ngày", "Mỗi tuần", "Mỗi tháng" });
            cboDinhKy.SelectedIndex = (int)_scheduleConfig.DinhKy;

            dtpGioChay.Format = DateTimePickerFormat.Custom;
            dtpGioChay.CustomFormat = "HH:mm";
            dtpGioChay.ShowUpDown = true;
            dtpGioChay.Value = DateTime.Today.Add(_scheduleConfig.GioChay);

            chkBatLichTuDong.Checked = _scheduleConfig.BatLich;
            CapNhatTrangThaiLich();

            TaiDanhSachBackup();
            ApplyTimerToStatusLabel();
        }

        private string GetCurrentDatabaseName()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(DataProvider.ConnectionString);
                return builder.InitialCatalog;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region SAO LƯU (BACKUP)

        private void btnChonThuMuc_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Chọn thư mục lưu file backup (.bak)";
                if (Directory.Exists(txtThuMucBackup.Text))
                    dlg.SelectedPath = txtThuMucBackup.Text;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtThuMucBackup.Text = dlg.SelectedPath;
                    TaiDanhSachBackup();
                }
            }
        }

        private void btnSaoLuuNgay_Click(object sender, EventArgs e)
        {
            if (_isBusy) return;

            string dbName = GetCurrentDatabaseName();
            if (string.IsNullOrWhiteSpace(dbName))
            {
                MessageBox.Show("Không xác định được Database hiện tại. Vui lòng kiểm tra lại kết nối CSDL!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string folder = txtThuMucBackup.Text.Trim();
            if (string.IsNullOrWhiteSpace(folder))
            {
                MessageBox.Show("Vui lòng chọn thư mục lưu file backup!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Directory.CreateDirectory(folder);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo thư mục backup!\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fileName = $"{dbName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string fullPath = Path.Combine(folder, fileName);

            SetBusy(true, "Đang sao lưu dữ liệu...");
            try
            {
                ThucHienBackup(dbName, fullPath);
                MessageBox.Show($"Sao lưu thành công!\n\nFile: {fileName}", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachBackup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sao lưu thất bại!\n\n" + ex.Message, "Thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false, null);
            }
        }

        /// <summary>
        /// Thực hiện câu lệnh BACKUP DATABASE bằng T-SQL thuần (không cần SQL Server Agent).
        /// </summary>
        private void ThucHienBackup(string dbName, string fullPath)
        {
            string sql = $@"BACKUP DATABASE [{dbName}]
TO DISK = @path
WITH FORMAT, INIT, NAME = @backupName, SKIP, NOREWIND, NOUNLOAD, STATS = 10;";

            using (var conn = new SqlConnection(DataProvider.ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 0; // backup có thể mất nhiều thời gian với CSDL lớn
                cmd.Parameters.AddWithValue("@path", fullPath);
                cmd.Parameters.AddWithValue("@backupName", $"Backup full cua {dbName}");
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region PHỤC HỒI (RESTORE)

        private void btnChonFileRestore_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "SQL Server Backup (*.bak)|*.bak|Tất cả file (*.*)|*.*";
                dlg.Title = "Chọn file backup để phục hồi";
                if (Directory.Exists(txtThuMucBackup.Text))
                    dlg.InitialDirectory = txtThuMucBackup.Text;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtFileRestore.Text = dlg.FileName;
                }
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            if (_isBusy) return;

            string filePath = txtFileRestore.Text.Trim();
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Vui lòng chọn một file backup (.bak) hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dbName = GetCurrentDatabaseName();
            if (string.IsNullOrWhiteSpace(dbName))
            {
                MessageBox.Show("Không xác định được Database hiện tại. Vui lòng kiểm tra lại kết nối CSDL!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Phục hồi sẽ GHI ĐÈ toàn bộ dữ liệu hiện tại của Database \"{dbName}\" " +
                $"bằng dữ liệu trong file:\n\n{Path.GetFileName(filePath)}\n\n" +
                "Toàn bộ thay đổi sau thời điểm backup sẽ bị mất. Bạn có chắc chắn muốn tiếp tục?",
                "Xác nhận phục hồi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes) return;

            SetBusy(true, "Đang phục hồi dữ liệu...");
            try
            {
                ThucHienRestore(dbName, filePath);
                MessageBox.Show("Phục hồi dữ liệu thành công!\n\nVui lòng khởi động lại phần mềm để áp dụng thay đổi.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phục hồi thất bại!\n\n" + ex.Message, "Thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false, null);
            }
        }

        /// <summary>
        /// Thực hiện RESTORE DATABASE: chuyển sang SINGLE_USER, restore với REPLACE,
        /// rồi chuyển lại MULTI_USER. Phải kết nối tới database "master" để restore.
        /// </summary>
        private void ThucHienRestore(string dbName, string filePath)
        {
            var masterBuilder = new SqlConnectionStringBuilder(DataProvider.ConnectionString)
            {
                InitialCatalog = "master"
            };

            using (var conn = new SqlConnection(masterBuilder.ConnectionString))
            {
                conn.Open();

                // Lấy đường dẫn vật lý của file MDF/LDF hiện tại để map lại khi restore
                var fileMap = LayDanhSachFileLogic(conn, filePath);

                // Đưa database về chế độ SINGLE_USER để có thể restore (ngắt mọi kết nối khác)
                ExecNonQuery(conn, $@"
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = @dbName)
BEGIN
    ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
END", dbName);

                try
                {
                    string moveClause = string.Join(",\n", fileMap.Select(f =>
                        $"MOVE N'{f.LogicalName}' TO N'{f.PhysicalName.Replace("'", "''")}'"));

                    string restoreSql = $@"RESTORE DATABASE [{dbName}]
FROM DISK = @path
WITH REPLACE, RECOVERY, STATS = 10
{(string.IsNullOrEmpty(moveClause) ? "" : "," + moveClause)};";

                    using (var cmd = new SqlCommand(restoreSql, conn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@path", filePath);
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    // Luôn cố gắng đưa database về MULTI_USER dù restore thành công hay lỗi
                    try
                    {
                        ExecNonQuery(conn, $@"
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = @dbName)
BEGIN
    ALTER DATABASE [{dbName}] SET MULTI_USER;
END", dbName);
                    }
                    catch { /* bỏ qua lỗi phụ khi khôi phục trạng thái multi-user */ }
                }
            }
        }

        private class BackupFileInfo
        {
            public string LogicalName;
            public string PhysicalName;
        }

        /// <summary>
        /// Đọc header của file .bak (RESTORE FILELISTONLY) để lấy tên logic file dữ liệu/log,
        /// sau đó map sang đường dẫn vật lý hiện tại của database (giữ nguyên thư mục data hiện hành).
        /// </summary>
        private List<BackupFileInfo> LayDanhSachFileLogic(SqlConnection conn, string filePath)
        {
            var result = new List<BackupFileInfo>();

            // Thư mục chứa file dữ liệu mặc định của SQL Server instance hiện tại
            string defaultDataPath = null;
            try
            {
                using (var cmdPath = new SqlCommand(
                    "SELECT SERVERPROPERTY('InstanceDefaultDataPath')", conn))
                {
                    defaultDataPath = cmdPath.ExecuteScalar() as string;
                }
            }
            catch { /* một số phiên bản SQL Server không hỗ trợ property này */ }

            using (var cmd = new SqlCommand("RESTORE FILELISTONLY FROM DISK = @path", conn))
            {
                cmd.Parameters.AddWithValue("@path", filePath);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string logicalName = reader["LogicalName"].ToString();
                        string originalPhysical = reader["PhysicalName"].ToString();
                        string ext = Path.GetExtension(originalPhysical);
                        string fileNameOnly = Path.GetFileNameWithoutExtension(originalPhysical);

                        string newPhysical;
                        if (!string.IsNullOrEmpty(defaultDataPath))
                        {
                            newPhysical = Path.Combine(defaultDataPath, fileNameOnly + ext);
                        }
                        else
                        {
                            // Không lấy được thư mục mặc định -> giữ nguyên đường dẫn gốc trong file backup
                            newPhysical = originalPhysical;
                        }

                        result.Add(new BackupFileInfo { LogicalName = logicalName, PhysicalName = newPhysical });
                    }
                }
            }

            return result;
        }

        private void ExecNonQuery(SqlConnection conn, string sql, string dbName)
        {
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@dbName", dbName);
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region DANH SÁCH BACKUP ĐÃ TẠO

        private void TaiDanhSachBackup()
        {
            lvDanhSachBackup.Items.Clear();

            string folder = txtThuMucBackup.Text.Trim();
            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder))
                return;

            try
            {
                var files = new DirectoryInfo(folder)
                    .GetFiles("*.bak")
                    .OrderByDescending(f => f.LastWriteTime);

                foreach (var f in files)
                {
                    var item = new ListViewItem(f.Name);
                    item.SubItems.Add(f.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"));
                    item.SubItems.Add(FormatFileSize(f.Length));
                    item.Tag = f.FullName;
                    lvDanhSachBackup.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đọc danh sách file backup!\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatFileSize(long bytes)
        {
            string[] units = { "B", "KB", "MB", "GB" };
            double size = bytes;
            int unitIndex = 0;
            while (size >= 1024 && unitIndex < units.Length - 1)
            {
                size /= 1024;
                unitIndex++;
            }
            return $"{size:0.##} {units[unitIndex]}";
        }

        private void btnLamMoiDanhSach_Click(object sender, EventArgs e)
        {
            TaiDanhSachBackup();
        }

        private void btnMoThuMuc_Click(object sender, EventArgs e)
        {
            string folder = txtThuMucBackup.Text.Trim();
            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Thư mục backup không tồn tại!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            System.Diagnostics.Process.Start("explorer.exe", folder);
        }

        private void btnXoaBackup_Click(object sender, EventArgs e)
        {
            if (lvDanhSachBackup.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn file backup cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullPath = lvDanhSachBackup.SelectedItems[0].Tag as string;
            string fileName = Path.GetFileName(fullPath);

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa file backup \"{fileName}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                File.Delete(fullPath);
                TaiDanhSachBackup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa file backup!\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvDanhSachBackup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSachBackup.SelectedItems.Count > 0)
            {
                txtFileRestore.Text = lvDanhSachBackup.SelectedItems[0].Tag as string;
            }
        }

        #endregion

        #region LỊCH TỰ ĐỘNG BACKUP

        public enum DinhKyBackup { HangNgay = 0, HangTuan = 1, HangThang = 2 }

        [Serializable]
        public class BackupScheduleConfig
        {
            public bool BatLich { get; set; } = false;
            public DinhKyBackup DinhKy { get; set; } = DinhKyBackup.HangNgay;
            public TimeSpan GioChay { get; set; } = new TimeSpan(23, 0, 0);
            public string ThuMucBackup { get; set; } = "";
            public string DatabaseName { get; set; } = "";
            public DateTime? LanChayCuoi { get; set; } = null;
        }

        private void chkBatLichTuDong_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatTrangThaiLich();
        }

        private void CapNhatTrangThaiLich()
        {
            bool batLich = chkBatLichTuDong.Checked;
            cboDinhKy.Enabled = batLich;
            dtpGioChay.Enabled = batLich;
        }

        private void btnLuuLich_Click(object sender, EventArgs e)
        {
            string folder = txtThuMucBackup.Text.Trim();
            if (chkBatLichTuDong.Checked && string.IsNullOrWhiteSpace(folder))
            {
                MessageBox.Show("Vui lòng chọn thư mục lưu backup trước khi bật lịch tự động!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _scheduleConfig.BatLich = chkBatLichTuDong.Checked;
            _scheduleConfig.DinhKy = (DinhKyBackup)cboDinhKy.SelectedIndex;
            _scheduleConfig.GioChay = dtpGioChay.Value.TimeOfDay;
            _scheduleConfig.ThuMucBackup = folder;
            _scheduleConfig.DatabaseName = GetCurrentDatabaseName();

            try
            {
                SaveScheduleConfig(_scheduleConfig);
                KhoiDongHoacDungTimer(_scheduleConfig);

                MessageBox.Show(
                    _scheduleConfig.BatLich
                        ? "Đã bật lịch tự động sao lưu!\n\n" +
                          "Lưu ý: lịch chỉ chạy khi phần mềm đang được mở."
                        : "Đã tắt lịch tự động sao lưu.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ApplyTimerToStatusLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu cấu hình lịch backup!\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private BackupScheduleConfig LoadScheduleConfig()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    var serializer = new XmlSerializer(typeof(BackupScheduleConfig));
                    using (var stream = File.OpenRead(ConfigFilePath))
                    {
                        return (BackupScheduleConfig)serializer.Deserialize(stream);
                    }
                }
            }
            catch
            {
                // Nếu file cấu hình lỗi/hỏng -> dùng cấu hình mặc định
            }
            return new BackupScheduleConfig();
        }

        private void SaveScheduleConfig(BackupScheduleConfig config)
        {
            string dir = Path.GetDirectoryName(ConfigFilePath);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            var serializer = new XmlSerializer(typeof(BackupScheduleConfig));
            using (var stream = File.Create(ConfigFilePath))
            {
                serializer.Serialize(stream, config);
            }
        }

        /// <summary>
        /// Khởi động/khởi động lại bộ đếm thời gian kiểm tra lịch (kiểm tra mỗi phút).
        /// Gọi tĩnh nên có thể được khởi động ngay từ FrmMain khi ứng dụng mở lên,
        /// không cần người dùng phải mở form này trước.
        /// </summary>
        public static void KhoiDongHoacDungTimer(BackupScheduleConfig config)
        {
            lock (_timerLock)
            {
                _scheduleTimer?.Dispose();
                _scheduleTimer = null;

                if (config == null || !config.BatLich) return;

                _scheduleTimer = new System.Threading.Timer(_ => KiemTraVaChayLichNenCanThiet(),
                    null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            }
        }

        /// <summary>
        /// Gọi khi ứng dụng khởi động (vd. trong FrmMain) để kích hoạt lịch đã lưu trước đó.
        /// </summary>
        public static void KhoiTaoLichTuFileCauHinh()
        {
            try
            {
                if (!File.Exists(ConfigFilePath)) return;

                var serializer = new XmlSerializer(typeof(BackupScheduleConfig));
                BackupScheduleConfig config;
                using (var stream = File.OpenRead(ConfigFilePath))
                {
                    config = (BackupScheduleConfig)serializer.Deserialize(stream);
                }
                KhoiDongHoacDungTimer(config);
            }
            catch
            {
                // bỏ qua nếu file cấu hình không hợp lệ
            }
        }

        private static void KiemTraVaChayLichNenCanThiet()
        {
            try
            {
                if (!File.Exists(ConfigFilePath)) return;

                var serializer = new XmlSerializer(typeof(BackupScheduleConfig));
                BackupScheduleConfig config;
                using (var stream = File.OpenRead(ConfigFilePath))
                {
                    config = (BackupScheduleConfig)serializer.Deserialize(stream);
                }

                if (!config.BatLich || string.IsNullOrWhiteSpace(config.ThuMucBackup)) return;

                DateTime now = DateTime.Now;
                bool isTimeMatch = Math.Abs((now.TimeOfDay - config.GioChay).TotalMinutes) < 1;
                if (!isTimeMatch) return;

                bool alreadyRanToday = config.LanChayCuoi.HasValue &&
                    config.LanChayCuoi.Value.Date == now.Date;

                bool shouldRun;
                switch (config.DinhKy)
                {
                    case DinhKyBackup.HangTuan:
                        shouldRun = !alreadyRanToday && now.DayOfWeek == DayOfWeek.Monday;
                        break;
                    case DinhKyBackup.HangThang:
                        shouldRun = !alreadyRanToday && now.Day == 1;
                        break;
                    default: // Hàng ngày
                        shouldRun = !alreadyRanToday;
                        break;
                }

                if (!shouldRun) return;

                string dbName = string.IsNullOrWhiteSpace(config.DatabaseName)
                    ? new SqlConnectionStringBuilder(DataProvider.ConnectionString).InitialCatalog
                    : config.DatabaseName;

                if (string.IsNullOrWhiteSpace(dbName)) return;

                Directory.CreateDirectory(config.ThuMucBackup);
                string fileName = $"{dbName}_{now:yyyyMMdd_HHmmss}_auto.bak";
                string fullPath = Path.Combine(config.ThuMucBackup, fileName);

                string sql = $@"BACKUP DATABASE [{dbName}]
TO DISK = @path
WITH FORMAT, INIT, NAME = @backupName, SKIP, NOREWIND, NOUNLOAD;";

                using (var conn = new SqlConnection(DataProvider.ConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@path", fullPath);
                    cmd.Parameters.AddWithValue("@backupName", $"Auto backup cua {dbName}");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                config.LanChayCuoi = now;
                var serializerSave = new XmlSerializer(typeof(BackupScheduleConfig));
                using (var stream = File.Create(ConfigFilePath))
                {
                    serializerSave.Serialize(stream, config);
                }
            }
            catch
            {
                // Backup nền chạy ngầm: không hiển thị lỗi gây phiền người dùng,
                // lần kiểm tra kế tiếp (1 phút sau) sẽ thử lại nếu vẫn trong khung giờ.
            }
        }

        private void ApplyTimerToStatusLabel()
        {
            if (_scheduleConfig.BatLich)
            {
                string dinhKyText = cboDinhKy.SelectedItem?.ToString() ?? "";
                lblTrangThaiLich.Text = $"Đang bật: {dinhKyText} lúc {dtpGioChay.Value:HH:mm}" +
                    (_scheduleConfig.LanChayCuoi.HasValue
                        ? $" (lần chạy gần nhất: {_scheduleConfig.LanChayCuoi.Value:dd/MM/yyyy HH:mm})"
                        : " (chưa chạy lần nào)");
                lblTrangThaiLich.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblTrangThaiLich.Text = "Đang tắt lịch tự động sao lưu.";
                lblTrangThaiLich.ForeColor = System.Drawing.Color.Gray;
            }
        }

        #endregion

        #region Tiện ích chung

        private void SetBusy(bool busy, string message)
        {
            _isBusy = busy;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;

            btnSaoLuuNgay.Enabled = !busy;
            btnPhucHoi.Enabled = !busy;
            btnChonThuMuc.Enabled = !busy;
            btnChonFileRestore.Enabled = !busy;
            btnXoaBackup.Enabled = !busy;
            btnLamMoiDanhSach.Enabled = !busy;
            btnLuuLich.Enabled = !busy;

            lblTrangThai.Text = busy ? message : "";
            lblTrangThai.Visible = busy;
            Application.DoEvents();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
