using QuanLyBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DAO
{
    public class LoaiSach
    {
        private static LoaiSach instance;

        public static LoaiSach Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiSach();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private LoaiSach() { }
        public List<LoaiSachDTO> GetLoaiSach()
        {
            List<LoaiSachDTO> list = new List<LoaiSachDTO>();
            string query = "SELECT * FROM loai";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                LoaiSachDTO loaisachDTO = new LoaiSachDTO(item);
                list.Add(loaisachDTO);
            }
            return list;
        }
    }
}
