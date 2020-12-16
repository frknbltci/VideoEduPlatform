
/* NOT IMPORTANT ERRORS
 * Düzenle PopUp açılması için bastığın butona err hiddenları gizleticez.
 * 
 * 
 * Controller da admin passiv or active de eğer admin ise passive olamaz
 * 
 * */

var id;
// USER OPERATIONS ******* //

// for making passive or active
$(".sendId").on("click", function () {
    var i = $(this).attr('userId');

    $('#makeActiveYesBtn').attr("onclick", "makeActiveOrPassive(" + i + ")");
    $('#makePassiveYesBtn').attr("onclick", "makeActiveOrPassive(" + i + ")");
});

// for editing send Id to popup
$(".btnsend").on("click", function () {
    var i = $(this).attr('uid');
    getUserInfo(i);
    id = i;
});

$("#userEditSend").on('click', function () {

    var data = {
        ID: id,
        Name: $('#editNameUser').val(),
        UserName: $('#editUserNameUser').val(),
        Password: $('#editPasswordUser').val(),
        Surname: $('#editSurnameUser').val(),
        Phone: $('#editPhoneUser').val(),
        Email: $('#editEmailUser').val(),
        Type: $("input:radio[name='editUserradioType']:checked").val(),
        Status: $("input:radio[name='editUserradioStatus']:checked").val(),
        Discount: $('#editDiscountUser').val(),
        BirthDate: $('#editBirthDateUser').val()
        // MemberShipDate: $('#editMemberShipDateUser').val()

    };


    if (data.Name == "" || data.Name == null) {
        $('#errName').removeClass('hidden');
        $('#errName').addClass('show');
    }
    else {
        $('#errName').removeClass('show');
        $('#errName').addClass('hidden');
    }
    if (data.Surname == "" || data.Surname == null) {
        $('#errSurname').removeClass('hidden');
        $('#errSurname').addClass('show');
    }
    else {
        $('#errSurname').removeClass('show');
        $('#errSurname').addClass('hidden');
    }

    if (data.UserName == "" || data.UserName == null) {
        $('#errUserName').removeClass('hidden');
        $('#errUserName').addClass('show');
    }
    else {
        $('#errUserName').removeClass('show');
        $('#errUserName').addClass('hidden');
    }
    if (data.Password == "" || data.Password == null) {
        $('#errPassword').removeClass('hidden');
        $('#errPassword').addClass('show');
    }
    else {
        $('#errPassword').removeClass('show');
        $('#errPassword').addClass('hidden');
    }
    if (data.Email == "" || data.Email == null) {
        $('#errEmail').removeClass('hidden');
        $('#errEmail').addClass('show');
    }
    else {
        $('#errEmail').removeClass('show');
        $('#errEmail').addClass('hidden');
    }
    if (data.Phone == "" || data.Phone == null) {
        $('#errPhone').removeClass('hidden');
        $('#errPhone').addClass('show');
    }
    else {
        $('#errPhone').removeClass('show');
        $('#errPhone').addClass('hidden');
    }


    if (data.Name != "" && data.Name != null && data.Surname != "" && data.Surname != null && data.UserName != "" && data.UserName != null &&
        data.Password != "" && data.Password != null && data.Email != "" && data.Email != null && data.Phone != "" && data.Phone != null) {

        $.ajax({
            type: "post",
            url: "/User/editUser",
            data: data,
            success: function (e) {

                if (e == true) {
                    sucMes(data.UserName, "Düzenleme İşlemi Başarılı");
                    setTimeout(() => { window.location.href = "/User/ListUsers"; }, 1000);

                }
                else if (e == data.UserName) {
                    warningMes(data.UserName, "Sistemde Kayıtlı Kullanıcı Adı");
                }
                else if (e == data.Email) {
                    warningMes(data.Email, "Sistemde Kayıtlı Mail Adresi");
                }
                else {
                    errorMes(data.UserName, "Kayıt İşlemi Yapılamadı");
                }
            }
        });

    }
    else {
        warningMes("Lütfen Zorunlu Alanları Doldurun", "Kayıt İşlemi Başarısız");
    }

});


function makeActiveOrPassive(i) {
    if (i == null && i <= 0) {
        warningMes(i, "Kullanıcıya Erişilemedi");
    } else {

        data = {
            ID: i
        };

        $.ajax({
            type: "post",
            url: "/User/makePassiveOrActiveUser",
            data: data,
            success: function (e) {
                if (e == true) {

                    sucMes("Onaylandı", "İşlem Başarılı");
                    setInterval(function () {
                        window.location.replace("/User/ListUsers");
                    }, 1000);
                }
                else {
                    errorMes("Başarısız", "Id'ye Erişilemedi.")
                }
            }
        });
    }

}

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

