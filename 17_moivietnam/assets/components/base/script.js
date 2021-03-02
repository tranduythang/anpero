'use strict';

/**
 * Wrapper to eliminate json errors
 * @param {string} str - JSON string
 * @returns {object} - parsed or empty object
 */
function parseJSON ( str ) {
	try {
		if ( str )  return JSON.parse( str );
		else return {};
	} catch ( error ) {
		//{DEL DIST BUILDER}
		console.warn( error );
		//{DEL}
		return {};
	}
}


// Global components list
let components = window.components = {};

components.pageReveal = {
	selector: '.page',
	init: function( nodes ) {
		window.addEventListener( 'components:ready', function () {
			window.dispatchEvent( new Event( 'resize' ) );
			document.documentElement.classList.add( 'components-ready' );

			nodes.forEach( function( node ) {
				setTimeout( function() {
					node.classList.add( 'page-revealed' );
				}, 500 );
			});
		}, { once: true } );
	}
};

components.currentDevice = {
	selector: 'html',
	script: '/assets/components/current-device/current-device.min.js'
};

components.grid = {
	selector: '.container, .container-fluid, .row, [class*="col-"]',
	styles: '/assets/components/grid/grid.css'
};

components.section = {
	selector: 'section',
	styles: '/assets/components/section/section.css'
};

components.templateInfo = {
	selector: '.template-info',
	styles: '/assets/components/template-info/template-info.css'
};

components.textDivider = {
	selector: '.text-divider',
	styles: '/assets/components/text-divider/text-divider.css'
};

components.textDecorated = {
	selector: '.text-decorated',
	styles: '/assets/components/text-decorated/text-decorated.css'
};

components.link = {
	selector: '.link',
	styles: [
		'/assets/components/link/link.css',
		'/assets/components/mdi/mdi.css'
	]
};

components.fontCantataOne = {
	selector: 'html',
	styles: 'https://fonts.googleapis.com/css?family=Cantata+One&display=swap'
};

components.fontSpartan = {
	selector: 'html',
	styles: 'https://fonts.googleapis.com/css?family=Spartan:300,400,500,600,700&display=swap'
};

components.fontLinearicons = {
	selector: '[class*="linearicons-"], [class*=" linearicons-"]',
	styles: '/assets/components/linearicons/linearicons.css'
};

components.fontThinicons = {
	selector: '[class*="thin-icon-"], [class*=" thin-icon-"]',
	styles: '/assets/components/thinicons/thin.css'
};

components.preloader = {
	selector: '.preloader',
	styles:   '/assets/components/preloader/preloader.css'
};

components.fontAwesome = {
	selector: '[class*="fa-"]',
	styles: '/assets/components/font-awesome/font-awesome.css'
};

components.mdi = {
	selector: '[class*="mdi-"]',
	styles: '/assets/components/mdi/mdi.css'
};

components.list = {
	selector: '.list',
	styles: '/assets/components/list/list.css'
};

components.icon = {
	selector: '.icon',
	styles: '/assets/components/icon/icon.css'
};

components.quote = {
	selector: '.quote',
	styles: '/assets/components/quote/quote.css'
};

components.pageTitle = {
	selector: '.page-title',
	styles: '/assets/components/page-title/page-title.css'
};

components.blurb = {
	selector: '.blurb',
	styles: '/assets/components/blurb/blurb.css'
};

components.rights = {
	selector: '.rights',
	styles: '/assets/components/rights/rights.css'
};

components.imageBlock = {
	selector: '.image-block',
	styles: '/assets/components/image-block/image-block.css'
};

components.image = {
	selector: '.image',
	styles: '/assets/components/image/image.css'
};

components.person = {
	selector: '.person',
	styles: [
		'/assets/components/person/person.css',
		'/assets/components/mdi/mdi.css'
	]
};

components.thumbnail = {
	selector: '.thumbnail',
	styles: [
		'/assets/components/thumbnail/thumbnail.css',
		'/assets/components/mdi/mdi.css'
	]
};

components.intro = {
	selector: '.intro',
	styles: '/assets/components/intro/intro.css'
};

components.input = {
	selector: '.form-group, .input-group, .form-check, .custom-control, .form-control',
	styles: '/assets/components/input/input.css'
};

components.button = {
	selector: '.btn',
	styles: '/assets/components/button/button.css'
};

components.divider = {
	selector: '.divider',
	styles: '/assets/components/divider/divider.css'
};

components.snackbar = {
	selector: '.snackbar',
	styles: '/assets/components/snackbar/snackbar.css'
};

components.address = {
	selector: '.address',
	styles: '/assets/components/address/address.css'
};

components.table = {
	selector: '.table',
	styles: '/assets/components/table/table.css'
};

components.post = {
	selector: '.post',
	styles: '/assets/components/post/post.css'
};

components.video = {
	selector: '.video',
	styles: '/assets/components/video/video.css'
};

components.pagination = {
	selector: '.pagination, .pag',
	styles: '/assets/components/pagination/pagination.css'
};

