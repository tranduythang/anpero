var googleCatcha;
$(document).ready(function () {
    
    $("#open-contact").click(function () {
        try {
            googleCatcha = grecaptcha.render('g-recaptcha', {
                'sitekey': googleCapchaSitekey,
                'theme': 'light',
                'hl': 'vi'
            });
        } catch (e) {

        }
    
    });
    $("#btn-send-contact").click(function () {
        $("#btn-send-contact").removeAttr('disabled');
        var valid = true;
        var captchaResponse = grecaptcha.getResponse(googleCatcha);
        var _name = $("#name").val();
        var _email = $("#email").val();
        var _phone = $("#phone").val();
        var _address = $("#address").val();
        var _message = $("#message").val();
        if (_phone == null || _phone == "" || !Utils.isVnFone(_phone)) {
            $(".contact-err").html("Lỗi. Vui lòng nhập số điện thoại. ");
            valid = false;
        }
        if (_name == null || _name == "") {
            $(".contact-err").html("Lỗi. Vui lòng nhập tên liên hệ. ");
            valid = false;
        }
        if (_message == null || _message == "") {
            $(".contact-err").html("Lỗi. Vui lòng nhập nội dung tin nhắn. ");
            valid = false;
        }
        if (_email == "" && !Utils.isEmail(_email)) {
            $(".contact-err").html("Lỗi. Email không đúng đụng dạng. ");
            valid = false;
        }
        
        if (captchaResponse == null || captchaResponse == "") {
            $(".contact-err").html("Vui lòng click vào ô kiểm tra bảo mật. ");
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
                    setTimeout(function () {
                        $("#nav-herder").removeClass("navbar-contact-active");
                        $(".navbar-contact-btn").removeClass("navbar-contact-active");
                    }, 3000);
                    if (!isNaN(rs)) {
                        $(".contact-err").html("Tin nhắn liên hệ đã được gửi, cảm ơn bạn đã đóng góp!");
                    }
                    grecaptcha.reset();
                    resetContactForm();

                }
            });
        }
    });
});
function resetContactForm() {
    $("#name").val("");
    $("#email").val("");
    $("#phone").val("");
    $("#address").val("");
    $("#message").val("");
    grecaptcha.reset();
    $("#btn-send-contact").prop('disabled', false);
}