//Get User or Admin Information
function getUserInfo(i) {
    data = {
        ID: i
    };
    $.ajax({
        type: "post",
        url: "/User/getUserInfo",
        data: data,
        success: function (e) {
            if (e != false) {
                //User Pop Up Dolumu

                $('#editNameUser').val(e.Name);
                $('#editSurnameUser').val(e.Surname);
                $('#editUserNameUser').val(e.UserName);
                $('#editEmailUser').val(e.Email);
                $('#editPhoneUser').val(e.Phone);
                $('#editDiscountUser').val(e.Discount);
                $('#editBirthDateUser').val(e.sBirthDate);
                //   $('#editMemberShipDateUser').val(e.sMemberShipDate);
                $('#editPasswordUser').val(e.Password);
                if (e.Type == false) {
                    $('#userSelected').attr('checked', 'checked');
                } else {
                    $('#adminSelected').attr('checked', 'checked');

                }
                if (e.Status == true) {
                    $('#activeSelected').attr('checked', 'checked');
                } else {
                    $('#passsiveSelected').attr('checked', 'checked');
                }

                //Admin Pop Up Dolumu
                $('#hiddenId').val(id);
                $('#editNameAdmin').val(e.Name);
                $('#editSurnameAdmin').val(e.Surname);
                $('#editUserNameAdmin').val(e.UserName);
                $('#editEmailAdmin').val(e.Email);
                $('#editPhoneAdmin').val(e.Phone);
                $('#editResumeAdmin').val(e.Resume);

                if (e.ImageUrl != null) {
                    $('#uploadImage').attr('src', e.ImageUrl);
                    $('#hiddenImageUrl').val(e.ImageUrl);

                } else {
                    var origin = window.location.origin;
                    $('#uploadImage').attr('src', origin + "/Assets/Images/noImgMan.jpg");
                    $('#hiddenImageUrl').val("/Assets/Images/noImgMan.jpg");
                }
                $('#editDiscountUser').val(e.Discount);
                $('#editBirthDateUser').val(e.sBirthDate);

                $('#editMemberShipDateUser').val(e.sMemberShipDate);
                $('#editPasswordAdmin').val(e.Password);
                if (e.Type == false) {
                    $('#userSelected').attr('checked', 'checked');
                } else {
                    $('#adminSelected').attr('checked', 'checked');

                }
                if (e.Status == true) {
                    $('#activeSelected').attr('checked', 'checked');
                } else {
                    $('#passsiveSelected').attr('checked', 'checked');
                }

            }
            else {

            }

        },

    });

}

//Preview Admin Photo
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#uploadImage').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#file").change(function () {
    readURL(this);
});


//Add User
$('#addUserBtn').on('click', function () {
    data = {
        Name: $('#addName').val(),
        Surname: $('#addSurname').val(),
        UserName: $('#addUserName').val(),
        Password: $('#addPassword').val(),
        Email: $('#addEmail').val(),
        Phone: $('#addPhone').val(),
        Discount: $('#addDiscount').val(),
        BirthDate: $('#addBirthDate').val(),
        Type: $("input:radio[name='addradioType']:checked").val(),
        Status: $("input:radio[name='addradioStatus']:checked").val()


    };

    if (data.Name == "" || data.Name == null) {
        $('#errName').removeClass('hidden');
        $('#errName').addClass('show');
    }
    else {
        $('#errName').removeClass('show');
        $('#errName').addClass('hidden');
    }
    if (data.Surname == "" || data.Surname == null) {
        $('#errSurname').removeClass('hidden');
        $('#errSurname').addClass('show');
    }
    else {
        $('#errSurname').removeClass('show');
        $('#errSurname').addClass('hidden');
    }

    if (data.UserName == "" || data.UserName == null) {
        $('#errUserName').removeClass('hidden');
        $('#errUserName').addClass('show');
    }
    else {
        $('#errUserName').removeClass('show');
        $('#errUserName').addClass('hidden');
    }
    if (data.Password == "" || data.Password == null) {
        $('#errPassword').removeClass('hidden');
        $('#errPassword').addClass('show');
    }
    else {
        $('#errPassword').removeClass('show');
        $('#errPassword').addClass('hidden');
    }
    if (data.Email == "" || data.Email == null) {
        $('#errEmail').removeClass('hidden');
        $('#errEmail').addClass('show');
    }
    else {
        $('#errEmail').removeClass('show');
        $('#errEmail').addClass('hidden');
    }
    if (data.Phone == "" || data.Phone == null) {
        $('#errPhone').removeClass('hidden');
        $('#errPhone').addClass('show');
    }
    else {
        $('#errPhone').removeClass('show');
        $('#errPhone').addClass('hidden');
    }
    if (data.Name != "" && data.Name != null && data.Surname != "" && data.Surname != null && data.UserName != "" && data.UserName != null &&
        data.Password != "" && data.Password != null && data.Email != "" && data.Email != null && data.Phone != "" && data.Phone != null) {

        $.ajax({
            type: "post",
            url: "/User/addUser",
            data: data,
            success: function (e) {
                if (e == true) {
                    sucMes(data.UserName, "Kayıt İşlemi Başarılı");
                    window.location.href("/User/ListUsers");
                }
                else if (e == data.Email) {
                    warningMes(data.UserName, "Böyle bir kullanıcı tanımlı");
                }
                else {
                    errorMes(data.UserName, "Kayıt İşlemi Yapılamadı");
                }
            }
        });

    }
    else {
        warningMes("Lütfen Zorunlu Alanları Doldurun", "Kayıt İşlemi Başarısız");

    }




});


