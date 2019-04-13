using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace QuanLyNhanVien
{
    public class CoQuan
    {
        public List<CanBo> dsCanBo = new List<CanBo>(); 
        
        public CoQuan(string tenfile)
        {
            StreamReader f = new StreamReader(tenfile); 
            while (true) 
            {
                string st = f.ReadLine();   
                if (string.IsNullOrEmpty(st)) break;
                    string [] ds = st.Split(';');  
               
                CanBo cb = new CanBo(ds[0],ds[1],bool.Parse(ds[2]),ds[3],DateTime.Parse(ds[4]),double.Parse(ds[5]),ds[6]);

                dsCanBo.Add(cb);
            }
        }

        public void Them(string ma, string hoten, bool gioitinh, string diachi, DateTime ngaysinh, double hesoluong, string tendonvi)
        {
            CanBo cb = new CanBo(ma, hoten, gioitinh, diachi, ngaysinh, hesoluong, tendonvi);
            dsCanBo.Add(cb);
        }

        public void Xoa(string ma)
        {
            int scb = dsCanBo.Count;
            for (int i = 0; i < scb ; i++)
                if (dsCanBo[i].Ma.Equals(ma))
                    dsCanBo.RemoveAt(i);
        }

        //Sửa lại hệ số lương cho cán bộ
        public void Sua(string ma, double HeSoLuongMoi)
        {
            foreach (CanBo cb in dsCanBo)
            {
                if (cb.Ma.Equals(ma))
                    cb.Hesoluong = HeSoLuongMoi;
            }
        }

        // tìm danh sách cán bộ theo tên đơn vị
        public List<CanBo> Tim(string tendonvi)
        {
            List<CanBo> dstam = new List<CanBo>();
            foreach (CanBo cb in dsCanBo)
                if (cb.Tendonvi.Trim().ToLower().Equals(tendonvi.ToLower()))
                    dstam.Add(cb);
            return dstam;
        }
   
        // lưu file
        public void LuuFile(string tenfile)
        {
            StreamWriter f = new StreamWriter(tenfile);
            foreach (CanBo cb in dsCanBo)
            {
                string st = cb.Ma + ";" + cb.Hoten + ";" + cb.Gioitinh.ToString() + ";" + cb.Diachi + ";" + 
                    cb.Ngaysinh.ToShortDateString() + ";" + cb.Hesoluong.ToString() + ";" + cb.Tendonvi;
                f.WriteLine(st);
            }
            f.Close();
        }
    }
}