components.widget = {
	selector: '.widget',
	styles: '/assets/components/widget/widget.css'
};

components.tag = {
	selector: '.tag',
	styles: '/assets/components/tag/tag.css'
};

components.blogPost = {
	selector: '.blog-post',
	styles: '/assets/components/blog-post/blog-post.css'
};

components.product = {
	selector: '.product',
	styles: '/assets/components/product/product.css'
};

components.productOverview = {
	selector: '.product-overview',
	styles: '/assets/components/product-overview/product-overview.css'
};

components.termList = {
	selector: '.term-list',
	styles: '/assets/components/term-list/term-list.css'
};

components.tab = {
	selector: '.tab',
	styles: '/assets/components/tab/tab.css'
};

components.rating = {
	selector: '.rating',
	styles: '/assets/components/rating/rating.css'
};

components.logo = {
	selector: '.logo',
	styles: '/assets/components/logo/logo.css'
};

components.serviceSection = {
	selector: '.service-section',
	styles: '/assets/components/service-section/service-section.css'
};

components.footer = {
	selector: 'footer',
	styles: '/assets/components/footer/footer.css'
};

components.line = {
	selector: '.line',
	styles: '/assets/components/line/line.css'
};

components.counter = {
	selector: '[data-counter]',
	styles: '/assets/components/counter/counter.css',
	script: [
		'/assets/components/util/util.min.js',
		'/assets/components/counter/counter.min.js',
	],
	init: function ( nodes ) {
		let observer = new IntersectionObserver( function ( entries ) {
			let observer = this;

			entries.forEach( function ( entry ) {
				let node = entry.target;

				if ( entry.isIntersecting ) {
					node.counter.run();
					observer.unobserve( node );
				}
			});
		}, {
			rootMargin: '0px',
			threshold: 1.0
		});

		nodes.forEach( function ( node ) {
			let counter = aCounter( Object.assign( {
				node: node,
				duration: 1000
			}, parseJSON( node.getAttribute( 'data-counter' ) ) ) );

			if ( window.xMode ) {
				counter.run();
			} else {
				observer.observe( node );
			}
		})
	}
};

components.progressLinear = {
	selector: '.progress-linear',
	styles: '/assets/components/progress-linear/progress-linear.css',
	script: [
		'/assets/components/util/util.min.js',
		'/assets/components/counter/counter.min.js'
	],
	init: function ( nodes ) {
		let observer = new IntersectionObserver( function ( entries ) {
			let observer = this;

			entries.forEach( function ( entry ) {
				let node = entry.target;

				if ( entry.isIntersecting ) {
					node.counter.run();
					observer.unobserve( node );
				}
			});
		}, {
			rootMargin: '0px',
			threshold: 1.0
		});

		nodes.forEach( function ( node ) {
			let
					bar = node.querySelector( '.progress-linear-bar' ),
					counter = node.counter = aCounter({
						node: node.querySelector( '.progress-linear-counter' ),
						duration: 500,
						onStart: function ( value ) {
							bar.style.width = this.params.to +'%';
						}
					});

			if ( window.xMode ) {
				counter.run();
			} else {
				observer.observe( node );
			}
		});
	}
};

components.progressCircle = {
	selector: '.progress-circle',
	styles: '/assets/components/progress-circle/progress-circle.css',
	script: [
		'/assets/components/util/util.min.js',
		'/assets/components/counter/counter.min.js',
		'/assets/components/progress-circle/progress-circle.min.js'
	],
	init: function ( nodes ) {
		let observer = new IntersectionObserver( function ( entries ) {
			let observer = this;

			entries.forEach( function ( entry ) {
				let node = entry.target;

				if ( entry.isIntersecting ) {
					node.counter.run();
					observer.unobserve( node );
				}
			});
		}, {
			rootMargin: '0px',
			threshold: 1.0
		});

		nodes.forEach( function ( node ) {
			let
					progress = aProgressCircle({
						node: node.querySelector( '.progress-circle-bar' )
					}),
					counter = node.counter = aCounter({
						node: node.querySelector( '.progress-circle-counter' ),
						duration: 500,
						onUpdate: function ( value ) {
							progress.render( value * 3.6 );
						}
					});

			if ( window.xMode ) {
				counter.run();
			} else {
				observer.observe( node );
			}
		});
	}
};

components.countdown = {
	selector: '[ data-countdown ]',
	styles: '/assets/components/countdown/countdown.css',
	script: [
		'/assets/components/util/util.min.js',
		'/assets/components/progress-circle/progress-circle.min.js',
		'/assets/components/countdown/countdown.min.js'
	],
	init: function ( nodes ) {
		nodes.forEach( function ( node ) {
			aCountdown( Object.assign( {
				node:  node,
				tick:  100
			}, parseJSON( node.getAttribute( 'data-countdown' ) ) ) );
		} )
	}
};

