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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }
        BO.DangKyBO dk = new BO.DangKyBO();
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(txtMaNhanVien.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "" || txtMatKhau.Text == "" || txtQuyen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông đăng ký");
            }
            else
            {
                Boolean kt = dk.Them(txtMaNhanVien.Text, txtHoTen.Text, txtDiaChi.Text, MaHoaMD5.MaHoa(txtMatKhau.Text,txtMatKhau.Text), txtQuyen.Text);
                if (kt)
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                    this.Close();
                }
                else
                    MessageBox.Show("Thêm tài khoản thất bại");
            }
        }
    }
}
