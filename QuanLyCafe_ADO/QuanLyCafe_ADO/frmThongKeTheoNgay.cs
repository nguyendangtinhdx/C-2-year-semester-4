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
    public partial class frmThongKeTheoNgay : Form
    {
        public frmThongKeTheoNgay()
        {
            InitializeComponent();
        }
        public static List<ThongKeBEAN> ds = new List<ThongKeBEAN>();
        ThongKeBO thongKe = new ThongKeBO();
        public static string ngay = "";
        private void frmThongKeTheoNgay_Load(object sender, EventArgs e)
        {
            var currentDateTime = DateTime.Now;
            var day = currentDateTime.Day;
            var month = currentDateTime.Month;
            var year = currentDateTime.Year;
            ds = thongKe.getListThongKeTheoNgay(day,month,year);
            dtgvThongKeTheoNgay.DataSource = ds;
            ngay = day.ToString();
        }

        private void MC_DateChanged(object sender, DateRangeEventArgs e)
        {
            // thống kê theo ngày được chọn
            var day = e.Start;
            lbNgay.Text = "Ngày: " + day.Day;
            lbTongTien.Text = "Tổng tiền: " + thongKe.getTongTienTheoNgay(day.Day,day.Month,day.Year) + " đ";
            ds = thongKe.getListThongKeTheoNgay(day.Day, day.Month, day.Year);
            dtgvThongKeTheoNgay.DataSource = ds;
            ngay = day.Day.ToString();
        }

        private void btnInBangThongKe_Click(object sender, EventArgs e)
        {
            frmInThongKeTheoNgay f = new frmInThongKeTheoNgay();
            f.ShowDialog();
        }
    }
}
