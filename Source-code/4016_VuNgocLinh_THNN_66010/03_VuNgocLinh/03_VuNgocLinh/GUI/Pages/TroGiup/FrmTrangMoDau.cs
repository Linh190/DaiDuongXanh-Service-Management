using _03_VuNgocLinh;
using _03_VuNgocLinh.DAL;
using _03_VuNgocLinh.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace _03_VuNgocLinh.GUI.Pages.TroGiup
{
    public partial class FrmTrangMoDau : Form
    {
        private DataRow _companyRow;
        private TaiKhoanDTO _currentUser;

        public FrmTrangMoDau()
        {
            InitializeComponent();
            this.Load += FrmTrangMoDau_Load;
        }

        /// <summary>
        /// Public property used by callers (e.g. FrmMain) to pass the currently logged-in user.
        /// Setting this updates the welcome label immediately.
        /// </summary>
        public TaiKhoanDTO CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                UpdateWelcomeLabel();
            }
        }

        private void FrmTrangMoDau_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCompany();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin công ty: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCompany()
        {
            // Take first company row if any
            var dt = DataProvider.ExecuteQuery("SELECT TOP(1) MACTY, TENCONGTY, TENVIETTAT, TENQUOCTE, MASOTHUE, NGUOIDAIDIEN, DIACHI, DIENTHOAI, EMAIL, WEBSITE, LINHVUC, NGAYTHANHLAP FROM CongTy");
            if (dt.Rows.Count == 0)
            {
                _companyRow = null;
                UpdateWelcomeLabel(); // still show user if set
                lblAddress.Text = "Địa chỉ: (chưa cấu hình)";
                lblLienHe.Text = "Liên hệ: (chưa cấu hình)";
                return;
            }

            _companyRow = dt.Rows[0];

            string ten = Convert.ToString(_companyRow["TENCONGTY"]);
            string diachi = Convert.ToString(_companyRow["DIACHI"]);
            string dienthoai = Convert.ToString(_companyRow["DIENTHOAI"]);
            string email = Convert.ToString(_companyRow["EMAIL"]);

            // Welcome label is decided by UpdateWelcomeLabel (prefers CurrentUser) but if no user, show company name
            if (_currentUser == null)
                lblWelcome.Text = string.IsNullOrWhiteSpace(ten) ? "Welcome, <user name>" : ten;

            lblAddress.Text = "Địa chỉ: " + (string.IsNullOrWhiteSpace(diachi) ? "—" : diachi);
            lblLienHe.Text = "Liên hệ: " + (string.IsNullOrWhiteSpace(dienthoai) ? "—" : dienthoai)
                              + (string.IsNullOrWhiteSpace(email) ? "" : "  •  " + email);

            // wire click handlers to show details
            lblWelcome.Click -= lblWelcome_Click;
            lblAddress.Click -= lblAddress_Click;
            lblLienHe.Click -= lblLienHe_Click;
            lblWelcome.Click += lblWelcome_Click;
            lblAddress.Click += lblAddress_Click;
            lblLienHe.Click += lblLienHe_Click;
        }

        private void UpdateWelcomeLabel()
        {
            if (!string.IsNullOrWhiteSpace(Session.UserName))
            {
                lblWelcome.Text = "Welcome, " + Session.UserName;
            }
            else if (_currentUser != null && !string.IsNullOrWhiteSpace(_currentUser.TenDangNhap))
            {
                lblWelcome.Text = "Welcome, " + _currentUser.TenDangNhap;
            }
            else if (_companyRow != null)
            {
                string ten = Convert.ToString(_companyRow["TENCONGTY"]);
                lblWelcome.Text = string.IsNullOrWhiteSpace(ten) ? "Welcome, <user name>" : ten;
            }
            else
            {
                lblWelcome.Text = "Welcome, <user name>";
            }
        }

        private void ShowCompanyDetails()
        {
            if (_companyRow == null)
            {
                MessageBox.Show("Chưa có thông tin công ty.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ten = Convert.ToString(_companyRow["TENCONGTY"]);
            string viettat = Convert.ToString(_companyRow["TENVIETTAT"]);
            string quocte = Convert.ToString(_companyRow["TENQUOCTE"]);
            string mst = Convert.ToString(_companyRow["MASOTHUE"]);
            string ngay = _companyRow["NGAYTHANHLAP"] == DBNull.Value ? "" : Convert.ToDateTime(_companyRow["NGAYTHANHLAP"]).ToString("dd/MM/yyyy");
            string nd = Convert.ToString(_companyRow["NGUOIDAIDIEN"]);
            string diachi = Convert.ToString(_companyRow["DIACHI"]);
            string dt = Convert.ToString(_companyRow["DIENTHOAI"]);
            string email = Convert.ToString(_companyRow["EMAIL"]);
            string website = Convert.ToString(_companyRow["WEBSITE"]);
            string linhvuc = Convert.ToString(_companyRow["LINHVUC"]);
            string msg =
                $"Tên công ty: {ten}\n" +
                (string.IsNullOrWhiteSpace(viettat) ? "" : $"Tên viết tắt: {viettat}\n") +
                (string.IsNullOrWhiteSpace(quocte) ? "" : $"Tên quốc tế: {quocte}\n") +
                $"Mã số thuế: {mst}\n" +
                (string.IsNullOrWhiteSpace(ngay) ? "" : $"Ngày thành lập: {ngay}\n") +
                (string.IsNullOrWhiteSpace(nd) ? "" : $"Người đại diện: {nd}\n") +
                $"Địa chỉ: {diachi}\n" +
                $"Điện thoại: {dt}\n" +
                $"Email: {email}\n" +
                $"Website: {website}\n" +
                $"Lĩnh vực: {linhvuc}";

            MessageBox.Show(msg, "Chi tiết công ty", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblAddress_Click(object sender, EventArgs e)
        {
            ShowCompanyDetails();
        }

        private void lblLienHe_Click(object sender, EventArgs e)
        {
            ShowCompanyDetails();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            ShowCompanyDetails();
        }

        private void FrmTrangMoDau_Load_1(object sender, EventArgs e)
        {

        }
    }
}
