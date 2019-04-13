using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class QlCanBo : Form
    {
        public QlCanBo()
        {
            InitializeComponent();
        }
        CoQuan cq = new CoQuan("canbo.txt");
        private void QlCanBo_Load(object sender, EventArgs e)
        {
            dtgvCanBo.DataSource = cq.dsCanBo;

            txtMaCb.DataBindings.Add("Text", cq.dsCanBo, "Ma");
            txtHoTen.DataBindings.Add("Text", cq.dsCanBo, "Hoten");
            txtGioiTinh.DataBindings.Add("Text", cq.dsCanBo, "Gioitinh");
            txtDiaChi.DataBindings.Add("Text", cq.dsCanBo, "Diachi");
            txtNgaySinh.DataBindings.Add("Text", cq.dsCanBo, "Ngaysinh");
            txtHeSoLuong.DataBindings.Add("Text", cq.dsCanBo, "Hesoluong");
            txtTenDonVi.DataBindings.Add("Text", cq.dsCanBo, "Tendonvi");
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dtgvCanBo.DataSource = null;
            dtgvCanBo.DataSource = cq.dsCanBo;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cq.Them(txtMaCb.Text, txtHoTen.Text, bool.Parse(txtGioiTinh.Text), txtDiaChi.Text,
               DateTime.Parse(txtNgaySinh.Text), double.Parse(txtHeSoLuong.Text), txtTenDonVi.Text);
            dtgvCanBo.DataSource = null;
            dtgvCanBo.DataSource = cq.dsCanBo;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cq.Sua(txtMaCb.Text, double.Parse(txtHeSoLuong.Text));
            dtgvCanBo.DataSource = null;
            dtgvCanBo.DataSource = cq.dsCanBo;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cq.Xoa(txtMaCb.Text);
            dtgvCanBo.DataSource = null;
            dtgvCanBo.DataSource = cq.dsCanBo;
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            cq.LuuFile("Canbo.txt");
            MessageBox.Show("Đã lưu file xong");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập Tên đơn vị của cán bộ cần tìm", "Tìm kiếm", "");
            //List<CanBo> lcb = cq.Tim(cq.dsCanBo, st);
            //dtgvCanBo.DataSource = null;
            //dtgvCanBo.DataSource = lcb;

            dtgvCanBo.DataSource = null;
            dtgvCanBo.DataSource = cq.Tim(txtTenDonVi.Text);
        }

        public static List<CanBo> ds;
        private void btnIn_Click(object sender, EventArgs e)
        {
            ds = cq.dsCanBo;
            frmInNhanVien f = new frmInNhanVien();
            f.ShowDialog();
        }

    }
}
