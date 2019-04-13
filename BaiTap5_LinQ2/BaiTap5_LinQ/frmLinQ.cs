using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap5_LinQ
{
    public partial class frmLinQ : Form
    {
        public frmLinQ()
        {
            InitializeComponent();
        }
        dbDataContext db = new dbDataContext();
        BO.SachBO sach = new BO.SachBO();
        BO.LoaiBO loai = new BO.LoaiBO();
        Boolean kt = false;
        public static List<sach> ds = new List<sach>();
        private void frmLinQ_Load(object sender, EventArgs e)
        {
            //var q = from s in db.saches
            //        select s;
            //dataGridView1.DataSource = q;

            //var q = from s in db.saches
            //        where s.maloai.Equals("Y hoc")
            //        select s;
            //dataGridView1.DataSource = q;



            // kiểu lampda
            //var qq = db.saches.Where(p => p.tensach.Equals("Hoa")).Select(s => new { s.masach, s.tensach, s.gia });
            //dataGridView1.DataSource = qq.Skip(10).Take(5);
            ds = sach.getSach();
            dataGridView1.DataSource = ds;
            listBox1.DataSource = loai.getLoai();
            listBox1.DisplayMember = "TenLoai";
            listBox1.ValueMember = "MaLoai";
            kt = true;

        }

        //private int dem = 0;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kt)
            {
                //loai loai = listBox1.SelectedItem as loai;

                //string maLoai = listBox1.SelectedValue.ToString();
                //var q = from s in db.saches
                //        where s.maloai.Equals(maLoai)
                //        select s;
                //dataGridView1.DataSource = q;
                //lblTong.Text = "Số sách: " + q.Count();
                //if (q.Count() != 0)
                //{
                //    long t = (long)q.Sum(s => s.soluong);
                //    lblTongSL.Text = " Tổng số lượng sách: " + t.ToString("0,0");

                //    long m = (long)q.Max(s => s.gia);
                //    lblMaxGia.Text = "Giá max = " + m.ToString("0,0");

                //    long min = (long)q.Min(s => s.gia);
                //    lblMinGia.Text = "Giá min = " + min.ToString("0,0");

                //    long tbGia = (long)q.Average(s => s.gia);
                //    lblTBGia.Text = "Giá trung bình = " + tbGia.ToString("0,0");

                //    long tongThanhTien = (long)q.Sum(g => g.gia * g.soluong);
                //    lblTongThanhTien.Text = "Tổng thành tiền = " + tongThanhTien.ToString("0,0");
                //}

                string maLoaiSach = listBox1.SelectedValue.ToString();
                ds = sach.getSach(maLoaiSach);
                dataGridView1.DataSource = ds;
                //dem = 1;

                int sumSL, count;
                long max, min, avg, thanhTien;
                sach.getSum(maLoaiSach, out sumSL, out count, out max, out min, out avg, out thanhTien);
                lblTongSL.Text = "Tổng số lượng sách: " + sumSL;
                lblTong.Text = "Số sách: " + count;
                lblMaxGia.Text = "Giá max: " + max.ToString("0,0");
                lblMinGia.Text = "Giá min: " + min.ToString("0,0");
                lblTBGia.Text = "Giá trung bình: " + avg.ToString("0,0");
                lblTongThanhTien.Text = "Tổng thành tiền: " + thanhTien.ToString("0,0");
            }
        }
        //private void txtTim_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode == Keys.Enter)
        //    {
        //        string maLoai = listBox1.SelectedValue.ToString();
        //        string key = txtTim.Text;
        //        dataGridView1.DataSource = sach.TimTenSachVaTacGia(maLoai, key);
        //        dem = 2;
        //    }
        //}
        private void txtTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string maLoai = listBox1.SelectedValue.ToString();
                string key = txtTim.Text;
                ds = sach.TimTenSachVaTacGia(maLoai, key);
                dataGridView1.DataSource = ds;
                //dem = 2;
            }
        }
        
        private void btnIn_Click(object sender, EventArgs e)
        {
            //if(dem == 0)
            //{
            //    ds = sach.getSach();
            //}
            //if(dem == 1)
            //{
            //    ds = sach.getSach(listBox1.SelectedValue.ToString());
            //}
            //if(dem == 2)
            //{
            //    ds = sach.TimTenSachVaTacGia(listBox1.SelectedValue.ToString(),txtTim.Text);
            //}
            frmIn f = new frmIn();
            f.ShowDialog();
        }

       
    }
}
