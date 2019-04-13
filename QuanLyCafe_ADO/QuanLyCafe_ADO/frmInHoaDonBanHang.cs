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
    public partial class frmInHoaDonBanHang : Form
    {
        public frmInHoaDonBanHang()
        {
            InitializeComponent();
        }

        private void frmInHoaDonBanHang_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1",frmMenu.ds));
            this.reportViewer1.RefreshReport();

            ReportParameter ts = new ReportParameter("Ngay", DateTime.Now.ToString());
            reportViewer1.LocalReport.SetParameters(ts);
            this.reportViewer1.RefreshReport();

            ReportParameter ts2 = new ReportParameter("TongTienBangChu", frmMenu.tongtienbangchu);
            reportViewer1.LocalReport.SetParameters(ts2);
            this.reportViewer1.RefreshReport();

            ReportParameter ts3 = new ReportParameter("Ban", frmMenu.tenBan);
            reportViewer1.LocalReport.SetParameters(ts3);
            this.reportViewer1.RefreshReport();

            ReportParameter ts4 = new ReportParameter("NguoiLapHoaDon", frmDangNhap.tenDangNhap);
            reportViewer1.LocalReport.SetParameters(ts4);
            this.reportViewer1.RefreshReport();

        }
    }
}
