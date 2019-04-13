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
    public partial class frmInHoaDon : Form
    {
        public frmInHoaDon()
        {
            InitializeComponent();
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            //Lấy về hóa đơn của bàn chọn ở FrmBanHang 
            var q = CauHinh.db.VHienThiHoaDons.Where(p => p.MaBan == frmBanHang.maban);
            reportViewer1.LocalReport.DataSources.Clear();// xoa du lieu cu
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("RinHoaDon", frmBanHang.ds));
            this.reportViewer1.RefreshReport();
            
            ReportParameter ts = new ReportParameter("TenBan", frmBanHang.tenban);
            reportViewer1.LocalReport.SetParameters(ts);
            this.reportViewer1.RefreshReport();

            ReportParameter ts2 = new ReportParameter("NgayIn", DateTime.Now.ToString());
            reportViewer1.LocalReport.SetParameters(ts2);
            this.reportViewer1.RefreshReport();

            ReportParameter ts3 = new ReportParameter("TongTienBangChu", frmBanHang.tongtienbangchu);
            reportViewer1.LocalReport.SetParameters(ts3);
            this.reportViewer1.RefreshReport();

            CauHinh.db.SubmitChanges();
        }
    }
}
