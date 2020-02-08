using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
    public class ECevapEkle
    {
        public void EkleCevap (DTOTanimDetay detay)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into sgt_tanimdetay(tanim_id, Detay1, Detay2, Detay3, Detay4) values('5', '" + detay.Detay1 + "', '" + detay.Detay2 + "', '" + detay.Detay3 + "', '" + detay.Detay4 + "')", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand("select max(id) from sgt_tanimdetay", Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            int tanimdetay_id = 0;
            while (rd.Read())
            {
                tanimdetay_id = Convert.ToInt16(rd.GetString(0));
            }
            rd.Close();
            cmd = new MySqlCommand("insert into `sgt_tanimdetayaciklamasi`(`tanimdetay_id`,`Detay1`,`Detay2`,`Detay3`,`Detay4`,`Detay5`,`Detay6`,`Detay7`,`Detay8`,`Detay9`,`Detay10`) values('" + tanimdetay_id + "', 'TanimKodu', 'TanimAdi', 'SoruAdi', 'Cevap', '', '', '', '', '', '')", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

    }
}