components.owl = {
	selector: '.owl-carousel',
	styles: [
		'/assets/components/owl-carousel/owl.carousel.css',
		'/assets/components/mdi/mdi.css'
	],
	script: [
		'/assets/components/jquery/jquery-3.4.1.min.js',
		'/assets/components/owl-carousel/owl.carousel.min.js',
		'/assets/components/util/util.min.js'
	],
	init: function ( nodes ) {
		nodes.forEach( function ( node ) {
			let
					params = parseJSON( node.getAttribute( 'data-owl' ) ),
					defaults = {
						items: 1,
						margin: 30,
						loop: false,
						mouseDrag: true,
						stagePadding: 0,
						nav: false,
						navText: [],
						dots: false,
						autoplay: true,
						autoplayHoverPause: true
					},
					xMode = {
						autoplay: false,
						loop: false,
						mouseDrag: false
					},
					generated = {
						autoplay: node.getAttribute( 'data-autoplay' ) !== 'false',
						loop: node.getAttribute( 'data-loop' ) !== 'false',
						mouseDrag: node.getAttribute( 'data-mouse-drag' ) !== 'false',
						responsive: {}
					},
					aliaces = [ '-', '-sm-', '-md-', '-lg-', '-xl-', '-xxl-' ],
					values =  [ 0, 576, 768, 992, 1200, 1600 ],
					responsive = generated.responsive;

			for ( let j = 0; j < values.length; j++ ) {
				responsive[ values[ j ] ] = {};

				for ( let k = j; k >= -1; k-- ) {
					if ( !responsive[ values[ j ] ][ 'items' ] && node.getAttribute( 'data' + aliaces[ k ] + 'items' ) ) {
						responsive[ values[ j ] ][ 'items' ] = k < 0 ? 1 : parseInt( node.getAttribute( 'data' + aliaces[ k ] + 'items' ), 10 );
					}
					if ( !responsive[ values[ j ] ][ 'stagePadding' ] && responsive[ values[ j ] ][ 'stagePadding' ] !== 0 && node.getAttribute( 'data' + aliaces[ k ] + 'stage-padding' ) ) {
						responsive[ values[ j ] ][ 'stagePadding' ] = k < 0 ? 0 : parseInt( node.getAttribute( 'data' + aliaces[ k ] + 'stage-padding' ), 10 );
					}
					if ( !responsive[ values[ j ] ][ 'margin' ] && responsive[ values[ j ] ][ 'margin' ] !== 0 && node.getAttribute( 'data' + aliaces[ k ] + 'margin' ) ) {
						responsive[ values[ j ] ][ 'margin' ] = k < 0 ? 30 : parseInt( node.getAttribute( 'data' + aliaces[ k ] + 'margin' ), 10 );
					}
				}
			}

			node.owl = $( node );
			$( node ).owlCarousel( Util.merge( window.xMode ? [ defaults, params, generated, xMode ] : [ defaults, params, generated ] ) );
		});
	}
};

components.regula = {
	selector: '[data-constraints]',
	styles: '/assets/components/regula/regula.css',
	script: [
		'/assets/components/jquery/jquery-3.4.1.min.js',
		'/assets/components/regula/regula.min.js'
	],
	init: function ( nodes ) {
		let elements = $( nodes );

		// Custom validator - phone number
		regula.custom({
			name: 'PhoneNumber',
			defaultMessage: 'Invalid phone number format',
			validator: function() {
				if ( this.value === '' ) return true;
				else return /^(\+\d)?[0-9\-\(\) ]{5,}$/i.test( this.value );
			}
		});

		for (let i = 0; i < elements.length; i++) {
			let o = $(elements[i]), v;
			o.addClass("form-control-has-validation").after("<span class='form-validation'></span>");
			v = o.parent().find(".form-validation");
			if (v.is(":last-child")) o.addClass("form-control-last-child");
		}

		elements.on('input change propertychange blur', function (e) {
			let $this = $(this), results;

			if (e.type !== "blur") if (!$this.parent().hasClass("has-error")) return;
			if ($this.parents('.rd-mailform').hasClass('success')) return;

			if (( results = $this.regula('validate') ).length) {
				for (let i = 0; i < results.length; i++) {
					$this.siblings(".form-validation").text(results[i].message).parent().addClass("has-error");
				}
			} else {
				$this.siblings(".form-validation").text("").parent().removeClass("has-error")
			}
		}).regula('bind');

		let regularConstraintsMessages = [
			{
				type: regula.Constraint.Required,
				newMessage: "The text field is required."
			},
			{
				type: regula.Constraint.Email,
				newMessage: "The email is not a valid email."
			},
			{
				type: regula.Constraint.Numeric,
				newMessage: "Only numbers are required"
			},
			{
				type: regula.Constraint.Selected,
				newMessage: "Please choose an option."
			}
		];


		for (let i = 0; i < regularConstraintsMessages.length; i++) {
			let regularConstraint = regularConstraintsMessages[i];

			regula.override({
				constraintType: regularConstraint.type,
				defaultMessage: regularConstraint.newMessage
			});
		}
	}
};

components.rdForm = {
	selector: '.rd-form',
	styles: '/assets/components/rd-form/rd-form.css'
};

