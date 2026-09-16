using _03_VuNgocLinh.BUS;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _03_VuNgocLinh.GUI.Popups
{
    /// <summary>
    /// Popup mini: hiện danh sách NV chưa có tài khoản.
    /// Double-click hoặc bấm "Chọn" để xác nhận.
    /// Kết quả trả về qua property SelectedNhanVien.
    /// </summary>
    public partial class FrmChonNhanVien : Form
    {
        private readonly NhanVienBUS _nvBus = new NhanVienBUS();

        // ── Kết quả trả về ─────────────────────────────────────────────
        public string SelectedMaNV { get; private set; }
        public string SelectedHoTen { get; private set; }
        public string SelectedVaiTro { get; private set; }

        public FrmChonNhanVien()
        {
            InitializeComponent();
            this.Load += FrmChonNhanVien_Load;
        }

        private void FrmChonNhanVien_Load(object sender, EventArgs e)
        {
            KhoiTaoBang();
            TaiDuLieu();
            grid.DoubleClick += (s, _) => ChonVaoDong();
        }

        private void KhoiTaoBang()
        {
            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToResizeRows = false;
            grid.Columns.Clear();

            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaNV",
                HeaderText = "Mã NV",
                DataPropertyName = "maNhanVien",
                Width = 90
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHoTen",
                HeaderText = "Họ tên",
                DataPropertyName = "hoTen",
                Width = 200
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVaiTro",
                HeaderText = "Vai trò",
                DataPropertyName = "vaiTro",
                Width = 200
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPhongBan",
                HeaderText = "Phòng ban",
                DataPropertyName = "phongBan",
                Width = 150
            });
        }

        private void TaiDuLieu(string filter = "")
        {
            try
            {
                DataTable dt = _nvBus.GetNhanVienChuaCoTK();

                // Lọc theo tên nếu user gõ vào txtSearch
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    var rows = dt.Select($"hoTen LIKE '%{filter.Trim()}%' OR maNhanVien LIKE '%{filter.Trim()}%'");
                    DataTable filtered = dt.Clone();
                    foreach (var r in rows) filtered.ImportRow(r);
                    dt = filtered;
                }

                grid.DataSource = dt;
                lblSoLuong.Text = $"{dt.Rows.Count} nhân viên chưa có tài khoản";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChonVaoDong()
        {
            if (grid.CurrentRow == null) return;

            SelectedMaNV = Convert.ToString(grid.CurrentRow.Cells["colMaNV"].Value);
            SelectedHoTen = Convert.ToString(grid.CurrentRow.Cells["colHoTen"].Value);
            SelectedVaiTro = Convert.ToString(grid.CurrentRow.Cells["colVaiTro"].Value);

            if (string.IsNullOrWhiteSpace(SelectedMaNV))
            {
                MessageBox.Show("Không đọc được mã nhân viên. Vui lòng thử lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ── Event handlers ──────────────────────────────────────────────
        private void txtSearch_TextChanged(object sender, EventArgs e)
            => TaiDuLieu(txtSearch.Text);

        private void btnChon_Click(object sender, EventArgs e)
            => ChonVaoDong();

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmChonNhanVien_Load_1(object sender, EventArgs e)
        {

        }
    }
}