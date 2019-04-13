using QuanLyBanSach.DAO;
using QuanLyBanSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string passWord = txtpassword.Text;
            if (Login(username,passWord))
            {
                accountDTO loginacc = accountDAO.Instance.GetTen(username);
                QuanLyBanSach123 f = new QuanLyBanSach123(loginacc);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!!!","Thông Báo",MessageBoxButtons.OK);
            }            
        }

        bool Login (string username, string password)
        {
            return accountDAO.Instance.Login(username,password);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
