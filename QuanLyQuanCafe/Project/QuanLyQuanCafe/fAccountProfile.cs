using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAccountProfile : Form
    {

        private Account loginAccount; // 15
        public Account LoginAccount
        {
            get { return loginAccount; }
            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount);
            }
        }

        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc; // 15
        }
        void ChangeAccount(Account acc) // 15
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void UpdateAccountInfo() // 15
        {
            string displayName = txbDisplayName.Text;
            string passWord = txbPassWord.Text;
            string newPassWord = txbNewPassWord.Text;
            string reEnterPassWord = txbReEnterPassWord.Text;
            string userName = txbUserName.Text;

            if (!newPassWord.Equals(reEnterPassWord))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName,displayName,passWord,newPassWord))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                    {
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu");
                }
            }
        }
        // xử lý khi đổi displayName nó sẽ cập nhật trên thanh jTableManager luôn 
        private event EventHandler<AccountEvent> updateAccount;  // 15
        public event EventHandler<AccountEvent> UpdateAcount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
            

        private void btnUpdate_Click(object sender, EventArgs e) // 15
        {
            UpdateAccountInfo();
        }
    }

    public class AccountEvent:EventArgs  // 15
    {
        private Account acc;

        public Account Acc { get => acc; set => acc = value; }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
