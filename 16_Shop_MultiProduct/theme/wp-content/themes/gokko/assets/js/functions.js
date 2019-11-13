;(function ($) {
    "use strict";
    var winW    =   $(window).width(),
        winH    =   $(window).height(),
        docH    =   0,
        winScrLast = 0,
        winScr  =   0,
        isMobile = navigator.userAgent.match(/Android/i) || navigator.userAgent.match(/webOS/i) || navigator.userAgent.match(/iPhone/i) || navigator.userAgent.match(/iPad/i) || navigator.userAgent.match(/iPod/i);
    /* Countdown */
    $.fn.gokko_countdown = function () {
        var time = $(this).data('datetime'),
            txt_day = $(this).data('txt_day'),
            txt_hour = $(this).data('txt_hour'),
            txt_min = $(this).data('txt_min'),
            txt_sec = $(this).data('txt_sec'),
            value_first = $(this).data('value_first'),
            html = '';
        if ( txt_day ) {
            if ( value_first == '0' )
                html += '<div class="countdown-item item-day"><span class="item-label">' + txt_day + '</span><span class="item-value">%D</span></div>';
            else
                html += '<div class="countdown-item item-day"><span class="item-value">%D</span><span class="item-label">' + txt_day + '</span></div>';
        }
        if ( txt_hour ) {
            if ( value_first == '0' )
                html += '<div class="countdown-item item-hour"><span class="item-label">' + txt_hour + '</span><span class="item-value">%H</span></div>';
            else
                html += '<div class="countdown-item item-hour"><span class="item-value">%H</span><span class="item-label">' + txt_hour + '</span></div>';
        }
        if ( txt_min ) {
            if ( value_first == '0' )
                html += '<div class="countdown-item item-min"><span class="item-label">' + txt_min + '</span><span class="item-value">%M</span></div>';
            else
                html += '<div class="countdown-item item-min"><span class="item-value">%M</span><span class="item-label">' + txt_min + '</span></div>';
        }
        if ( txt_sec ) {
            if ( value_first == '0' )
                html += '<div class="countdown-item item-sec"><span class="item-label">' + txt_sec + '</span><span class="item-value">%S</span></div>';
            else
                html += '<div class="countdown-item item-sec"><span class="item-value">%S</span><span class="item-label">' + txt_sec + '</span></div>';
        }
        if ( html ) {
            $(this).countdown(time, function (event) {
                $(this).html(event.strftime(html));
            });
        }
    };
    var GOKKO_THEME = {
        content_loaded:function(){
            this.gokko_countdown_init();
        },
        init: function () {      
            this.gokko_custom_scrollbar();
            if($(".product-item.style-10 .variation-images .js-select-variation.selected").length >0){
                $(".product-item.style-10 .variation-images .js-select-variation.selected").each(function () {
                    var _p = $(this).closest('.product-item'), src = $(this).data('image');
                    _p.find('.wp-post-image').attr('src', src);
                });
            }
        },
      
        gokko_countdown_init: function () {
            if ( $('.gokko-countdown').length > 0 ) {
                $('.gokko-countdown').each(function () {
                    $(this).gokko_countdown();
                })
            }
        },
        gokko_custom_scrollbar: function () {
            //$('.widget_shopping_cart_content .cart_list').scrollbar();
        },
    };
    $('body').on('click', '.quantity .quantity-plus', function (e) {
        var _this  = $(this).closest('.quantity').find('input.qty'),
            _value = parseInt(_this.val()),
            _max   = parseInt(_this.attr('max')),
            _step  = parseInt(_this.data('step')),
            _value = _value + _step;
        if ( _max && _value > _max ) {
            _value = _max;
        }
        _this.val(_value);
        _this.trigger("change");
        e.preventDefault();
    });
    $('body').on('click', '.js-redirect', function (e) {
        var _url = $(this).data('url');
        if (_url != undefined && _url != ''){
            window.location.href = _url;
        }
    });

    $(document).on('change', function () {
        $('.quantity').each(function () {
            var _this  = $(this).find('input.qty'),
                _value = _this.val(),
                _max   = parseInt(_this.attr('max'));
            if ( _value > _max ) {
                $(this).find('.quantity-plus').css('pointer-events', 'none')
            } else {
                $(this).find('.quantity-plus').css('pointer-events', 'auto')
            }
        })
    });
    $('body').on('click', '.quantity .quantity-minus', function (e) {
        var _this  = $(this).closest('.quantity').find('input.qty'),
            _value = parseInt(_this.val()),
            _min   = parseInt(_this.attr('min')),
            _step  = parseInt(_this.data('step')),
            _value = _value - _step;
        if ( _min && _value < _min ) {
            _value = _min;
        }
        if ( !_min && _value < 0 ) {
            _value = 0;
        }
        _this.val(_value);
        _this.trigger("change");
        e.preventDefault();
    });


    $(document).on('click', 'a.backtotop', function () {
        $('html, body').animate({scrollTop: 0}, 800);
        return false;
    });
    $(document).on('click', '.filter-toggle', function () {
        $('body').addClass('overlay-open');
        $('.widget-area').addClass('open');
        $(this).toggleClass('open');
        return false;
    });
    $(document).on('click', '.myaccount-toggle', function () {
        $('body').addClass('overlay-open');
        $('.mobile-wpml-switcher').addClass('open');
        $(this).toggleClass('open');
        return false;
    });
    $(document).on('click', '.close-block-sidebar', function () {
        $('body').removeClass('overlay-open');
        $('.widget-area, .mobile-wpml-switcher').removeClass('open');
        return false;
    });
    $(document).on('click', '.overlay-body', function () {
        $('body').removeClass('overlay-open');
        $('.widget-area, .mobile-wpml-switcher').removeClass('open');
    });
    $(document).on('click', '.form-search-mobile >a', function () {
        $('body').addClass('overlay-open');
        $(this).closest('.form-search-mobile').addClass('open');
        $(this).closest('.form-search-mobile').find('.searchfield').focus();
        return false;
    });
    $(document).on('click', '.form-search-mobile .close-block-search', function () {
        $('body').removeClass('overlay-open');
        $(this).closest('.form-search-mobile').removeClass('open');
        return false;
    });
    $(document).on('click', '.overlay-body', function () {
        $('body').removeClass('overlay-open');
        $('.form-search-mobile').removeClass('open');
    });
    $(document).on('click', '.ovic-custommenu-load-more', function () {
        $(this).prev().children('.link-other').slideToggle();
    });
    $(document).on('click', '.ovic_products_style2 .js-image-thumb', function () {
        var p = $(this).closest('.product-images');
        p.find('.primary-image').attr({'src': $(this).data('src'), 'alt': $(this).data('alt')});
        $(this).addClass('selected').siblings().removeClass('selected');
    });

    $(document).on('click', '.js-select-variation', function () {
        var p               = $(this).closest('.product-is-variation'),
            product_id      = $(this).data('product_id'),
            variation_id    = $(this).data('variation_id'),
            variation_price = p.find('.variation-' + product_id + '-' + variation_id),
            src = $(this).data('image');
        $(this).addClass('selected').siblings().removeClass('selected');
        variation_price.addClass('selected').siblings().removeClass('selected');
        p.find('.variation_ajax_add_to_cart').attr('data-attributes', $(this).attr('data-attributes'));
        if(src !== undefined){
            var _p = $(this).closest('.product-item');
            _p.find('.wp-post-image').attr('src', src);

        }
    });
    $(document).on('click', '.ovic-share-socials .share-button', function () {
        $(this).closest('.ovic-share-socials').toggleClass('active');
    });
    $(document).on('click', '.ovic-custommenu-open-sub-menu', function () {
        var p = $(this).parent();
        if ( p.hasClass('opened') ) {
            p.removeClass('opened');
            $(this).next().slideUp("slow");
        } else {
            p.addClass('opened');
            $(this).next().slideDown("slow");
        }
    });
    $(document).on('click', '.widgettitle', function () {
        var p = $(this).parent();
        if ( p.hasClass('opened') ) {
            p.removeClass('opened').find('.ovic-menu-wapper').slideUp("slow");
        } else {
            p.addClass('opened').find('.ovic-menu-wapper').slideDown("slow");
        }
    });
    $(document).on('click', '.top-sidebar .arrow-sidebar', function () {
        $(this).closest('.arrow-sidebar').toggleClass('has-open');
        $(this).closest('.sidebar').children('.shop-sidebar').slideToggle(300);
    });
    $(document).on('click', '.box-search-mobile .btn-submit', function (e) {
        $(this).closest('.header-middle-inner').toggleClass('active');
        e.preventDefault();
    });
    $(document).on('click', '.ovic-tabs .tab-link a', function () {
        $(this).closest('.tab-head').removeClass('open');
    });
    $(document).on('click', '.ovic-pin .ovic-popup', function () {
        $(this).closest('.ovic-pin').removeClass('actived');
    });

    $('body').on('wc_fragments_loaded', function () {
        GOKKO_THEME.gokko_custom_scrollbar();
    });

    $('body').on('added_to_wishlist', function (e, el, el_wrap) {
        el.closest('.ovic-wishlist').addClass('added');
        el.siblings('.ajax-loading').css('visibility', 'hidden');
    });
    $('body').on('ovic_menuclone_all_menus', function () {
        $(".ovic-menu-clone-wrap").find('.lazy:not(.lazyed)').each(function () {
            var _img = $(this).attr('data-src');
            if ( _img !== undefined ) {
                $(this).attr('src', _img);
            }
            $(this).addClass('lazyed');
        });
    });

    


   
    $(window).scroll(function (event) {
        var winScr = $(window).scrollTop();
        if (docH == 0){
            docH    =   $(document).height();
        }
        if ( winScr > 1000 ) {
            $('.backtotop').addClass('show');
        } else {
            $('.backtotop').removeClass('show');
        }
        if ( winW < 1200 ) {
            if (winScr > 60){
                if ( winScr > winScrLast ) {
                    if ( winScr + winH + 60 >= docH ) {
                        $('.mobile-footer').addClass('is-sticky');
                    } else {
                        $('.mobile-footer').removeClass('is-sticky');
                    }
                } else {
                    $('.mobile-footer').addClass('is-sticky');
                }
            }else{
                $('.mobile-footer').removeClass('is-sticky');
            }
        }
        winScrLast = winScr;
    });
    if(!isMobile){
        $(window).resize(function(){
            resizeCall();
        });
    } else{
        window.addEventListener("orientationchange", function() {
            resizeCall();
        }, false);
    }
    function resizeCall(){
        winW    =   $(window).width();
        winH    =   $(window).height();
        docH    =   $(document).height();
        if (winW < 1200){
            if ($('.mobile-footer-inner>div:visible').length >0){
                $('.mobile-footer-inner>div:visible').css('width', 100 / $('.mobile-footer-inner>div:visible').length + '%');
            }
            if (winScr > 60){
                if ( winScr > winScrLast ) {
                    if ( winScr + winH + 60 >= docH ) {
                        $('.mobile-footer').addClass('is-sticky');
                    } else {
                        $('.mobile-footer').removeClass('is-sticky');
                    }
                } else {
                    $('.mobile-footer').addClass('is-sticky');
                }
            }else{
                $('.mobile-footer').removeClass('is-sticky');
            }
            $(".sidebar:not(.initialized)").addClass('initialized').find('.lazy:not(.lazyed)').each(function () {
                var _img = $(this).attr('data-src');
                if ( _img !== undefined ) {
                    $(this).attr('src', _img)
                }
                $(this).addClass('lazyed');
            });
        }
        winScrLast = winScr;
        return true;
    }
    document.addEventListener("DOMContentLoaded", function(event) {
        GOKKO_THEME.content_loaded();
    });
    window.addEventListener('load',
        function (ev) {
            GOKKO_THEME.init();
            $( '.gokko_variations_form' ).each( function() {
                $( this ).wc_variation_form();
            });

        }, false);
    $(document).on('click', '.gokko_variations_form .change-value', function (e) {
        var _this   = $(this),
            _change = _this.data('value'),
            _p = _this.closest('.value');
        _p.children('select').val(_change).change();
        _this.addClass('active').siblings().removeClass('active');
        e.preventDefault();
    });
})(jQuery, window, document);