// Edit Admin
function editAdminPost(formData) {
    var eusname = $('#editUserNameAdmin').val();
    var eemail = $('#editEmailAdmin').val();

    var ajaxConfig = {
        type: "post",
        url: "/User/editAdmin",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                sucMes('', 'Düzenleme İşlemi Başarılı');
                setInterval(function runn() {
                    window.location.href = "/User/ListUsers";
                }, 2000);
            }
            else if (e == eusname) {
                warningMes(e, "Sistemde böyle bir kullanıcı kayıtlı email ve kullanıcı adını kontrol edin.");
            }
            else if (eemail == e) {
                warningMes(e, "Sistemde böyle bir email kayıtlı email ve kullanıcı adını kontrol edin.");
            }
            else {
                errorMes("", "Düzenleme Yapılamadı");
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

// USER OPERATIONS END ******* //

//SETTINGS OPERATIONS **** //

// to make Menus Active or Passive 

$('.menuActOrPass').on('click', function () {
    var menuId = $(this).attr('menuid');

    $('#makePassiveMenuYesBtn').attr("onclick", "makeActMenuOrPass(" + menuId + ")");
    $('#makeActiveMenuYesBtn').attr("onclick", "makeActMenuOrPass(" + menuId + ")");

});


function makeActMenuOrPass(menuId) {
    if (menuId == null && i <= 0) {
        warningMes("", "Menüye Erişilemedi");
    } else {
        data = {
            ID: menuId
        };

        $.ajax({
            type: "post",
            url: "/Settings/makeMenuPassOrAct",
            data: data,
            success: function (e) {
                if (e == null || e == 0) {

                    warningMes(e, "Id'li Menüye ulaşılamadı");

                }
                else {
                    sucMes("", "İşlem Başarıyla Gerçekleştirildi")
                    setInterval(function () {
                        window.location.replace("/Settings/Menu");
                    }, 1000);
                }
            }
        });
    }

}



// to  edit Menu

$(".menuEdit").on("click", function () {
    var menuId = $(this).attr('menuid');

    if (menuId == null) {
        warningMes("Başarısız", "Menü Id'ye ulaşılamadı");
    }
    else {
        getMenuInfo(menuId);
    }

});

function getMenuInfo(menuId) {

    id = menuId;

    var data = {
        ID: menuId
    };

    $.ajax({
        type: "post",
        url: "/Settings/getMenuInfo",
        data: data,
        success: function (info) {
            if (info != false) {

                $('#editTitle').val(info.Title);
                $('#editLink').val(info.Link);
                $('#subTitle').val(info.Description);
                $('#sortNumber').val(info.SortNumber);
            }
            else {
                sucMes("", "İşlem Başarıyla Gerçekleştirildi")
                setInterval(function () {
                    window.location.replace("/Settings/Menu");
                }, 1000);
            }

        }
    });



};


$('#menuEditSend').on('click', function () {

    var data = {
        ID: id,
        Title: $('#editTitle').val(),
        Link: $('#editLink').val(),
        Description: $('#subTitle').val(),
        SortNumber: $('#sortNumber').val()
    };

    if (data.Title == "" || data.Title == null) {
        $('#editTitleErr').removeClass('hidden');
        $('#editTitleErr').addClass('show');
        warningMes("Hatalı Giriş", "Başlık Tanımlamalısınız");
    }
    else {
        $('#editTitleErr').removeClass('show');
        $('#editTitleErr').addClass('hidden');
    }
    if (data.SortNumber == 0 || data.SortNumber == null) {
        $('#sortNumberErr').removeClass('hidden');
        $('#sortNumberErr').addClass('show');
        warningMes("Hata", "Geçerli Sıralama Numarası Girin");
    }
    else {
        $('#sortNumberErr').removeClass('show');
        $('#sortNumberErr').addClass('hidden');
    }
    if (data.Title != " " && data.Title != null && data.SortNumber != null && data.SortNumber != 0) {

        $.ajax({
            type: "post",
            url: "/Settings/editMenu",
            data: data,
            success: function (e) {
                if (e == true) {
                    sucMes(data.Title, "İşlem Başarılı Yönlendiriliyorsunuz..");
                    setInterval(function () {
                        window.location.replace("/Settings/Menu");
                    }, 2000);
                }
                else {
                    errorMes("", "İşlem Başarısız");
                }
            }
        });
    }
    else {
        warningMes("Hata", "Alan girişlerini doğru şekilde yazın");

    }





})



//to add Menu
$('#menuAddSend').on('click', function () {
    data = {
        ActOrPass: $("input:radio[name='addMenuradioStatus']:checked").val(),
        SortNumber: $('#addSortNumber').val(),
        Description: $('#addSubTitle').val(),
        Link: $('#addLink').val(),
        Title: $('#addTitle').val()
    };

    if (data.Title == "" || data.Title == null) {
        $('#addTitleErr').removeClass('hidden');
        $('#addTitleErr').addClass('show');
        warningMes("Hatalı Giriş", "Başlık Tanımlamalısınız");
    }
    else {
        $('#addTitleErr').removeClass('show');
        $('#addTitleErr').addClass('hidden');
    }
    if (data.SortNumber == 0 || data.SortNumber == null) {
        $('#addSortNumberErr').removeClass('hidden');
        $('#addSortNumberErr').addClass('show');
        warningMes("Hata", "Geçerli Sıralama Numarası Girin");
    }
    else {
        $('#addSortNumberErr').removeClass('show');
        $('#addSortNumberErr').addClass('hidden');
    }
    if (data.Title != "" && data.Title != null && data.SortNumber != null && data.SortNumber != 0) {

        $.ajax({
            type: "post",
            url: "/Settings/addMenu",
            data: data,
            success: function (e) {
                if (e == true) {
                    sucMes(data.Title, "İşlem Başarılı Yönlendiriliyorsunuz..");
                    setInterval(function () {
                        window.location.replace("/Settings/Menu");
                    }, 2000);
                }
                else {
                    errorMes("", "İşlem Başarısız");
                }

            }

        });


    }
    else {
        warningMes("", "Girişleri Kontrol Edin !")
    }




});


//to make Announcement Active or Passive

$('.AnnounActOrPass').on('click', function () {

    var annid = $(this).attr('announid');

    $('#makeActiveAnnounYesBtn').attr('onclick', "makeAnnActOrPass(" + annid + ")");
    $('#makePassiveAnnounYesBtn').attr('onclick', "makeAnnActOrPass(" + annid + ")");


});


function makeAnnActOrPass(annid) {
    if (annid == null && i <= 0) {
        warningMes("", "Duyuruya Erişilemedi");
    } else {
        data = {
            ID: annid
        };

        $.ajax({
            type: "post",
            url: "/Settings/makeAnnPassOrAct",
            data: data,
            success: function (e) {
                if (e == null || e == 0) {

                    warningMes("", "Duyuruya ulaşılamadı");

                }
                else {
                    sucMes("", "İşlem Başarıyla Gerçekleştirildi")
                    setInterval(function () {
                        window.location.replace("/Settings/Announcement");
                    }, 1000);
                }
            }
        });
    }

}




//to edit Announcement

$('.AnnouncementEdit').on("click", function fnc() {
    var announId = $(this).attr('announid');
    if (announId == null) {
        warningMes("", "Duyuruya Erişilemedi");
    } else {

        id = announId;

        var data = {
            ID: announId
        };

        $.ajax({
            type: "post",
            url: "/Settings/getAnnounInfo",
            data: data,
            success: function (info) {
                if (info != false) {
                    $('#editAnnounTitle').val(info.Title);
                    $('#editAnnounDesc').val(info.Description);
                    $('#editAnnounSortNum').val(info.SortNumber);
                    $('#editAnContent').val(info.AnContent);

                }
                else {
                    sucMes("", "Duyuru Bulunamadı")
                }

            }
        });
    }


})


$('#editAnnounSend').on("click", function fnc() {

    var data = {
        ID: id,
        Title: $('#editAnnounTitle').val(),
        Description: $('#editAnnounDesc').val(),
        SortNumber: $('#editAnnounSortNum').val(),
        AnContent: $('#editAnContent').val()

    };

    if (data.Description == "" || data.Description == null) {
        $('#editAnnounDescErr').removeClass('hidden');
        $('#editAnnounDescErr').addClass('show');
        warningMes("Hatalı Giriş", "Duyuru Tanımlamalısınız");
    }
    else {
        $('#editAnnounDescErr').removeClass('show');
        $('#editAnnounDescErr').addClass('hidden');
    }
    if (data.SortNumber == 0 || data.SortNumber == null) {
        $('#AnoounEditsortNumberErr').removeClass('hidden');
        $('#AnoounEditsortNumberErr').addClass('show');
        warningMes("Hata", "Geçerli Sıralama Numarası Girin");
    }
    else {
        $('#AnoounEditsortNumberErr').removeClass('show');
        $('#AnoounEditsortNumberErr').addClass('hidden');
    }

    if (data.Description != "" && data.Title != null && data.SortNumber != 0 && data.SortNumber != null) {

        $.ajax({
            type: "post",
            url: "/Settings/editAnnounInfo",
            data: data,
            success: function (e) {
                if (e == true) {
                    sucMes(data.Title, "Kayıt Başarılı");
                    setInterval(function () {
                        window.location.replace("/Settings/Announcement");
                    }, 2000);
                }
                else {
                    errorMes(data.Title, "Kayıt Başarısız");
                }
            }
        });


    }
    else {
        warningMes('', 'Girişleri Kontrol Edin');
    }

})



//to add Announcement
$('#addAnnounSend').on('click', function fnc() {

    var data = {
        ID: id,
        Title: $('#addAnnounTitle').val(),
        Description: $('#addAnnounDesc').val(),
        SortNumber: $('#addAnnounSortNum').val(),
        AnContent: $('#addAnContent').val(),
        ActOrPass: $("input:radio[name='addAnnradioStatus']:checked").val(),
    };

    if (data.Description == "" || data.Description == null) {
        $('#addAnnounDescErr').removeClass('hidden');
        $('#addAnnounDescErr').addClass('show');
        warningMes("Hatalı Giriş", "Duyuru Tanımlamalısınız");
    }
    else {
        $('#addAnnounDescErr').removeClass('show');
        $('#addAnnounDescErr').addClass('hidden');
    }
    if (data.SortNumber == 0 || data.SortNumber == null) {
        $('#AnoounAddsortNumberErr').removeClass('hidden');
        $('#AnoounAddsortNumberErr').addClass('show');
        warningMes("Hata", "Geçerli Sıralama Numarası Girin");
    }
    else {
        $('#AnoounAddsortNumberErr').removeClass('show');
        $('#AnoounAddsortNumberErr').addClass('hidden');
    }

    if (data.Description != "" && data.Title != null && data.SortNumber != 0 && data.SortNumber != null) {

        $.ajax({
            type: "post",
            url: "/Settings/addAnnounInfo",
            data: data,
            success: function (e) {
                if (e == true) {
                    sucMes(data.Title, "Kayıt Başarılı");
                    setInterval(function () {
                        window.location.replace("/Settings/Announcement");
                    }, 2000);
                }
                else {
                    errorMes(data.Title, "Kayıt Başarısız");
                }
            }
        });
    }
    else {
        warningMes('', 'Girişleri Kontrol Edin');
    }






});



//Slider Settings

function prewSliderSet(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#previewSliderImgUrl').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#SliderImageUrl").change(function () {
    prewSliderSet(this);
});


//Slider Info save 


function SliderPost(formData) {

    var ajaxConfig = {

        type: "post",
        url: "/Settings/editSlider",
        data: new FormData(formData),
        success: function (e) {

            if (e == true) {
                sucMes("", "Güncelleme Başarılı");
                setInterval(function myfunction() {
                    window.location.href = "/Settings/Slider";
                }, 1000)

            }
            else {
                errorMes("", "Güncelleme Esnasında Hata Oluştu.");
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




//General Settings 


//General Logo Preview

function readLogoUrl(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#previewGeneralLogoUrl').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#LogoUrl").change(function () {
    readLogoUrl(this);
});



//edit General Settings

function AjaxPost(formData) {

    var ajaxConfig = {

        type: "post",
        url: "/Settings/editGeneralSettings",
        data: new FormData(formData),
        success: function (e) {

            if (e == true) {
                sucMes("", "Güncelleme Başarılı");
                setInterval(function myfunction() {
                    window.location.href = "/Settings/GeneralSettings";
                }, 1000)

            }
            else {
                errorMes("", "Güncelleme Esnasında Hata Oluştu.");
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


//SETTINGS OPERATIONS END **** //


// BLOG OPERATIONS        ****//

// Blog Image Preview

function previewCreateBlog(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#previewBlogImgUrl').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$("#BlogImgUrl").change(function () {
    previewCreateBlog(this);
});


//send create Info

$('#sendCreateData').on('click', function myfunction() {

    var ck_ed = CKEDITOR.instances.ckeditor.getData();
    var file_data = $('#BlogImgUrl').prop('files')[0];
    var blogName = $('#BlogName').val();
    var blogSeoUrl = $('#blogSeoUrl').val();
    var blogMetaTitle = $('#blogMetaTitle').val();
    var BlogMetaDesc = $('#blogMetaDesc').val();
    var catId = $('#basicSelect').val();
    var form_data = new FormData();
    form_data.append('BlogImgUrl', file_data);
    form_data.append('BlogContent', ck_ed);
    form_data.append('BlogName', blogName);
    form_data.append('CategoryID', catId);
    form_data.append('BlogMetaTitle', blogMetaTitle);
    form_data.append('BlogMetaDesc', BlogMetaDesc);
    form_data.append('BlogSeoUrl', blogSeoUrl);

    if (blogSeoUrl == NaN || blogSeoUrl == undefined || blogSeoUrl == null || blogSeoUrl == "") {
        warningMes("Link Belirlemelisiniz");
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Blog/addBlog",
            data: form_data,
            cache: false,
            contentType: false,
            processData: false,
            success: function (e) {
                if (e == true) {
                    sucMes(blogName, "Blog Başarıyla Oluşturuldu");
                    setInterval(() => {
                        window.location.href = "/Blog/Index";
                    }, 2000);
                }
                else if (e == blogSeoUrl) {
                    warningMes(blogSeoUrl, "Böyle Bir Blog Linki Bulunmaktadır.");
                }
                else {
                    errorMes(blogName, "Blog oluşturulurken bir hata ile karşılaşıldı.");
                }
            }

        });
    }

});


//edit preview blog img

function readBlogImgUrl(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#editPreviewBlogImgUrl').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$("#editBlogImgUrl").change(function () {
    readBlogImgUrl(this);
});




$('#blogEditSend').on('click', function myfunction() {

    var id = $(this).attr('blogId');

    var hidImg = $('#blogEditImgHidden').val();
    var ck_ed = CKEDITOR.instances.ckeditorEditBlog.getData();
    var file_data = $('#editBlogImgUrl').prop('files')[0];
    var blogName = $('#editBlogName').val();
    var blogSeoUrl = $('#editBlogUrl').val();
    var blogMetaTitle = $('#editBlogMetaTitle').val();
    var BlogMetaDesc = $('#editBlogMetaDesc').val();
    var catId = $('#selectEditBlogPopUp').val();
    var form_data = new FormData();
    form_data.append('BlogImgUrl', file_data);
    form_data.append('BlogContent', ck_ed);
    form_data.append('BlogName', blogName);
    form_data.append('CategoryID', catId);
    form_data.append('BlogMetaTitle', blogMetaTitle);
    form_data.append('BlogMetaDesc', BlogMetaDesc);
    form_data.append('BlogSeoUrl', blogSeoUrl);
    form_data.append('ID', id);
    form_data.append('strBlogImgUrl', hidImg);

    if (blogSeoUrl == NaN || blogSeoUrl == undefined || blogSeoUrl == null || blogSeoUrl == "") {
        warningMes("Link Belirlemelisiniz");
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Blog/editBlog",
            data: form_data,
            cache: false,
            contentType: false,
            processData: false,
            success: function (e) {
                if (e == true) {
                    sucMes(blogName, "Blog Başarıyla Düzenlendi");
                    setInterval(() => {
                        window.location.href = "/Blog/BlogDetail/" + id;
                    }, 1000);
                }
                else if (blogSeoUrl == e) {
                    warningMes(blogSeoUrl, 'Url Bulunmaktadır başka bir url tanımlayınız.')
                }
                else {
                    errorMes(blogName, "Blog Düzenlenirken bir hata ile karşılaşıldı.");
                }
            }

        });
    }

});

//make active or passive 

$('.takeIdBlog').on('click', function () {

    var bid = $(this).attr('blogid');

    $('#makePassiveBlogYesBtn').attr("onclick", "makeBlogActiveOrPassive(" + bid + ")");
    $('#makeActiveBlogYesBtn').attr("onclick", "makeBlogActiveOrPassive(" + bid + ")");
});


function makeBlogActiveOrPassive(bid) {
    if (bid != null && bid != undefined && bid != NaN) {
        var data = {
            ID: bid
        };

        $.ajax({
            type: "post",
            url: "/Blog/makeActiveOrPassive",
            data: data,
            success: function my(e) {
                if (e == true) {
                    sucMes("", "İşlem Başarılı Yönlendiriliyorsunuz.");
                    setInterval(() => {
                        window.location.href = "/Blog/Index";
                    }, 1000);
                } else {
                    errorMes("", "İşlem Başarısız");
                }
            }

        })


    } else {
        warningMes("", "Bloğa Erişilemedi");
    }


}




// BLOG OPERATIONS   END     ****//



// PAGE OPERATIONS     ****//

//edit preview page img

function readPageImgUrl(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#editPreviewPageImgUrl').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$("#editPageImgUrl").change(function () {
    readPageImgUrl(this);
});

$('#pageEditSend').on('click', function editPage() {

    var id = $(this).attr('pageId');

    var hidImg = $('#pageEditImgHidden').val();
    var ck_ed = CKEDITOR.instances.ckeditorEditPage.getData();
    var file_data = $('#editPageImgUrl').prop('files')[0];
    var pageName = $('#editPageName').val();
    var pageSeoUrl = $('#editPageUrl').val();
    var pageMetaTitle = $('#editPageMetaTitle').val();
    var pageMetaDesc = $('#editPageMetaDesc').val();
    var catId = $('#selectEditPagePopUp').val();
    var form_data = new FormData();
    form_data.append('ImgUrl', file_data);
    form_data.append('PageContent', ck_ed);
    form_data.append('PageName', pageName);
    form_data.append('CategoryID', catId);
    form_data.append('PageMetaTitle', pageMetaTitle);
    form_data.append('PageMetaDesc', pageMetaDesc);
    form_data.append('PageSeoUrl', pageSeoUrl);
    form_data.append('ID', id);
    form_data.append('strImgUrl', hidImg);

    if (pageSeoUrl == NaN || pageSeoUrl == undefined || pageSeoUrl == null || pageSeoUrl == "") {
        warningMes("Link Belirlemelisiniz");
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Page/editInfo",
            data: form_data,
            cache: false,
            contentType: false,
            processData: false,
            success: function (e) {
                if (e == true) {
                    sucMes(pageName, "Sayfa Başarıyla Düzenlendi");
                    setInterval(() => {
                        window.location.href = "/Page/EditPage/" + id;
                    }, 1000);
                }
                else if (blogSeoUrl == e) {
                    warningMes(pageSeoUrl, 'Url Bulunmaktadır başka bir url tanımlayınız.')
                }
                else {
                    errorMes(pageName, "Sayfa Düzenlenirken bir hata ile karşılaşıldı.");
                }
            }

        });
    }

});


