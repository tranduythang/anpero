var Translate = {
    match : [['tr', 'c'],['q', 'k'],['d', 'z'],['c(?!h)', 'k'],['gi', 'z'],['ch', 'c'],['ngh?', 'q'],['\u0111', 'd'],['gh', 'g'],['nh', 'n\''],['kh', 'x'],['ph', 'f'],['r', 'z'],['th', 'w'],],    
    Go: function (input) {
        if ('string' !== typeof input) {
            input = String(input);
        }
        Translate.match.forEach(function (index) {
            input = Translate.convert(input, index);
        });
        return input;
    },
    convert:function(val, match) {
        return val.replace(new RegExp(match[0], 'g'), match[1]).replace(new RegExp(Translate.capitalize(match[0]), 'g'), Translate.capitalize(match[1])).replace(new RegExp(match[0].toUpperCase(), 'g'), match[1].toUpperCase());
    },
    capitalize: function (a) {
    return a.replace(new RegExp('\b\w', 'g'), function(i){ return i.toUpperCase() })
    }
}
$(document).ready(function () {
    $("#ip").keyup(function () {
        var temp = Translate.Go($("#ip").val());
        temp = temp.replace(/(?:\r\n|\r|\n)/g, '<br />');
        $("#translateCt").html(temp);
    })
})
