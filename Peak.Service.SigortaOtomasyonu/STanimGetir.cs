using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using Peak.Entity.SigortaOtomasyonu;
namespace Peak.Service.SigortaOtomasyonu
{
  public   class STanimGetir
    {
        public List<DTOTanim> tanim()
        {
           
            ETanimGetir getir = new ETanimGetir();
            return getir.tanimgetir();
        }
    }
}
