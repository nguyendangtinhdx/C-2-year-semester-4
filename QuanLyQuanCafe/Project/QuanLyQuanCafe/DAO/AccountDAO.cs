
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return AccountDAO.instance;
            }
            private set { AccountDAO.instance = value; } // chỉ có nội bộ trong class mới được set dữ liệu vào, nếu ở ngoài thì không được đụng vào
        }
        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord); // lấy ra 1 mảng kiểu byte từ chuỗi   // 22 mã hóa
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp); // đã có mật khẩu mã hóa băm ra rồi

            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            //var list = hasData.ToString();
            //list.Reverse(); // đảo ngược lại


            //string query = "SELECT * FROM dbo.Account WHERE UserName = N'" + userName +"' AND PassWord = N'"+ passWord + "' ";
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hasPass /* list*/});
            return result.Rows.Count > 0;// số dòng trả ra > 0
        }

        public bool UpdateAccount( string userName, string displayName, string passWord,string newPassWord) // 15
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateAccount @userName , @displayName , @passWord , @newPassWord ", new object[] { userName,displayName,passWord,newPassWord});

            return result > 0;// số dòng thây đổi > 0
        }

        // lấy account dựa vào userName
        public Account GetAccountByUserName(string userName) // 15
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Account WHERE UserName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        //public List<Account> GetListAccount() // tự làm
        //{
        //    List<Account> listAccount = new List<Account>();
        //    string query = "SELECT * FROM dbo.Account";
        //    DataTable data = DataProvider.Instance.ExecuteQuery(query);
        //    foreach (DataRow item in data.Rows)
        //    {
        //        Account acount= new Account(item);
        //        listAccount.Add(acount);
        //    }
        //    return listAccount;
        //}

        public DataTable GetListAccount() // 20
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName,DisplayName,Type FROM dbo.Account");
        }

        public bool InsertAccount(string name, string displayName, int type) // 21
        {
            string query = string.Format("INSERT dbo.Account( UserName, DisplayName,PassWord , Type) VALUES ( N'{0}', N'{1}', N'{2}', {3})", name,displayName , "18833213210117723916811824913021616923162239", type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateAccount( string name, string displayName, int type) // 21
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}',Type = {2} WHERE UserName = N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteAccount(string name) // 21
        {
            string query = "DELETE dbo.Account WHERE UserName = N'" + name + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string name) // 21
        {
            string query = "UPDATE dbo.Account SET PassWord = N'18833213210117723916811824913021616923162239' WHERE UserName = N'" + name + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
