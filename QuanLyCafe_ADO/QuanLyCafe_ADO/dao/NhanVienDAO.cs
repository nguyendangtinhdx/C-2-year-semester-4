using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QuanLyCafe_ADO.bean;
namespace QuanLyCafe_ADO.dao
{
    public class NhanVienDAO
    {
        public List<NhanVienBEAN> getListNhanVien()
        {
            string sql = "SELECT * FROM NHanVien";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<NhanVienBEAN> ds = new List<NhanVienBEAN>();
            while (rs.Read())
            {
                string maNhanVien = rs["Manv"].ToString();
                string hoTen = rs["HoTen"].ToString();
                string diaChi = rs["DiaChi"].ToString();
                string matKhau = rs["MatKhau"].ToString();
                string quyen = rs["Quyen"].ToString();
                NhanVienBEAN nhanVien = new NhanVienBEAN(maNhanVien, hoTen,diaChi,matKhau,quyen);
                ds.Add(nhanVien);
            }
            rs.Close();
            return ds;
        }
        public int themNhanVien(string maNhanVien, string hoTen, string diaChi, string matKhau, string quyen)
        {
            string sql = " INSERT INTO NHanVien VALUES(@maNhanVien,@hoTen,@diaChi,@matKhau,@quyen) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts1 = new SqlParameter("@maNhanVien", maNhanVien);
            SqlParameter ts2 = new SqlParameter("@hoTen", hoTen);
            SqlParameter ts3 = new SqlParameter("@diaChi", diaChi);
            SqlParameter ts4 = new SqlParameter("@matKhau", matKhau);
            SqlParameter ts5 = new SqlParameter("@quyen", quyen);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            cmd.Parameters.Add(ts4);
            cmd.Parameters.Add(ts5);
            return cmd.ExecuteNonQuery();
        }
        public int suaNhanVien(string maNhanVien, string hoTen, string diaChi, string matKhau, string quyen)
        {
            string sql = " UPDATE NHanVien SET HoTen = @hoTen, DiaChi = @diaChi, MatKhau = @matKhau, Quyen = @quyen WHERE Manv = @maNhanVien ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts1 = new SqlParameter("@hoTen", hoTen);
            SqlParameter ts2 = new SqlParameter("@diaChi", diaChi);
            SqlParameter ts3 = new SqlParameter("@matKhau", matKhau);
            SqlParameter ts4 = new SqlParameter("@quyen", quyen);
            SqlParameter ts5 = new SqlParameter("@maNhanVien", maNhanVien);

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            cmd.Parameters.Add(ts3);
            cmd.Parameters.Add(ts4);
            cmd.Parameters.Add(ts5);
            return cmd.ExecuteNonQuery();
        }
        public int xoaNhanVien(string maNhanVien)
        {
            string sql = " DELETE NHanVien WHERE Manv = @maNhanVien ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            cmd.Parameters.Add(new SqlParameter("@maNhanVien", maNhanVien));
            return cmd.ExecuteNonQuery();
        }
        public List<NhanVienBEAN> timNhanVien(string key)
        {
            string sql = "SELECT * FROM NHanVien WHERE HoTen LIKE @hoTen ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@hoTen", "%" + key + "%");
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            List<NhanVienBEAN> ds = new List<NhanVienBEAN>();
            while (rs.Read())
            {
                string maNhanVien = rs["Manv"].ToString();
                string hoTen = rs["HoTen"].ToString();
                string diaChi = rs["DiaChi"].ToString();
                string matKhau = rs["MatKhau"].ToString();
                string quyen = rs["Quyen"].ToString();
                NhanVienBEAN nhanVien = new NhanVienBEAN(maNhanVien, hoTen,diaChi,matKhau,quyen);
                ds.Add(nhanVien);
            }
            rs.Close();
            return ds;
        }
        public bool checkNhanVien(string maNhanVien)
        {
            string sql = " SELECT Manv FROM NHanVien WHERE Manv = @maNhanVien AND Quyen = 'admin' ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@maNhanVien", maNhanVien);
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();

            bool check = rs.Read();
            rs.Close();
            return check;
        }

    }
}
