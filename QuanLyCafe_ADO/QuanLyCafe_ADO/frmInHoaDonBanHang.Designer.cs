namespace QuanLyCafe_ADO
{
    partial class frmInHoaDonBanHang
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.HoaDonBanHangBEANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonBanHangBEANBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // HoaDonBanHangBEANBindingSource
            // 
            this.HoaDonBanHangBEANBindingSource.DataSource = typeof(QuanLyCafe_ADO.bean.HoaDonBanHangBEAN);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.HoaDonBanHangBEANBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyCafe_ADO.Report7.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(466, 351);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmInHoaDonBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 375);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInHoaDonBanHang";
            this.Text = "In hóa đơn bán hàng";
            this.Load += new System.EventHandler(this.frmInHoaDonBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonBanHangBEANBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource HoaDonBanHangBEANBindingSource;
    }
}