components.rdMailform = {
	selector: '.rd-mailform',
	styles: [
		'/assets/components/rd-mailform/rd-mailform.css',
		'/assets/components/font-awesome/font-awesome.css',
		'/assets/components/mdi/mdi.css'
	],
	script: [
		'/assets/components/jquery/jquery-3.4.1.min.js',
		'/assets/components/rd-mailform/rd-mailform.min.js',
	],
	init: function ( nodes ) {
		let i, j, k,
				$captchas = $( nodes ).find( '.recaptcha' ),
				msg = {
					'MF000': 'Successfully sent!',
					'MF001': 'Recipients are not set!',
					'MF002': 'Form will not work locally!',
					'MF003': 'Please, define email field in your form!',
					'MF004': 'Please, define type of your form!',
					'MF254': 'Something went wrong with PHPMailer!',
					'MF255': 'Aw, snap! Something went wrong.'
				};

		if ( $captchas.length ) {
			$.getScript("//www.google.com/recaptcha/api.js?onload=onloadCaptchaCallback&render=explicit&hl=en");
		}

		/**
		 * @desc Check if all elements pass validation
		 * @param {object} elements - object of items for validation
		 * @param {object} captcha - captcha object for validation
		 * @return {boolean}
		 */
		function isValidated(elements, captcha) {
			let results, errors = 0;

			if (elements.length) {
				for (let j = 0; j < elements.length; j++) {

					let $input = $(elements[j]);
					if ((results = $input.regula('validate')).length) {
						for (k = 0; k < results.length; k++) {
							errors++;
							$input.siblings(".form-validation").text(results[k].message).parent().addClass("has-error");
						}
					} else {
						$input.siblings(".form-validation").text("").parent().removeClass("has-error")
					}
				}

				if (captcha) {
					if (captcha.length) {
						return validateReCaptcha(captcha) && errors === 0
					}
				}

				return errors === 0;
			}
			return true;
		}

		/**
		 * @desc Validate google reCaptcha
		 * @param {object} captcha - captcha object for validation
		 * @return {boolean}
		 */
		function validateReCaptcha(captcha) {
			let captchaToken = captcha.find('.g-recaptcha-response').val();

			if (captchaToken.length === 0) {
				captcha
				.siblings('.form-validation')
				.html('Please, prove that you are not robot.')
				.addClass('active');
				captcha
				.closest('.form-wrap')
				.addClass('has-error');

				captcha.on('propertychange', function () {
					let $this = $(this),
							captchaToken = $this.find('.g-recaptcha-response').val();

					if (captchaToken.length > 0) {
						$this
						.closest('.form-wrap')
						.removeClass('has-error');
						$this
						.siblings('.form-validation')
						.removeClass('active')
						.html('');
						$this.off('propertychange');
					}
				});

				return false;
			}

			return true;
		}

		/**
		 * @desc Initialize Google reCaptcha
		 */
		window.onloadCaptchaCallback = function () {
			for (let i = 0; i < $captchas.length; i++) {
				let
						$captcha = $($captchas[i]),
						resizeHandler = (function() {
							let
									frame = this.querySelector( 'iframe' ),
									inner = this.firstElementChild,
									inner2 = inner.firstElementChild,
									containerRect = null,
									frameRect = null,
									scale = null;

							inner2.style.transform = '';
							inner.style.height = 'auto';
							inner.style.width = 'auto';

							containerRect = this.getBoundingClientRect();
							frameRect = frame.getBoundingClientRect();
							scale = containerRect.width/frameRect.width;

							if ( scale < 1 ) {
								inner2.style.transform = 'scale('+ scale +')';
								inner.style.height = ( frameRect.height * scale ) + 'px';
								inner.style.width = ( frameRect.width * scale ) + 'px';
							}
						}).bind( $captchas[i] );

				grecaptcha.render(
						$captcha.attr('id'),
						{
							sitekey: $captcha.attr('data-sitekey'),
							size: $captcha.attr('data-size') ? $captcha.attr('data-size') : 'normal',
							theme: $captcha.attr('data-theme') ? $captcha.attr('data-theme') : 'light',
							callback: function () {
								$('.recaptcha').trigger('propertychange');
							}
						}
				);

				$captcha.after("<span class='form-validation'></span>");

				if ( $captchas[i].hasAttribute( 'data-auto-size' ) ) {
					resizeHandler();
					window.addEventListener( 'resize', resizeHandler );
				}
			}
		};

		for ( i = 0; i < nodes.length; i++ ) {
			let
					$form = $(nodes[i]),
					formHasCaptcha = false;

			$form.attr('novalidate', 'novalidate').ajaxForm({
				data: {
					"form-type": $form.attr("data-form-type") || "contact",
					"counter": i
				},
				beforeSubmit: function (arr, $form, options) {
					if ( window.xMode ) return;

					let
							form = $(nodes[this.extraData.counter]),
							inputs = form.find("[data-constraints]"),
							output = $("#" + form.attr("data-form-output")),
							captcha = form.find('.recaptcha'),
							captchaFlag = true;

					output.removeClass("active error success");

					if (isValidated(inputs, captcha)) {

						// veify reCaptcha
						if (captcha.length) {
							let captchaToken = captcha.find('.g-recaptcha-response').val(),
									captchaMsg = {
										'CPT001': 'Please, setup you "site key" and "secret key" of reCaptcha',
										'CPT002': 'Something wrong with google reCaptcha'
									};

							formHasCaptcha = true;

							$.ajax({
								method: "POST",
								url: "components/rd-mailform/reCaptcha.php",
								data: {'g-recaptcha-response': captchaToken},
								async: false
							})
							.done(function (responceCode) {
								if (responceCode !== 'CPT000') {
									if (output.hasClass("snackbar")) {
										output.html('<div class="snackbar-inner"><div class="snackbar-title"><span class="icon snackbar-icon mdi-check"></span>'+ captchaMsg[responceCode] +'</div></div>');

										setTimeout(function () {
											output.removeClass("active");
										}, 3500);

										captchaFlag = false;
									} else {
										output.html(captchaMsg[responceCode]);
									}

									output.addClass("active");
								}
							});
						}

						if (!captchaFlag) {
							return false;
						}

						form.addClass('form-in-process');

						if (output.hasClass("snackbar")) {
							output.html('<div class="snackbar-inner"><div class="snackbar-title"><span class="icon snackbar-icon fa-circle-o-notch fa-spin"></span>Sending</div></div>');
							output.addClass("active");
						}
					} else {
						return false;
					}
				},
				error: function (result) {
					if ( window.xMode ) return;

					let
							output = $("#" + $(nodes[this.extraData.counter]).attr("data-form-output")),
							form = $(nodes[this.extraData.counter]);

					output.text(msg[result]);
					form.removeClass('form-in-process');

					if (formHasCaptcha) {
						grecaptcha.reset();
					}
				},
				success: function (result) {
					if ( window.xMode ) return;

					let
							form = $(nodes[this.extraData.counter]),
							output = $("#" + form.attr("data-form-output")),
							select = form.find('select');

					form
					.addClass('success')
					.removeClass('form-in-process');

					if (formHasCaptcha) {
						grecaptcha.reset();
					}

					result = result.length === 5 ? result : 'MF255';
					output.text(msg[result]);

					if (result === "MF000") {
						if (output.hasClass("snackbar")) {
							output.html('<div class="snackbar-inner"><div class="snackbar-title"><span class="icon snackbar-icon mdi-check"></span>'+ msg[result] +'</div></div>');
						} else {
							output.addClass("active success");
						}
					} else {
						if (output.hasClass("snackbar")) {
							output.html('<div class="snackbar-inner"><div class="snackbar-title"><span class="icon snackbar-icon mdi-warning"></span>'+ msg[result] +'</div></div>');
						} else {
							output.addClass("active error");
						}
					}

					form.clearForm();

					if (select.length) {
						select.select2("val", "");
					}

					form.find('input, textarea').trigger('blur');

					setTimeout(function () {
						output.removeClass("active error success");
						form.removeClass('success');
					}, 3500);
				}
			});
		}
	}
};

