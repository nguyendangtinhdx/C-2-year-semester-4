using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.bo;
namespace QuanLyCafe_ADO
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }
        NhanVienBO nhanVien = new NhanVienBO();
        public static List<NhanVienBEAN> ds, tam = new List<NhanVienBEAN>();
        private void frmDangKy_Load(object sender, EventArgs e)
        {
            ds = nhanVien.getListNhanVien();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "" || txtMatKhau.Text == "" || txtXacNhanMatKhau.Text == "" || cbbQuyen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin nhân viên");
                return;
            }
            if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu không giống nhau");
                return;
            }
            Boolean kq;
            nhanVien.themNhanVien(ds, txtMaNhanVien.Text, txtHoTen.Text, txtDiaChi.Text, MaHoaMD5.MaHoa(txtMatKhau.Text, txtMatKhau.Text), cbbQuyen.Text, out kq);
            if (kq == false)
                MessageBox.Show("Mã nhân viên đã tồn tại");
            else
                MessageBox.Show("Đăng ký thành công");
        }
    }
}
