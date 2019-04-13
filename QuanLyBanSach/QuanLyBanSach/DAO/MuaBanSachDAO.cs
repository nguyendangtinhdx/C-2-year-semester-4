using QuanLyBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DAO
{
    public class MuaBanSachDAO
    {
        private static MuaBanSachDAO instance;

        public static MuaBanSachDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MuaBanSachDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private MuaBanSachDAO() { }
        public List<MuaBanSach> getList()
        {
            List<MuaBanSach> list = new List<MuaBanSach>();
            string query = "SELECT sach.MaSach, sach.tensach, sach.gia, ChiTietHoaDon.SoLuongMua, sach.gia * ChiTietHoaDon.SoLuongMua AS [ThanhTien] FROM hoadon INNER JOIN ChiTietHoaDon ON hoadon.MaHoaDon = ChiTietHoaDon.MaHoaDon INNER JOIN sach ON ChiTietHoaDon.MaSach = sach.MaSach WHERE damua = 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MuaBanSach muaban = new MuaBanSach(item);
                list.Add(muaban);
            }
            return list;
        }
    }
}
