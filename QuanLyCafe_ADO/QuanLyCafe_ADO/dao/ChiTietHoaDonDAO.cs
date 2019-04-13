using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyCafe_ADO.bean;
namespace QuanLyCafe_ADO.dao
{
    public class ChiTietHoaDonDAO
    {
        public List<ChiTietHoaDonBEAN> getListChiTietHoaDon()
        {
            string sql = "SELECT * FROM ChiTietHoaDon";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<ChiTietHoaDonBEAN> ds = new List<ChiTietHoaDonBEAN>();
            while (rs.Read())
            {
                string maChiTietHoaDon = rs["MaCtHd"].ToString();
                string maHang = rs["MaHang"].ToString();
                string soLuongMua = rs["SoLuongMua"].ToString();
                string thanhTien = rs["ThanhTien"].ToString();
                string maHoaDon = rs["MaHD"].ToString();
                ChiTietHoaDonBEAN chiTietHoaDon = new ChiTietHoaDonBEAN(long.Parse(maChiTietHoaDon), maHang, long.Parse(soLuongMua), long.Parse(thanhTien),long.Parse(maHoaDon));
                ds.Add(chiTietHoaDon);
            }
            rs.Close();
            return ds;
        }
        public int xoaChiTietHoaDon(long maChiTietHoaDon)
        {
            string sql = " DELETE ChiTietHoaDon WHERE MaCtHd = @maChiTietHoaDon";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            cmd.Parameters.Add(new SqlParameter("@maChiTietHoaDon", maChiTietHoaDon));
            return cmd.ExecuteNonQuery();
        }
        public int themChiTietHoaDon(string maHang, long soLuongMua, long thanhTien)
        {
            string sql2 = " SELECT MAX(MaCtHd) FROM ChiTietHoaDon ";
            SqlCommand cmd2 = new SqlCommand(sql2, DungChung.cn);
            string max = cmd2.ExecuteScalar().ToString();
            long maChiTietHoaDon = 1;
            if (max != "")
            {
                maChiTietHoaDon = long.Parse(max) + 1;
            }

            string sql = " INSERT INTO ChiTietHoaDon VALUES(@MaCtHd,@maHang,@soLuongMua,@thanhTien,(SELECT MAX(MaHD) FROM HoaDon)) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts = new SqlParameter("@MaCtHd", maChiTietHoaDon);
            SqlParameter ts2 = new SqlParameter("@maHang", maHang);
            SqlParameter ts3 = new SqlParameter("@soLuongMua", soLuongMua);
            SqlParameter ts4 = new SqlParameter("@thanhTien", thanhTien);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            cmd.Parameters.Add(ts4);
            return cmd.ExecuteNonQuery();
        }
        public int themChiTietHoaDonKhiTonTaiMaHoaDon(string maHang, long soLuongMua, long thanhTien,long maHoaDon)
        {

            string sql = " INSERT INTO ChiTietHoaDon VALUES((SELECT MAX(MaCtHd)+1 FROM ChiTietHoaDon),@maHang,@soLuongMua,@thanhTien,@maHoaDon) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts2 = new SqlParameter("@maHang", maHang);
            SqlParameter ts3 = new SqlParameter("@soLuongMua", soLuongMua);
            SqlParameter ts4 = new SqlParameter("@thanhTien", thanhTien);
            SqlParameter ts5 = new SqlParameter("@maHoaDon", maHoaDon);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            cmd.Parameters.Add(ts4);
            cmd.Parameters.Add(ts5);
            return cmd.ExecuteNonQuery();
        }
        public string getMaHangByMaHang(string ma, long maHoaDon)
        {
            string sql = " SELECT MaHang FROM ChiTietHoaDon WHERE MaHang = @maHang AND MaHD = @maHoaDon";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maHang", ma);
            SqlParameter ts2 = new SqlParameter("@maHoaDon", maHoaDon);
            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            SqlDataReader rs = cmd.ExecuteReader();
            string maHang = "";
            if (rs.Read())
            {
                maHang = rs.GetString(0);
            }
            rs.Close();
            return maHang;
        }

        public int suaSoLuongChiTietHoaDonByTrungMaHang(string maHang, long soLuongMua, long maHoaDon)
        {
            string sql = " UPDATE dbo.ChiTietHoaDon SET SoLuongMua = @soLuongMua + (SELECT SoLuongMua FROM dbo.ChiTietHoaDon WHERE MaHang = @maHang AND MaHD = @maHoaDon), ThanhTien = @soLuongMua * (SELECT Gia FROM dbo.Hang WHERE MaHang = @maHang) + (SELECT ThanhTien FROM dbo.ChiTietHoaDon WHERE MaHang = @maHang AND MaHD = @maHoaDon) WHERE MaHang = @maHang AND MaHD = @maHoaDon";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts1 = new SqlParameter("@soLuongMua", soLuongMua);
            SqlParameter ts2 = new SqlParameter("@maHang", maHang);
            SqlParameter ts3 = new SqlParameter("@maHoaDon", maHoaDon);

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            return cmd.ExecuteNonQuery();
        }
    }
}
