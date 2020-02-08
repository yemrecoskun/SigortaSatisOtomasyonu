using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
    public class SCevapDuzenle
    {
        public void CevapDuzenle(DTOTanimDetay detay)
        {
            ECevapDuzenle cevapDuzenle = new ECevapDuzenle();
            cevapDuzenle.guncellecevap(detay);
        }
    }
}
