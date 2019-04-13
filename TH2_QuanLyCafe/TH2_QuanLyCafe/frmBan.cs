using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH2_QuanLyCafe
{
    public partial class frmBan : Form
    {
        public frmBan()
        {
            InitializeComponent();
        }
        public static List<Ban> ds = new List<Ban>();
        private void frmBan_Load(object sender, EventArgs e)
        {
            CauHinh ch = new CauHinh();
            bindingSource1.DataSource = CauHinh.db.Bans;
            dataGridView1.DataSource = bindingSource1;
            ds = CauHinh.db.Bans.ToList();
            txtMaBan.DataBindings.Add("Text", bindingSource1, "MaBan");
            txtTenBan.DataBindings.Add("Text", bindingSource1, "TenBan");
            txtSoGhe.DataBindings.Add("Text", bindingSource1, "SoGhe");
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            bindingSource1.AddNew();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hay không ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                bindingSource1.RemoveCurrent();
                CauHinh.db.SubmitChanges();
                MessageBox.Show("Xóa thành công");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource1.EndEdit();
                CauHinh.db.SubmitChanges();
                MessageBox.Show("Lưu thành công");   
            }
            catch (Exception tt)
            {
                MessageBox.Show("Lưu thất bại");   
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên bàn: ", "Tìm kiếm", "", 100, 300);
            var q = from p in CauHinh.db.Bans
                    where p.TenBan == st
                    select p;
            if (q.Count() == 0)
                MessageBox.Show("Không tìm thấy");
            else
                bindingSource1.DataSource = q;
            ds = q.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int d = e.RowIndex;
            //if (dataGridView1[0, d].Value != null)
            //    txtMaBan.Text = dataGridView1[0, d].Value.ToString();
            //else
            //    txtMaBan.Text = "";
            //if (dataGridView1[1, d].Value != null)
            //    txtTenBan.Text = dataGridView1[1, d].Value.ToString();
            //else
            //    txtTenBan.Text = "";
            //if (dataGridView1[2, d].Value != null)
            //    txtSoGhe.Text = dataGridView1[2, d].Value.ToString();
            //else
            //    txtSoGhe.Text = "";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInBan f = new frmInBan();
            f.ShowDialog();
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = CauHinh.db.Bans;
            dataGridView1.DataSource = bindingSource1;
        }


    }
}
