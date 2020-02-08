using MySql.Data.MySqlClient;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Peak.Entity.SigortaOtomasyonu
{
    public class EKaskoSatis
    {
        public string SatisKasko(List<String> satisevraklari)
        {
            EMusteriDogrula emusteribul = new EMusteriDogrula();
            if (emusteribul.musteridogrula(satisevraklari[0]) == "Müşteri Bulunamadi")
            {
                return emusteribul.musteridogrula(satisevraklari[0]);
            }
            else if (emusteribul.musteridogrula(satisevraklari[1]) == "Müşteri Bulunamadi")
            {
                return emusteribul.musteridogrula(satisevraklari[1]);
            }
            else
            {
                int policenumarası = 0;
                List<DTOTanimDetay> satiskimligi = new List<DTOTanimDetay>();
                DTOTanimDetay satiskimlik = new DTOTanimDetay();
                DTOTanimDetay satiskimlik2 = new DTOTanimDetay();
                satiskimlik.tanim_id = 8;
                satiskimlik2.tanim_id = 8;
                satiskimlik.Detay2 = emusteribul.musteridogrula(satisevraklari[0]);
                satiskimlik2.Detay2 = emusteribul.musteridogrula(satisevraklari[0]);
                satiskimlik.Detay3 = "1";
                satiskimlik2.Detay3 = "2";
                XElement SatisKasko = new XElement("Satis");
                XElement yenibilgi;
                int i = 0;
                EGetirKaskoSoru SoruGetir = new EGetirKaskoSoru();
                DTOTanimDetay detay = new DTOTanimDetay();
                DTOTanimDetay satiskaskodetayi = new DTOTanimDetay();
                detay.Detay1 = "ComponentTanimi";
                detay.Detay2 = "Müsteri Componenti";
                foreach (var item in SoruGetir.kaskosoru(detay))
                {
                    yenibilgi = new XElement(item.Detay5);
                    yenibilgi.Add(satisevraklari[i]);
                    SatisKasko.Add(yenibilgi);
                    i++;
                }
                SoruGetir = new EGetirKaskoSoru();
                detay = new DTOTanimDetay();
                detay.Detay1 = "UrunTanimi";
                detay.Detay2 = "Kasko";
                foreach (var item in SoruGetir.kaskosoru(detay))
                {
                    yenibilgi = new XElement(item.Detay5);
                    yenibilgi.Add(satisevraklari[i]);
                    SatisKasko.Add(yenibilgi);
                    i++;
                }
                int j = i;
                SoruGetir = new EGetirKaskoSoru();
                detay = new DTOTanimDetay();
                detay.Detay1 = "ComponentTanimi";
                detay.Detay2 = "Satis Componenti";
                foreach (var item in SoruGetir.kaskosoru(detay))
                {
                    yenibilgi = new XElement(item.Detay5);
                    yenibilgi.Add(satisevraklari[i]);
                    SatisKasko.Add(yenibilgi);
                    i++;
                }
                if (Globals.Globals.con.State == System.Data.ConnectionState.Closed) Globals.Globals.con.Open();
                MySqlCommand policeno = new MySqlCommand("select (max(Detay8)) from sgt_tanimdetay;", Globals.Globals.con);
                var rd = policeno.ExecuteReader();
                while (rd.Read()) { policenumarası = Convert.ToInt16(rd.GetString(0))+1; }
                satiskimlik.Detay1 = policenumarası.ToString();
                satiskimlik2.Detay1 = policenumarası.ToString();
                satiskaskodetayi.tanim_id = 7;
                satiskaskodetayi.Detay1 = "Kasko";
                satiskaskodetayi.Detay2 = SatisKasko.ToString();
                satiskaskodetayi.Detay3 = satisevraklari[j];
                satiskaskodetayi.Detay4 = satisevraklari[j + 1];
                satiskaskodetayi.Detay5 = satisevraklari[j + 2];
                satiskaskodetayi.Detay6 = satisevraklari[j + 3];
                satiskaskodetayi.Detay7 = satisevraklari[j + 4];
                satiskaskodetayi.Detay8 = (policenumarası).ToString();
                satiskaskodetayi.Detay9 = "10";
                satiskaskodetayi.Detay10 = "10";
                satiskimligi.Add(satiskimlik);
                satiskimligi.Add(satiskimlik2);
                rd.Close();
                MySqlCommand cmd = new MySqlCommand("insert into sgt_tanimdetay(`tanim_id`,`Detay1`,`Detay2`,`Detay3`,`Detay4`,`Detay5`,`Detay6`,`Detay7`,`Detay8`,`Detay9`,`Detay10`) values('" + satiskaskodetayi.tanim_id + "','" + satiskaskodetayi.Detay1 + "','" + satiskaskodetayi.Detay2 + "','" + satiskaskodetayi.Detay3 + "','" + satiskaskodetayi.Detay4 + "','" + satiskaskodetayi.Detay5 + "','" + satiskaskodetayi.Detay6 + "','" + satiskaskodetayi.Detay7 + "','" + satiskaskodetayi.Detay8 + "','" + satiskaskodetayi.Detay9 + "','" + satiskaskodetayi.Detay10 + "')", Globals.Globals.con);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("select max(id) from sgt_tanimdetay", Globals.Globals.con);
                rd = cmd.ExecuteReader();
                int tanimdetay_id = 0;
                while (rd.Read()) tanimdetay_id = Convert.ToInt16(rd.GetString(0));
                rd.Close();
                cmd = new MySqlCommand("insert into `sgt_tanimdetayaciklamasi`(`tanimdetay_id`,`Detay1`,`Detay2`,`Detay3`,`Detay4`,`Detay5`,`Detay6`,`Detay7`,`Detay8`,`Detay9`,`Detay10`) values('" + tanimdetay_id + "', 'TanimKodu', 'SatisXML', 'Baslangic', 'Bitis', 'HesapNo', 'OdemeAraci', 'Teminat', 'PoliceNo', 'Tutar1', 'Tutar2')", Globals.Globals.con);
                cmd.ExecuteNonQuery();
                foreach(var item in satiskimligi)
                {
                    cmd = new MySqlCommand("insert into sgt_tanimdetay(`tanim_id`,`Detay1`,`Detay2`,`Detay3`,`Detay4`,`Detay5`,`Detay6`,`Detay7`,`Detay8`,`Detay9`,`Detay10`) values('"+item.tanim_id+"','"+item.Detay1+"','"+item.Detay2+"','"+item.Detay3+"','','','','','','','')",Globals.Globals.con);
                    cmd.ExecuteNonQuery();
                    cmd = new MySqlCommand("select max(id) from sgt_tanimdetay", Globals.Globals.con);
                    rd = cmd.ExecuteReader();
                    while (rd.Read()) tanimdetay_id = Convert.ToInt16(rd.GetString(0));
                    rd.Close();
                    cmd = new MySqlCommand("insert into `sgt_tanimdetayaciklamasi`(`tanimdetay_id`,`Detay1`,`Detay2`,`Detay3`,`Detay4`,`Detay5`,`Detay6`,`Detay7`,`Detay8`,`Detay9`,`Detay10`) values('" + tanimdetay_id + "', 'Poliçe ID', 'Müşteri NO', 'Sigorta Kişi Tipi', '', '', '', '', '', '', '')", Globals.Globals.con);
                    cmd.ExecuteNonQuery();

                }
                Globals.Globals.con.Close();
                return ("ÜrünSatildi\n" + SatisKasko.ToString());
            }
        }
    }
}
