using QuanLyBenXePhiaNamHue.DAO;
using QuanLyBenXePhiaNamHue.DTO;
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
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = txtMatKhau.Text;
            if (Login(username,password))
            {
                AccountDTO gettypelogin = AccountDAO.Instance.GetTypeLogin(username);
                DataProvider.TypeLoginshow = gettypelogin.TypeLogin;
                DataProvider.manhanvienshow = gettypelogin.MaNhanVien;
                DataProvider.tentaikhoanshow = username;
                List<NhanVienDTO> listnv = NhanVienDAO.Instance.getNhanVienDangNhap(gettypelogin.MaNhanVien);
                foreach (NhanVienDTO item in listnv)
                {
                    DataProvider.tennhanvienshow = item.HoTen;
                }
                FMenu f = new FMenu();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu","Thông Báo");
            }
        }
        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
