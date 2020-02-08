using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
    public class SSoruKaydet
    {
        public void sorukaydet(DTOTanimDetay detay)
        { 
        ESoruKaydet eSoruKaydet = new ESoruKaydet();
        eSoruKaydet.sorukaydet(detay);
        }
    }
}
