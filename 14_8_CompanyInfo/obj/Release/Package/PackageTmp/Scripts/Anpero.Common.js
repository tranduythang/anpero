var Util = {
    toMoneyFormat: function (input) {
        var nf = new Intl.NumberFormat();
        return nf.format(input);
    },
    isEmail: function (n) { var t = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/; return t.test(n) },
    isVnFone: function (n) { return (n = n.replace("+84", "0").replace("+", "0").replace("-", "").replace(" ", "").replace(".", ""), n.length > 15 || n.length < 9) ? !1 : (n = n.replace("+", "0"), isNaN(n)) ? !1 : !0 },
    notify: function (_title, _mesage) {
        $.notify({
            title: '<strong>' + _title + '</strong>',
            message: '<strong>' + _mesage + '</strong>'
        }, {
                type: 'warning',
                delay: 3000,
                z_index: 9999,
                placement: {
                    from: "top",
                    align: "center"
                }

            });

    },
    isUrl: function (string) {
        var pattern = new RegExp('^(https?:\\/\\/)?' + // protocol
            '((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.?)+[a-z]{2,}|' + // domain name
            '((\\d{1,3}\\.){3}\\d{1,3}))' + // OR ip (v4) address
            '(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*' + // port and path
            '(\\?[;&a-z\\d%_.~+=-]*)?' + // query string
            '(\\#[-a-z\\d_]*)?$', 'i'); // fragment locator
        return pattern.test(string);
    }

};

function resetContactForm() {
    $("#name").val("");
    $("#email").val("");
    $("#phone").val("");
    $("#address").val("");
    $("#message").val("");
    grecaptcha.reset();
    $("#btn-send-contact").prop('disabled', false);
}
$(document).ready(function () {

    $("#btn-send-contact").click(function () {
        $("#btn-send-contact").removeAttr('disabled');
        var valid = true;
        var captchaResponse = grecaptcha.getResponse(googleCatcha);
        var _name = $("#name").val();
        var _email = $("#email").val();
        var _phone = $("#phone").val();
        var _address = $("#address").val();
        var _message = $("#message").val();
        if (_phone == null || _phone == "" || !Util.isVnFone(_phone)) {
            Util.notify("", "Vui lòng nhập số điện thoại. ");
            valid = false;
        }
        if (_name == null || _name == "") {
            Util.notify("", "Vui lòng nhập tên liên hệ. ");
            valid = false;
        }
        if (_message == null || _message == "") {
            Util.notify("", "Vui lòng nhập nội dung tin nhắn. ");
            valid = false;
        }
        if (captchaResponse == null || captchaResponse == "") {
            Util.notify("", "Vui lòng click vào ô kiểm tra bảo mật. ");
            valid = false;
        }
        if (valid) {
            $("#ajax_loader").show();
            $.ajax({
                method: "post",
                url: "/handler/ProductHandler.ashx",
                datatype: "text/plain",
                data: { op: "sendContact", name: _name, email: _email, phone: _phone, address: _address, message: _message, captcha: captchaResponse },
                success: function (rs) {
                    $("#ajax_loader").hide();
                    if (!isNaN(rs)) {
                        Util.notify("", "Tin nhắn liên hệ đã được gửi, cảm ơn bạn đã đóng góp!");
                    }
                    resetContactForm();

                }
            });
        }
    });
});