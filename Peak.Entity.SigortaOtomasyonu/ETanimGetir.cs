using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
namespace Peak.Entity.SigortaOtomasyonu
{
    public class ETanimGetir
    {

        public List<DTOTanim> tanimgetir()
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sgt_tanim",Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            List<DTOTanim> tanimlistesi = new List<DTOTanim>();
            while (rd.Read())
            {
                DTOTanim tanim = new DTOTanim();
                tanim.id = Convert.ToInt16(rd.GetString("id"));
                tanim.tanim_kodu = rd.GetString("tanim_kodu");
                tanim.tanim_aciklamasi = rd.GetString("tanim_aciklamasi");
                tanim.tanim_adi = rd.GetString("tanim_adi");
                tanimlistesi.Add(tanim);
            }
            Globals.Globals.con.Close();
            return tanimlistesi;
        }
    }
}
