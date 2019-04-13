namespace QuanLyCafe_ADO
{
    partial class frmChiTietHoaDon
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
            this.dtgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtMaChiTietHoaDon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MaChiTietHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvChiTietHoaDon
            // 
            this.dtgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvChiTietHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChiTietHoaDon,
            this.MaHang,
            this.SoLuongMua,
            this.ThanhTien,
            this.MaHoaDon});
            this.dtgvChiTietHoaDon.Location = new System.Drawing.Point(12, 52);
            this.dtgvChiTietHoaDon.Name = "dtgvChiTietHoaDon";
            this.dtgvChiTietHoaDon.Size = new System.Drawing.Size(535, 216);
            this.dtgvChiTietHoaDon.TabIndex = 7;
            this.dtgvChiTietHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvChiTietHoaDon_CellClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(393, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtMaChiTietHoaDon
            // 
            this.txtMaChiTietHoaDon.Enabled = false;
            this.txtMaChiTietHoaDon.Location = new System.Drawing.Point(193, 12);
            this.txtMaChiTietHoaDon.Name = "txtMaChiTietHoaDon";
            this.txtMaChiTietHoaDon.Size = new System.Drawing.Size(165, 20);
            this.txtMaChiTietHoaDon.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã chi tiết hóa đơn";
            // 
            // MaChiTietHoaDon
            // 
            this.MaChiTietHoaDon.DataPropertyName = "MaChiTietHoaDon";
            this.MaChiTietHoaDon.HeaderText = "Mã chi tiết hóa đơn";
            this.MaChiTietHoaDon.Name = "MaChiTietHoaDon";
            // 
            // MaHang
            // 
            this.MaHang.DataPropertyName = "MaHang";
            this.MaHang.HeaderText = "Mã hàng";
            this.MaHang.Name = "MaHang";
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
            // MaHoaDon
            // 
            this.MaHoaDon.DataPropertyName = "MaHoaDon";
            this.MaHoaDon.HeaderText = "Mã hóa đơn";
            this.MaHoaDon.Name = "MaHoaDon";
            // 
            // frmChiTietHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 279);
            this.Controls.Add(this.dtgvChiTietHoaDon);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtMaChiTietHoaDon);
            this.Controls.Add(this.label1);
            this.Name = "frmChiTietHoaDon";
            this.Text = "Chi tiết hóa đơn";
            this.Load += new System.EventHandler(this.frmChiTietHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvChiTietHoaDon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtMaChiTietHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiTietHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongMua;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDon;
    }
}