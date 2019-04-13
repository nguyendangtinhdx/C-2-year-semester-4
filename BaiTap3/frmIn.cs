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
namespace BaiTap3
{
    public partial class frmIn : Form
    {
        public frmIn()
        {
            InitializeComponent();
        }

        private void frmIn_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();// xoa du lieu cu
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", frmNhanVien.tam));// xoa du lieu cu

            this.reportViewer1.RefreshReport();

            ReportParameter ts= new ReportParameter("nlp",frmDangNhap.ten);
            reportViewer1.LocalReport.SetParameters(ts);
            this.reportViewer1.RefreshReport();

            ReportParameter ts2 = new ReportParameter("tenNhaVien", frmNhanVien.tukhoa);
            reportViewer1.LocalReport.SetParameters(ts2);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
