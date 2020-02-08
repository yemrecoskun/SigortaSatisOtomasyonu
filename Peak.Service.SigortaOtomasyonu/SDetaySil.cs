using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
   public class SDetaySil
    {
        public void urunsil(int id) { 
        EDetaySil sil = new EDetaySil();
            sil.SilUrun(id);
        }
    }
}