// page create

function readCreatePageImgUrl(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#previewCreatePageImgUrl').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$("#createPageImgUrl").change(function () {
    readCreatePageImgUrl(this);
});



$('#sendCreatePageData').on('click', function createPage() {

    var ck_ed = CKEDITOR.instances.createPageContent.getData();
    var file_data = $('#createPageImgUrl').prop('files')[0];
    var pageName = $('#createPageName').val();
    var pageSeoUrl = $('#createPageSeoUrl').val();
    var pageMetaTitle = $('#createPageMetaTitle').val();
    var pageMetaDesc = $('#createPageMetaDesc').val();
    var catId = $('#createPageCat').val();
    var form_data = new FormData();
    form_data.append('ImgUrl', file_data);
    form_data.append('PageContent', ck_ed);
    form_data.append('PageName', pageName);
    form_data.append('CategoryID', catId);
    form_data.append('PageMetaTitle', pageMetaTitle);
    form_data.append('PageMetaDesc', pageMetaDesc);
    form_data.append('PageSeoUrl', pageSeoUrl);

    if (pageSeoUrl == NaN || pageSeoUrl == undefined || pageSeoUrl == null || pageSeoUrl == "") {
        warningMes("Link Belirlemelisiniz");
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Page/cPage",
            data: form_data,
            cache: false,
            contentType: false,
            processData: false,
            success: function (e) {
                if (e == true) {
                    sucMes(pageName, "Sayfa Başarıyla Oluşturuldu");
                    setInterval(() => {
                        window.location.href = "/Page/Index";
                    }, 2000);
                }
                else if (e == pageSeoUrl) {
                    warningMes(pageSeoUrl, "Böyle Bir Sayfa Linki Bulunmaktadır.");
                }
                else {
                    errorMes(pageName, "Sayfa oluşturulurken bir hata ile karşılaşıldı.");
                }
            }

        });
    }





});


