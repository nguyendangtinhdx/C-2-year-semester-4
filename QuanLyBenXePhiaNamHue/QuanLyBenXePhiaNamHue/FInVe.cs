using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBenXePhiaNamHue
{
    public partial class FInVe : Form
    {
        public FInVe()
        {
            InitializeComponent();
        }

        private void FInVe_Load(object sender, EventArgs e)
        {
            this.USP_InVeTableAdapter.Fill(this.QuanlybenxephianamDataSet.USP_InVe, FMenu.getmavemax);
            this.reportViewer1.RefreshReport();
        }
    }
}
