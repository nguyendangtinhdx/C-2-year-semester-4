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
    public partial class frmNhapXoaSua : Form
    {
        public frmNhapXoaSua()
        {
            InitializeComponent();
        }
        CuaHang ch = new CuaHang();
        private void frmNhapXoaSua_Load(object sender, EventArgs e)
        {
            dgvSach.DataSource = ch.ds;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<Sach> tam = ch.Add(ch.ds,txtMaSach.Text,txtTenSach.Text,txtTacGia.Text,long.Parse(txtGia.Text));
            if (tam == null)
                MessageBox.Show("Trùng mã");
            else
            {
                ch.ds = tam;
                MessageBox.Show("Thêm thành công");
                dgvSach.DataSource = null;
                dgvSach.DataSource = ch.ds;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // mở file ra để đọc
            StreamWriter f = new StreamWriter("data1.txt",true); // true (ghi bổ sung)
            f.WriteLine("c");
            f.WriteLine("d");
            f.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string st =  Microsoft.VisualBasic.Interaction.InputBox("Nhập tên sách cần tìm", "Tìm kiếm", ""); // mượn thuốc tính trong visual basic để hiển thị hộp tìm kiếm
            MessageBox.Show(st);
        }
    }
}