components.campaignMonitor = {
	selector: '.campaign-mailform',
	styles: '/assets/components/rd-mailform/rd-mailform.css',
	script: '/assets/components/jquery/jquery-3.4.1.min.js',
	init: function ( nodes ) {
		/**
		 * @desc Check if all elements pass validation
		 * @param {object} elements - object of items for validation
		 * @param {object} captcha - captcha object for validation
		 * @return {boolean}
		 */
		function isValidated(elements, captcha) {
			let results, errors = 0;

			if (elements.length) {
				for (let j = 0; j < elements.length; j++) {

					let $input = $(elements[j]);
					if ((results = $input.regula('validate')).length) {
						for (let k = 0; k < results.length; k++) {
							errors++;
							$input.siblings(".form-validation").text(results[k].message).parent().addClass("has-error");
						}
					} else {
						$input.siblings(".form-validation").text("").parent().removeClass("has-error")
					}
				}

				if (captcha) {
					if (captcha.length) {
						return validateReCaptcha(captcha) && errors === 0
					}
				}

				return errors === 0;
			}
			return true;
		}

		let $nodes = $(nodes);

		for ( let i = 0; i < $nodes.length; i++ ) {
			let $campaignItem = $($nodes[i]);

			$campaignItem.on('submit', $.proxy(function (e) {
				e.preventDefault();

				let data = {},
						url = this.attr('action'),
						dataArray = this.serializeArray(),
						$output = $("#" + $nodes.attr("data-form-output")),
						$this = $(this);

				for ( let i = 0; i < dataArray.length; i++) {
					data[dataArray[i].name] = dataArray[i].value;
				}

				$.ajax({
					data: data,
					url: url,
					dataType: 'jsonp',
					error: function (resp, text) {
						$output.html('Server error: ' + text);

						setTimeout(function () {
							$output.removeClass("active");
						}, 4000);
					},
					success: function (resp) {
						$output.html(resp.Message).addClass('active');

						setTimeout(function () {
							$output.removeClass("active");
						}, 6000);
					},
					beforeSend: function (data) {
						// Stop request if inputs are invalid
						if ( window.xMode || !isValidated( $this.find( '[data-constraints]' ) ) )
							return false;

						$output.html('Submitting...').addClass('active');
					}
				});

				// Clear inputs after submit
				let inputs = $this[0].getElementsByTagName('input');
				for (let i = 0; i < inputs.length; i++) {
					inputs[i].value = '';
					let label = document.querySelector( '[for="'+ inputs[i].getAttribute( 'id' ) +'"]' );
					if( label ) label.classList.remove( 'focus', 'not-empty' );
				}

				return false;
			}, $campaignItem));
		}
	}
};

