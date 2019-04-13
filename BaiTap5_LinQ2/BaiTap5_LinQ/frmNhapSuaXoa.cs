using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap5_LinQ
{
    public partial class frmNhapSuaXoa : Form
    {
        dbDataContext db = new dbDataContext();
        BO.SachBO sach = new BO.SachBO();
        BO.LoaiBO loai = new BO.LoaiBO();
        public frmNhapSuaXoa()
        {
            InitializeComponent();
        }
        
        private void frmNhapSuaXoa_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = loai.getLoai();
            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "MaLoai";
            String maLoai = comboBox1.SelectedValue.ToString();
            dataGridView1.DataSource = sach.getSach(maLoai);

            //txtMaSach.DataBindings.Add("Text", dataGridView1.DataSource, "MaSach");
            //txtTenSach.DataBindings.Add("Text", dataGridView1.DataSource, "TenSach");
            //txtTacGia.DataBindings.Add("Text", dataGridView1.DataSource, "TacGia");
            //txtGia.DataBindings.Add("Text", dataGridView1.DataSource, "Gia");
            //txtSoLuong.DataBindings.Add("Text", dataGridView1.DataSource, "SoLuong");
            //txtSoTap.DataBindings.Add("Text", dataGridView1.DataSource, "SoTap");
            //dateTimePicker1.DataBindings.Add("Text", dataGridView1.DataSource, "NgayNhap");
            //comboBox1.DataBindings.Add("Text", dataGridView1.DataSource, "MaLoai");
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String maLoai = comboBox1.SelectedValue.ToString();
            dataGridView1.DataSource = sach.getSach(maLoai);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                String maLoai = comboBox1.SelectedValue.ToString();
                Boolean kt = sach.Them(txtMaSach.Text, txtTenSach.Text, txtTacGia.Text, long.Parse(txtSoLuong.Text), long.Parse(txtGia.Text), txtSoTap.Text, dateTimePicker1.Value, maLoai);
                if (kt) MessageBox.Show("Thêm sách thành công");
                else MessageBox.Show("Trùng mã sách, vui lòng nhập lại");
                dataGridView1.DataSource = sach.getSach(maLoai);
            }
            catch (Exception tt)
            {
                MessageBox.Show(tt.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMaSach.Text = dataGridView1[0,d].Value.ToString();
            if (dataGridView1[1, d].Value != null)
                txtTenSach.Text = dataGridView1[1, d].Value.ToString();
            else
                txtTenSach.Text = "";
            txtTacGia.Text = dataGridView1[2, d].Value.ToString();
            txtGia.Text = dataGridView1[3, d].Value.ToString();
            txtSoLuong.Text = dataGridView1[4, d].Value.ToString();
            if (dataGridView1[5, d].Value != null)
                txtSoTap.Text = dataGridView1[5, d].Value.ToString();
            else
                txtSoTap.Text = "";
            dateTimePicker1.Value = (DateTime)dataGridView1["NgayNhap",d].Value;
           

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String maLoai = comboBox1.SelectedValue.ToString();
            sach.Sua(txtMaSach.Text, txtTenSach.Text, txtTacGia.Text, long.Parse(txtSoLuong.Text), long.Parse(txtGia.Text), txtSoTap.Text, dateTimePicker1.Value, maLoai);
            dataGridView1.DataSource = sach.getSach(maLoai);
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) // nếu nhấn OK
            {
                String maLoai = comboBox1.SelectedValue.ToString();
                sach.Xoa(txtMaSach.Text);
                dataGridView1.DataSource = sach.getSach(maLoai);
            }
        }

        private void btnNangGia_Click(object sender, EventArgs e)
        {
            string gia = Microsoft.VisualBasic.Interaction.InputBox("Nhập giá tăng thêm", "Thông báo", "0");
            String maLoai = comboBox1.SelectedValue.ToString();
            sach.NangGia(maLoai,long.Parse(gia));
            dataGridView1.DataSource = sach.getSach(maLoai);
        }
    }
}
