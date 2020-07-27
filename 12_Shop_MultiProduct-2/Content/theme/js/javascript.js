function updateCatg() {
    var windowWidth = $(window).width();
    var courseHeight = $('.box-course-search .main-course .course').height();

    if (windowWidth > 813) {
        $('header .nav-navbar .li-child').click(function () {
            $(this).toggleClass('open-nav');
            $(this).find('.level-2').addClass('open-nav');
        });
        $('header .nav-navbar .level-2 .li-child').click(function () {
            $(this).find('.level-3').toggleClass('open-nav');
        });
    } else if (windowWidth < 812) {
        $("a.m-nav").click(function (event) {
            event.preventDefault();
        });
        $('header .nav-navbar .li-child').click(function () {
            $(this).toggleClass('open-nav');
            //$(this).find('.level-2').toggleClass('open-nav');
        });
        $('header .nav-navbar .level-2 .li-child').click(function () {
            $(this).find('.level-3').toggleClass('open-nav');
        });
        //$('header .nav-navbar .main-child').removeAttr("style");
    }
}


$(document).ready(function () {
    updateCatg();
    $('.toggle-filter').click(function () {
        $('body').addClass('open-filter');
        $('.overlay-filter').show();
    });

    $('.overlay-filter').click(function () {
        $('body').removeClass('open-filter');
    });

    $('.box-item-product .box-title .open-menu').click(function () {
        $(this).parent().toggleClass('open');
    });

    $('body').click(function () {
        $('header .nav-navbar .li-child, .main-child').removeClass('open-nav');
    });

    $('header .nav-navbar .li-child, .main-child').click(function (event) {
        event.stopPropagation();
    });

    $('header .toggle-menu').click(function () {
        $('body').addClass('open-nav-mobile');
    });

    $('.overlayMenu, header .close-nav').click(function () {
        $('body').removeClass('open-nav-mobile');
    });

    $('.close-hotline').click(function () {
        $('.box-hotline').hide();
    });



    jQuery(window).resize(function () {
        updateCatg();
    });

    $('.owl-carousel-6').owlCarousel({
        itemsCustom: [
            [320, 1],
            [480, 2],
            [768, 4],
            [1024, 5],
            [1200, 6]
        ],
        navigation: true
        //autoPlay: true
    });

    $('.owl-carousel-5').owlCarousel({
        itemsCustom: [
            [320, 1],
            [600, 2],
            [768, 3],
            [1024, 4],
            [1200, 5]
        ],
        navigation: true
        //autoPlay: true
    });

    $('.owl-carousel-4').owlCarousel({
        itemsCustom: [
            [320, 1],
            [480, 2],
            [768, 3],
            [1024, 4],
            [1200, 4]
        ],
        navigation: true
        //autoPlay: true
    });

    $('.owl-carousel-3').owlCarousel({
        itemsCustom: [
            [320, 1],
            [600, 2],
            [768, 2],
            [1024, 3],
            [1200, 3]
        ],
        navigation: true
        //autoPlay: true
    });

    $(window).scroll(function () {
        $(window).scrollTop() > 300 ? $(".item-fix").addClass("trans") : $(".item-fix").removeClass("trans");
    });

    $('.box-back-top').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    });

    //$('.datetimepicker').datetimepicker();

    $('.header-languages .current-languages').click(function () {
        $(this).toggleClass('show');
        $('.header-languages .list-languages').toggleClass('show');
    })
});

// Remove dropdown when click outside target
window.onclick = function (e) {
    if (!e.target.matches('.header-languages .current-languages')) {
        var dropdownNotifications = $('.header-languages .list-languages');
        if (dropdownNotifications.hasClass('show'));
        dropdownNotifications.removeClass('show');
    }
}


