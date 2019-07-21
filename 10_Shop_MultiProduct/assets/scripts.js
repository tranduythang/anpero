(function() {
  var __sections__ = {};
  (function() {
    for(var i = 0, s = document.getElementById('sections-script').getAttribute('data-sections').split(','); i < s.length; i++)
      __sections__[s[i]] = true;
  })();
  (function() {
  if (!__sections__["footer"]) return;
  try {
    
jQuery(document).ready(function($) { 

	// NEWSLETTER FORM
	$('.footer_newsletter_form').each(function (){      
		$(this).on('submit', function(e){
			var formCookie = $(this).attr('class');
			$.cookie('footerformSended', formCookie);
		});
	});
	
	if( document.location.href.indexOf('?customer_posted=true') > 0 && $.cookie('footerformSended') == 'footer_newsletter_form') {
		$('.footer_newsletter_form .form_wrapper').hide();
		$('.footer_newsletter_form .form_text').hide();
		$('.footer_newsletter_form .alert-success').show();
	}

	$('.footer_newsletter_form').formValidation();


});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["header"]) return;
  try {
    
(function($) {

	// MEGAMENU /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	var mobFlag = 0;
	megamenuToggle = function() {
		if ( $(window).width() > 991 ) {
			$('#megamenu').removeClass('megamenu_mobile').addClass('megamenu_desktop');

			$('#megamenu_level__1').superfish();

			$('#megamenu .level_1, #megamenu .level_2, #megamenu .level_3').removeAttr('style');

			$('#megamenu_mobile_toggle, .megamenu_trigger').off('.mobileMenu').removeClass('off active');

			$('#megamenu_level__1, #megamenu_mobile_close').removeClass('on');

			$('html, body').css('overflow', 'auto');

			mobFlag = 0;
			
			turnMenuDropdownSide();
		}
		else {
			$('#megamenu_level__1, #megamenu_mobile_close').hide();
			$('#megamenu').removeClass('megamenu_desktop').addClass('megamenu_mobile');

			$('#megamenu_level__1').superfish('destroy');

			if ( mobFlag == 0 ) {
				menuMobile();
				mobFlag = 1;
			};
		};
	};

	menuMobile = function() {
		$('#megamenu_mobile_toggle').on('click.mobileMenu', function(){
			$('#megamenu_level__1, #megamenu_mobile_close').show().addClass('on');

			$('html, body').css({'overflow': 'hidden', 'position':'fixed', 'top': '0', 'left': '0', 'right': '0'});

		});

		$('#megamenu_mobile_close').on('click', function() {
			$('#megamenu_level__1, #megamenu_mobile_close').removeClass('on');

			$('html, body').css({'overflow': 'auto', 'position':'static'});

		});

		$('.megamenu_trigger').on('click.mobileMenu', function() {
			var targetMenu = '#' + $(this).data('submenu');

			$(targetMenu).slideToggle(300);

			$(this).toggleClass('active');

			return false;
		});

	};


	// WATCH MENU DROP SIDE
	turnMenuDropdownSide = function() {
		$('#megamenu .level_2__small').each(function(i){
			if ( ($(this).offset().left + 470) > $(window).width() ){
				$(this).find('.droped_linklist').addClass('left_side');
			}
		});
	};



	// STICKY MENU v.1 //////////////////////////////////////////////////////////////////////////////////////////////////////////
	stickyHeader = function() {

		var target = $('#page_header');
		var pseudo = $('#pseudo_sticky_block');
		var stick_class = 'megamenu_stuck';

		$(window).on('load scroll resize', function() {

			if ( $(window).width() > 991 ) {
				var scrolledValue = parseInt( $(window).scrollTop() );
				var offsetValue = parseInt( pseudo.offset().top );
				var headHeight = target.outerHeight();

				if ( scrolledValue > offsetValue ) {
					target.addClass( stick_class );
					pseudo.css({ 'height' : headHeight - 40 });
				}
				else {
					target.removeClass( stick_class );
					pseudo.css({ 'height' : 0 });
				};
			}
			else {
				target.removeClass( stick_class );
				pseudo.css({ 'height' : 0 });
			};

		});

		$(window).on('load', function() {
			setTimeout( 
				function(){ $(window).trigger('scroll') }
			, 180 );
		});

	};

	stickyHeader();

    $(document).ready(function () {
        megamenuToggle();
    });
	$(window).on('resize', function() {
        megamenuToggle();
	});


	$(document).on('shopify:section:load', '#shopify-section-header', function() {
		stickyHeader();
		megamenuToggle();
	});



	// SEARCH TOGGLE  //////////////////////////////////////////////////////////////////////
	var headerSearchForm = $('header .search_form');

	$('.search_toggle').on('click', function(e){
		if ( headerSearchForm.hasClass('open') ){
			headerSearchForm.removeClass('open').hide(400);
			$(this).removeClass('open');
		} else {
			headerSearchForm.addClass('open').show(400);
			$(this).addClass('open');
		}
	});

	$(document).mouseup(function (e) {
		if ( $('.header_search').has(e.target).length === 0 ){
			if ( headerSearchForm.hasClass('open') ) {
				headerSearchForm.removeClass('open').fadeOut(400);
				$('.search_toggle').removeClass('open');
				$('#search_result_container').removeClass('active').html('');
			};
		};
	});
	

	// AJAX SEARCH  //////////////////////////////////////////////////////////////////////////
	if( theme.searchAjaxOn ){
		var container = $('#search_result_container');
		var url = '/search?q=';


		$('.header_search input[type=search]').on('keyup', function(e){
			var inputVal = $(this).val();

			if( inputVal.length > 2 ){
				container.addClass('active');
				container.load(url + inputVal + ' #hidden_search_result> *', function(){
					var list = container.find('ul');
					if ( parseInt( list.data('count_result') ) > 10 ){
						list.append('<li class="centred"><a href="' + url + inputVal + '">' + list.data('caption') + ': ' + list.data('count_result') + '</a></li>');
					}
				});
			}
		});
	};




})(jQuery);

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-banners-countdown-custom"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	$('.countdown_timer').each(function(i) {

		var timerId = '#' + $(this).attr('id');
		var countdownDay = $(this).data('day');
		var countdownMonth = $(this).data('month');
		var countdownYear = $(this).data('year');
		
		$( timerId ).ccountdown(countdownYear, countdownMonth, countdownDay,'00:00'); 
		
	});

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-banners"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	$('.countdown_timer').each(function(i) {

		var timerId = '#' + $(this).attr('id');
		var countdownDay = $(this).data('day');
		var countdownMonth = $(this).data('month');
		var countdownYear = $(this).data('year');
		
		$( timerId ).ccountdown(countdownYear, countdownMonth, countdownDay,'00:00'); 
		
	});

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-collections-with-menu"] && !window.DesignMode) return;
  try {
    
(function($) {
	// MOBILE MENU SHOW/HIDE
	$(window).on('load', function() {
		$('.linklist_menu_item').each(function(i) {
			var item = $(this);
			var trigger = item.find('.menu_trigger');
			var menu = item.find('ul');

			var windowSizeWatch = function(){
				if ( $(window).width() < 992 ) {
					menu.hide(0);
				} else {
					menu.show(0);
				}
			};
			
			windowSizeWatch();
			
			$(window).on('resize', windowSizeWatch);

			trigger.on('click', function(e){
				if ( item.hasClass('open') ) {
					item.removeClass('open');
					menu.hide(500);
				} else {
					item.addClass('open');
					menu.show(500);
				};
			});
		});
	});

})(jQuery);

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-communication"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) { 

	// BLOG POST CAROUSEL
	$('.blog_posts_carousel').each(function(i) {

		var swiperId = '#' + $(this).attr('id');
		var swiperVar = $(this).attr('id');
		var swiperPrev = '#blog_carousel_prev_' + swiperVar.replace('blog_carousel_', '');
		var swiperNext = '#blog_carousel_next_' + swiperVar.replace('blog_carousel_', '');
		

		var swiperVar = new Swiper( swiperId, {
			effect: 'slide',
			loop: true,

			prevButton: swiperPrev,
			nextButton: swiperNext,

		});

		$(window).on('load', function() {
			swiperVar.onResize(); // updating swiper after loading
		});

	});



	// NEWSLETTER FORM
	$('.newsletter_form').each(function (){      
		$(this).on('submit', function(e){
			var formCookie = $(this).attr('class');
			$.cookie('formSended', formCookie);
		});
	});
	
	if( document.location.href.indexOf('?customer_posted=true') > 0 && $.cookie('formSended') == 'newsletter_form') {
		$('.section_communication .newsletter_form .form_wrapper').hide();
		$('.section_communication .newsletter_form .form_text').hide();
		$('.section_communication .newsletter_form .alert-success').show();
	}

	$('.newsletter_form').formValidation();




});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-image-with-text-overlay"] && !window.DesignMode) return;
  try {
    
jQuery(function($){

	morkoParallax = function() {
		$('.parallax_block').each(function() {
			var parallaxBlock = $(this);
			var parallaxLayer = $(this).find('.parallax_layer');
			var parallaxLayer_2 = $(this).find('.parallax_layer_2');

			$(window).on('load scroll', function() {
				var parallaxHeight = parseInt( parallaxBlock.outerHeight() );
				var parallaxImgHeight = parseInt( parallaxLayer.outerHeight() );
				var parallaxImgHeight_2 = parseInt( parallaxLayer_2.outerHeight() );

				var parallaxOffset1 = parseInt( parallaxBlock.offset().top );
				var parallaxOffset2 = parseInt( parallaxOffset1 + parallaxHeight );

				var translateMax = parseInt( parallaxImgHeight - parallaxHeight ) - 2; // minus 2 to prevent floated numbers and borders between sections
				var translateMax_2 = parseInt( parallaxImgHeight_2 - parallaxHeight ) - 2; 

				var scrollTemp = $(window).scrollTop() + window.innerHeight;

				if ( ( scrollTemp >= parallaxOffset1 ) && ( $(window).scrollTop() <= parallaxOffset2 ) ) {
					// var translateKoff = parallaxHeight/parallaxImgHeight;

					// if ( translateKoff > 0.2 ) {
					// 	var translateVal = parseInt( ( scrollTemp - parallaxOffset1 ) * 0.2 );
					// }
					// else {
					// 	var translateVal = parseInt( ( scrollTemp - parallaxOffset1 ) * translateKoff );
					// };

					var translateVal = parseInt( ( scrollTemp - parallaxOffset1 ) * 0.3 );
					var translateVal_2 = parseInt( ( scrollTemp - parallaxOffset1 ) * 0.1 );

					if ( translateVal <= translateMax ) {
						parallaxLayer.css({ 'transform' : 'translate3d(0, -' + translateVal + 'px, 0)' });
                        parallaxLayer_2.css({ 'transform' : 'translate3d(0, -' + translateVal_2 + 'px, 0)' });
					}
					else if ( translateVal > translateMax ) {
						parallaxLayer.css({ 'transform' : 'translate3d(0, -' + translateMax + 'px, 0)' });
						
					};

				};

			});

		});

	};


	morkoParallax();


	$(document).on('shopify:section:load shopify:section:unload', '.section_image-with-text-overlay', function() {
		morkoParallax();
	});



	

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-instagram"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	
		

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-logo-list"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	$('.logo_swiper').each(function(i) {

		var sliderId = '#' + $(this).attr('id');
		var sliderVar = $(this).attr('id');
		
		var sliderPrev = '#swiper_prev_' + sliderVar.replace('logo_swiper__', '');
		var sliderNext = '#swiper_next_' + sliderVar.replace('logo_swiper__', '');
		
		var swiperVar = new Swiper( sliderId, {
			effect: 'slide',
			loop: true,
			prevButton: sliderPrev,
			nextButton: sliderNext,
			slidesPerView: 6,
			breakpoints: {
				1199: {
					slidesPerView: 5
				},
				992: {
					slidesPerView: 4
				},
				768: {
					slidesPerView: 3
				},
				480: {
					slidesPerView: 2
				}
			},

		});

		$(window).on('load', function() {
			swiperVar.onResize(); // updating swiper after loading
		});

	});

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-lookbook"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	$(window).on('load resize', function() {
		
		if ( $(window).width() < 991 ) {
			$('.lookbook_item__bullet').each(function(i) {
				var self = $(this);
				var productLink = self.attr('href');
				var prodCaption = self.siblings('.lookbook_item__caption');
					
				self.on('click', function(e){
					e.preventDefault();
					prodCaption.show(300);
				});

				prodCaption.on('click', function(e){
					document.location.href = productLink;
				});
			});
		};


	});

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-map"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	$.getScript('//maps.googleapis.com/maps/api/js?key=' + theme.mapKey).then(function() {

		$('.section_map').each(function(i) {

			var mapId = $(this).data('section');
			var mapBlock = 'map_' + mapId;

			var mapAddress = $(this).data('map-address');
			var mapMarker = $(this).data('map-marker');
			var mapStyle = $(this).data('map-style');

			var mapLoad = function(mapAddress, mapMarker, mapStyle) {

				var latlng = new google.maps.LatLng(0, 0);

				var mapOptions = {
					center: latlng,
					zoom: 15,
					mapTypeId: google.maps.MapTypeId.ROADMAP,
					panControl: true,
					zoomControl: false,
					mapTypeControl: false,
					scaleControl: false,
					scrollwheel: false,
					streetViewControl: false,
					rotateControl: false
				};

				var map = new google.maps.Map(document.getElementById( mapBlock ), mapOptions);

				var geocoder = new google.maps.Geocoder();

				geocoder.geocode( { 'address': mapAddress }, function(results, status) {
					if ( status == google.maps.GeocoderStatus.OK ) {
						map.setCenter( results[0].geometry.location );

						var mapIcon = {
							path:'M213.285,0h-0.608C139.114,0,79.268,59.826,79.268,133.361c0,48.202,21.952,111.817,65.246,189.081 c32.098,57.281,64.646,101.152,64.972,101.588c0.906,1.217,2.334,1.934,3.847,1.934c0.043,0,0.087,0,0.13-0.002 c1.561-0.043,3.002-0.842,3.868-2.143c0.321-0.486,32.637-49.287,64.517-108.976c43.03-80.563,64.848-141.624,64.848-181.482 C346.693,59.825,286.846,0,213.285,0z M274.865,136.62c0,34.124-27.761,61.884-61.885,61.884 c-34.123,0-61.884-27.761-61.884-61.884s27.761-61.884,61.884-61.884C247.104,74.736,274.865,102.497,274.865,136.62z',
							fillColor: mapMarker,
							fillOpacity: 0.9,
							scale: 0.13,
							strokeColor:'#BABBBB',
							strokeWeight: 1
						};

						var marker = new google.maps.Marker({
							position: results[0].geometry.location,
							icon: mapIcon,
							map: map,
							title: mapAddress
						});

					}
					else {
						alert("Geocode was not successful for the following reason: " + status);
					};

				});

				// MAP STYLES
				map.setOptions({ styles: mapStyle });

				// MAP RESPONSIVE RESIZE
				google.maps.event.addDomListener(window, 'resize', function() {
					var center = map.getCenter();
					google.maps.event.trigger(map, "resize");
					map.setCenter(center); 

				});

			};


			// LOADING MAPS
			mapLoadTrigger = true;

			$(document).on('shopify:section:load', '#shopify-section-' + mapId, function() {

				var mapInstance = $(this).find('.section_map');

				var mapAddress = mapInstance.data('map-address');
				var mapMarker = mapInstance.data('map-marker');
				var mapStyle = mapInstance.data('map-style');

				mapLoad(mapAddress, mapMarker, mapStyle);
				mapLoadTrigger = false;

			});

			if ( mapLoadTrigger = true ) {
				mapLoad(mapAddress, mapMarker, mapStyle);
			};

		});

	});
});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-newsletter"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	

	// CHECK FORM POSTED
	$('.contact-form').each(function (){      
		$(this).on('submit', function(e){
			var formCookie = $(this).attr('class');
			$.cookie('formSended', formCookie);
		});
	});
	
	if( document.location.href.indexOf('?customer_posted=true') > 0 && $.cookie('formSended') == 'contact-form') {
		$('#newsletter_form .form_wrapper').hide();
		$('#newsletter_form .form_text').hide();
		$('#newsletter_form .alert-success').show();
	};

	// FORM VALIDATION
	$(document).ready(function() {
		$('#newsletter_form').formValidation();
	});

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-product-countdown"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	$('.countdown_timer').each(function(i) {

		var timerId = '#' + $(this).attr('id');
		var countdownDay = $(this).data('day');
		var countdownMonth = $(this).data('month');
		var countdownYear = $(this).data('year');
		
		$( timerId ).ccountdown(countdownYear, countdownMonth, countdownDay,'00:00'); 
		
	});

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-products-carousel"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	$('.products_carousel').each(function(i) {

		var sliderId = '#' + $(this).attr('id');
		var sliderVar = $(this).attr('id');
		var sliderPrev = '#carousel_swiper__prev_' + sliderVar.replace('products_carousel_', '');
		var sliderNext = '#carousel_swiper__next_' + sliderVar.replace('products_carousel_', '');
		var productsQ = $(this).data('products');
		var sliderRows = $(this).data('rows');
		var sliderDir = $(this).data('dir');

		if ( productsQ > 4 && sliderRows == 1 ) {
			var carouselVar = new Swiper( sliderId, {
				effect: 'slide',
				slidesPerView: 4,
				spaceBetween: 30,
				loop: true,
				speed: 500,
				autoplayDisableOnInteraction: false,

				breakpoints: {
					992: {
						slidesPerView: 3
					},
					768: {
						slidesPerView: 2
					},
					479: {
						slidesPerView: 1
					}
				},

				prevButton: sliderPrev,
				nextButton: sliderNext,

			});
			
			$(window).on('load', function() {
				carouselVar.onResize(); // updating swiper after loading
			});
		};
		


		if ( productsQ > 8 && sliderRows == 2 ) {

			var slider1 = sliderId + ' .swiper_1';
			var slider2 = sliderId + ' .swiper_2';
			var slider1_prev = sliderId + ' .swiper_1 .carousel_1_prev';
			var slider1_next = sliderId + ' .swiper_2 .carousel_1_next';
			var slider2_prev = sliderId + ' .swiper_1 .carousel_2_prev';
			var slider2_next = sliderId + ' .swiper_2 .carousel_2_next';

			var carousel_1 = new Swiper( slider1, {
				effect: 'slide',
				slidesPerView: 4,
				spaceBetween: 30,
				loop: true,
				speed: 500,
				autoplayDisableOnInteraction: false,

				breakpoints: {
					992: {
						slidesPerView: 3
					},
					768: {
						slidesPerView: 2
					},
					479: {
						slidesPerView: 1
					}
				},

				prevButton: slider1_prev,
				nextButton: slider1_next,

			});


			var carousel_2 = new Swiper( slider2, {
				effect: 'slide',
				slidesPerView: 4,
				spaceBetween: 30,
				loop: true,
				speed: 500,
				autoplayDisableOnInteraction: false,

				breakpoints: {
					992: {
						slidesPerView: 3
					},
					768: {
						slidesPerView: 2
					},
					479: {
						slidesPerView: 1
					}
				},

				prevButton: slider2_prev,
				nextButton: slider2_next,

			});

			if (sliderDir == 1) {
				$(sliderPrev).on('click', function() {
					carousel_1.slidePrev();
					carousel_2.slidePrev();
				});
				$(sliderNext).on('click', function() {
					carousel_1.slideNext();
					carousel_2.slideNext();
				});
			} else {
				$(sliderPrev).on('click', function() {
					carousel_1.slidePrev();
					carousel_2.slideNext();
				});
				$(sliderNext).on('click', function() {
					carousel_1.slideNext();
					carousel_2.slidePrev();
				});
			};
			
			$(window).on('load', function() {
				carousel_1.onResize(); // updating swiper after loading
				carousel_2.onResize(); 
			});

		};



	});

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-products-column"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {

	// TIMER INIT
	$('.countdown_timer').each(function(i) {

		var timerId = '#' + $(this).attr('id');
		var countdownDay = $(this).data('day');
		var countdownMonth = $(this).data('month');
		var countdownYear = $(this).data('year');
		
		$( timerId ).ccountdown(countdownYear, countdownMonth, countdownDay,'00:00'); 
		
	});

	
	// COLUMN TABS
	$('.section_products-column').each(function(i) {
		var firstEl = $(this).find('.item_collection').first();
		var firstTrigger = firstEl.find('.column_trigger');
		var prodLists = $(this).find('.products_list');
		var tabItem = $(this);

		if ( $(window).width() < 768 ) {
			prodLists.hide();
			firstEl.find('.products_list').show();
			firstTrigger.addClass('active');

			tabItem.find('.column_trigger').on('click', function(e){
				if ( $(this).hasClass('active') ) {
					$(this).removeClass('active');
					$(this).parent().parent().parent().find('.products_list').hide(300);
				} else {
					$(this).parent().parent().parent().find('.column_trigger').removeClass('active');
					$(this).addClass('active');
					$(this).parent().parent().parent().find('.products_list').hide(300);
					$(this).parent().siblings('.products_list').show(300);
				}
			});
		};
	});

});

  } catch(e) { console.error(e); }
})();



