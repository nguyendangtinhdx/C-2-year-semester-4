using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenDangTinh
{
    public partial class InCuaHang : Form
    {
        public InCuaHang()
        {
            InitializeComponent();
        }

        private void InCuaHang_Load(object sender, EventArgs e)
        {
        
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("cuahang", QuanLyCuaHang.ds));
            
            this.reportViewer1.RefreshReport();
        }
    }
}
