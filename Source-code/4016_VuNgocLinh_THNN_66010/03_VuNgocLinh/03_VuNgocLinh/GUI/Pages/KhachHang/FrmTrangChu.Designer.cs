namespace _03_VuNgocLinh.GUI.Pages.KhachHang
{
    partial class FrmTrangChu
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlProductList = new System.Windows.Forms.Panel();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.pnlProductDetail = new System.Windows.Forms.Panel();
            this.pnlBookingForm = new System.Windows.Forms.Panel();
            this.btnMuaNgay = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChuLabel = new System.Windows.Forms.Label();
            this.cbPTTT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDiemDen = new System.Windows.Forms.TextBox();
            this.lblDiemDenLabel = new System.Windows.Forms.Label();
            this.txtDiemDi = new System.Windows.Forms.TextBox();
            this.lblDiemDiLabel = new System.Windows.Forms.Label();
            this.dtpNgayThucHien = new System.Windows.Forms.DateTimePicker();
            this.lblNgayTH = new System.Windows.Forms.Label();
            this.lblBookingHeader = new System.Windows.Forms.Label();
            this.pnlSvcInfo = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTrangthai = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblNhom = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTenDV = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtGiaDen = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGiaTu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboNhom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTenDV = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.pnlProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.pnlProductDetail.SuspendLayout();
            this.pnlBookingForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.pnlSvcInfo.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlProductList);
            this.panel2.Controls.Add(this.pnlProductDetail);
            this.panel2.Controls.Add(this.pnlSearch);
            this.panel2.Controls.Add(this.pnlHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1126, 771);
            this.panel2.TabIndex = 0;
            // 
            // pnlProductList
            // 
            this.pnlProductList.BackColor = System.Drawing.Color.White;
            this.pnlProductList.Controls.Add(this.dgvKetQua);
            this.pnlProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductList.Location = new System.Drawing.Point(0, 126);
            this.pnlProductList.Name = "pnlProductList";
            this.pnlProductList.Size = new System.Drawing.Size(736, 645);
            this.pnlProductList.TabIndex = 3;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.AllowUserToResizeRows = false;
            this.dgvKetQua.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvKetQua.ColumnHeadersHeight = 36;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(0, 0);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersVisible = false;
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.RowTemplate.Height = 34;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(736, 645);
            this.dgvKetQua.TabIndex = 0;
            this.dgvKetQua.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQua_CellContentClick);
            // 
            // pnlProductDetail
            // 
            this.pnlProductDetail.BackColor = System.Drawing.Color.White;
            this.pnlProductDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProductDetail.Controls.Add(this.pnlBookingForm);
            this.pnlProductDetail.Controls.Add(this.pnlSvcInfo);
            this.pnlProductDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlProductDetail.Location = new System.Drawing.Point(736, 126);
            this.pnlProductDetail.Name = "pnlProductDetail";
            this.pnlProductDetail.Size = new System.Drawing.Size(390, 645);
            this.pnlProductDetail.TabIndex = 2;
            // 
            // pnlBookingForm
            // 
            this.pnlBookingForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.pnlBookingForm.Controls.Add(this.btnMuaNgay);
            this.pnlBookingForm.Controls.Add(this.txtGhiChu);
            this.pnlBookingForm.Controls.Add(this.lblGhiChuLabel);
            this.pnlBookingForm.Controls.Add(this.cbPTTT);
            this.pnlBookingForm.Controls.Add(this.label1);
            this.pnlBookingForm.Controls.Add(this.nudSoLuong);
            this.pnlBookingForm.Controls.Add(this.label10);
            this.pnlBookingForm.Controls.Add(this.txtDiemDen);
            this.pnlBookingForm.Controls.Add(this.lblDiemDenLabel);
            this.pnlBookingForm.Controls.Add(this.txtDiemDi);
            this.pnlBookingForm.Controls.Add(this.lblDiemDiLabel);
            this.pnlBookingForm.Controls.Add(this.dtpNgayThucHien);
            this.pnlBookingForm.Controls.Add(this.lblNgayTH);
            this.pnlBookingForm.Controls.Add(this.lblBookingHeader);
            this.pnlBookingForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBookingForm.Location = new System.Drawing.Point(0, 282);
            this.pnlBookingForm.Name = "pnlBookingForm";
            this.pnlBookingForm.Size = new System.Drawing.Size(388, 361);
            this.pnlBookingForm.TabIndex = 1;
            // 
            // btnMuaNgay
            // 
            this.btnMuaNgay.FlatAppearance.BorderSize = 0;
            this.btnMuaNgay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuaNgay.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMuaNgay.Location = new System.Drawing.Point(12, 318);
            this.btnMuaNgay.Name = "btnMuaNgay";
            this.btnMuaNgay.Size = new System.Drawing.Size(364, 40);
            this.btnMuaNgay.TabIndex = 16;
            this.btnMuaNgay.Text = "🚢  ĐẶT DỊCH VỤ NGAY";
            this.btnMuaNgay.UseVisualStyleBackColor = false;
            this.btnMuaNgay.Click += new System.EventHandler(this.btnMuaNgay_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGhiChu.Location = new System.Drawing.Point(12, 264);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(364, 48);
            this.txtGhiChu.TabIndex = 15;
            this.txtGhiChu.Text = "Hàng dễ vỡ / Hàng nguy hiểm / Yêu cầu khác...";
            // 
            // lblGhiChuLabel
            // 
            this.lblGhiChuLabel.AutoSize = true;
            this.lblGhiChuLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGhiChuLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.lblGhiChuLabel.Location = new System.Drawing.Point(12, 248);
            this.lblGhiChuLabel.Name = "lblGhiChuLabel";
            this.lblGhiChuLabel.Size = new System.Drawing.Size(238, 20);
            this.lblGhiChuLabel.TabIndex = 17;
            this.lblGhiChuLabel.Text = "Ghi chú (loại hàng, yêu cầu thêm...)";
            // 
            // cbPTTT
            // 
            this.cbPTTT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbPTTT.FormattingEnabled = true;
            this.cbPTTT.Location = new System.Drawing.Point(196, 213);
            this.cbPTTT.Name = "cbPTTT";
            this.cbPTTT.Size = new System.Drawing.Size(180, 31);
            this.cbPTTT.TabIndex = 14;
            this.cbPTTT.SelectedIndexChanged += new System.EventHandler(this.cbPTTT_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(12, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Thanh toán";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudSoLuong.Location = new System.Drawing.Point(196, 183);
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(180, 30);
            this.nudSoLuong.TabIndex = 13;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.ValueChanged += new System.EventHandler(this.nudSoLuong_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.label10.Location = new System.Drawing.Point(12, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Số lượng *";
            // 
            // txtDiemDen
            // 
            this.txtDiemDen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiemDen.Location = new System.Drawing.Point(12, 152);
            this.txtDiemDen.Name = "txtDiemDen";
            this.txtDiemDen.Size = new System.Drawing.Size(364, 30);
            this.txtDiemDen.TabIndex = 12;
            this.txtDiemDen.Text = "VD: Port of Singapore";
            // 
            // lblDiemDenLabel
            // 
            this.lblDiemDenLabel.AutoSize = true;
            this.lblDiemDenLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiemDenLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.lblDiemDenLabel.Location = new System.Drawing.Point(12, 136);
            this.lblDiemDenLabel.Name = "lblDiemDenLabel";
            this.lblDiemDenLabel.Size = new System.Drawing.Size(191, 20);
            this.lblDiemDenLabel.TabIndex = 20;
            this.lblDiemDenLabel.Text = "Điểm đến / Cảng dỡ hàng *";
            // 
            // txtDiemDi
            // 
            this.txtDiemDi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiemDi.Location = new System.Drawing.Point(12, 104);
            this.txtDiemDi.Name = "txtDiemDi";
            this.txtDiemDi.Size = new System.Drawing.Size(364, 30);
            this.txtDiemDi.TabIndex = 11;
            this.txtDiemDi.Text = "VD: Cảng Cát Lái, TP.HCM";
            // 
            // lblDiemDiLabel
            // 
            this.lblDiemDiLabel.AutoSize = true;
            this.lblDiemDiLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiemDiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.lblDiemDiLabel.Location = new System.Drawing.Point(12, 88);
            this.lblDiemDiLabel.Name = "lblDiemDiLabel";
            this.lblDiemDiLabel.Size = new System.Drawing.Size(189, 20);
            this.lblDiemDiLabel.TabIndex = 21;
            this.lblDiemDiLabel.Text = "Điểm đi / Cảng chất hàng *";
            // 
            // dtpNgayThucHien
            // 
            this.dtpNgayThucHien.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThucHien.Location = new System.Drawing.Point(12, 58);
            this.dtpNgayThucHien.Name = "dtpNgayThucHien";
            this.dtpNgayThucHien.Size = new System.Drawing.Size(364, 22);
            this.dtpNgayThucHien.TabIndex = 10;
            // 
            // lblNgayTH
            // 
            this.lblNgayTH.AutoSize = true;
            this.lblNgayTH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayTH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.lblNgayTH.Location = new System.Drawing.Point(12, 42);
            this.lblNgayTH.Name = "lblNgayTH";
            this.lblNgayTH.Size = new System.Drawing.Size(119, 20);
            this.lblNgayTH.TabIndex = 22;
            this.lblNgayTH.Text = "Ngày thực hiện *";
            // 
            // lblBookingHeader
            // 
            this.lblBookingHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblBookingHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBookingHeader.ForeColor = System.Drawing.Color.White;
            this.lblBookingHeader.Location = new System.Drawing.Point(0, 0);
            this.lblBookingHeader.Name = "lblBookingHeader";
            this.lblBookingHeader.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblBookingHeader.Size = new System.Drawing.Size(388, 36);
            this.lblBookingHeader.TabIndex = 23;
            this.lblBookingHeader.Text = "📋  THÔNG TIN ĐẶT DỊCH VỤ";
            this.lblBookingHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSvcInfo
            // 
            this.pnlSvcInfo.BackColor = System.Drawing.Color.White;
            this.pnlSvcInfo.Controls.Add(this.richTextBox1);
            this.pnlSvcInfo.Controls.Add(this.label14);
            this.pnlSvcInfo.Controls.Add(this.lblTrangthai);
            this.pnlSvcInfo.Controls.Add(this.label19);
            this.pnlSvcInfo.Controls.Add(this.lblGiaBan);
            this.pnlSvcInfo.Controls.Add(this.label4);
            this.pnlSvcInfo.Controls.Add(this.lblDonViTinh);
            this.pnlSvcInfo.Controls.Add(this.label17);
            this.pnlSvcInfo.Controls.Add(this.lblNhom);
            this.pnlSvcInfo.Controls.Add(this.label15);
            this.pnlSvcInfo.Controls.Add(this.lblTenDV);
            this.pnlSvcInfo.Controls.Add(this.label13);
            this.pnlSvcInfo.Controls.Add(this.label12);
            this.pnlSvcInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSvcInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlSvcInfo.Name = "pnlSvcInfo";
            this.pnlSvcInfo.Size = new System.Drawing.Size(388, 282);
            this.pnlSvcInfo.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.richTextBox1.Location = new System.Drawing.Point(12, 192);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(364, 78);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "← Chọn một dịch vụ để xem chi tiết";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label14.Location = new System.Drawing.Point(12, 175);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "Mô tả dịch vụ";
            // 
            // lblTrangthai
            // 
            this.lblTrangthai.AutoSize = true;
            this.lblTrangthai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTrangthai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblTrangthai.Location = new System.Drawing.Point(196, 144);
            this.lblTrangthai.Name = "lblTrangthai";
            this.lblTrangthai.Size = new System.Drawing.Size(27, 23);
            this.lblTrangthai.TabIndex = 2;
            this.lblTrangthai.Text = "—";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label19.Location = new System.Drawing.Point(196, 128);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 20);
            this.label19.TabIndex = 3;
            this.label19.Text = "Trạng thái";
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGiaBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblGiaBan.Location = new System.Drawing.Point(12, 144);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(35, 30);
            this.lblGiaBan.TabIndex = 4;
            this.lblGiaBan.Text = "—";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Giá bán";
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDonViTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblDonViTinh.Location = new System.Drawing.Point(196, 100);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(27, 23);
            this.lblDonViTinh.TabIndex = 6;
            this.lblDonViTinh.Text = "—";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label17.Location = new System.Drawing.Point(196, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 20);
            this.label17.TabIndex = 7;
            this.label17.Text = "Đơn vị tính";
            // 
            // lblNhom
            // 
            this.lblNhom.AutoSize = true;
            this.lblNhom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.lblNhom.Location = new System.Drawing.Point(12, 100);
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Size = new System.Drawing.Size(27, 23);
            this.lblNhom.TabIndex = 8;
            this.lblNhom.Text = "—";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label15.Location = new System.Drawing.Point(12, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 20);
            this.label15.TabIndex = 9;
            this.label15.Text = "Nhóm dịch vụ";
            // 
            // lblTenDV
            // 
            this.lblTenDV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTenDV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.lblTenDV.Location = new System.Drawing.Point(12, 56);
            this.lblTenDV.Name = "lblTenDV";
            this.lblTenDV.Size = new System.Drawing.Size(364, 24);
            this.lblTenDV.TabIndex = 10;
            this.lblTenDV.Text = "—";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label13.Location = new System.Drawing.Point(12, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 20);
            this.label13.TabIndex = 11;
            this.label13.Text = "Tên dịch vụ";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label12.Size = new System.Drawing.Size(388, 36);
            this.label12.TabIndex = 0;
            this.label12.Text = "CHI TIẾT DỊCH VỤ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Controls.Add(this.btnReset);
            this.pnlSearch.Controls.Add(this.btnTimKiem);
            this.pnlSearch.Controls.Add(this.txtGiaDen);
            this.pnlSearch.Controls.Add(this.label8);
            this.pnlSearch.Controls.Add(this.txtGiaTu);
            this.pnlSearch.Controls.Add(this.label6);
            this.pnlSearch.Controls.Add(this.cboNhom);
            this.pnlSearch.Controls.Add(this.label3);
            this.pnlSearch.Controls.Add(this.cbTenDV);
            this.pnlSearch.Controls.Add(this.label7);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 50);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlSearch.Size = new System.Drawing.Size(1126, 76);
            this.pnlSearch.TabIndex = 1;
            this.pnlSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSearch_Paint);
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnReset.Location = new System.Drawing.Point(940, 20);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 32);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Đặt lại";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Location = new System.Drawing.Point(826, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 32);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "🔍  Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtGiaDen
            // 
            this.txtGiaDen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiaDen.Location = new System.Drawing.Point(722, 22);
            this.txtGiaDen.Name = "txtGiaDen";
            this.txtGiaDen.Size = new System.Drawing.Size(90, 30);
            this.txtGiaDen.TabIndex = 3;
            this.txtGiaDen.TextChanged += new System.EventHandler(this.txtGiaDen_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label8.Location = new System.Drawing.Point(692, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "đến";
            // 
            // txtGiaTu
            // 
            this.txtGiaTu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiaTu.Location = new System.Drawing.Point(596, 22);
            this.txtGiaTu.Name = "txtGiaTu";
            this.txtGiaTu.Size = new System.Drawing.Size(90, 30);
            this.txtGiaTu.TabIndex = 2;
            this.txtGiaTu.TextChanged += new System.EventHandler(this.txtGiaTu_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label6.Location = new System.Drawing.Point(542, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "Giá từ:";
            // 
            // cboNhom
            // 
            this.cboNhom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhom.FormattingEnabled = true;
            this.cboNhom.Location = new System.Drawing.Point(355, 22);
            this.cboNhom.Name = "cboNhom";
            this.cboNhom.Size = new System.Drawing.Size(175, 31);
            this.cboNhom.TabIndex = 1;
            this.cboNhom.SelectedIndexChanged += new System.EventHandler(this.cboNhom_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label3.Location = new System.Drawing.Point(282, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nhóm DV:";
            // 
            // cbTenDV
            // 
            this.cbTenDV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTenDV.FormattingEnabled = true;
            this.cbTenDV.Location = new System.Drawing.Point(78, 22);
            this.cbTenDV.Name = "cbTenDV";
            this.cbTenDV.Size = new System.Drawing.Size(195, 31);
            this.cbTenDV.TabIndex = 0;
            this.cbTenDV.SelectedIndexChanged += new System.EventHandler(this.cbTenDV_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label7.Location = new System.Drawing.Point(12, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "Dịch vụ:";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(120)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1126, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(12, 9);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(600, 32);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "🚢  ĐẶT DỊCH VỤ VẬN CHUYỂN";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1126, 771);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Name = "FrmTrangChu";
            this.Text = "Trang chủ – Đặt dịch vụ";
            this.Load += new System.EventHandler(this.FrmTrangChu_Load);
            this.panel2.ResumeLayout(false);
            this.pnlProductList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.pnlProductDetail.ResumeLayout(false);
            this.pnlBookingForm.ResumeLayout(false);
            this.pnlBookingForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.pnlSvcInfo.ResumeLayout(false);
            this.pnlSvcInfo.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtGiaDen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGiaTu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboNhom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTenDV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlProductDetail;
        private System.Windows.Forms.Panel pnlSvcInfo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTrangthai;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblNhom;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTenDV;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlBookingForm;
        private System.Windows.Forms.Label lblBookingHeader;
        private System.Windows.Forms.Label lblNgayTH;
        private System.Windows.Forms.DateTimePicker dtpNgayThucHien;
        private System.Windows.Forms.Label lblDiemDiLabel;
        private System.Windows.Forms.TextBox txtDiemDi;
        private System.Windows.Forms.Label lblDiemDenLabel;
        private System.Windows.Forms.TextBox txtDiemDen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPTTT;
        private System.Windows.Forms.Label lblGhiChuLabel;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnMuaNgay;
        private System.Windows.Forms.Panel pnlProductList;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}