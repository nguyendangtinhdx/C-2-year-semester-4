namespace QuanLyCafe_ADO
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiTiếtHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bànChưaThanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bànTrốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoNgàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoThángToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoNămToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngKýTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbbChuyenBan = new System.Windows.Forms.ComboBox();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.dtgvBanHang = new System.Windows.Forms.DataGridView();
            this.TenHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaTraTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbBan = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.txtNgayBan = new System.Windows.Forms.TextBox();
            this.cbbTenHang = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoLuongMua = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoLuongTrongKho = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.btnBan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBanHang)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýToolStripMenuItem,
            this.tìmKiếmToolStripMenuItem,
            this.thốngKêToolStripMenuItem,
            this.đăngKýTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnBan,
            this.mnHang,
            this.mnNhanVien,
            this.hóaĐơnToolStripMenuItem,
            this.chiTiếtHóaĐơnToolStripMenuItem,
            this.mnThoat});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // mnBan
            // 
            this.mnBan.Name = "mnBan";
            this.mnBan.Size = new System.Drawing.Size(159, 22);
            this.mnBan.Text = "Bàn";
            this.mnBan.Click += new System.EventHandler(this.mnBan_Click);
            // 
            // mnHang
            // 
            this.mnHang.Name = "mnHang";
            this.mnHang.Size = new System.Drawing.Size(159, 22);
            this.mnHang.Text = "Hàng";
            this.mnHang.Click += new System.EventHandler(this.mnHang_Click);
            // 
            // mnNhanVien
            // 
            this.mnNhanVien.Name = "mnNhanVien";
            this.mnNhanVien.Size = new System.Drawing.Size(159, 22);
            this.mnNhanVien.Text = "Nhân viên";
            this.mnNhanVien.Click += new System.EventHandler(this.mnNhanVien_Click);
            // 
            // hóaĐơnToolStripMenuItem
            // 
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            this.hóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.hóaĐơnToolStripMenuItem.Text = "Hóa đơn";
            this.hóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnToolStripMenuItem_Click);
            // 
            // chiTiếtHóaĐơnToolStripMenuItem
            // 
            this.chiTiếtHóaĐơnToolStripMenuItem.Name = "chiTiếtHóaĐơnToolStripMenuItem";
            this.chiTiếtHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.chiTiếtHóaĐơnToolStripMenuItem.Text = "Chi tiết hóa đơn";
            this.chiTiếtHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.chiTiếtHóaĐơnToolStripMenuItem_Click);
            // 
            // mnThoat
            // 
            this.mnThoat.Name = "mnThoat";
            this.mnThoat.Size = new System.Drawing.Size(159, 22);
            this.mnThoat.Text = "Thoát";
            this.mnThoat.Click += new System.EventHandler(this.mnThoat_Click);
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bànChưaThanhToánToolStripMenuItem,
            this.bànTrốngToolStripMenuItem});
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm kiếm";
            // 
            // bànChưaThanhToánToolStripMenuItem
            // 
            this.bànChưaThanhToánToolStripMenuItem.Name = "bànChưaThanhToánToolStripMenuItem";
            this.bànChưaThanhToánToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.bànChưaThanhToánToolStripMenuItem.Text = "Bàn chưa thanh toán";
            this.bànChưaThanhToánToolStripMenuItem.Click += new System.EventHandler(this.bànChưaThanhToánToolStripMenuItem_Click);
            // 
            // bànTrốngToolStripMenuItem
            // 
            this.bànTrốngToolStripMenuItem.Name = "bànTrốngToolStripMenuItem";
            this.bànTrốngToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.bànTrốngToolStripMenuItem.Text = "Bàn trống";
            this.bànTrốngToolStripMenuItem.Click += new System.EventHandler(this.bànTrốngToolStripMenuItem_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theoNgàyToolStripMenuItem,
            this.theoThángToolStripMenuItem,
            this.theoNămToolStripMenuItem});
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // theoNgàyToolStripMenuItem
            // 
            this.theoNgàyToolStripMenuItem.Name = "theoNgàyToolStripMenuItem";
            this.theoNgàyToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.theoNgàyToolStripMenuItem.Text = "Theo ngày";
            this.theoNgàyToolStripMenuItem.Click += new System.EventHandler(this.theoNgàyToolStripMenuItem_Click);
            // 
            // theoThángToolStripMenuItem
            // 
            this.theoThángToolStripMenuItem.Name = "theoThángToolStripMenuItem";
            this.theoThángToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.theoThángToolStripMenuItem.Text = "Theo tháng";
            this.theoThángToolStripMenuItem.Click += new System.EventHandler(this.theoThángToolStripMenuItem_Click);
            // 
            // theoNămToolStripMenuItem
            // 
            this.theoNămToolStripMenuItem.Name = "theoNămToolStripMenuItem";
            this.theoNămToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.theoNămToolStripMenuItem.Text = "Theo năm";
            this.theoNămToolStripMenuItem.Click += new System.EventHandler(this.theoNămToolStripMenuItem_Click);
            // 
            // đăngKýTàiKhoảnToolStripMenuItem
            // 
            this.đăngKýTàiKhoảnToolStripMenuItem.Name = "đăngKýTàiKhoảnToolStripMenuItem";
            this.đăngKýTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.đăngKýTàiKhoảnToolStripMenuItem.Text = "Đăng ký tài khoản";
            this.đăngKýTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.đăngKýTàiKhoảnToolStripMenuItem_Click);
            // 
            // cbbChuyenBan
            // 
            this.cbbChuyenBan.FormattingEnabled = true;
            this.cbbChuyenBan.Location = new System.Drawing.Point(16, 429);
            this.cbbChuyenBan.Name = "cbbChuyenBan";
            this.cbbChuyenBan.Size = new System.Drawing.Size(101, 21);
            this.cbbChuyenBan.TabIndex = 25;
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(442, 432);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(0, 13);
            this.lbTongTien.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 432);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(262, 429);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(112, 20);
            this.txtTongTien.TabIndex = 28;
            this.txtTongTien.TextChanged += new System.EventHandler(this.txtTongTien_TextChanged);
            // 
            // dtgvBanHang
            // 
            this.dtgvBanHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBanHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenHang,
            this.Gia,
            this.SoLuongMua,
            this.ThanhTien,
            this.MaBan,
            this.DaTraTien});
            this.dtgvBanHang.Location = new System.Drawing.Point(208, 232);
            this.dtgvBanHang.Name = "dtgvBanHang";
            this.dtgvBanHang.Size = new System.Drawing.Size(461, 186);
            this.dtgvBanHang.TabIndex = 33;
            // 
            // TenHang
            // 
            this.TenHang.DataPropertyName = "TenHang";
            this.TenHang.HeaderText = "Tên hàng";
            this.TenHang.Name = "TenHang";
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "Gia";
            this.Gia.HeaderText = "Giá";
            this.Gia.Name = "Gia";
            // 
            // SoLuongMua
            // 
            this.SoLuongMua.DataPropertyName = "SoLuongMua";
            this.SoLuongMua.HeaderText = "Số lượng mua";
            this.SoLuongMua.Name = "SoLuongMua";
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.Name = "ThanhTien";
            // 
            // MaBan
            // 
            this.MaBan.DataPropertyName = "MaBan";
            this.MaBan.HeaderText = "Mã bàn";
            this.MaBan.Name = "MaBan";
            // 
            // DaTraTien
            // 
            this.DaTraTien.DataPropertyName = "DaTraTien";
            this.DaTraTien.HeaderText = "Đã trả tiền";
            this.DaTraTien.Name = "DaTraTien";
            // 
            // lbBan
            // 
            this.lbBan.FormattingEnabled = true;
            this.lbBan.Location = new System.Drawing.Point(16, 44);
            this.lbBan.Name = "lbBan";
            this.lbBan.Size = new System.Drawing.Size(185, 368);
            this.lbBan.TabIndex = 32;
            this.lbBan.SelectedIndexChanged += new System.EventHandler(this.lbBan_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Chọn 1 bàn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Danh sách các mặt hàng của bàn";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(358, 129);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(75, 23);
            this.btnThanhToan.TabIndex = 17;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // txtNgayBan
            // 
            this.txtNgayBan.Enabled = false;
            this.txtNgayBan.Location = new System.Drawing.Point(141, 125);
            this.txtNgayBan.Name = "txtNgayBan";
            this.txtNgayBan.Size = new System.Drawing.Size(181, 20);
            this.txtNgayBan.TabIndex = 4;
            // 
            // cbbTenHang
            // 
            this.cbbTenHang.FormattingEnabled = true;
            this.cbbTenHang.Location = new System.Drawing.Point(141, 21);
            this.cbbTenHang.Name = "cbbTenHang";
            this.cbbTenHang.Size = new System.Drawing.Size(181, 21);
            this.cbbTenHang.TabIndex = 0;
            this.cbbTenHang.SelectedIndexChanged += new System.EventHandler(this.cbbTenHang_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThanhToan);
            this.groupBox1.Controls.Add(this.txtNgayBan);
            this.groupBox1.Controls.Add(this.cbbTenHang);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNhanVien);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSoLuongMua);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSoLuongTrongKho);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGia);
            this.groupBox1.Controls.Add(this.btnBan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(207, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 186);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin bán hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Nhân viên";
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Enabled = false;
            this.txtNhanVien.Location = new System.Drawing.Point(141, 151);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(181, 20);
            this.txtNhanVien.TabIndex = 5;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(358, 79);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ngày bán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số lượng mua";
            // 
            // txtSoLuongMua
            // 
            this.txtSoLuongMua.Location = new System.Drawing.Point(141, 99);
            this.txtSoLuongMua.Name = "txtSoLuongMua";
            this.txtSoLuongMua.Size = new System.Drawing.Size(181, 20);
            this.txtSoLuongMua.TabIndex = 3;
            this.txtSoLuongMua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuongMua_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số lượng trong kho";
            // 
            // txtSoLuongTrongKho
            // 
            this.txtSoLuongTrongKho.Enabled = false;
            this.txtSoLuongTrongKho.Location = new System.Drawing.Point(141, 73);
            this.txtSoLuongTrongKho.Name = "txtSoLuongTrongKho";
            this.txtSoLuongTrongKho.Size = new System.Drawing.Size(181, 20);
            this.txtSoLuongTrongKho.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Giá";
            // 
            // txtGia
            // 
            this.txtGia.Enabled = false;
            this.txtGia.Location = new System.Drawing.Point(141, 47);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(181, 20);
            this.txtGia.TabIndex = 1;
            // 
            // btnBan
            // 
            this.btnBan.Location = new System.Drawing.Point(358, 27);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(75, 23);
            this.btnBan.TabIndex = 6;
            this.btnBan.Text = "Bán";
            this.btnBan.UseVisualStyleBackColor = true;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên hàng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(380, 432);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Bằng chữ:";
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.Location = new System.Drawing.Point(123, 427);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(75, 23);
            this.btnChuyenBan.TabIndex = 24;
            this.btnChuyenBan.Text = "Chuyển bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = true;
            this.btnChuyenBan.Click += new System.EventHandler(this.btnChuyenBan_Click);
            // 
            // frmMenu
            // 
            this.AcceptButton = this.btnBan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 464);
            this.Controls.Add(this.cbbChuyenBan);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.dtgvBanHang);
            this.Controls.Add(this.lbBan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnChuyenBan);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBanHang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnBan;
        private System.Windows.Forms.ToolStripMenuItem mnHang;
        private System.Windows.Forms.ToolStripMenuItem mnNhanVien;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bànChưaThanhToánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bànTrốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theoNgàyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theoThángToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theoNămToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngKýTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnThoat;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiTiếtHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbbChuyenBan;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.DataGridView dtgvBanHang;
        private System.Windows.Forms.ListBox lbBan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TextBox txtNgayBan;
        private System.Windows.Forms.ComboBox cbbTenHang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoLuongMua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoLuongTrongKho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Button btnBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongMua;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaTraTien;
    }
}