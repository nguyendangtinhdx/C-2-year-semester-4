using QuanLyBanSach.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class ChangePassWord : Form
    {
        public ChangePassWord()
        {
            InitializeComponent();
        }
        void UpdateAccount()
        {
            string taikhoan = txttaikhoan.Text;
            string matkhau = txtmatkhaucu.Text;
            string matkhaumoi = txtmatkhaumoi.Text;
            string nhaplai = txtnhaplai.Text;
            if (Regex.IsMatch(txtmatkhaucu.Text, @"[^a-zA-Z0-9 ]+") || Regex.IsMatch(txtmatkhaumoi.Text, @"[^a-zA-Z0-9 ]+") || Regex.IsMatch(txtnhaplai.Text, @"[^a-zA-Z0-9 ]+"))// || txttaikhoan.Text != null || txtmatkhaucu.Text != null || txtmatkhaumoi.Text != null || txtnhaplai.Text != null)
            {
                MessageBox.Show("Vui lòng không sử dụng ký tự đặc biệt hoặc chưa nhập ký tự !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!nhaplai.Equals(matkhaumoi))
                {
                    MessageBox.Show("Vui lòng nhập đúng với mật khẩu mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnhaplai.Text = null;
                    txtmatkhaumoi.Text = null;
                }
                else
                {
                    if (accountDAO.Instance.UpdateAccount(taikhoan,matkhau,matkhaumoi))
                    {
                        MessageBox.Show("Thay đổi mật khẩu thành công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txttaikhoan.Text = null;
                        txtnhaplai.Text = null;
                        txtmatkhaumoi.Text = null;
                        txtmatkhaucu.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Thay đổi không thành công, vui lòng kiểm tra lại tài khoảng hoặc mật khẩu cũ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }
    }
}
