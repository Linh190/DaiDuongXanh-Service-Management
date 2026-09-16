using _03_VuNgocLinh;
using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.GUI.Pages.Admin;
using _03_VuNgocLinh.BUS;
using _03_VuNgocLinh.DTO;
using _03_VuNgocLinh.GUI.Pages;
using _03_VuNgocLinh.GUI.Pages.BanHang;
using _03_VuNgocLinh.GUI.Pages.KhachHang;
using _03_VuNgocLinh.GUI.Pages.Owner;
using _03_VuNgocLinh.GUI.Pages.TroGiup;
using _03_VuNgocLinh.GUI.Pages.VanPhong;
using _03_VuNgocLinh.GUI.Popups;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace _03_VuNgocLinh
{
    public partial class FrmMain : Form
    {
        private TaiKhoanDTO currentUser;

        public FrmMain()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            this.WindowState = FormWindowState.Maximized;

            // Kích hoạt lại lịch tự động sao lưu (nếu người dùng đã bật trước đó)
            _03_VuNgocLinh.GUI.Pages.Admin.FrmSaoLuuPhucHoi.KhoiTaoLichTuFileCauHinh();
        }

        #region Ribbon Tab Title

        private void ResetColorTabTitle()
        {
            btnAdminTitle.BackColor = Color.White;
            btnOwner.BackColor = Color.White;
            btnKhachHangTitle.BackColor = Color.White;
            btnBanHangTitle.BackColor = Color.White;
            btnVanPhongTitle.BackColor = Color.White;
            btnTroGiupTitle.BackColor = Color.White;
        }

        private void SelectTab(string tabName, Button selectedButton)
        {
            // safe guard against missing tab pages
            if (tabRibbon != null && tabRibbon.TabPages != null && tabRibbon.TabPages.ContainsKey(tabName))
            {
                tabRibbon.SelectedTab = tabRibbon.TabPages[tabName];
            }

            ResetColorTabTitle();

            if (selectedButton != null)
                selectedButton.BackColor = Color.FromArgb(233, 233, 233);

            // clear workspace when switching main tab (we will load the landing page separately on login)
            pnlWorkspace.Controls.Clear();
        }
        private void btnAdminTitle_Click(object sender, EventArgs e)
        {
            SelectTab("TabAdmin", sender as Button);
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
            SelectTab("TabOwner", sender as Button);
        }

        private void btnKhachHangTitle_Click(object sender, EventArgs e)
        {
            SelectTab("TabKhachHang", sender as Button);
        }

        private void btnBanHangTitle_Click(object sender, EventArgs e)
        {
            SelectTab("TabBanHang", sender as Button);
        }

        private void btnVanPhongTitle_Click(object sender, EventArgs e)
        {
            SelectTab("TabVanPhong", sender as Button);
        }

        private void btnKhoTitle_Click(object sender, EventArgs e)
        {
            SelectTab("TabKho", sender as Button);
        }

        private void btnTroGiupTitle_Click(object sender, EventArgs e)
        {
            SelectTab("TabTroGiup", sender as Button);
            btnTrangMoDau_Click(null, null);
        }

        #endregion

        #region Load Form vào pnlWorkspace

        private void btnThayDoiThongTin_Click(object sender, EventArgs e)
        {
            OpenThayDoiThongTin();
        }

        private void btnBHThayDoiThongTin_Click(object sender, EventArgs e)
        {
            OpenThayDoiThongTin();
        }

        private void btnVPThayDoiThongTin_Click(object sender, EventArgs e)
        {
            OpenThayDoiThongTin();
        }

        private void btnKhoThayDoiThongTin_Click(object sender, EventArgs e)
        {
            OpenThayDoiThongTin();
        }

        private void OpenThayDoiThongTin()
        {
            if (currentUser == null)
            {
                MessageBox.Show("Không tìm thấy thông tin người dùng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maNhanVien = GetMaNhanVienFromUsername(currentUser.TenDangNhap);

            if (string.IsNullOrEmpty(maNhanVien))
            {
                MessageBox.Show("Không tìm thấy mã nhân viên tương ứng với tài khoản này!\n" +
                                "Vui lòng kiểm tra lại dữ liệu trong bảng NhanVien.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FrmThaydoithongtin frm = new FrmThaydoithongtin(maNhanVien, currentUser.TenDangNhap))
            {
                frm.ShowDialog(this);
            }
        }

        public void LoadPage(Form form)
        {
            if (form == null) return;

            pnlWorkspace.Controls.Clear();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;

            pnlWorkspace.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }


        private void btnTrangChu_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.TrangChu);

        private void btnLichSuMuaHang_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.LichSuDonHang);
        private string GetMaKhachHangFromUsername(string tenDangNhap)
        {
            string query = @"
        SELECT MAKH
        FROM TaiKhoan
        WHERE TENDANGNHAP = @tenDangNhap";

            SqlParameter[] parameters =
            {
        new SqlParameter("@tenDangNhap", tenDangNhap)
    };

            object result = DataProvider.ExecuteScalar(query, parameters);

            return result?.ToString();
        }

        private void btnKHDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                using (FrmDoimatkhau frm = new FrmDoimatkhau(currentUser.TenDangNhap))
                {
                    frm.ShowDialog(this);
                }
            }
        }

        private void btnKHThayDoiThongTin_Click(object sender, EventArgs e)
        {
            if (currentUser == null) return;

            string maKH = new TaiKhoanBUS().GetUserID(currentUser.TenDangNhap);

            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi");
                return;
            }

            using (var frm = new FrmThaydoithongtinKH(maKH))
            {
                frm.ShowDialog(this);
            }
        }

        // BÁN HÀNG
        private void btnDonHang_Click(object sender, EventArgs e) => LoadPage(GlobalPages.DonHang);
        private void btnKhachHang_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.KhachHang);
        private void btnSalesDashboard_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.SalesDashboard);
        private void btnBHDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                using (FrmDoimatkhau frm = new FrmDoimatkhau(currentUser.TenDangNhap))
                {
                    frm.ShowDialog(this);
                }
            }
        }

        // VĂN PHÒNG
        private void btnDonHangOffice_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.DonHangOffice);
        private void btnBaoCaoOffice_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.OfficeDashboard);
        private void btnVPDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                using (FrmDoimatkhau frm = new FrmDoimatkhau(currentUser.TenDangNhap))
                {
                    frm.ShowDialog(this);
                }
            }
        }


        private void btnChungTu_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.ChungTu);



        // OWNER / ADMIN
        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.QuanLyTaiKhoan);
        private void btnBaoCao_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.OwnerDashboard);
        private void btnDanhMuc_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.DanhMuc);
        private void btnNhanVien_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.NhanVien);
        private void btnKTChungTu_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.KTChungTu);
        private void btnOwnerThayDoiThongTin_Click(object sender, EventArgs e)
        {
            OpenThayDoiThongTin();
        }
        private void btnOwnerThongTinTrungTam_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmThongTinTrungTam())
            {
                frm.ShowDialog(this);
            }
        }
        private void btnOwnerDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                using (FrmDoimatkhau frm = new FrmDoimatkhau(currentUser.TenDangNhap))
                {
                    frm.ShowDialog(this);
                }
            }
        }

        private void btnKetNoiCSDL_Click(object sender, EventArgs e)
        {
            using (FrmKetNoiCSDL frm = new FrmKetNoiCSDL())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Đã cập nhật kết nối cơ sở dữ liệu thành công!",
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSaoLuuPhucHoi_Click(object sender, EventArgs e)
        {
            using (var frm = new _03_VuNgocLinh.GUI.Pages.Admin.FrmSaoLuuPhucHoi())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
            => LoadPage(GlobalPages.Log);
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                using (FrmDoimatkhau frm = new FrmDoimatkhau(currentUser.TenDangNhap))
                {
                    frm.ShowDialog(this);
                }
            }
        }

        private void btnTrangMoDau_Click(object sender, EventArgs e)
        {
            if (GlobalPages.TrangMoDau == null || GlobalPages.TrangMoDau.IsDisposed)
            {
                GlobalPages.TrangMoDau = new FrmTrangMoDau();
            }

            if (GlobalPages.TrangMoDau is FrmTrangMoDau trangMoDau)
            {
                trangMoDau.CurrentUser = currentUser;
            }

            LoadPage(GlobalPages.TrangMoDau);
        }

        private void btnThongTinPhanMem_Click(object sender, EventArgs e)
        {
            using (FrmThongTinPhanMem frm = new FrmThongTinPhanMem())
            {
                frm.ShowDialog(this);
            }
        }

        #endregion

        private void PhanQuyen()
        {
            // hide all main tabs by default, always show help
            btnAdminTitle.Visible = false;
            btnOwner.Visible = false;
            btnKhachHangTitle.Visible = false;
            btnBanHangTitle.Visible = false;
            btnVanPhongTitle.Visible = false;
            btnTroGiupTitle.Visible = true;

            // If there's no user information, show a safe default (customer/home)
            if (currentUser == null && string.IsNullOrWhiteSpace(Session.UserName))
            {
                btnKhachHangTitle.Visible = true;
                SelectTab("TabKhachHang", btnKhachHangTitle);
                return;
            }

            // Read role: prefer Session.Role, then DTO.LoaiTaiKhoan, then legacy VaiTro
            string roleRaw = Session.Role ?? currentUser?.LoaiTaiKhoan ?? currentUser?.VaiTro ?? "";
            string roleKey = roleRaw?.Trim() ?? "";
            string roleLower = roleKey.ToLowerInvariant();

            // If still empty, try to infer from account linkage (MAKH / MANV) or DB
            if (string.IsNullOrEmpty(roleLower) && currentUser != null)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(currentUser.MaKhachHang))
                    {
                        roleLower = "khách hàng";
                    }
                    else if (!string.IsNullOrWhiteSpace(currentUser.MaNhanVien))
                    {
                        string query = "SELECT LOAITAIKHOAN FROM TaiKhoan WHERE TENDANGNHAP = @tenDangNhap";
                        SqlParameter[] parameters = { new SqlParameter("@tenDangNhap", currentUser.TenDangNhap) };
                        object loaiObj = DataProvider.ExecuteScalar(query, parameters);
                        if (loaiObj != null)
                            roleLower = loaiObj.ToString().Trim().ToLowerInvariant();
                        else
                            roleLower = "nhân viên bán hàng";
                    }
                }
                catch
                {
                    // ignore DB errors and fall through to default
                }
            }

            // Persist resolved role to Session for future calls
            if (!string.IsNullOrWhiteSpace(roleLower))
            {
                Session.Role = roleLower;
            }

            // Chủ doanh nghiệp (Owner) -> TabOwner riêng
            if (roleLower.Contains("chủ doanh nghiệp") ||
                roleLower.Contains("chu doanh nghiep"))
            {
                btnOwner.Visible = true;
                SelectTab("TabOwner", btnOwner);
                LoadPage(GlobalPages.OwnerDashboard);
                return;
            }

            // Admin (Quản lý hệ thống) -> TabAdmin
            if (roleLower.Contains("nhân viên quản lý") ||
                roleLower.Contains("nhan vien quan ly") ||
                roleLower.Contains("quản trị") ||
                roleLower.Contains("quantri") ||
                roleLower.Contains("admin") ||
                roleLower.Contains("administrator"))
            {
                btnAdminTitle.Visible = true;
                SelectTab("TabAdmin", btnAdminTitle);
                return;
            }

            // Sales / Bán hàng
            if (roleLower.Contains("nhân viên bán hàng") ||
                roleLower.Contains("nhan vien ban hang") ||
                roleLower.Contains("banhang") ||
                roleLower.Contains("sales"))
            {
                btnBanHangTitle.Visible = true;
                SelectTab("TabBanHang", btnBanHangTitle);
                return;
            }

            // Văn phòng / Office
            if (roleLower.Contains("nhân viên văn phòng") ||
                roleLower.Contains("nhan vien van phong") ||
                roleLower.Contains("vanphong") ||
                roleLower.Contains("office"))
            {
                btnVanPhongTitle.Visible = true;
                SelectTab("TabVanPhong", btnVanPhongTitle);
                return;
            }

            // Customer / default -> show KhachHang tab
            btnKhachHangTitle.Visible = true;
            SelectTab("TabKhachHang", btnKhachHangTitle);
        }

        public void LoadGiaoDien()
        {
            if (Session.Role == "Khách hàng")
            {
                var kh = KhachHangDAL.GetById(Session.UserID);

                lblUserName.Text =
                    kh != null
                    ? Convert.ToString(kh["hoTen"])
                    : Session.UserID;
            }
            else if (Session.Role.StartsWith("Nhân viên"))
            {
                var nv = NhanVienDAL.GetById(Session.UserID);

                lblUserName.Text = nv != null
                    ? nv["TENNV"].ToString()
                    : Session.UserID;
            }
            else
            {
                lblUserName.Text = Session.UserID;
            }

            // configure which tabs/buttons are visible and which tab is selected
            PhanQuyen();

            // ensure essential pages are prepared (creates pages used by buttons)
            GlobalPages.LoadEssentialPages();

            // always show the landing/help page on login
            if (GlobalPages.TrangMoDau == null || GlobalPages.TrangMoDau.IsDisposed)
            {
                GlobalPages.TrangMoDau = new FrmTrangMoDau();
            }

            if (GlobalPages.TrangMoDau is FrmTrangMoDau trang)
            {
                trang.CurrentUser = currentUser;
            }

            // Load landing page into workspace regardless of selected tab
            LoadPage(GlobalPages.TrangMoDau);

            this.WindowState = FormWindowState.Maximized;
        }



        public void Login()
        {
            using (FrmLogin frmLogin = new FrmLogin())
            {
                if (frmLogin.ShowDialog(this) == DialogResult.OK)
                {
                    currentUser = frmLogin.Tag as TaiKhoanDTO;
                    if (currentUser != null)
                    {
                        LoadGiaoDien();
                        this.Show();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Hide();
            Login();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                currentUser = null;
                Session.UserName = null;
                Session.Role = null;
                Session.UserID = null;

                // optional: dispose cached pages to free resources (call if you add Dispose logic to GlobalPages)
                // GlobalPages.DisposeAllPages();

                this.Hide();
                Login();
            }
        }

        private void pnlWorkspace_Paint(object sender, PaintEventArgs e)
        {
        }

        private string GetMaNhanVienFromUsername(string tenDangNhap)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
                return null;

            string query = @"
        SELECT MANV
        FROM TaiKhoan
        WHERE TENDANGNHAP = @tenDangNhap";

            SqlParameter[] parameters =
            {
        new SqlParameter("@tenDangNhap", tenDangNhap)
    };

            object result = DataProvider.ExecuteScalar(query, parameters);

            return result?.ToString();
        }
        private void btnPhieu_Click(object sender, EventArgs e)
        {

        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {

        }

    }
}
