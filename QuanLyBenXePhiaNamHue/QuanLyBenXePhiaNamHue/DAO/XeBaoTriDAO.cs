using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DAO
{
    public class XeBaoTriDAO
    {
        private static XeBaoTriDAO instance;

        public static XeBaoTriDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new XeBaoTriDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private XeBaoTriDAO() { }

        public void themXeBaoTri(string biensoxe, DateTime ngayxong, string tinhtrang)
        {
            string query = "EXEC dbo.USP_insertxebaotri @biensoxe , @ngayxong , @tinhtrang ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { biensoxe, ngayxong, tinhtrang });
        }
    }
}
