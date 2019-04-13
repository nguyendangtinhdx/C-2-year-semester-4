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
    public partial class frmHang : Form
    {
        public frmHang()
        {
            InitializeComponent();
        }
        public static List<Hang> ds = new List<Hang>();
        private void frmHang_Load(object sender, EventArgs e)
        {
            CauHinh ch = new CauHinh();
            bindingSource1.DataSource = CauHinh.db.Hangs;
            dataGridView1.DataSource = bindingSource1;
            ds = CauHinh.db.Hangs.ToList();
            txtMaHang.DataBindings.Add("Text", bindingSource1, "MaHang");
            txtTenHang.DataBindings.Add("Text", bindingSource1, "TenHang");
            txtGia.DataBindings.Add("Text", bindingSource1, "Gia");
            txtSoLuong.DataBindings.Add("Text", bindingSource1, "SoLuong");
            txtDonViTinh.DataBindings.Add("Text", bindingSource1, "DonViTinh");
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
            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên hàng: ", "Tìm kiếm", "", 100, 300);
            var q = from p in CauHinh.db.Hangs
                    where p.TenHang == st
                    select p;
            if (q.Count() == 0)
                MessageBox.Show("Không tìm thấy");
            else
                bindingSource1.DataSource = q;
            ds = q.ToList();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInHang f = new frmInHang();
            f.ShowDialog();
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = CauHinh.db.Hangs;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
