using QuanLyBenXePhiaNamHue.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DAO
{
    public class XeDAO
    {
        private static XeDAO instance;

        public static XeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new XeDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private XeDAO() { }        
        public List<XeDTO> getListXe()
        {
            List<XeDTO> listxe = new List<XeDTO>();
            string query = "SELECT Xe.* FROM Xe";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                XeDTO xe = new XeDTO(item);
                listxe.Add(xe);
            }
            return listxe;
        }
        public List<XeDTO> getListXebybienso(string biensoxe)
        {
            List<XeDTO> listxe = new List<XeDTO>();
            string query = "SELECT Xe.* FROM Xe WHERE BienSoXe LIKE  @biensoxe ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,  new object[] { '%'+biensoxe+'%' });
            foreach (DataRow item in data.Rows)
            {
                XeDTO xe = new XeDTO(item);
                listxe.Add(xe);
            }
            return listxe;
        }
        public List<XeDTO> listxetheotuyen(string biensoxe)
        {
            List<XeDTO> listxetheotuyen = new List<XeDTO>();
            string query = "SELECT Xe.* FROM Xe WHERE BienSoXe = @biensoxe ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { biensoxe });
            foreach (DataRow item in data.Rows)
            {
                XeDTO tx = new XeDTO(item);
                listxetheotuyen.Add(tx);
            }
            return listxetheotuyen;
        }
        public bool themXe(string biensoxe, string mauxe, string loaixe, int sochongoi)
        {
            string query = "INSERT dbo.Xe (BienSoXe, MauXe, LoaiXe, SoChoNgoi, TinhTrang) VALUES( @biensoxe , @mauxe , @loaixe , @sochongoi , N'Tốt' )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { biensoxe, mauxe, loaixe, sochongoi });
            return result > 0;
        }
        public bool suaXe(string biensoxe, string mauxe, string loaixe, int sochongoi)
        {
            string query = "UPDATE Xe SET MauXe = @mauxe , LoaiXe = @loaixe , SoChoNgoi = @sochongoi  WHERE BienSoXe = @biensoxe";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { mauxe, loaixe, sochongoi, biensoxe });
            return result > 0;
        }
        public bool xoaXe(string biensoxe)
        {
            string query = "DELETE FROM Xe WHERE BienSoXe = @biensoxe ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { biensoxe });
            return result > 0;
        }
    }
}
