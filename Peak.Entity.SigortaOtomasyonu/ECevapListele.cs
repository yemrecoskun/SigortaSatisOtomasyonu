using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
   public class ECevapListele
    {
        public List<DTOTanimDetay> cevaplistesi() {
            List<DTOTanimDetay> detaylistesi = new List<DTOTanimDetay>();
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select id,Detay1,Detay2,Detay3,Detay4 from sgt_tanimdetay where tanim_id in ('5')",Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTOTanimDetay tanimdetay = new DTOTanimDetay();
                tanimdetay.id = Convert.ToInt16(rd.GetString("id"));
                tanimdetay.Detay1 = rd.GetString("Detay1");
                tanimdetay.Detay2 = rd.GetString("Detay2");
                tanimdetay.Detay3 = rd.GetString("Detay3");
                tanimdetay.Detay4 = rd.GetString("Detay4");
                detaylistesi.Add(tanimdetay);
            }
            Globals.Globals.con.Close();
            return detaylistesi;
        }
    }
}
