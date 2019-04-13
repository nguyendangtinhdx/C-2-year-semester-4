namespace QuanLyBanSach
{
    partial class FInHoaDon
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInHoaDon));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLyBanSachDataSet = new QuanLyBanSach.QuanLyBanSachDataSet();
            this.USP_InHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_InHoaDonTableAdapter = new QuanLyBanSach.QuanLyBanSachDataSetTableAdapters.USP_InHoaDonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyBanSachDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_InHoaDonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.USP_InHoaDonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyBanSach.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(639, 318);
            this.reportViewer1.TabIndex = 0;
            // 
            // QuanLyBanSachDataSet
            // 
            this.QuanLyBanSachDataSet.DataSetName = "QuanLyBanSachDataSet";
            this.QuanLyBanSachDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_InHoaDonBindingSource
            // 
            this.USP_InHoaDonBindingSource.DataMember = "USP_InHoaDon";
            this.USP_InHoaDonBindingSource.DataSource = this.QuanLyBanSachDataSet;
            // 
            // USP_InHoaDonTableAdapter
            // 
            this.USP_InHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // FInHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 318);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FInHoaDon";
            this.Text = "FInHoaDon";
            this.Load += new System.EventHandler(this.FInHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyBanSachDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_InHoaDonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_InHoaDonBindingSource;
        private QuanLyBanSachDataSet QuanLyBanSachDataSet;
        private QuanLyBanSachDataSetTableAdapters.USP_InHoaDonTableAdapter USP_InHoaDonTableAdapter;
    }
}