components.mailchimp = {
	selector: '.mailchimp-mailform',
	styles: '/assets/components/rd-mailform/rd-mailform.css',
	script: '/assets/components/jquery/jquery-3.4.1.min.js',
	init: function ( nodes ) {
		let $nodes = $( nodes );

		for ( let i = 0; i < $nodes.length; i++ ) {
			let
					$mailchimpItem = $($nodes[i]),
					$email = $mailchimpItem.find('input[type="email"]');

			// Required by MailChimp
			$mailchimpItem.attr('novalidate', 'true');
			$email.attr('name', 'EMAIL');

			$mailchimpItem.on('submit', $.proxy( function ( $email, event ) {
				event.preventDefault();

				let
						$this = this,
						data = {},
						url = $this.attr('action').replace('/post?', '/post-json?').concat('&c=?'),
						dataArray = $this.serializeArray(),
						$output = $("#" + $this.attr("data-form-output"));

				for ( let i = 0; i < dataArray.length; i++ ) {
					data[dataArray[i].name] = dataArray[i].value;
				}

				$.ajax({
					data: data,
					url: url,
					dataType: 'jsonp',
					error: function (resp, text) {
						$output.html('Server error: ' + text);

						setTimeout(function () {
							$output.removeClass("active");
						}, 4000);
					},
					success: function (resp) {
						$output.html(resp.msg).addClass('active');
						$email[0].value = '';
						var $label = $('[for="'+ $email.attr( 'id' ) +'"]');
						if ( $label.length ) $label.removeClass( 'focus not-empty' );

						setTimeout(function () {
							$output.removeClass("active");
						}, 6000);
					},
					beforeSend: function (data) {
						var isValidated = (function () {
							var results, errors = 0;
							var elements = $this.find('[data-constraints]');
							var captcha = null;
							if (elements.length) {
								for (var j = 0; j < elements.length; j++) {

									var $input = $(elements[j]);
									if ((results = $input.regula('validate')).length) {
										for (var k = 0; k < results.length; k++) {
											errors++;
											$input.siblings(".form-validation").text(results[k].message).parent().addClass("has-error");
										}
									} else {
										$input.siblings(".form-validation").text("").parent().removeClass("has-error")
									}
								}

								if (captcha) {
									if (captcha.length) {
										return validateReCaptcha(captcha) && errors === 0
									}
								}

								return errors === 0;
							}
							return true;
						})();

						// Stop request if builder or inputs are invalid
						if ( window.xMode || !isValidated ) return false;

						$output.html('Submitting...').addClass('active');
					}
				});

				return false;
			}, $mailchimpItem, $email ));
		}
	}
};

components.select2 = {
	selector: '.select2',
	styles: '/assets/components/select2/select2.css',
	script: [
		'/assets/components/jquery/jquery-3.4.1.min.js',
		'/assets/components/select2/select2.min.js'
	],
	init: function ( nodes ) {
		nodes.forEach( function ( node ) {
			let
					params = parseJSON( node.getAttribute( 'data-select2-options' ) ),
					defaults = {
						dropdownParent: $( '.page' ),
						minimumResultsForSearch: Infinity
					};

			$( node ).select2( $.extend( defaults, params ) );
		});
	}
};

components.lightgallery = {
	selector: '[data-lightgallery]',
	styles: '/assets/components/lightgallery/lightgallery.css',
	script: [
		'/assets/components/jquery/jquery-3.4.1.min.js',
		'/assets/components/lightgallery/lightgallery.min.js',
		'/assets/components/util/util.min.js'
	],
	init: function ( nodes ) {
		if ( !window.xMode ) {
			nodes.forEach( function ( node ) {
				node = $( node );
				let
						defaults = {
							thumbnail: true,
							selector: '.lightgallery-item',
							youtubePlayerParams: {
								modestbranding: 1,
								showinfo: 0,
								rel: 0,
								controls: 0
							},
							vimeoPlayerParams: {
								byline : 0,
								portrait : 0,
								color : 'A90707'
							}
						},
						options = parseJSON( node.attr( 'data-lightgallery' ) );

				node.lightGallery( Util.merge( [ defaults, options ] ) );
			});
		}
	}
};

