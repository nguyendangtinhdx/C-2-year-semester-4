using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenDangTinh
{
    public partial class QuanLyCuaHang : Form
    {
        public QuanLyCuaHang()
        {
            InitializeComponent();
        }
        HangHoa hh = new HangHoa("data.txt");

        private void QuanLyCuaHang_Load(object sender, EventArgs e)
        {
            dtgvCuaHang.DataSource = hh.dsCuaHang;

            txtMaHang.DataBindings.Add("Text", hh.dsCuaHang, "MaHang");
            txtTenHang.DataBindings.Add("Text", hh.dsCuaHang, "TenHang");
            txtGia.DataBindings.Add("Text", hh.dsCuaHang, "Gia");
            txtSoLuong.DataBindings.Add("Text", hh.dsCuaHang, "SoLuong");
            txtNgayNhap.DataBindings.Add("Text", hh.dsCuaHang, "NgayNhap");
            txtThanhTien.DataBindings.Add("Text", hh.dsCuaHang, "ThanhTien");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            hh.Sua(txtMaHang.Text,txtTenHang.Text,double.Parse(txtGia.Text),Int32.Parse(txtSoLuong.Text),DateTime.Parse(txtNgayNhap.Text),double.Parse(txtThanhTien.Text));
            dtgvCuaHang.DataSource = null;
            dtgvCuaHang.DataSource = hh.dsCuaHang;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgvCuaHang.DataSource = null;
            dtgvCuaHang.DataSource = hh.Tim(txtTenHang.Text);
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            hh.LuuFile("data.txt");
            MessageBox.Show("Đã lưu file xong");
        }

        private void btnInTimKiem_Click(object sender, EventArgs e)
        {
            ds = hh.Tim(txtTenHang.Text);
            InCuaHang f = new InCuaHang();
            f.ShowDialog();
        }
        public static List<CuaHang> ds;
        private void btnIn_Click(object sender, EventArgs e)
        {
            ds = hh.dsCuaHang;
            InCuaHang f = new InCuaHang();
            f.ShowDialog();
        }
    }
}
