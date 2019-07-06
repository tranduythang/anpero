var Cart = {
    list: [],
    addProduct: function (_id, _price, _thumb, _title) {
        
        var checkExited = false;
        if ($.cookie("CartList") != null && $.cookie("CartList") != "undefined" && $.cookie("CartList") != "null") {
            Cart.list = jQuery.parseJSON($.cookie("CartList"));
        }

        if (Cart.list.length == 0) {
            Cart.list.push({ id: _id, quantity: 1, price: _price, thumb: _thumb, title: _title });
        } else {
            for (var i = 0; i < Cart.list.length; i++) {
                if (Cart.list[i].id == _id) {
                    Cart.list[i].price = parseInt(_price);
                    Cart.list[i].quantity = parseInt(Cart.list[i].quantity) + 1;
                    checkExited = true;
                }
            }
            // if this product no in cart list
            if (!checkExited) {
                Cart.list.push({ id: _id, quantity: 1, price: _price, thumb: _thumb, title: _title });
            }
        }        
        $.cookie("CartList", JSON.stringify(Cart.list), {path: '/' });
        window.location.href = "/product/checkout";
    },
    addProduct3: function (_id, _price, _thumb, _title) {
        
        var checkExited = false;
        if ($.cookie("CartList") != null && $.cookie("CartList") != "undefined" && $.cookie("CartList") != "null") {
            Cart.list = jQuery.parseJSON($.cookie("CartList"));
        }

        if (Cart.list.length == 0) {
            Cart.list.push({ id: _id, quantity: 1, price: _price, thumb: _thumb, title: _title });
        } else {
            for (var i = 0; i < Cart.list.length; i++) {
                if (Cart.list[i].id == _id) {
                    Cart.list[i].price = parseInt(_price);
                    Cart.list[i].quantity = parseInt(Cart.list[i].quantity) + 1;
                    checkExited = true;
                }
            }
            // if this product no in cart list
            if (!checkExited) {
                Cart.list.push({ id: _id, quantity: 1, price: _price, thumb: _thumb, title: _title });
            }
        }
        $.cookie("CartList", JSON.stringify(Cart.list), { path: '/' });
        Cart.bindCart();
    },
    addProduct2: function (_id, _price) {
       
        if ($.cookie("CartList") != null && $.cookie("CartList") != "undefined" && $.cookie("CartList") != "null") {
            Cart.list = jQuery.parseJSON($.cookie("CartList"));
        }
        for (var i = 0; i < Cart.list.length; i++) {
            if (Cart.list[i].id == _id) {
                Cart.list[i].price = parseInt(Cart.list[i].price)
                Cart.list[i].quantity = parseInt(Cart.list[i].quantity) + 1;
                $("#prQuantity_" + _id).val(Cart.list[i].quantity);
            }
        }
        $.cookie("CartList", JSON.stringify(Cart.list), { path: '/' });
        Cart.bindCartTable();
    },
    updateQuantity: function (_id, _quantity) {

        if ($.cookie("CartList") != null && $.cookie("CartList") != "undefined" && $.cookie("CartList") != "null") {
            Cart.list = jQuery.parseJSON($.cookie("CartList"));
        }
        for (var i = 0; i < Cart.list.length; i++) {
            if (Cart.list[i].id == _id) {                
                Cart.list[i].quantity = _quantity;
            }
        }
        $.cookie("CartList", JSON.stringify(Cart.list), { path: '/' });
        Cart.bindCartTable();
    },
    bindCart: function () {
        var ttSC = 0;
        var htmlCat = "";
        if ($.cookie("CartList") != 'null' && $.cookie("CartList") != "undefined" && $.cookie("CartList") != undefined) {
            Cart.list = jQuery.parseJSON($.cookie("CartList"));
            $(".spN").html(Cart.list.length);
            for (var i = 0; i < Cart.list.length; i++) {
                ttSC += parseInt(Cart.list[i].price) * parseInt(Cart.list[i].quantity);
                htmlCat += '<li class="product-info"><div class="p-left">';
                htmlCat += '<a href="javascript:Cart.remove(' + Cart.list[i].id + ')" class="remove_link"></a>';
                htmlCat += '<img class="img-responsive" src="' + Cart.list[i].thumb + '" alt="' + Cart.list[i].title + '">';
                htmlCat += '</div>';
                htmlCat += '<div class="p-right">';
                htmlCat += '<p class="p-name">' + Cart.list[i].title + '</p>';
                htmlCat += '<p class="p-rice">' + Util.toMoneyFormat(Cart.list[i].price) + ' đ</p>';
                htmlCat += '<p>SL: ' + Cart.list[i].quantity + '</p>';
                htmlCat += '</div>';
                htmlCat += '</li>';
            }
            $("#ttSC").html(Util.toMoneyFormat(ttSC));
            $("#prCatCt").html(htmlCat);
            $(".toal-cart").show();
            $(".cart-buttons").show();
        }
    },
    bindCartTable: function () {

        var ttSC = 0;

        var _paymentFee = $('input[name=radio_4]:checked').attr("data-ship");
        var htmlCat = "";
        if ($.cookie("CartList") != null && $.cookie("CartList") != "undefined") {
            Cart.list = jQuery.parseJSON($.cookie("CartList"));
           
            $(".spN").html(Cart.list.length);
            for (var i = 0; i < Cart.list.length; i++) {
                ttSC += parseInt(Cart.list[i].price) * parseInt(Cart.list[i].quantity);
                htmlCat += '<tr>';
                htmlCat += '<td class="cart_product">';
                htmlCat += '<a href="#"><img src="' + Cart.list[i].thumb + '" alt="' + Cart.list[i].title + '"></a>';
                htmlCat += '</td>';
                htmlCat += '<td class="cart_description">';
                htmlCat += '<p class="product-name"><a href="#">' + Cart.list[i].title + ' </a></p>';

                htmlCat += '</td>';
                htmlCat += '<td class="cart_avail"><span class="label label-success">Sẵn hàng</span></td>';
                htmlCat += '<td class="price"><span>' + Util.toMoneyFormat(Cart.list[i].price) + '</span></td>';
                htmlCat += '<td class="qty">';
                htmlCat += '<input class="form-control input-sm" type="text" value="' + Cart.list[i].quantity + '" id="prQuantity_' + Cart.list[i].id + '">';
                htmlCat += '<a href="javascript:Cart.addProduct2(' + Cart.list[i].id + ',' + Cart.list[i].price + ');"><i class="fa fa-caret-up"></i></a>';
                htmlCat += '<a href="javascript:Cart.remove3(' + Cart.list[i].id + ',' + Cart.list[i].price + ');"><i class="fa fa-caret-down"></i></a>';
                htmlCat += '</td>';
                htmlCat += '<td class="price">';
                htmlCat += '<span>' + Util.toMoneyFormat(parseInt(Cart.list[i].price) * parseInt(Cart.list[i].quantity)) + ' đ</span>';
                htmlCat += '</td>';
                htmlCat += '<td class="action">';
                htmlCat += '<a href="javascript:Cart.remove2(' + Cart.list[i].id + ')" class="remove_link"></a>';
                htmlCat += '</td>';
                htmlCat += '</tr>';

            }
            var shipingFee = $('input[name=radio_3]:checked').attr("data-ship");

            $("#ttPrCt").html(Util.toMoneyFormat(ttSC) + " đ");
            $("#ttOdCt").html(Util.toMoneyFormat(parseInt(ttSC) + parseInt(shipingFee) + parseInt(_paymentFee)) + " đ");
            $("#prCatCtTable").html(htmlCat);
            $(".qty input").change(function () {
                var id = $(this).attr('id').replace("prQuantity_","");
                Cart.updateQuantity(id,$(this).val());
            });
        }
    },
    remove: function (prId) {
        Cart.list = jQuery.parseJSON($.cookie("CartList"));
        for (var i = 0; i < Cart.list.length; i++) {
            if (Cart.list[i].id == prId) {
                Cart.list.splice(i, 1);
            }
        }
        var date = new Date();
        var minutes = 60 * 2;
        date.setTime(date.getTime() + (minutes * 60 * 1000));
        $.cookie("CartList", JSON.stringify(Cart.list), { path: '/' });
        Cart.bindCart();
    },
    remove2: function (prId) {
        Cart.list = jQuery.parseJSON($.cookie("CartList"));
        for (var i = 0; i < Cart.list.length; i++) {
            if (Cart.list[i].id == prId) {
                Cart.list.splice(i, 1);
            }
        }        
        $.cookie("CartList", JSON.stringify(Cart.list), { path: '/' });
        Cart.bindCartTable();
    },
    remove3: function (_id) {
        if ($.cookie("CartList") != null && $.cookie("CartList") != "undefined" && $.cookie("CartList") != "null") {
            Cart.list = jQuery.parseJSON($.cookie("CartList"));
        }
        for (var i = 0; i < Cart.list.length; i++) {

            if (Cart.list[i].id == _id && parseInt(Cart.list[i].quantity) > 1) {
                Cart.list[i].price = parseInt(Cart.list[i].price);
                Cart.list[i].quantity = parseInt(Cart.list[i].quantity) - 1;
            }
        }        
        $.cookie("CartList", JSON.stringify(Cart.list), { path: '/' });
        Cart.bindCartTable();
    },
    sendOrder: function () {
        var valid = true;
        var _name = $("#cName").val();
        var _detail = $("#detail").val();
        var _shipingType = $('input[name=radio_3]:checked').val();
        var _paymentType = $('input[name=radio_4]:checked').val();
        var _paymentCode = $('input[name=radio_4]:checked').attr("payment-code");
        //case 2:  "Thanh toán online";
        //case 3: "Thanh toán Ngân Lượng";
        var _shipingFee = $('input[name=radio_3]:checked').attr("data-ship");
        var _paymentFee = $('input[name=radio_4]:checked').attr("data-ship");
        var _email = $("#cMail").val();
        var _phone = $("#cPhone").val();
        var _address = $("#cAddress").val();
        if (_name == 'null' || _name == "") {
            valid = false;
            Util.notify("Lỗi: ", "Bạn chưa nhập tên liên hệ");
        }
        if (_address == 'null' || _address == "") {
            valid = false;
            Util.notify("Lỗi: ", "Vui lòng nhập địa chỉ");
        }

        if (_email != "" && !Util.isEmail(_email)) {
            valid = false;
            Util.notify("Lỗi: ", "Email không đúng định dạng");
        }

        if (_phone == "" || _phone == 'null') {
            valid = false;
            Util.notify("Lỗi: ", "Số điện không được để trống");
        } else if (!Util.isVnFone(_phone)) {
            valid = false;
            Util.notify("Lỗi: ", "Số điện không đúng định dạng");
        }
        var captchaResponse = grecaptcha.getResponse(googleCatcha);
        if (captchaResponse == "" || captchaResponse == null) {
            grecaptcha.reset();
            Util.notify("Lỗi", "Vui lòng nhập click vào ô kiểm tra");
            valid = false;
        }
        if ($.cookie("CartList") == "[]" || $.cookie("CartList")==null) {
            Util.notify("Lỗi", "Giỏ hàng đang trống không thể tạo đơn hàng");
            valid = false;
        }
        var isPaymentOnline = false; 
        if ((parseInt(_paymentType) === 2 || parseInt(_paymentType) === 3) && _paymentCode != "" && _paymentCode != null) {
            isPaymentOnline = true;
        }
        if (isPaymentOnline && $('input[name=bankcode]:checked').val() == null) {
            valid = false;
            Util.notify("", "Vui lòng chọn ngân hàng thanh toán. ");
            
        }
        
        if (isPaymentOnline && (_email == "" || !Util.isEmail(_email))) {
            valid = false;
            Util.notify("Lỗi: ", "Email không đúng định dạng, Thanh toán Online yêu cầu nhập Email.");
        }
        if (valid) {
            $("#cartContent1").hide();
            $("#cartContent2").show();
            $("#cartContent2").html("<h4>Đơn hàng đang được gửi ...</h4>");
            $("#ajax_loader").show();
            $.ajax({
                method: "post",
                url: "/handler/ProductHandler.ashx",
                datatype: "text/plain",
                data: { op: "CreateOrder", detail: _detail, PayMentType: _paymentType, shippingMethod: _shipingType, captcha: captchaResponse, name: _name, email: _email, phone: _phone, address: _address, ProductList: $.cookie("CartList"), shipingFee: parseInt(_shipingFee) + parseInt(_paymentFee) },
                success: function (rs) {
                    
                    $("#ajax_loader").hide();
                    if (!isNaN(rs)) {
                        $.removeCookie('CartList', { path: '/' });
                        if (isPaymentOnline) {
                            $("#cartContent2").html("<h4>Đơn hàng số #" + rs + " đang được chuyển tới cổng thanh toán</h4>");
                            try {
                                Util.notify("", "Đơn hàng đang được chuyển sang cổng thanh toán. ");
                            } catch (e) {

                            }
                            
                            var _totalPrice = $("#ttOdCt").html().replace("đ", "").replace(/\,/g, '');
                            var _bankcode = $('input[name=bankcode]:checked').val();

                            $.ajax({
                                method: "post",
                                url: "/handler/PaymentHandler.ashx",
                                datatype: "text/plain",
                                data: { op: "nlCheckout", detail: "Thanh toán cho đơn hàng số #" + rs, captcha: captchaResponse, name: _name, email: _email, phone: _phone, address: _address, price: _totalPrice, shipingFee: parseInt(_shipingFee) + parseInt(_paymentFee), orderId: rs, payment_method: _paymentCode, bankcode: _bankcode },

                                success: function (checkOutUrl) {
                                    if (Util.isUrl(checkOutUrl)) {
                                        window.location.href = checkOutUrl;
                                    } else {
                                        Util.notify("Lỗi: ", checkOutUrl);
                                    }
                                        
                                }
                            });
                        } else {
                            $("#cartContent2").html("<h4>Đơn hàng số #" + rs + " đã được gửi thành công tới bộ phận bán hàng. Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!</h4>");
                            Util.notify("", "Đơn hàng đã được gửi tới bộ phận bán hàng. ");
                        }


                    } else {
                        Util.notify("", rs);
                        $("#cartContent1").show();
                        grecaptcha.reset();
                    }
                }
            });
        }
    }
}