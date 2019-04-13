using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH2_QuanLyCafe
{
    public partial class frmThongKeTheoNam : Form
    {
        public frmThongKeTheoNam()
        {
            InitializeComponent();
        }
        public static List<Qtk> ds = new List<Qtk>();
        public static DateTime nam; 
        private void frmThongKeTheoNam_Load(object sender, EventArgs e)
        {
            nam = DateTime.Now; // lấy ngày hiện tại
            label1.Text = "Ngày: " + nam.ToShortDateString();
            //Lấy về các hóa đơn của ngày hiện tại 
            var q = CauHinh.db.Qtks.Where(p => p.NgayBan.Value.Year == nam.Year);
            if (q.Count() != 0)
            {
                //Tính tổng thành tiền của hàng bán trong ngày
                long tongtien = q.Sum(p => p.ThanhTien);
                label2.Text = "Tổng tiền: " + tongtien.ToString() + " đ";
            }
            else
                label2.Text = "Tổng tiên : 0 đ";
            dataGridView1.DataSource = q;
            ds = q.ToList();
        }

        private void MC_DateChanged(object sender, DateRangeEventArgs e)
        {
            // thống kê theo ngày được chọn
            nam = e.Start;
            label1.Text = "Ngày: " + nam.ToShortDateString();
            var q = CauHinh.db.Qtks.Where(p => p.NgayBan.Value.Year == nam.Year);
            if (q.Count() != 0)
            {
                long tongtien = q.Sum(p => p.ThanhTien);
                label2.Text = "Tổng tiền: " + tongtien.ToString() + " đ";
            }
            else
                label2.Text = "Tổng tiền : 0 đ";
            dataGridView1.DataSource = q;
        }

        private void btnInBangThongKe_Click(object sender, EventArgs e)
        {
            frmInThongKeTheoNam f = new frmInThongKeTheoNam();
            f.ShowDialog();
        }
    }
}
