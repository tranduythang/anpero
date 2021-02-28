var Cart = {
    list: [],
    quantity: 1,
    addProduct: function (_id, _price, _thumb, _title, _originPrice = 0) {        
        debugger
        if (_originPrice == 0) {
            _originPrice = _price;
        }
        var checkExited = false;
        var productCookies = Cookies.get("CartList");
        if (productCookies) {
            Cart.list = jQuery.parseJSON(productCookies);
        }
        var quantity = Cart.quantity;
        if (Cart.list.length == 0) {

            Cart.list.push({ id: _id, quantity, price: _price, thumb: _thumb, title: _title, originPrice: _originPrice});
        } else {
            for (var i = 0; i < Cart.list.length; i++) {
                if (Cart.list[i].id == _id) {
                    Cart.list[i].price = parseInt(_price);
                    Cart.list[i].quantity = parseInt(Cart.list[i].quantity) + parseInt(quantity);
                    checkExited = true;
                }
            }
            // if this product no in cart list
            if (!checkExited) {
                Cart.list.push({ id: _id, quantity: 1, price: _price, thumb: _thumb, title: _title, originPrice: _originPrice });
            }
        }        
        Cookies.set('CartList', JSON.stringify(Cart.list), { expires: 7, path: '/' })
        window.location.href = "/product/checkout";
        
       
    },
    addProduct3: function(_id, _price, _thumb, _title, _originPrice = 0) {
        debugger
        if (_originPrice==0){
            _originPrice=_price;
        }
        var productCookies = Cookies.get("CartList");
        var checkExited = false;
        if (productCookies) {
            Cart.list = jQuery.parseJSON(productCookies);
        }

        if (Cart.list.length == 0) {
            Cart.list.push({ id: _id, quantity: 1, price: _price, thumb: _thumb, title: _title, originPrice: _originPrice });
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
                Cart.list.push({ id: _id, quantity: 1, price: _price, thumb: _thumb, title: _title, originPrice: _originPrice});
            }
        }
        $.cookie("CartList", JSON.stringify(Cart.list), { path: '/' });
        Cart.bindCart();
    },
    addProduct2: function (_id, _price) {
        var productCookies = Cookies.get("CartList");
        if (productCookies) {
            Cart.list = jQuery.parseJSON(productCookies);
        }
        for (var i = 0; i < Cart.list.length; i++) {
            if (Cart.list[i].id == _id) {
                Cart.list[i].price = parseInt(Cart.list[i].price);
                Cart.list[i].quantity = parseInt(Cart.list[i].quantity) + 1;
                $("#prQuantity_" + _id).val(Cart.list[i].quantity);
            }
        }
        var stringData = JSON.stringify(Cart.list);
        Cookies.set('CartList', stringData, { expires: 7, path: '/' })
        
        Cart.bindCartTable();
    },
    bindCart: function () {
        try {
            var productCookies = Cookies.get("CartList");
            if (productCookies) {
                Cart.list = jQuery.parseJSON(productCookies);
                if (Cart.list.length > 0) {
                    $(".icon-basket .count").html(Cart.list.length);
                } else {
                    $(".icon-basket .count").html(0);
                }
            }
         
        } catch (e) {
            $(".icon-basket .count").html(0);
        }
    },
    updateQuantity: function (_id, _quantity) {
        var productCookies = Cookies.get("CartList")
        if (productCookies) {
            Cart.list = jQuery.parseJSON(productCookies);
        }
        for (var i = 0; i < Cart.list.length; i++) {
            if (Cart.list[i].id == _id) {
                Cart.list[i].quantity = _quantity;
            }
        }
        Cookies.set('CartList', JSON.stringify(Cart.list), { expires: 7, path: '/' })        
        Cart.bindCartTable();
    },
    bindCartTable: function () {
        
        var ttSC = 0;

        var _paymentFee = $('input[name=radio_4]:checked').attr("data-ship");
        var htmlCat = "";
        var productCookies = Cookies.get("CartList");
        if (productCookies) {

            Cart.list = jQuery.parseJSON(productCookies);
            try {
                
                $(".spN").html(Cart.list.length);
                for (var i = 0; i < Cart.list.length; i++) {
                    ttSC += parseInt(Cart.list[i].price) * parseInt(Cart.list[i].quantity);
                    htmlCat += '<tr>';
                    htmlCat += '<td class="cart_product">';
                    htmlCat += '<a href="#"><img src="' + Cart.list[i].thumb + '" alt="' + Utils.decodeHTML(Cart.list[i].title) + '"></a>';
                    htmlCat += '</td>';
                    htmlCat += '<td class="cart_description">';
                    htmlCat += '<p class="product-name"><a href="#">' + Utils.decodeHTML(Cart.list[i].title) + ' </a></p>';
                    htmlCat += '</td>';
                    htmlCat += '<td class="price"><span>' + Utils.toMoneyFormat(Cart.list[i].price) + 'đ</span></td>';
                    htmlCat += '<td class="price"><span>' + Utils.toMoneyFormat(Cart.list[i].originPrice - Cart.list[i].price) + 'đ</span></td>';
                    htmlCat += '<td class="qty">';
                    htmlCat += '<a href="javascript:Cart.remove3(' + Cart.list[i].id + ',' + Cart.list[i].price + ');" class="btn">-</a>';
                    htmlCat += '<input class="input-text qty2" type="text" value="' + Cart.list[i].quantity + '" id="prQuantity_' + Cart.list[i].id + '">';
                    htmlCat += '<a href="javascript:Cart.addProduct2(' + Cart.list[i].id + ',' + Cart.list[i].price + ');" class="btn">+</a>';
                    htmlCat += '</td>';
                    //htmlCat += '<td class="price">';
                    //htmlCat += '<span>' + Utils.toMoneyFormat(parseInt(Cart.list[i].price) * parseInt(Cart.list[i].quantity)) + ' đ</span>';
                    //htmlCat += '</td>';
                    htmlCat += '<td class="a-center last">';
                    htmlCat += '<a href="javascript:Cart.remove2(' + Cart.list[i].id + ')" class="button remove-item">Xóa</a>';
                    htmlCat += '</td>';
                    htmlCat += '</tr>';
                }
                var shipingFee = $('input[name=radio_3]:checked').attr("data-ship");
                $("#ttPrCt").html(Utils.toMoneyFormat(ttSC) + " đ");
                $("#ttOdCt").html(Utils.toMoneyFormat(parseInt(ttSC) + parseInt(shipingFee) + parseInt(_paymentFee)) + " đ");
                $("#prCatCtTable").html(htmlCat);
                $(".qty input").change(function () {
                    var id = $(this).attr('id').replace("prQuantity_", "");
                    Cart.updateQuantity(id, $(this).val());
                });
            } catch (e) {
                console.log(e);
                $(".spN").html("0");
            }
        }
    },
    bindSmallCart: function () {

        var ttSC = 0;
        var htmlCat = "";
        var productCookies = Cookies.get("CartList");
        if (productCookies!=null) {

            Cart.list = jQuery.parseJSON(productCookies);
            try {

                $(".spN").html(Cart.list.length);
                for (var i = 0; i < Cart.list.length; i++) {
                    ttSC += parseInt(Cart.list[i].price) * parseInt(Cart.list[i].quantity);
                    htmlCat += '<div class="navbar-cart-item">';
                    htmlCat += '<div class="navbar-cart-item-left thumbnail"><a class="thumbnail-small" href="#"><img src="' + Utils.decodeHTML(Cart.list[i].thumb) + '" alt="" width="72" height="91"></a></div>'
                    htmlCat += '<div class="navbar-cart-item-body">';
                    htmlCat += '<a class="navbar-cart-item-heading" href="#">' + Utils.decodeHTML(Cart.list[i].title)+'</a>';
                    htmlCat += '<div class="navbar-cart-item-price d-flex group-10 justify-content-between">'
                    htmlCat += '<div>' + Cart.list[i].quantity + ' x <span class="navbar-cart-item-price-value">' + Cart.list[i].price+'đ</span>';
                    htmlCat += '</div><button class="navbar-cart-remove mdi-delete" onclick="Cart.remove3(' + Cart.list[i].id + ',' + Cart.list[i].price + ');"></button></div></div></div >';               
                    
                }               
                $(".qty input").change(function () {
                    var id = $(this).attr('id').replace("prQuantity_", "");
                    Cart.updateQuantity(id, $(this).val());
                });
                htmlCat += '<div class="navbar-cart-total">Subtotal: ' + Utils.toMoneyFormat(ttSC) +'đ</div><a class="btn btn-sm navbar-cart-btn" href="/product/checkout">Checkout</a>';
                $(".navbar-cart").html(htmlCat);
            } catch (e) {
                
                $(".spN").html("0");
            }
        }
    },
    remove: function (prId) {
        var productCookies = Cookies.get("CartList");
        Cart.list = jQuery.parseJSON(productCookies);
        for (var i = 0; i < Cart.list.length; i++) {
            if (Cart.list[i].id == prId) {
                Cart.list.splice(i, 1);
            }
        }        
        Cookies.set('CartList', JSON.stringify(Cart.list), { expires: 7, path: '/' });
        Cart.bindCart();
    },
    remove2: function (prId) {
        Cart.list = jQuery.parseJSON(Cookies.get("CartList"));
        for (var i = 0; i < Cart.list.length; i++) {
            if (Cart.list[i].id == prId) {
                Cart.list.splice(i, 1);
            }
        }
        
        Cookies.set('CartList', JSON.stringify(Cart.list), { expires: 7, path: '/' });
        Cart.bindCartTable();
    },
    remove3: function (_id) {
        var productCookies = Cookies.get("CartList");
        if (productCookies) {
            Cart.list = jQuery.parseJSON(productCookies);
        }
        for (var i = 0; i < Cart.list.length; i++) {

            if (Cart.list[i].id == _id && parseInt(Cart.list[i].quantity) > 1) {
                Cart.list[i].price = parseInt(Cart.list[i].price);
                Cart.list[i].quantity = parseInt(Cart.list[i].quantity) - 1;
            }
        }
        Cookies.set("CartList", JSON.stringify(Cart.list), { expires: 7, path: '/' });        
        Cart.bindCartTable();
        Cart.bindSmallCart();
    },
    sendOrder: function () {
        var productCookies = Cookies.get("CartList");
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
            $(".alert").html("Bạn chưa nhập tên liên hệ").removeClass("d-none");

        }
        if (_address == 'null' || _address == "") {
            valid = false;
            $(".alert").html("Vui lòng nhập địa chỉ").removeClass("d-none");            
            
        }

        if (_email != "" && !Utils.isEmail(_email)) {
            valid = false;
            $(".alert").html("Email không đúng định dạng").removeClass("d-none");            
        }

        if (_phone == "" || _phone == 'null') {
            valid = false;
            $(".alert").html("Số điện không được để trống").removeClass("d-none");                   
        } else if (!Utils.isVnFone(_phone)) {
            valid = false;
            $(".alert").html("Số điện không đúng định dạng").removeClass("d-none");       
        }
        var captchaResponse = grecaptcha.getResponse(googleCatcha2);
        if (captchaResponse == "" || captchaResponse == null) {
            grecaptcha.reset();
            
            $(".alert").html("Vui lòng nhập click vào ô kiểm tra").removeClass("d-none");       
            valid = false;
        }
        if (productCookies==null) {
            $(".alert").html("Giỏ hàng đang trống không thể tạo đơn hàng").removeClass("d-none");    
            valid = false;
        }
        var isPaymentOnline = false;
        if ((parseInt(_paymentType) === 2 || parseInt(_paymentType) === 3) && _paymentCode != "" && _paymentCode != null) {
            isPaymentOnline = true;
        }
        if (isPaymentOnline && $('input[name=bankcode]:checked').val() == null) {
            valid = false;
            $(".alert").html("Vui lòng chọn ngân hàng thanh toán.").removeClass("d-none");    
        }

        if (isPaymentOnline && (_email == "" || !Utils.isEmail(_email))) {
            valid = false;
            $(".alert").html("Email không đúng định dạng, Thanh toán Online yêu cầu nhập Email").removeClass("d-none");    
           
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
                data: { op: "CreateOrder", detail: unescape(_detail), PayMentType: _paymentType, shippingMethod: _shipingType, captcha: captchaResponse, name: unescape(_name), email: _email, phone: _phone, address: _address, ProductList: productCookies, shipingFee: parseInt(_shipingFee) + parseInt(_paymentFee) },
                success: function (rs) {

                    $("#ajax_loader").hide();
                    if (!isNaN(rs)) {
                        Cookies.remove('CartList', { path: '/' })
                        if (isPaymentOnline) {
                            $("#cartContent2").html("<h4>Đơn hàng số #" + rs + " đang được chuyển tới cổng thanh toán</h4>");

                            Utils.notify("", "Đơn hàng đang được chuyển sang cổng thanh toán. ");
                            var _totalPrice = $("#ttOdCt").html().replace("đ", "").replace(/\,/g, '');
                            var _bankcode = $('input[name=bankcode]:checked').val();

                            $.ajax({
                                method: "post",
                                url: "/handler/PaymentHandler.ashx",
                                datatype: "text/plain",
                                data: { op: "nlCheckout", detail: "Thanh toán cho đơn hàng số #" + rs, captcha: captchaResponse, name: _name, email: _email, phone: _phone, address: _address, price: _totalPrice, shipingFee: parseInt(_shipingFee) + parseInt(_paymentFee), orderId: rs, payment_method: _paymentCode, bankcode: _bankcode },

                                success: function (checkOutUrl) {
                                    if (Utils.isUrl(checkOutUrl)) {
                                        window.location.href = checkOutUrl;
                                    } else {
                                        Utils.notify("Lỗi: ", checkOutUrl);
                                        $(".alert").html("Email không đúng định dạng, Thanh toán Online yêu cầu nhập Email").removeClass("d-none");    
                                    }

                                }
                            });
                        } else {
                            $("#cartContent2").html("<h4>Đơn hàng số #" + rs + " đã được gửi thành công tới bộ phận bán hàng. Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!</h4><h5>Với thông tin chuyển khoản vui lòng click vào <a href='/PaymentInfo' style='color: blue;'>link này</a> để được hướng dẫn chuyển khoản</h5>");
                            $(".alert").html("Đơn hàng đã được gửi tới bộ phận bán hàng.").removeClass("d-none");    
                        }


                    } else {
                        Utils.notify("", rs);
                        $("#cartContent1").show();
                        grecaptcha.reset();
                    }
                }
            });
        }
    },
    saveTempForm: function () {
        OrderForm.Name = $("#cName").val();
        OrderForm.Phone = $("#cPhone").val();
        OrderForm.Email = $("#cMail").val();
        OrderForm.Address = $("#cAddress").val();
        OrderForm.Detail = $("#detail").val();
        Cookies.set('TempForm', JSON.stringify(OrderForm), { expires: 7, path: '' });
    },
    bindTempForm: function () {
        var tempCookie = Cookies.get('TempForm');
        if (tempCookie) {
            OrderForm = jQuery.parseJSON(tempCookie);
            $("#cName").val(OrderForm.Name);
            $("#cPhone").val(OrderForm.Phone);
            $("#cMail").val(OrderForm.Email);
            $("#cAddress").val(OrderForm.Address);
            $("#detail").val(OrderForm.Detail);
        }

    }
};

var OrderForm = {
    Name: "",
    Phone: "",
    Email: "",
    Address: "",
    Detail: "",
    PaymentMethod: "",
    ShipMethod: ""
};

var order = "pricedesc";
$(document).ready(function () {
    Cart.bindSmallCart();
    if ($(".cartContent input")) {
        $(".cartContent input").change(function () {
            Cart.saveTempForm();
        });
        $(".cartContent  textarea").change(function () {
            Cart.saveTempForm();
        });
    }
    

});