components.rdSearch = {
	selector: '[data-rd-search]',
	styles: '/assets/components/rd-search/rd-search.css',
	script: '/assets/components/rd-search/rd-search.js',
	init: function ( nodes ) {
		nodes.forEach( function ( node ) {
			new RDSearch( Object.assign( {
				form: node,
				handler: 'components/rd-search/rd-search.php',
				output: '.rd-search-results'
			}, parseJSON( node.getAttribute( 'data-rd-search' ) ) ) );
		});
	}
};

components.rdRange = {
	selector: '.rd-range',
	styles: '/assets/components/rd-range/rd-range.css',
	script: [
		'/assets/components/jquery/jquery-3.4.1.min.js',
		'/assets/components/rd-range/rd-range.min.js'
	],
	init: function ( nodes ) {
		nodes.forEach( function ( node ) {
			$( node ).RDRange({});
		});
	}
};

components.spinner = {
	selector: '[data-spinner]',
	styles: [
		'/assets/components/spinner/spinner.css',
		'/assets/components/mdi/mdi.css'
	],
	script: [
		'/assets/components/jquery/jquery-3.4.1.min.js',
		'/assets/components/jquery/jquery-ui.min.js'
	],
	init: function ( nodes ) {
		nodes.forEach( function ( node ) {
			let
					params = parseJSON( node.getAttribute( 'data-spinner' ) ),
					defaults = {
						min: 0,
						step: 1
					};

			$( node ).spinner( $.extend( defaults, params ) );
		});
	}
};

components.nav = {
	selector: '.nav',
	styles: '/assets/components/nav/nav.css',
	script: [
		'/assets/components/jquery/jquery-3.4.1.min.js',
		'/assets/components/bootstrap/js/popper.js',
		'/assets/components/bootstrap/js/bootstrap.min.js'
	],
	init: function ( nodes ) {
		nodes.forEach( function ( node ) {
			$( node ).on( 'click', function ( event ) {
				event.preventDefault();
				$( this ).tab( 'show' );
			});

			$( node ).find( 'a[data-toggle="tab"]' ).on( 'shown.bs.tab', function () {
				window.dispatchEvent( new Event( 'resize' ) );
			});
		});
	}
};

components.gmap = {
	selector: '.google-map',
	styles: '/assets/components/google-map/google-map.css',
	script: [
		'//maps.google.com/maps/api/js?key=AIzaSyBHij4b1Vyck1QAuGQmmyryBYVutjcuoRA&libraries=geometry,places&v=quarterly',
		'/assets/components/google-map/google-map.js'
	],
	init: function ( nodes ) {
		let promises = [];

		nodes.forEach( function ( node ) {
			let
					defaults = {
						node: node,
						center: { lat: 0, lng: 0 },
						zoom: 4,
					},
					params = parseJSON( node.getAttribute( 'data-settings' ) ),
					sMap = new SimpleGoogleMap( Object.assign( defaults, params ) );

			promises.push( new Promise ( function ( resolve ) {
				sMap.map.addListener( 'tilesloaded', resolve );
			}) );
		});

		return Promise.all( promises );
	}
};

components.gmapMarkerInfo = {
	selector: '[data-marker-info]',
	init: function ( nodes ) {
		nodes.forEach( function ( node ) {
			node.addEventListener( 'click', function () {
				let
						params = parseJSON( this.getAttribute( 'data-marker-info' ) ),
						map = document.querySelector( params.mapId ).simpleGoogleMap;

				map.showInfo( params.markerId );
			});
		});
	}
};

components.multiswitch = {
	selector: '[data-multi-switch]',
	styles: '/assets/components/multiswitch/multiswitch.css',
	script: [
		'/assets/components/current-device/current-device.min.js',
		'/assets/components/multiswitch/multiswitch.js'
	],
	dependencies: 'rdNavbar',
	init: function ( nodes ) {
		let click = device.ios() ? 'touchstart' : 'click';

		nodes.forEach( function ( node ) {
			if ( node.tagName === 'A' ) {
				node.addEventListener( click, function ( event ) {
					event.preventDefault();
				});
			}

			MultiSwitch( Object.assign( {
				node: node,
				event: click,
			}, parseJSON( node.getAttribute( 'data-multi-switch' ) ) ) );
		});
	}
};

