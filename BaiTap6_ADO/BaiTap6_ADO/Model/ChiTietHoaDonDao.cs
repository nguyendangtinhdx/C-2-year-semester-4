using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BaiTap6_ADO.Model
{
    public class ChiTietHoaDonDao
    {
        public int themChiTietHoaDon(string maSach, long soLuongMua, long gia)
        {
            string sql2 = " SELECT MAX(MaChiTietHD) FROM ChiTietHoaDon ";
            SqlCommand cmd2 = new SqlCommand(sql2, DungChung.cn);
            string max = cmd2.ExecuteScalar().ToString();
            long maChiTietHoaDon = 1;
            if (max != "")
            {
                maChiTietHoaDon = long.Parse(max) + 1;
            }

            string sql = " INSERT INTO ChiTietHoaDon VALUES(@MaChiTietHD,@maSach,@soLuongMua,(SELECT MAX(MaHoaDon) FROM hoadon),@gia) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts = new SqlParameter("@MaChiTietHD", maChiTietHoaDon);
            SqlParameter ts2 = new SqlParameter("@maSach", maSach);
            SqlParameter ts3 = new SqlParameter("@soLuongMua", soLuongMua);
            SqlParameter ts4 = new SqlParameter("@gia", gia);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            cmd.Parameters.Add(ts4);
            return cmd.ExecuteNonQuery();
        }
    }
}
