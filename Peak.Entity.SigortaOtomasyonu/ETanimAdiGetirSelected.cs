using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
   public class ETanimAdiGetirSelected
    {
        public List<string> stanimadigetirselected(string getir)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select distinct(Detay1) from sgt_tanimdetay where tanim_id = (select id from sgt_tanim where tanim_kodu = '"+getir+ "') and tanim_id not in (4,5)", Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            List<string> tanimkodu = new List<string>();
            while (rd.Read())
            {
                tanimkodu.Add(rd.GetString("Detay1"));
            }
            Globals.Globals.con.Close();
            return tanimkodu;
        }
    }
}