(function() {
  if (!__sections__["index-slideshow"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	$('.section_slider').each(function(i) {

		var sliderId = '#' + $(this).attr('id');
		var sliderVar = $(this).attr('id');
		var sliderPagination = '#pagination_' + sliderVar.replace('slideshow_', '');
		var sliderPrev = '#slider_prev_' + sliderVar.replace('slideshow_', '');
		var sliderNext = '#slider_next_' + sliderVar.replace('slideshow_', '');

		var sliderAutoplay = $(this).data('autoplay');
		if ( sliderAutoplay == true ) {
			sliderAutoplay = $(this).data('speed');
		};

		var sliderVar = new Swiper( sliderId, {
			effect: 'fade',
			autoplay: sliderAutoplay,
			loop: true,
			speed: 500,
			autoplayDisableOnInteraction: false,

			pagination: sliderPagination,
			paginationClickable: true,

			prevButton: sliderPrev,
			nextButton: sliderNext,

		});

		$(window).on('load', function() {
			sliderVar.onResize(); // updating swiper after loading

			// TITLE ANIMATION
			if ( $(window).width() > 992 && theme.titleAnimation ){
				$(sliderId + ' .slider_title_animation').each(function() {
					var elemEffect = $(this).data('in-effect');
					$(this).textillate({
						in: {
							effect: elemEffect,
							initialDelay: 0,
						},
						out: {
							effect: 'fadeOut',
						},
						loop: true
					});
				})
			}
		});


		

	});

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["index-testimonials"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	$('.section_testimonials').each(function() {

		var sectionId = $(this).attr('id').replace('shopify-section-', '');

		var testimonialSliderTag = '#testimonials_' + sectionId;
		var testimonialSliderPagination = '#pagination_' + sectionId;


		var testimonialsLoad = function() {

			if( $(testimonialSliderTag).length ) {

				var testimonialSlider = new Swiper(testimonialSliderTag, {
					slidesPerView: 3,
					breakpoints: {
						768: {
							slidesPerView: 2
						},
						480: {
							slidesPerView: 1
						}
					},
					spaceBetween: 30,
					pagination: testimonialSliderPagination,
					paginationClickable: true,
				});

			};

		};


		// LOADING SLIDERS
		testimonialsLoadTrigger = true;

		$(document).on('shopify:section:load', '#shopify-section-' + sectionId, function() {
			testimonialsLoad();
			testimonialsLoadTrigger = false;
		});

		if ( testimonialsLoadTrigger = true ) {
			testimonialsLoad();
		};

	});
});

  } catch(e) { console.error(e); }
})();



