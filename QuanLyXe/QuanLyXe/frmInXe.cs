using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyXe
{
    public partial class frmInXe : Form
    {
        public frmInXe()
        {
            InitializeComponent();
        }

        private void frmInXe_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("InXe",frmXe.lx));
            this.reportViewer1.RefreshReport();
        }
    }
}
