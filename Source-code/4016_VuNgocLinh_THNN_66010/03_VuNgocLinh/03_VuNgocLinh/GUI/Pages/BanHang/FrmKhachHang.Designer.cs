namespace _03_VuNgocLinh.GUI.Pages.BanHang
{
    partial class FrmKhachHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridKetQua = new System.Windows.Forms.DataGridView();
            this.pnlGridHeader = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.pnlGridBtns = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXemTatCa = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.pnlDetailCard = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbNV = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbbTrangThai = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cbbGioiTinh = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.pnlSearchCard = new System.Windows.Forms.Panel();
            this.chkMaKH = new System.Windows.Forms.CheckBox();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.chkTenKH = new System.Windows.Forms.CheckBox();
            this.txHoTen = new System.Windows.Forms.TextBox();
            this.chkGioiTinh = new System.Windows.Forms.CheckBox();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.cboTrangThaiKH = new System.Windows.Forms.ComboBox();
            this.pnlSearchBtns = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnDatLai = new System.Windows.Forms.Button();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSub = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbHoTen = new System.Windows.Forms.Label();
            this.lbMaKH = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlRoot.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKetQua)).BeginInit();
            this.pnlGridHeader.SuspendLayout();
            this.pnlGridBtns.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.pnlDetailCard.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlSearchCard.SuspendLayout();
            this.pnlSearchBtns.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlRoot.Controls.Add(this.pnlBody);
            this.pnlRoot.Controls.Add(this.pnlHeader);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Size = new System.Drawing.Size(1488, 760);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlGrid);
            this.pnlBody.Controls.Add(this.panel6);
            this.pnlBody.Controls.Add(this.pnlDetail);
            this.pnlBody.Controls.Add(this.panel3);
            this.pnlBody.Controls.Add(this.pnlSearch);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 75);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1488, 685);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.gridKetQua);
            this.pnlGrid.Controls.Add(this.pnlGridHeader);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(342, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(14);
            this.pnlGrid.Size = new System.Drawing.Size(804, 685);
            this.pnlGrid.TabIndex = 12;
            // 
            // gridKetQua
            // 
            this.gridKetQua.AllowUserToAddRows = false;
            this.gridKetQua.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.gridKetQua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridKetQua.BackgroundColor = System.Drawing.Color.White;
            this.gridKetQua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridKetQua.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridKetQua.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridKetQua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridKetQua.ColumnHeadersHeight = 38;
            this.gridKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridKetQua.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKetQua.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridKetQua.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            this.gridKetQua.Location = new System.Drawing.Point(14, 64);
            this.gridKetQua.MultiSelect = false;
            this.gridKetQua.Name = "gridKetQua";
            this.gridKetQua.ReadOnly = true;
            this.gridKetQua.RowHeadersVisible = false;
            this.gridKetQua.RowHeadersWidth = 51;
            this.gridKetQua.RowTemplate.Height = 34;
            this.gridKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridKetQua.Size = new System.Drawing.Size(776, 607);
            this.gridKetQua.TabIndex = 1;
            this.gridKetQua.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridKetQua_CellClick);
            // 
            // pnlGridHeader
            // 
            this.pnlGridHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlGridHeader.Controls.Add(this.lblGridTitle);
            this.pnlGridHeader.Controls.Add(this.pnlGridBtns);
            this.pnlGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridHeader.Location = new System.Drawing.Point(14, 14);
            this.pnlGridHeader.Name = "pnlGridHeader";
            this.pnlGridHeader.Size = new System.Drawing.Size(776, 50);
            this.pnlGridHeader.TabIndex = 0;
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.lblGridTitle.Location = new System.Drawing.Point(0, 14);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(228, 25);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "📋  Danh sách khách hàng";
            // 
            // pnlGridBtns
            // 
            this.pnlGridBtns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGridBtns.BackColor = System.Drawing.Color.Transparent;
            this.pnlGridBtns.Controls.Add(this.btnThem);
            this.pnlGridBtns.Controls.Add(this.btnSua);
            this.pnlGridBtns.Controls.Add(this.btnXemTatCa);
            this.pnlGridBtns.Location = new System.Drawing.Point(322, 7);
            this.pnlGridBtns.Name = "pnlGridBtns";
            this.pnlGridBtns.Size = new System.Drawing.Size(454, 36);
            this.pnlGridBtns.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(73)))));
            this.btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(144)))), ((int)(((byte)(204)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(13, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(142, 36);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "➕  Thêm mới";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(140)))), ((int)(((byte)(10)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(176, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(123, 36);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "✏️  Cập nhật";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXemTatCa
            // 
            this.btnXemTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.btnXemTatCa.FlatAppearance.BorderSize = 0;
            this.btnXemTatCa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnXemTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTatCa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnXemTatCa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnXemTatCa.Location = new System.Drawing.Point(322, 0);
            this.btnXemTatCa.Name = "btnXemTatCa";
            this.btnXemTatCa.Size = new System.Drawing.Size(128, 36);
            this.btnXemTatCa.TabIndex = 4;
            this.btnXemTatCa.Text = "📄  Xem tất cả";
            this.btnXemTatCa.UseVisualStyleBackColor = false;
            this.btnXemTatCa.Click += new System.EventHandler(this.btnXemTatCa_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1146, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2, 685);
            this.panel6.TabIndex = 11;
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.White;
            this.pnlDetail.Controls.Add(this.lblDetailTitle);
            this.pnlDetail.Controls.Add(this.pnlDetailCard);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Location = new System.Drawing.Point(1148, 0);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.pnlDetail.Size = new System.Drawing.Size(340, 685);
            this.pnlDetail.TabIndex = 13;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(16, 14);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(308, 30);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "📝  Thông tin chi tiết";
            // 
            // pnlDetailCard
            // 
            this.pnlDetailCard.AutoScroll = true;
            this.pnlDetailCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlDetailCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetailCard.Controls.Add(this.label8);
            this.pnlDetailCard.Controls.Add(this.textBox2);
            this.pnlDetailCard.Controls.Add(this.label6);
            this.pnlDetailCard.Controls.Add(this.txtTenDangNhap);
            this.pnlDetailCard.Controls.Add(this.label4);
            this.pnlDetailCard.Controls.Add(this.textBox1);
            this.pnlDetailCard.Controls.Add(this.lbNV);
            this.pnlDetailCard.Controls.Add(this.txtSoDienThoai);
            this.pnlDetailCard.Controls.Add(this.label1);
            this.pnlDetailCard.Controls.Add(this.txtEmail);
            this.pnlDetailCard.Controls.Add(this.label14);
            this.pnlDetailCard.Controls.Add(this.txtDiaChi);
            this.pnlDetailCard.Controls.Add(this.label13);
            this.pnlDetailCard.Controls.Add(this.cbbTrangThai);
            this.pnlDetailCard.Controls.Add(this.label10);
            this.pnlDetailCard.Controls.Add(this.dtpNgayTao);
            this.pnlDetailCard.Controls.Add(this.label9);
            this.pnlDetailCard.Controls.Add(this.dtpNgaySinh);
            this.pnlDetailCard.Controls.Add(this.label11);
            this.pnlDetailCard.Controls.Add(this.cbbGioiTinh);
            this.pnlDetailCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailCard.Location = new System.Drawing.Point(16, 14);
            this.pnlDetailCard.Name = "pnlDetailCard";
            this.pnlDetailCard.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.pnlDetailCard.Size = new System.Drawing.Size(308, 657);
            this.pnlDetailCard.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label8.Location = new System.Drawing.Point(14, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 20);
            this.label8.TabIndex = 85;
            this.label8.Text = "MÃ KHÁCH HÀNG";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox2.Location = new System.Drawing.Point(14, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(256, 30);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label6.Location = new System.Drawing.Point(18, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 93;
            this.label6.Text = "TÊN ĐĂNG NHẬP";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenDangNhap.Location = new System.Drawing.Point(18, 112);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(256, 30);
            this.txtTenDangNhap.TabIndex = 2;
            this.txtTenDangNhap.TextChanged += new System.EventHandler(this.txtTenDangNhap_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label4.Location = new System.Drawing.Point(18, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 86;
            this.label4.Text = "HỌ TÊN";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox1.Location = new System.Drawing.Point(18, 172);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 30);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbNV
            // 
            this.lbNV.AutoSize = true;
            this.lbNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lbNV.Location = new System.Drawing.Point(18, 209);
            this.lbNV.Name = "lbNV";
            this.lbNV.Size = new System.Drawing.Size(119, 20);
            this.lbNV.TabIndex = 87;
            this.lbNV.Text = "SỐ ĐIỆN THOẠI";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoDienThoai.Location = new System.Drawing.Point(18, 231);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(256, 30);
            this.txtSoDienThoai.TabIndex = 4;
            this.txtSoDienThoai.TextChanged += new System.EventHandler(this.txtSoDienThoai_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(18, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 92;
            this.label1.Text = "EMAIL";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(18, 289);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(256, 30);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label14.Location = new System.Drawing.Point(18, 332);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 20);
            this.label14.TabIndex = 95;
            this.label14.Text = "ĐỊA CHỈ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Location = new System.Drawing.Point(18, 354);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(256, 30);
            this.txtDiaChi.TabIndex = 6;
            this.txtDiaChi.TextChanged += new System.EventHandler(this.txtDiaChi_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label13.Location = new System.Drawing.Point(18, 392);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 20);
            this.label13.TabIndex = 97;
            this.label13.Text = "TRẠNG THÁI";
            // 
            // cbbTrangThai
            // 
            this.cbbTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbTrangThai.FormattingEnabled = true;
            this.cbbTrangThai.Location = new System.Drawing.Point(18, 414);
            this.cbbTrangThai.Name = "cbbTrangThai";
            this.cbbTrangThai.Size = new System.Drawing.Size(256, 31);
            this.cbbTrangThai.TabIndex = 7;
            this.cbbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbbTrangThai_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label10.Location = new System.Drawing.Point(18, 454);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 20);
            this.label10.TabIndex = 99;
            this.label10.Text = "NGÀY TẠO";
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayTao.Location = new System.Drawing.Point(18, 476);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(256, 30);
            this.dtpNgayTao.TabIndex = 8;
            this.dtpNgayTao.ValueChanged += new System.EventHandler(this.dtpNgayTao_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label9.Location = new System.Drawing.Point(18, 515);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 101;
            this.label9.Text = "NGÀY SINH";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgaySinh.Location = new System.Drawing.Point(18, 537);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(256, 30);
            this.dtpNgaySinh.TabIndex = 9;
            this.dtpNgaySinh.ValueChanged += new System.EventHandler(this.dtpNgaySinh_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label11.Location = new System.Drawing.Point(18, 576);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 103;
            this.label11.Text = "GIỚI TÍNH";
            // 
            // cbbGioiTinh
            // 
            this.cbbGioiTinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbGioiTinh.FormattingEnabled = true;
            this.cbbGioiTinh.Location = new System.Drawing.Point(18, 598);
            this.cbbGioiTinh.Name = "cbbGioiTinh";
            this.cbbGioiTinh.Size = new System.Drawing.Size(256, 31);
            this.cbbGioiTinh.TabIndex = 10;
            this.cbbGioiTinh.SelectedIndexChanged += new System.EventHandler(this.cbbGioiTinh_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(340, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 685);
            this.panel3.TabIndex = 10;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Controls.Add(this.lblSearchTitle);
            this.pnlSearch.Controls.Add(this.pnlSearchCard);
            this.pnlSearch.Controls.Add(this.pnlSearchBtns);
            this.pnlSearch.Controls.Add(this.lblTongCong);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.pnlSearch.Size = new System.Drawing.Size(340, 685);
            this.pnlSearch.TabIndex = 9;
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.lblSearchTitle.Location = new System.Drawing.Point(19, 34);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(308, 30);
            this.lblSearchTitle.TabIndex = 0;
            this.lblSearchTitle.Text = "Bộ lọc tìm kiếm";
            // 
            // pnlSearchCard
            // 
            this.pnlSearchCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlSearchCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchCard.Controls.Add(this.chkMaKH);
            this.pnlSearchCard.Controls.Add(this.txtMaKhachHang);
            this.pnlSearchCard.Controls.Add(this.chkTenKH);
            this.pnlSearchCard.Controls.Add(this.txHoTen);
            this.pnlSearchCard.Controls.Add(this.chkGioiTinh);
            this.pnlSearchCard.Controls.Add(this.cboGioiTinh);
            this.pnlSearchCard.Controls.Add(this.chkTrangThai);
            this.pnlSearchCard.Controls.Add(this.cboTrangThaiKH);
            this.pnlSearchCard.Location = new System.Drawing.Point(16, 68);
            this.pnlSearchCard.Name = "pnlSearchCard";
            this.pnlSearchCard.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlSearchCard.Size = new System.Drawing.Size(308, 320);
            this.pnlSearchCard.TabIndex = 1;
            // 
            // chkMaKH
            // 
            this.chkMaKH.AutoSize = true;
            this.chkMaKH.Checked = true;
            this.chkMaKH.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMaKH.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkMaKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.chkMaKH.Location = new System.Drawing.Point(12, 14);
            this.chkMaKH.Name = "chkMaKH";
            this.chkMaKH.Size = new System.Drawing.Size(176, 25);
            this.chkMaKH.TabIndex = 1;
            this.chkMaKH.Text = "Theo mã khách hàng";
            this.chkMaKH.CheckedChanged += new System.EventHandler(this.chkMaKH_CheckedChanged);
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaKhachHang.Location = new System.Drawing.Point(12, 40);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(270, 30);
            this.txtMaKhachHang.TabIndex = 2;
            this.txtMaKhachHang.TextChanged += new System.EventHandler(this.txtMaKhachHang_TextChanged);
            // 
            // chkTenKH
            // 
            this.chkTenKH.AutoSize = true;
            this.chkTenKH.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkTenKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.chkTenKH.Location = new System.Drawing.Point(12, 82);
            this.chkTenKH.Name = "chkTenKH";
            this.chkTenKH.Size = new System.Drawing.Size(176, 25);
            this.chkTenKH.TabIndex = 3;
            this.chkTenKH.Text = "Theo tên khách hàng";
            this.chkTenKH.CheckedChanged += new System.EventHandler(this.chkTenKH_CheckedChanged);
            // 
            // txHoTen
            // 
            this.txHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txHoTen.Location = new System.Drawing.Point(12, 108);
            this.txHoTen.Name = "txHoTen";
            this.txHoTen.Size = new System.Drawing.Size(270, 30);
            this.txHoTen.TabIndex = 4;
            this.txHoTen.TextChanged += new System.EventHandler(this.txHoTen_TextChanged);
            // 
            // chkGioiTinh
            // 
            this.chkGioiTinh.AutoSize = true;
            this.chkGioiTinh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.chkGioiTinh.Location = new System.Drawing.Point(12, 150);
            this.chkGioiTinh.Name = "chkGioiTinh";
            this.chkGioiTinh.Size = new System.Drawing.Size(128, 25);
            this.chkGioiTinh.TabIndex = 5;
            this.chkGioiTinh.Text = "Theo giới tính";
            this.chkGioiTinh.CheckedChanged += new System.EventHandler(this.chkGioiTinh_CheckedChanged);
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioiTinh.Location = new System.Drawing.Point(12, 176);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(270, 31);
            this.cboGioiTinh.TabIndex = 6;
            this.cboGioiTinh.SelectedIndexChanged += new System.EventHandler(this.cboGioiTinh_SelectedIndexChanged);
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.chkTrangThai.Location = new System.Drawing.Point(12, 218);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(104, 25);
            this.chkTrangThai.TabIndex = 7;
            this.chkTrangThai.Text = "Trạng thái:";
            this.chkTrangThai.CheckedChanged += new System.EventHandler(this.chkLoaiKH_CheckedChanged);
            // 
            // cboTrangThaiKH
            // 
            this.cboTrangThaiKH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThaiKH.FormattingEnabled = true;
            this.cboTrangThaiKH.Location = new System.Drawing.Point(12, 244);
            this.cboTrangThaiKH.Name = "cboTrangThaiKH";
            this.cboTrangThaiKH.Size = new System.Drawing.Size(270, 31);
            this.cboTrangThaiKH.TabIndex = 8;
            this.cboTrangThaiKH.SelectedIndexChanged += new System.EventHandler(this.cboTrangThaiKH_SelectedIndexChanged);
            // 
            // pnlSearchBtns
            // 
            this.pnlSearchBtns.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearchBtns.Controls.Add(this.btnTimKiem);
            this.pnlSearchBtns.Controls.Add(this.btnDatLai);
            this.pnlSearchBtns.Location = new System.Drawing.Point(13, 394);
            this.pnlSearchBtns.Name = "pnlSearchBtns";
            this.pnlSearchBtns.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlSearchBtns.Size = new System.Drawing.Size(308, 54);
            this.pnlSearchBtns.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(73)))));
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(144)))), ((int)(((byte)(204)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(1, 12);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(148, 36);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "🔍  Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnDatLai
            // 
            this.btnDatLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.btnDatLai.FlatAppearance.BorderSize = 0;
            this.btnDatLai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnDatLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatLai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDatLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnDatLai.Location = new System.Drawing.Point(157, 12);
            this.btnDatLai.Name = "btnDatLai";
            this.btnDatLai.Size = new System.Drawing.Size(148, 36);
            this.btnDatLai.TabIndex = 2;
            this.btnDatLai.Text = "↺  Đặt lại";
            this.btnDatLai.UseVisualStyleBackColor = false;
            this.btnDatLai.Click += new System.EventHandler(this.btnDatLai_Click);
            // 
            // lblTongCong
            // 
            this.lblTongCong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblTongCong.Location = new System.Drawing.Point(16, 647);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(308, 24);
            this.lblTongCong.TabIndex = 3;
            this.lblTongCong.Text = "Tổng cộng: — khách hàng";
            this.lblTongCong.Click += new System.EventHandler(this.lblTongCong_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Controls.Add(this.lblPageSub);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlHeader.Size = new System.Drawing.Size(1488, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(20, 8);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(400, 40);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "👤  QUẢN LÝ KHÁCH HÀNG";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPageSub
            // 
            this.lblPageSub.AutoSize = true;
            this.lblPageSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.lblPageSub.Location = new System.Drawing.Point(16, 48);
            this.lblPageSub.Name = "lblPageSub";
            this.lblPageSub.Size = new System.Drawing.Size(355, 20);
            this.lblPageSub.TabIndex = 1;
            this.lblPageSub.Text = "Tìm kiếm, thêm mới và quản lý thông tin khách hàng";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 0;
            this.label5.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 0;
            this.label7.Visible = false;
            // 
            // lbHoTen
            // 
            this.lbHoTen.Location = new System.Drawing.Point(0, 0);
            this.lbHoTen.Name = "lbHoTen";
            this.lbHoTen.Size = new System.Drawing.Size(100, 23);
            this.lbHoTen.TabIndex = 0;
            this.lbHoTen.Visible = false;
            // 
            // lbMaKH
            // 
            this.lbMaKH.Location = new System.Drawing.Point(0, 0);
            this.lbMaKH.Name = "lbMaKH";
            this.lbMaKH.Size = new System.Drawing.Size(100, 23);
            this.lbMaKH.TabIndex = 0;
            this.lbMaKH.Visible = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 0;
            this.label12.Visible = false;
            // 
            // FrmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1488, 760);
            this.Controls.Add(this.pnlRoot);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1200, 680);
            this.Name = "FrmKhachHang";
            this.Text = "Quản lý Khách hàng";
            this.Load += new System.EventHandler(this.FrmKhachHang_Load);
            this.pnlRoot.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKetQua)).EndInit();
            this.pnlGridHeader.ResumeLayout(false);
            this.pnlGridHeader.PerformLayout();
            this.pnlGridBtns.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetailCard.ResumeLayout(false);
            this.pnlDetailCard.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearchCard.ResumeLayout(false);
            this.pnlSearchCard.PerformLayout();
            this.pnlSearchBtns.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ── Khai báo fields ───────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSub;
        private System.Windows.Forms.Panel pnlBody;

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.Panel pnlSearchCard;
        private System.Windows.Forms.CheckBox chkMaKH;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.CheckBox chkTenKH;
        private System.Windows.Forms.TextBox txHoTen;
        private System.Windows.Forms.CheckBox chkGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThaiKH;
        private System.Windows.Forms.Panel pnlSearchBtns;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnDatLai;
        private System.Windows.Forms.Label lblTongCong;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlGridHeader;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Panel pnlGridBtns;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXemTatCa;
        private System.Windows.Forms.DataGridView gridKetQua;

        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Panel pnlDetailCard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbNV;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbbTrangThai;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbbGioiTinh;

        // Legacy (ẩn — chỉ giữ để code-behind không lỗi)
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbHoTen;
        private System.Windows.Forms.Label lbMaKH;
        private System.Windows.Forms.Label label12;

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
    }
}
