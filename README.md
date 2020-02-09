# SigortaSatisOtomasyonu
## Projemizin Amacı
- Müşterilere sigorta satışı yapar.
- Sigorta satışı yapan bir sigorta tanımı oluşturur.(örnek: Kasko Sigortası oluştur.)
- Sigorta satışı oluşturduğunda çeşitli sigortalar satabilir.
- Kalıcı olarak doldurulması gereken bir alan oluşur.(Tüm sigorta satış ekranlarında bulunan alan(örnek: Müşteri Bilgileri: Ad,Soyad) 

## Kullanılan Programlar
- ASP.NET MVC FRAMEWORK
- MySQL Workbench
- Katmanlı Mimari
- Bootstrap

## Projemizın Kullanımı
### Projemizde çeşitli tanımlar mevcuttur.
  - <b>Kullanıcı Tanımı:</b> Kullanıcı ekler, günceller ve listeler.
  - <b>Soru Tanımı:</b> Sigorta Satışı için bizlere verilen sorular( örnek: Araç Markası )
  - <b>Cevap Tanımı:</b> Sigorta Satışı için bizlere verilen bazı sorular için kalıcı cevaplar( örnek: Araç Markası Sorusu, Cevap: Hyundai)
  - <b>Ürün Tanımı:</b> Yeni sigorta satışı (ürün) oluştururuz.(örnek: Araç Sigortası)
  - <b>Component Tanımı:</b> Her sigorta satışında bulunması gereken genel bilgiler içerir.(örnek: Müşteri Adı,Soyadı) 
### Sigorta Satışı Yapmak.
  - Satış Paneline geldiğimizde Ürün seçiyoruz( Araç Sigortası vs.) Ürüne Ait tüm sorular ekrana gelir ve satışımızı oluşturarak bize 
  JSON formatında dosya oluşturur.
