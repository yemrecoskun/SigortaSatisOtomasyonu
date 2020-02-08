using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
  public  class SComponentKaydet
    {
        public void componentekle(DTOTanimDetay detay)
        { 
            EComponentEkle ecomponent = new EComponentEkle();
            ecomponent.ComponentEkle(detay);
        }

    }
}
