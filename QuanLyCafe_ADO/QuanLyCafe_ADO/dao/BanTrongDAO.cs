using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyCafe_ADO.bean;
namespace QuanLyCafe_ADO.dao
{
    public class BanTrongDAO
    {
        public List<BanTrongBEAN> getListBanTrong()
        {
            string sql = "SELECT * FROM BanTrong";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<BanTrongBEAN> ds = new List<BanTrongBEAN>();
            while (rs.Read())
            {
                string maBan = rs["MaBan"].ToString();
                string tenBan = rs["TenBan"].ToString();
                string soGhe = rs["SoGhe"].ToString();
                BanTrongBEAN banTrong = new BanTrongBEAN(maBan, tenBan, long.Parse(soGhe));
                ds.Add(banTrong);
            }
            rs.Close();
            return ds;
        }
    }
}