components.rdNavbar = {
	selector: '.rd-navbar',
	styles: [
		'/assets/components/rd-navbar/rd-navbar.css'
	],
	script: [
		'/assets/components/jquery/jquery-3.4.1.min.js',
		'/assets/components/util/util.min.js',
		'/assets/components/current-device/current-device.min.js',
		'/assets/components/rd-navbar/rd-navbar.min.js'
	],
	dependencies: 'currentDevice',
	init: function ( nodes ) {
		nodes.forEach( function ( node ) {
			let
					backButtons = node.querySelectorAll( '.navbar-navigation-back-btn' ),
					params = parseJSON( node.getAttribute( 'data-rd-navbar' ) ),
					defaults = {
						stickUpClone: false,
						anchorNav: false,
						autoHeight: false,
						stickUpOffset: '1px',
						responsive: {
							0: {
								layout: 'rd-navbar-fixed',
								deviceLayout: 'rd-navbar-fixed',
								focusOnHover: 'ontouchstart' in window,
								stickUp: false
							},
							992: {
								layout: 'rd-navbar-fixed',
								deviceLayout: 'rd-navbar-fixed',
								focusOnHover: 'ontouchstart' in window,
								stickUp: false
							},
							1200: {
								layout: 'rd-navbar-fullwidth',
								deviceLayout: 'rd-navbar-fullwidth',
								stickUp: true,
								stickUpOffset: '1px',
								autoHeight: true
							}
						},
						callbacks: {
							onStuck: function () {
								document.documentElement.classList.add( 'rd-navbar-stuck' );
							},
							onUnstuck: function () {
								document.documentElement.classList.remove( 'rd-navbar-stuck' );
							},
							onDropdownToggle: function () {
								if ( this.classList.contains( 'opened' ) ) {
									this.parentElement.classList.add( 'overlaid' );
								} else {
									this.parentElement.classList.remove( 'overlaid' );
								}
							},
							onDropdownClose: function () {
								this.parentElement.classList.remove( 'overlaid' );
							}
						}
					},
					xMode = {
						stickUpClone: false,
						anchorNav: false,
						responsive: {
							0: {
								stickUp: false,
								stickUpClone: false
							},
							992: {
								stickUp: false,
								stickUpClone: false
							},
							1200: {
								stickUp: false,
								stickUpClone: false
							}
						},
						callbacks: {
							onDropdownOver: function () { return false; }
						}
					},
					navbar = node.RDNavbar = new RDNavbar( node, Util.merge( window.xMode ? [ defaults, params, xMode ] : [ defaults, params ] ) );

			if ( backButtons.length ) {
				backButtons.forEach( function ( btn ) {
					btn.addEventListener( 'click', function () {
						let
								submenu = this.closest( '.rd-navbar-submenu' ),
								parentmenu = submenu.parentElement;

						navbar.dropdownToggle.call( submenu, navbar );
					});
				});
			}
		})
	}
};

components.animate = {
	selector: '[data-animate]',
	styles: '/assets/components/animate/animate.css',
	script: '/assets/components/current-device/current-device.min.js',
	init: function ( nodes ) {
		if ( window.xMode || device.macos() ) {
			nodes.forEach( function ( node ) {
				let params = parseJSON( node.getAttribute( 'data-animate' ) );
				node.classList.add( 'animated', params.class );
			});
		} else {
			let observer = new IntersectionObserver( function ( entries ) {
				let observer = this;

				entries.forEach( function ( entry ) {
					let
							node = entry.target,
							params = parseJSON( node.getAttribute( 'data-animate' ) );

					if ( params.delay ) node.style.animationDelay = params.delay;
					if ( params.duration ) node.style.animationDuration = params.duration;

					if ( entry.isIntersecting ) {
						node.classList.add( 'animated', params.class );
						observer.unobserve( node );
					}
				});
			}, {
				threshold: .5
			});

			nodes.forEach( function ( node ) {
				observer.observe( node );
			});
		}
	}
};

components.tooltip = {
	selector: '[data-tooltip]',
	styles: '/assets/components/tooltip/tooltip.css',
	script: [
		'/assets/components/jquery/jquery-3.4.1.min.js',
		'/assets/components/bootstrap/js/popper.js',
		'/assets/components/bootstrap/js/bootstrap.min.js'
	],
	init: function ( nodes ) {
		nodes.forEach( function ( node ) {
			let options = parseJSON( node.getAttribute( 'data-tooltip' ) );

			$( node ).tooltip( options )
		})
	}
};

components.toTop = {
	selector: 'html',
	styles: '/assets/components/to-top/to-top.css',
	script: '/assets/components/jquery/jquery-3.4.1.min.js',
	init: function () {
		if ( !window.xMode ) {
			let node = document.createElement( 'div' );
			node.className = 'to-top mdi-chevron-up';
			document.body.appendChild( node );

			node.addEventListener( 'mousedown', function () {
				this.classList.add( 'active' );

				$( 'html, body' ).stop().animate( { scrollTop:0 }, 500, 'swing', (function () {
					this.classList.remove( 'active' );
				}).bind( this ));
			});

			document.addEventListener( 'scroll', function () {
				if ( window.scrollY > window.innerHeight ) node.classList.add( 'show' );
				else node.classList.remove( 'show' );
			});
		}
	}
};


// Main
window.addEventListener( 'load', function () {
	new ZemezCore({
		//{DEL LIVEDEMO BUILDER}
		debug: true,
		//{DEL}
		components: components,
		observeDOM: window.xMode,
		IEPolyfill: '/assets/components/base/support.js',
		IEHandler: function ( version ) {
			document.documentElement.classList.add( 'ie-'+ version );
		}
	});
});