(function() {
  if (!__sections__["sidebar-sort"]) return;
  try {
    
jQuery(document).ready(function($) {
	$('.section_filter_block .filter_content_main').each(function(i) {

		$('.filter_select option[value="all"]').prop('selected', 'true');

		var queryCollection = 'all/';
		var queryType = '';
		var queryTag1 = '';
		var queryTag2 = '';

		// SELECT CATEGORY
		$('#category_select').on('change', function() {
			$('#type_select option[value="all"]').prop('selected', 'true');
			queryCollection = $(this).prop('value') + '/';

			return queryCollection, queryType = '';
		});
		
		// SELECT TYPE
		$('#type_select').on('change', function() {
			
			if ($(this).prop('value') == 'all') {
				queryType = '';
			} else {
				$('#category_select option[value="all"]').prop('selected', 'true');
				$('#tag_select_1 option[value="all"]').prop('selected', 'true');
				$('#tag_select_2 option[value="all"]').prop('selected', 'true');

				queryType = 'types?q=' + $(this).prop('value');
			};
			return queryType, queryCollection = '', queryTag1 = '', queryTag2 = '';
		});
		
		// SELECT TAG 1
		$('#tag_select_1').on('change', function() {

			if ($(this).prop('value') == 'all') {
				queryTag1 = '';
			} else {
				$('#type_select option[value="all"]').prop('selected', 'true');
				queryTag1 = $(this).prop('value');
			};
			return queryTag1, queryType = '';
		});
		
		// SELECT TAG 2
		$('#tag_select_2').on('change', function() {
			if ($(this).prop('value') == 'all') {
				queryTag2 = '';
			} else {
				$('#type_select option[value="all"]').prop('selected', 'true');
				queryTag2 = $(this).prop('value');
			};
			return queryTag2, queryType = '';
		});
		
		
		// CREATE A QUERY
		$('#sort_btn').on('click', function() {

			var emptyTag = ( queryTag1 + queryTag2 );
			var queryTag = '';

			if ( queryTag1 ) { queryTag = queryTag + queryTag1; };
			if ( queryTag2 ) { queryTag = queryTag + '+' + queryTag2; };
			if ( queryTag[0] == '+' ) { queryTag = queryTag.substr(1); };
			if ( emptyTag ) { queryTag = queryTag + '/' };


		var location = '/collections/' + queryCollection + queryTag + queryType;
			document.location.href = location;
			//console.log(location);
		});

	});


});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["sidebar"]) return;
  try {
    
(function($) {

	// LINKLIST ITEM SHOW/HIDE ELEMENT
	$(window).on('load', function() {
		$('.sidebar_widget__linklist .menu_trigger').each(function(i) {
			var targetMenu = '#' + $(this).data('submenu');

			$(this).on('click', function(e){
				if ($(this).hasClass('active')){
					$(targetMenu).hide(300);
					$(this).removeClass('active');
				} else {
					$(targetMenu).show(300);
					$(this).addClass('active');
				};
			});
		});
	
	});


})(jQuery);

  } catch(e) { console.error(e); }
})();


