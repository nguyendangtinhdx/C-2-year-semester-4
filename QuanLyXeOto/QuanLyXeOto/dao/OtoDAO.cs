using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyXeOto.bean;
using System.Data.SqlClient;
namespace QuanLyXeOto.dao
{
    public class OtoDAO
    {
        public List<OtoBEAN> getListOto()
        {
            string sql = "SELECT * FROM Oto";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<OtoBEAN> ds = new List<OtoBEAN>();
            while (rs.Read())
            {
                string maXe = rs["MaXe"].ToString();
                string tenXe = rs["TenXe"].ToString();
                string soLuongTrongKho = rs["SoLuongTrongKho"].ToString();
                string gia = rs["Gia"].ToString();
                string maHang = rs["MaHang"].ToString();
                OtoBEAN ban = new OtoBEAN(maXe, tenXe, long.Parse(soLuongTrongKho), long.Parse(gia), maHang);
                ds.Add(ban);
            }
            rs.Close();
            return ds;
        }
        public List<OtoBEAN> getListOtoByMa(string ma)
        {
            string sql = "SELECT * FROM Oto WHERE MaXe = @maHang";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts1 = new SqlParameter("@maHang", ma);
            cmd.Parameters.Add(ts1);
            SqlDataReader rs = cmd.ExecuteReader();
            List<OtoBEAN> ds = new List<OtoBEAN>();
            while (rs.Read())
            {
                string maXe = rs["MaXe"].ToString();
                string tenXe = rs["TenXe"].ToString();
                string soLuongTrongKho = rs["SoLuongTrongKho"].ToString();
                string gia = rs["Gia"].ToString();
                string maHang = rs["MaHang"].ToString();
                OtoBEAN ban = new OtoBEAN(maXe, tenXe,long.Parse(soLuongTrongKho),long.Parse(gia),maHang);
                ds.Add(ban);
            }
            rs.Close();
            return ds;
        }
        public List<OtoBEAN> getListOtoByMaHang(string ma)
        {
            string sql = "SELECT * FROM Oto WHERE MaHang = @maHang";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts1 = new SqlParameter("@maHang", ma);
            cmd.Parameters.Add(ts1);
            SqlDataReader rs = cmd.ExecuteReader();
            List<OtoBEAN> ds = new List<OtoBEAN>();
            while (rs.Read())
            {
                string maXe = rs["MaXe"].ToString();
                string tenXe = rs["TenXe"].ToString();
                string soLuongTrongKho = rs["SoLuongTrongKho"].ToString();
                string gia = rs["Gia"].ToString();
                string maHang = rs["MaHang"].ToString();
                OtoBEAN ban = new OtoBEAN(maXe, tenXe, long.Parse(soLuongTrongKho), long.Parse(gia), maHang);
                ds.Add(ban);
            }
            rs.Close();
            return ds;
        }
        public int suaSoLuong(string maXe, long soLuong)
        {
            string sql = " UPDATE Oto SET SoLuongTrongKho = @soLuong WHERE MaXe = @maXe";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts1 = new SqlParameter("@maXe", maXe);
            SqlParameter ts2 = new SqlParameter("@soLuong", soLuong);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);

            return cmd.ExecuteNonQuery();
        }
    }
}
