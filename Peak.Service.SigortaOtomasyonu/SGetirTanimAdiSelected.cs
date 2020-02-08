using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
    public class SGetirTanimAdiSelected
    {
        public List<String> tanimgetir(string getir)
        {
            ETanimAdiGetirSelected etanimadigetirselected = new ETanimAdiGetirSelected();
            return etanimadigetirselected.stanimadigetirselected(getir);
        }
    }
}
