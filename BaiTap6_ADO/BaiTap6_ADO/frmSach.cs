using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTap6_ADO.BO;
namespace BaiTap6_ADO
{
    public partial class frmSach : Form
    {
        public frmSach()
        {
            InitializeComponent();
        }
        public static List<Model.SachBean> ds, tam;
        SachBo sach = new SachBo();
        LoaiBo loai = new LoaiBo();
        private void frmSach_Load(object sender, EventArgs e)
        {
            ds = sach.getSach();
            dataGridView1.DataSource = ds;

            cbbLoaiSach.DataSource = loai.getLoai();
            cbbLoaiSach.DisplayMember = "tenloai";
            cbbLoaiSach.ValueMember = "maloai";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMaSach.Text = dataGridView1[0, d].Value.ToString();
            txtTenSach.Text = dataGridView1[1, d].Value.ToString();
            txtTacGia.Text = dataGridView1[2, d].Value.ToString();
            txtSoLuong.Text = dataGridView1[3, d].Value.ToString();
            txtGia.Text = dataGridView1[4, d].Value.ToString();
            txtSoTap.Text = dataGridView1[5, d].Value.ToString();
            txtAnh.Text = dataGridView1[6, d].Value.ToString();
            cbbLoaiSach.Text = dataGridView1[7, d].Value.ToString();
            dtpkNgayNhap.Text = dataGridView1[8, d].Value.ToString();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Boolean kq;
            ds = sach.themSach(ds, txtMaSach.Text, txtTenSach.Text,txtTacGia.Text,long.Parse(txtSoLuong.Text),long.Parse(txtGia.Text),txtSoTap.Text,txtAnh.Text,cbbLoaiSach.SelectedValue.ToString(),DateTime.Now, out kq);
            //if (LoaiBo.check == false)
            if (kq == false)
                MessageBox.Show("Trùng mã sách");
            else
                MessageBox.Show("Thêm thành công");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tam = sach.suaSach(ds, txtMaSach.Text, txtTenSach.Text, txtTacGia.Text,long.Parse(txtSoLuong.Text),long.Parse(txtGia.Text), txtSoTap.Text, txtAnh.Text, cbbLoaiSach.SelectedValue.ToString(), dtpkNgayNhap.Value);
            if (tam == null)
            {
                MessageBox.Show("Sửa thất bại");
                frmSach.ActiveForm.Close();
            }
            else
            {
                ds = tam;
                MessageBox.Show("Sửa thành công");
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult t = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo);
            if(t == DialogResult.Yes)
            {
                tam = sach.xoaSach(ds, txtMaSach.Text);
                if(tam == null)
                {
                    MessageBox.Show("Xóa thất bại");
                    frmSach.ActiveForm.Close();
                }
                else
                {
                    ds = tam;
                    MessageBox.Show("Xóa thàng công");
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ds;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên sách hoặc tác giả muốn tìm", "Tìm kiếm");
            //tam = sach.timSach(ds,st);
            //dataGridView1.DataSource = tam;
            ds = sach.timSach(ds, st);
            dataGridView1.DataSource = ds;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInSach f = new frmInSach();
            f.ShowDialog();
        }

        private void btnImportAnh_Click(object sender, EventArgs e)
        {
            frmUpPicture f = new frmUpPicture();
            f.ShowDialog();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = (@"C:\Users\nguye\Documents\Visual Studio 2013\Projects\BaiTap6_ADO\BaiTap6_ADO\image_sach");//Định đường dẫn khi mở cửa sổ tìm ảnh
            openFileDialog1.FileName = "";// Tên ảnh
            openFileDialog1.Filter = "Images(*.jpg)|*.jpg|PNG (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();// Hiện cửa sổ 
            if (openFileDialog1.FileName != "")
            {
                txtAnh.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);// Hiển thị tên ảnh lên Textbox
            }
        }

       
    }
}
