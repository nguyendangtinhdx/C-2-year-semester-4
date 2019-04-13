using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTap6_ADO.BO;
namespace BaiTap6_ADO
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        DangNhapBo dangNhap = new DangNhapBo();
        public static string tenDangNhap = "";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (dangNhap.DangNhap(long.Parse(txtTenDangNhap.Text), txtMatKhau.Text))
            {
                tenDangNhap = txtTenDangNhap.Text;
                frmMenu f = new frmMenu();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
