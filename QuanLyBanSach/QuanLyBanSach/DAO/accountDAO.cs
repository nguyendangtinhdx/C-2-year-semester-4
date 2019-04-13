using QuanLyBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DAO
{
    public class accountDAO
    {
        private static accountDAO instance;

        public static accountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new accountDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private accountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query1 = "USP_Login @tenDangNhap , @matKhau ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query1, new object[] {userName, passWord});
            return result.Rows.Count > 0;
        }
        public bool UpdateAccount(string tendangnhap, string matkhau, string matkhaumoi)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @tendangnhap , @matkhau , @matkhaunmoi ", new object[] { tendangnhap, matkhau, matkhaumoi });
            return result > 0;
        }
        public accountDTO GetTen(string tendangnhap)
        {
            string query = "SELECT * FROM DangNhap WHERE TenDangNhap = N'" + tendangnhap +"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new accountDTO(item);
            }
            return null;
        }
    }
}
