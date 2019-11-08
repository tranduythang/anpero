(function (a) {
    if ( typeof define === "function" && define.amd ) {
        define([ "jquery" ], a);
    } else {
        a(jQuery);
    }
}(function (a) {
    a.fn.addBack = a.fn.addBack || a.fn.andSelf;
    a.fn.extend({
        actual: function (b, l) {
            if ( !this[ b ] ) {
                throw'$.actual => The jQuery method "' + b + '" you called does not exist';
            }
            var f = {absolute: false, clone: false, includeMargin: false, display: "block"};
            var i = a.extend(f, l);
            var e = this.eq(0);
            var h, j;
            if ( i.clone === true ) {
                h = function () {
                    var m = "position: absolute !important; top: -1000 !important; ";
                    e     = e.clone().attr("style", m).appendTo("body");
                };
                j = function () {
                    e.remove();
                };
            } else {
                var g = [];
                var d = "";
                var c;
                h     = function () {
                    c = e.parents().addBack().filter(":hidden");
                    d += "visibility: hidden !important; display: " + i.display + " !important; ";
                    if ( i.absolute === true ) {
                        d += "position: absolute !important; ";
                    }
                    c.each(function () {
                        var m = a(this);
                        var n = m.attr("style");
                        g.push(n);
                        m.attr("style", n ? n + ";" + d : d);
                    });
                };
                j     = function () {
                    c.each(function (m) {
                        var o = a(this);
                        var n = g[ m ];
                        if ( n === undefined ) {
                            o.removeAttr("style");
                        } else {
                            o.attr("style", n);
                        }
                    });
                };
            }
            h();
            var k = /(outer)/.test(b) ? e[ b ](i.includeMargin) : e[ b ]();
            j();
            return k;
        }
    });
}));
(function ($) {
    "use strict"; // Start of use strict
    
    /* ---------------------------------------------
     Resize mega menu
     --------------------------------------------- */
    
    function ovic_menuadd_string_prefix(str, prefix) {
        return prefix + str;
    }
    
    function ovic_uid(prefix) {
        return (prefix || '') + Math.random().toString(36).substr(2, 9);
    }
    
    function responsive_megamenu_item(container, element) {
        if ( container !== 'undefined' ) {
            var left             = 0,
                container_width  = 0,
                container_offset = container.offset();
            
            if ( typeof container_offset != 'undefined' ) {
                container_width = container.innerWidth();
                setTimeout(function () {
                    element.children('.megamenu').css({
                        'max-width': container_width + 'px'
                    });
                    var sub_menu_width = element.children('.megamenu').outerWidth(),
                        item_width     = element.outerWidth();
                    element.children('.megamenu').css({
                        'left': '-' + (sub_menu_width / 2 - item_width / 2) + 'px'
                    });
                    var container_left  = container_offset.left,
                        container_right = (container_left + container_width),
                        item_left       = element.offset().left,
                        overflow_left   = (sub_menu_width / 2 > (item_left - container_left)),
                        overflow_right  = ((sub_menu_width / 2 + item_left) > container_right);
                    
                    if ( overflow_left ) {
                        left = (item_left - container_left);
                        element.children('.megamenu').css({
                            'left': -left + 'px'
                        });
                    }
                    if ( overflow_right && !overflow_left ) {
                        left = (item_left - container_left);
                        left = left - (container_width - sub_menu_width);
                        element.children('.megamenu').css({
                            'left': -left + 'px'
                        });
                    }
                }, 100);
            }
        }
    }
    
    $.fn.ovic_resize_megamenu = function () {
        var megamenu = $(this);
        megamenu.on('ovic_resize_megamenu', function () {
            var window_size = jQuery('body').innerWidth();
            window_size += ovic_get_scrollbar_width();
            if ( $(this).length > 0 && window_size > 991 ) {
                $(this).each(function () {
                    var _class_responsive = $(this).children('.megamenu').data('responsive'),
                        _container        = $(this).closest('.ovic-menu-wapper');
                    
                    if ( _class_responsive !== '' )
                        _container = $(this).closest(_class_responsive);
                    
                    responsive_megamenu_item(_container, $(this));
                });
            }
        }).trigger('ovic_resize_megamenu');
        $(window).on('resize', function () {
            megamenu.trigger('ovic_resize_megamenu');
        });
    };
    
    /**==============================
     Auto width Vertical menu
     ===============================**/
    $.fn.ovic_vertical_megamenu = function () {
        var vertical_menu = $(this);
        vertical_menu.on('ovic_vertical_megamenu', function () {
            $(this).each(function () {
                var menu        = $(this),
                    menu_offset = menu.offset().left > 0 ? menu.offset().left : 0,
                    menu_width  = parseInt(menu.actual('width')),
                    menu_left   = menu_offset + menu_width;
                
                menu.find('.megamenu').each(function () {
                    var megamenu          = $(this),
                        class_responsive  = megamenu.data('responsive'),
                        element_caculator = megamenu.closest('.container');
                    
                    if ( class_responsive !== '' ) {
                        element_caculator = megamenu.closest(class_responsive);
                    }
                    
                    if ( element_caculator.length > 0 ) {
                        var container_width  = parseInt(element_caculator.innerWidth()) - 30,
                            container_offset = element_caculator.offset(),
                            container_left   = container_offset.left + container_width,
                            width            = (container_width - menu_width);
                        
                        if ( menu_offset > container_left || menu_left < container_offset.left )
                            width = container_width;
                        if ( menu_left > container_left )
                            width = container_width - (menu_width - (menu_left - container_left)) - 30;
                        
                        if ( width > 0 ) {
                            $(this).css('max-width', width + 'px');
                        }
                    }
                });
            });
        }).trigger('ovic_vertical_megamenu');
        $(window).on('resize', function () {
            vertical_menu.trigger('ovic_vertical_megamenu');
        });
    };
    
    function ovic_get_scrollbar_width() {
        var $inner = jQuery('<div style="width: 100%; height:200px;">test</div>'),
            $outer = jQuery('<div style="width:200px;height:150px; position: absolute; top: 0; left: 0; visibility: hidden; overflow:hidden;"></div>').append($inner),
            inner  = $inner[ 0 ],
            outer  = $outer[ 0 ];
        jQuery('body').append(outer);
        var width1 = inner.offsetWidth;
        $outer.css('overflow', 'scroll');
        var width2 = outer.clientWidth;
        $outer.remove();
        return (width1 - width2);
    }
    
    /* ---------------------------------------------
     MOBILE MENU
     --------------------------------------------- */
    $.fn.ovic_menuclone_all_menus = function () {
        var _this = $(this);
        _this.on('ovic_menuclone_all_menus', function () {
            if ( !$('.ovic-menu-clone-wrap').length && $('.ovic-clone-mobile-menu').length > 0 ) {
                $('body').prepend('<div class="ovic-menu-clone-wrap">' +
                    '<div class="ovic-menu-panels-actions-wrap">' +
                    '<span class="ovic-menu-current-panel-title">' + ovic_megamenu_frontend.title + '</span>' +
                    '<a class="ovic-menu-close-btn ovic-menu-close-panels" href="#">x</a></div>' +
                    '<div class="ovic-menu-panels"></div>' +
                    '</div>');
            }
            var i                = 0,
                panels_html_args = Array();
            if ( !$('.ovic-menu-clone-wrap .ovic-menu-panels #ovic-menu-panel-main').length ) {
                $('.ovic-menu-clone-wrap .ovic-menu-panels').append('<div id="ovic-menu-panel-main" class="ovic-menu-panel ovic-menu-panel-main"><ul class="depth-01"></ul></div>');
            }
            $(this).each(function () {
                var $this              = $(this),
                    thisMenu           = $this,
                    this_menu_id       = thisMenu.attr('id'),
                    this_menu_clone_id = ovic_uid('ovic-menu-clone-');
                
                if ( !$('#' + this_menu_clone_id).length ) {
                    var thisClone = $this.clone(true); // Clone Wrap
                    thisClone.find('.menu-item').addClass('clone-menu-item');
                    
                    thisClone.find('[id]').each(function () {
                        // Change all tab links with href = this id
                        thisClone.find('.vc_tta-panel-heading a[href="#' + $(this).attr('id') + '"]').attr('href', '#' + ovic_menuadd_string_prefix($(this).attr('id'), 'ovic-menu-clone-'));
                        thisClone.find('.ovic-menu-tabs .tabs-link a[href="#' + $(this).attr('id') + '"]').attr('href', '#' + ovic_menuadd_string_prefix($(this).attr('id'), 'ovic-menu-clone-'));
                        $(this).attr('id', ovic_menuadd_string_prefix($(this).attr('id'), 'ovic-menu-clone-'));
                    });
                    
                    thisClone.find('.ovic-menu-menu').addClass('ovic-menu-menu-clone');
                    
                    // Create main panel if not exists
                    
                    var thisMainPanel = $('.ovic-menu-clone-wrap .ovic-menu-panels #ovic-menu-panel-main ul');
                    thisMainPanel.append(thisClone.html());
                    
                    ovic_menu_insert_children_panels_html_by_elem(thisMainPanel, i);
                }
            });
        }).trigger('ovic_menuclone_all_menus');
    }
    
    // i: For next nav target
    function ovic_menu_insert_children_panels_html_by_elem($elem, i) {
        if ( $elem.find('.menu-item-has-children').length ) {
            $elem.find('.menu-item-has-children').each(function () {
                var thisChildItem = $(this);
                ovic_menu_insert_children_panels_html_by_elem(thisChildItem, i);
                var next_nav_target = 'ovic-menu-panel-' + i;
                
                // Make sure there is no duplicate panel id
                while ( $('#' + next_nav_target).length ) {
                    i++;
                    next_nav_target = 'ovic-menu-panel-' + i;
                }
                // Insert Next Nav
                thisChildItem.prepend('<a class="ovic-menu-next-panel" href="#' + next_nav_target + '" data-target="#' + next_nav_target + '"></a>');
                
                // Get sub menu html
                var sub_menu_html = $('<div>').append(thisChildItem.find('> .sub-menu').clone()).html();
                thisChildItem.find('> .sub-menu').remove();
                
                $('.ovic-menu-clone-wrap .ovic-menu-panels').append('<div id="' + next_nav_target + '" class="ovic-menu-panel ovic-menu-sub-panel ovic-menu-hidden">' + sub_menu_html + '</div>');
            });
        }
    }
    
    // BOX MOBILE MENU
    $(document).on('click', '.menu-toggle', function (e) {
        $('.ovic-menu-clone-wrap').addClass('open');
        e.preventDefault();
    });
    // Close box menu
    $(document).on('click', '.ovic-menu-clone-wrap .ovic-menu-close-panels', function (e) {
        $('.ovic-menu-clone-wrap').removeClass('open');
        e.preventDefault();
    });
    $(document).on('click', function (event) {
        if ( $('body').hasClass('rtl') ) {
            if ( event.offsetX < 0 )
                $('.ovic-menu-clone-wrap').removeClass('open');
        } else {
            if ( event.offsetX > $('.ovic-menu-clone-wrap').width() )
                $('.ovic-menu-clone-wrap').removeClass('open');
        }
    });
    
    // Open next panel
    $(document).on('click', '.ovic-menu-next-panel', function (e) {
        var thisButton   = $(this),
            targetID     = thisButton.attr('href'),
            thisItem     = thisButton.closest('.menu-item'),
            thisPanel    = thisButton.closest('.ovic-menu-panel'),
            thisMenu     = thisButton.closest('.ovic-menu-clone-wrap'),
            currentTitle = thisMenu.find('.ovic-menu-current-panel-title'),
            actionsWrap  = thisMenu.find('.ovic-menu-panels-actions-wrap'),
            targetElem   = thisMenu.find(targetID);
        
        if ( targetElem.length ) {
            
            // Insert current panel title
            var itemTitle      = thisItem.children('.menu-link').html(),
                prevPanel      = $('<a class="ovic-menu-prev-panel"></a>'),
                firstItemTitle = '';
            
            thisPanel.addClass('ovic-menu-sub-opened');
            targetElem
                .removeClass('ovic-menu-hidden')
                .addClass('ovic-menu-panel-opened')
                .attr('data-parent-title', itemTitle)
                .attr('data-parent-panel', thisPanel.attr('id'));
            
            if ( currentTitle.length > 0 ) {
                firstItemTitle = currentTitle.clone();
            }
            
            if ( typeof itemTitle != 'undefined' && typeof itemTitle !== false ) {
                if ( !currentTitle.length ) {
                    actionsWrap.prepend('<span class="ovic-menu-current-panel-title"></span>');
                }
                currentTitle.html(itemTitle);
            } else {
                currentTitle.remove();
            }
            
            // Back to previous panel
            prevPanel.attr('data-current-panel', targetID);
            prevPanel.attr('href', '#' + thisPanel.attr('id'));
            actionsWrap.find('.ovic-menu-prev-panel').remove();
            actionsWrap.prepend(prevPanel);
        }
        
        e.preventDefault();
    });
    
    // Go to previous panel
    $(document).on('click', '.ovic-menu-prev-panel', function (e) {
        var thisButton   = $(this),
            thisMenu     = thisButton.closest('.ovic-menu-clone-wrap'),
            currentPanel = thisButton.attr('data-current-panel'),
            targetID     = thisButton.attr('href'),
            actionsWrap  = thisMenu.find('.ovic-menu-panels-actions-wrap'),
            currentTitle = thisMenu.find('.ovic-menu-current-panel-title'),
            targetElem   = thisMenu.find(targetID),
            mainTitle    = currentTitle.attr('data-main-title');
        
        thisMenu.find(currentPanel).removeClass('ovic-menu-panel-opened').addClass('ovic-menu-hidden');
        targetElem.addClass('ovic-menu-panel-opened').removeClass('ovic-menu-sub-opened');
        
        // Set new back button
        var itemTitle   = targetElem.attr('data-parent-title'),
            parentPanel = targetElem.attr('data-parent-panel');
        
        if ( typeof parentPanel == 'undefined' || typeof parentPanel === false ) {
            thisButton.remove();
            currentTitle.html(mainTitle);
        } else {
            thisButton.attr('href', '#' + parentPanel)
                .attr('data-current-panel', targetID);
            
            // Insert new panel title
            if ( typeof itemTitle != 'undefined' && typeof itemTitle !== false ) {
                if ( !currentTitle.length ) {
                    actionsWrap.prepend('<span class="ovic-menu-current-panel-title"></span>');
                }
                currentTitle.html(itemTitle);
            } else {
                currentTitle.remove();
            }
        }
        
        e.preventDefault();
    });
    
    // Menu item next panel
    $(document).on('click', '.ovic-menu-clone-wrap .menu-item.disable-link > .menu-link', function (e) {
        $(this).prev('.ovic-menu-next-panel').trigger('click');
        e.preventDefault();
    });
    
    // Open vartical menu
    $(document).on('click', '.block-title', function () {
        $(this).closest('.vertical-wrapper').find('.ovic-menu-wapper.vertical').ovic_auto_width_vertical_menu();
    });
    /* ---------------------------------------------
     Scripts load
     --------------------------------------------- */
    $(document).on('ready', function () {
        var horizontal = $('.ovic-menu-wapper.horizontal'),
            vertical   = $('.ovic-menu-wapper.vertical');
        
        if ( $('.ovic-clone-mobile-menu').length ) {
            $('.ovic-clone-mobile-menu').ovic_menuclone_all_menus();
        }
        
        if ( horizontal.length ) {
            horizontal.each(function () {
                if ( $(this).find('.item-megamenu').length ) {
                    $(this).find('.item-megamenu').ovic_resize_megamenu();
                }
            });
        }
        
        if ( vertical.length ) {
            vertical.ovic_vertical_megamenu();
        }
    });
    
})(jQuery); // End of use strict