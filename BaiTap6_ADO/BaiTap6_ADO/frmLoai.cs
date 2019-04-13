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
    public partial class frmLoai : Form
    {
        public frmLoai()
        {
            InitializeComponent();
        }
        public static List<Model.LoaiBean> ds,tam;
        LoaiBo loai = new LoaiBo();
        private void frmLoai_Load(object sender, EventArgs e)
        {
            ds = loai.getLoai();
            dataGridView1.DataSource = ds;
            //txtMaLoai.DataBindings.Add("Text", ds, "MaLoai");
            //txtTenLoai.DataBindings.Add("Text", ds, "TenLoai");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Boolean kq;
            ds = loai.themLoai(ds, txtMaLoai.Text, txtTenLoai.Text, out kq);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds;
            //if (LoaiBo.check == false)
            if (kq == false)
                MessageBox.Show("Trùng mã loại");
            else
                MessageBox.Show("Thêm thành công");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tam = loai.suaLoai(ds, txtMaLoai.Text, txtTenLoai.Text);
            if (tam == null)
            {
                MessageBox.Show("Sửa thất bại");
                frmLoai.ActiveForm.Close();
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
            //if (MessageBox.Show("Bạn có chắc chắn muốn xóa hay không","Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) // nếu nhấn OK

            DialogResult t = MessageBox.Show("Bạn có chắc chắn muốn xóa hay không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (t == DialogResult.Yes)
            {
                tam = loai.xoaLoai(ds, txtMaLoai.Text);
                if (tam == null)
                {
                    MessageBox.Show("Xóa thất bại");
                    frmLoai.ActiveForm.Close();
                }
                else
                {
                    ds = tam;
                    MessageBox.Show("Xóa thành công");
                }
                ds = loai.getLoai();
                dataGridView1.DataSource = ds;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên sách cần tìm","Tìm kiếm");
            //tam = loai.timLoai(ds,st);
            //dataGridView1.DataSource = tam;
            ds = loai.timLoai(ds, st);
            dataGridView1.DataSource = ds;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInLoai f = new frmInLoai();
            f.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMaLoai.Text = dataGridView1[0, d].Value.ToString();
            txtTenLoai.Text = dataGridView1[1, d].Value.ToString();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.ShowDialog();
            of.Filter = "txt file|*.txt";
        }
    }
}
