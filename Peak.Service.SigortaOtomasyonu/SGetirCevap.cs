﻿using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using Peak.Entity.SigortaOtomasyonu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Service.SigortaOtomasyonu
{
    public class SGetirCevap
    {
        public List<String> GetirCevap(DTOTanimDetay detay)
        {
            EGetirCevap cevap = new EGetirCevap();
            return cevap.CevapGetir(detay);
        }
    }
}
