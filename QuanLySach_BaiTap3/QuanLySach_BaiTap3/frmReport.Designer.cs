namespace QuanLySach_BaiTap3
{
    partial class frmReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLySachDataSet = new QuanLySach_BaiTap3.QuanLySachDataSet();
            this.SachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SachTableAdapter = new QuanLySach_BaiTap3.QuanLySachDataSetTableAdapters.SachTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLySachDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SachBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.SachBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLySach_BaiTap3.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(641, 350);
            this.reportViewer1.TabIndex = 0;
            // 
            // QuanLySachDataSet
            // 
            this.QuanLySachDataSet.DataSetName = "QuanLySachDataSet";
            this.QuanLySachDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SachBindingSource
            // 
            this.SachBindingSource.DataMember = "Sach";
            this.SachBindingSource.DataSource = this.QuanLySachDataSet;
            // 
            // SachTableAdapter
            // 
            this.SachTableAdapter.ClearBeforeFill = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 374);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLySachDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SachBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SachBindingSource;
        private QuanLySachDataSet QuanLySachDataSet;
        private QuanLySachDataSetTableAdapters.SachTableAdapter SachTableAdapter;
    }
}