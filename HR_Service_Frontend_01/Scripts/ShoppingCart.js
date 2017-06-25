var Cart = {
    list: [],
    addProduct: function (_id, _price, _thumb, _title) {
        debugger
        var checkExited = false;
        if ($.cookie("CartList") != null && $.cookie("CartList") != "undefined" && $.cookie("CartList") != "null") {
            Cart.list = jQuery.parseJSON($.cookie("CartList"));
        }

        if (Cart.list.length == 0) {
            Cart.list.push({ id: _id, quantity: 1, price: _price, thumb: _thumb, title: _title });
        } else {
            for (var i = 0; i < Cart.list.length; i++) {
                if (Cart.list[i].id == _id) {
                    Cart.list[i].price = parseInt(_price) + parseInt(Cart.list[i].price)
                    Cart.list[i].quantity = parseInt(Cart.list[i].quantity) + 1;
                    checkExited = true;
                }
            }
            if (!checkExited) {
                Cart.list.push({ id: _id, quantity: 1, price: _price, thumb: _thumb, title: _title });
            }
        }
        var date = new Date();
        var minutes = 60 * 2;
        date.setTime(date.getTime() + (minutes * 60 * 1000));
        $.cookie("CartList", JSON.stringify(Cart.list), { expires: date, path: '/' });
        Cart.bindCart();
    },
    addProduct2: function (_id, _price) {
        debugger
        if ($.cookie("CartList") != null && $.cookie("CartList") != "undefined" && $.cookie("CartList") != "null") {
            Cart.list = jQuery.parseJSON($.cookie("CartList"));
        }
        for (var i = 0; i < Cart.list.length; i++) {
            if (Cart.list[i].id == _id) {
                Cart.list[i].price =  parseInt(Cart.list[i].price)
                Cart.list[i].quantity = parseInt(Cart.list[i].quantity) + 1;
                $("#prQuantity_" + _id).val(Cart.list[i].quantity);
            }
        }        
        var date = new Date();
        var minutes = 60 * 2;
        date.setTime(date.getTime() + (minutes * 60 * 1000));
        $.cookie("CartList", JSON.stringify(Cart.list), { expires: date, path: '/' });
        Cart.bindCartTable();
    },
    bindCart: function () {
        var ttSC = 0;
        var htmlCat = "";
        if ($.cookie("CartList") != 'null' && $.cookie("CartList") != "undefined") {
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
                htmlCat += '<td class="cart_avail"><span class="label label-success">Sẵn sàng</span></td>';
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
            var shipingFee = $('input[name=radio_3]:checked').val();
            $("#ttPrCt").html(Util.toMoneyFormat(ttSC) + " đ");
            $("#ttOdCt").html(Util.toMoneyFormat(parseInt(ttSC) + parseInt(shipingFee)) + " đ");
            $("#prCatCtTable").html(htmlCat);


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
        $.cookie("CartList", JSON.stringify(Cart.list), { expires: date, path: '/' });
        Cart.bindCart();
    },
    remove2: function (prId) {
        Cart.list = jQuery.parseJSON($.cookie("CartList"));
        for (var i = 0; i < Cart.list.length; i++) {
            if (Cart.list[i].id == prId) {
                Cart.list.splice(i, 1);
            }
        }
        var date = new Date();
        var minutes = 60 * 2;
        date.setTime(date.getTime() + (minutes * 60 * 1000));
        $.cookie("CartList", JSON.stringify(Cart.list), { expires: date, path: '/' });
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
        var date = new Date();
        var minutes = 60 * 2;
        date.setTime(date.getTime() + (minutes * 60 * 1000));
        $.cookie("CartList", JSON.stringify(Cart.list), { expires: date, path: '/' });
        Cart.bindCartTable();
    },
    sendOrder: function () {
        var valid = true;
        var _name = $("#cName").val();
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
        if (_name == 'null' || _name == "") {
            valid = false;
        }
        if (!Util.isEmail(_email)) {
            valid = false;
        }
        if (_phone != "" && _phone != 'null' && !Util.isVnFone(_phone)) {
            valid = false;
        }
    }
}