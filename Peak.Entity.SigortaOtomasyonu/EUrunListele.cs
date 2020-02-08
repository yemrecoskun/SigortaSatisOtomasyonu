using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
   public class EUrunListele
    {
        public List<DTOTanimDetay> urunlistele()
        {
            List<DTOTanimDetay> urunlistesi = new List<DTOTanimDetay>();
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sgt_tanimdetay where tanim_id=2",Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTOTanimDetay detay = new DTOTanimDetay();
                detay.id = Convert.ToInt16(rd.GetString("id"));
                detay.tanim_id = Convert.ToInt16(rd.GetString("tanim_id"));
                if (!rd.IsDBNull(rd.GetOrdinal("Detay1"))) detay.Detay1 = rd.GetString("Detay1");
                if (!rd.IsDBNull(rd.GetOrdinal("Detay2"))) detay.Detay2 = rd.GetString("Detay2");
                if (!rd.IsDBNull(rd.GetOrdinal("Detay3"))) detay.Detay3 = rd.GetString("Detay3");
                if (!rd.IsDBNull(rd.GetOrdinal("Detay4"))) detay.Detay4 = rd.GetString("Detay4");
                if (!rd.IsDBNull(rd.GetOrdinal("Detay5"))) detay.Detay5 = rd.GetString("Detay5");
                if (!rd.IsDBNull(rd.GetOrdinal("Detay6"))) detay.Detay6 = rd.GetString("Detay6");
                if (!rd.IsDBNull(rd.GetOrdinal("Detay7"))) detay.Detay7 = rd.GetString("Detay7");
                if (!rd.IsDBNull(rd.GetOrdinal("Detay8"))) detay.Detay8 = rd.GetString("Detay8");
                if(!rd.IsDBNull(rd.GetOrdinal("Detay9"))) detay.Detay9 = rd.GetString("Detay9");
                if (!rd.IsDBNull(rd.GetOrdinal("Detay10"))) detay.Detay10 = rd.GetString("Detay10");
                urunlistesi.Add(detay);
            }
            Globals.Globals.con.Close();
            return urunlistesi;
        }
    }
}
