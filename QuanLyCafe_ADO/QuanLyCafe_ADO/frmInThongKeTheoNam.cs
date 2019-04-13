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
namespace QuanLyCafe_ADO
{
    public partial class frmInThongKeTheoNam : Form
    {
        public frmInThongKeTheoNam()
        {
            InitializeComponent();
        }

        private void frmInThongKeTheoNam_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            reportViewer1.LocalReport.DataSources.Clear();// xoa du lieu cu
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", frmThongKeTheoNam.ds));

            ReportParameter ts = new ReportParameter("Nam", frmThongKeTheoNam.nam);
            reportViewer1.LocalReport.SetParameters(ts);
            this.reportViewer1.RefreshReport();
        }
    }
}
