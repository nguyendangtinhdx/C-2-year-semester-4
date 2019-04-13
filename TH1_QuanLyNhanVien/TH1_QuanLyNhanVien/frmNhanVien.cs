using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH1_QuanLyNhanVien
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        dbDataContext db = new dbDataContext();
        NhanVien TimManv(String manv) //Tìm kiếm nhân viên theo mã nhân viên nhập ở txtmanv 
        {
            var q = from p in db.NhanViens
                    where p.Manv == txtMaNhanVien.Text
                    select p;
            if(q.Count() == 1) // nếu tìm thấy
                return (NhanVien)q.First(); //Trả về nhân viên đầu tiên
            else 
                return null; //Nếu không tìm thấy 
        }
      
        void NapDuLieu()
        {
            dbDataContext db = new dbDataContext();
            dtgvNhanVien.DataSource = db.NhanViens;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            NapDuLieu();

            txtMaNhanVien.DataBindings.Add("Text", dtgvNhanVien.DataSource,"Manv");
            txtHoTen.DataBindings.Add("Text", dtgvNhanVien.DataSource, "HoTen");
            txtDiaChi.DataBindings.Add("Text", dtgvNhanVien.DataSource, "DiaChi");
            txtMatKhau.DataBindings.Add("Text", dtgvNhanVien.DataSource, "MatKhau");
            txtQuyen.DataBindings.Add("Text", dtgvNhanVien.DataSource, "Quyen");
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (TimManv(txtMaNhanVien.Text) == null) // nếu không trùng mã
            {
                //Tạo ra 1 lớp NhanVien
                NhanVien nv = new NhanVien();
                nv.Manv = txtMaNhanVien.Text;
                nv.HoTen = txtHoTen.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.MatKhau = txtMatKhau.Text;
                nv.Quyen = txtQuyen.Text;
                //Nhập vào 1 nhân viên 
                db.NhanViens.InsertOnSubmit(nv);
                db.SubmitChanges();// lưu vào DB
                NapDuLieu();
            }
            else
                MessageBox.Show("Trùng mã nhân viên");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (TimManv(txtMaNhanVien.Text) == null)
                MessageBox.Show("Không tìm thấy nhân viên");
            else
            {
                NhanVien nv = db.NhanViens.Single(p => p.Manv == txtMaNhanVien.Text);
                db.NhanViens.DeleteOnSubmit(nv);
                db.SubmitChanges();
                NapDuLieu();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVien nv = TimManv(txtMaNhanVien.Text); // tìm nhân viên
            if(nv == null)
                MessageBox.Show("Không tìm thấy nhân viên");
            else
            {
                nv.HoTen = txtHoTen.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.MatKhau = txtMatKhau.Text;
                nv.Quyen = txtQuyen.Text;

                db.SubmitChanges();
                NapDuLieu();
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //NhanVien nv = TimManv(txtMaNhanVien.Text);
            //if (nv == null)
            //    MessageBox.Show("Không tìm thấy");
            //else
            //{
            //    txtMaNhanVien.Text = nv.Manv;
            //    txtHoTen.Text = nv.HoTen;
            //    txtDiaChi.Text = nv.DiaChi;
            //    txtMatKhau.Text = nv.MatKhau;
            //    txtQuyen.Text = nv.Quyen;
            //}

            //Nhập mã nhân viên cần tìm 
            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã nhân viên:", "Tìm Kiếm", "");
            //Sử dụng câu lẹnh LINQ đề tìm nhân viên 
            var q = from p in db.NhanViens
                    where p.Manv == st
                    select p;
            if (q.Count() == 0)
                MessageBox.Show("Không tìm thấy");
            else
                dtgvNhanVien.DataSource = q;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInNhanVien f = new frmInNhanVien();
            f.Show();
        }
    }
}
