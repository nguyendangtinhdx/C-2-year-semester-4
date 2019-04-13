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
    public partial class Fdoimatkhau : Form
    {
        public Fdoimatkhau()
        {
            InitializeComponent();
        }

        private void Fdoimatkhau_Load(object sender, EventArgs e)
        {
            lbmanhanvien.Text = DataProvider.manhanvienshow;
            lbtentaikhoan.Text = DataProvider.tentaikhoanshow;         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = lbtentaikhoan.Text;
            string newpassword = txtmatkhau.Text;
            if (txtmatkhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới");
            }
            else
            {
                if (txtmatkhau.Text != txtnhaplaimatkhau.Text)
                {
                    MessageBox.Show("Vui lòng nhập đúng nhập lại mật khẩu mới");
                }
                else
                {
                    string query = "UPDATE Account SET Password = @newpassword WHERE Username = @username ";
                    DataProvider.Instance.ExecuteQuery(query, new object[] { newpassword, username });
                    MessageBox.Show("Đổi mật khẩu thành công!!!","Thông Báo");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
