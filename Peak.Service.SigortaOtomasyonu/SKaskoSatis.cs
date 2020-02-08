using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
 public class SKaskoSatis
    {
        public string SSatisKasko(List<String> KaskoEvraklar)
        {
            EKaskoSatis ESatisKasko = new EKaskoSatis();
            return ESatisKasko.SatisKasko(KaskoEvraklar);
        }
    }
}
