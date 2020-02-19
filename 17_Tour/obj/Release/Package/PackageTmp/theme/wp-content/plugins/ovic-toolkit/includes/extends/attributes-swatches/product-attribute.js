;(function ($) {
    "use strict";

    $.fn.ovic_variations_custom = function () {
        $(this).closest('form').find('.data-val').html('');
        $(this).each(function () {
            var _this = $(this);

            _this.find('option').each(function () {
                var _ID          = $(this).parent().data('id'),
                    _data        = $(this).data(_ID),
                    _value       = $(this).attr('value'),
                    _name        = $(this).html(),
                    _data_type   = $(this).data('type'),
                    _data_width  = $(this).data('width'),
                    _data_height = $(this).data('height'),
                    _itemclass   = _data_type;

                if ( $(this).is(':selected') ) {
                    _itemclass += ' active';
                }
                if ( _value !== '' ) {
                    if ( _data_type == 'color' || _data_type == 'photo' ) {
                        _this.parent().find('.data-val').append('<a class="change-value ' + _itemclass + '" href="#" style="background: ' + _data + ';background-size: cover; background-repeat: no-repeat;min-width:' + _data_width + 'px;height:' + _data_height + 'px;line-height:' + _data_height + 'px;" data-value="' + _value + '"><span class="name">' + _name + '</span></a>');
                    } else {
                        _this.parent().find('.data-val').append('<a class="change-value ' + _itemclass + '" href="#" data-value="' + _value + '" style="min-width:' + _data_width + 'px;height:' + _data_height + 'px;line-height:' + _data_height + 'px;"><span class="name">' + _name + '</span></a>');
                    }
                }
            });
        });
    };

    $(document).on('click', '.reset_variations', function () {
        $('.variations_form, .ovic_variations_form').find('.change-value').removeClass('active');
    });
    $(document).on('click', '.variations_form .change-value, .ovic_variations_form .change-value', function (e) {
        var _this   = $(this),
            _change = _this.data('value');

        if ( _this.hasClass('active') ) {
            _this.parent().parent().children('select').val('').trigger('change');
            _this.removeClass('active');
        } else {
            _this.parent().parent().children('select').val(_change).trigger('change');
            _this.addClass('active').siblings().removeClass('active');
        }
        e.preventDefault();
    });
    $(document).on('woocommerce_variation_has_changed wc_variation_form', function (event) {
        $(event.target).find('select').ovic_variations_custom();
    });
})(jQuery);