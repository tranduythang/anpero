var Util = {
    toMoneyFormat: function (input) {
        var nf = new Intl.NumberFormat();
       return nf.format(input);
    }
}