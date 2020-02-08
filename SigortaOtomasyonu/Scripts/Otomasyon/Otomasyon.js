//Soru ekleme ekranında tanım kodlarına göre tanım listesini selected,opotiona ekler.
$(document).ready(function () {
    $("select#tanimkodu").change(function () {
        var deger = $("select#tanimkodu").find(":selected").text();
        $.ajax({
            url: '/Home/tanimgetir/',
            type: 'POST',
            dataType: 'json',
            data: { getir: deger },
            success: function (data) {
                $('select#tanimadi').find('option').remove();
                $('select#tanimadi').append(`<option value="Seçiniz"> Seçiniz</option>`);
                $.each(data, function (index) {
                    $('select#tanimadi').append(new Option(data[index], true));
                });
            }
        });
    });
});
//Cevap Ekranında soruları getirir.
$(document).ready(function () {
    $("select#tanimadi").change(function () {
        var deger = $("select#tanimadi").find(":selected").text();
        $.ajax({
            url: '/Home/sorugetir/',
            type: 'POST',
            dataType: 'json',
            data: { sorugetir: deger },
            success: function (data) {
                $('select#soruadi').find('option').remove();
                $('select#soruadi').append(`<option value="Seçiniz"> Seçiniz</option>`);
                $.each(data, function (index) {
                    $('select#soruadi').append(new Option(data[index], true));
                });
            }
        });
    });
});
//Component ekleme
function componentekle() {
    var Detay1 = $("input#componentadi").val();
    if ($('button#kaydetcomponent').text() == "Kaydet") {
        if (confirm("Componenti Eklemek İstediğinize Emin misiniz?")) {
            $.ajax({
                url: '/Home/ComponentKaydet/',
                type: 'POST',
                dataType: 'json',
                data: { Detay1: Detay1 },
                success: function (data) {
                    if (data == "boş");
                    else ($("table table-striped custab").append(data));
                }
            })
        }
    }
    else {
        if (confirm("Düzenlemek İstediğinize Emin misiniz?")) {
            $.ajax({
                url: '/Home/DuzenleComponent/',
                type: 'POST',
                dataType: 'json',
                data: { Detay1: Detay1 },
                error
                    : function (xhr, status, error) {
                        var err = eval("(" + xhr.responseText + ")");
                        alert(err.Message);
                    },
                success: function (data) {
                    alert("COMPONENT DÜZENLENMİŞTİR");
                    location.reload();
                }

            })
        }
        $('button#kaydetcevap').text("Kaydet");
    }
}

//cevap ekleme ekranında ekle butonuna bastığımızda cevap ekler veya düzenle butonuna bastığımızda cevap düzenler.
function cevapekle() {
    var Detay1 = $("select#tanimkodu").find(":selected").text();
    var Detay2 = $("select#tanimadi").find(":selected").text();
    var Detay3 = $("select#soruadi").find(":selected").text();
    var Detay4 = $("input#cevap").val();
    if ($('button#kaydetcevap').text() == "Kaydet") {
        if (confirm("Cevabı Eklemek İstediğinize Emin misiniz?")) {
            $.ajax({
                url: '/Home/CevapKaydet/',
                type: 'POST',
                dataType: 'json',
                data: { Detay1: Detay1, Detay2: Detay2, Detay3: Detay3, Detay4: Detay4 },
                success: function (data) {
                    if (data == "boş");
                    else ($("table table-striped custab").append(data));
                }
            })
        }
    }
    else {
        if (confirm("Düzenlemek İstediğinize Emin misiniz?")) {
            $.ajax({
                url: '/Home/DuzenleCevap/',
                type: 'POST',
                dataType: 'json',
                data: { Detay1: Detay1, Detay2: Detay2, Detay3: Detay3, Detay4: Detay4 },
                success: function (data) {
                    alert("CEVAP DÜZENLENMİŞTİR");
                    location.reload();
                }
            })
        }
        $('button#kaydetcevap').text("Kaydet");
    }
}
//soru ekleme ekranında ekle butonuna bastığımızda soruyu ekler veya düzenle butonuna bastığımızda soruyu düzenler.
function soruekle() {
    var Detay1 = $("select#tanimkodu").find(":selected").text();
    var Detay2 = $("select#tanimadi").find(":selected").text();
    var Detay3 = $("input#soru").val();
    var Detay4 = $("select#inputtipi").find(":selected").text();
    var Detay5 = $("input#soru_id").val();
    if ($('button#kaydet').text() == "Kaydet") {
        if (confirm("Soruyu Eklemek İstediğinize Emin misiniz?")) {
            $.ajax({
                url: '/Home/SoruKaydet/',
                type: 'POST',
                dataType: 'json',
                data: { Detay1: Detay1, Detay2: Detay2, Detay3: Detay3, Detay4: Detay4, Detay5: Detay5 },
                success: function (data) {
                    if (data == "boş");
                    else {
                        $("table table-striped custab").append(data);
                    }
                }
            })
        }
    }
    else {
        if (confirm("Düzenlemek İstediğinize Emin misiniz?")) {
            $.ajax({
                url: '/Home/DuzenleSoru/',
                type: 'POST',
                dataType: 'json',
                data: { Detay1: Detay1, Detay2: Detay2, Detay3: Detay3, Detay4: Detay4, Detay5: Detay5 },
                success: function (data) {
                    alert("SORU DÜZENLENMİŞTİR");
                    location.reload();
                }
            })
        }
        $('button#kaydet').text("Kaydet");
    }
}

