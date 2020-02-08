using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
    public class ESoruListele
    {
        public List<DTOTanimDetay> sorulistele()
        {
            List<DTOTanimDetay> sorulistesi = new List<DTOTanimDetay>();
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sgt_tanimdetay where tanim_id in ('4')",Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                //AÇIKLAMA: Detay1 : Tanim Kodu, Detay2 : Tanim Adi, Detay3 : Soru Adi , Detay4: İnput Tipi
                DTOTanimDetay detay = new DTOTanimDetay();
                detay.id = Convert.ToInt16(rd.GetString("id"));
                detay.Detay1 = rd.GetString("detay1");
                detay.Detay2 = rd.GetString("detay2");
                detay.Detay3 = rd.GetString("detay3");
                detay.Detay4 = rd.GetString("detay4");
                detay.Detay5 = rd.GetString("detay5");
                sorulistesi.Add(detay);
            }
            Globals.Globals.con.Close();
            return sorulistesi;
        }
    }
}
