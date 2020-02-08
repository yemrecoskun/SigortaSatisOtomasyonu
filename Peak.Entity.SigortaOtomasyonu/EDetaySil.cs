using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Entity.SigortaOtomasyonu
{
  public  class EDetaySil
    {
        public void SilUrun(int id)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from sgt_tanimdetay where id='"+id+"'",Globals.Globals.con);
            cmd.ExecuteReader();
            cmd = new MySqlCommand("delete from sgt_tanimdetayaciklamasi where tanimdetay_id='" + id + "'", Globals.Globals.con);
            cmd.ExecuteReader();
            Globals.Globals.con.Close();
        }
    }
}
