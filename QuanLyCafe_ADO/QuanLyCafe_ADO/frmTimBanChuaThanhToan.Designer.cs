namespace QuanLyCafe_ADO
{
    partial class frmTimBanChuaThanhToan
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
            this.dtgvBanChuaThanhToan = new System.Windows.Forms.DataGridView();
            this.MaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaTraTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBanChuaThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvBanChuaThanhToan
            // 
            this.dtgvBanChuaThanhToan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvBanChuaThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBanChuaThanhToan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaBan,
            this.TenBan,
            this.SoGhe,
            this.DaTraTien});
            this.dtgvBanChuaThanhToan.Location = new System.Drawing.Point(12, 12);
            this.dtgvBanChuaThanhToan.Name = "dtgvBanChuaThanhToan";
            this.dtgvBanChuaThanhToan.Size = new System.Drawing.Size(441, 240);
            this.dtgvBanChuaThanhToan.TabIndex = 0;
            // 
            // MaBan
            // 
            this.MaBan.DataPropertyName = "MaBan";
            this.MaBan.HeaderText = "Mã bàn";
            this.MaBan.Name = "MaBan";
            // 
            // TenBan
            // 
            this.TenBan.DataPropertyName = "TenBan";
            this.TenBan.HeaderText = "Tên bàn";
            this.TenBan.Name = "TenBan";
            // 
            // SoGhe
            // 
            this.SoGhe.DataPropertyName = "SoGhe";
            this.SoGhe.HeaderText = "Số ghế";
            this.SoGhe.Name = "SoGhe";
            // 
            // DaTraTien
            // 
            this.DaTraTien.DataPropertyName = "DaTraTien";
            this.DaTraTien.HeaderText = "Đã trả tiền";
            this.DaTraTien.Name = "DaTraTien";
            // 
            // frmTimBanChuaThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 264);
            this.Controls.Add(this.dtgvBanChuaThanhToan);
            this.Name = "frmTimBanChuaThanhToan";
            this.Text = "Bàn chưa thanh toán";
            this.Load += new System.EventHandler(this.frmTimBanChuaThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBanChuaThanhToan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvBanChuaThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaTraTien;
    }
}