using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.bo;
using test.dao;
namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DangNhapBO dangNhap = new DangNhapBO();
        DungChung dc = new DungChung();
        public static string taiKhoan = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            dc.KetNoi();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dangNhap.DangNhap(txtTaiKhoan.Text, txtMatKhau.Text))
            {
                taiKhoan = txtTaiKhoan.Text;
                frmMenu f = new frmMenu();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

       
    }
}
