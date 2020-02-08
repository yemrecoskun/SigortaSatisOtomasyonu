using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
    public class EKullaniciGiris
    {
        public string KullaniciGiris(DTOKullanici kullanici)
        {
            string sonuc;
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sigortaotomasyonu.kullanicigiris;",Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (kullanici.Kullanici_Adi == rd.GetString("Kullanici_adi") && kullanici.Sifre == rd.GetString("sifre")) {    Globals.Globals.con.Close(); return sonuc = "Giris Basarili";  }
            }

            Globals.Globals.con.Close();
            return sonuc = "Giris Basarisiz";
        }
    }
}
