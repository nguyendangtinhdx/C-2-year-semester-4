using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BaiTap6_ADO.Model
{
    public class HoaDonDao
    {
        public int themHoaDon(long maKhachHang, DateTime ngayMua)
        {
            string sql2 = " SELECT MAX(MaHoaDon) FROM hoadon ";
            SqlCommand cmd2 = new SqlCommand(sql2, DungChung.cn);
            string max = cmd2.ExecuteScalar().ToString();
            long maHoaDon = 1;
            if (max != "")
            {
                maHoaDon = long.Parse(max) + 1;
            }

            string sql = " INSERT INTO hoadon VALUES(@maHoaDon,@maKhachHang,@ngayMua,0) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts = new SqlParameter("@maHoaDon", maHoaDon);
            SqlParameter ts2 = new SqlParameter("@maKhachHang", maKhachHang);
            SqlParameter ts3 = new SqlParameter("@ngayMua", ngayMua);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            return cmd.ExecuteNonQuery();
        }
        public int thanhToanHoaDon()
        {
            string sql = " UPDATE hoadon SET damua = 1 ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            return cmd.ExecuteNonQuery();
        }
        public long getHonDonMax()
        {
            string sql = " SELECT COUNT(MaHoaDon) FROM hoadon ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            long result = 0;
            string max = cmd.ExecuteScalar().ToString();
            if (max != "")
            {
                result = long.Parse(max);
            }
            return result;
        }
    }
}
