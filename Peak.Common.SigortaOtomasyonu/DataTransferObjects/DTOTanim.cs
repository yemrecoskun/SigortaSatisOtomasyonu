using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Common.SigortaOtomasyonu.DataTransferObjects
{
   public class DTOTanim
    {
        public int id { get; set; }
        public string tanim_kodu { get; set; }
        public string tanim_aciklamasi { get; set; }
        public string tanim_adi { get; set; }
    }
}
