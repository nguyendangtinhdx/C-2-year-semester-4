using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyCafe_ADO.bean;
namespace QuanLyCafe_ADO.dao
{
    public class HoaDonDAO
    {
        public List<HoaDonBEAN> getListHoaDon()
        {
            string sql = "SELECT * FROM HoaDon";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<HoaDonBEAN> ds = new List<HoaDonBEAN>();
            while (rs.Read())
            {
                string maHoaDon = rs["MaHD"].ToString();
                string maNhanVien = rs["MaNv"].ToString();
                string maBan = rs["MaBan"].ToString();
                string ngayBan = rs["NgayBan"].ToString();
                string daTraTien = rs["DaTraTien"].ToString();
                HoaDonBEAN hoaDon = new HoaDonBEAN(long.Parse(maHoaDon), maNhanVien, maBan, DateTime.Parse(ngayBan), bool.Parse(daTraTien));
                ds.Add(hoaDon);
            }
            rs.Close();
            return ds;
        }
        public int xoaHoaDon(long maHoaDon)
        {
            string sql = " DELETE HoaDon WHERE MaHD = @maHoaDon";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            cmd.Parameters.Add(new SqlParameter("@maHoaDon", maHoaDon));
            return cmd.ExecuteNonQuery();
        }
        public int themHoaDon(string maNhanVien, string maBan)
        {
            string sql2 = " SELECT MAX(MaHD) FROM HoaDon ";
            SqlCommand cmd2 = new SqlCommand(sql2, DungChung.cn);
            string max = cmd2.ExecuteScalar().ToString();
            long maHoaDon = 1;
            if (max != "")
            {
                maHoaDon = long.Parse(max) + 1;
            }

            string sql = " INSERT INTO HoaDon VALUES(@maHoaDon,@maNhanVien,@maBan,GETDATE(),0) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts = new SqlParameter("@maHoaDon", maHoaDon);
            SqlParameter ts2 = new SqlParameter("@maNhanVien", maNhanVien);
            SqlParameter ts3 = new SqlParameter("@maBan", maBan);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            return cmd.ExecuteNonQuery();
        }
        public int thanhToanHoaDon(string maBan)
        {
            string sql = " UPDATE HoaDon SET DaTraTien = 1 WHERE MaBan = @maBan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            cmd.Parameters.Add(new SqlParameter("@maBan", maBan));

            return cmd.ExecuteNonQuery();
        }
        //public long getHonDonMax()
        //{
        //    string sql = " SELECT COUNT(MaHD) FROM HoaDon ";
        //    SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
        //    long result = 0;
        //    string max = cmd.ExecuteScalar().ToString();
        //    if (max != "")
        //    {
        //        result = long.Parse(max);
        //    }
        //    return result;
        //}
        public int xoaHoaDonByMaBan(string maBan)
        {
            string sql = " DELETE HoaDon WHERE MaBan = @maBan";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            cmd.Parameters.Add(new SqlParameter("@maBan", maBan));
            return cmd.ExecuteNonQuery();
        }
        public long getMaHoaDonByMaBan(string ma)
        {
            string sql = " SELECT MaHD FROM HoaDon WHERE MaBan = @maBan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maBan", ma);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            long maHoaDon = 0;
            if (rs.Read())
            {
                maHoaDon =  (long)rs[0];
            }
            rs.Close();
            return maHoaDon;
        }

        public string getMaBanByMaBan(string ma)
        {
            string sql = " SELECT MaBan FROM HoaDon WHERE MaBan = @maBan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maBan", ma);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            string maBan = "";
            if (rs.Read())
            {
                maBan = rs.GetString(0);
            }
            rs.Close();
            return maBan;
        }

        public int chuyenBan(string maBanCu, string maBanMoi)
        {
            string sql = " UPDATE HoaDon SET MaBan = @maBanMoi WHERE MaBan = @maBanCu ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts1 = new SqlParameter("@maBanMoi", maBanMoi);
            SqlParameter ts2 = new SqlParameter("@maBanCu", maBanCu);

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            return cmd.ExecuteNonQuery();
        }
    }
}
