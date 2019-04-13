using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using test.bean;
namespace test.dao
{
    public class DangNhapDAO
    {
        public bool DangNhap(string taiKhoan, string matKhau)
        {
            string sql = " SELECT * FROM DangNhap WHERE TaiKhoan = @taiKhoan AND MatKhau = @matKhau";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter[] ts = new SqlParameter[2];
            ts[0] = new SqlParameter("@taiKhoan", taiKhoan);
            ts[1] = new SqlParameter("@matKhau", matKhau);
            int n = ts.Length;
            for (int i = 0; i < n; i++)
            {
                cmd.Parameters.Add(ts[i]);
            }
            SqlDataReader rs = cmd.ExecuteReader();
            bool kq = rs.Read();
            rs.Close();
            return kq;
        }
        public List<DangNhapBEAN> getListDangNhap()
        {
            string sql = "SELECT * FROM DangNhap";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlDataReader rs = cmd.ExecuteReader();
            List<DangNhapBEAN> ds = new List<DangNhapBEAN>();
            while (rs.Read())
            {
                string taiKhoan = rs["TaiKhoan"].ToString();
                string matKhau = rs["MatKhau"].ToString();
                DangNhapBEAN dn = new DangNhapBEAN(taiKhoan, matKhau);
                ds.Add(dn);

            }
            rs.Close();
            return ds;
        }
        public int themDangNhap(string taiKhoan, string matKhau)
        {
            string sql = " INSERT INTO DangNhap VALUES(@taiKhoan,@matKhau) ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            // tạo tham số cho câu lệnh
            SqlParameter ts1 = new SqlParameter("@taiKhoan", taiKhoan);
            SqlParameter ts2 = new SqlParameter("@matKhau", matKhau);
            // đưa tham số vào cmd

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            return cmd.ExecuteNonQuery();
        }
        public int suaDangNhap(string taiKhoan, string matKhau)
        {
            string sql = " UPDATE DangNhap SET MatKhau = @matKhau WHERE TaiKhoan = @taiKhoan";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts1 = new SqlParameter("@matKhau", matKhau);
            SqlParameter ts2 = new SqlParameter("@taiKhoan", taiKhoan);

            cmd.Parameters.Add(ts1);
            cmd.Parameters.Add(ts2);
            return cmd.ExecuteNonQuery();
        }
        public int xoaDangNhap(string taiKhoan)
        {
            string sql = " DELETE DangNhap WHERE TaiKhoan = @taiKhoan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);

            cmd.Parameters.Add(new SqlParameter("@taiKhoan", taiKhoan));
            return cmd.ExecuteNonQuery();
        }
        public List<DangNhapBEAN> timDangNhap(string key)
        {
            string sql = "SELECT * FROM DangNhap WHERE TaiKhoan LIKE @taiKhoan ";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter ts = new SqlParameter("@taiKhoan", "%" + key + "%");
            cmd.Parameters.Add(ts);
            SqlDataReader rs = cmd.ExecuteReader();
            List<DangNhapBEAN> ds = new List<DangNhapBEAN>();
            while (rs.Read())
            {
                string taiKhoan = rs["TaiKhoan"].ToString();
                string matKhau = rs["MatKhau"].ToString();
                DangNhapBEAN dn = new DangNhapBEAN(taiKhoan, matKhau);
                ds.Add(dn);
            }
            rs.Close();
            return ds;
        }
    }
}
