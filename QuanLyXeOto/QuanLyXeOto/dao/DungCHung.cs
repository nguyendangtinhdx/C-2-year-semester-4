using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace QuanLyXeOto.dao
{
    public class DungChung
    {
        public static SqlConnection cn;
        public void KetNoi()
        {
            string st = @"Data Source=DESKTOP-264SA00\SQLEXPRESS;Initial Catalog=QuanLyXe;Integrated Security=True";
            cn = new SqlConnection(st);
            cn.Open();
        }
    }
}
