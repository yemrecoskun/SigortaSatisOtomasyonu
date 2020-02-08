using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
    public class EUrunDuzenle
    {
        public void guncelleurun(DTOTanimDetay detay)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("update sgt_tanimdetay set Detay1='"+detay.Detay1+"',Detay2='"+detay.Detay2+ "',Detay3='" + detay.Detay3 + "',Detay4='" + detay.Detay4 + "',Detay5='" + detay.Detay5 + "',Detay6='" + detay.Detay6 + "',Detay7='" + detay.Detay7 + "',Detay8='" + detay.Detay8 + "',Detay9='" + detay.Detay9 + "',Detay10='" + detay.Detay10 + "' where id='"+detay.id+"'",Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }
    }
}
