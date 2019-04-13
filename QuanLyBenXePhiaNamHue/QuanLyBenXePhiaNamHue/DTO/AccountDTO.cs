using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DTO
{
    public class AccountDTO
    {
        private string username;
        private string password;
        private string maNhanVien;
        private string typeLogin;
        public AccountDTO(string username, string password, string manhanvien, string typelogin)
        {
            this.Username = username;
            this.Password = password;
            this.MaNhanVien = manhanvien;
            this.TypeLogin = typelogin;
        }
        public AccountDTO(DataRow row)
        {
            this.Username = (string)row["Username"];
            this.Password = (string)row["Password"];
            this.MaNhanVien = (string)row["MaNhanVien"];
            this.TypeLogin = (string)row["TypeLogin"];
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string MaNhanVien
        {
            get
            {
                return maNhanVien;
            }

            set
            {
                maNhanVien = value;
            }
        }

        public string TypeLogin
        {
            get
            {
                return typeLogin;
            }

            set
            {
                typeLogin = value;
            }
        }
    }
}
