var Warranty = (function () {
    var datas = {};
    function getAndValidateData() {
        var valid = true;
        datas.LocationId = 0;
        var location = $("#country").val();
        var district = $("#prov").val();
        var captchaResponse = grecaptcha.getResponse(googleCatcha);
        if (district > 0) {
            datas.LocationId = district;
        } else if (location > 0) {
            datas.LocationId = location;
        }
         
        datas.Province = location>0?$("select[name=province] option:selected").text():"";
        datas.District = district>0?$("select[name=district] option:selected").text():"";
        datas.seria = $("#seria").val();
        datas.Name = $("#fullName").val();
        datas.Address = $("#address").val();
        datas.identiryId = $("#identiryId").val();
        datas.Phone = $("#phone").val();
        datas.Mail = $("#emial").val();
        datas.IdCard = $("#identiryId").val();
        datas.capcha = captchaResponse;
        if (captchaResponse == null || captchaResponse == "") {
            Util.notify("", "Vui lòng click vào ô kiểm tra bảo mật. ");
            valid = false;
        }
        if (datas.IdCard == "") {
            Util.notify("", "Vui lòng nhập số CMTND hoặc hộ chiếu!");
            valid = false;
        }

        if (datas.LocationId == 0) {
            Util.notify("", "Vui lòng chọn tỉnh thành phố!");
            valid = false;
        }
        if (datas.seria == "") {
            Util.notify("", "Vui lòng nhập seria");
            valid = false;
        }
        if (datas.Name == "") {
            Util.notify("", "Vui lòng nhập đủ họ tên!");
            valid = false;
        }

        if (datas.Address == "") {
            Util.notify("", "Vui lòng nhập địa chỉ!");
            valid = false;
        }
        if (datas.Phone == "") {
            Util.notify("", "Vui lòng nhập số điện thoại!");
            valid = false;
        } else if (!Util.isVnFone(datas.Phone)) {
            Util.notify("", "Lỗi! Số điện thoại không đúng định dạng.");
        }
        if (datas.Mail == "" || !Util.isEmail(datas.Mail)) {
            Util.notify("", "Lỗi! Email không đúng định dạng.");
        }
        return valid;
    }
    function init() {
        $(document).ready(function () {
            $("#addWrr").click(function (e) {
                if (getAndValidateData()) {
                    $.ajax({
                        method: "post",
                        url: "/warranty/Register",
                        datatype: "json",
                        data:datas,
                        success: function (rs) {
                            if (rs.code != "" && rs.code != null && rs.code!=0) {
                                swal({
                                    title: "Đăng ký bảo hành thành công",
                                    text: "Cảm ơn bạn đã sử dụng sản phẩm của JAKI.",
                                    showConfirmButton: true,
                                    showCancelButton: true,

                                    cancelButtonText: 'Đăng ký tiếp',
                                    confirmButtonText: "Xem thông tin",
                                    type: "success"
                                }, function (confirm) {
                                    if (confirm) {
                                        window.location.href = "/warranty/success?id=" + rs.code;
                                    } else {
                                        $("#seria").val("");
                                        grecaptcha.reset();
                                    }

                                });
                            } else {
                                grecaptcha.reset();
                                Util.notify("", rs.msg);
                            }
                            

                        }
                    });
                }
            });
        });


    }
    function initCheck() {
        $(document).ready(function () {
            $("#checkWarranty").click(function () {
                var valid = true;
                var captchaResponse = grecaptcha.getResponse(googleCatcha);
               var seria =  $("#seria").val();
                var idCard= $("#identiryId").val();
                if (captchaResponse == null || captchaResponse == "") {
                    Util.notify("", "Vui lòng click vào ô kiểm tra bảo mật. ");
                    valid = false;
                    grecaptcha.reset();
                }
                if (seria == "") {
                    Util.notify("", "Vui lòng Nhập seria. ");
                    valid = false;
                }
                if (idCard == "") {
                    Util.notify("", "Vui lòng nhập số CMTND / Hộ chiếu. ");
                    valid = false;
                }
                if (valid) {                    
                    window.location.href = "/warranty/info?seria=" + seria + "&idCard=" + idCard+"&capcha=" + captchaResponse;
                }
            });
        });

    }
    return {
        init: init,
        initCheck: initCheck
    };
})();

