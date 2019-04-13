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
    public partial class frmInHoaDonBanHangCrystal : Form
    {
        public frmInHoaDonBanHangCrystal()
        {
            InitializeComponent();
        }

        private void frmInHoaDonBanHangCrystal_Load(object sender, EventArgs e)
        {
            CrystalReport2 r = new CrystalReport2();
            r.SetDataSource(frmMenu.ds);
            r.SetParameterValue("TenBan", frmMenu.tenBan);
            r.SetParameterValue("NguoiLapPhieu", frmDangNhap.tenDangNhap);
            r.SetParameterValue("TongTienBangChu", frmMenu.tongtienbangchu);
            crystalReportViewer1.ReportSource = r;

        }

    }
}
