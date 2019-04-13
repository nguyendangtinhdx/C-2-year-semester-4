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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        BO.DangNhapBO dn = new BO.DangNhapBO();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (dn.DangNhap(txtTaiKhoan.Text, MaHoaChuoi.MaHoa(txtMatKhau.Text, txtMatKhau.Text)) == true)
            //if (dn.DangNhap(txtTaiKhoan.Text,MaHoa.md5(txtMatKhau.Text)) == true)
            {
                frmMenu f = new frmMenu();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
