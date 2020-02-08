using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
  public class SMusteriDogrula
    {
        public string musteridogrula(string Kimlik)
        {
            EMusteriDogrula emusteridogrula = new EMusteriDogrula();
            return emusteridogrula.musteridogrula(Kimlik);
        }
    }
}