(function() {
  if (!__sections__["template-collection"]) return;
  try {
    
jQuery(document).ready(function($) {

	// PRODUCTS NUMBER
	$('#products_number_select option[value=' + theme.productNumber + ']').prop('selected', 'true');

	$('#products_number_select').on('change', function() {
		if (document.location.pathname.indexOf('types') > 0 || document.location.pathname.indexOf('vendors') > 0 && document.location.search.indexOf('page') < 0) {
			var productSortQuery = document.location.origin + document.location.pathname + document.location.search + '&page=1&sort_by=' + $('#sort_by_select').val() + '&view=' + $(this).val();
		} else if (document.location.pathname.indexOf('types') > 0 || document.location.pathname.indexOf('vendors') > 0 && document.location.search.indexOf('page') > 0) {
			var productSortQuery = document.location.origin + document.location.pathname + document.location.search.slice(0, document.location.search.indexOf('&') + 1) + '?page=1&sort_by=' + $('#sort_by_select').val() + '&view=' + $(this).val();
		} else {
			var productSortQuery = document.location.origin + document.location.pathname + '?page=1&sort_by=' + $('#sort_by_select').val() + '&view=' + $(this).val();
		}
		document.location.href = productSortQuery;
	});

	// LOAD MORE STYLE PAGINATION
	if( theme.paginationTypeLoad ){
		var current_page = theme.paginationCurrent;
		var pageFirstArrow = $('#page_navigation_prev_prev');
		var pageLastArrow = $('#page_navigation_next_next');
		var pagePrevArrow = $('#page_navigation_prev');
		var pageNextArrow = $('#page_navigation_next');
		var pageCurrentLabel = $('#page_navigation_current');
	
		// LOAD MORE BUTTON
		$('#load_more_button').on('click', function() {     			//  when clicking on the button the load is replaced in the URL of the page number on the +1
			var currentUrl = document.location.href;   					 // and load into a container

			if (document.location.href.indexOf('page=') > 0 ) {
				var newUrl = currentUrl.replace(/\?page=\d{1,3}/, '?page=' + (current_page + 1));
			} else {
				if (document.location.search.length > 0 ) {
					var newUrl = currentUrl +'&page=' + (current_page + 1);
				} else {
					var newUrl = currentUrl +'?page=' + (current_page + 1);
				}
			}

			var tempDiv = document.createElement('div');   				// create a temporary block in which we load content from url
			tempDiv.setAttribute('style', 'display: none;');
			tempDiv.id = 'further_loaded_content';

			$('#product_listing__sorted').addClass('loader_on');  									// preloader on

			$(tempDiv).load( newUrl + ' #product_listing__sorted> *', function(){  					// add content from the diva to the end of the listing
				$('#product_listing__sorted').append( $(tempDiv).html() ).removeClass('loader_on');  
				tempDiv.remove();																	// remove the temporary div
				
			});
			current_page ++; 																		// increase the page count by 1

			showHideLoadMoreButton(current_page);

			$.cookie(theme.collectionName, '?page=' + current_page , {path: '/'}); 					 // set cookie with the modified page

			redefinitionPagination(current_page);  													 // reloading pagination
			return current_page; 																	 // return the number of the current page


		});
		

		// SHOW/HIDE LOAD MORE BUTTON
		var showHideLoadMoreButton = function(page){  				// if the page is the last one we hid the button
			if( page == theme.paginatePages ){ 
				$('#load_more_button').addClass('hidden');
			} else {
				if( $('#load_more_button').hasClass('hidden') ){
					$('#load_more_button').removeClass('hidden');
				}
			}
		};


		// PAGINATION FOR LOAD MORE
		var checkStateOfPagination = function(page){
			if ( page > 1 &&  pageFirstArrow.hasClass('hidden') ){pageFirstArrow.removeClass('hidden');}; 	// Here we hide the arrows at the extreme values of pagination
			if ( page == 1 && !(pageFirstArrow.hasClass('hidden')) ){pageFirstArrow.addClass('hidden');}; 
			if ( page > 2 &&  pagePrevArrow.hasClass('hidden') ){pagePrevArrow.removeClass('hidden');};
			if ( page <= 2 && !(pagePrevArrow.hasClass('hidden')) ){pagePrevArrow.addClass('hidden');};  
																										
			if ( (theme.paginatePages - page) <= 1 && !(pageNextArrow.hasClass('hidden')) ){
				pageNextArrow.addClass('hidden');
			};
			if ( (theme.paginatePages - page) == 0 && !(pageLastArrow.hasClass('hidden')) ){
				pageLastArrow.addClass('hidden');
			};
			if ( (theme.paginatePages - page) > 0 &&  pageLastArrow.hasClass('hidden') ) {
				pageLastArrow.removeClass('hidden');
			};
			if ( (theme.paginatePages - page) > 1 &&  pageNextArrow.hasClass('hidden') ) {
				pageNextArrow.removeClass('hidden');
			};
		};

		var redefinitionPagination = function(page){ 					// pagination loading function, gets the page number argument
			pageCurrentLabel.html(page);
			checkStateOfPagination(page);
		};


		// ADD EVENT ON PAGINATION BUTTON  								// add events to the pagination buttons 
		pageFirstArrow.on('click', function(e) {
			if ( document.location.search.indexOf('page=') != -1 ){
				var newPageUrl = document.location.href.replace(/\?page=\d{1,3}/, '?page=1');
			} else {
				var newPageUrl = document.location.href + '?page=1';
			}
			$.cookie(theme.collectionName, '?page=1', {path: '/'});
			document.location.href = newPageUrl;
		});

		pageLastArrow.on('click', function(e) {
			if ( document.location.search.indexOf('page=') != -1 ){
				var newPageUrl = document.location.href.replace(/\?page=\d{1,3}/, '?page=' + theme.paginatePages);
			} else {
				var newPageUrl = document.location.href + '?page=' + theme.paginatePages;
			}
			$.cookie(theme.collectionName, '?page=' + theme.paginatePages, {path: '/'});
			document.location.href = newPageUrl;
		});

		pagePrevArrow.on('click', function(e) {
			if ( document.location.search.indexOf('page=') != -1 ){
				var newPageUrl = document.location.href.replace(/\?page=\d{1,3}/, '?page=' + ( current_page - 1 ));
			} else {
				var newPageUrl = document.location.href + '?page=' + ( current_page - 1 );
			}
			$.cookie(theme.collectionName, '?page=' + ( current_page - 1 ), {path: '/'});
			document.location.href = newPageUrl;
		});

		pageNextArrow.on('click', function(e) {
			if ( document.location.search.indexOf('page=') != -1 ){
				var newPageUrl = document.location.href.replace(/\?page=\d{1,3}/, '?page=' + ( current_page + 1 ));
			} else {
				var newPageUrl = document.location.href + '?page=' + ( current_page + 1 );
			}
			$.cookie(theme.collectionName, '?page=' + ( current_page + 1 ), {path: '/'});
			document.location.href = newPageUrl;
		});

		redefinitionPagination( current_page );    // call the function when the page loads

	};


});

  } catch(e) { console.error(e); }
})();



