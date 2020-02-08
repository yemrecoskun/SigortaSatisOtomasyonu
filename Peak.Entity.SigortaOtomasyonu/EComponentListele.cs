using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
    public class EComponentListele
    {
        public List<DTOTanimDetay> componentlistele()
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select id,detay1 from sgt_tanimdetay where tanim_id='6'",Globals.Globals.con);
            List<DTOTanimDetay> componentlistesi = new List<DTOTanimDetay>();
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTOTanimDetay detay = new DTOTanimDetay();
                detay.id = Convert.ToInt16(rd.GetString("id"));
                detay.Detay1 = rd.GetString("Detay1");
                componentlistesi.Add(detay);
            }Globals.Globals.con.Close();
            return componentlistesi;
        }
    }
}
