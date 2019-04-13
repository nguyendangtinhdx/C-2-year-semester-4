using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource(); // 17
        BindingSource categoryList = new BindingSource(); // tự làm
        BindingSource tableList = new BindingSource(); // tự làm
        BindingSource accountList = new BindingSource();

        public Account loginAccount; // 21

        public fAdmin()
        {
            InitializeComponent();
            //LoadAccountList();
            //dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery("select * from Account where UserName = N' 'or 1=1-- ");
            Load();
        }

        #region methods
        //tìm tên thức ăn
        List<Food> SearchFoodByName(string name) // 19
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);
            return listFood;
        }

        void Load()
        {
            dtgvFood.DataSource = foodList; // 17
            dtgvCategory.DataSource = categoryList; //tự làm
            dtgvTable.DataSource = tableList;// tự làm
            dtgvAccount.DataSource = accountList; // tự làm

            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value); // mới vô là load luôn

            LoadListFood(); // 16
            AddFoodBinding(); // 17
            LoadCategoryIntoCombobox(cbFoodCategory); // 17

            LoadListCategory(); //tự làm
            AddCategoryBinding(); //tự làm
            

            LoadListTable(); //tự làm
            AddTableBinding(); //tự làm

            LoadAccount(); // từ làm
            AddAccountBinding();// tự làm

        }

        void LoadDateTimePickerBill() // 14
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);  // ngày đầu tháng
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut) // 14
        {
            dtgvBill.DataSource =  BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        void LoadListFood() // 16
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        void AddFoodBinding() // 17
        {
            // từ cái textbox FoodName hãy thay đổi giá trị thuộc tính Text bằng giá trị của thằng Name nguồn từ DataSourse
            txbFoodName.DataBindings.Add(new Binding("Text",dtgvFood.DataSource,"Name",true,DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID",true,DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price",true,DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombobox(ComboBox cb) // 17
        {
            cbFoodCategory.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        void LoadListCategory() // tự làm
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        void AddCategoryBinding() // tự làm
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        
        void LoadListTable() // tự làm
        {
            tableList.DataSource = TableDAO.Instance.GetListTable();
        }

        void AddTableBinding() // tự làm
        {
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name",true,DataSourceUpdateMode.Never));
            txbTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmAccountType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }


        #endregion


        #region events

        private void btnViewBill_Click(object sender, EventArgs e) // 14
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void txbFoodID_TextChanged(object sender, EventArgs e) // 17
        {
            try
            {
                // lấy category ra
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
                    Category category = CategoryDAO.Instance.GetCategoryByID(id);
                    cbFoodCategory.SelectedItem = category;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbFoodCategory.SelectedIndex = index;
                }
            }
            catch (Exception)
            {
            }
         
            
        }
        // xem Food
        private void btnShowFood_Click(object sender, EventArgs e) // 17
        {
            LoadListFood();
        }
        // Thêm Food
        private void btnAddFood_Click(object sender, EventArgs e) // 18
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name,categoryID,price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                {
                    insertFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        // Sửa Food
        private void btnEditFood_Click(object sender, EventArgs e) // 18
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id,name, categoryID, price))
            {
                MessageBox.Show("Sửa thức ăn thành công");
                LoadListFood();
                if (updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }
        // Xóa Food
        private void btnDeleteFood_Click(object sender, EventArgs e)  // 18
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa thức ăn thành công");
                LoadListFood();
                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private event EventHandler insertFood; // khi thêm thì bên dtgvTable sẽ load lại       // 18
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        // xem danh mục
        private void btnShowCategory_Click(object sender, EventArgs e) // từ làm
        {
            LoadListCategory();
        }
        // Thêm danh mục
        private void btnAddCategory_Click(object sender, EventArgs e) // tự làm
        {
            string name = txbCategoryName.Text;
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thức ăn thành công");
                LoadListCategory();
                LoadCategoryIntoCombobox(cbFoodCategory);
                if (insertCategory != null)
                {
                    insertCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục thức ăn");
            }
        }

        // Sửa danh mục
        private void btnEditCategory_Click(object sender, EventArgs e) // tự làm
        {
            string name = txbCategoryName.Text;
            int id = Convert.ToInt32(txbCategoryID.Text);
            if (CategoryDAO.Instance.UpdateCategory(id,name))
            {
                MessageBox.Show("Cập nhật danh mục thức ăn thành công");
                LoadListCategory();
                LoadCategoryIntoCombobox(cbFoodCategory);
                if (updateCategory != null)
                {
                    updateCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật danh mục thức ăn ");
            }
        }

        // Xóa danh mục
        private void btnDeleteCatogody_Click(object sender, EventArgs e) // tự làm
        {
            int id = Convert.ToInt32(txbCategoryID.Text);
            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadListCategory();
                LoadCategoryIntoCombobox(cbFoodCategory);
                if (deleteCategory != null)
                {
                    deleteCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục thức ăn");
            }
        }

        private event EventHandler insertCategory; // tự làm
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }
        private event EventHandler deleteCategory; // tự làm
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }
        private event EventHandler updateCategory; // tự làm
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }

        // Xem bàn
        private void btnShowTable_Click(object sender, EventArgs e) // tự làm
        {
            LoadListTable();
        }
        // thêm bàn
        private void btnAddTable_Click(object sender, EventArgs e) // tự làm
        {
            string name = txbTableName.Text;
            string staus = txbTableStatus.Text;

            if (TableDAO.Instance.InsertTable(name,staus))
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadListTable();
                if (insertTable!= null)
                {
                    insertTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn");
            }
        }
        // Sửa bàn
        private void btnEditTable_Click(object sender, EventArgs e) // tự làm
        {
            string name = txbTableName.Text;
            string staus = txbTableStatus.Text;
            int id = Convert.ToInt32(txbTableID.Text);
            if (TableDAO.Instance.UpdateTable(id,name,staus))
            {
                MessageBox.Show("Cập nhật bàn thành công");
                LoadListTable();
                if (updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật bàn");
            }
        }
         // Xóa bàn
        private void btnDeleteTable_Click(object sender, EventArgs e) // tự làm
        {
            int id = Convert.ToInt32(txbTableID.Text);
            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công");
                LoadListTable();
                if (deleteTable != null)
                {
                    deleteTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa bàn");
            }
        }
        

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }
        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }
        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        // Xem account
        private void btnShowAccount_Click(object sender, EventArgs e) // 21
        {
            LoadAccount();
        }
        // Thêm account
        private void btnAddAccount_Click(object sender, EventArgs e) // 21
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmAccountType.Value;
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            LoadAccount();
        }
        // Sửa account
        private void btnEditAccount_Click(object sender, EventArgs e) // 21
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmAccountType.Value;
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }
            LoadAccount();
        }
        // Xóa account
        private void btnDeleteAccount_Click(object sender, EventArgs e) // 21
        {
            string userName = txbUserName.Text;
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Xóa tài khoản hiện tại thất bại");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            LoadAccount();
        }

        private void btnResetPassWord_Click(object sender, EventArgs e) // 21
        {
            string userName = txbUserName.Text;
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }

        private void btnSearchFood_Click(object sender, EventArgs e) // 19
        {
            foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }

        private void btnFirstBillPage_Click(object sender, EventArgs e) // button về trang đầu // 24
        {
            txbPageBill.Text = "1";
        }

        private void btnLastBillPage_Click(object sender, EventArgs e) // button về trang cuối // 24
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            int lastPage = sumRecord / 10;
            if (sumRecord % 10 != 0)
                lastPage++;
            txbPageBill.Text = lastPage.ToString();
        }

        private void txbPageBill_TextChanged(object sender, EventArgs e) // giá trị số trang thay đổi // 24
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(txbPageBill.Text));
        }

        private void btnPreviousBillPage_Click(object sender, EventArgs e) // 24
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            if (page > 1)
                page--;
            txbPageBill.Text = page.ToString();
        }

        private void btnNextBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);
            if (page < sumRecord)
                page++;
            txbPageBill.Text = page.ToString();
        }







        #endregion

        private void fAdmin_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }



        //void LoadFoodList()
        //{
        //    string query = "SELECT * FROM Food";
        //    dtgvFood.DataSource = DataProvider.Instance.ExecuteQuery(query);
        //}

        //void LoadAccountList()   // 4
        //{
        //    string query = "EXEC USP_GetAccountByUserName @userName";
        //    dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] {"admin"});
        //}
    }
}
