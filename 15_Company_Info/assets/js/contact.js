var googleCatcha;
jQuery(window).load(function () {
    googleCatcha = grecaptcha.render('g-recaptcha', {
        'sitekey': googleCapchaSitekey,
        'theme': 'light',
        'hl': 'vi'
    });
});
jQuery(document).ready(function () {

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