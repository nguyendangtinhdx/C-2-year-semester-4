using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodDAO();
                return instance;
            }
            private set { instance = value;}
        }
        private FoodDAO() { }

        public List<Food> GetFoodByCategoryByID(int id)
        {
            List<Food> listFood = new List<Food>();
            string query = " SELECT * FROM dbo.Food WHERE idCategory = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }

            return listFood;
        }

        public List<Food> GetListFood() // 16
        {
            List<Food> listFood = new List<Food>();
            string query = " SELECT * FROM dbo.Food " ;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }

            return listFood;
        }

        public List<Food> SearchFoodByName( string name)
        {
            List<Food> listFood = new List<Food>();
            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fChuyenCoDauThanhKhongDau(name) LIKE N'%' + dbo.fChuyenCoDauThanhKhongDau(N'{0}') + '%' ", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }

            return listFood;
        }

        public bool InsertFood(string name , int id, float price) // 18
        {
            string query = string.Format("INSERT dbo.Food( name, idCategory, price ) VALUES ( N'{0}', {1}, {2})", name, id,price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateFood(int idFood, string name, int id, float price) // 18
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}',idCategory = {1},price = {2} WHERE id = {3}", name, id, price,idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteFood(int idFood) // 18
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood); // xóa bên billInfo trước khi xóa bill
            string query = "DELETE dbo.Food WHERE id = "+ idFood;
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public void DeleteFoodByCategoryID(int id)  // tự làm
        {
            DataProvider.Instance.ExecuteQuery("DELETE FROM BillInfo FROM BillInfo INNER JOIN Food ON BillInfo.idFood = Food.id INNER JOIN FoodCategory ON Food.idCategory = FoodCategory.id WHERE FoodCategory.id = " + id);
            DataProvider.Instance.ExecuteQuery("DELETE dbo.Food WHERE idCategory = " + id);
        }
    }
}