/*function sorulariGetir() {

    //TODO Veritabanından sorulisti getir.
    //Get metodunu kullan
    //soruListin içerisine datayı doldur.
    //sorulist içerisinde kayıt bazlı dönerek html' append ile item ekle
    var soruList;
    $.ajax({
        url: '/Home/SoruKaydet/',
        type: 'POST',
        dataType: 'json',
        data: { Detay1: Detay1, Detay2: Detay2, Detay3: Detay3, Detay4: Detay4, Detay5: Detay5 },
        success: function (data) {
            if (data == "boş");
            else {
                $("table table-striped custab").append(data);
            }
        }
    }) 
}*/

//Soruyu, Ürünü, Cevabı Siler
function Sil(id) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Home/Sil/' + id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                alert("Silindi");
                var a = "#" + data;
                $(a).remove();
            }

        });
    }
};
//Düzenlenecek soruyu soru ekleme ekranına verileri aktarır.
function DuzenleGetirSoru(id) {
    if (confirm("Düzenlemek istediginize Eminmisiniz")) {
        $.ajax({
            url: '/Home/DuzenleGetirSoru/' + id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                $('select#tanimkodu').val(data.Detay1);
                $('select#tanimadi').find(':selected').text(data.Detay2);
                $('input#soru').val(data.Detay3);
                $('select#inputtipi').val(data.Detay4);
                $('button#kaydet').text("Düzenle");
                $('input#soruid').val(data.Detay5);
            }
        })
    }
}
//Düzenlenecek cevabı cebap ekleme ekranına verileri aktarır.
function DuzenleGetirCevap(id) {
    if (confirm("Düzenlemek istediginize Emin misiniz?")) {
        $.ajax({
            url: '/Home/DuzenleGetirCevap/' + id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                $('select#tanimkodu').val(data.Detay1);
                $('select#tanimadi').find(':selected').text(data.Detay2);
                $('select#soruadi').find(':selected').text(data.Detay3);
                $('input#cevap').val(data.Detay4);
                $('button#kaydetcevap').text("Düzenle");
            }
        })
    }
}
//Düzenlenecek Componentleri component ekleme ekranına verileri aktarır.
function DuzenleGetirComponent(id) {
    if (confirm("Düzenlemek İstediğinize Emin misiniz?")) {
        $.ajax({
            url: '/Home/DuzenleGetirComponent/' + id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                $("input#componentadi").val(data.Detay1);
                $('button#kaydetcomponent').text("Düzenle");
            }
        })
    }
}
//Düzenlenecek Ürünü Modala verileri aktarır.
function edit_data(id) {
    $.ajax({
        url: '/Home/DuzenleGetirUrun/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            $('#id').val(data.id);
            $('#tanim_id').val(data.tanim_id);
            $('#Detay1').val(data.Detay1);
            $('#Detay2').val(data.Detay2);
            $('#Detay3').val(data.Detay3);
            $('#Detay4').val(data.Detay4);
            $('#Detay5').val(data.Detay5);
            $('#Detay6').val(data.Detay6);
            $('#Detay7').val(data.Detay7);
            $('#Detay8').val(data.Detay8);
            $('#Detay9').val(data.Detay9);
            $('#Detay10').val(data.Detay10);
        }
    });
}
//Satış Ekranındaki Tab olayları
function openCity(evt, cityName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}

//tabloyu sıralar
$(document).ready(function () {
    $('table#example').DataTable({
        "pagingType": "full_numbers"
    });
});
