using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace test
{
    public partial class frmIn : Form
    {
        public frmIn()
        {
            InitializeComponent();
        }

        private void frmIn_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", frmMenu.ds));
            
            ReportParameter ts = new ReportParameter("TaiKhoan", Form1.taiKhoan);
            reportViewer1.LocalReport.SetParameters(ts);
            this.reportViewer1.RefreshReport();
        }
    }
}
