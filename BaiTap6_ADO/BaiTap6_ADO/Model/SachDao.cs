using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BaiTap6_ADO.Model
{
    public class SachDao
    {
        public List<SachBean> ds = new List<SachBean>();
        public List<SachBean> getSach()
        {
            string sql = "SELECT * FROM sach";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<SachBean> ds = new List<SachBean>();
            while (rs.Read())
            {
                string maSach = rs["masach"].ToString();
                string tenSach = rs["tensach"].ToString();
                string tacGia = rs["tacgia"].ToString();
                string soLuong = rs["soluong"].ToString();
                string gia = rs["gia"].ToString();
                string soTap = rs["sotap"].ToString();
                string anh = rs["anh"].ToString();
                string maLoai = rs["maloai"].ToString();
                string ngayNhap  = rs["NgayNhap"].ToString();
                SachBean sach = new SachBean(maSach, tenSach, tacGia, long.Parse(soLuong), long.Parse(gia), soTap, anh, maLoai, DateTime.Parse(ngayNhap));
                ds.Add(sach);

            }
            rs.Close();
            return ds;
        }

        public List<SachBean> getSachByLoai(string ma)
        {
            string sql = "SELECT * FROM sach WHERE maloai = @maLoai ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maLoai", ma);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            List<SachBean> ds = new List<SachBean>();
            while (rs.Read())
            {
                string maSach = rs["masach"].ToString();
                string tenSach = rs["tensach"].ToString();
                string tacGia = rs["tacgia"].ToString();
                string soLuong = rs["soluong"].ToString();
                string gia = rs["gia"].ToString();
                string soTap = rs["sotap"].ToString();
                string anh = rs["anh"].ToString();
                string maLoai = rs["maloai"].ToString();
                string ngayNhap = rs["NgayNhap"].ToString();
                SachBean sach = new SachBean(maSach, tenSach, tacGia, long.Parse(soLuong), long.Parse(gia), soTap, anh, maLoai, DateTime.Parse(ngayNhap));
                ds.Add(sach);

            }
            rs.Close();
            return ds;
        }
        public List<SachBean> getSachByMaSach(string ma)
        {
            string sql = "SELECT * FROM sach WHERE masach = @maSach";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maSach", ma);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            List<SachBean> ds = new List<SachBean>();
            while (rs.Read())
            {
                string maSach = rs["masach"].ToString();
                string tenSach = rs["tensach"].ToString();
                string tacGia = rs["tacgia"].ToString();
                string soLuong = rs["soluong"].ToString();
                string gia = rs["gia"].ToString();
                string soTap = rs["sotap"].ToString();
                string anh = rs["anh"].ToString();
                string maLoai = rs["maloai"].ToString();
                string ngayNhap = rs["NgayNhap"].ToString();
                SachBean sach = new SachBean(maSach, tenSach, tacGia, long.Parse(soLuong), long.Parse(gia), soTap, anh, maLoai, DateTime.Parse(ngayNhap));
                ds.Add(sach);

            }
            rs.Close();
            return ds;
        }
        public int suaSoLuong(string maSach, long soLuong)
        {
            string sql = " UPDATE sach SET soluong = @soLuong WHERE masach = @maSach ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts1 = new SqlParameter("@maSach", maSach);
            SqlParameter ts2 = new SqlParameter("@soLuong", soLuong);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);

            return cmd.ExecuteNonQuery();
        }
        public int themSach(string maSach, string tenSach, string tacGia, long soLuong, long gia, string soTap, string anh, string maLoai, DateTime ngayNhap)
        {
            string sql = " INSERT INTO sach VALUES(@maSach,@tenSach,@tacGia,@soLuong,@gia,@soTap,@anh,@maLoai,@ngayNhap) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts1 = new SqlParameter("@maSach", maSach);
            SqlParameter ts2 = new SqlParameter("@tenSach", tenSach);
            SqlParameter ts3 = new SqlParameter("@tacGia", tacGia);
            SqlParameter ts4 = new SqlParameter("@soLuong", soLuong);
            SqlParameter ts5 = new SqlParameter("@gia", gia);
            SqlParameter ts6 = new SqlParameter("@soTap", soTap);
            SqlParameter ts7 = new SqlParameter("@anh", anh);
            SqlParameter ts8 = new SqlParameter("@maLoai", maLoai);
            SqlParameter ts9 = new SqlParameter("@ngayNhap", ngayNhap);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            cmd.Parameters.Add(ts4);
            cmd.Parameters.Add(ts5);
            cmd.Parameters.Add(ts6);
            cmd.Parameters.Add(ts7);
            cmd.Parameters.Add(ts8);
            cmd.Parameters.Add(ts9);

            return cmd.ExecuteNonQuery();
        }
        public int suaSach(string maSach, string tenSach, string tacGia, long soLuong, long gia, string soTap, string anh, string maLoai, DateTime ngayNhap)
        {
            string sql = " UPDATE sach SET tensach = @tenSach, tacgia = @tacGia, soluong = @soLuong, gia = @gia, sotap = @soTap, anh = @anh, maloai = @maLoai, NgayNhap = @ngayNhap WHERE masach = @maSach ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts1 = new SqlParameter("@maSach", maSach);
            SqlParameter ts2 = new SqlParameter("@tenSach", tenSach);
            SqlParameter ts3 = new SqlParameter("@tacGia", tacGia);
            SqlParameter ts4 = new SqlParameter("@soLuong", soLuong);
            SqlParameter ts5 = new SqlParameter("@gia", gia);
            SqlParameter ts6 = new SqlParameter("@soTap", soTap);
            SqlParameter ts7 = new SqlParameter("@anh", anh);
            SqlParameter ts8 = new SqlParameter("@maLoai", maLoai);
            SqlParameter ts9 = new SqlParameter("@ngayNhap", ngayNhap);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            cmd.Parameters.Add(ts4);
            cmd.Parameters.Add(ts5);
            cmd.Parameters.Add(ts6);
            cmd.Parameters.Add(ts7);
            cmd.Parameters.Add(ts8);
            cmd.Parameters.Add(ts9);

            return cmd.ExecuteNonQuery();
        }
        public int xoaSach(string maSach)
        {
            string sql = " DELETE sach WHERE masach= @maSach ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            cmd.Parameters.Add(new SqlParameter("@maSach", maSach));
            return cmd.ExecuteNonQuery();
        }
        public List<SachBean> timSach(string key)
        {
            string sql = "SELECT * FROM sach WHERE masach LIKE@maSach tensach LIKE @tenSach OR tacgia LIKE @tacGia ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maSach", key);
            SqlParameter ts2 = new SqlParameter("@tenSach", key);
            SqlParameter ts3 = new SqlParameter("@tacGia", key);
            cmd.Parameters.Add(ts);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            SqlDataReader rs = cmd.ExecuteReader();
            List<SachBean> ds = new List<SachBean>();
            while (rs.Read())
            {
                string maSach = rs["masach"].ToString();
                string tenSach = rs["tensach"].ToString();
                string tacGia = rs["tacgia"].ToString();
                string soLuong = rs["soluong"].ToString();
                string gia = rs["gia"].ToString();
                string soTap = rs["sotap"].ToString();
                string anh = rs["anh"].ToString();
                string maLoai = rs["maloai"].ToString();
                string ngayNhap = rs["NgayNhap"].ToString();

                SachBean sach = new SachBean(maSach, tenSach, tacGia, long.Parse(soLuong), long.Parse(gia), soTap, anh, maLoai, DateTime.Parse(ngayNhap));
                ds.Add(sach);
            }
            rs.Close();
            return ds;
        }
    }
}
