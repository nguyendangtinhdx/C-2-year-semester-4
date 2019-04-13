using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BaiTap6_ADO.Model
{
    public class DangNhapDao
    {
        public bool DangNhap(long tenDangNhap, string matKhau)
        {
            string sql = " SELECT tendn,matkhau FROM KhachHang WHERE Makh = @tenDangNhap AND matkhau = @matKhau";
            SqlCommand cmd = new SqlCommand(sql, DungChung.cn);
            SqlParameter[] ts = new SqlParameter[2];
            ts[0] = new SqlParameter("@tenDangNhap", tenDangNhap);
            ts[1] = new SqlParameter("@matKhau",matKhau);
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
