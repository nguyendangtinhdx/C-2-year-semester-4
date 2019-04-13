using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap3
{
    public partial class frmSach : Form
    {
        public frmSach()
        {
            InitializeComponent();
        }
        CuaHang ch = new CuaHang();
        private void Form1_Load(object sender, EventArgs e)
        {

            //Sach s1 = new Sach("s1", "Cấu trúc dữ liệu", "KK", 100);
            //Sach s2 = new Sach("s2", "Cấu trúc dữ liệu", "KK", 100);
            //s1.Masach = "s2";
            //MessageBox.Show(s1.Masach);
            //s2.Masach = "aaa";
            //s1.Masach = ? (aaa)

            // nạp dữ liệu ra dataGridView
            dgvSach.DataSource = ch.ds;

            // buộc dữ liệu vào Combobox
            comboBox1.DataSource = ch.ds;
            comboBox1.DisplayMember = "Tensach";
            comboBox1.ValueMember = "Masach"; // show mã

            // buộc dữ liệu vào listBox
            listBox1.DataSource = ch.ds;
            listBox1.DisplayMember = "Tensach";

            // buộc dữ lieju vào textbox
            txtMaSach.DataBindings.Add("Text", ch.ds, "Masach");
            txtTenSach.DataBindings.Add("Text", ch.ds, "Tensach");
            txtTacGia.DataBindings.Add("Text", ch.ds, "Tacgia");
            txtGia.DataBindings.Add("Text", ch.ds, "Gia");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // lấy giá trị (Value) trên combobox
            string masach = comboBox1.SelectedValue.ToString();
            MessageBox.Show(masach);
        }
    }
}
