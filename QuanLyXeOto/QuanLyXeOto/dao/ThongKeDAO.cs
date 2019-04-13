using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyXeOto.bean;
using System.Data.SqlClient;
namespace QuanLyXeOto.dao
{
    public class ThongKeDAO
    {
        public List<ThongKeBEAN> getListThongKe(string ma)
        {
            string sql = "SELECT * FROM ThongKe WHERE MaHang = @maHang ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            cmd.Parameters.Add(new SqlParameter("@maHang",ma));
            SqlDataReader rs = cmd.ExecuteReader();
            List<ThongKeBEAN> ds = new List<ThongKeBEAN>();
            while (rs.Read())
            {
                string TenHang = rs["TenHang"].ToString();
                string SoLuongMua = rs["SoLuongMua"].ToString();
                string ThanhTien = rs["ThanhTien"].ToString();
                ThongKeBEAN ban = new ThongKeBEAN(TenHang, long.Parse(SoLuongMua), long.Parse(ThanhTien));
                ds.Add(ban);
            }
            rs.Close();
            return ds;
        }
    }
}
