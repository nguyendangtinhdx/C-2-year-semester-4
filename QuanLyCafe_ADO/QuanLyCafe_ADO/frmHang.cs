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
    public partial class frmHang : Form
    {
        public frmHang()
        {
            InitializeComponent();
        }
        HangBO hang = new HangBO();
        public static List<HangBEAN> ds, tam = new List<HangBEAN>();
        private void frmHang_Load(object sender, EventArgs e)
        {
            ds = hang.getListHang();
            dtgvHang.DataSource = ds;
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            ds = hang.getListHang();
            dtgvHang.DataSource = ds;
        }

        private void dtgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMaHang.Text = dtgvHang[0, d].Value.ToString();
            txtTenHang.Text = dtgvHang[1, d].Value.ToString();
            txtGia.Text = dtgvHang[2, d].Value.ToString();
            txtSoLuong.Text = dtgvHang[3, d].Value.ToString();
            txtDonViTinh.Text = dtgvHang[4, d].Value.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text == "" || txtTenHang.Text == "" || txtGia.Text == "" || txtSoLuong.Text == "" || txtDonViTinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin hàng");
                return;
            }
            Boolean kq;
            ds = hang.themHang(ds, txtMaHang.Text, txtTenHang.Text, long.Parse(txtGia.Text),long.Parse(txtSoLuong.Text),txtDonViTinh.Text, out kq);
            if (kq == false)
                MessageBox.Show("Trùng mã hàng");
            else
                MessageBox.Show("Thêm hàng thành công");
            dtgvHang.DataSource = null;
            dtgvHang.DataSource = ds;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tam = hang.suaHang(ds, txtMaHang.Text, txtTenHang.Text, long.Parse(txtGia.Text), long.Parse(txtSoLuong.Text), txtDonViTinh.Text);
            if (tam == null)
            {
                MessageBox.Show("Sửa hàng thất bại");
                return;
            }
            else
            {
                ds = tam;
                MessageBox.Show("Sửa hàng thành công");
            }
            dtgvHang.DataSource = null;
            dtgvHang.DataSource = ds;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hàng để xóa");
                return;
            }
            DialogResult t = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hay không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (t == DialogResult.Yes)
            {
                tam = hang.xoaHang(ds, txtMaHang.Text);
                if (tam == null)
                {
                    MessageBox.Show("Xóa hàng thất bại");
                    return;
                }
                else
                {
                    ds = tam;
                    MessageBox.Show("Xóa hàng thành công");
                }
                ds = hang.getListHang();
                dtgvHang.DataSource = ds;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên hàng cần tìm", "Tìm kiếm");

            //tam = ban.timBan(ds, st);
            //dtgvBan.DataSource = tam;

            ds = hang.timHang(ds, st);
            dtgvHang.DataSource = ds;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInHang f = new frmInHang();
            f.ShowDialog();
        }
    }
}
