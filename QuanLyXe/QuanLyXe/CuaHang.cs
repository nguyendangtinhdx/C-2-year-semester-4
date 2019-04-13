using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace QuanLyXe
{
    public class CuaHang
    {
        public List<Xe> ds = new List<Xe>();
        public CuaHang(string tf)
        {
            StreamReader f = new StreamReader(tf);
            while(true)
            {
                string st = f.ReadLine();
                if (string.IsNullOrEmpty(st))
                    break;
                string[] tach = st.Split(';');
                Xe x = new Xe(tach[0], tach[1], tach[2], DateTime.Parse(tach[3]), long.Parse(tach[4]));
                ds.Add(x);
            }
            f.Close();
        }

        public List<Xe> TimLoai(string loaixe)
        {
            List<Xe> tam = new List<Xe>();
            foreach (Xe x in ds)
                if (x.Loaixe.Trim().ToLower().Equals(loaixe.Trim().ToLower()))
                    tam.Add(x);
            return tam;
        }

        //bool KtMa(List<Xe> xe, string maxe)
        //{
        //    foreach (Xe x in ds)
        //        if (x.Maxe.Equals(maxe))
        //            return true;
        //        return false;
        //}
        public void Them(string maxe, string tenxe, string loaixe, DateTime ngaysanxuat, long gia)
        {
            //if (KtMa(ds, maxe) == false)
            //{
                Xe x = new Xe(maxe, tenxe, loaixe, ngaysanxuat, gia);
                ds.Add(x);
            //    return ds;
            //}
            //return null;
        }
        public void Sua(string maxe,string tenxeMoi, string loaixeMoi, DateTime ngaysanxuatMoi, long giaMoi)
        {
            foreach (Xe x in ds)
                if(x.Maxe.Equals(maxe))
                {
                    x.Ten = tenxeMoi;
                    x.Loaixe = loaixeMoi;
                    x.Ngaysanxuat = ngaysanxuatMoi;
                    x.Gia = giaMoi;
                }
        }

        public void Xoa(string maxe)
        {
            int dem = ds.Count;
            for (int i = 0; i < dem; i++)
                if (ds[i].Maxe.Equals(maxe))
                    ds.RemoveAt(i);
        }

        public void LuuFile(string tenfile)
        {
            StreamWriter f = new StreamWriter(tenfile);
            foreach (Xe x in ds)
            {
                string st = x.Maxe + ";" + x.Ten + ";" + x.Loaixe + ";" + x.Ngaysanxuat + ";" + x.Gia;
                f.WriteLine(st);
            }
            f.Close();
        }

        
    }
}
