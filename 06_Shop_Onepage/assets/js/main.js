jQuery(document).on('ready', function ($) {
    $.scrollUp({
        scrollText: '<i class="fa fa-arrow-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });
    $('body').scrollspy({
        target: '.bs-example-js-navbar-scrollspy',
        offset: 50
    });

   $('.header-bg').parallax("90%", -0.3);
    $(".mainmenu ul.nav.navbar-nav li a").on("click", function () {
        $(".mainmenu .navbar-collapse").removeClass("in");
    });

   
    
    $('.portfolio-items').mixItUp();

    new WOW().init();
    
    var mySlider = $('.pogoSlider').pogoSlider({
        pauseOnHover: false,
        autoplay: true,
    }).data('plugin_pogoSlider');
}(jQuery));
