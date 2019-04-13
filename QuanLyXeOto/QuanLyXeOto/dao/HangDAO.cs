using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyXeOto.bean;
using System.Data.SqlClient;
namespace QuanLyXeOto.dao
{
    public class HangDAO
    {
        public List<HangBEAN> getListHang()
        {
            string sql = "SELECT * FROM Hang";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<HangBEAN> ds = new List<HangBEAN>();
            while (rs.Read())
            {
                string maHang = rs["MaHang"].ToString();
                string tenHang = rs["TenHang"].ToString();
                HangBEAN ban = new HangBEAN(maHang, tenHang);
                ds.Add(ban);
            }
            rs.Close();
            return ds;
        }
    }
}
