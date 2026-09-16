namespace _03_VuNgocLinh.GUI.Pages.Owner
{
    partial class FrmDanhMuc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nhomDichVuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyDichVu_DaiDuongXanhDataSet2 = new _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSet2();
            this.nhomDichVuTableAdapter = new _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSet2TableAdapters.NhomDichVuTableAdapter();
            this.mANHOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tENNHOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mOTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRANGTHAIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeftBody = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbNhomDichVu = new System.Windows.Forms.ComboBox();
            this.lbLoai = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lbTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.pnlSepLine = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnDatLai = new System.Windows.Forms.Button();
            this.pnlSepLine2 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.pnlLeftHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.gridThongKe = new System.Windows.Forms.DataGridView();
            this.pnlRightToolbar = new System.Windows.Forms.Panel();
            this.lblTongDV = new System.Windows.Forms.Label();
            this.lblTongNhom = new System.Windows.Forms.Label();
            this.btnTaoBaoCao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nhomDichVuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyDichVu_DaiDuongXanhDataSet2)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftBody.SuspendLayout();
            this.pnlLeftHeader.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridThongKe)).BeginInit();
            this.pnlRightToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // nhomDichVuBindingSource
            // 
            this.nhomDichVuBindingSource.DataMember = "NhomDichVu";
            this.nhomDichVuBindingSource.DataSource = this.quanLyDichVu_DaiDuongXanhDataSet2;
            // 
            // quanLyDichVu_DaiDuongXanhDataSet2
            // 
            this.quanLyDichVu_DaiDuongXanhDataSet2.DataSetName = "QuanLyDichVu_DaiDuongXanhDataSet2";
            this.quanLyDichVu_DaiDuongXanhDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nhomDichVuTableAdapter
            // 
            this.nhomDichVuTableAdapter.ClearBeforeFill = true;
            // 
            // mANHOMDataGridViewTextBoxColumn
            // 
            this.mANHOMDataGridViewTextBoxColumn.DataPropertyName = "MANHOM";
            this.mANHOMDataGridViewTextBoxColumn.HeaderText = "MANHOM";
            this.mANHOMDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mANHOMDataGridViewTextBoxColumn.Name = "mANHOMDataGridViewTextBoxColumn";
            this.mANHOMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tENNHOMDataGridViewTextBoxColumn
            // 
            this.tENNHOMDataGridViewTextBoxColumn.DataPropertyName = "TENNHOM";
            this.tENNHOMDataGridViewTextBoxColumn.HeaderText = "TENNHOM";
            this.tENNHOMDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tENNHOMDataGridViewTextBoxColumn.Name = "tENNHOMDataGridViewTextBoxColumn";
            this.tENNHOMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mOTADataGridViewTextBoxColumn
            // 
            this.mOTADataGridViewTextBoxColumn.DataPropertyName = "MOTA";
            this.mOTADataGridViewTextBoxColumn.HeaderText = "MOTA";
            this.mOTADataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mOTADataGridViewTextBoxColumn.Name = "mOTADataGridViewTextBoxColumn";
            this.mOTADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tRANGTHAIDataGridViewTextBoxColumn
            // 
            this.tRANGTHAIDataGridViewTextBoxColumn.DataPropertyName = "TRANGTHAI";
            this.tRANGTHAIDataGridViewTextBoxColumn.HeaderText = "TRANGTHAI";
            this.tRANGTHAIDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tRANGTHAIDataGridViewTextBoxColumn.Name = "tRANGTHAIDataGridViewTextBoxColumn";
            this.tRANGTHAIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.pnlLeftBody);
            this.pnlLeft.Controls.Add(this.pnlLeftHeader);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(420, 651);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlLeftBody
            // 
            this.pnlLeftBody.BackColor = System.Drawing.Color.White;
            this.pnlLeftBody.Controls.Add(this.label2);
            this.pnlLeftBody.Controls.Add(this.cbbNhomDichVu);
            this.pnlLeftBody.Controls.Add(this.lbLoai);
            this.pnlLeftBody.Controls.Add(this.txtMoTa);
            this.pnlLeftBody.Controls.Add(this.lbTrangThai);
            this.pnlLeftBody.Controls.Add(this.txtTrangThai);
            this.pnlLeftBody.Controls.Add(this.pnlSepLine);
            this.pnlLeftBody.Controls.Add(this.btnTimKiem);
            this.pnlLeftBody.Controls.Add(this.btnDatLai);
            this.pnlLeftBody.Controls.Add(this.pnlSepLine2);
            this.pnlLeftBody.Controls.Add(this.btnThem);
            this.pnlLeftBody.Controls.Add(this.btnSua);
            this.pnlLeftBody.Controls.Add(this.btnXoa);
            this.pnlLeftBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftBody.Location = new System.Drawing.Point(0, 48);
            this.pnlLeftBody.Name = "pnlLeftBody";
            this.pnlLeftBody.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.pnlLeftBody.Size = new System.Drawing.Size(420, 603);
            this.pnlLeftBody.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label2.Location = new System.Drawing.Point(20, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên nhóm dịch vụ";
            // 
            // cbbNhomDichVu
            // 
            this.cbbNhomDichVu.BackColor = System.Drawing.Color.White;
            this.cbbNhomDichVu.DisplayMember = "TenLoaiSP";
            this.cbbNhomDichVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbNhomDichVu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbNhomDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.cbbNhomDichVu.FormattingEnabled = true;
            this.cbbNhomDichVu.Location = new System.Drawing.Point(20, 40);
            this.cbbNhomDichVu.Name = "cbbNhomDichVu";
            this.cbbNhomDichVu.Size = new System.Drawing.Size(360, 31);
            this.cbbNhomDichVu.TabIndex = 1;
            this.cbbNhomDichVu.ValueMember = "MaLoaiSP";
            this.cbbNhomDichVu.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiSP_SelectedIndexChanged);
            // 
            // lbLoai
            // 
            this.lbLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.lbLoai.Location = new System.Drawing.Point(20, 82);
            this.lbLoai.Name = "lbLoai";
            this.lbLoai.Size = new System.Drawing.Size(360, 20);
            this.lbLoai.TabIndex = 2;
            this.lbLoai.Text = "Từ khóa / Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.BackColor = System.Drawing.Color.White;
            this.txtMoTa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.txtMoTa.Location = new System.Drawing.Point(20, 106);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(360, 56);
            this.txtMoTa.TabIndex = 3;
            this.txtMoTa.TextChanged += new System.EventHandler(this.txtMoTa_TextChanged);
            // 
            // lbTrangThai
            // 
            this.lbTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.lbTrangThai.Location = new System.Drawing.Point(20, 176);
            this.lbTrangThai.Name = "lbTrangThai";
            this.lbTrangThai.Size = new System.Drawing.Size(360, 20);
            this.lbTrangThai.TabIndex = 4;
            this.lbTrangThai.Text = "Trạng thái";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.BackColor = System.Drawing.Color.White;
            this.txtTrangThai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.txtTrangThai.Location = new System.Drawing.Point(20, 200);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(360, 30);
            this.txtTrangThai.TabIndex = 5;
            this.txtTrangThai.TextChanged += new System.EventHandler(this.txtTrangThai_TextChanged);
            // 
            // pnlSepLine
            // 
            this.pnlSepLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.pnlSepLine.Location = new System.Drawing.Point(20, 244);
            this.pnlSepLine.Name = "pnlSepLine";
            this.pnlSepLine.Size = new System.Drawing.Size(360, 1);
            this.pnlSepLine.TabIndex = 6;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(20, 256);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(172, 36);
            this.btnTimKiem.TabIndex = 7;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnDatLai
            // 
            this.btnDatLai.BackColor = System.Drawing.Color.White;
            this.btnDatLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatLai.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.btnDatLai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnDatLai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.btnDatLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatLai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDatLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.btnDatLai.Location = new System.Drawing.Point(204, 256);
            this.btnDatLai.Name = "btnDatLai";
            this.btnDatLai.Size = new System.Drawing.Size(176, 36);
            this.btnDatLai.TabIndex = 8;
            this.btnDatLai.Text = "Đặt lại";
            this.btnDatLai.UseVisualStyleBackColor = false;
            this.btnDatLai.Click += new System.EventHandler(this.btnDatLai_Click);
            // 
            // pnlSepLine2
            // 
            this.pnlSepLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.pnlSepLine2.Location = new System.Drawing.Point(20, 306);
            this.pnlSepLine2.Name = "pnlSepLine2";
            this.pnlSepLine2.Size = new System.Drawing.Size(360, 1);
            this.pnlSepLine2.TabIndex = 9;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 320);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(360, 38);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnSua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(20, 368);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(360, 38);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa dòng đã chọn";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnXoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(20, 416);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(360, 38);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa dòng đã chọn";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // pnlLeftHeader
            // 
            this.pnlLeftHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.pnlLeftHeader.Controls.Add(this.label1);
            this.pnlLeftHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftHeader.Name = "pnlLeftHeader";
            this.pnlLeftHeader.Size = new System.Drawing.Size(420, 48);
            this.pnlLeftHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "  QUẢN LÝ DANH MỤC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.pnlRight.Controls.Add(this.gridThongKe);
            this.pnlRight.Controls.Add(this.pnlRightToolbar);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(420, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(879, 651);
            this.pnlRight.TabIndex = 1;
            // 
            // gridThongKe
            // 
            this.gridThongKe.AllowUserToAddRows = false;
            this.gridThongKe.AllowUserToDeleteRows = false;
            this.gridThongKe.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.gridThongKe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridThongKe.AutoGenerateColumns = false;
            this.gridThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridThongKe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.gridThongKe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridThongKe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridThongKe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridThongKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridThongKe.ColumnHeadersHeight = 38;
            this.gridThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mANHOMDataGridViewTextBoxColumn,
            this.tENNHOMDataGridViewTextBoxColumn,
            this.mOTADataGridViewTextBoxColumn,
            this.tRANGTHAIDataGridViewTextBoxColumn});
            this.gridThongKe.DataSource = this.nhomDichVuBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridThongKe.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridThongKe.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridThongKe.EnableHeadersVisualStyles = false;
            this.gridThongKe.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.gridThongKe.Location = new System.Drawing.Point(0, 48);
            this.gridThongKe.MultiSelect = false;
            this.gridThongKe.Name = "gridThongKe";
            this.gridThongKe.ReadOnly = true;
            this.gridThongKe.RowHeadersVisible = false;
            this.gridThongKe.RowHeadersWidth = 51;
            this.gridThongKe.RowTemplate.Height = 32;
            this.gridThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridThongKe.Size = new System.Drawing.Size(879, 603);
            this.gridThongKe.TabIndex = 1;
            this.gridThongKe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridThongKe_CellContentClick);
            // 
            // pnlRightToolbar
            // 
            this.pnlRightToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.pnlRightToolbar.Controls.Add(this.lblTongDV);
            this.pnlRightToolbar.Controls.Add(this.lblTongNhom);
            this.pnlRightToolbar.Controls.Add(this.btnTaoBaoCao);
            this.pnlRightToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRightToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlRightToolbar.Name = "pnlRightToolbar";
            this.pnlRightToolbar.Size = new System.Drawing.Size(879, 48);
            this.pnlRightToolbar.TabIndex = 0;
            // 
            // lblTongDV
            // 
            this.lblTongDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTongDV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongDV.ForeColor = System.Drawing.Color.White;
            this.lblTongDV.Location = new System.Drawing.Point(16, 14);
            this.lblTongDV.Name = "lblTongDV";
            this.lblTongDV.Size = new System.Drawing.Size(278, 22);
            this.lblTongDV.TabIndex = 0;
            this.lblTongDV.Text = "Tổng dịch vụ: 0";
            this.lblTongDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTongDV.Click += new System.EventHandler(this.lblTongDV_Click);
            // 
            // lblTongNhom
            // 
            this.lblTongNhom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTongNhom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongNhom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.lblTongNhom.Location = new System.Drawing.Point(311, 14);
            this.lblTongNhom.Name = "lblTongNhom";
            this.lblTongNhom.Size = new System.Drawing.Size(270, 22);
            this.lblTongNhom.TabIndex = 1;
            this.lblTongNhom.Text = "Tổng nhóm dịch vụ:  0";
            this.lblTongNhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTongNhom.Click += new System.EventHandler(this.lblTongNhom_Click);
            // 
            // btnTaoBaoCao
            // 
            this.btnTaoBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnTaoBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoBaoCao.FlatAppearance.BorderSize = 0;
            this.btnTaoBaoCao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnTaoBaoCao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnTaoBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTaoBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnTaoBaoCao.Location = new System.Drawing.Point(1276, 8);
            this.btnTaoBaoCao.Name = "btnTaoBaoCao";
            this.btnTaoBaoCao.Size = new System.Drawing.Size(172, 32);
            this.btnTaoBaoCao.TabIndex = 2;
            this.btnTaoBaoCao.Text = "Xuất báo cáo PDF";
            this.btnTaoBaoCao.UseVisualStyleBackColor = false;
            this.btnTaoBaoCao.Click += new System.EventHandler(this.btnTaoBaoCao_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1299, 651);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FrmDanhMuc";
            this.Text = "FrmDanhMuc";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nhomDichVuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyDichVu_DaiDuongXanhDataSet2)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeftBody.ResumeLayout(false);
            this.pnlLeftBody.PerformLayout();
            this.pnlLeftHeader.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridThongKe)).EndInit();
            this.pnlRightToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // ── Dataset / BindingSource / TableAdapter
        private _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSet2 quanLyDichVu_DaiDuongXanhDataSet2;
        private System.Windows.Forms.BindingSource nhomDichVuBindingSource;
        private _03_VuNgocLinh.QuanLyDichVu_DaiDuongXanhDataSet2TableAdapters.NhomDichVuTableAdapter nhomDichVuTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mANHOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tENNHOMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOTADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRANGTHAIDataGridViewTextBoxColumn;

        // ── Layout panels
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlLeftHeader;
        private System.Windows.Forms.Panel pnlLeftBody;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlRightToolbar;
        private System.Windows.Forms.Panel pnlSepLine;
        private System.Windows.Forms.Panel pnlSepLine2;

        // ── Controls
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbNhomDichVu;
        private System.Windows.Forms.Label lbLoai;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lbTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnDatLai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblTongDV;
        private System.Windows.Forms.Label lblTongNhom;
        private System.Windows.Forms.Button btnTaoBaoCao;
        private System.Windows.Forms.DataGridView gridThongKe;

        // ── Removed panel2 / panel3 / panel6 — replaced by pnlLeft / pnlRight
        // old names kept as aliases via #pragma or just removed — .cs doesn't reference them directly
    }
}