// make passive or active page
$('.takeIdPage').on('click', function () {

    var bid = $(this).attr('blogid');

    $('#makePassivePageYesBtn').attr("onclick", "makePageActiveOrPassive(" + bid + ")");
    $('#makeActivePageYesBtn').attr("onclick", "makePageActiveOrPassive(" + bid + ")");
});


function makePageActiveOrPassive(bid) {
    if (bid != null && bid != undefined && bid != NaN) {
        var data = {
            ID: bid
        };

        $.ajax({
            type: "post",
            url: "/Page/makeActiveOrPassive",
            data: data,
            success: function my(e) {
                if (e == true) {
                    sucMes("", "İşlem Başarılı Yönlendiriliyorsunuz.");
                    setInterval(() => {
                        window.location.href = "/Page/Index";
                    }, 1000);
                } else {
                    errorMes("", "İşlem Başarısız");
                }
            }

        })


    } else {
        warningMes("", "Bloğa Erişilemedi");
    }


}


//ADMİN OPERATIONS **  //


function AdminLoginPost(formData) {

    var username = $('#uname').val();

    var ajaxConfig = {

        type: "post",
        url: "/Admin/doLogin",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                sucMes(username, "Giriş Başarılı");
                setInterval(function () {
                    window.location.href = "/Home/Index";
                }, 3000);
            }
            else if (e == false) {
                warningMes("", "Girişleri Kontrol Ediniz");
            }
            else if (e == "except") {
                warningMes("Admin Bulunamadı", "");
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


///******    /////////////

//PACKET OPERATIONS

$('.PacketActOrPass').on('click', function cn() {
    var packId = $(this).attr('packid');

    $('#makeActivePacketYesBtn').attr('onclick', "makePacketActiveOrPassive(" + packId + ")")
    $('#makePassivePacketYesBtn').attr('onclick', "makePacketActiveOrPassive(" + packId + ")")

});

function makePacketActiveOrPassive(packId) {

    var data = {
        ID: packId
    };
    $.ajax({
        type: "post",
        url: "/Packet/makePassiveOrActive",
        data: data,
        success: function (e) {
            if (e == true) {
                sucMes('', 'İşlem Başarılı');
                setInterval(function myfunction() {
                    window.location.href = "/Packet/Index";
                }, 1000);
            }
            else {
                warningMes('', 'Bir hata ile karşılaşıldı');
            }

        }

    });


};

$('.PacketEdit').on('click', function pn() {
    var pId = $(this).attr('packid');

    if (pId == null || pId == '' || pId == undefined) {
        warningMes('Paket Bilgilerine Ulaşılamadı', '');
    }
    else {

        var data = {
            ID: pId
        };

        $.ajax({
            type: "post",
            url: "/Packet/getPacketInfo",
            data: data,
            success: function (e) {
                if (e != null) {
                    if (e.hiddenOldImg != null) {
                        $('#editPacketPreview').attr('src', e.hiddenOldImg);
                        $('#hiddenOldImg').val(e.hiddenOldImg);
                    }
                    else {
                        $('#editPacketPreview').attr('src', "/Assets/images/demo.png");
                    }
                    $('#PacketName').val(e.PackageName);
                    $('#PacketDesc').val(e.PacketDesc);
                    $('#PacketLink').val(e.SeoUrlLink);
                    $('#PacketName').val(e.PackageName);
                    $('#PacketPrice').val(e.PacketPrice);
                    $('#PacketPrice').val(e.PacketPrice);
                    $('#hiddenPID').val(e.ID);
                }
                else {
                    arningMes('Paket Bilgilerine Ulaşılamadı', '');
                }

            }

        });
    }


});


//packet edit preview
function readeditPacketImgUrl(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#editPacketPreview').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#PacketImgUrl").change(function () {
    readeditPacketImgUrl(this);
});


//edit post packet info
function PacketEditPost(formData) {

    var seoLink = $('#PacketLink').val();
    var packetName = $('#PacketName').val();

    var ajaxConfig = {
        type: "post",
        url: "/Packet/editPacket",
        data: new FormData(formData),
        success: function (e) {
            if (e == seoLink) {
                warningMes(seoLink, 'Böyle bir link tanımlı, lütfen değiştirin');
            }
            else if (e == true) {
                sucMes(packetName, 'Başarıyla Güncellendi');
                setInterval(function myfunction() {
                    window.location.href = "/Packet/Index";
                }, 2000);

            }
            else {
                errorMes('', 'Güncelleme yapılırken hata ile karşılaşıldı');
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


// add packet 

//edit post packet info
function PacketAddPost(formData) {

    var seoLink = $('#PacketLink').val();
    var packetName = $('#PacketName').val();

    var ajaxConfig = {
        type: "post",
        url: "/Packet/addPacket",
        data: new FormData(formData),
        success: function (e) {
            if (e == seoLink) {
                warningMes(e, "Böyle bir link tanımlı, lütfen linki değiştirin");
            }
            else if (e == true) {
                sucMes(packetName, 'Paket başarılı bir şekilde yüklendi.');
                setInterval(function myfunction() {
                    window.location.href = "/Packet/Index";

                }, 2000);
            }
            else if (false == e) {
                errorMes('', 'Paket Oluşturulurken Hata İle Karşılaşıldı');
            }
            else {
                errorMes('', 'Paket Oluşturulurken Hata İle Karşılaşıldı');
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


// packet add preview


function readaddPacketImgUrl(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#addPacketPreview').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#PacketImgUrlAdd").change(function () {
    readaddPacketImgUrl(this);
});



// Video Operations ****/////

//Video Upload

//function VideoPost(formData) {

//    var seoLink = $('#PacketLink').val();
//    var packetName = $('#PacketName').val();

//    var ajaxConfig = {
//        type: "post",
//        url: "/Video/getVideo",
//        data: new FormData(formData),
//        success: function (e) {
//            if (e == true) {

//                sucMes("Başarılı Yükleme");


//            }

//        }
//    }
//    if ($(formData).attr('enctype') == "multipart/form-data") {
//        ajaxConfig["contentType"] = false;
//        ajaxConfig["processData"] = false;
//    }
//    $.ajax(ajaxConfig);

//    return false;
//}
//const uploadForm = document.getElementById("uploadForm");
//const inpFile = document.getElementById("VideoUrl");
//const progressBarFill = document.querySelector('#progressBar > .progress-bar-fill');
//const progressBarText = progressBarFill.querySelector('#progressBar > .progress-bar-text');


//uploadForm.addEventListener('submit', uploadFile);

//function uploadFile(e) {
//    e.preventDefault();

//    var gelen = new FormData();


//    var file_data = $('#VideoUrl').prop('files')[0];


//    gelen.append("VideoUrl", file_data);

//    const xhr = new XMLHttpRequest({ timeOut:30000 });

//    xhr.open("post", "/Video/getVideo");
//    xhr.upload.addEventListener("progress", e => {

//        const percent = e.lengthComputable ? (e.loaded / e.total) * 100 : 0;

//        progressBarFill.style.width = percent.toFixed(2) + '%';
//        //progressBarText.textContent = percent.toFixed(2) + '%';


//    });

//    xhr.send(gelen);


//};




//// TEACHER OPERATIONS *****/

function teacherPost(formData) {
    var teachName = $('#editTeacherName').val();
    var ajaxConfig = {
        type: "post",
        url: "/Teacher/setTeacherInfo",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                sucMes(teachName, 'Güncelleme Başarılı');
            }          
            else {
                errorMes('Güncelleme Esnasında Bir Hata İle Karşılaşıldı');
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


function prewTeacherSet(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#editPreviewTeachImgUrl').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$("#editTeachImgUrl").change(function () {
    prewTeacherSet(this);
});

