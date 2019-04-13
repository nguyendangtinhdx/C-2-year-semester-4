using QuanLySach_BaiTap3.DAO;
using QuanLySach_BaiTap3.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace QuanLySach_BaiTap3
{
    public partial class frmSach : Form
    {
        BindingSource sachList = new BindingSource();
        public frmSach()
        {
            
            InitializeComponent();
            LoadListSach();
            Load();
            
        }

        List<Sach> SearchSachByName(string tenSach)
        {
            List<Sach> listSach = SachDAO.Instance.SearchSach(tenSach);
            return listSach;
        }
        
        void Load() 
        {
            dtgvSach.DataSource = sachList;
            
            AddSachBinding();
        }

        void LoadListSach()
        {
            sachList.DataSource = SachDAO.Instance.GetListSach();
        }
        void AddSachBinding()
        {
            txtMaSach.DataBindings.Add(new Binding("Text", dtgvSach.DataSource, "MaSach",true,DataSourceUpdateMode.Never));
            txtTenSach.DataBindings.Add(new Binding("Text", dtgvSach.DataSource, "TenSach", true, DataSourceUpdateMode.Never));
            txtTacGia.DataBindings.Add(new Binding("Text", dtgvSach.DataSource, "TacGia", true, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", dtgvSach.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
            txtGia.DataBindings.Add(new Binding("Text", dtgvSach.DataSource, "Gia", true, DataSourceUpdateMode.Never));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text;
            string tenSach = txtTenSach.Text;
            string tacGia = txtTacGia.Text;
            int soLuong = Convert.ToInt32(txtSoLuong.Text);
            float gia = Convert.ToInt32(txtGia.Text);
            if (SachDAO.Instance.InsertSach(maSach,tenSach,tacGia,soLuong,gia))
            {
                MessageBox.Show("Thêm sách thành công");
                LoadListSach();
            }
            else
            {
                MessageBox.Show("Thêm sách thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenSach = txtTenSach.Text;
            string tacGia = txtTacGia.Text;
            int soLuong = Convert.ToInt32(txtSoLuong.Text);
            float gia = Convert.ToInt32(txtGia.Text);
            string maSach = txtMaSach.Text;
            if (SachDAO.Instance.UpdateSach(maSach,tenSach,tacGia,soLuong,gia))
            {
                MessageBox.Show("Cập nhật sách thành công");
                LoadListSach();
            }
            else
            {
                MessageBox.Show("Cập nhật sách thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSach = txtMaSach.Text;
            if (SachDAO.Instance.DeleteSach(maSach))
            {
                MessageBox.Show("Xóa sách thành công");
                LoadListSach();
            }
            else
            {
                MessageBox.Show("Xóa sách thất bại");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtSoLuong.Text = "";
            txtGia.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            sachList.DataSource = SearchSachByName(txtTimKiem.Text);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadListSach();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReport fr = new frmReport();
            fr.ShowDialog();
        }

        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter("data.txt", true);
            f.WriteLine(txtMaSach.Text);
            f.WriteLine(txtTenSach.Text);
            f.WriteLine(txtTacGia.Text);
            f.WriteLine(txtSoLuong.Text);
            f.WriteLine(txtGia.Text);
            MessageBox.Show("Ghi file thành công");
            f.Close();
        }
    }
}
