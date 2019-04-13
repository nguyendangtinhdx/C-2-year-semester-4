using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BaiTap6_ADO.Model
{
    public class DungChung
    {
        public static SqlConnection cn;
        public void KetNoi(string server, string database, string username, string password)
        {

            string st = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server, database, username, password);
            //string st = @"Data Source=DESKTOP-264SA00\SQLEXPRESS;Initial Catalog=QlSach;Persist Security Info=True;User ID=sa;Password=55555";
            cn = new SqlConnection(st);
            cn.Open();
        }
    }
}
