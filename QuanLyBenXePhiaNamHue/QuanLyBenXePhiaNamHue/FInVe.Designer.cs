namespace QuanLyBenXePhiaNamHue
{
    partial class FInVe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInVe));
            this.USP_InVeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanlybenxephianamDataSet = new QuanLyBenXePhiaNamHue.QuanlybenxephianamDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_InVeTableAdapter = new QuanLyBenXePhiaNamHue.QuanlybenxephianamDataSetTableAdapters.USP_InVeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_InVeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanlybenxephianamDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_InVeBindingSource
            // 
            this.USP_InVeBindingSource.DataMember = "USP_InVe";
            this.USP_InVeBindingSource.DataSource = this.QuanlybenxephianamDataSet;
            // 
            // QuanlybenxephianamDataSet
            // 
            this.QuanlybenxephianamDataSet.DataSetName = "QuanlybenxephianamDataSet";
            this.QuanlybenxephianamDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_InVeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyBenXePhiaNamHue.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(729, 374);
            this.reportViewer1.TabIndex = 0;
            // 
            // USP_InVeTableAdapter
            // 
            this.USP_InVeTableAdapter.ClearBeforeFill = true;
            // 
            // FInVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 374);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(745, 413);
            this.MinimumSize = new System.Drawing.Size(745, 413);
            this.Name = "FInVe";
            this.Text = "FInVe";
            this.Load += new System.EventHandler(this.FInVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_InVeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanlybenxephianamDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_InVeBindingSource;
        private QuanlybenxephianamDataSet QuanlybenxephianamDataSet;
        private QuanlybenxephianamDataSetTableAdapters.USP_InVeTableAdapter USP_InVeTableAdapter;
    }
}