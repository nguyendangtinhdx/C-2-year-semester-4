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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        NhanVienBO nhanVien = new NhanVienBO();
        public static List<NhanVienBEAN> ds, tam = new List<NhanVienBEAN>();
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ds = nhanVien.getListNhanVien();
            dtgvNhanVien.DataSource = ds;
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMaNhanVien.Text = dtgvNhanVien[0, d].Value.ToString();
            txtHoTen.Text = dtgvNhanVien[1, d].Value.ToString();
            txtDiaChi.Text = dtgvNhanVien[2, d].Value.ToString();
            txtMatKhau.Text = dtgvNhanVien[3, d].Value.ToString();
            cbbQuyen.Text = dtgvNhanVien[4, d].Value.ToString();
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            ds = nhanVien.getListNhanVien();
            dtgvNhanVien.DataSource = ds;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "" || txtMatKhau.Text == "" || cbbQuyen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin nhân viên");
                return;
            }
            Boolean kq;
            ds = nhanVien.themNhanVien(ds, txtMaNhanVien.Text, txtHoTen.Text, txtDiaChi.Text,MaHoaMD5.MaHoa(txtMatKhau.Text,txtMatKhau.Text),cbbQuyen.Text, out kq);
            if (kq == false)
                MessageBox.Show("Trùng mã nhân viên");
            else
                MessageBox.Show("Thêm nhân viên thành công");
            dtgvNhanVien.DataSource = null;
            dtgvNhanVien.DataSource = ds;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tam = nhanVien.suaNhanVien(ds, txtMaNhanVien.Text, txtHoTen.Text, txtDiaChi.Text, MaHoaMD5.MaHoa(txtMatKhau.Text, txtMatKhau.Text), cbbQuyen.Text);
            if (tam == null)
            {
                MessageBox.Show("Sửa nhân viên thất bại");
                return;
            }
            else
            {
                ds = tam;
                MessageBox.Show("Sửa nhân viên thành công");
            }
            dtgvNhanVien.DataSource = null;
            dtgvNhanVien.DataSource = ds;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa");
                return;
            }
            DialogResult t = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên hay không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (t == DialogResult.Yes)
            {
                tam = nhanVien.xoaNhanVien(ds, txtMaNhanVien.Text);
                if (tam == null)
                {
                    MessageBox.Show("Xóa nhân viên thất bại");
                    return;
                }
                else
                {
                    ds = tam;
                    MessageBox.Show("Xóa nhân viên thành công");
                }
                ds = nhanVien.getListNhanVien();
                dtgvNhanVien.DataSource = ds;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên nhân viên cần tìm", "Tìm kiếm");

            //tam = ban.timBan(ds, st);
            //dtgvBan.DataSource = tam;

            ds = nhanVien.timNhanVien(ds, st);
            dtgvNhanVien.DataSource = ds;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInNhanVien f = new frmInNhanVien();
            f.ShowDialog();
        }


    }
}
