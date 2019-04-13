using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyXe
{
    public partial class frmXe : Form
    {
        public frmXe()
        {
            InitializeComponent();
        }

        CuaHang ch = new CuaHang("xe.txt");
        private void Form1_Load(object sender, EventArgs e)
        {
            dtgvXe.DataSource = ch.ds;

            txtMaXe.DataBindings.Add("Text", ch.ds, "MaXe");
            txtTenXe.DataBindings.Add("Text", ch.ds, "Ten");
            txtLoaiXe.DataBindings.Add("Text", ch.ds, "LoaiXe");
            txtNgaySanXuat.DataBindings.Add("Text", ch.ds, "NgaySanXuat");
            txtGia.DataBindings.Add("Text", ch.ds, "Gia");
        }


        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            dtgvXe.DataSource = null;
            dtgvXe.DataSource = ch.TimLoai(txtTimLoai.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            /*List<Xe> tam = */ ch.Them(txtMaXe.Text, txtTenXe.Text, txtLoaiXe.Text, DateTime.Parse(txtNgaySanXuat.Text),long.Parse(txtGia.Text));
            //if (tam == null)
            //{
            //    MessageBox.Show("Trùng mã xe");
            //}
            //else
            //{
            //    ch.ds = tam;
            //    MessageBox.Show("Thêm thành công");
                dtgvXe.DataSource = null;
                dtgvXe.DataSource = ch.ds;
            //}
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ch.Sua(txtMaXe.Text, txtTenXe.Text, txtLoaiXe.Text, DateTime.Parse(txtNgaySanXuat.Text), long.Parse(txtGia.Text));
            dtgvXe.DataSource = null;
            dtgvXe.DataSource = ch.ds;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ch.Xoa(txtMaXe.Text);
            dtgvXe.DataSource = null;
            dtgvXe.DataSource = ch.ds;
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            ch.LuuFile("xe.txt");
            MessageBox.Show("Đã lưu file thành công");
        }
        public static List<Xe> lx;
        private void btnIn_Click(object sender, EventArgs e)
        {
            lx = ch.ds;
            frmInXe f = new frmInXe();
            f.ShowDialog();
        }



    }
}
