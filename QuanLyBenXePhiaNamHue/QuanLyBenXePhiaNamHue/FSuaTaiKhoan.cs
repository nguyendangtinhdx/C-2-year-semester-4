using QuanLyBenXePhiaNamHue.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBenXePhiaNamHue
{
    public partial class FSuaTaiKhoan : Form
    {
        public FSuaTaiKhoan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tentaikhoan = AccountDAO.uesrnametk;
            string matkhau = txtmatkhau.Text;
            string nhaplai = txtnhaplaimatkhau.Text;
            string quyen = cbbQuyen.Text;
            if (MessageBox.Show("Xác nhận sửa tài khoản?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (matkhau != nhaplai)
                {
                    MessageBox.Show("Mật khẩu và Nhập lại mật khẩu không khớp", "Thông Báo");
                }
                else
                {
                    if (AccountDAO.Instance.suaTaiKhoan(tentaikhoan,matkhau,quyen))
                    {
                        MessageBox.Show("Sửa Tài Khoản Thành Công!!!", "Thông Báo");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Tài Khoản Thất Bại!!!", "Thông Báo");
                    }
                }
            }
        }

        private void FSuaTaiKhoan_Load(object sender, EventArgs e)
        {
            lbmanhanvien.Text = NhanVienDAO.manhanvientk;
            lbtennhanvien.Text = NhanVienDAO.tennhanvientk;
            lbTenTaiKhoan.Text = AccountDAO.uesrnametk;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn hủy tài khoản này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (AccountDAO.Instance.xoaTaiKhoan(lbTenTaiKhoan.Text))
                {
                    MessageBox.Show("Xóa Tài Khoản Thành Công!!!", "Thông Báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa Tài Khoản Thất Bại!!!", "Thông Báo");
                }
            }
        }
    }
}
