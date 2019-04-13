using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe_ADO.bo;
using QuanLyCafe_ADO.dao;
namespace QuanLyCafe_ADO
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        DangNhapBO dangNhap = new DangNhapBO();
        DungChung dc = new DungChung();
        public static string tenDangNhap = "";
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            dc.KetNoi2();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (dangNhap.DangNhap(txtTenDangNhap.Text, MaHoaMD5.MaHoa(txtMatKhau.Text, txtMatKhau.Text)))
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

     
    }
}