(function() {
  if (!__sections__["template-product"]) return;
  try {
    
jQuery(document).ready(function($) {

	var sectionID = $('.section_product').attr('id').replace('shopify-section-', '');

	var productLoad = function() {

		if ( productImage && theme.productViewType == 'carousel' ){

			// PRODUCT IMAGES
			var primaryImg = $('#primary_img_' + sectionID);

			var galleryImages = $('#gallery_big-' + sectionID);
			var galleryImagesPrev = $('#prev_' + sectionID);
			var galleryImagesNext = $('#next_' + sectionID);

			var galleryThumbs = $('#gallery_thumbs-' + sectionID);

			var galleryImageSlider = new Swiper(galleryImages, {
				effect: 'fade',
			});

			var galleryThumbSlider = new Swiper(galleryThumbs, {
				prevButton: galleryImagesPrev,
				nextButton: galleryImagesNext,
				slidesPerView: 3,
				centeredSlides: true,
				direction: 'vertical',
				breakpoints: {
					991: {
						slidesPerView: 3
					}
				},
				spaceBetween: 10,
				touchRatio: 0.2,
				slideToClickedSlide: true,
			});


			$(window).on('load', function() {
				galleryImageSlider.onResize(); // updating swiper after loading
				galleryThumbSlider.onResize(); // updating swiper after loading
			});


			galleryImageSlider.params.control = galleryThumbSlider;
			galleryThumbSlider.params.control = galleryImageSlider;
		};


		// PRODUCT OPTIONS
		var productSelect = 'product_select_' + sectionID;

		var productArray = JSON.parse( $('#product_json_' + sectionID).html() );
		var variantWeights = JSON.parse( $('#variant_weights_' + sectionID).html() );

		var productWeight = $('#single_product__weight-' + sectionID);
		var productSKU = $('#single_product__sku-' + sectionID);
		var productBarcode = $('#single_product__barcode-' + sectionID);

		var productAvailability = $('#single_product__availability-' + sectionID);
		var productPrice = $('#single_product__price-' + sectionID);

		var productQuantity = $('#single_product__quantity-' + sectionID);
		var productAdd = $('#single_product__addtocart-' + sectionID);


		selectCallback = function(variant, selector) {
			if ( variant && variant.available ) {

				// VARIANT WEIGHT
				if ( variant.requires_shipping == true ) {

					for ( var i in variantWeights ) {
						var i = parseInt(i);

						if ( i == variant.id ) {
							productWeight.html( variantWeights[i] );
						};
					};
				}
				else {
					productWeight.html( '—' );
				};


				// VARIANT SKU
				if ( variant.sku && variant.sku.length ) {
					productSKU.html( variant.sku );
				}
				else {
					productSKU.html( '—' );
				};


				// VARIANT BARCODE
				if ( variant.barcode != null ) {
					productBarcode.html( variant.barcode );
				}
				else {
					productBarcode.html( '—' );
				};


				// VARIANT AVAILABILITY
				if ( variant.inventory_management != null ) {

					if ( ( variant.inventory_quantity == 0 ) && ( variant.inventory_policy == 'continue' ) ) {
						productAvailability.removeClass('notify_danger').addClass('notify_success').html( producText.available );
					}
					else {
						productAvailability.removeClass('notify_danger').addClass('notify_success').html( variant.inventory_quantity + ' ' + producText.items );
					};

				}
				else {
					productAvailability.removeClass('notify_danger').addClass('notify_success').html( producText.available );
				};

				// VARIANT PRICE
				if ( variant.price < variant.compare_at_price ) {
					productPrice.html( '<span class="money">' + Shopify.formatMoney(variant.price, theme.moneyFormat) + '</span>' + '<span class="money money_sale">' + Shopify.formatMoney(variant.compare_at_price, theme.moneyFormat) + '</span><span class="money_sale_percent">– ' + parseInt( 100 - ( variant.price*100 )/variant.compare_at_price ) + '%</span>');
				}
				else {
					productPrice.html( '<span class="money">' + Shopify.formatMoney(variant.price, theme.moneyFormat) + '</span>' );
				};


				// VARIANT QUANTITY
				productQuantity.removeAttr('disabled', 'disabled');


				// VARIANT ADD TO CART BUTTON
				productAdd.removeAttr('disabled', 'disabled');


				if ( productImage && theme.productViewType == 'carousel' ) {

					// SWITCH VARIANT IMAGE (CAROUSEL VIEW)
					var newImage = variant.featured_image;
					var element = primaryImg[0];

					Shopify.Image.switchImage(newImage, element, function(newImageSizedSrc, newImage, element) {
						galleryImageSlider.slides.each(function(i) {
							var thumb = $(this).find('img').attr('src').replace('_crop_top', '').replace('_crop_center', '').replace('_crop_bottom', '').replace(/\?v=.*/ , '');
							var newImg = newImageSizedSrc.replace(/\?v=.*/ , '');

							if ( thumb == newImg ) {
								galleryImageSlider.slideTo(i);
							};
						});
					});
				};
				
				// SWITCH VARIANT IMAGE (STICKY VIEW)
				if ( productImage && theme.productViewType == 'sticky' && $(window).width() > 991 ){
					var variantImg = variant.featured_image.src;
					var imageOll = $('.single_product__img img');
				
					for (var i = 0; i < imageOll.length; i++) {
						var imgSrc = $(imageOll[i]).attr('src').replace('_570x617_crop_top', '');
						
						if ( variantImg.indexOf(imgSrc) > 0 ){
							var offsetImg = $(imageOll[i]).offset().top - $('#page_header').outerHeight();
							
							$('body,html').animate({scrollTop: offsetImg - 100}, 500);
							$(window).trigger('scroll');
						};
					}
				};


				// HIDE NOTIFY BUTTON
				$('#notify_trigger_button').removeClass('visible');
				$('.product_notify .notify_form').hide(300);

			}
			else {
				// VARIANT AVAILABILITY
				productAvailability.removeClass('notify_success').addClass('notify_danger').html( producText.unavailable );


				// VARIANT QUANTITY
				productQuantity.attr('disabled', 'disabled');


				// VARIANT ADD TO CART BUTTON
				productAdd.attr('disabled', 'disabled');

				// SHOW NOTIFY BUTTON
				$('#notify_trigger_button').addClass('visible');
			};


			// SWITCH CURRENCY
			if ( typeof theme.shopCurrency != 'undefined' ) {
				var newCurrency = Currency.cookie.read();
				var moneySelector = productPrice.find('span.money');
				Currency.convertAll( theme.shopCurrency, newCurrency, moneySelector, 'money_format' );

			};

			renderColorOptions(productArray.options);
			renderSizeOptions(productArray.options);
			
		};

		new Shopify.OptionSelectors( productSelect, {
			product: productArray,
			onVariantSelected: selectCallback,
			enableHistoryState: true 
		});

	};


	// LOADING PRODUCTS
	productLoadTrigger = true;

	$(document).on('shopify:section:load', '#shopify-section-' + sectionID, function() {
		productLoad();
		productLoadTrigger = false;
	});




	
	// RENDER COLOR OPTION
	var renderColorOptions = function(options){
		var colorOptionIndex = $('.color_product__options .color_toggle').data('option-index');
		var colorSelect = $('#shopify-section-' + sectionID + ' .single-option-selector').eq(colorOptionIndex);
		var selectId = '#' + colorSelect.attr('id');
		var container = $('#shopify-section-' + sectionID + ' .color_product__options .color_toggle');
		var content = '<label>' + options[colorOptionIndex] + ':</label>';

		$( selectId + ' option' ).each(function(){
			var value = $(this).val();
			colorSelect.parent('.selector-wrapper').addClass('hidden');
			if ( colorSelect.val() == value ) {
				return content = content + '<div class="color_item current" data-val="' + value + '" title="' + value + '"><span class="color_inner" style="background-color: ' + value + '"></span></div>';
			} else {
				return content = content + '<div class="color_item" data-val="' + value + '" title="' + value + '"><span class="color_inner" style="background-color: ' + value + '"></span></div>';
			};
		});

		container.html(content);

		$('.color_product__options .color_item').on('click', function(e){
			colorSelect.val( $(this).data('val') ).trigger('change');
		});
		
	};

	// RENDER SIZE OPTION
	var renderSizeOptions = function(options){
		var sizeOptionIndex = $('.size_product__options .size_toggle').data('option-index');
		var sizeSelect = $('#shopify-section-' + sectionID + ' .single-option-selector').eq(sizeOptionIndex);
		var selectId = '#' + sizeSelect.attr('id');
		var container = $('#shopify-section-' + sectionID + ' .size_product__options .size_toggle');
		var content = '<label>' + options[sizeOptionIndex] + ':</label>';

		$( selectId + ' option' ).each(function(){
			var value = $(this).val();
			sizeSelect.parent('.selector-wrapper').addClass('hidden');
			if ( sizeSelect.val() == value ) {
				return content = content + '<div class="size_item current" data-val="' + value + '"><span class="size_inner">' + value + '</span></div>';
			} else {
				return content = content + '<div class="size_item" data-val="' + value + '"><span class="size_inner">' + value + '</span></div>';
			};
		});

		container.html(content);

		$('.size_product__options .size_item').on('click', function(e){
			sizeSelect.val( $(this).data('val') ).trigger('change');
		});
		
	};


	// STICKY VIEW 
	if( theme.productViewType == 'sticky' && $(window).width() > 991 ){
		var target = $('.single_product__info');
		var mainUnit = target.parent();
		var sibling = target.siblings('.single_product__img');

		$(window).on('load scroll resize', function() {
			var scrolledValue = parseInt( $(window).scrollTop() );
			var offsetValue = parseInt( mainUnit.offset().top );
			var mainUnitEnd = mainUnit.outerHeight() + mainUnit.offset().top + 70;

			if(scrolledValue > offsetValue ){
				target.addClass('sticky').css({
					'top':$('#page_header').outerHeight() + 'px',
					'left':( sibling.offset().left + sibling.outerWidth() ) + 'px'
				});
			} else {
				target.removeClass('sticky');
			};


			if( ( scrolledValue + $(window).height() ) > mainUnitEnd ){
				target.removeClass('sticky');
			};

		});
	}

});

  } catch(e) { console.error(e); }
})();


})();
