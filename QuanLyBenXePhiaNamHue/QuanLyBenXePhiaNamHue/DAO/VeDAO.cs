using QuanLyBenXePhiaNamHue.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DAO
{
    public class VeDAO
    {
        private static VeDAO instance;

        public static VeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VeDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private VeDAO() { }
        public int getSoChoConTrong(string matuyenxe)
        {
            string query = "IF (SELECT SUM(SoLuong) FROM Ve WHERE (MaTuyenXe = @matuyenxe )) IS NULL SELECT 0 ELSE SELECT SUM(SoLuong) FROM Ve WHERE MaTuyenXe = @matuyenxe1 ";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { matuyenxe , matuyenxe });
        }
        public bool muaVe(string matuyenxe, string manhanvien, int gia, int soluong, DateTime thoigianmua)
        {
            string query = "INSERT dbo.Ve (MaTuyenXe, MaNhanVien, Gia, SoLuong, ThoiGianBanVe) VALUES( @matuyenxe , @manhanvien , @gia , @soluong , @thoigianmua )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { matuyenxe , manhanvien, gia, soluong, thoigianmua });
            return result > 0;
        }
        public int getMaVeMax()
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(MaVe) FROM Ve");
        }
        public bool xoaVe(string mave)
        {
            string query = "DELETE FROM Ve WHERE MaVe = @mave ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { mave });
            return result > 0;
        }
    }
}
