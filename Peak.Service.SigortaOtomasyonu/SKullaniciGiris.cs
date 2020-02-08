using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
    public class SKullaniciGiris
    {
        public string KullaniciGiris(DTOKullanici kullanici)
        {
            EKullaniciGiris kullanicigiris = new EKullaniciGiris();
            return kullanicigiris.KullaniciGiris(kullanici);
        }
    }
}
