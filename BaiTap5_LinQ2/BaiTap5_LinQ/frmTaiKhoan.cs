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
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        BO.DangNhapBO dn = new BO.DangNhapBO();
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dn.getList();
            txtTenTaiKhoan.DataBindings.Add("Text", dataGridView1.DataSource, "TenDangNhap");
            txtMatKhau.DataBindings.Add("Text", dataGridView1.DataSource, "MatKhau");
            cbQuyen.DataBindings.Add("Text", dataGridView1.DataSource, "Quyen");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                dn.Xoa(txtTenTaiKhoan.Text);
                dataGridView1.DataSource = dn.getList();
            }
        }
    }
}
