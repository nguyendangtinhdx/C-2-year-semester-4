using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace QuanLyCafe_ADO.dao
{
    public class DangNhapDAO
    {
        public bool DangNhap(string tenDangNhap, string matKhau)
        {
            string sql = " SELECT Manv,MatKhau FROM NHanVien WHERE Manv = @tenDangNhap AND MatKhau = @matKhau";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter[] ts = new SqlParameter[2];
            ts[0] = new SqlParameter("@tenDangNhap", tenDangNhap);
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
    }
}
