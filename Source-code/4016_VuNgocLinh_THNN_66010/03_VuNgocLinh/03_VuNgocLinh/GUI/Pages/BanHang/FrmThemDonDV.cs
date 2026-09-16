using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.BanHang
{
    public partial class FrmThemDonDV : Form
    {
        private readonly KhachHangBUS _khBus = new KhachHangBUS();
        private readonly NhanVienBUS _nvBus = new NhanVienBUS();

        // local detail table for dgvChiTiet
        private DataTable _dtChiTietLocal;

        public FrmThemDonDV()
        {
            InitializeComponent();
        }

        private void FrmThemDonDV_Load(object sender, EventArgs e)
        {
            try
            {
                // Generate new MADON
                txtMaDon.Text = ChungTuDAL.GenerateNewMaDon();

                // Fill ngay dat
                txtNgayDat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                // Load customers (active)
                try
                {
                    var dtKH = DataProvider.ExecuteQuery("SELECT MAKH, TENKH FROM KhachHang WHERE TRANGTHAI = N'Hoạt động' ORDER BY TENKH");
                    cboKhachHang.DisplayMember = "TENKH";
                    cboKhachHang.ValueMember = "MAKH";
                    cboKhachHang.DataSource = dtKH;
                    cboKhachHang.SelectedIndex = -1;
                }
                catch
                {
                    cboKhachHang.DataSource = null;
                }

                // Load employees (active + appropriate roles)
                try
                {
                    const string sqlNV = @"
SELECT MANV, TENNV
FROM   NhanVien
WHERE  TRANGTHAI = N'Đang làm việc'
  AND  VAITRO    IN (N'Nhân viên bán hàng', N'Nhân viên văn phòng')
ORDER  BY TENNV";
                    var dtNV = DataProvider.ExecuteQuery(sqlNV);
                    cboNhanVien.DisplayMember = "TENNV";
                    cboNhanVien.ValueMember = "MANV";
                    cboNhanVien.DataSource = dtNV;
                    cboNhanVien.SelectedIndex = -1;
                }
                catch
                {
                    cboNhanVien.DataSource = null;
                }

                // Load services into combo (uses ChungTu helper)
                try
                {
                    var services = ChungTuDAL.GetAllDichVu(); // List<ChungTuDichVuItem>
                    cboDichVu.DataSource = services;
                    cboDichVu.DisplayMember = "TenDichVu";
                    cboDichVu.ValueMember = "MaDichVu";
                    cboDichVu.SelectedIndex = -1;
                }
                catch
                {
                    cboDichVu.DataSource = null;
                }

                // init empty detail table and bind
                _dtChiTietLocal = TaoBangChiTietRong();
                dgvChiTiet.AutoGenerateColumns = true;
                dgvChiTiet.DataSource = _dtChiTietLocal;
                UpdateTongTienLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var sel = cboDichVu.SelectedItem as ChungTuDichVuItem;
                if (sel != null)
                    lblDonGia.Text = $"{sel.GiaBan:N0} đ";
                else
                    lblDonGia.Text = "0 đ";
            }
            catch { lblDonGia.Text = "0 đ"; }
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            try
            {
                var sel = cboDichVu.SelectedItem as ChungTuDichVuItem;
                if (sel == null)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int qty = (int)numSoLuong.Value;
                if (qty <= 0) qty = 1;

                // Prevent duplicate MADV in same order
                foreach (DataRow r in _dtChiTietLocal.Rows)
                {
                    if (r.RowState == DataRowState.Deleted) continue;
                    if (string.Equals(Convert.ToString(r["MADV"]), sel.MaDichVu, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Dịch vụ này đã có trong đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                var nr = _dtChiTietLocal.NewRow();
                nr["MADV"] = sel.MaDichVu;
                nr["TENDV"] = sel.TenDichVu;
                nr["SOLUONG"] = qty;
                nr["DONGIA"] = sel.GiaBan;
                nr["THANHTIEN"] = sel.GiaBan * qty;
                nr["GHICHU"] = txtGhiChuDong.Text?.Trim() ?? "";
                _dtChiTietLocal.Rows.Add(nr);

                // refresh grid and totals
                dgvChiTiet.DataSource = null;
                dgvChiTiet.DataSource = _dtChiTietLocal;
                UpdateTongTienLabel();

                // reset line inputs
                txtGhiChuDong.Clear();
                numSoLuong.Value = 1;
                cboDichVu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvChiTiet.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var drv = dgvChiTiet.CurrentRow.DataBoundItem as DataRowView;
                if (drv != null)
                {
                    drv.Row.Delete();
                }
                else
                {
                    int idx = dgvChiTiet.CurrentRow.Index;
                    if (idx >= 0 && idx < _dtChiTietLocal.Rows.Count)
                        _dtChiTietLocal.Rows[idx].Delete();
                }

                // refresh
                dgvChiTiet.DataSource = null;
                dgvChiTiet.DataSource = _dtChiTietLocal;
                UpdateTongTienLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Basic validation
                if (_dtChiTietLocal == null || _dtChiTietLocal.Rows.Cast<DataRow>().All(r => r.RowState == DataRowState.Deleted || string.IsNullOrWhiteSpace(Convert.ToString(r["MADV"]))))
                {
                    MessageBox.Show("Đơn phải có ít nhất một dịch vụ.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Build DonDichVuDTO
                var don = new DonDichVuDTO
                {
                    MaDon = txtMaDon.Text,
                    NgayDat = DateTime.Now,
                    NgayThucHien = dtpNgayThucHien.Value,
                    DiemDi = txtDiemDi.Text?.Trim(),
                    DiemDen = txtDiemDen.Text?.Trim(),
                    GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim(),
                    TrangThai = txtTrangThai.Text?.Trim() ?? "Chờ xác nhận",
                    MaKhachHang = cboKhachHang.SelectedIndex >= 0 && cboKhachHang.SelectedValue != null ? cboKhachHang.SelectedValue.ToString() : null,
                    MaNhanVienTiepNhan = cboNhanVien.SelectedIndex >= 0 && cboNhanVien.SelectedValue != null ? cboNhanVien.SelectedValue.ToString() : null
                };

                // Build chi tiết DTO list
                var chiTietModels = new List<_03_VuNgocLinh.DTO.ChiTietDonDV>();
                foreach (DataRow r in _dtChiTietLocal.Rows)
                {
                    if (r.RowState == DataRowState.Deleted) continue;
                    chiTietModels.Add(new _03_VuNgocLinh.DTO.ChiTietDonDV
                    {
                        MADON = don.MaDon,
                        MADV = Convert.ToString(r["MADV"]),
                        SOLUONG = r["SOLUONG"] == DBNull.Value ? 0 : Convert.ToInt32(r["SOLUONG"]),
                        DONGIA = r["DONGIA"] == DBNull.Value ? 0m : Convert.ToDecimal(r["DONGIA"]),
                        GHICHU = Convert.ToString(r["GHICHU"])
                    });
                }

                // Save via ChungTuDAL convenience method (will create DonDichVu + ChiTiet + optional ChungTu)
                ChungTuDAL.SaveChungTu(don, chiTietModels);

                MessageBox.Show("Đã lưu đơn dịch vụ.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // helpers
        private DataTable TaoBangChiTietRong()
        {
            var dt = new DataTable();
            dt.Columns.Add("MADV", typeof(string));
            dt.Columns.Add("TENDV", typeof(string));
            dt.Columns.Add("SOLUONG", typeof(int));
            dt.Columns.Add("DONGIA", typeof(decimal));
            dt.Columns.Add("THANHTIEN", typeof(decimal));
            dt.Columns.Add("GHICHU", typeof(string));
            return dt;
        }

        private void UpdateTongTienLabel()
        {
            decimal total = 0m;
            if (_dtChiTietLocal != null)
            {
                foreach (DataRow r in _dtChiTietLocal.Rows)
                {
                    if (r.RowState == DataRowState.Deleted) continue;
                    decimal tt = r["THANHTIEN"] == DBNull.Value ? 0m : Convert.ToDecimal(r["THANHTIEN"]);
                    total += tt;
                }
            }
            lblTongTien.Text = $"Tổng tiền: {total:N0} đ";
        }
    }
}
