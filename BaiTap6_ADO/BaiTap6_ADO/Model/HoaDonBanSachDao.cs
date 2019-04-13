using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BaiTap6_ADO.Model
{
    public class HoaDonBanSachDao
    {
        public List<HoaDonBanSachBean> ds = new List<HoaDonBanSachBean>();
        public List<HoaDonBanSachBean> getHoaDonBanSach()
        {
            string sql = "SELECT * FROM HoaDonBanSach";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<HoaDonBanSachBean> ds = new List<HoaDonBanSachBean>();
            while (rs.Read())
            {
                string maSach = rs["masach"].ToString();
                string tenSach = rs["tensach"].ToString();
                string tacGia = rs["tacgia"].ToString();
                string soLuongMua = rs["SoLuongMua"].ToString();
                string gia = rs["gia"].ToString();
                string ngayMua = rs["NgayMua"].ToString();
                string daMua = rs["damua"].ToString();
                HoaDonBanSachBean hoadon = new HoaDonBanSachBean(maSach, tenSach, tacGia, long.Parse(soLuongMua), long.Parse(gia), DateTime.Parse(ngayMua), bool.Parse(daMua));
                ds.Add(hoadon);

            }
            rs.Close();
            return ds;
        }
        public long getTongTien()
        {
            string sql = "SELECT SUM(gia*SoLuongMua) AS TongTien FROM HoaDonBanSach";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            long result = 0;
            string TongTien = cmd.ExecuteScalar().ToString();
            if(TongTien != "")
            {
                result = long.Parse(TongTien);
            }
            return result;
        }
    }
}
