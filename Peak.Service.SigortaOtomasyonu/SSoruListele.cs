using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
 public class SSoruListele
    {
        public List<DTOTanimDetay> soruistele()
        {
            ESoruListele eSoruListele = new ESoruListele();
            return eSoruListele.sorulistele();
        }
    }
}
