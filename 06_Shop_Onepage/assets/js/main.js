jQuery(document).on('ready', function ($) {
    "use strict";
    /* Scroll to top
    ===================*/
    $.scrollUp({
        scrollText: '<i class="fa fa-arrow-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });
    /* SCROLLSPY ACTIVE
    =======================*/
    $('body').scrollspy({
        target: '.bs-example-js-navbar-scrollspy',
        offset: 50
    });

    /* jQuery parallax
    =======================*/
   $('.header-bg').parallax("90%", -0.3);
     
    /* Mobile menu click then remove
    ===============================*/
    $(".mainmenu ul.nav.navbar-nav li a").on("click", function () {
        $(".mainmenu .navbar-collapse").removeClass("in");
    });

    $(".blog-slide").owlCarousel({
        items: 3,
        loop: true,
        autoplay: true,
        autoplayTimeout: 7000,
        smartSpeed: 1000,
        responsive: {
            // breakpoint from 0 up
            0: {
                items: 1,
            },
            // breakpoint from 480 up
            480: {
                items: 2,
            },
            // breakpoint from 768 up 
            768: {
                items: 3,
            }
        }
    });
    
    $('.portfolio-items').mixItUp();

    new WOW().init();
    
    var mySlider = $('.pogoSlider').pogoSlider({
        pauseOnHover: false,
        autoplay: true,
    }).data('plugin_pogoSlider');
}(jQuery));

/* Preloader Js
===================*/
//jQuery(window).on("load", function () {
//    $('.preeloader').fadeOut(500);
//
//});