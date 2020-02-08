using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
 public   class SEkleUrun
    {
        public void ekleurun(string Detay1, string Detay2)
        {
            EUrunEkle ekle = new EUrunEkle();
            ekle.urunekle(Detay1, Detay2);
        }
    }
}
