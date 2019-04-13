using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyXeOto.bean;
using System.Data.SqlClient;
namespace QuanLyXeOto.dao
{
    public class HoaDonDAO
    {
        public List<HoaDonDEAN> getListHoaDon()
        {
            string sql = "SELECT * FROM HoaDon WHERE TrangThai = 0";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<HoaDonDEAN> ds = new List<HoaDonDEAN>();
            while (rs.Read())
            {
                string mhd = rs["MaHoaDon"].ToString();
                string mx = rs["MaXe"].ToString();
                string slm= rs["SoLuongMua"].ToString();
                string tt = rs["ThanhTien"].ToString();
                string trangThai= rs["TrangThai"].ToString();
                HoaDonDEAN ban = new HoaDonDEAN(mhd, mx, long.Parse(slm), long.Parse(tt), bool.Parse(trangThai));
                ds.Add(ban);
            }
            rs.Close();
            return ds;
        }
        public int themHoaDon(string maXe, long soLuongMua, long thanhTien)
        {
            string sql2 = " SELECT MAX(MaHoaDon) FROM HoaDon ";
            SqlCommand cmd2 = new SqlCommand(sql2, DungChung.cn);
            string max = cmd2.ExecuteScalar().ToString();
            long maHoaDon = 1;
            if (max != "")
            {
                maHoaDon = long.Parse(max) + 1;
            }

            string sql = " INSERT INTO HoaDon VALUES(@maHoaDon,@maXe,@soLuongMua,@thanhTien,0) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts = new SqlParameter("@maHoaDon", maHoaDon);
            SqlParameter ts2 = new SqlParameter("@maXe", maXe);
            SqlParameter ts3 = new SqlParameter("@soLuongMua", soLuongMua);
            SqlParameter ts4 = new SqlParameter("@thanhTien", thanhTien);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            cmd.Parameters.Add(ts4);
            return cmd.ExecuteNonQuery();
        }
        public long getTongTien()
        {
            string sql = " SELECT SUM(ThanhTien) AS TongTien FROM HoaDon ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            long result = 0;
            string TongTien = cmd.ExecuteScalar().ToString();
            if (TongTien != "")
            {
                result = long.Parse(TongTien);
            }
            return result;
        }
        public int thanhToanHoaDon()
        {
            string sql = " UPDATE HoaDon SET TrangThai = 1 ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            return cmd.ExecuteNonQuery();
        }
        public string getMaXeByMaXe(string ma)
        {
            string sql = " SELECT MaXe FROM HoaDon WHERE MaXe = @maXe";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maXe", ma);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            string maXe = "";
            if (rs.Read())
            {
                maXe = rs.GetString(0);
            }
            rs.Close();
            return maXe;
        }

        public int suaSoLuongHoaDonByTrungMaXe(string maXe, long soLuongMua)
        {
            string sql = " UPDATE dbo.HoaDon SET SoLuongMua = @soLuongMua + (SELECT SoLuongMua FROM dbo.HoaDon WHERE MaXe = @maXe), ThanhTien = @soLuongMua * (SELECT Gia FROM dbo.Oto WHERE MaXe = @maXe) + (SELECT ThanhTien FROM dbo.HoaDon WHERE MaXe = @maXe) WHERE MaXe = @maXe";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts1 = new SqlParameter("@soLuongMua", soLuongMua);
            SqlParameter ts2 = new SqlParameter("@maXe", maXe);

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            return cmd.ExecuteNonQuery();
        }
    }
}
