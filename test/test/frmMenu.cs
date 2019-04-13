using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.bean;
using test.bo;
using test.dao;
namespace test
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        public static List<DangNhapBEAN> ds, tam;
        DangNhapBO dangNhap = new DangNhapBO();
        DungChung dc = new DungChung();
        private void frmMenu_Load(object sender, EventArgs e)
        {
            dc.KetNoi();
            ds = dangNhap.getListDangNhap();
            dataGridView1.DataSource = ds;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtTaiKhoan.Text = dataGridView1[0, d].Value.ToString();
            txtMatKhau.Text = dataGridView1[1, d].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin");
                return;
            }
            Boolean kq;
            ds = dangNhap.themDangNhap(ds, txtTaiKhoan.Text, txtMatKhau.Text, out kq);
            if (kq == false)
                MessageBox.Show("Tài khoản đã tồn tại");
            else
                MessageBox.Show("Thêm tài khoản thành công");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Enabled = false;
            tam = dangNhap.suaDangNhap(ds, txtTaiKhoan.Text, txtMatKhau.Text);
            if (tam == null)
            {
                MessageBox.Show("Sửa tài khoản thất bại");
                return;
            }
            else
            {
                ds = tam;
                MessageBox.Show("Sửa tài khoản thành công");
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa");
                return;
            }
            DialogResult t = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản hay không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (t == DialogResult.Yes)
            {
                tam = dangNhap.xoaDangNhap(ds, txtTaiKhoan.Text);
                if (tam == null)
                {
                    MessageBox.Show("Xóa tài khoản thất bại");
                    return;
                }
                else
                {
                    ds = tam;
                    MessageBox.Show("Xóa tài khoản thành công");
                }
                ds = dangNhap.getListDangNhap();
                dataGridView1.DataSource = ds;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập tài khoản cần tìm", "Tìm kiếm");


            ds = dangNhap.timDangNhap(ds, st);
            dataGridView1.DataSource = ds;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmIn f = new frmIn();
            f.ShowDialog();
        }
    }
}


