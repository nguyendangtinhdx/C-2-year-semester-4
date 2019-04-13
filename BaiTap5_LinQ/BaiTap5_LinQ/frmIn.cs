using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap5_LinQ
{
    public partial class frmIn : Form
    {
        public frmIn()
        {
            InitializeComponent();
        }

        private void frmIn_Load(object sender, EventArgs e)
        {
            dbDataContext db = new dbDataContext();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", frmLinQ.ds));
            //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", sach.TimTenSachVaTacGia(maloaisach, tenSach, tacGia)));
            this.reportViewer1.RefreshReport();
        }

    }
}
