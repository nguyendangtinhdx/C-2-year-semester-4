using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Account  // 15
    {
        public Account(string userName, string displayName, int type,string passWord = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.PassWord = passWord;
            this.Type = type;
        }

        public Account(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.PassWord = row["PassWord"].ToString();
            this.Type = (int)row["Type"];
        }

        private int type;
        public int Type
        {
            get => type;
            set => type = value;
        }

        private string passWord;
        public string PassWord
        {
            get => passWord;
            set => passWord = value;
        }

        private string displayName;
        public string DisplayName
        {
            get => displayName;
            set => displayName = value;
        }

        private string userName;
        public string UserName
        {
            get => userName;
            set => userName = value;
        }

    }
}
