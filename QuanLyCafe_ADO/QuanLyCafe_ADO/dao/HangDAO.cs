using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyCafe_ADO.bean;
namespace QuanLyCafe_ADO.dao
{
    public class HangDAO
    {
        public List<HangBEAN> getListHang()
        {
            string sql = "SELECT * FROM Hang";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<HangBEAN> ds = new List<HangBEAN>();
            while (rs.Read())
            {
                string maHang = rs["MaHang"].ToString();
                string tenHang = rs["TenHang"].ToString();
                string gia = rs["Gia"].ToString();
                string soLuong = rs["SoLuong"].ToString();
                string donViTinh = rs["DonViTinh"].ToString();
                HangBEAN hang = new HangBEAN(maHang, tenHang, long.Parse(gia),long.Parse(soLuong),donViTinh);
                ds.Add(hang);
            }
            rs.Close();
            return ds;
        }
        public List<HangBEAN> getListHangByMaHang(string ma)
        {
            string sql = "SELECT * FROM Hang WHERE MaHang = @maHang";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maHang", ma);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            List<HangBEAN> ds = new List<HangBEAN>();
            while (rs.Read())
            {
                string maHang = rs["MaHang"].ToString();
                string tenHang = rs["TenHang"].ToString();
                string gia = rs["Gia"].ToString();
                string soLuong = rs["SoLuong"].ToString();
                string donViTinh = rs["DonViTinh"].ToString();
                HangBEAN hang = new HangBEAN(maHang, tenHang, long.Parse(gia), long.Parse(soLuong), donViTinh);
                ds.Add(hang);
            }
            rs.Close();
            return ds;
        }
        public int themHang(string maHang, string tenHang, long gia, long soLuong, string donViTinh)
        {
            string sql = " INSERT INTO Hang VALUES(@maHang,@tenHang,@gia,@soLuong,@donViTinh) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts1 = new SqlParameter("@maHang", maHang);
            SqlParameter ts2 = new SqlParameter("@tenHang", tenHang);
            SqlParameter ts3 = new SqlParameter("@gia", gia);
            SqlParameter ts4 = new SqlParameter("@soLuong", soLuong);
            SqlParameter ts5 = new SqlParameter("@donViTinh", donViTinh);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            cmd.Parameters.Add(ts4);
            cmd.Parameters.Add(ts5);
            return cmd.ExecuteNonQuery();
        }
        public int suaHang(string maHang, string tenHang, long gia, long soLuong, string donViTinh)
        {
            string sql = " UPDATE Hang SET TenHang= @tenHang, Gia = @gia, SoLuong = @soLuong, DonViTinh = @donViTinh WHERE MaHang = @maHang ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts1 = new SqlParameter("@tenHang", tenHang);
            SqlParameter ts2 = new SqlParameter("@gia", gia);
            SqlParameter ts3 = new SqlParameter("@soLuong", soLuong);
            SqlParameter ts4 = new SqlParameter("@donViTinh", donViTinh);
            SqlParameter ts5 = new SqlParameter("@maHang", maHang);

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            cmd.Parameters.Add(ts4);
            cmd.Parameters.Add(ts5);
            return cmd.ExecuteNonQuery();
        }
        public int xoaHang(string maHang)
        {
            string sql = " DELETE Hang WHERE MaHang = @maHang ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            cmd.Parameters.Add(new SqlParameter("@maHang", maHang));
            return cmd.ExecuteNonQuery();
        }
        public List<HangBEAN> timHang(string key)
        {
            string sql = "SELECT * FROM Hang WHERE TenHang LIKE @tenHang ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@tenHang", "%" + key + "%");
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            List<HangBEAN> ds = new List<HangBEAN>();
            while (rs.Read())
            {
                string maHang = rs["MaHang"].ToString();
                string tenHang = rs["TenHang"].ToString();
                string gia = rs["Gia"].ToString();
                string soLuong = rs["SoLuong"].ToString();
                string donViTinh = rs["DonViTinh"].ToString();
                HangBEAN hang = new HangBEAN(maHang, tenHang, long.Parse(gia), long.Parse(soLuong), donViTinh);
                ds.Add(hang);

            }
            rs.Close();
            return ds;
        }
        public int suaSoLuong(string maHang, long soLuong)
        {
            string sql = " UPDATE Hang SET SoLuong = @soLuong WHERE maHang = @maHang ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts1 = new SqlParameter("@maHang", maHang);
            SqlParameter ts2 = new SqlParameter("@soLuong", soLuong);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);

            return cmd.ExecuteNonQuery();
        }
    }
}
