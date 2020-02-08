using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
    public class EMusteriDogrula
    {
        public string musteridogrula(string Kimlik)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) Globals.Globals.con.Close();
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sgt_musteri where TCKimlik='"+Kimlik+"'",Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            var MusteriNo = "";
            while (rd.Read()) MusteriNo = rd.GetString("MusteriNo");
            rd.Close();
                if (String.IsNullOrEmpty(MusteriNo)) return "Müşteri Bulunamadi";
                else return MusteriNo;
        }
    }
}
