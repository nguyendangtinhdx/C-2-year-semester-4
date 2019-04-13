using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fTableManager : Form
    {
        private Account loginAccount; // 15
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value;
                ChangeAccount(loginAccount.Type);
            }
        }

        public fTableManager(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc; // truyền tài khoản đăng nhập // 15 

            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbSwitchTable);
        }

        public fTableManager()
        {
        }
        #region Method

        void ChangeAccount(int type) //15
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName +  ") ";
        }

        void LoadCategory() // 11
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "name"; // hiển thị trường name
        }

        void LoadFoodListByCategoryID(int id) // 11
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryByID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "name"; // hiển thị trường name
        }

        void LoadTable() // 8
        {
            flpTable.Controls.Clear(); // 12

            List<Table> tableList = TableDAO.Instance.GetListTable(); // lấy được danh sách table
            foreach (Table item in tableList)
            {
                Button btn = new Button(){Width = TableDAO.TableWidth, Height = TableDAO.TableHeight};
                btn.Text = item.Name + Environment.NewLine + item.Status; // hiển thị text lên mỗi bàn

                btn.Click += btn_Click; // click vào button từng bàn // 9
                btn.Tag = item; // lưu table vô     //9
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.FromArgb(230, 0, 0);
                        break;
                    default:
                        btn.BackColor = Color.FromArgb(0, 160, 0);
                        break;
                }

                flpTable.Controls.Add(btn);// thêm button
            }

        }

        void ShowBill(int id) //9
        {
            lsvBill.Items.Clear();
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id); // lấy được danh sách BillInfo 

            float totalPrice = 0;  // 10
            foreach (DTO.Menu item in listBillInfo) // add vô listView
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());

                totalPrice += item.TotalPrice; // 10

                lsvBill.Items.Add(lsvItem);
            }
            //CultureInfo culture = new CultureInfo("en-US"); // tiền $
            CultureInfo culture = new CultureInfo("vi-VN"); // tiền VNĐ

            txbTotalPrice.Text = totalPrice.ToString("c",culture);
        }

        void LoadComboboxTable(ComboBox cb) // 13
        {
            cb.DataSource = TableDAO.Instance.GetListTable();
            cb.DisplayMember = "Name";
        }

        #endregion

        #region Event
        private void btn_Click(object sender, EventArgs e) // 9
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag; // lưu Table vô   // 11
            ShowBill(tableID);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAcount += f_UpdateAccount; // 15
            f.ShowDialog();
        }

        private void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();

            f.loginAccount = LoginAccount; // 21 

            f.InsertFood += f_InsertFood; // 18
            f.DeleteFood += f_DeleteFood; // 18
            f.UpdateFood += f_UpdateFood; // 18

            f.InsertCategory += f_InsertCategory; // tự làm
            f.DeleteCategory += f_DelateCategory; // tự làm
            f.UpdateCategory += f_UpdateCategory; // tự làm

            f.InsertTable += f_InsertTable; // tự làm
            f.DeleteTable += f_DeleteTable; // tự làm
            f.UpdateTable += f_UpdateTable; // tự làm
            f.ShowDialog();
        }

        private void f_UpdateTable(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void f_DeleteTable(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void f_InsertTable(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void f_UpdateCategory(object sender, EventArgs e) // tự làm
        {
            LoadCategory();
        }

        private void f_DelateCategory(object sender, EventArgs e) // tự làm
        {
            LoadCategory();
            LoadTable();
        }

        private void f_InsertCategory(object sender, EventArgs e) // tự làm
        {
            LoadCategory();
        }

        private void f_UpdateFood(object sender, EventArgs e) // 18
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void f_DeleteFood(object sender, EventArgs e) // 18
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable(); // load lại cả table
        }

        private void f_InsertFood(object sender, EventArgs e) // 18
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e) // 11
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;// select từ item của nó
            id = selected.ID;


            LoadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e) // 11
        {
            Table table = lsvBill.Tag as Table; // lấy được table hiện tại
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn để thêm món ăn");
                return;
            }
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID); // lấy idBill hiện tại
            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1) // không có bill nào(thêm bill mới)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(),foodID,count);
            }
            else //  bill đã tồn tại
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }
            ShowBill(table.ID); // load mới lại sau khi thêm món

            LoadTable(); // chỉ thêm món mới load table // 12
        }

        private void btnCheckOut_Click(object sender, EventArgs e) // 12
        {
            Table table = lsvBill.Tag as Table; // lấy table hiện tại

            if (table == null)
            {
                MessageBox.Show("Hãy chọn để thanh toán");
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID); // lấy idBill
            int discount = (int)nmDiscount.Value;  // lấy giá trị giảm giá // 13

            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split('.')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount; // 13

            CultureInfo culture = new CultureInfo("vi-VN"); // tiền VNĐ

            if (idBill != -1) // đã có bill
            {
                if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn thanh toán hóa đơn cho {0} ? \nTổng tiền - (Tổng tiền / 100) X Giảm giá \n=> {1} - ({1} / 100) X {2} = {3} VNĐ",
                    table.Name, totalPrice * 1000, discount, finalTotalPrice * 1000),
                    "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) // nếu nhấn OK
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice); // thanh toán
                    ShowBill(table.ID);

                    LoadTable(); // chỉ thanh toán mới load table // 12
                }
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e) // 13
        {
            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn chuyển {0} sang {1} ?", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
            }
        }


        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e) // 23
        {
            btnCheckOut_Click(this, new EventArgs()); // gọi event click của thằng button
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e) // 23
        {
            btnAddFood_Click(this, new EventArgs()); // gọi event click của thằng button
        }

        #endregion


    }
}
