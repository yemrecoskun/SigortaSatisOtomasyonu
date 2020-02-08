using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
   public class SComponentDuzenle
    {
        public void componentduzenle(DTOTanimDetay detay) { 
        EComponentDuzenle ecomponent = new EComponentDuzenle();
            ecomponent.guncellecomponent(detay);
                }
    }
}
