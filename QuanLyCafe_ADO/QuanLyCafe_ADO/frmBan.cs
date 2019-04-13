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
    public partial class frmBan : Form
    {
        public frmBan()
        {
            InitializeComponent();
        }
        BanBO ban = new BanBO();
        public static List<BanBEAN> ds,tam;
        private void frmBan_Load(object sender, EventArgs e)
        {
            ds = ban.getListBan();
            dtgvBan.DataSource = ds;
        }
        private void dtgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMaBan.Text = dtgvBan[0, d].Value.ToString();
            txtTenBan.Text = dtgvBan[1, d].Value.ToString();
            txtSoGhe.Text = dtgvBan[2, d].Value.ToString();
        }
        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            ds = ban.getListBan();
            dtgvBan.DataSource = ds;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaBan.Text == "" || txtTenBan.Text == "" || txtSoGhe.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin bàn");
                return;
            }
            Boolean kq;
            ds = ban.themBan(ds, txtMaBan.Text, txtTenBan.Text,long.Parse(txtSoGhe.Text), out kq);
            if (kq == false)
                MessageBox.Show("Trùng mã bàn");
            else
                MessageBox.Show("Thêm bàn thành công");
            dtgvBan.DataSource = null;
            dtgvBan.DataSource = ds;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tam = ban.suaBan(ds, txtMaBan.Text, txtTenBan.Text, long.Parse(txtSoGhe.Text));
            if (tam == null)
            {
                MessageBox.Show("Sửa bàn thất bại");
                return;
            }
            else
            {
                ds = tam;
                MessageBox.Show("Sửa bàn thành công");
            }
            dtgvBan.DataSource = null;
            dtgvBan.DataSource = ds;
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaBan.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa");
                return;
            }
            DialogResult t = MessageBox.Show("Bạn có chắc chắn muốn xóa bàn hay không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (t == DialogResult.Yes)
            {
                tam = ban.xoaBan(ds, txtMaBan.Text);
                if (tam == null)
                {
                    MessageBox.Show("Xóa bàn thất bại");
                    return;
                }
                else
                {
                    ds = tam;
                    MessageBox.Show("Xóa bàn thành công");
                }
                ds = ban.getListBan();
                dtgvBan.DataSource = ds;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên bàn cần tìm", "Tìm kiếm");

            //tam = ban.timBan(ds, st);
            //dtgvBan.DataSource = tam;

            ds = ban.timBan(ds, st);
            dtgvBan.DataSource = ds;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInBan f = new frmInBan();
            f.ShowDialog();
        }

    }
}
