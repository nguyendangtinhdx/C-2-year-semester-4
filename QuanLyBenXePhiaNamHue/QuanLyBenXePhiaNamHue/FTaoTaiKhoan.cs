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
    public partial class FTaoTaiKhoan : Form
    {
        public FTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tendangnhap = txttendangnhap.Text;
            string matkhau = txtmatkhau.Text;
            string nhaplai = txtnhaplaimatkhau.Text;
            string quyen = cbbQuyen.Text;
            if (MessageBox.Show("Xác nhận thêm tài khoản?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (matkhau != nhaplai)
                {
                    MessageBox.Show("Mật khẩu và Nhập lại mật khẩu không khớp", "Thông Báo");
                }
                else
                {
                    if (AccountDAO.Instance.taoTaiKhoan(tendangnhap, matkhau, lbmanhanvien.Text, quyen))
                    {
                        MessageBox.Show("Tạo Tài Khoản Thành Công!!!", "Thông Báo");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tạo Tài Khoản Thất Bại!!!", "Thông Báo");
                    }
                }                
            }            
        }

        private void FTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            lbmanhanvien.Text = NhanVienDAO.manhanvientk;
            lbtennhanvien.Text = NhanVienDAO.tennhanvientk;
        }
    }
}
