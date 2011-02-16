$(document).ready(function(){
    
	$('#msjbienvenida').delay(2000).show('slow');/*bienvenida*/
	$('#boton1').delay(300).show('fast');/*bienvenida*/
	$('#boton2').delay(700).show('fast');/*bienvenida*/
	$('#boton3').delay(1100).show('fast');/*bienvenida*/
	$('#boton4').delay(1500).show('fast');/*bienvenida*/
	$('#boton5').delay(1900).show('fast');/*bienvenida*/
	$('#boton1').click(function() {
  		document.location.href='oficina.html';
	});
	$('#boton2').click(function() {
		$("#stacksNav").show();
		$(".stack").show();
		$('#overlay').css("background-image", "url(./images/overlay/fcliente.png)");
  		
		$('#msjbienvenida').delay(600).fadeOut();
	  	$('#boton5').delay(600).fadeOut();
		$('#boton4').delay(900).fadeOut();
		$('#boton3').delay(1200).fadeOut();
		$('#boton2').delay(1500).fadeOut();
		$('#boton1').delay(1800).fadeOut();
    });
	$('#boton3').click(function() {
		$("#stacksNav").show();
		$(".stack").show();
		$('#overlay').css("background-image", "url(./images/overlay/fproveedor.png)");
  		
  		$('#msjbienvenida').delay(600).fadeOut();
	  	$('#boton5').delay(600).fadeOut();
		$('#boton4').delay(900).fadeOut();
		$('#boton3').delay(1200).fadeOut();
		$('#boton2').delay(1500).fadeOut();
		$('#boton1').delay(1800).fadeOut();
    });
	$('#boton4').click(function() {
		$("#stacksNav").show();
		$(".stack").show();
  		$('#overlay').css("background-image", "url(./images/overlay/fproductos.png)");
  		$('#msjbienvenida').delay(600).fadeOut();
	  	$('#boton5').delay(600).fadeOut();
		$('#boton4').delay(900).fadeOut();
		$('#boton3').delay(1200).fadeOut();
		$('#boton2').delay(1500).fadeOut();
		$('#boton1').delay(1800).fadeOut();
    });
	$('#boton5').click(function() {
		$("#stacksNav").show();
		$(".stack").show();
  		$('#overlay').css("background-image", "url(./images/overlay/fmoneda.png)");
  		$('#msjbienvenida').delay(600).fadeOut();
	  	$('#boton5').delay(600).fadeOut();
		$('#boton4').delay(900).fadeOut();
		$('#boton3').delay(1200).fadeOut();
		$('#boton2').delay(1500).fadeOut();
		$('#boton1').delay(1800).fadeOut();
    });
	$('#divmonedastack').click(function() {
		
  		$('#overlay').css("background-image", "url(./images/overlay/fmoneda.png)");
  	});
	$('#divproductostack').click(function(e) {
		
		
		
  		$('#overlay').css("background-image", "url(./images/overlay/fproductos.png)");
  	});
	$('#divproveedorstack').click(function(e) {
		
		
  		$('#overlay').css("background-image", "url(./images/overlay/fproveedor.png)");
  	});
	$('#divclientestack').click(function(e) {
		
		
		$('#overlay').css("background-image", "url(./images/overlay/fcliente.png)");
		
  	});
		
    
});





$(function () {
	// Stack initialize
	var openspeed = 300;
	var closespeed = 300;
	
	$('.stack>img').toggle(function(){
		var vertical = 0;
		var horizontal = 0;
		var $el=$(this);
		$el.next().children().each(function(){
			$(this).animate({top: '-' + vertical + 'px', left: horizontal + 'px'}, openspeed);
			vertical = vertical + 55;
			horizontal = (horizontal+.75)*2;
		});
		$el.next().animate({top: '-50px', left: '10px'}, openspeed).addClass('openStack')
		   .find('li a>img').animate({width: '50px', height:'50px', marginLeft: '9px'}, openspeed);
		$el.animate({paddingTop: '0'});
	}, function(){
		//reverse above
		var $el=$(this);
		$el.next().removeClass('openStack').children('li').animate({top: '55px', left: '-10px'}, closespeed);
		$el.next().find('li a>img').animate({width: '79px',height:'79px', marginLeft: '0'}, closespeed);
		$el.animate({paddingTop: '35'});
	});

	// Stacks additional animation
	$('.stack li a').hover(function(){
		$("img.stack-item",this).animate({width: '56px', height:'56px'}, 100);
		$("span.stack-item",this).animate({marginRight: '30px'});
	},function(){
		$("img.stack-item",this).animate({width: '50px', height:'50px'}, 100);
		$("span.stack-item",this).animate({marginRight: '0'});
	});
});


