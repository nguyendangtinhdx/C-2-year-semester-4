using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyCafe_ADO.bean;
namespace QuanLyCafe_ADO.dao
{
    public class HoaDonBanHangDAO
    {
        public List<HoaDonBanHangBEAN> getListHoaDonBanHang(string ma)
        {
            string sql = "SELECT * FROM HoaDonBanHang WHERE MaBan = @maBan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maBan", ma);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            List<HoaDonBanHangBEAN> ds = new List<HoaDonBanHangBEAN>();
            while (rs.Read())
            {
                string tenHang = rs["TenHang"].ToString();
                string gia = rs["Gia"].ToString();
                string soLuongMua= rs["SoLuongMua"].ToString();
                string thanhTien = rs["ThanhTien"].ToString();
                string maBan = rs["MaBan"].ToString();
                string daTraTien = rs["DaTraTien"].ToString();
                HoaDonBanHangBEAN hoaDonBanHang = new HoaDonBanHangBEAN(tenHang, long.Parse(gia), long.Parse(soLuongMua), long.Parse(thanhTien), maBan, bool.Parse(daTraTien));
                ds.Add(hoaDonBanHang);
            }
            rs.Close();
            return ds;
        }
        public long getTongTien(string ma)
        {
            string sql = " SELECT SUM(ThanhTien) AS TongTien FROM HoaDonBanHang WhERE MaBan = @maBan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maBan", ma);
            cmd.Parameters.Add(ts);
            long result = 0;
            string TongTien = cmd.ExecuteScalar().ToString();
            if (TongTien != "")
            {
                result = long.Parse(TongTien);
            }
            return result;
        }
    }
}
