using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
   public class SGetirSoru
    {
        public List<string> ServiceSoruGetir(string sorugetir)
        {
            ESoruGetir egetirsoru = new ESoruGetir();
            return egetirsoru.GetirSoru(sorugetir);
        }
    }
}
