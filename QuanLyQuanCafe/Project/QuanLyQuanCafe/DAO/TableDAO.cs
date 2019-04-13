using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO // 8
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAO();
                return instance;
            }
            private set { instance = value; }
        }
        public static int TableWidth = 90;
        public static int TableHeight = 90;
        private TableDAO() { }

        public void SwitchTable(int id1, int id2) // 13
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2",new object[] {id1,id2 });
        }

        //public List<Table> LoadTableList()
        //{
        //    List<Table> tableList = new List<Table>();

        //    DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");
        //    foreach (DataRow item in data.Rows)
        //    {
        //        Table table = new Table(item);
        //        tableList.Add(table);
        //    }

        //    return tableList;
        //}

            // 2 hàm tương tự

        public List<Table> GetListTable()  // tự làm
        {
            List<Table> listTable = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                listTable.Add(table);
            }
            return listTable;
        }

        public bool InsertTable(string name, string status)  // tự làm
        {
            string query = string.Format("INSERT dbo.TableFood( name, status )VALUES  ( N'{0}',N'{1}')",name,status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        } 
        public bool UpdateTable(int idTable, string name, string status)  // tự làm
        {
            string query = string.Format(("UPDATE dbo.TableFood SET name = N'{0}', status = N'{1}' WHERE id = {2}"), name, status, idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteTable(int idTable)
        {
            string query = "DELETE dbo.TableFood WHERE id = " + idTable;
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
