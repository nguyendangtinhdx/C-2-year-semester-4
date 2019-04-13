using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH2_QuanLyCafe
{
    public partial class frmInNhaVien : Form
    {
        public frmInNhaVien()
        {
            InitializeComponent();
        }

        private void frmIn_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", frmNhanVien.ds));

            this.reportViewer1.RefreshReport();
        }
    }
}
