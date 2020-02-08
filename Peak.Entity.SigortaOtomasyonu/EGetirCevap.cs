using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
 public class EGetirCevap
    {
        public List<string> CevapGetir(DTOTanimDetay detay)
        {
            List<String> cevaplistesi = new List<String>();
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select Detay4 from sgt_tanimdetay where Detay3='"+detay.Detay3+"' and tanim_id='5' " ,Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                cevaplistesi.Add(rd.GetString(0));
            }
            Globals.Globals.con.Close();
            return cevaplistesi;
        }
    }
}
