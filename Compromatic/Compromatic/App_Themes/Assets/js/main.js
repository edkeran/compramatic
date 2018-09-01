jQuery(function($) {
	"use strict";

	var $container = $('.portfolio-container');
	var navbar = $('.navbar');
	var owlHeader = $('#owl-header');
	var owlClients = $(".owl-clients:not(.no-navigation)");
	var owlClientsNN = $('.owl-clients');
	var backgrounds = $("[data-background]");
	var navbarNav = $('.navbar-nav');
	var searchForm = $('.search-form');
	var rangeSlider = $('.range-slider');
	var spinners = $('.spinner');
	var tabsContainer = $('.tabs-container');
	var owlProject = $('#owl-project');
	var progressBars = $('.progress-bar');
	var accordions = $('.accordions');
	var thumbnails = $('.thumbnails .product-holder');

	$(document).ready(function(){
		$('.vcenter').each(function(){
			if($(window).width() > 768)
				$(this).css("top", $(this).parent().height() / 2 - $(this).height() / 2 + "px");
		});
		$('body').css("padding-top", navbar.outerHeight());
		progressBars.each(function(){
			$(this).width($(this).data("valuenow") + "%");
		});
		
		$('.owl-text').owlCarousel({
			navigation: false,
			pagination: true,
			singleItem: true
		});
		owlClients.owlCarousel({
			pagination: false,
			navigation: true,
			navigationText:["<", ">"],
			autoPlay: 4000,
			items: 5
		});
		owlClientsNN.owlCarousel({
			pagination: false,
			navigation: true,
			navigationText:["<", ">"],
			autoPlay: 4000,
			items: 2
		});
		owlProject.owlCarousel({
			pagination: false,
			singleItem: true,
			autoPlay: 4000,
		})
		$container = $('.portfolio-container').imagesLoaded(function(){
			$container.isotope({
				itemSelector: '.item'
			});
		});
		$("a[data-rel^='prettyPhoto']").prettyPhoto({
			social_tools: false
		});
		rangeSlider.slider({
			range: true,
			min: 0,
			max: 500,
			values: [ 75, 300 ],
			slide: function( event, ui ) {
				$( ".price-range" ).html( ui.values[0] + " - " + ui.values[1] );
			}
		});
		spinners.spinner({
			min:0,
	      	step: 1
	    });
		AdaptHeader();
		AddBackgrounds();
		TimelineHeight();
		// Accordion

		accordions.children('.accordion').children('.content').hide();
		$('.accordions').children('.accordion.active').children('.content').slideDown(200);
		accordions.children('.accordion').children('a.heading').on('click', function(){
			event.preventDefault();
				$(this).parent().siblings('.accordion').children('.content').slideUp();
				$(this).parent().siblings('.accordion').removeClass('active')
				$(this).parent().children('.content').slideDown();
				$(this).parent().addClass('active');
		});

		$(window).resize(function(){
			$('body').css("padding-top", navbar.outerHeight());
			thumbnails.each(function(){
				$(this).height($('.gallery-pic').height() / thumbnails.length);
			});
			AdaptHeader();
		});

		$(window).load(function(){
			$('#owl-header').owlCarousel({
				singleItem: true, 
				addClassActive:true,
				pagination:false,
				afterMove: AnimateHeader
			});
			thumbnails.each(function(){
				$(this).height($('.gallery-pic').height() / thumbnails.length);
			});
			FixFIsotope();
		});

		function TimelineHeight() {
			$('.timeline .post .icon').each(function(){
				var height = $(this).parent().siblings('.desc').height();
				$(this).parent().css("line-height", height + "px");
				$(this).parent().siblings('.posted').children('.heading').css("line-height", height - 35 + "px");
			});
		}

		function AddBackgrounds() {
			backgrounds.each(function(){
				$(this).css("background", "url('" + $(this).data("background") + "') no-repeat center center");
				$(this).css("background-size", "cover");
			});
		}
		function AdaptHeader() {
			owlHeader.find('.item').height($(window).height() - navbar.outerHeight());
		}
		function AnimateHeader() {
			var index = $('.owl-header .owl-item.active').index();

			$('.owl-header').find('.owl-item').eq(index).find('.header-text').addClass('animated zoomIn').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
	  			$(this).removeClass('animated zoomIn');
			});
		}
		// Tabs

		tabsContainer.children('.tab-nav').children('a').on('click', function(){
			event.preventDefault();
			$('.tabs-container .tab-nav a').removeClass('active');
			$(this).addClass('active');
			var index = $(this).parent().children('a').index($(this));
			tabsContainer.children('.tab-holder').children('.tab').fadeOut(150);
			tabsContainer.children('.tab-holder').children('.tab').eq(index).fadeIn(150);
		});

		tabsContainer.each(function(){
			var active_tab = $('.tab-nav a.active');
			var index = $(this).find('.tab-nav').children('a').index(active_tab);
			tabsContainer.find('.tab').hide();
			tabsContainer.children('.tab-holder').children('.tab').eq(index).show();
		});
		$('.search-toggle').on('click', function(){
			event.preventDefault();
			$(this).parent().parent().next('input').slideToggle();
			$(this).parent().parent().next('input').focus();
			navbarNav.slideToggle();
		});
		$('.search-form').on('blur', function() {
			if($(this).is(":visible"))
			{
				$(this).slideToggle();
				navbarNav.slideToggle();
			}
		});

		//Search Event
		$('.search-form').on('keypress', function(event) {
			if(event.keyCode == 13) {
				$(this).slideToggle();
				navbarNav.slideToggle();
			}
		});

		$('.portfolio-filter a').on('click', function(){
			event.preventDefault();
			var filterValue = $(this).attr('data-filter');
	  		$container.isotope({ filter: filterValue });
		});

		//Animate
		/*$('p').removeClass().addClass('animated bounce').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
	  			$(this).removeClass();
		});*/

		function FixFIsotope() {
			$container.find(".item").each(function(){
		  		if($(this).index() != 0) {
					var width = parseInt($(this).prev(".item").css("width").replace(/[^-\d\.]/g, ''));
					var left = parseInt($(this).prev(".item").css("left").replace(/[^-\d\.]/g, ''));
					var pfWidthMin = $container.width() - 5;
					var pfWidthMax = $container.width() + 5;
		  			if(!(
		  				width + left > pfWidthMin &&
		  				width + left < pfWidthMax) ) {
		  				
		  				$(this).css("left", (parseInt(width)+parseInt(left)) + "px");
		  			}
		  		}
	  		});
		}
	});
})