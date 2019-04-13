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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public static string quyen = "";
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            CauHinh ch = new CauHinh();
            //Sử dụng câu lệnh LINQ để kiểm tra đăng nhập 
            var q = from p in CauHinh.db.NHanViens
                    where p.Manv == txtMaNhanVien.Text && p.MatKhau == MaHoaMD5.MaHoa(txtMatKhau.Text,txtMatKhau.Text)
                    select p;
            if(q.Count() == 0)
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
            else
            {
                quyen = txtMaNhanVien.Text;
                //Lưu lại các thông tin của nhân viên đăng nhập 
                CauHinh.manv = txtMaNhanVien.Text;
                CauHinh.hoten = q.First().HoTen;
                CauHinh.quyen = q.First().Quyen;
                frmMenu f = new frmMenu();
                f.Show();
                this.Hide();
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
