using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace QuanLyCafe_ADO.dao
{
    public class DungChung
    {
        public static SqlConnection cn;
        public void KetNoi2()
        {
            string st = @"Data Source=.\SQLEXPRESS;Initial Catalog=Qlcafe;Integrated Security=True";
            cn = new SqlConnection(st);
            cn.Open();
        }
        public void KetNoi(string server, string database, string username, string password)
        {
            string st = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server, database, username, password);
            cn = new SqlConnection(st);
            cn.Open();
        }
    }
}
