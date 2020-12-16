



//Toastr Messages
function errorMes(message, errorTitle) {
    toastr.error(message, errorTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};

function warningMes(message, warTitle) {
    toastr.warning(message, warTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};

function sucMes(message, sucTitle) {

    toastr.success(message, sucTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "700",
        "hideDuration": "1000",
        "timeOut": "3000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};


//  Regex ile giriş güvenliği geliştirilebilir 
$('#sendInfoContact').on('click', function () {
    data = {
        NameSurname: $('#contactNameSurname').val(),
        Email: $('#contactEmail').val(),
        Phone: $('#contactPhone').val(),

    };

    if (data.NameSurname == null || data.NameSurname == " " || data.NameSurname.length < 1) {
        warningMes(data.Username, "Adınız Soyadınız Hatalı");
        $('#errNameSurnameContact').removeClass('hidden');
        $('#errNameSurnameContact').addClass('show');
    } else {
        $('#errNameSurnameContact').removeClass('show');
        $('#errNameSurnameContact').addClass('hidden');
    }

    if (data.Email == null || data.Email == " " || data.Email.length < 9) {
        warningMes(data.Email, "Email Hatalı");
        $('#errEmailContact').removeClass('hidden');
        $('#errEmailContact').addClass('show');
    } else {
        $('#errEmailContact').removeClass('show');
        $('#errEmailContact').addClass('hidden');
    }
    if (data.Phone == null || data.Phone == " " || data.Phone.length < 5) {
        warningMes(data.Phone, "Telefon Hatalı");
        $('#errPhoneContact').removeClass('hidden');
        $('#errPhoneContact').addClass('show');
    }
    else {
        $('#errPhoneContact').removeClass('show');
        $('#errPhoneContact').addClass('hidden');
    }

    if (data.NameSurname != "" && data.NameSurname != null &&
        data.Phone != "" && data.Phone != null && data.Email != "" && data.Email != null && data.NameSurname.length > 1 && data.Email.length > 9 && data.Phone.length > 5) {

        $.ajax({
            type: "post",
            url: "/Home/sendContactInfo",
            data: data,
            success: function (e) {
                if (e == true) {
                    sucMes(data.NameSurname, "Mesajınız bize ulaşmıştır.");
                    setInterval(function () {
                        window.location.reload();
                    }, 3000);

                } else if (e = "err") {
                    success(data.NameSurname + "Mesajınız bize ulaşmıştır.");
                    setInterval(function () {
                        window.location.reload();
                    }, 3000);
                }
                else {
                    errorMes("Başvurunuz bize ulaşmamıştır.", "Hatalı Gönderim");
                }
            }
        });

    } else {
        warningMes("Girişleri Kontrol Edin", "Hatalı Giriş");
    }




});



//Annound Pop Up

$(".sendDataAnnoun").on("click", function () {

    var annouId = $(this).attr('annId');
    if (annouId == null) {
        warningMes('', 'Duyuruya Ulaşılamadı');
    }
    else {
        var data = {
            ID: annouId
        };
        $.ajax({
            type: "post",
            url: "/Home/findAnnoun",
            data: data,
            success: function (e) {
                if (e == false || e == undefined) {
                    html = "<div style='color:red;'>Duyuruya erişirken bir hata oluştu.</div>";
                    $("#anCont").html(html);
                    warningMes('Duyuru Gösterilemiyor', 'Hata ile karşılaşıldı');
                } else if (e == null || e == "") {
                    html = "<div>Duyuru'nun içeriği bulunmamaktadır.</div>";
                    $("#anCont").html(html);
                }
                else {
                    html = "<div>" + e + "</div>";
                    $("#anCont").html(html);
                }
            }
        })
    }
});



// Get Layout Datas

function getSocial() {
    $.ajax({
        url: "/Partial/Social",
        type: "get",
        success: function (response) {
            if (response.Name == null || response.Name == undefined || response.Name == "") {
                var html2 = "";
                html2 += '<div class="container-fluid">' +
                    '<div class="row">' +
                    '<div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">' +
                    '<div class="sosyal-icon" style="float:left; margin-top: 8px;">' +
                    '<ul>' +
                    '<li><a oncontextmenu="return false" target="_blank" href="//' + response.GeneralSettings.FacebookUrl + '"><i class="fa fa-facebook-official"></i></a></li>' +
                    '<li><a oncontextmenu="return false" target="_blank" href="//' + response.GeneralSettings.TwitterUrl + '"><i class="fa fa-twitter-square"></i></a></li>' +
                    '<li><a oncontextmenu="return false" target="_blank" href="//' + response.GeneralSettings.InstagramUrl + '"><i class="fa fa-instagram"></i></a></li>' +
                    '<li><a oncontextmenu="return false" target="_blank" href="//' + response.GeneralSettings.YoutubeUrl + '"><i class="fa fa-youtube"></i></a></li>' +
                    '</ul>' +
                    '</div>' +
                    '</div>' +
                    '<div class="col-md-5 col-lg-5 col-ms-12 col-xs-12">' +
                    '</div>' +
                    '<div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">' +
                    '<ul class="top-nav nav-right">' +
                    '<a oncontextmenu="return false" href ="" data-toggle="modal" data-target="#loginPopUp" >GİRİŞ YAP</a>' +
                    '<a oncontextmenu="return false" href="/UserRegister/Register"> | KAYIT OL</a>' +
                    '<li><a oncontextmenu="return false" href="">Destek Hattı :' + response.GeneralSettings.Phone + '</a></li>' +
                    '</ul>' +
                    '</div>' +
                    '</div>' +
                    '</div>'
                $("#topbarsocial").html(html2)
            }
            else {
                var html = "";
                html += '<div class="container-fluid">' +
                    '<div class="row">' +
                    '<div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 hidden-xs hidden-sm">' +
                    '<div class="sosyal-icon" style="float:left; margin-top: 8px;">' +
                    '<ul>' +
                    '<li><a oncontextmenu="return false" target="_blank" href="//' + response.GeneralSettings.FacebookUrl + '"><i class="fa fa-facebook-official"></i></a></li>' +
                    '<li><a oncontextmenu="return false"target="_blank" href="//' + response.GeneralSettings.TwitterUrl + '"><i class="fa fa-twitter-square"></i></a></li>' +
                    '<li><a oncontextmenu="return false" target="_blank" href="//' + response.GeneralSettings.InstagramUrl + '"><i class="fa fa-instagram"></i></a></li>' +
                    '<li><a oncontextmenu="return false" target="_blank" href="//' + response.GeneralSettings.YoutubeUrl + '"><i class="fa fa-youtube"></i></a></li>' +
                    '</ul>' +
                    '</div>' +
                    '</div>' +
                    '<div class="col-md-5 col-lg-5 col-ms-12 col-xs-12">' +
                    '</div>' +
                    '<div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">' +
                    '<ul class="top-nav nav-right">' +
                    '<a oncontextmenu="return false" >Merhaba ' + response.Name + '</a>' +
                    '<a oncontextmenu="return false" href ="/Login/Logout"  > |ÇIKIŞ YAP</a>' +
                    '<li><a oncontextmenu="return false" href="">Destek Hattı :' + response.GeneralSettings.Phone + '</a></li>' +
                    '</ul>' +
                    '</div>' +
                    '</div>' +
                    '</div>'
                $("#topbarsocial").html(html)

            }


        }

    })
}


function getMenu() {
    $.ajax({
        url: "/Partial/Menu",
        type: "get",
        success: function (response) {
            var html2 = "";
            for (var i = 0; i < response.MenuList.length; i++) {
                html2 += '<li class="mns" ><a oncontextmenu="return false" href="' + response.MenuList[i].Link + '">' + response.MenuList[i].Title + '</a><span class="hidden-xs hidden-sm subTitle">' + response.MenuList[i].Description + '</span></li>'
            }

            var html = "";
            var none = "";
            if ($(window).width() < 1001) {
                none = "display:none";
            }
            
            html += '<div class="col-lg-2 col-md-12 col-sm-6 col-xs-6">' +
                '<div class="cs-logo cs-logo-dark">' +
                '<div class="cs-media">' +
                '<figure><a oncontextmenu="return false" href="/"><img src="' + response.LogoUrl + '" alt="" /></a></figure>' +
                '</div>' +
                '</div>' +
                '<div class="cs-logo cs-logo-light">' +
                '<div class="cs-media">' +
                '<figure><a oncontextmenu="return false" href="/"><img src="' + response.LogoUrl + '" alt="" /></a></figure>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '<div id="menub" class="col-lg-10 col-md-10 col-sm-6 col-xs-6">' +
                '<div class="menubar"><i class="fa fa-bars">Menü</i></div>'+
                '<div class="menucs" style="' + none+'">' +
                '<nav class="main-navigationcs">' +
                '<ul>' +
                html2
            '</ul>' +
                '</nav>' +
                '</div>' +
                '</div>'
            $("#menuPart").html(html)
        }
    })
}

//Footer bilgileri getirirken problem var bakılacak

function getFooter() {

    $.ajax({

        url: "/Partial/FooterMenu",
        type: "get",
        success: function (footData) {


            $('#footerNote').html(footData.GeneralSettings.FooterNote);
            $('#footerPhone').html(footData.GeneralSettings.Phone);
            $('#footerMail').html(footData.GeneralSettings.Email);

            var html = "";
            for (var i = 0; i < footData.InfoPage.length; i++) {

                html += '<li><a oncontextmenu="return false" href="/' + footData.InfoPage[i].SeoUrl + '">' + footData.InfoPage[i].Title + '</a></li>'

            }
            //var videohtml = "";

            //for(var i = 0; i < response.packetlist.length; i++) {
            //    videohtml += '<li><a href="/' + response.packetlist[i].seourllink + '">' + response.packetlist[i].packagename + '</a></li>'
            //}

            $('#infoPages').html(html);
            //$('#videoedu').html(videohtml);

        }

    })
}




//Video Id Send to Pop Up

var id;


$('.buyPlease').on('click', function run() {

    warningMes("Eğitimi İzlemek İçin Satın Almalısınız");

});



$(".sendVideoId").on("click", function () {

    var ID = $(this).attr('vid');
    var packetId = $(this).attr('packetid');

    id = ID;

    getVideo(id, packetId);

});



$(document).on("click", ".menubar", function () {

    if ($(".menucs").attr("style") == "display:block") {

        $(".menucs").attr("style", "display:none");
    } else {

        $(".menucs").attr("style", "display:block");
    }

});

function getVideo(id, packetId) {

    var data = {
        ID: id,
        PID: packetId
    };

    $.ajax({
        url: "/VideoEduSystem/getVideo",
        type: "post",
        data: data,
        success: function (k) {
            if (k == false) {
                warningMes("", "Videoya Erişim Yetkiniz Yok ");
            }
            else {
                    
                $(".showVideo").html(
                    '<video controlslist="nodownload" controls autoplay> <source src="' + k + '" id="playVideo"  class="playVideo" type="video/mp4"> <source id="playVideo" class="playVideo" src="' + k + '" type="video/ogg"> <source id="playVideo" class="playVideo" src="' + k + '" type="video/avi"> </video>');

            }
        }

    })
}



function RegisterPost(formData) {

    var email = $('#Email').val();
    var pass = $('#Pass').val();

    var ajaxConfig = {

        type: "post",
        url: "/UserRegister/makeRegister",
        data: new FormData(formData),
        success: function (e) {
            if (e == email) {
                warningMes(e, "Kayıtlı Email Girdiniz");

            } else if (e == pass) {
                warningMes("", "Girilen Şifreler Birbirini Tutmuyor");
            }
            else if (e == true) {
                sucMes("'a aktivasyon linki gönderildi. Aktivasyon yaparak sisteme giriş yapabilirsiniz.", email)
                setInterval(function () {
                    window.location.href = "/";
                },
                    2000);
            }
            else {
                errorMes("", "Üye işlemi başarısız");
            }

        }
    }
    if ($(formData).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);

    return false;
}


//Login 

function LoginPost(formData) {

    var email = $("#loginEmail").val();

    var ajaxConfig = {

        type: "post",
        url: "/Login/Login",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                warningMes("Aktif Hesap Denediğinizden Emin Olun", "Email veya Şifreniz Hatalı");
            }
            else if (e == false) {
                warningMes("", "Lütfen Girişleri Kontrol Edin");
            }
            else if (e == "aktifErr") {
                warningMes(email, "Mail Aktivasyon Linkine Tıkladığınızdan Emin Olun");
            }
            else {
                sucMes(email, "Hoş Geldiniz ");
                setInterval(function myfunction() {
                    window.location.href = "/Home/Index";
                }, 3000);
            }
        }
    }
    if ($(formData).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);

    return false;
}




//////////////***** Blog Page *****///////////////////////

// ##Search Filter





//////**** Contact Section  ***/////



function ContactPost(formData) {

    var ajaxConfig = {

        type: "post",
        url: "/Contact/sendContactInfo",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                sucMes("", "Mesajınız Ulaşmıştır.Anasayfaya Yönlendiriliyorsunuz");
                setInterval(function succ() {
                    window.location.href = "/Home/Index";

                }, 4000);
            }
            else {
                errorMes("", "Gönderilirken bir hata ile karşılaşıldı");
            }
        }
    }
    if ($(formData).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);

    return false;


}





