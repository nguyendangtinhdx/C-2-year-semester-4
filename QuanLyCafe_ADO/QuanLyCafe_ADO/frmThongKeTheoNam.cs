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
    public partial class frmThongKeTheoNam : Form
    {
        public frmThongKeTheoNam()
        {
            InitializeComponent();
        }
        public static List<ThongKeBEAN> ds = new List<ThongKeBEAN>();
        ThongKeBO thongKe = new ThongKeBO();
        public static string nam = "";
        private void frmThongKeTheoNam_Load(object sender, EventArgs e)
        {
            var currentDateTime = DateTime.Now;
            var year = currentDateTime.Day;
            ds = thongKe.getListThongKeTheoNam(year);
            dtgvThongKeTheoNam.DataSource = ds;
            nam = year.ToString();
        }

        private void MC_DateChanged(object sender, DateRangeEventArgs e)
        {
            // thống kê theo năm được chọn
            var year = e.Start;
            lbNgay.Text = "Năm: " + year.Year;
            lbTongTien.Text = "Tổng tiền: " + thongKe.getTongTienTheoNam(year.Year) + " đ";
            ds = thongKe.getListThongKeTheoNam(year.Year);
            dtgvThongKeTheoNam.DataSource = ds;
            nam = year.Year.ToString();
        }

        private void btnInBangThongKe_Click(object sender, EventArgs e)
        {
            frmInThongKeTheoNam f = new frmInThongKeTheoNam();
            f.ShowDialog();
        }
    }
}
