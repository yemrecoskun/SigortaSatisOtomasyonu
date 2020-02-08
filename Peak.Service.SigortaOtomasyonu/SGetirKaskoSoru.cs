using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
  public class SGetirKaskoSoru
    {
        public List<DTOTanimDetay> GetirKaskoSoru(DTOTanimDetay detay)
        {
            EGetirKaskoSoru egetir = new EGetirKaskoSoru();
            return egetir.kaskosoru(detay);
        }
    }
}
