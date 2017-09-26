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

    }
};
var Location = {
    Init: function () {
        $(document).ready(function () {
            Location.Getlocation(0);
            $("#country").change(function () {
                Location.Getlocation($("#country option:selected").val());
            });
        });
    },
    Getlocation: function (_parentLocation) {
        if (_parentLocation > 0) {
            $("#prov").html("<option value=0>Đang tải dữ liệu</option>");
        }
        
        $.ajax({
            method: "post",
            url: "/handler/LocationHandler.ashx",
            datatype: "text/plain",
            data: { ParentLocationId: _parentLocation },
            success: function (rs) {
                if (_parentLocation == 0) {
                    $("#country").html(rs);
                } else {
                    $("#prov").html(rs);
                }
            }
        });
    }
};  
var Category = {
    Init: function () {
        $(document).ready(function () {
            $("#cat_s").change(function () {
                $("#scat option").hide();
                $(".cct_" + $("#cat_s option:selected").val()).show();
            });

        });
    }
};
