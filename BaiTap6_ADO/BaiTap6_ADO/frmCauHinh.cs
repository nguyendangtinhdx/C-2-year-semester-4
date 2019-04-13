using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTap6_ADO.Model;
namespace BaiTap6_ADO
{
    public partial class frmCauHinh : Form
    {
        public frmCauHinh()
        {
            InitializeComponent();
        }
        //Model.DungChung db = new Model.DungChung();
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                DungChung dc = new DungChung();
                dc.KetNoi(txtServer.Text,txtDatabase.Text,txtUsername.Text,txtPassword.Text);
                frmDangNhap f = new frmDangNhap();
                this.Hide();
                f.ShowDialog();
            }
            catch (Exception tt)
            {
                MessageBox.Show(tt.Message);
            }
           
        }
    }
}
