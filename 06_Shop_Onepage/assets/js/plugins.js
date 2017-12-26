
(function () {
    var method;
    var noop = function () {};
    var methods = [
        'assert', 'clear', 'count', 'debug', 'dir', 'dirxml', 'error',
        'exception', 'group', 'groupCollapsed', 'groupEnd', 'info', 'log',
        'markTimeline', 'profile', 'profileEnd', 'table', 'time', 'timeEnd',
        'timeline', 'timelineEnd', 'timeStamp', 'trace', 'warn'
    ];
    var length = methods.length;
    var console = (window.console = window.console || {});

    while (length--) {
        method = methods[length];

        // Only stub undefined methods.
        if (!console[method]) {
            console[method] = noop;
        }
    }
}());



jQuery(document).ready(function ($) {
    function animateElements() {
        $('.single-skill ').each(function () {
            var elementPos = $(this).offset().top;
            var topOfWindow = $(window).scrollTop();
            var animate = $(this).data('animate');
            if (elementPos < topOfWindow + $(window).height() - 30 && !animate) {
                $(this).data('animate', true);
                $(this).find('.skill').easyPieChart({
                    size: 200,
                    barColor: '#64BE43',
                    trackColor: '#dddddd',
                    scaleColor: '',
                    scaleLength: 5,
                    lineWidth: 5,
                    lineCap: 'square',
                    onStep: function (from, to, percent) {
                        $(this.el).find('span').text(Math.round(percent) + '%');
                    }
                }).stop();
            }
        });
    }
    animateElements();
    $(window).scroll(animateElements);

    /* Sticky Navbar jQuery
    =========================*/
    //function sticky_relocate() {
    //    var menu = $('.mainmenu-area'),
    //        window_top = $(window).scrollTop(),
    //        div_top = $('#sticky-helper').offset().top;
    //    if (window_top > div_top) {
    //        menu.addClass('sticky');
    //    } else {
    //        menu.removeClass('sticky');
    //    }
    //}
    //$(window).scroll(sticky_relocate);
    //sticky_relocate();
});
$(function () {
    /* ============================
    Smoth-Scroll-jQuery
    =============================*/
    $('.mainmenu-area a[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: target.offset().top
                }, 1000);
                return false;
            }
        }
    });
    /*=============================
    Search-box-jquery 
    =============================*/
    $('#search_toogle').on("click", function () {
        $('.search-box').fadeToggle(300);
    });
});


/*========================
Bootstrap Slider Animate
=========================*/
/* Demo Scripts for Bootstrap Carousel and Animate.css article
 * on SitePoint by Maria Antonietta Perna
 */
(function ($) {

    //Function to animate slider captions 
    function doAnimations(elems) {
        //Cache the animationend event in a variable
        var animEndEv = 'webkitAnimationEnd animationend';

        elems.each(function () {
            var $this = $(this),
                $animationType = $this.data('animation');
            $this.addClass($animationType).one(animEndEv, function () {
                $this.removeClass($animationType);
            });
        });
    }

    //Variables on page load 
    var $myCarousel = $('.carousel-example-generic'),
        $firstAnimatingElems = $myCarousel.find('.item:first').find("[data-animation ^= 'animated']");

    //Initialize carousel 
    $myCarousel.carousel();

    //Animate captions in first slide on page load 
    doAnimations($firstAnimatingElems);

    //Pause carousel  
    $myCarousel.carousel('pause');


    //Other slides to be animated on carousel slide event 
    $myCarousel.on('slide.bs.carousel', function (e) {
        var $animatingElems = $(e.relatedTarget).find("[data-animation ^= 'animated']");
        doAnimations($animatingElems);
    });

})(jQuery);