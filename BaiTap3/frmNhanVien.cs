using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BaiTap3
{
    public partial class frmNhanVien : Form
    {
        ThongTinNhanVien tt = new ThongTinNhanVien();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public static List<NhanVien> tam; // in
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dtgvNhanVien.DataSource = tt.ds;

            cbNhanVien.DataSource = tt.ds;
            cbNhanVien.DisplayMember = "TenNhanVien";
            cbNhanVien.ValueMember = "Tuoi";

            lbNhanVien.DataSource = tt.ds;
            lbNhanVien.DisplayMember = "TenNhanVien";

            txtMaNhanVien.DataBindings.Add("Text", tt.ds, "MaNhanVien");
            txtTenNhanVien.DataBindings.Add("Text", tt.ds, "TenNhanVien");
            txtDiaChi.DataBindings.Add("Text", tt.ds, "DiaChi");
            txtTuoi.DataBindings.Add("Text", tt.ds, "Tuoi");
            txtSDT.DataBindings.Add("Text", tt.ds, "SDT");

            tam = tt.ds;
        }

        private void btnShowTuoiNhanVien_Click(object sender, EventArgs e)
        {
            string maNhanVien = cbNhanVien.SelectedValue.ToString();
            MessageBox.Show(maNhanVien);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            List<NhanVien> list = tt.Add(tt.ds, txtMaNhanVien.Text, txtTenNhanVien.Text, txtDiaChi.Text, int.Parse(txtTuoi.Text), long.Parse(txtSDT.Text));
            if (list == null)
            {
                MessageBox.Show("Trùng mã nhân viên");
            }
            else
            {
                tt.ds = list;
                MessageBox.Show("Thêm thành công");
                dtgvNhanVien.DataSource = null;
                dtgvNhanVien.DataSource = tt.ds;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmIn f = new frmIn();
            f.ShowDialog();
        }
        public static string tukhoa = "Khong co tu khoa";
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            //string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên nhân viên cần tìm", "Tìm kiếm", "");

            string st = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên nhân viên cần tìm", "Tìm kiếm", "");
            List<NhanVien> ds = tt.Search(tt.ds, st);
            dtgvNhanVien.DataSource = null;
            dtgvNhanVien.DataSource = ds;

            tukhoa = st;
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int row = dtgvNhanVien.CurrentRow.Index;
            tt.ds.RemoveAt(row);
            dtgvNhanVien.DataSource = null;
            dtgvNhanVien.DataSource = tt.ds;
            //SaveToFile();
            StreamWriter f = new StreamWriter("BaiTap3.txt", false);
            foreach (NhanVien s in tt.ds)
            {
                f.WriteLine(s.MaNhanVien + ";" + s.TenNhanVien + ";" + s.DiaChi + ";" + s.Tuoi + ";" + s.Sdt);
            }
            f.Close();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int row = dtgvNhanVien.CurrentRow.Index;
            dtgvNhanVien[0, row].Value = txtMaNhanVien.Text;
            dtgvNhanVien[1, row].Value = txtTenNhanVien.Text;
            dtgvNhanVien[2, row].Value = txtDiaChi.Text;
            dtgvNhanVien[3, row].Value = txtTuoi.Text;
            dtgvNhanVien[4, row].Value = txtSDT.Text;
            //SaveToFile();
            StreamWriter f = new StreamWriter("BaiTap3.txt", false);
            foreach(NhanVien s in tt.ds)
            {
                f.WriteLine(s.MaNhanVien + ";" + s.TenNhanVien + ";" + s.DiaChi + ";"+ s.Tuoi + ";"+ s.Sdt);
            }
            f.Close();
        }

        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter("BaiTap3.txt", true);
            f.WriteLine(txtMaNhanVien.Text);
            f.WriteLine(txtTenNhanVien.Text);
            f.WriteLine(txtDiaChi.Text);
            f.WriteLine(txtTuoi.Text);
            f.WriteLine(txtSDT.Text);
            MessageBox.Show("Ghi file thành công");
            f.Close();
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaNhanVien.Text = dtgvNhanVien[0, row].Value.ToString();
            txtTenNhanVien.Text = dtgvNhanVien[1, row].Value.ToString();
            txtDiaChi.Text = dtgvNhanVien[2, row].Value.ToString();
            txtTuoi.Text = dtgvNhanVien[3, row].Value.ToString();
            txtSDT.Text = dtgvNhanVien[4, row].Value.ToString();
        }
         
    }
}
