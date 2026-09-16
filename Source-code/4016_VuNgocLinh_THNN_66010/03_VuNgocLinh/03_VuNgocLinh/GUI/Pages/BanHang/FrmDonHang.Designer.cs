namespace _03_VuNgocLinh.GUI.Pages.BanHang
{
    partial class FrmDonHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlProductList = new System.Windows.Forms.Panel();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.pnlProductDetail = new System.Windows.Forms.Panel();
            this.pnlDetailBody = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTenDV = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblNhomDV = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.pnlDetailHeader = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblChoXacNhan = new System.Windows.Forms.Label();
            this.lblDaXacNhan = new System.Windows.Forms.Label();
            this.lblDangXuLy = new System.Windows.Forms.Label();
            this.lblDaHoanThanh = new System.Windows.Forms.Label();
            this.pnlSearchBody = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaDonHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayDat = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpNgayThucHien = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiemDi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiemDen = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXuatBaoCaoPDF = new System.Windows.Forms.Button();
            this.pnlSearchHeader = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.pnlProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.pnlProductDetail.SuspendLayout();
            this.pnlDetailBody.SuspendLayout();
            this.pnlDetailHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlSearchBody.SuspendLayout();
            this.pnlSearchHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.panel2.Controls.Add(this.pnlProductList);
            this.panel2.Controls.Add(this.pnlProductDetail);
            this.panel2.Controls.Add(this.pnlSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1303, 868);
            this.panel2.TabIndex = 9;
            // 
            // pnlProductList
            // 
            this.pnlProductList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.pnlProductList.Controls.Add(this.dgvKetQua);
            this.pnlProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductList.Location = new System.Drawing.Point(0, 242);
            this.pnlProductList.Name = "pnlProductList";
            this.pnlProductList.Size = new System.Drawing.Size(927, 626);
            this.pnlProductList.TabIndex = 12;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.dgvKetQua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.dgvKetQua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKetQua.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKetQua.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKetQua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKetQua.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.EnableHeadersVisualStyles = false;
            this.dgvKetQua.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.dgvKetQua.Location = new System.Drawing.Point(0, 0);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersVisible = false;
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.RowTemplate.Height = 32;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(927, 626);
            this.dgvKetQua.TabIndex = 66;
            // 
            // pnlProductDetail
            // 
            this.pnlProductDetail.BackColor = System.Drawing.Color.White;
            this.pnlProductDetail.Controls.Add(this.pnlDetailBody);
            this.pnlProductDetail.Controls.Add(this.pnlDetailHeader);
            this.pnlProductDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlProductDetail.Location = new System.Drawing.Point(927, 242);
            this.pnlProductDetail.Name = "pnlProductDetail";
            this.pnlProductDetail.Size = new System.Drawing.Size(376, 626);
            this.pnlProductDetail.TabIndex = 14;
            // 
            // pnlDetailBody
            // 
            this.pnlDetailBody.BackColor = System.Drawing.Color.White;
            this.pnlDetailBody.Controls.Add(this.label13);
            this.pnlDetailBody.Controls.Add(this.lblTenDV);
            this.pnlDetailBody.Controls.Add(this.label4);
            this.pnlDetailBody.Controls.Add(this.lblGiaBan);
            this.pnlDetailBody.Controls.Add(this.label17);
            this.pnlDetailBody.Controls.Add(this.lblGhiChu);
            this.pnlDetailBody.Controls.Add(this.label19);
            this.pnlDetailBody.Controls.Add(this.lblNhomDV);
            this.pnlDetailBody.Controls.Add(this.label14);
            this.pnlDetailBody.Controls.Add(this.richTextBox1);
            this.pnlDetailBody.Controls.Add(this.lblTongTien);
            this.pnlDetailBody.Controls.Add(this.btnThem);
            this.pnlDetailBody.Controls.Add(this.btnXoa);
            this.pnlDetailBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailBody.Location = new System.Drawing.Point(0, 38);
            this.pnlDetailBody.Name = "pnlDetailBody";
            this.pnlDetailBody.Size = new System.Drawing.Size(376, 588);
            this.pnlDetailBody.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label13.Location = new System.Drawing.Point(14, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 24);
            this.label13.TabIndex = 0;
            this.label13.Text = "Dịch vụ:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenDV
            // 
            this.lblTenDV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenDV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblTenDV.Location = new System.Drawing.Point(120, 14);
            this.lblTenDV.Name = "lblTenDV";
            this.lblTenDV.Size = new System.Drawing.Size(220, 24);
            this.lblTenDV.TabIndex = 1;
            this.lblTenDV.Text = "__";
            this.lblTenDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTenDV.Click += new System.EventHandler(this.lblTenDV_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label4.Location = new System.Drawing.Point(14, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giá bán:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGiaBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.lblGiaBan.Location = new System.Drawing.Point(120, 46);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(220, 24);
            this.lblGiaBan.TabIndex = 3;
            this.lblGiaBan.Text = "__";
            this.lblGiaBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGiaBan.Click += new System.EventHandler(this.lblGiaBan_Click);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label17.Location = new System.Drawing.Point(14, 78);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 24);
            this.label17.TabIndex = 4;
            this.label17.Text = "Ghi chú:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblGhiChu.Location = new System.Drawing.Point(120, 78);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(220, 24);
            this.lblGhiChu.TabIndex = 5;
            this.lblGhiChu.Text = "__";
            this.lblGhiChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGhiChu.Click += new System.EventHandler(this.lblGhiChu_Click);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label19.Location = new System.Drawing.Point(14, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 24);
            this.label19.TabIndex = 6;
            this.label19.Text = "Nhóm dịch vụ:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNhomDV
            // 
            this.lblNhomDV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhomDV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblNhomDV.Location = new System.Drawing.Point(120, 110);
            this.lblNhomDV.Name = "lblNhomDV";
            this.lblNhomDV.Size = new System.Drawing.Size(220, 24);
            this.lblNhomDV.TabIndex = 7;
            this.lblNhomDV.Text = "__";
            this.lblNhomDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNhomDV.Click += new System.EventHandler(this.lblNhomDV_Click);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label14.Location = new System.Drawing.Point(14, 144);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 22);
            this.label14.TabIndex = 8;
            this.label14.Text = "Mô tả:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.richTextBox1.Location = new System.Drawing.Point(14, 170);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(336, 110);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.lblTongTien.Location = new System.Drawing.Point(14, 292);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(336, 30);
            this.lblTongTien.TabIndex = 10;
            this.lblTongTien.Text = "Tổng tiền:   0 đ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTongTien.Click += new System.EventHandler(this.lblTongTien_Click);
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
            this.btnThem.Location = new System.Drawing.Point(14, 334);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(160, 34);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
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
            this.btnXoa.Location = new System.Drawing.Point(184, 334);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(160, 34);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Hủy đơn";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // pnlDetailHeader
            // 
            this.pnlDetailHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.pnlDetailHeader.Controls.Add(this.label12);
            this.pnlDetailHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailHeader.Name = "pnlDetailHeader";
            this.pnlDetailHeader.Size = new System.Drawing.Size(376, 38);
            this.pnlDetailHeader.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(376, 38);
            this.label12.TabIndex = 0;
            this.label12.Text = "  Chi tiết dịch vụ chọn";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.pnlSearch.Controls.Add(this.pnlStatus);
            this.pnlSearch.Controls.Add(this.pnlSearchBody);
            this.pnlSearch.Controls.Add(this.pnlSearchHeader);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1303, 242);
            this.pnlSearch.TabIndex = 10;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.pnlStatus.Controls.Add(this.label5);
            this.pnlStatus.Controls.Add(this.lblChoXacNhan);
            this.pnlStatus.Controls.Add(this.lblDaXacNhan);
            this.pnlStatus.Controls.Add(this.lblDangXuLy);
            this.pnlStatus.Controls.Add(this.lblDaHoanThanh);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(0, 206);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1303, 36);
            this.pnlStatus.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(12, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kết quả tìm kiếm:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChoXacNhan
            // 
            this.lblChoXacNhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChoXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(127)))), ((int)(((byte)(23)))));
            this.lblChoXacNhan.Location = new System.Drawing.Point(180, 8);
            this.lblChoXacNhan.Name = "lblChoXacNhan";
            this.lblChoXacNhan.Size = new System.Drawing.Size(190, 20);
            this.lblChoXacNhan.TabIndex = 1;
            this.lblChoXacNhan.Text = "Chờ xác nhận: 0";
            this.lblChoXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChoXacNhan.Click += new System.EventHandler(this.lblChoXacNhan_Click);
            // 
            // lblDaXacNhan
            // 
            this.lblDaXacNhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDaXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblDaXacNhan.Location = new System.Drawing.Point(378, 8);
            this.lblDaXacNhan.Name = "lblDaXacNhan";
            this.lblDaXacNhan.Size = new System.Drawing.Size(190, 20);
            this.lblDaXacNhan.TabIndex = 2;
            this.lblDaXacNhan.Text = "Đã xác nhận: 0";
            this.lblDaXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDaXacNhan.Click += new System.EventHandler(this.lblDaXacNhan_Click);
            // 
            // lblDangXuLy
            // 
            this.lblDangXuLy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDangXuLy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.lblDangXuLy.Location = new System.Drawing.Point(576, 8);
            this.lblDangXuLy.Name = "lblDangXuLy";
            this.lblDangXuLy.Size = new System.Drawing.Size(190, 20);
            this.lblDangXuLy.TabIndex = 3;
            this.lblDangXuLy.Text = "Đang xử lý: 0";
            this.lblDangXuLy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDangXuLy.Click += new System.EventHandler(this.lblDangXuLy_Click);
            // 
            // lblDaHoanThanh
            // 
            this.lblDaHoanThanh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDaHoanThanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblDaHoanThanh.Location = new System.Drawing.Point(774, 8);
            this.lblDaHoanThanh.Name = "lblDaHoanThanh";
            this.lblDaHoanThanh.Size = new System.Drawing.Size(210, 20);
            this.lblDaHoanThanh.TabIndex = 4;
            this.lblDaHoanThanh.Text = "Đã hoàn thành: 0";
            this.lblDaHoanThanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDaHoanThanh.Click += new System.EventHandler(this.lblDaHoanThanh_Click);
            // 
            // pnlSearchBody
            // 
            this.pnlSearchBody.BackColor = System.Drawing.Color.White;
            this.pnlSearchBody.Controls.Add(this.label7);
            this.pnlSearchBody.Controls.Add(this.txtMaDonHang);
            this.pnlSearchBody.Controls.Add(this.label3);
            this.pnlSearchBody.Controls.Add(this.dtpNgayDat);
            this.pnlSearchBody.Controls.Add(this.label11);
            this.pnlSearchBody.Controls.Add(this.dtpNgayThucHien);
            this.pnlSearchBody.Controls.Add(this.label16);
            this.pnlSearchBody.Controls.Add(this.cboKhachHang);
            this.pnlSearchBody.Controls.Add(this.label18);
            this.pnlSearchBody.Controls.Add(this.cboNhanVien);
            this.pnlSearchBody.Controls.Add(this.label20);
            this.pnlSearchBody.Controls.Add(this.cboTrangThai);
            this.pnlSearchBody.Controls.Add(this.label6);
            this.pnlSearchBody.Controls.Add(this.label8);
            this.pnlSearchBody.Controls.Add(this.txtDiemDi);
            this.pnlSearchBody.Controls.Add(this.label9);
            this.pnlSearchBody.Controls.Add(this.txtDiemDen);
            this.pnlSearchBody.Controls.Add(this.label21);
            this.pnlSearchBody.Controls.Add(this.txtGhiChu);
            this.pnlSearchBody.Controls.Add(this.btnTimKiem);
            this.pnlSearchBody.Controls.Add(this.btnReset);
            this.pnlSearchBody.Controls.Add(this.btnLuu);
            this.pnlSearchBody.Controls.Add(this.btnXuatBaoCaoPDF);
            this.pnlSearchBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchBody.Location = new System.Drawing.Point(0, 38);
            this.pnlSearchBody.Name = "pnlSearchBody";
            this.pnlSearchBody.Size = new System.Drawing.Size(1303, 168);
            this.pnlSearchBody.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label7.Location = new System.Drawing.Point(14, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 22);
            this.label7.TabIndex = 1;
            this.label7.Text = "Mã đơn hàng:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaDonHang
            // 
            this.txtMaDonHang.BackColor = System.Drawing.Color.White;
            this.txtMaDonHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaDonHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaDonHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.txtMaDonHang.Location = new System.Drawing.Point(138, 14);
            this.txtMaDonHang.Name = "txtMaDonHang";
            this.txtMaDonHang.Size = new System.Drawing.Size(180, 30);
            this.txtMaDonHang.TabIndex = 2;
            this.txtMaDonHang.TextChanged += new System.EventHandler(this.txtMaDonHang_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label3.Location = new System.Drawing.Point(338, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày đặt:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayDat
            // 
            this.dtpNgayDat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayDat.Location = new System.Drawing.Point(452, 14);
            this.dtpNgayDat.Name = "dtpNgayDat";
            this.dtpNgayDat.Size = new System.Drawing.Size(180, 30);
            this.dtpNgayDat.TabIndex = 4;
            this.dtpNgayDat.ValueChanged += new System.EventHandler(this.dtpNgayDat_ValueChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label11.Location = new System.Drawing.Point(652, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 22);
            this.label11.TabIndex = 5;
            this.label11.Text = "Ngày thực hiện:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayThucHien
            // 
            this.dtpNgayThucHien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayThucHien.Location = new System.Drawing.Point(786, 14);
            this.dtpNgayThucHien.Name = "dtpNgayThucHien";
            this.dtpNgayThucHien.Size = new System.Drawing.Size(180, 30);
            this.dtpNgayThucHien.TabIndex = 6;
            this.dtpNgayThucHien.ValueChanged += new System.EventHandler(this.dtpNgayThucHien_ValueChanged);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label16.Location = new System.Drawing.Point(14, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 22);
            this.label16.TabIndex = 7;
            this.label16.Text = "Khách hàng:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.BackColor = System.Drawing.Color.White;
            this.cboKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(138, 56);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(180, 31);
            this.cboKhachHang.TabIndex = 8;
            this.cboKhachHang.SelectedIndexChanged += new System.EventHandler(this.cboKhachHang_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label18.Location = new System.Drawing.Point(338, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(152, 22);
            this.label18.TabIndex = 9;
            this.label18.Text = "Nhân viên tiếp nhận:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.BackColor = System.Drawing.Color.White;
            this.cboNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(494, 56);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(180, 31);
            this.cboNhanVien.TabIndex = 10;
            this.cboNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboNhanVien_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label20.Location = new System.Drawing.Point(694, 60);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(90, 22);
            this.label20.TabIndex = 11;
            this.label20.Text = "Trạng thái:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.BackColor = System.Drawing.Color.White;
            this.cboTrangThai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(788, 56);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(178, 31);
            this.cboTrangThai.TabIndex = 12;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label6.Location = new System.Drawing.Point(14, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 22);
            this.label6.TabIndex = 13;
            this.label6.Text = "Địa điểm:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label8.Location = new System.Drawing.Point(96, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 22);
            this.label8.TabIndex = 14;
            this.label8.Text = "Đi:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiemDi
            // 
            this.txtDiemDi.BackColor = System.Drawing.Color.White;
            this.txtDiemDi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiemDi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiemDi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.txtDiemDi.Location = new System.Drawing.Point(126, 100);
            this.txtDiemDi.Name = "txtDiemDi";
            this.txtDiemDi.Size = new System.Drawing.Size(180, 30);
            this.txtDiemDi.TabIndex = 15;
            this.txtDiemDi.TextChanged += new System.EventHandler(this.txtDiemDi_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label9.Location = new System.Drawing.Point(312, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 22);
            this.label9.TabIndex = 16;
            this.label9.Text = "Đến:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiemDen
            // 
            this.txtDiemDen.BackColor = System.Drawing.Color.White;
            this.txtDiemDen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiemDen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiemDen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.txtDiemDen.Location = new System.Drawing.Point(352, 100);
            this.txtDiemDen.Name = "txtDiemDen";
            this.txtDiemDen.Size = new System.Drawing.Size(180, 30);
            this.txtDiemDen.TabIndex = 17;
            this.txtDiemDen.TextChanged += new System.EventHandler(this.txtDiemDen_TextChanged);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label21.Location = new System.Drawing.Point(552, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 22);
            this.label21.TabIndex = 18;
            this.label21.Text = "Ghi chú:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.Color.White;
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.txtGhiChu.Location = new System.Drawing.Point(630, 100);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(336, 30);
            this.txtGhiChu.TabIndex = 19;
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(1132, 14);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(148, 32);
            this.btnTimKiem.TabIndex = 20;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.btnReset.Location = new System.Drawing.Point(1132, 56);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(148, 32);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Đặt lại";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(1132, 100);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(148, 32);
            this.btnLuu.TabIndex = 22;
            this.btnLuu.Text = "Lưu thông tin";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXuatBaoCaoPDF
            // 
            this.btnXuatBaoCaoPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatBaoCaoPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXuatBaoCaoPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatBaoCaoPDF.FlatAppearance.BorderSize = 0;
            this.btnXuatBaoCaoPDF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnXuatBaoCaoPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnXuatBaoCaoPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatBaoCaoPDF.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnXuatBaoCaoPDF.ForeColor = System.Drawing.Color.White;
            this.btnXuatBaoCaoPDF.Location = new System.Drawing.Point(974, 100);
            this.btnXuatBaoCaoPDF.Name = "btnXuatBaoCaoPDF";
            this.btnXuatBaoCaoPDF.Size = new System.Drawing.Size(148, 32);
            this.btnXuatBaoCaoPDF.TabIndex = 23;
            this.btnXuatBaoCaoPDF.Text = "Xuất báo cáo PDF";
            this.btnXuatBaoCaoPDF.UseVisualStyleBackColor = false;
            this.btnXuatBaoCaoPDF.Click += new System.EventHandler(this.btnXuatBaoCaoPDF_Click);
            // 
            // pnlSearchHeader
            // 
            this.pnlSearchHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.pnlSearchHeader.Controls.Add(this.lblSearchTitle);
            this.pnlSearchHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchHeader.Name = "pnlSearchHeader";
            this.pnlSearchHeader.Size = new System.Drawing.Size(1303, 38);
            this.pnlSearchHeader.TabIndex = 0;
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.White;
            this.lblSearchTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(1303, 38);
            this.lblSearchTitle.TabIndex = 0;
            this.lblSearchTitle.Text = "  THÔNG TIN ĐƠN HÀNG";
            this.lblSearchTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 868);
            this.Controls.Add(this.panel2);
            this.Name = "FrmDonHang";
            this.Text = "FrmDonHang";
            this.Load += new System.EventHandler(this.FrmDonHang_Load);
            this.panel2.ResumeLayout(false);
            this.pnlProductList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.pnlProductDetail.ResumeLayout(false);
            this.pnlDetailBody.ResumeLayout(false);
            this.pnlDetailHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlSearchBody.ResumeLayout(false);
            this.pnlSearchBody.PerformLayout();
            this.pnlSearchHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlSearchHeader;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.Panel pnlSearchBody;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaDonHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayDat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpNgayThucHien;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiemDi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiemDen;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXuatBaoCaoPDF;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblChoXacNhan;
        private System.Windows.Forms.Label lblDaXacNhan;
        private System.Windows.Forms.Label lblDangXuLy;
        private System.Windows.Forms.Label lblDaHoanThanh;
        private System.Windows.Forms.Panel pnlProductList;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Panel pnlProductDetail;
        private System.Windows.Forms.Panel pnlDetailHeader;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlDetailBody;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTenDV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblNhomDV;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
    }
}
