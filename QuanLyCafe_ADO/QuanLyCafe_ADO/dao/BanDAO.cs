using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyCafe_ADO.bean;
namespace QuanLyCafe_ADO.dao
{
    public class BanDAO
    {
        public List<BanBEAN> getListBan()
        {
            string sql = "SELECT * FROM Ban";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<BanBEAN> ds = new List<BanBEAN>();
            while (rs.Read())
            {
                string maBan= rs["MaBan"].ToString();
                string tenBan = rs["TenBan"].ToString();
                string soGhe = rs["SoGhe"].ToString();
                BanBEAN ban = new BanBEAN(maBan,tenBan,long.Parse(soGhe));
                ds.Add(ban);

                //String[] st = new String[2];
                //st[0] = rs[0].ToString();
                //st[1] = rs[1].ToString();
            }
            rs.Close();
            return ds;
        }
        public int themBan(string maBan, string tenBan, long soGhe)
        {
            string sql = " INSERT INTO Ban VALUES(@maBan,@tenBan,@soGhe) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts1 = new SqlParameter("@maBan", maBan);
            SqlParameter ts2 = new SqlParameter("@tenBan", tenBan);
            SqlParameter ts3 = new SqlParameter("@soGhe", soGhe);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            return cmd.ExecuteNonQuery();
        }
        public int suaBan(string maBan, string tenBan, long soGhe)
        {
            string sql = " UPDATE Ban SET TenBan = @tenBan, SoGhe = @soGhe WHERE MaBan = @maBan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts1 = new SqlParameter("@tenBan", tenBan);
            SqlParameter ts2 = new SqlParameter("@soGhe", soGhe);
            SqlParameter ts3 = new SqlParameter("@maBan", maBan);

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            return cmd.ExecuteNonQuery();
        }
        public int xoaBan(string maBan)
        {
            string sql = " DELETE Ban WHERE MaBan = @maBan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            cmd.Parameters.Add(new SqlParameter("@maBan", maBan));
            return cmd.ExecuteNonQuery();
        }
        public List<BanBEAN> timBan(string key)
        {
            string sql = "SELECT * FROM Ban WHERE TenBan LIKE @tenBan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@tenBan","%"+ key +"%");
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            List<BanBEAN> ds = new List<BanBEAN>();
            while (rs.Read())
            {
                string maBan = rs["MaBan"].ToString();
                string tenBan = rs["TenBan"].ToString();
                string soGhe = rs["SoGhe"].ToString();
                BanBEAN ban = new BanBEAN(maBan, tenBan, long.Parse(soGhe));
                ds.Add(ban);

            }
            rs.Close();
            return ds;
        }
        public string getTenBan(string ma)
        {
            string sql = " SELECT TenBan FROM Ban WHERE maBan = @maBan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maBan",ma);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            string tenBan = "";
            if (rs.Read())
            {
                tenBan = rs.GetString(0);
            }
            rs.Close();
            return tenBan;
        }
    }
}
