// © Copyright 2015 - Archi by Designesia 
jQuery(document).ready(function() {		
	'use strict'; // use strict mode

	var mobile_menu_show = 0;
	
	// --------------------------------------------------
	// paralax background
	// --------------------------------------------------
	var $window = jQuery(window);
   	jQuery('section[data-type="background"]').each(function(){
		var $bgobj = jQuery(this); // assigning the object						
		jQuery(window).scroll(function() {
			var yPos = -($window.scrollTop() / $bgobj.data('speed')); 
			var coords = '50% '+ yPos + 'px';
			$bgobj.css({ backgroundPosition: coords });			
		});
 	});
	document.createElement("article");
	document.createElement("section");
	
	// --------------------------------------------------
	// init
	// --------------------------------------------------
	function init_de(){
		enquire.register("screen and (max-width: 993px)", {
			match : function() {
				$('header.header-mobile-sticky').addClass("header-mobile");		
			},  
			unmatch : function() {
				$('header.header-mobile-sticky').removeClass("header-mobile");
			}
		});

		var $window = jQuery(window);
        jQuery('section[data-type="background"]').each(function () {
            var $bgobj = jQuery(this); // assigning the object

            jQuery(window).scroll(function () {

                enquire.register("screen and (min-width: 993px)", {
                    match: function () {
                        var yPos = -($window.scrollTop() / $bgobj.data('speed'));
                        var coords = '50% ' + yPos + 'px';
                        $bgobj.css({ backgroundPosition: coords });
                    }
                });
            });
            document.createElement("article");
            document.createElement("section");
        });
	
		jQuery('.de-team-list').each(function(){

			 jQuery(this).find("img").on('load', function() {
					var w = jQuery(this).css("width");
			 	   	var h = jQuery(this).css("height");
				   	//nh = (h.substring(0, h.length - 2)/2)-48;
			 
					jQuery(this).parent().parent().find(".team-pic").css("height",h);
					jQuery(this).parent().parent().find(".team-desc").css("width",w);
				 	jQuery(this).parent().parent().find(".team-desc").css("height",h);
					jQuery(this).parent().parent().find(".team-desc").css("top",h);

				}).each(function() {
				  if(this.complete) jQuery(this).load();
				});
		});

		jQuery(".de-team-list").on("mouseenter", function () {
			 var h;
			 h = jQuery(this).find("img").css("height");
			 jQuery(this).find(".team-desc").stop(true).animate({'top': "0px"},350,'easeOutQuad');
			 jQuery(this).find("img").stop(true).animate({'margin-top': "-100px"},400,'easeOutQuad');
		}).on("mouseleave", function () {		
			 var h;
			 h = jQuery(this).find("img").css("height");
			 jQuery(this).find(".team-desc").stop(true).animate({'top': h},350,'easeOutQuad');
			 jQuery(this).find("img").stop(true).animate({'margin-top': "0px"},400,'easeOutQuad');
	  	})	
		
		
		// portfolio
		jQuery('.item .picframe').each(function(){		
		jQuery(this).find("img").css("width","100%");
		jQuery(this).find("img").css("height","auto");	 
		jQuery(this).find("img").on('load', function() {
				var w = jQuery(this).css("width");
		 	   	var h = jQuery(this).css("height");
				jQuery(this).parent().css("height",h);
			}).each(function() {
			  if(this.complete) jQuery(this).load();
			});
		});
			
		// --------------------------------------------------
		// portfolio hover
		// --------------------------------------------------
		jQuery('.overlay').fadeTo(1, 0);

		jQuery('.item > .picframe').each(function () {

            jQuery(this).find("img").on('load', function () {
                var w = jQuery(this).css("width");
                var h = jQuery(this).css("height");
				var space = 40;
				var w1 = parseInt(jQuery(this).css("width"))-space;
				var h1 = parseInt(jQuery(this).css("height"))-space;
                
				//nh = (h.substring(0, h.length - 2)/2)-48;
				
				var obj = jQuery(this).parent().parent().find(".overlay-1");

                obj.css("width", w);
                obj.css("height", h);
				

            }).each(function () {
                if (this.complete) $(this).load();
            });
        });
		
		// gallery hover
		jQuery(".item .picframe").on("mouseenter", function () {
			 jQuery(this).parent().find(".overlay").width(jQuery(this).find("img").css("width"));
			 jQuery(this).parent().find(".overlay").height(jQuery(this).find("img").css("height"));
			 jQuery(this).parent().find(".overlay").stop(true).fadeTo(300, .9);
			 var picheight = jQuery(this).find("img").css("height");
			 var newheight;
			 newheight = (picheight.substring(0, picheight.length - 2)/2)-10;
			 //alert(newheight);
			 jQuery(this).parent().find(".pf_text").stop(true).animate({'margin-top': newheight},300,'easeOutCubic');
			 
			 var w = jQuery(this).find("img").css("width");
			 var h = jQuery(this).find("img").css("height");
			 var w = parseInt(w, 10);
			 var h = parseInt(h, 10);
			 var $scale = 1.2;
			 //alert(w);
			 
			jQuery(this).find("img").stop(true).animate({
		            width:  w*$scale,
		            height: h*$scale,
		            'margin-left': -w*($scale - 1)/2,
		            'margin-top':  -h*($scale - 1)/2
		    }, 700,'easeOutQuad');

	  	}).on("mouseleave", function () {
		 var newheight;
		 var picheight = jQuery(this).find("img").css("height");	 
		 newheight = (picheight.substring(0, picheight.length - 2)/2)-10;
		 jQuery(this).parent().find(".pf_text").stop(true).animate({'margin-top': newheight - 30},300,'easeOutCubic');
		 jQuery(this).parent().find(".overlay").stop(true).fadeTo(300, 0);
		 jQuery(this).find("img").stop(true).animate({
	            width:  '100%',
	            height: '100%',
	            'margin-left': 0,
	            'margin-top': 0
	     }, 700,'easeOutQuad');
		})

		jQuery('.overlay').fadeTo(1, 0);
	// team hover
	}
	
	init_de();

	// --------------------------------------------------
	// function
	// --------------------------------------------------
	
	function video_autosize(){
		jQuery('.de-video-container').each(function() {
			var height_1 = jQuery(this).css("height");
			var height_2 = jQuery(this).find(".de-video-content").css("height");
			var newheight = (height_1.substring(0, height_1.length - 2)-height_2.substring(0, height_2.length - 2))/2;
			jQuery(this).find('.de-video-overlay').css("height", height_1);
			jQuery(this).find(".de-video-content").animate({'margin-top': newheight},'fast');
		});
	}
	
	window.onresize = function(event) {
		enquire.register("screen and (min-width: 993px)", {
			match : function() {
				jQuery('#mainmenu').show();
				jQuery('.mainmenu').show();
				mobile_menu_show = 1;
			},  
			unmatch : function() {
				jQuery('#mainmenu').hide();
				jQuery('.mainmenu').hide();
				mobile_menu_show = 0;
				jQuery("#menu-btn").show();
			}
		});

		// header bottom setting begin
        var mq = window.matchMedia("(max-width: 993px)");
        if (mq.matches) {
            jQuery('.header-bottom').css("display", "block");
            jQuery('.header-bottom').css("top", "0");
        }
        // header bottom setting close
		
		init_de();
		video_autosize();
		
		jQuery('header').removeClass('smaller');		
		jQuery('header').removeClass('clone');		
	};	
	

	function init() {
		var sh = jQuery('#de-sidebar').css("height");
		var dh = jQuery(window).innerHeight();
		var h = parseInt(sh) - parseInt(dh);
		var header_height = parseInt(jQuery('header').height(), 10);
        var screen_height = parseInt(jQuery(window).height(), 10);
        var header_mt = screen_height - header_height;
        var mq = window.matchMedia("(min-width: 993px)");
        var ms = window.matchMedia("(min-width: 768px)");

        window.addEventListener('scroll', function(e){			
			if (mq.matches) {
				var distanceY = window.pageYOffset || document.documentElement.scrollTop,
                shrinkOn = 100,
                header = document.querySelector("header");
	            if (distanceY > shrinkOn) {
	                classie.add(header,"smaller");
	            } else {
	                if (classie.has(header,"smaller")) {
	                    classie.remove(header,"smaller");
	                }

	            }
	        }

	        if (mq.matches) {    
	            jQuery("header").addClass("clone", 1000, "easeOutBounce");
				
				// header autoshow on scroll begin
				var $document = $(document);
				var vscroll = 0;
				
				if ($document.scrollTop() >= 50 && vscroll == 0) {
					jQuery("header.autoshow").removeClass("scrollOff");
					jQuery("header.autoshow").addClass("scrollOn");
					jQuery("header.autoshow").css("height", "auto");
					vscroll = 1;
				} else {
					jQuery("header.autoshow").removeClass("scrollOn");
					jQuery("header.autoshow").addClass("scrollOff");
					vscroll = 0;
				}
				// header autoshow on scroll close

	            // header bottom on scroll begin
				var $document = $(document);
				var header_height = parseInt(jQuery('header').height(), 10);
				var screen_height = parseInt(jQuery(window).height(), 10);
				var header_mt = screen_height - header_height;

				if ($document.scrollTop() >= header_mt) {
					jQuery('.header-bottom').css("position", "fixed");
					jQuery('.header-bottom').css("top", "0");
				} else if ($document.scrollTop() <= header_mt) {
					jQuery('.header-bottom').css("position", "absolute");
					jQuery('.header-bottom').css("top", header_mt);
				}
                // header bottom on scroll close
			}

			if (mq.matches) {
				var sh = jQuery('#de-sidebar').css("height");
				var dh = jQuery(window).innerHeight();
				var h = parseInt(sh) - parseInt(dh);				
				if(jQuery("header").hasClass("side-header")){
					if(jQuery(document).scrollTop()>=h){
						jQuery('#de-sidebar').css("position","fixed");
						if(parseInt(sh)>parseInt(dh)){
							jQuery('#de-sidebar').css("top",-h);
						}			
						jQuery('#main').addClass("col-md-offset-3");										
					}else{
						jQuery('#de-sidebar').css("position","relative");
						if(parseInt(sh)>parseInt(dh)){
							jQuery('#de-sidebar').css("top",0);
						}	
						jQuery('#main').removeClass("col-md-offset-3");				
					}
				}			
			}
        });

		if (mq.matches) {
            jQuery('.header-bottom').css('position', 'absolute');
            jQuery('.header-bottom').css('top', header_mt);
        }
    }
    window.onload = init();	

	// --------------------------------------------------
	// owlCarousel
	// --------------------------------------------------

	jQuery("#gallery-carousel").owlCarousel({
	    items : 4,
	    navigation : false,
		pagination : false
    });
	
	jQuery(".carousel-gallery").owlCarousel({
	    items : 4,
	    navigation : false,
		pagination : false
    });
	
	jQuery("#blog-carousel").owlCarousel({
	    items : 2,
	    navigation : false,
		pagination : true,
		itemsDesktop : [1199,2],
		itemsDesktopSmall : [979,1],
		itemsTablet : [768, 1],
        itemsTabletSmall : false,
        itemsMobile : [479, 1]
    });
	
	jQuery("#contact-carousel").owlCarousel({
	    items : 1,
		singleItem:true,	
	    navigation : false,
		pagination : false,
		autoPlay : true
    });
	
	jQuery(".text-slider").owlCarousel({
	    items : 1,
		singleItem:true,	
	    navigation : false,
		pagination : false,
		mouseDrag : false,
		touchDrag : false,
		autoPlay : 4000,
		transitionStyle : "fade"
    });
	
	jQuery(".blog-slide").owlCarousel({
	    items : 1,
		singleItem:true,	
	    navigation : false,
		pagination : false,
		autoPlay : false
    });
	
	// Custom Navigation owlCarousel
	jQuery(".next").on("click", function() {
		$(this).parent().parent().find('.blog-slide').trigger('owl.next');
	});
	jQuery(".prev").on("click", function() {
		$(this).parent().parent().find('.blog-slide').trigger('owl.prev');
	});
	
	
	// --------------------------------------------------
	// custom positiion
	// --------------------------------------------------
	var $doc_height = jQuery(window).innerHeight(); 
	jQuery('#homepage #content.content-overlay').css("margin-top", $doc_height);
	jQuery('.full-height, #home').css("height", $doc_height);
	var picheight = jQuery('.center-y').css("height");
	picheight = parseInt(picheight, 10);
	jQuery('.center-y').css('margin-top', (($doc_height - picheight)/2)-90);
	jQuery('.full-height .de-video-container').css("height",$doc_height);

	
	// --------------------------------------------------	
	//  logo carousel hover
	jQuery("#logo-carousel img").on("mouseenter", function () {
	 	jQuery(this).fadeTo(150,.5);
	}).on("mouseleave", function () {
	 	jQuery(this).fadeTo(150,1);	 
  	})
	
	
	jQuery(window).load(function() {			
		video_autosize();		

		// --------------------------------------------------
		// filtering gallery
		// --------------------------------------------------
		
	
		jQuery('#filters a').on("click", function() {
			var $this = jQuery(this);
			if ( $this.hasClass('selected') ) {
				return false;
				}
			var $optionSet = $this.parents();
			$optionSet.find('.selected').removeClass('selected');
			$this.addClass('selected');
					
			var selector = jQuery(this).attr('data-filter');
			
			return false;
		});					

		// --------------------------------------------------
		// tabs
		// --------------------------------------------------
		jQuery('.de_tab').find('.de_tab_content div.de_tab_content_inner').hide();
		jQuery('.de_tab').find('.de_tab_content div.de_tab_content_inner:first').show();
		jQuery('li').find('.v-border').fadeTo(150,0);
		jQuery('li.active').find('.v-border').fadeTo(150,1);
		
		jQuery('.de_nav li').click(function() {
			jQuery(this).parent().find('li').removeClass("active");
			jQuery(this).addClass("active");
			jQuery(this).parent().parent().find('.v-border').fadeTo(150,0);
			jQuery(this).parent().parent().find('.de_tab_content div.de_tab_content_inner').hide();
		
			var indexer = jQuery(this).index(); //gets the current index of (this) which is #nav li
			jQuery(this).parent().parent().find('.de_tab_content div.de_tab_content_inner:eq(' + indexer + ')').fadeIn(); //uses whatever index the link has to open the corresponding box 
			jQuery(this).find('.v-border').fadeTo(150,1);
		});
		
		
		// --------------------------------------------------
		// toggle
		// --------------------------------------------------
		jQuery(".toggle-list h2").addClass("acc_active");
		jQuery(".toggle-list h2").toggle(
		function() {
		 jQuery(this).addClass("acc_noactive");
		 jQuery(this).next(".ac-content").slideToggle(200);
		},
		function() {
		 jQuery(this).removeClass("acc_noactive").addClass("acc_active");
		 jQuery(this).next(".ac-content").slideToggle(200);
		})
		
		var mb;
		
		// --------------------------------------------------
		// navigation for mobile
		// --------------------------------------------------
		
		jQuery('#menu-btn').on("click", function() {
			if(mobile_menu_show==0){
				jQuery('#mainmenu, .mainmenu').slideDown();
				mobile_menu_show = 1;
			}else{
				jQuery('#mainmenu, .mainmenu').slideUp();
				mobile_menu_show = 0;			
			}
		});
		
		// one page navigation
		  /**
		 * This part causes smooth scrolling using scrollto.js
		 * We target all a tags inside the nav, and apply the scrollto.js to it.
		 */
		
		jQuery("a.btn").click(function(evn){
			
			if (this.href.indexOf('#') != -1) {
			evn.preventDefault();
			jQuery('html,body').scrollTo(this.hash, this.hash); 
			}
		});
		
		jQuery('.de-gallery .item .icon-info').on("click", function() {
			jQuery('.page-overlay').show();
			url = jQuery(this).attr("data-value");
			
			jQuery("#loader-area .project-load").load(url, function() {
				jQuery("#loader-area").slideDown(500,function(){
					jQuery('.page-overlay').hide();
				jQuery('html, body').animate({
					scrollTop: jQuery('#loader-area').offset().top - 70
				}, 500, 'easeOutCirc');
											
				jQuery(".image-slider").owlCarousel({
					items : 1,
					singleItem:true,	
					navigation : false,
					pagination : true,
					autoPlay : false
				});
				
				jQuery(".container").fitVids();				
					jQuery('#btn-close-x').on("click", function() {
						jQuery("#loader-area").slideUp(500,function(){
							jQuery('html, body').animate({				
								scrollTop: jQuery('#section-portfolio').offset().top - 70
							}, 500, 'easeOutCirc');
						});
						return false;								
					});  				
				});			
			}); 
		});   
		
		jQuery('.de-gallery .item').on("click", function() {
			$('#navigation').show();
		});
			
		// --------------------------------------------------
		// custom page with background on side
		// --------------------------------------------------
		jQuery('.side-bg').each(function(){	
			jQuery(this).find(".image-container").css("height",jQuery(this).find(".image-container").parent().css("height"));
		});
			
		var target = jQuery('.center-y');
		var targetHeight = target.outerHeight();		
		jQuery(document).scroll(function(e){
			var scrollPercent = (targetHeight - window.scrollY) / targetHeight;
			if(scrollPercent >= 0){
				target.css('opacity', scrollPercent);
			}
		});		
	});

	
	// --------------------------------------------------
	// css animation
	// --------------------------------------------------
	var v_count = '0';
	jQuery(window).load(function() {				
		jQuery('.animated').fadeTo(0,0);
		jQuery('.animated').each(function(){
		var imagePos = jQuery(this).offset().top;
		var timedelay = jQuery(this).attr('data-delay');		
		var topOfWindow = jQuery(window).scrollTop();
			if (imagePos < topOfWindow+300) {
				jQuery(this).fadeTo(1,500);
				var $anim = jQuery(this).attr('data-animation');
			}
		});
		
		// btn arrow up
		jQuery(".arrow-up").on("click", function() {
			jQuery(".coming-soon .coming-soon-content").fadeOut("medium",function(){
				jQuery("#hide-content").fadeIn(600,function(){
					jQuery('.arrow-up').animate({'bottom': '-40px' },"slow");
					jQuery('.arrow-down').animate({'top': '0' },"slow");
				});
			});
		});
		
		// btn arrow down
		jQuery(".arrow-down").on("click", function() {
			jQuery("#hide-content").fadeOut("slow",function(){
				jQuery(".coming-soon .coming-soon-content").fadeIn(800,function(){
					jQuery('.arrow-up').animate({'bottom': '0px' },"slow");
					jQuery('.arrow-down').animate({'top': '-40' },"slow");
				});
			});
		});
		
		
	});
		
	jQuery(window).scroll(function() {		
		// --------------------------------------------------
		// counter
		// --------------------------------------------------
		
		jQuery('.timer').each(function(){
			var imagePos = jQuery(this).offset().top;			
			var topOfWindow = jQuery(window).scrollTop();
			if (imagePos < topOfWindow+500 && v_count=='0') {		
				jQuery(function ($) {
					// start all the timers
					jQuery('.timer').each(count);					  					  
					function count(options) {
						v_count = '1';
						var $this = jQuery(this);
						options = $.extend({}, options || {}, $this.data('countToOptions') || {});
						$this.countTo(options);
					}
				});				
			}
		});
		
		// --------------------------------------------------
		// progress bar
		// --------------------------------------------------
		jQuery('.de-progress').each(function(){
		var pos_y = jQuery(this).offset().top;
		var value = jQuery(this).find(".progress-bar").attr('data-value');
		
		var topOfWindow = jQuery(window).scrollTop();
			if (pos_y < topOfWindow+500) {		
				jQuery(this).find(".progress-bar").animate({'width': value },"slow");
			}
		});

		jQuery('.animated').each(function(){
		var imagePos = jQuery(this).offset().top;
		var timedelay = jQuery(this).attr('data-delay');
		
		var topOfWindow = jQuery(window).scrollTop();
			if (imagePos < topOfWindow+500) {		
				jQuery(this).delay(timedelay).queue(function(){
					jQuery(this).fadeTo(1,500);
					var $anim = jQuery(this).attr('data-animation');
					jQuery(this).addClass($anim).clearQueue();
				});
				
			}
		});
		
		jQuery(".nav-exit").on("click", function() {
			$.magnificPopup.close();
		});			
	});
	
	// --------------------------------------------------
	// magnificPopup
	// --------------------------------------------------
	
	jQuery('.simple-ajax-popup-align-top').magnificPopup({
        type: 'ajax',
        alignTop: true,
        overflowY: 'scroll',
		fixedContentPos: true,
		callbacks: {
			beforeOpen: function() { $('html').addClass('mfp-helper'); },
			close: function() { $('html').removeClass('mfp-helper'); }
		},
		gallery: {
			enabled: true
		},
    });

    jQuery('.simple-ajax-popup').magnificPopup({
        type: 'ajax'
    });
	
	// zoom gallery
	jQuery('.zoom-gallery').magnificPopup({
		delegate: 'a',
		type: 'image',
		closeOnContentClick: false,
		closeBtnInside: false,
		mainClass: 'mfp-with-zoom mfp-img-mobile',
		image: {
			verticalFit: true,
			titleSrc: function(item) {
				return item.el.attr('title');
				//return item.el.attr('title') + ' &middot; <a class="image-source-link" href="'+item.el.attr('data-source')+'" target="_blank">image source</a>';
			}
		},
		gallery: {
			enabled: true
		},
		zoom: {
			enabled: true,
			duration: 300, // don't foget to change the duration also in CSS
			opener: function(element) {
				return element.find('img');
			}
		}
		
	});
	
	// popup youtube, video, gmaps	
	jQuery('.popup-youtube, .popup-vimeo, .popup-gmaps').magnificPopup({
		disableOn: 700,
		type: 'iframe',
		mainClass: 'mfp-fade',
		removalDelay: 160,
		preloader: false,
		fixedContentPos: false
	});
	
	// image popup	
	jQuery('.image-popup-vertical-fit').magnificPopup({
		type: 'image',
		closeOnContentClick: true,
		mainClass: 'mfp-img-mobile',
		image: {
			verticalFit: true
		}
		
	});

	jQuery('.image-popup-fit-width').magnificPopup({
		type: 'image',
		closeOnContentClick: true,
		image: {
			verticalFit: false
		}
	});

	jQuery('.image-popup-no-margins').magnificPopup({
		type: 'image',
		closeOnContentClick: true,
		closeBtnInside: false,
		fixedContentPos: true,
		mainClass: 'mfp-no-margins mfp-with-zoom', // class to remove default margin from left and right side
		image: {
			verticalFit: true
		},
		zoom: {
			enabled: true,
			duration: 300 // don't foget to change the duration also in CSS
		}
	});
	
	jQuery('.image-popup-gallery').magnificPopup({
		type: 'image',
		closeOnContentClick: false,
		closeBtnInside: false,
		mainClass: 'mfp-with-zoom mfp-img-mobile',
		image: {
			verticalFit: true,
			titleSrc: function(item) {
				return item.el.attr('title');
				//return item.el.attr('title') + ' &middot; <a class="image-source-link" href="'+item.el.attr('data-source')+'" target="_blank">image source</a>';
			}
		},
		gallery: {
			enabled: true
		}		
	});

	jQuery('.image-link, .video-link').magnificPopup({
	    callbacks: {
	      elementParse: function(item) {
	         // the class name
	         if(item.el.context.className == 'video-link') {
	           item.type = 'iframe';
	         } else {
	           item.type = 'image';
	         }
	      }
	    },
	    gallery:{
	    	enabled:true
	    },
	    type: 'image',
	    closeOnContentClick: false,
		closeBtnInside: false,
		mainClass: 'mfp-with-zoom mfp-img-mobile',
		image: {
			verticalFit: true,
			titleSrc: function(item) {
				return item.el.attr('title');
				//return item.el.attr('title') + ' &middot; <a class="image-source-link" href="'+item.el.attr('data-source')+'" target="_blank">image source</a>';
			}
		},
	});
	
	// mainmenu create span
	jQuery('#mainmenu > li > a').each(function(){	
		if($(this).next("ul").length > 0)  {
		$("<span></span>").insertAfter($(this));
		}
	});
	
	jQuery('#mainmenu > li > ul > li > a').each(function(){	
		if($(this).next("ul").length > 0)  {
		$("<span></span>").insertAfter($(this));
		}
	});

	// mainmenu arrow click
    jQuery("#mainmenu > li > span, #mainmenu > li > ul > li > span").on( "click", function() {
		$('header').css("height","auto");
        var iteration = $(this).data('iteration') || 1;
        switch (iteration) {
            case 1:
				$(this).addClass("active");
                $(this).next("ul").css("height","auto");
				var curHeight = $(this).next("ul").height();
				$(this).next("ul").css("height","0");
				$(this).next("ul").animate({'height': curHeight},400,'easeInOutQuint');
				
				break;

            case 2:
				$(this).removeClass("active");
                $(this).next("ul").animate({'height': "0"},400,'easeInOutQuint');
				break;
        }
        iteration++;
        if (iteration > 2) iteration = 1;
        $(this).data('iteration', iteration);
    });

	if ($('#back-to-top').length) {
	    var scrollTrigger = 500, // px
	        backToTop = function () {
	            var scrollTop = $(window).scrollTop();
	            if (scrollTop > scrollTrigger) {
	                $('#back-to-top').addClass('show');
	            } else {
	                $('#back-to-top').removeClass('show');
	            }
	        };
	    backToTop();
	    $(window).on('scroll', function () {
	        backToTop();
	    });
	    $('#back-to-top').on('click', function (e) {
	        e.preventDefault();
	        $('html,body').animate({
	            scrollTop: 0
	        }, 700);
	    });
		
		$("section,div").css('background-color', function () {
			return jQuery(this).data('bgcolor');
		});
		
		$("div").css('background-image', function () {
			return jQuery(this).data('bgimage');
		});
		
    }

    //Home YouTube Video
	jQuery(".player").mb_YTPlayer();

	//Home fit screen			
	$(function(){"use strict";
		$('#home-sec').css({'height':($(window).height())+'px'});
		$(window).resize(function(){
		$('#home-sec').css({'height':($(window).height())+'px'});
		});
	});	

	$(function () {
		"use strict";
        // jquery typed plugin
        $(".typed").typed({
            stringsElement: $('.typed-strings'),
            typeSpeed: 100,
            backDelay: 1500,
            loop: true,
            contentType: 'html', // or text
            // defaults to false for infinite loop
            loopCount: false,
            callback: function () { null; },
            resetCallback: function () { newTyped(); }
        });
    });
	
});

