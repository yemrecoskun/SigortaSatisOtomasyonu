using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Peak.Entity.SigortaOtomasyonu
{
   public class ESoruGetir
    {
        public List<string> GetirSoru(string sorugetir)
        {
            List<string> sorulistesi = new List<string>();
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select Detay3 from sgt_tanimdetay where Detay2='"+sorugetir+"'and Detay4='Select'",Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                sorulistesi.Add(rd.GetString("Detay3"));
            }
            Globals.Globals.con.Close();
            return sorulistesi;
        }
    }
}