window.addEventListener('keydown', e => {
    if (e.key === 'F12') // detect f12
        e.preventDefault();
})
jQuery(document).ready(function () {
    function disableSelection(e) {
        if (typeof e.onselectstart != "undefined") e.onselectstart = function () {
            return false
        };
        else if (typeof e.style.MozUserSelect != "undefined") e.style.MozUserSelect = "none";
        else e.onmousedown = function () {
            return false
        };
        e.style.cursor = "default"
    }
    window.onload = function () {
        disableSelection(document.body)
    };

    window.addEventListener("keydown", function (e) {
        if (e.ctrlKey && (e.which == 65 || e.which == 66 || e.which == 67 || e.which == 70 || e.which == 73 || e.which == 80 || e.which == 83 || e.which == 85 || e.which == 86)) {
            e.preventDefault()
        }
    });
    document.keypress = function (e) {
        if (e.ctrlKey && (e.which == 65 || e.which == 66 || e.which == 70 || e.which == 67 || e.which == 73 || e.which == 80 || e.which == 83 || e.which == 85 || e.which == 86)) { }
        return false
    };

    document.onkeydown = function (e) {
        e = e || window.event;
        if (e.keyCode == 123 || e.keyCode == 18) {
            return false
        }
    };

    document.oncontextmenu = function (e) {
        var t = e || window.event;
        var n = t.target || t.srcElement;
        if (n.nodeName != "A") return false
    };
    document.ondragstart = function () {
        return false
    };


  

});
