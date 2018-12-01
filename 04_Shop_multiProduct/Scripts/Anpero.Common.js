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
    },
    resizeVideo:function () { var contentW = $('#center_column').width(); var iframe = $('#center_column iframe'); var iframeW = iframe.css('width', contentW - 20); iframe.css('width', iframeW); var iframeH = contentW / 16 * 9; iframe.css('height', iframeH); }

}
var Search = {
    Data: {},
    GetData: function () {
        
        this.Data.Category = $("#search2 select[name='category']").val();
        this.Data.GroupId = $("#search2 select[name='GroupId']").val();
        this.Data.SortBy = $("#search2 select[name='SortBy']").val();
        this.Data.priceRank = $("#search2 select[name='priceRank']").val();
       return this.Data;
    },
    Sunmit: function () {
        $.ajax({
            url: "/product/searchAjax",
            data: Search.GetData(),
            success: function (rs) {
                $("#prListContent").html(rs);
                
            }


        });
    },
    Init: function () {
        $("form input,form select").change(function () {
            Search.Sunmit();
        });
    }
}