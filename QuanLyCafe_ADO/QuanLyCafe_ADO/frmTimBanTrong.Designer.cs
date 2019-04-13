namespace QuanLyCafe_ADO
{
    partial class frmTimBanTrong
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
            this.dtgvBanTrong = new System.Windows.Forms.DataGridView();
            this.MaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBanTrong)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvBanTrong
            // 
            this.dtgvBanTrong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvBanTrong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBanTrong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaBan,
            this.TenBan,
            this.SoGhe});
            this.dtgvBanTrong.Location = new System.Drawing.Point(13, 12);
            this.dtgvBanTrong.Name = "dtgvBanTrong";
            this.dtgvBanTrong.Size = new System.Drawing.Size(441, 240);
            this.dtgvBanTrong.TabIndex = 1;
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
            // frmTimBanTrong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 264);
            this.Controls.Add(this.dtgvBanTrong);
            this.Name = "frmTimBanTrong";
            this.Text = "Bàn trống";
            this.Load += new System.EventHandler(this.frmTimBanTrong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBanTrong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvBanTrong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGhe;
    }
}