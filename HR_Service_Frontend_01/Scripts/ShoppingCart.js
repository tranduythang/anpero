var Cart = {    
    list: [],
    addProduct: function (_id, _price, _thumb, _title) {
        var checkExited = false;
        Cart.list = jQuery.parseJSON($.cookie("CartList"));
        if (Cart.list.length == 0) {
            Cart.list.push({ id: _id,quantity:1, price: _price, thumb: _thumb, title: _title });
        } else {
            for (var i = 0; i < Cart.list.length; i++) {
                if (Cart.list[i].id == _id) {
                    Cart.list[i].price =parseInt(_price) + parseInt(Cart.list[i].price)
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
        $.cookie("CartList", JSON.stringify(Cart.list), { expires: date });
        
    },
}
