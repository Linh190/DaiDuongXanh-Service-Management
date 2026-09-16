namespace _03_VuNgocLinh.GUI.Pages.Admin
{
    partial class FrmTaiKhoan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.gridKetQua = new System.Windows.Forms.DataGridView();
            this.pnlGridTop = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlGridBtns = new System.Windows.Forms.Panel();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlEditCard = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.pnlNhanVienChon = new System.Windows.Forms.Panel();
            this.lblNVChon = new System.Windows.Forms.Label();
            this.lblMatKhauRo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTrangThaiEdit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboVaiTroEdit = new System.Windows.Forms.ComboBox();
            this.lblPhanQuyen = new System.Windows.Forms.Label();
            this.pnlEditBtns = new System.Windows.Forms.Panel();
            this.btnLuuThongTin = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.pnlFilterCard = new System.Windows.Forms.Panel();
            this.chkTen = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.chkLoaiTK = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboLoaiTK = new System.Windows.Forms.ComboBox();
            this.pnlFilterBtns = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnDatLai = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.quanLyDichVu_DaiDuongXanhDataSet = new _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSet();
            this.taiKhoanBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.taiKhoanTableAdapter = new _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSetTableAdapters.TaiKhoanTableAdapter();
            this.tENDANGNHAPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mATKHAUHASHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOAITAIKHOANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRANGTHAIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mAKHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mANVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taiKhoanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlRoot.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKetQua)).BeginInit();
            this.pnlGridTop.SuspendLayout();
            this.pnlGridBtns.SuspendLayout();
            this.pnlEdit.SuspendLayout();
            this.pnlEditCard.SuspendLayout();
            this.pnlNhanVienChon.SuspendLayout();
            this.pnlEditBtns.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilterCard.SuspendLayout();
            this.pnlFilterBtns.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyDichVu_DaiDuongXanhDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).BeginInit();
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
            this.pnlBody.Controls.Add(this.panel5);
            this.pnlBody.Controls.Add(this.pnlEdit);
            this.pnlBody.Controls.Add(this.panel3);
            this.pnlBody.Controls.Add(this.pnlFilter);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 64);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1488, 696);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.gridKetQua);
            this.pnlGrid.Controls.Add(this.pnlGridTop);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(347, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(14);
            this.pnlGrid.Size = new System.Drawing.Size(794, 696);
            this.pnlGrid.TabIndex = 0;
            // 
            // gridKetQua
            // 
            this.gridKetQua.AllowUserToAddRows = false;
            this.gridKetQua.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.gridKetQua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridKetQua.BackgroundColor = System.Drawing.Color.White;
            this.gridKetQua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridKetQua.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridKetQua.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            this.gridKetQua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gridKetQua.ColumnHeadersHeight = 38;
            this.gridKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridKetQua.DefaultCellStyle = dataGridViewCellStyle12;
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
            this.gridKetQua.Size = new System.Drawing.Size(766, 618);
            this.gridKetQua.TabIndex = 0;
            this.gridKetQua.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridKetQua_CellContentClick);
            // 
            // pnlGridTop
            // 
            this.pnlGridTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlGridTop.Controls.Add(this.label4);
            this.pnlGridTop.Controls.Add(this.pnlGridBtns);
            this.pnlGridTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridTop.Location = new System.Drawing.Point(14, 14);
            this.pnlGridTop.Name = "pnlGridTop";
            this.pnlGridTop.Size = new System.Drawing.Size(766, 50);
            this.pnlGridTop.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.label4.Location = new System.Drawing.Point(0, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "📋  Danh sách tài khoản";
            // 
            // pnlGridBtns
            // 
            this.pnlGridBtns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGridBtns.BackColor = System.Drawing.Color.Transparent;
            this.pnlGridBtns.Controls.Add(this.btnThemMoi);
            this.pnlGridBtns.Controls.Add(this.btnXoa);
            this.pnlGridBtns.Location = new System.Drawing.Point(520, 7);
            this.pnlGridBtns.Name = "pnlGridBtns";
            this.pnlGridBtns.Size = new System.Drawing.Size(246, 36);
            this.pnlGridBtns.TabIndex = 1;
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnThemMoi.FlatAppearance.BorderSize = 0;
            this.btnThemMoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(144)))), ((int)(((byte)(204)))));
            this.btnThemMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnThemMoi.ForeColor = System.Drawing.Color.White;
            this.btnThemMoi.Location = new System.Drawing.Point(0, 0);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(118, 36);
            this.btnThemMoi.TabIndex = 0;
            this.btnThemMoi.Text = "➕  Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = false;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(126, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 36);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "🗑️  Xóa TK";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1141, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 696);
            this.panel5.TabIndex = 1;
            // 
            // pnlEdit
            // 
            this.pnlEdit.BackColor = System.Drawing.Color.White;
            this.pnlEdit.Controls.Add(this.label6);
            this.pnlEdit.Controls.Add(this.pnlEditCard);
            this.pnlEdit.Controls.Add(this.pnlEditBtns);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEdit.Location = new System.Drawing.Point(1143, 0);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.pnlEdit.Size = new System.Drawing.Size(345, 696);
            this.pnlEdit.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Thông tin tài khoản";
            // 
            // pnlEditCard
            // 
            this.pnlEditCard.AutoScroll = true;
            this.pnlEditCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlEditCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditCard.Controls.Add(this.label7);
            this.pnlEditCard.Controls.Add(this.txtTenDangNhap);
            this.pnlEditCard.Controls.Add(this.pnlNhanVienChon);
            this.pnlEditCard.Controls.Add(this.label8);
            this.pnlEditCard.Controls.Add(this.txtMatKhau);
            this.pnlEditCard.Controls.Add(this.label2);
            this.pnlEditCard.Controls.Add(this.cboTrangThaiEdit);
            this.pnlEditCard.Controls.Add(this.label1);
            this.pnlEditCard.Controls.Add(this.cboVaiTroEdit);
            this.pnlEditCard.Controls.Add(this.lblPhanQuyen);
            this.pnlEditCard.Location = new System.Drawing.Point(16, 68);
            this.pnlEditCard.Name = "pnlEditCard";
            this.pnlEditCard.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.pnlEditCard.Size = new System.Drawing.Size(313, 520);
            this.pnlEditCard.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label7.Location = new System.Drawing.Point(14, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "TÊN ĐĂNG NHẬP";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Enabled = false;
            this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenDangNhap.Location = new System.Drawing.Point(14, 36);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(270, 30);
            this.txtTenDangNhap.TabIndex = 1;
            this.txtTenDangNhap.TextChanged += new System.EventHandler(this.txtTenDangNhap_TextChanged);
            // 
            // pnlNhanVienChon
            // 
            this.pnlNhanVienChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlNhanVienChon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNhanVienChon.Controls.Add(this.lblNVChon);
            this.pnlNhanVienChon.Controls.Add(this.lblMatKhauRo);
            this.pnlNhanVienChon.Location = new System.Drawing.Point(14, 328);
            this.pnlNhanVienChon.Name = "pnlNhanVienChon";
            this.pnlNhanVienChon.Padding = new System.Windows.Forms.Padding(8);
            this.pnlNhanVienChon.Size = new System.Drawing.Size(270, 90);
            this.pnlNhanVienChon.TabIndex = 2;
            this.pnlNhanVienChon.Visible = false;
            // 
            // lblNVChon
            // 
            this.lblNVChon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNVChon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNVChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.lblNVChon.Location = new System.Drawing.Point(8, 8);
            this.lblNVChon.Name = "lblNVChon";
            this.lblNVChon.Size = new System.Drawing.Size(252, 22);
            this.lblNVChon.TabIndex = 0;
            // 
            // lblMatKhauRo
            // 
            this.lblMatKhauRo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMatKhauRo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMatKhauRo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(20)))));
            this.lblMatKhauRo.Location = new System.Drawing.Point(8, 30);
            this.lblMatKhauRo.Name = "lblMatKhauRo";
            this.lblMatKhauRo.Size = new System.Drawing.Size(252, 50);
            this.lblMatKhauRo.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label8.Location = new System.Drawing.Point(14, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(264, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "MẬT KHẨU (để trống = giữ nguyên)";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatKhau.Location = new System.Drawing.Point(14, 108);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(270, 30);
            this.txtMatKhau.TabIndex = 4;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label2.Location = new System.Drawing.Point(14, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "TRẠNG THÁI";
            // 
            // cboTrangThaiEdit
            // 
            this.cboTrangThaiEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiEdit.Enabled = false;
            this.cboTrangThaiEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThaiEdit.Location = new System.Drawing.Point(14, 176);
            this.cboTrangThaiEdit.Name = "cboTrangThaiEdit";
            this.cboTrangThaiEdit.Size = new System.Drawing.Size(270, 31);
            this.cboTrangThaiEdit.TabIndex = 6;
            this.cboTrangThaiEdit.SelectedIndexChanged += new System.EventHandler(this.cboTrangThaiEdit_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(14, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "VAI TRÒ";
            // 
            // cboVaiTroEdit
            // 
            this.cboVaiTroEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTroEdit.Enabled = false;
            this.cboVaiTroEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVaiTroEdit.Location = new System.Drawing.Point(14, 244);
            this.cboVaiTroEdit.Name = "cboVaiTroEdit";
            this.cboVaiTroEdit.Size = new System.Drawing.Size(270, 31);
            this.cboVaiTroEdit.TabIndex = 8;
            this.cboVaiTroEdit.SelectedIndexChanged += new System.EventHandler(this.cboVaiTroEdit_SelectedIndexChanged);
            // 
            // lblPhanQuyen
            // 
            this.lblPhanQuyen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblPhanQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblPhanQuyen.Location = new System.Drawing.Point(14, 288);
            this.lblPhanQuyen.Name = "lblPhanQuyen";
            this.lblPhanQuyen.Size = new System.Drawing.Size(270, 24);
            this.lblPhanQuyen.TabIndex = 9;
            this.lblPhanQuyen.Text = "[Role] — …";
            this.lblPhanQuyen.Click += new System.EventHandler(this.lblPhanQuyen_Click);
            // 
            // pnlEditBtns
            // 
            this.pnlEditBtns.BackColor = System.Drawing.Color.Transparent;
            this.pnlEditBtns.Controls.Add(this.btnLuuThongTin);
            this.pnlEditBtns.Controls.Add(this.btnHuyBo);
            this.pnlEditBtns.Location = new System.Drawing.Point(16, 596);
            this.pnlEditBtns.Name = "pnlEditBtns";
            this.pnlEditBtns.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlEditBtns.Size = new System.Drawing.Size(313, 54);
            this.pnlEditBtns.TabIndex = 2;
            // 
            // btnLuuThongTin
            // 
            this.btnLuuThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnLuuThongTin.FlatAppearance.BorderSize = 0;
            this.btnLuuThongTin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(144)))), ((int)(((byte)(204)))));
            this.btnLuuThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuThongTin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLuuThongTin.ForeColor = System.Drawing.Color.White;
            this.btnLuuThongTin.Location = new System.Drawing.Point(0, 10);
            this.btnLuuThongTin.Name = "btnLuuThongTin";
            this.btnLuuThongTin.Size = new System.Drawing.Size(148, 36);
            this.btnLuuThongTin.TabIndex = 0;
            this.btnLuuThongTin.Text = "💾  Lưu thông tin";
            this.btnLuuThongTin.UseVisualStyleBackColor = false;
            this.btnLuuThongTin.Click += new System.EventHandler(this.btnLuuThongTin_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.btnHuyBo.FlatAppearance.BorderSize = 0;
            this.btnHuyBo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnHuyBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyBo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuyBo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnHuyBo.Location = new System.Drawing.Point(156, 10);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(148, 36);
            this.btnHuyBo.TabIndex = 1;
            this.btnHuyBo.Text = "✖  Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = false;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(221)))), ((int)(((byte)(237)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(345, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 696);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.lblTong);
            this.pnlFilter.Controls.Add(this.pnlFilterCard);
            this.pnlFilter.Controls.Add(this.pnlFilterBtns);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(16, 14, 16, 14);
            this.pnlFilter.Size = new System.Drawing.Size(345, 696);
            this.pnlFilter.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(17, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tìm kiếm tài khoản";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblTong
            // 
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblTong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.lblTong.Location = new System.Drawing.Point(18, 419);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(308, 24);
            this.lblTong.TabIndex = 1;
            this.lblTong.Text = "Tổng: 0 tài khoản";
            this.lblTong.Click += new System.EventHandler(this.lblTong_Click);
            // 
            // pnlFilterCard
            // 
            this.pnlFilterCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlFilterCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterCard.Controls.Add(this.chkTen);
            this.pnlFilterCard.Controls.Add(this.label3);
            this.pnlFilterCard.Controls.Add(this.txtTen);
            this.pnlFilterCard.Controls.Add(this.chkLoaiTK);
            this.pnlFilterCard.Controls.Add(this.label9);
            this.pnlFilterCard.Controls.Add(this.cboLoaiTK);
            this.pnlFilterCard.Location = new System.Drawing.Point(16, 68);
            this.pnlFilterCard.Name = "pnlFilterCard";
            this.pnlFilterCard.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlFilterCard.Size = new System.Drawing.Size(313, 240);
            this.pnlFilterCard.TabIndex = 2;
            // 
            // chkTen
            // 
            this.chkTen.AutoSize = true;
            this.chkTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.chkTen.Location = new System.Drawing.Point(12, 14);
            this.chkTen.Name = "chkTen";
            this.chkTen.Size = new System.Drawing.Size(188, 27);
            this.chkTen.TabIndex = 0;
            this.chkTen.Text = "Theo tên đăng nhập";
            this.chkTen.CheckedChanged += new System.EventHandler(this.chkTen_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "TÊN ĐĂNG NHẬP";
            // 
            // txtTen
            // 
            this.txtTen.Enabled = false;
            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTen.Location = new System.Drawing.Point(12, 64);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(273, 30);
            this.txtTen.TabIndex = 2;
            this.txtTen.TextChanged += new System.EventHandler(this.txtTen_TextChanged);
            // 
            // chkLoaiTK
            // 
            this.chkLoaiTK.AutoSize = true;
            this.chkLoaiTK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkLoaiTK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.chkLoaiTK.Location = new System.Drawing.Point(12, 108);
            this.chkLoaiTK.Name = "chkLoaiTK";
            this.chkLoaiTK.Size = new System.Drawing.Size(178, 27);
            this.chkLoaiTK.TabIndex = 3;
            this.chkLoaiTK.Text = "Theo loại tài khoản";
            this.chkLoaiTK.CheckedChanged += new System.EventHandler(this.chkLoaiTK_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(143)))), ((int)(((byte)(175)))));
            this.label9.Location = new System.Drawing.Point(12, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "LOẠI TÀI KHOẢN";
            // 
            // cboLoaiTK
            // 
            this.cboLoaiTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiTK.Enabled = false;
            this.cboLoaiTK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiTK.Location = new System.Drawing.Point(12, 160);
            this.cboLoaiTK.Name = "cboLoaiTK";
            this.cboLoaiTK.Size = new System.Drawing.Size(273, 31);
            this.cboLoaiTK.TabIndex = 5;
            this.cboLoaiTK.SelectedIndexChanged += new System.EventHandler(this.cboLoaiTK_SelectedIndexChanged);
            // 
            // pnlFilterBtns
            // 
            this.pnlFilterBtns.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilterBtns.Controls.Add(this.btnTimKiem);
            this.pnlFilterBtns.Controls.Add(this.btnDatLai);
            this.pnlFilterBtns.Location = new System.Drawing.Point(18, 350);
            this.pnlFilterBtns.Name = "pnlFilterBtns";
            this.pnlFilterBtns.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlFilterBtns.Size = new System.Drawing.Size(313, 54);
            this.pnlFilterBtns.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(144)))), ((int)(((byte)(204)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(0, 10);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(150, 36);
            this.btnTimKiem.TabIndex = 0;
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
            this.btnDatLai.Location = new System.Drawing.Point(158, 10);
            this.btnDatLai.Name = "btnDatLai";
            this.btnDatLai.Size = new System.Drawing.Size(150, 36);
            this.btnDatLai.TabIndex = 1;
            this.btnDatLai.Text = "↺  Đặt lại";
            this.btnDatLai.UseVisualStyleBackColor = false;
            this.btnDatLai.Click += new System.EventHandler(this.btnDatLai_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1488, 64);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(258, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.lblSubTitle.Location = new System.Drawing.Point(22, 38);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(387, 20);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Tìm kiếm, thêm mới và phân quyền tài khoản người dùng";
            // 
            // quanLyDichVu_DaiDuongXanhDataSet
            // 
            this.quanLyDichVu_DaiDuongXanhDataSet.DataSetName = "QuanLyDichVu_DaiDuongXanhDataSet";
            this.quanLyDichVu_DaiDuongXanhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taiKhoanBindingSource1
            // 
            this.taiKhoanBindingSource1.DataMember = "TaiKhoan";
            this.taiKhoanBindingSource1.DataSource = this.quanLyDichVu_DaiDuongXanhDataSet;
            // 
            // taiKhoanTableAdapter
            // 
            this.taiKhoanTableAdapter.ClearBeforeFill = true;
            // 
            // tENDANGNHAPDataGridViewTextBoxColumn
            // 
            this.tENDANGNHAPDataGridViewTextBoxColumn.DataPropertyName = "TENDANGNHAP";
            this.tENDANGNHAPDataGridViewTextBoxColumn.HeaderText = "TENDANGNHAP";
            this.tENDANGNHAPDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tENDANGNHAPDataGridViewTextBoxColumn.Name = "tENDANGNHAPDataGridViewTextBoxColumn";
            this.tENDANGNHAPDataGridViewTextBoxColumn.ReadOnly = true;
            this.tENDANGNHAPDataGridViewTextBoxColumn.Width = 125;
            // 
            // mATKHAUHASHDataGridViewTextBoxColumn
            // 
            this.mATKHAUHASHDataGridViewTextBoxColumn.DataPropertyName = "MATKHAU_HASH";
            this.mATKHAUHASHDataGridViewTextBoxColumn.HeaderText = "MATKHAU_HASH";
            this.mATKHAUHASHDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mATKHAUHASHDataGridViewTextBoxColumn.Name = "mATKHAUHASHDataGridViewTextBoxColumn";
            this.mATKHAUHASHDataGridViewTextBoxColumn.ReadOnly = true;
            this.mATKHAUHASHDataGridViewTextBoxColumn.Width = 125;
            // 
            // lOAITAIKHOANDataGridViewTextBoxColumn
            // 
            this.lOAITAIKHOANDataGridViewTextBoxColumn.DataPropertyName = "LOAITAIKHOAN";
            this.lOAITAIKHOANDataGridViewTextBoxColumn.HeaderText = "LOAITAIKHOAN";
            this.lOAITAIKHOANDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lOAITAIKHOANDataGridViewTextBoxColumn.Name = "lOAITAIKHOANDataGridViewTextBoxColumn";
            this.lOAITAIKHOANDataGridViewTextBoxColumn.ReadOnly = true;
            this.lOAITAIKHOANDataGridViewTextBoxColumn.Width = 125;
            // 
            // tRANGTHAIDataGridViewTextBoxColumn
            // 
            this.tRANGTHAIDataGridViewTextBoxColumn.DataPropertyName = "TRANGTHAI";
            this.tRANGTHAIDataGridViewTextBoxColumn.HeaderText = "TRANGTHAI";
            this.tRANGTHAIDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tRANGTHAIDataGridViewTextBoxColumn.Name = "tRANGTHAIDataGridViewTextBoxColumn";
            this.tRANGTHAIDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRANGTHAIDataGridViewTextBoxColumn.Width = 125;
            // 
            // mAKHDataGridViewTextBoxColumn
            // 
            this.mAKHDataGridViewTextBoxColumn.DataPropertyName = "MAKH";
            this.mAKHDataGridViewTextBoxColumn.HeaderText = "MAKH";
            this.mAKHDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mAKHDataGridViewTextBoxColumn.Name = "mAKHDataGridViewTextBoxColumn";
            this.mAKHDataGridViewTextBoxColumn.ReadOnly = true;
            this.mAKHDataGridViewTextBoxColumn.Width = 125;
            // 
            // mANVDataGridViewTextBoxColumn
            // 
            this.mANVDataGridViewTextBoxColumn.DataPropertyName = "MANV";
            this.mANVDataGridViewTextBoxColumn.HeaderText = "MANV";
            this.mANVDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mANVDataGridViewTextBoxColumn.Name = "mANVDataGridViewTextBoxColumn";
            this.mANVDataGridViewTextBoxColumn.ReadOnly = true;
            this.mANVDataGridViewTextBoxColumn.Width = 125;
            // 
            // taiKhoanBindingSource
            // 
            this.taiKhoanBindingSource.DataMember = "TaiKhoan";
            // 
            // FrmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1488, 760);
            this.Controls.Add(this.pnlRoot);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 680);
            this.Name = "FrmTaiKhoan";
            this.Text = "Quản lý Tài khoản";
            this.Load += new System.EventHandler(this.FrmTaiKhoan_Load);
            this.pnlRoot.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKetQua)).EndInit();
            this.pnlGridTop.ResumeLayout(false);
            this.pnlGridTop.PerformLayout();
            this.pnlGridBtns.ResumeLayout(false);
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            this.pnlEditCard.ResumeLayout(false);
            this.pnlEditCard.PerformLayout();
            this.pnlNhanVienChon.ResumeLayout(false);
            this.pnlEditBtns.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilterCard.ResumeLayout(false);
            this.pnlFilterCard.PerformLayout();
            this.pnlFilterBtns.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyDichVu_DaiDuongXanhDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        // ── Field declarations ──────────────────────────────────────────
        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel pnlBody;

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlFilterCard;
        private System.Windows.Forms.CheckBox chkTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.CheckBox chkLoaiTK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboLoaiTK;
        private System.Windows.Forms.Panel pnlFilterBtns;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnDatLai;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlGridTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlGridBtns;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView gridKetQua;

        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlEditCard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        // Panel NV chọn
        private System.Windows.Forms.Panel pnlNhanVienChon;
        private System.Windows.Forms.Label lblNVChon;
        private System.Windows.Forms.Label lblMatKhauRo;
        //
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTrangThaiEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVaiTroEdit;
        private System.Windows.Forms.Label lblPhanQuyen;
        private System.Windows.Forms.Panel pnlEditBtns;
        private System.Windows.Forms.Button btnLuuThongTin;
        private System.Windows.Forms.Button btnHuyBo;

        // Legacy dataset fields
        private _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSet quanLyDichVu_DaiDuongXanhDataSet;
        private System.Windows.Forms.BindingSource taiKhoanBindingSource;
        private System.Windows.Forms.BindingSource taiKhoanBindingSource1;
        private _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSetTableAdapters.TaiKhoanTableAdapter taiKhoanTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tENDANGNHAPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATKHAUHASHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOAITAIKHOANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRANGTHAIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAKHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mANVDataGridViewTextBoxColumn;
    }
}