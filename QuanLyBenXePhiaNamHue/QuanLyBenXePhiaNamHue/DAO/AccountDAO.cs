using QuanLyBenXePhiaNamHue.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private AccountDAO() { }
        public static string uesrnametk;
        public bool Login(string userName, string passWord)
        {
            string query1 = "USP_Login @username , @password ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query1, new object[] { userName, passWord });
            return result.Rows.Count > 0;
        }
        public AccountDTO GetTypeLogin(string username)
        {
            //string query = "SELECT * FROM Account WHERE Username ='"+username+"'";
            string query = "SELECT * FROM Account WHERE Username = @username ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            foreach (DataRow item in data.Rows)
            {
                return new AccountDTO(item);
            }
            return null;
        }
        public bool taoTaiKhoan(string username, string password, string manhanvien, string quyen)
        {
            string query = "INSERT dbo.Account ( Username , Password , MaNhanVien , TypeLogin ) VALUES  ( @username , @password ,  @manhanvien , @quyen )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, password, manhanvien, quyen });
            return result > 0;
        }
        public bool suaTaiKhoan(string username, string password, string quyen)
        {
            string query = "UPDATE Account SET Password = @password , TypeLogin = @quyen WHERE Username = @username";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { password, quyen, username });
            return result > 0;
        }
        public bool xoaTaiKhoan(string username)
        {
            string query = "DELETE FROM Account WHERE Username = @username ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username });
            return result > 0;
        }
    }
}
