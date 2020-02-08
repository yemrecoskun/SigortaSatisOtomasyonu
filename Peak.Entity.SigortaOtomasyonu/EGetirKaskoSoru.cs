using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
    public class EGetirKaskoSoru
    {
        public List<DTOTanimDetay> kaskosoru(DTOTanimDetay detay)
        {
           if(Globals.Globals.con.State == System.Data.ConnectionState.Open) Globals.Globals.con.Close();
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sgt_tanimdetay where Detay1='"+detay.Detay1+"' and Detay2='"+detay.Detay2+"' and tanim_id='4';",Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            List<DTOTanimDetay> kaskosorulistesi = new List<DTOTanimDetay>();
            while (rd.Read())
            {
                DTOTanimDetay detayekle = new DTOTanimDetay();
                detayekle.Detay3 = rd.GetString("Detay3");
                detayekle.Detay4 = rd.GetString("Detay4");
                detayekle.Detay5 = rd.GetString("Detay5");
                kaskosorulistesi.Add(detayekle);
            }
            Globals.Globals.con.Close();
            return kaskosorulistesi;
        }
    }
}
