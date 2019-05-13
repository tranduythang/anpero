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


	$(window).on('load resize', function() {
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
  if (!__sections__["index-slideshow-full-width"] && !window.DesignMode) return;
  try {
    
jQuery(document).ready(function($) {
	$('.section_slideshow_full_width').each(function(i) {

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


			paginationBulletRender: function (sliderVar, index, className) {
				return '<span class="' + className + '">' + '.0' + (index + 1) + '</span>';
			},

			prevButton: sliderPrev,
			nextButton: sliderNext,

		});

		$(window).on('load', function() {
			sliderVar.onResize(); // updating swiper after loading
		});

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
  if (!__sections__["sidebar-blog"]) return;
  try {
    
jQuery(document).ready(function($) { 

	// NEWSLETTER FORM
	$('.sidebar_newsletter_form').each(function (){      
		$(this).on('submit', function(e){
			var formCookie = $(this).attr('class');
			$.cookie('footerformSended', formCookie);
		});
	});
	
	if( document.location.href.indexOf('?customer_posted=true') > 0 && $.cookie('footerformSended') == 'sidebar_newsletter_form') {
		$('.sidebar_newsletter_form .form_wrapper').hide();
		$('.sidebar_newsletter_form .form_text').hide();
		$('.sidebar_newsletter_form .alert-success').show();
	}

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
  if (!__sections__["template-addresses"]) return;
  try {
    
jQuery(document).ready(function($) {
	// ADD NEW ADDRESS
	$('#address_add, #address_add__close').hide();

	$('#address_add__link').on('click', function(e) {
		e.preventDefault();

		$(this).fadeOut(300);
		$('#address_add__close').delay(300).fadeIn();
		$('#address_add').slideDown();
	});

	$('#address_add__close, #address_add__cancel').on('click', function(e) {
		e.preventDefault();

		$('#address_add__close').fadeOut(300);
		$('#address_add__link').delay(300).fadeIn();
		$('#address_add').slideUp();
	});


	// EDIT EXISTING ADDRESS
	$('.account_address__edit').hide();
	$('.account_address__item .link_close').hide();

	$('.link_edit').on('click', function(e) {
		e.preventDefault();

		var t = $(this).attr('href');

		$(t).find('.account_address__edit').slideDown();

		$(this).fadeOut(300);

		$(t).find('.link_close').delay(300).fadeIn();

		$(t).find('.link_close').on('click', function(event) {
			event.preventDefault();

			$(t).find('.account_address__edit').slideUp();

			$(this).fadeOut(300);

			$(t).find('.link_edit').delay(300).fadeIn();
		});

		$(t).find('.link_cancel').on('click', function(event) {
			event.preventDefault();

			$(t).find('.link_close').trigger('click');
		});

	});


	// DELETING ADDRESS
	$('.link_delete').on('click', function() {
		Shopify.CustomerAddress.destroy( $(this).attr('title') );
	});

});


// PROVINCES SELECTS
new Shopify.CountryProvinceSelector( 'address_country_new', 'address_province_new', { hideElement: 'address_province_container_new' } );

var customerAddresses = JSON.parse( theme.customerAddresses );

for ( i=0; i<customerAddresses.length; i++ ) {
	var addressCountry = 'address_country_' + customerAddresses[i].id;
	var addressProvince = 'address_province_' + customerAddresses[i].id;
	var addressProvinceHide = 'address_province_container_' + customerAddresses[i].id;

	new Shopify.CountryProvinceSelector( addressCountry, addressProvince, { hideElement: addressProvinceHide } );

};

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["template-collection"]) return;
  try {
    
jQuery(document).ready(function($) {

	// LOAD COLLECTION CONTENT         
																		 // when loading a page, we compare the value from the cookie and load the content onto the page
	if( theme.paginationTypeLoad && theme.collectionName.length > 0 ){   
		var collectionUrlCookie = $.cookie(theme.collectionName);
		if( collectionUrlCookie ){        								 // if there is a cookie, if there is a search in the URL and there is a page in the search 

			if ( document.location.search.indexOf('page=') != -1 ){
				var urlPage = document.location.search.match(/\?page=\d{1,3}/)[0];
				var reloadUrl = document.location.href.replace(/\?page=\d{1,3}/, collectionUrlCookie);

				if( urlPage != collectionUrlCookie ){
																		// reloading to the page with the replacement of the page number by the number from the cookie
					document.location.href = reloadUrl;
				}
			}

		} 
	}

	// PRODUCTS VIEW GRID/LIST
	if ( typeof $.cookie('productSortView') == 'undefined' ) {
		$.cookie('productSortView', 'grid', {path: '/'});
	}
	else if ( $.cookie('productSortView') == 'list' ) {
		$('#view_grid').removeClass('active');
		$('#view_list').addClass('active');

		$('#product_listing__sorted').addClass('product_listing__list');

	};

	$('#view_grid, #view_list').on('click', function() {
		var thisView = $(this).data('view');

		$('#view_grid, #view_list').removeClass('active');
		$('#product_listing__sorted').removeClass('product_listing__list product_listing__grid');

		$(this).addClass('active');

		$.cookie('productSortView', thisView, {path: '/'});
		$('#product_listing__sorted').addClass( 'product_listing__' + thisView );

	});


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


	// PRODUCTS SORTING
	$('#sort_by_select option').each(function() {
		if ( document.location.href.indexOf( $(this).prop('value') ) != -1 ) {
			$(this).prop('selected', 'selected');
		};

	});


	$('#sort_by_select').on('change', function() {
		if (document.location.pathname.indexOf('types') > 0 || document.location.pathname.indexOf('vendors') > 0 && document.location.search.indexOf('page') < 0) {
			var productSortQuery = document.location.origin + document.location.pathname + document.location.search + '?page=1&sort_by=' + $(this).val() + '&view=' + theme.productNumber;
		} else if (document.location.pathname.indexOf('types') > 0 || document.location.pathname.indexOf('vendors') > 0 && document.location.search.indexOf('page') > 0) {
			var productSortQuery = document.location.origin + document.location.pathname + document.location.search.slice(0, document.location.search.indexOf('&') + 1) + '?page=1&sort_by=' + $(this).val() + '&view=' + theme.productNumber;
		} else {
			var productSortQuery = document.location.origin + document.location.pathname  + '?page=1&sort_by=' + $(this).val() + '&view=' + theme.productNumber;
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
  if (!__sections__["template-login"]) return;
  try {
    
jQuery(document).ready(function($) {
	if ( $('#create_customer').find('.alert').length ) {
		$('#account_section__register').show().removeClass('account_section__hidden');
		$('#account_section__wrapper').hide();
	}
	else if ( $('#account_section__reset').find('.alert').length ) {
		$('#account_section__reset').show().removeClass('account_section__hidden');
	};



	$('#account_register__link').on('click', function(e) {
		e.preventDefault();

		$('#account_section__wrapper').slideUp();
		$('#account_section__register').slideDown();

		if ( $('#account_section__reset').is(':visible') ) {
			$('#account_section__reset').slideUp();
		};

	});


	$('.account_register__close').on('click', function(e) {
		e.preventDefault();

		$('#account_section__register').slideUp();
		$('#account_section__wrapper').slideDown();

	});


	$('#account_reset__link').on('click', function(e) {
		e.preventDefault();

		if ( $('#account_section__reset').is(':hidden') ) {
			$('#account_section__reset').slideDown();
		};

	});


	$('.account_reset__cancel').on('click', function(e) {
		e.preventDefault();

		$('#account_section__reset').slideUp();
	});


	if ( document.location.href.indexOf( '#recover' ) !== -1 ) {
		$('#account_section__reset').removeClass('account_section__hidden');
	};


	$('#create_customer').on('submit', function() {
		$('#password_confirmed').val( $('#password_1').val() );
	});

});

  } catch(e) { console.error(e); }
})();

(function() {
  if (!__sections__["template-password"]) return;
  try {
    
	// jQuery Circular CountDown - https://github.com/nikhiln/Circular-Countdown
		!function(e){e.fn.ccountdown=function(a,t,n,r,d){var o,g=this,i=new Array("Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"),c=(new Date,function(){var c=new Date,u=c.getYear();1e3>u&&(u+=1900);var h=c.getMonth(),l=c.getDate(),f=c.getHours(),s=c.getMinutes(),_=c.getSeconds();_="0"+_,_=_.substr(_.length-2);var v=i[h]+" "+l+", "+u+" "+f+":"+s+":"+_,M=i[t-1]+" "+n+", "+a+" "+r;_dd=Date.parse(M)-Date.parse(v),_dday=Math.floor(_dd/864e5*1),_dhour=Math.floor(_dd%864e5/36e5*1),_dmin=Math.floor(_dd%864e5%36e5/6e4*1),_dsec=Math.floor(_dd%5184e6%36e5%6e4/1e3*1);var y=e(g),w=y.find(".second"),D=y.find(".minute"),p=y.find(".hour"),m=y.find(".days");w.val(_dsec).trigger("change"),D.val(_dmin).trigger("change"),p.val(_dhour).trigger("change"),m.val(_dday).trigger("change"),0==_dd&&(window.clearInterval(o),"function"==typeof d&&d.call(this))});c(),o=setInterval(c,1e3)}}(jQuery);

	// jQuery Knob - https://github.com/aterrien/jQuery-Knob
		!function(t){"object"==typeof exports?module.exports=t(require("jquery")):"function"==typeof define&&define.amd?define(["jquery"],t):t(jQuery)}(function(t){"use strict";var i={},s=Math.max,h=Math.min;i.c={},i.c.d=t(document),i.c.t=function(t){return t.originalEvent.touches.length-1},i.o=function(){var s=this;this.o=null,this.$=null,this.i=null,this.g=null,this.v=null,this.cv=null,this.x=0,this.y=0,this.w=0,this.h=0,this.$c=null,this.c=null,this.t=0,this.isInit=!1,this.fgColor=null,this.pColor=null,this.dH=null,this.cH=null,this.eH=null,this.rH=null,this.scale=1,this.relative=!1,this.relativeWidth=!1,this.relativeHeight=!1,this.$div=null,this.run=function(){var i=function(t,i){var h;for(h in i)s.o[h]=i[h];s._carve().init(),s._configure()._draw()};if(!this.$.data("kontroled")){if(this.$.data("kontroled",!0),this.extend(),this.o=t.extend({min:void 0!==this.$.data("min")?this.$.data("min"):0,max:void 0!==this.$.data("max")?this.$.data("max"):100,stopper:!0,readOnly:this.$.data("readonly")||"readonly"===this.$.attr("readonly"),cursor:this.$.data("cursor")===!0&&30||this.$.data("cursor")||0,thickness:this.$.data("thickness")&&Math.max(Math.min(this.$.data("thickness"),1),.01)||.35,lineCap:this.$.data("linecap")||"butt",width:this.$.data("width")||200,height:this.$.data("height")||200,displayInput:null==this.$.data("displayinput")||this.$.data("displayinput"),displayPrevious:this.$.data("displayprevious"),fgColor:this.$.data("fgcolor")||"#87CEEB",inputColor:this.$.data("inputcolor"),font:this.$.data("font")||"Arial",fontWeight:this.$.data("font-weight")||"bold",inline:!1,step:this.$.data("step")||1,rotation:this.$.data("rotation"),draw:null,change:null,cancel:null,release:null,format:function(t){return t},parse:function(t){return parseFloat(t)}},this.o),this.o.flip="anticlockwise"===this.o.rotation||"acw"===this.o.rotation,this.o.inputColor||(this.o.inputColor=this.o.fgColor),this.$.is("fieldset")?(this.v={},this.i=this.$.find("input"),this.i.each(function(i){var h=t(this);s.i[i]=h,s.v[i]=s.o.parse(h.val()),h.bind("change blur",function(){var t={};t[i]=h.val(),s.val(s._validate(t))})}),this.$.find("legend").remove()):(this.i=this.$,this.v=this.o.parse(this.$.val()),""===this.v&&(this.v=this.o.min),this.$.bind("change blur",function(){s.val(s._validate(s.o.parse(s.$.val())))})),!this.o.displayInput&&this.$.hide(),this.$c=t(document.createElement("canvas")).attr({width:this.o.width,height:this.o.height}),this.$div=t('<div style="'+(this.o.inline?"display:inline;":"")+"width:"+this.o.width+"px;height:"+this.o.height+'px;"></div>'),this.$.wrap(this.$div).before(this.$c),this.$div=this.$.parent(),"undefined"!=typeof G_vmlCanvasManager&&G_vmlCanvasManager.initElement(this.$c[0]),this.c=this.$c[0].getContext?this.$c[0].getContext("2d"):null,!this.c)throw{name:"CanvasNotSupportedException",message:"Canvas not supported. Please use excanvas on IE8.0.",toString:function(){return this.name+": "+this.message}};return this.scale=(window.devicePixelRatio||1)/(this.c.webkitBackingStorePixelRatio||this.c.mozBackingStorePixelRatio||this.c.msBackingStorePixelRatio||this.c.oBackingStorePixelRatio||this.c.backingStorePixelRatio||1),this.relativeWidth=this.o.width%1!==0&&this.o.width.indexOf("%"),this.relativeHeight=this.o.height%1!==0&&this.o.height.indexOf("%"),this.relative=this.relativeWidth||this.relativeHeight,this._carve(),this.v instanceof Object?(this.cv={},this.copy(this.v,this.cv)):this.cv=this.v,this.$.bind("configure",i).parent().bind("configure",i),this._listen()._configure()._xy().init(),this.isInit=!0,this.$.val(this.o.format(this.v)),this._draw(),this}},this._carve=function(){if(this.relative){var t=this.relativeWidth?this.$div.parent().width()*parseInt(this.o.width)/100:this.$div.parent().width(),i=this.relativeHeight?this.$div.parent().height()*parseInt(this.o.height)/100:this.$div.parent().height();this.w=this.h=Math.min(t,i)}else this.w=this.o.width,this.h=this.o.height;return this.$div.css({width:this.w+"px",height:this.h+"px"}),this.$c.attr({width:this.w,height:this.h}),1!==this.scale&&(this.$c[0].width=this.$c[0].width*this.scale,this.$c[0].height=this.$c[0].height*this.scale,this.$c.width(this.w),this.$c.height(this.h)),this},this._draw=function(){var t=!0;s.g=s.c,s.clear(),s.dH&&(t=s.dH()),t!==!1&&s.draw()},this._touch=function(t){var h=function(t){var i=s.xy2val(t.originalEvent.touches[s.t].pageX,t.originalEvent.touches[s.t].pageY);i!=s.cv&&(s.cH&&s.cH(i)===!1||(s.change(s._validate(i)),s._draw()))};return this.t=i.c.t(t),h(t),i.c.d.bind("touchmove.k",h).bind("touchend.k",function(){i.c.d.unbind("touchmove.k touchend.k"),s.val(s.cv)}),this},this._mouse=function(t){var h=function(t){var i=s.xy2val(t.pageX,t.pageY);i!=s.cv&&(s.cH&&s.cH(i)===!1||(s.change(s._validate(i)),s._draw()))};return h(t),i.c.d.bind("mousemove.k",h).bind("keyup.k",function(t){if(27===t.keyCode){if(i.c.d.unbind("mouseup.k mousemove.k keyup.k"),s.eH&&s.eH()===!1)return;s.cancel()}}).bind("mouseup.k",function(){i.c.d.unbind("mousemove.k mouseup.k keyup.k"),s.val(s.cv)}),this},this._xy=function(){var t=this.$c.offset();return this.x=t.left,this.y=t.top,this},this._listen=function(){return this.o.readOnly?this.$.attr("readonly","readonly"):(this.$c.bind("mousedown",function(t){t.preventDefault(),s._xy()._mouse(t)}).bind("touchstart",function(t){t.preventDefault(),s._xy()._touch(t)}),this.listen()),this.relative&&t(window).resize(function(){s._carve().init(),s._draw()}),this},this._configure=function(){return this.o.draw&&(this.dH=this.o.draw),this.o.change&&(this.cH=this.o.change),this.o.cancel&&(this.eH=this.o.cancel),this.o.release&&(this.rH=this.o.release),this.o.displayPrevious?(this.pColor=this.h2rgba(this.o.fgColor,"0.4"),this.fgColor=this.h2rgba(this.o.fgColor,"0.6")):this.fgColor=this.o.fgColor,this},this._clear=function(){this.$c[0].width=this.$c[0].width},this._validate=function(t){var i=~~((0>t?-.5:.5)+t/this.o.step)*this.o.step;return Math.round(100*i)/100},this.listen=function(){},this.extend=function(){},this.init=function(){},this.change=function(){},this.val=function(){},this.xy2val=function(){},this.draw=function(){},this.clear=function(){this._clear()},this.h2rgba=function(t,i){var s;return t=t.substring(1,7),s=[parseInt(t.substring(0,2),16),parseInt(t.substring(2,4),16),parseInt(t.substring(4,6),16)],"rgba("+s[0]+","+s[1]+","+s[2]+","+i+")"},this.copy=function(t,i){for(var s in t)i[s]=t[s]}},i.Dial=function(){i.o.call(this),this.startAngle=null,this.xy=null,this.radius=null,this.lineWidth=null,this.cursorExt=null,this.w2=null,this.PI2=2*Math.PI,this.extend=function(){this.o=t.extend({bgColor:this.$.data("bgcolor")||"#EEEEEE",angleOffset:this.$.data("angleoffset")||0,angleArc:this.$.data("anglearc")||360,inline:!0},this.o)},this.val=function(t,i){return null==t?this.v:(t=this.o.parse(t),void(i!==!1&&t!=this.v&&this.rH&&this.rH(t)===!1||(this.cv=this.o.stopper?s(h(t,this.o.max),this.o.min):t,this.v=this.cv,this.$.val(this.o.format(this.v)),this._draw())))},this.xy2val=function(t,i){var e,n;return e=Math.atan2(t-(this.x+this.w2),-(i-this.y-this.w2))-this.angleOffset,this.o.flip&&(e=this.angleArc-e-this.PI2),this.angleArc!=this.PI2&&0>e&&e>-.5?e=0:0>e&&(e+=this.PI2),n=e*(this.o.max-this.o.min)/this.angleArc+this.o.min,this.o.stopper&&(n=s(h(n,this.o.max),this.o.min)),n},this.listen=function(){var i,e,n,a,o=this,r=function(t){t.preventDefault();var n=t.originalEvent,a=n.detail||n.wheelDeltaX,r=n.detail||n.wheelDeltaY,l=o._validate(o.o.parse(o.$.val()))+(a>0||r>0?o.o.step:0>a||0>r?-o.o.step:0);l=s(h(l,o.o.max),o.o.min),o.val(l,!1),o.rH&&(clearTimeout(i),i=setTimeout(function(){o.rH(l),i=null},100),e||(e=setTimeout(function(){i&&o.rH(l),e=null},200)))},l=1,c={37:-o.o.step,38:o.o.step,39:o.o.step,40:-o.o.step};this.$.bind("keydown",function(i){var e=i.keyCode;if(e>=96&&105>=e&&(e=i.keyCode=e-48),n=parseInt(String.fromCharCode(e)),isNaN(n)&&(13!==e&&8!==e&&9!==e&&189!==e&&(190!==e||o.$.val().match(/\./))&&i.preventDefault(),t.inArray(e,[37,38,39,40])>-1)){i.preventDefault();var r=o.o.parse(o.$.val())+c[e]*l;o.o.stopper&&(r=s(h(r,o.o.max),o.o.min)),o.change(o._validate(r)),o._draw(),a=window.setTimeout(function(){l*=2},30)}}).bind("keyup",function(){isNaN(n)?a&&(window.clearTimeout(a),a=null,l=1,o.val(o.$.val())):o.$.val()>o.o.max&&o.$.val(o.o.max)||o.$.val()<o.o.min&&o.$.val(o.o.min)}),this.$c.bind("mousewheel DOMMouseScroll",r),this.$.bind("mousewheel DOMMouseScroll",r)},this.init=function(){(this.v<this.o.min||this.v>this.o.max)&&(this.v=this.o.min),this.$.val(this.v),this.w2=this.w/2,this.cursorExt=this.o.cursor/100,this.xy=this.w2*this.scale,this.lineWidth=this.xy*this.o.thickness,this.lineCap=this.o.lineCap,this.radius=this.xy-this.lineWidth/2,this.o.angleOffset&&(this.o.angleOffset=isNaN(this.o.angleOffset)?0:this.o.angleOffset),this.o.angleArc&&(this.o.angleArc=isNaN(this.o.angleArc)?this.PI2:this.o.angleArc),this.angleOffset=this.o.angleOffset*Math.PI/180,this.angleArc=this.o.angleArc*Math.PI/180,this.startAngle=1.5*Math.PI+this.angleOffset,this.endAngle=1.5*Math.PI+this.angleOffset+this.angleArc;var t=s(String(Math.abs(this.o.max)).length,String(Math.abs(this.o.min)).length,2)+2;this.o.displayInput&&this.i.css({width:(this.w/2+4>>0)+"px",height:(this.w/3>>0)+"px",position:"absolute","vertical-align":"middle","margin-top":(this.w/3>>0)+"px","margin-left":"-"+(3*this.w/4+2>>0)+"px",border:0,background:"none",font:this.o.fontWeight+" "+(this.w/t>>0)+"px "+this.o.font,"text-align":"center",color:this.o.inputColor||this.o.fgColor,padding:"0px","-webkit-appearance":"none"})||this.i.css({width:"0px",visibility:"hidden"})},this.change=function(t){this.cv=t,this.$.val(this.o.format(t))},this.angle=function(t){return(t-this.o.min)*this.angleArc/(this.o.max-this.o.min)},this.arc=function(t){var i,s;return t=this.angle(t),this.o.flip?(i=this.endAngle+1e-5,s=i-t-1e-5):(i=this.startAngle-1e-5,s=i+t+1e-5),this.o.cursor&&(i=s-this.cursorExt)&&(s+=this.cursorExt),{s:i,e:s,d:this.o.flip&&!this.o.cursor}},this.draw=function(){var t,i=this.g,s=this.arc(this.cv),h=1;i.lineWidth=this.lineWidth,i.lineCap=this.lineCap,"none"!==this.o.bgColor&&(i.beginPath(),i.strokeStyle=this.o.bgColor,i.arc(this.xy,this.xy,this.radius,this.endAngle-1e-5,this.startAngle+1e-5,!0),i.stroke()),this.o.displayPrevious&&(t=this.arc(this.v),i.beginPath(),i.strokeStyle=this.pColor,i.arc(this.xy,this.xy,this.radius,t.s,t.e,t.d),i.stroke(),h=this.cv==this.v),i.beginPath(),i.strokeStyle=h?this.o.fgColor:this.fgColor,i.arc(this.xy,this.xy,this.radius,s.s,s.e,s.d),i.stroke()},this.cancel=function(){this.val(this.v)}},t.fn.dial=t.fn.knob=function(s){return this.each(function(){var h=new i.Dial;h.o=s,h.$=t(this),h.run()}).parent()}});


	// COUNTER INIT
		$(function(){$(".knob").knob({draw:function(){if("tron"==this.$.data("skin")){var t,i=this.angle(this.cv),s=this.startAngle,h=this.startAngle,n=h+i,o=!0;return this.g.lineWidth=this.lineWidth,this.o.cursor&&(h=n-.3)&&(n+=.3),this.o.displayPrevious&&(t=this.startAngle+this.angle(this.value),this.o.cursor&&(s=t+.3)&&(t-=.3),this.g.beginPath(),this.g.strokeStyle=this.previousColor,this.g.arc(this.xy,this.xy,this.radius-this.lineWidth,s,t,!1),this.g.stroke()),this.g.beginPath(),this.g.strokeStyle=o?this.o.fgColor:this.fgColor,this.g.arc(this.xy,this.xy,this.radius-this.lineWidth,h,n,!1),this.g.stroke(),this.g.lineWidth=2,this.g.beginPath(),this.g.strokeStyle=this.o.fgColor,this.g.arc(this.xy,this.xy,this.radius-this.lineWidth+1+2*this.lineWidth/3,0,2*Math.PI,!1),this.g.stroke(),!1}}});var t,i=0,s=0,h=0,n=$("div.idir"),o=$("div.ival"),e=function(){h++,n.show().html("+").fadeOut(),o.html(h)},r=function(){h--,n.show().html("-").fadeOut(),o.html(h)};$("input.infinite").knob({min:0,max:20,stopper:!1,change:function(){t>this.cv?i?(r(),i=0):(i=1,s=0):t<this.cv&&(s?(e(),s=0):(s=1,i=0)),t=this.cv}})});



	jQuery(document).ready(function($) {

		var date_year = $("#timer_countdown_wrap").data('year');
		var date_month = $("#timer_countdown_wrap").data('month');
		var date_day = $("#timer_countdown_wrap").data('day');

		$("#timer_countdown").ccountdown( date_year, date_month, date_day,'00:00');

		$('.knob.days').after("<span class='countdown_caption'>" + passwordText.daysTr + "</span>");
		$('.knob.hour').after("<span class='countdown_caption'>" + passwordText.hoursTr + "</span>");
		$('.knob.minute').after("<span class='countdown_caption'>" + passwordText.minutesTr + "</span>");
		$('.knob.second').after("<span class='countdown_caption'>" + passwordText.secondsTr + "</span>");
		
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

	if ( productLoadTrigger = true ) {
		productLoad();
	};
	

	// ADD WISHLIST
	$('#wishlist_add').on('click', function(e) {
		e.preventDefault();
		$('#wishlist_form').submit();
		
	});
	

	$('#notify_trigger_button').on('click',function(){
		$('.product_notify .notify_form').show(600);
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

(function() {
  if (!__sections__["template-wishlist"]) return;
  try {
    
	jQuery(document).ready(function($) {

		var isCustomer = $('#wishlist_page').data('customer')
		
			if ( isCustomer ) {
			
				if ($('.product_wishlist').length == 0) {
					$('#wishlist_empty').removeClass('hidden');
		 			$('#wishlist_products_number').html( 0 );
				}
		 		else {
		 			$('#wishlist_products_number').html( $('.product_wishlist').length );
		 		};
			}		 		
			 	
	});

	function removeFromWishlist($this) {
		

		// select parent li element
		var $elem = $this.closest(".product_wishlist");
		// get the id which is the selected variant tag
		var tagID = $elem.attr("id");
		var $form = $("#remove");

		// set the value of the input in the form to the selected variant
		$("#remove-value").attr("value", tagID);
		
		$("#remove").submit();
		
	};

	$('.js-remove-button').on('click', function(e) {
	 	e.preventDefault();
	 	removeFromWishlist( $(this) );
	});
	



  } catch(e) { console.error(e); }
})();

})();
