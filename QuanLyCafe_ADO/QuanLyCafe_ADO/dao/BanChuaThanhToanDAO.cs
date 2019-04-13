using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyCafe_ADO.bean;
namespace QuanLyCafe_ADO.dao
{
    public class BanChuaThanhToanDAO
    {
        public List<BanChuaThanhToanBEAN> getListBanChuaThanhToan()
        {
            string sql = "SELECT * FROM BanChuaThanhToan";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<BanChuaThanhToanBEAN> ds = new List<BanChuaThanhToanBEAN>();
            while (rs.Read())
            {
                string maBan = rs["MaBan"].ToString();
                string tenBan = rs["TenBan"].ToString();
                string soGhe = rs["SoGhe"].ToString();
                string daTraTien = rs["DaTraTien"].ToString();
                BanChuaThanhToanBEAN banChuaThanhToan = new BanChuaThanhToanBEAN( maBan, tenBan, long.Parse(soGhe), bool.Parse(daTraTien));
                ds.Add(banChuaThanhToan);
            }
            rs.Close();
            return ds;
        }
    }
}
