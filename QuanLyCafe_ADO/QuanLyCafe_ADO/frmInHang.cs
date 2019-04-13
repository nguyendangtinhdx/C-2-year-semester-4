using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe_ADO
{
    public partial class frmInHang : Form
    {
        public frmInHang()
        {
            InitializeComponent();
        }

        private void frmInHang_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", frmHang.ds));

        }
    }
}
