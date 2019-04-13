﻿using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> listCategory = new List<Category>();

            string query = "SELECT * FROM dbo.FoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listCategory.Add(category);
            }

            return listCategory;
        }

        public Category GetCategoryByID(int id) // 17
        {
            Category category = null;

            string query = "SELECT * FROM dbo.FoodCategory WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
            }

            return category;
        }

        public bool InsertCategory(string name)
        {
            string query = "INSERT dbo.FoodCategory( name ) VALUES ( N'" + name + "')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public bool UpdateCategory(int idCategory, string name)
        {
            string query = string.Format("UPDATE dbo.FoodCategory SET name = N'{0}' WHERE id = {1}",name,idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteCategory(int idCategory)
        {
            FoodDAO.Instance.DeleteFoodByCategoryID(idCategory);
            string query = "DELETE dbo.FoodCategory WHERE id = " + idCategory;
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
