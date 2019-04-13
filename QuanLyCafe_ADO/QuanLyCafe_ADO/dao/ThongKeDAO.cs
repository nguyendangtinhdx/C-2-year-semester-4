using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyCafe_ADO.bean;
namespace QuanLyCafe_ADO.dao
{
    public class ThongKeDAO
    {
        public List<ThongKeBEAN> getListThongKeTheoNgay(long ngay, long thang, long nam)
        {
            string sql = "SELECT * FROM Qtk WHERE DAY(NgayBan) = @ngay AND MONTH(NgayBan) = @thang AND YEAR(NgayBan) = @nam";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@ngay", ngay);
            SqlParameter ts2 = new SqlParameter("@thang", thang);
            SqlParameter ts3 = new SqlParameter("@nam", nam);
            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            SqlDataReader rs = cmd.ExecuteReader();
            List<ThongKeBEAN> ds = new List<ThongKeBEAN>();
            while (rs.Read())
            {
                string tenHang = rs["TenHang"].ToString();
                string gia = rs["Gia"].ToString();
                string soLuongMua = rs["SoLuongMua"].ToString();
                string thanhTien = rs["ThanhTien"].ToString();
                string ngayBan = rs["NgayBan"].ToString();
                ThongKeBEAN thongKe = new ThongKeBEAN(tenHang, long.Parse(gia), long.Parse(soLuongMua), long.Parse(thanhTien),DateTime.Parse(ngayBan));
                ds.Add(thongKe);
            }
            rs.Close();
            return ds;
        }
        public long getTongTienTheoNgay(long ngay, long thang, long nam)
        {
            string sql = " SELECT SUM(ThanhTien) AS TongTien FROM Qtk WHERE DAY(NgayBan) = @ngay AND MONTH(NgayBan) = @thang AND YEAR(NgayBan) = @nam";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@ngay", ngay);
            SqlParameter ts2 = new SqlParameter("@thang", thang);
            SqlParameter ts3 = new SqlParameter("@nam", nam);
            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            long result = 0;
            string sum = cmd.ExecuteScalar().ToString();
            if (sum != "")
            {
                result = long.Parse(sum);
            }
            return result;
        }
        public List<ThongKeBEAN> getListThongKeTheoThang(long thang,long nam)
        {
            string sql = "SELECT * FROM Qtk WHERE MONTH(NgayBan) = @thang AND YEAR(NgayBan) = @nam";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@thang", thang);
            SqlParameter ts2 = new SqlParameter("@nam", nam);
            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            SqlDataReader rs = cmd.ExecuteReader();
            List<ThongKeBEAN> ds = new List<ThongKeBEAN>();
            while (rs.Read())
            {
                string tenHang = rs["TenHang"].ToString();
                string gia = rs["Gia"].ToString();
                string soLuongMua = rs["SoLuongMua"].ToString();
                string thanhTien = rs["ThanhTien"].ToString();
                string ngayBan = rs["NgayBan"].ToString();
                ThongKeBEAN thongKe = new ThongKeBEAN(tenHang, long.Parse(gia), long.Parse(soLuongMua), long.Parse(thanhTien), DateTime.Parse(ngayBan));
                ds.Add(thongKe);
            }
            rs.Close();
            return ds;
        }
        public long getTongTienTheoThang(long thang, long nam)
        {
            string sql = " SELECT SUM(ThanhTien) AS TongTien FROM Qtk WHERE MONTH(NgayBan) = @thang AND YEAR(NgayBan) = @nam";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@thang", thang);
            SqlParameter ts2 = new SqlParameter("@nam", nam);
            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            long result = 0;
            string sum = cmd.ExecuteScalar().ToString();
            if (sum != "")
            {
                result = long.Parse(sum);
            }
            return result;
        }
        public List<ThongKeBEAN> getListThongKeTheoNam(long nam)
        {
            string sql = "SELECT * FROM Qtk WHERE YEAR(NgayBan) = @nam";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@nam", nam);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            List<ThongKeBEAN> ds = new List<ThongKeBEAN>();
            while (rs.Read())
            {
                string tenHang = rs["TenHang"].ToString();
                string gia = rs["Gia"].ToString();
                string soLuongMua = rs["SoLuongMua"].ToString();
                string thanhTien = rs["ThanhTien"].ToString();
                string ngayBan = rs["NgayBan"].ToString();
                ThongKeBEAN thongKe = new ThongKeBEAN(tenHang, long.Parse(gia), long.Parse(soLuongMua), long.Parse(thanhTien), DateTime.Parse(ngayBan));
                ds.Add(thongKe);
            }
            rs.Close();
            return ds;
        }
        public long getTongTienTheoNam(long nam)
        {
            string sql = " SELECT SUM(ThanhTien) AS TongTien FROM Qtk WHERE YEAR(NgayBan) = @nam ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@nam", nam);
            cmd.Parameters.Add(ts);
            long result = 0;
            string sum = cmd.ExecuteScalar().ToString();
            if (sum != "")
            {
                result = long.Parse(sum);
            }
            return result;
        }
    }
}
