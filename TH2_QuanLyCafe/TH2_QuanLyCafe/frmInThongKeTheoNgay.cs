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
namespace TH2_QuanLyCafe
{
    public partial class frmInThongKeTheoNgay : Form
    {
        public frmInThongKeTheoNgay()
        {
            InitializeComponent();
        }

        private void frmInThongKeTheoNgay_Load(object sender, EventArgs e)
        {
             var q = CauHinh.db.Qtks.Where(p => p.NgayBan.Value.Day == frmThongKeTheoNgay.ngay.Day);
            if (q.Count() != 0)
            {
                reportViewer1.LocalReport.DataSources.Clear();// xoa du lieu cu
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("RTkNgay", frmThongKeTheoNgay.ds));
                this.reportViewer1.RefreshReport();
            }


            ReportParameter ts = new ReportParameter("Ngay", frmThongKeTheoNgay.ngay.Day.ToString());
            reportViewer1.LocalReport.SetParameters(ts);
            this.reportViewer1.RefreshReport();

            ReportParameter ts2 = new ReportParameter("NgayIn", DateTime.Now.ToString());
            reportViewer1.LocalReport.SetParameters(ts2);
            this.reportViewer1.RefreshReport();
        }
    }
}
