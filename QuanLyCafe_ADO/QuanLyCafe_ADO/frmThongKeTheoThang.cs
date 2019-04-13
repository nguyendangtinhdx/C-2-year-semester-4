using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.bo;
namespace QuanLyCafe_ADO
{
    public partial class frmThongKeTheoThang : Form
    {
        public frmThongKeTheoThang()
        {
            InitializeComponent();
        }
        public static List<ThongKeBEAN> ds = new List<ThongKeBEAN>();
        ThongKeBO thongKe = new ThongKeBO();
        public static string thang = "";
        private void frmThongKeTheoThang_Load(object sender, EventArgs e)
        {
            var currentDateTime = DateTime.Now;
            var month = currentDateTime.Month;
            var year = currentDateTime.Year;
            ds = thongKe.getListThongKeTheoThang(month,year);
            dtgvThongKeTheoThang.DataSource = ds;
            thang = month.ToString();
        }

        private void MC_DateChanged(object sender, DateRangeEventArgs e)
        {
            // thống kê theo thám được chọn
            var month = e.Start;
            lbNgay.Text = "Tháng: " + month.Month;
            lbTongTien.Text = "Tổng tiền: " + thongKe.getTongTienTheoThang(month.Month,month.Year) + " đ";
            ds = thongKe.getListThongKeTheoThang(month.Month,month.Year);
            dtgvThongKeTheoThang.DataSource = ds;
            thang = month.Month.ToString();
        }

        private void btnInBangThongKe_Click(object sender, EventArgs e)
        {
            frmInThongKeTheoThang f = new frmInThongKeTheoThang();
            f.ShowDialog();
        }
    }
}
