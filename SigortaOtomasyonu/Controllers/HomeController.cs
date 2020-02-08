using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peak.Common.SigortaOtomasyonu.DataTransferObjects;
using Peak.Service.SigortaOtomasyonu;
namespace SigortaOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult AnaSayfa()
        {
            return View();
        }
        //Login true
        [HttpPost]
        public ActionResult LoginPage(string username, string pw)
        {
            SKullaniciGiris servicekullanicigiris = new SKullaniciGiris();
            DTOKullanici kullanici = new DTOKullanici();
            kullanici.Kullanici_Adi = username;
            kullanici.Sifre = pw;
            var rd = servicekullanicigiris.KullaniciGiris(kullanici);
            TempData["mesaj"] = rd;
            if (rd == "Giris Basarili") { return View("Anasayfa"); }

            else return View();
        }
        //Ürün Sayfası
        public ActionResult UrunTanimi()
        {
            return View();
        }
        //Detay Siler(Soru silebilir, ürün silebilir
        public JsonResult Sil(int id)
        {
            SDetaySil serviceurunsil = new SDetaySil();
            serviceurunsil.urunsil(id);
            return Json(id);
        }
        //Düzenlenen Ürünün Verilerini Getir-Götür işlemi

        public JsonResult DuzenleGetirUrun(int id)
        {
            Globals.Globals.duzenleid = id;
            SUrunListele serviceurun = new SUrunListele();
            DTOTanimDetay detay = new DTOTanimDetay();
            foreach ( var item in serviceurun.listeleurun())
            {
                if (item.id == id)   detay = item;   
            }
            return Json(detay);
        }

        //Düzenlenen Sorunun Verilerini Getir-Götür İşlemi
        public JsonResult DuzenleGetirSoru(int id)
        {
            Globals.Globals.duzenleid = id;
            SSoruListele servicesoru = new SSoruListele();
            DTOTanimDetay detay = new DTOTanimDetay();
            foreach(var item in servicesoru.soruistele())
            {
                if (item.id == id) detay = item;
            }
            return Json(detay);
        }
        //Düzenlenen Sorunun Verilerini Getir-Götür işlemi
        public JsonResult DuzenleGetirCevap(int id)
        {
            Globals.Globals.duzenleid = id;
            SCevapListele servicecevap = new SCevapListele();
            DTOTanimDetay detay = new DTOTanimDetay();
            foreach(var item in servicecevap.cevaplistesi())
            {
                if (item.id == id) detay = item;
            }
            return Json(detay);
        }
        //Düzenlenen Sorunun Verilerini Getir-Götür işlemi
        public JsonResult DuzenleGetirComponent(int id)
        {
            Globals.Globals.duzenleid = id;
            SComponentListele servicecomponent = new SComponentListele();
            DTOTanimDetay detay = new DTOTanimDetay();
            foreach(var item in servicecomponent.componentlistele())
            {
                if (item.id == id) detay = item;
            }
            return Json(detay);
        }
        //Ürünü Düzenler
        [HttpPost]
        public ActionResult Duzenle(DTOTanimDetay dTO)
        {
            dTO.id = Globals.Globals.duzenleid;
            SDuzenleUrun serviceduzenle = new SDuzenleUrun();
            serviceduzenle.Duzenle(dTO);
            return View("UrunTanimi");
        }
        //Ürün Kayıt
        public ActionResult kaydet(string Detay1K, string Detay2K)
        {
            SEkleUrun serviceurunekle = new SEkleUrun();
            serviceurunekle.ekleurun(Detay1K, Detay2K);
            return View("UrunTanimi");
        }
        public ActionResult SoruTanimi()
        {
            return View();
        }
        //Soruda tanıma ait verileri selected-optiona ekleme.
        public JsonResult tanimgetir(string getir)
        {
            SGetirTanimAdiSelected servicegetirtanimadi = new SGetirTanimAdiSelected();
            return Json(servicegetirtanimadi.tanimgetir(getir));
        }
        //Cevap Tanımında tanımlara ait soruları selected-optiona ekler.
        public JsonResult sorugetir(string sorugetir)
        {
            SGetirSoru servicegetirsoru = new SGetirSoru();
            return Json(servicegetirsoru.ServiceSoruGetir(sorugetir));
        }
        //Cevap Kaydeder.
        public JsonResult CevapKaydet(DTOTanimDetay detay)
        {
            if (detay.Detay1 != null && detay.Detay2 != null && detay.Detay3 != null && detay.Detay4 != null)
            { 
                SCevapEkle servicecevapekle = new SCevapEkle();
                servicecevapekle.EkleCevap(detay);
                return Json(detay);
            }
            else return Json("boş");
        }
        //Component Ekler.
        public JsonResult ComponentKaydet(DTOTanimDetay detay)
        {
            if (detay.Detay1 != null)
            {
                SComponentKaydet servicecomponentkaydet = new SComponentKaydet();
                servicecomponentkaydet.componentekle(detay);
                return Json(detay);
            }
            else return Json("boş");
        }
        //Soruları Kaydeder.
        public JsonResult SoruKaydet(DTOTanimDetay detay)
        {
            if (detay.Detay1 != null && detay.Detay2 !=null && detay.Detay3 !=null && detay.Detay4!=null && detay.Detay5!=null)
            {
                SSoruKaydet servicesorukaydet = new SSoruKaydet();
                servicesorukaydet.sorukaydet(detay);
                return Json(detay);
            }
            else return Json("boş");
        }
        //Soruyu Duzenler
        public JsonResult DuzenleSoru (DTOTanimDetay detay)
        {
            detay.id = Globals.Globals.duzenleid;
            SSoruDuzenle servicesoruduzenle = new SSoruDuzenle();
            servicesoruduzenle.soruduzenle(detay);
            return Json(detay);
        }
        //Cevabı Duzenler
        public JsonResult DuzenleCevap (DTOTanimDetay detay)
        {
            detay.id = Globals.Globals.duzenleid;
            SCevapDuzenle servicecevapduzenle = new SCevapDuzenle();
            servicecevapduzenle.CevapDuzenle(detay);
            return Json(detay);
        } 
        public JsonResult DuzenleComponent(DTOTanimDetay detay)
        {
            detay.id = Globals.Globals.duzenleid;
            SComponentDuzenle servicecomponentduzenle = new SComponentDuzenle();
            servicecomponentduzenle.componentduzenle(detay);
            return Json(detay);
        }
        public ActionResult CevapTanimi()
        {
            return View();
        }
        public ActionResult ComponentTanimi()
        {
            return View();
        }
        public ActionResult KaskoSatis()
        {
            return View();
        }
        public ActionResult urunSatisTanimi()
        {
            return View();
        }
        //Kasko Sigortası Satar.
        [HttpPost]
        public ActionResult KaskoSatis(List<String> satiskasko)
        {
            SKaskoSatis ServiceKaskoSatis = new SKaskoSatis();
            var rd = ServiceKaskoSatis.SSatisKasko(satiskasko);
            return Json(rd);
        }
    }
}