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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }
        BO.DangKyBO dk = new BO.DangKyBO();
        public static bool quyen;
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            if(txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin đăng ký !");
            }
            else
            {
                Boolean kt = dk.Them(txtTaiKhoan.Text, MaHoaChuoi.MaHoa(txtMatKhau.Text, txtMatKhau.Text), cbQuyen.Checked);
                //Boolean kt = dk.Them(txtTaiKhoan.Text, MaHoa.md5(txtMatKhau.Text), cbQuyen.Checked);
                if (kt)
                    MessageBox.Show("Thêm tài khoản thành công");
                else
                    MessageBox.Show("Thêm tài khoản thất bại");
            }
           
        }
    }
}
