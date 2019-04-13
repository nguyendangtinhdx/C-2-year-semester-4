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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public static List<NHanVien> ds = new List<NHanVien>();
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            CauHinh ch = new CauHinh();
            bindingSource1.DataSource = CauHinh.db.NHanViens;
            dataGridView1.DataSource = bindingSource1;
            ds = CauHinh.db.NHanViens.ToList();
            txtMaNhanVien.DataBindings.Add("Text", bindingSource1, "Manv");
            txtHoTen.DataBindings.Add("Text", bindingSource1, "HoTen");
            txtDiaChi.DataBindings.Add("Text", bindingSource1, "DiaChi");
            txtMatKhau.DataBindings.Add("Text", bindingSource1, "MatKhau");
            txtQuyen.DataBindings.Add("Text", bindingSource1, "Quyen");
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            bindingSource1.AddNew(); //Tạo mới 1 dòng trong bindingSource1    
            //Khi đó dataGridView1 sẽ tạo thêm 1 dòng mới  
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hay không ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                bindingSource1.RemoveCurrent(); //Xóa dòng hiện tại
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
            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã nhân viên: ", "Tìm kiếm", "", 100, 300);
            var q = from p in CauHinh.db.NHanViens
                    where p.Manv == st
                    select p;
            if (q.Count() == 0)
                MessageBox.Show("Không tìm thấy");
            else
                bindingSource1.DataSource = q;
            ds = q.ToList();
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = CauHinh.db.NHanViens;
            dataGridView1.DataSource = bindingSource1;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInNhaVien f = new frmInNhaVien();
            f.ShowDialog();
        }
    }
}
