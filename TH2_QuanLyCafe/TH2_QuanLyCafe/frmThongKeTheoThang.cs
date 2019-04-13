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
    public partial class frmThongKeTheoThang : Form
    {
        public frmThongKeTheoThang()
        {
            InitializeComponent();
        }
        public static List<Qtk> ds = new List<Qtk>();
        public static DateTime thang; 
        private void frmThongKeTheoThang_Load(object sender, EventArgs e)
        {
            thang = DateTime.Now; // lấy tháng hiện tại
            label1.Text = "Ngày: " + thang.ToShortDateString();
            //Lấy về các hóa đơn của ngày hiện tại 
            var q = CauHinh.db.Qtks.Where(p => p.NgayBan.Value.Month == thang.Month);
            if (q.Count() != 0)
            {
                //Tính tổng thành tiền của hàng bán trong tháng
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
            thang = e.Start;
            label1.Text = "Ngày: " + thang.ToShortDateString();
            var q = CauHinh.db.Qtks.Where(p => p.NgayBan.Value.Month == thang.Month);
            if (q.Count() != 0)
            {
                //Tính tổng thành tiền của hàng bán trong tháng
                long tongtien = q.Sum(p => p.ThanhTien);
                label2.Text = "Tổng tiền: " + tongtien.ToString() + " đ";
            }
            else
                label2.Text = "Tổng tiên : 0 đ";
            dataGridView1.DataSource = q;
        }

        private void btnInBangThongKe_Click(object sender, EventArgs e)
        {
            frmInThongKeTheoThang f = new frmInThongKeTheoThang();
            f.ShowDialog();
        }
    }
}
