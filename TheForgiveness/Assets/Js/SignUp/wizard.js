searchVisible = 0;
transparent = true;
$(document).ready(function(){
    $('[rel="tooltip"]').tooltip();
    jQuery.validator.addMethod("text", function (v, e) {
        return this.optional(e) || /^[a-zA-Z\u00F1\u00D1\s]+$/i.test(v);
    }, "Solo letras!"); 
    jQuery.validator.addMethod("valueNotEquals", function (v, e) { // Adding rules for Amount(Not equal to zero)
        return this.optional(e) || v !== 'default';
    });
    jQuery.validator.addMethod("NUMID", function (v, e) {
        return this.optional(e) || /[^a-zA-Z¨¢¨¦¨ª¨®¨²A??????0-9]*$/i.test(v);
    }, "id error"); 
    var $validator = $('.wizard-card form').validate({
rules: {
            PriNombre: {
                required: true,
                minlength: 3,
                maxlength: 45,
                text: true
            },
            SegNombre: {
                required: false,
                minlength: 3,
                maxlength: 50,
                text: true
            },
            PriApellido: {
                required: true,
                minlength: 3,
                maxlength: 55,
                text: true
            },
            SegApellido: {
                required: true,
                minlength: 3,
                maxlength: 55,
                text: true
            },
            Identificacion:{
                required: true,
                valueNotEquals: true
            },
            NumIdentificacion: {
                required: true,
                minlength: 6,
                maxlength: 12,
                NUMID: true
            },
            Genero:{
                required: true,
                valueNotEquals: true
            },
            FechaNacimiento:{
                required: true
            },
            UserName: {
                required: true,
                minlength: 4,
                maxlength: 45
            },
            ConfirmUserName: {
                required: true,
                minlength: 4,
                maxlength: 45,
                equalTo: "#UN"
            },
            PassWord: {
                required: true,
                minlength: 8,
                maxlength: 45
            },
            ConfirmPassWord: {
                required: true,
                minlength: 8,
                maxlength: 45,
                equalTo: "#PW"
            },
            Email: {
                required: true,
                minlength: 8,
                maxlength: 400,
                email: true
            },
            Telefono: {
                required: true,
                digits: true,
                minlength: 7,
                maxlength: 10
            },           
            Departamento:{
                required: true,
                valueNotEquals: true
            },
            Municipio:{
                required: true,
                valueNotEquals: true
            }
        },
        messages: {
             PriNombre: {
                required: "Campo requerido",
                text: "?olo puede digitar letras!"
            },
            SegNombre: {
                required: "Campo requerido",
                text: "?olo puede digitar letras!"
            },
            PriApellido: {
                required: "Campo requerido",
                text: "?olo puede digitar letras!"
            },
            SegApellido: {
                required: "Campo requerido",
                text: "?olo puede digitar letras!"
            },
            Identificacion:{
                required: "Debe Seleccionar un dato",
                valueNotEquals: "No ha seleccionado nada!"
            },
            NumIdentificacion: {
                required: "Campo requerido",  
                NUMID: "Error"
            },
            Genero:{
                required: "Debe Seleccionar un dato",
                valueNotEquals: "No ha seleccionado nada!"
            },
            FechaNacimiento:{
                required: "Campo requerido",
            },
            UserName: {
                required: "Campo requerido",
            },
            ConfirmUserName: {
                required: "Campo requerido",
                equalTo: "Los nombre de usuario no coinciden"
            },
            PassWord: {
                required: "Campo requerido",
            },
            ConfirmPassWord: {
                required: "Campo requerido",
                equalTo: "las contraseñas no coinciden"
            },
            Email: {
                required: "Campo requerido",
                email: 'Eso no es un correo electronico'
            },
            Telefono: {
                required: "Campo requerido",
                digits: "Solo se aceptan números"
            },           
            Departamento:{
                required: "Debe Seleccionar un dato",
                valueNotEquals: "No ha seleccionado nada!"
            },
            Municipio:{
                required: "Debe Seleccionar un dato",
                valueNotEquals: "No ha seleccionado nada!"
            }
        }
	});
  	$('.wizard-card').bootstrapWizard({
        'tabClass': 'nav nav-pills',
        'nextSelector': '.btn-next',
        'previousSelector': '.btn-previous',
        onNext: function(tab, navigation, index) {
        	var $valid = $('.wizard-card form').valid();
        	if(!$valid) {
        		$validator.focusInvalid();
        		return false;
        	}
        },
        onInit : function(tab, navigation, index){
          var $total = navigation.find('li').length;
          $width = 100/$total;
          var $wizard = navigation.closest('.wizard-card');
          $display_width = $(document).width();
          if($display_width < 600 && $total > 3){
              $width = 50;
          }
           navigation.find('li').css('width',$width + '%');
           $first_li = navigation.find('li:first-child a').html();
           $moving_div = $('<div class="moving-tab">' + $first_li + '</div>');
           $('.wizard-card .wizard-navigation').append($moving_div);
           refreshAnimation($wizard, index);
           $('.moving-tab').css('transition','transform 0s');
       },
        onTabClick : function(tab, navigation, index){
            var $valid = $('.wizard-card form').valid();
            if(!$valid){
                return false;
            } else {
                return true;
            }
        },

        onTabShow: function(tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index+1;
            var $wizard = navigation.closest('.wizard-card');
            if($current >= $total) {
                $($wizard).find('.btn-next').hide();
                $($wizard).find('.btn-finish').show();
            } else {
                $($wizard).find('.btn-next').show();
                $($wizard).find('.btn-finish').hide();
            }
            button_text = navigation.find('li:nth-child(' + $current + ') a').html();
            setTimeout(function(){
                $('.moving-tab').text(button_text);
            }, 150);
            var checkbox = $('.footer-checkbox');
            if( !index == 0 ){
                $(checkbox).css({
                    'opacity':'0',
                    'visibility':'hidden',
                    'position':'absolute'
                });
            } else {
                $(checkbox).css({
                    'opacity':'1',
                    'visibility':'visible'
                });
            }
            refreshAnimation($wizard, index);
        }
  	});
    $('[data-toggle="wizard-radio"]').click(function(){
        wizard = $(this).closest('.wizard-card');
        wizard.find('[data-toggle="wizard-radio"]').removeClass('active');
        $(this).addClass('active');
        $(wizard).find('[type="radio"]').removeAttr('checked');
        $(this).find('[type="radio"]').attr('checked','true');
    });
    $('[data-toggle="wizard-checkbox"]').click(function(){
        if( $(this).hasClass('active')){
            $(this).removeClass('active');
            $(this).find('[type="checkbox"]').removeAttr('checked');
        } else {
            $(this).addClass('active');
            $(this).find('[type="checkbox"]').attr('checked','true');
        }
    });
    $('.set-full-height').css('height', 'auto');
});

$(window).resize(function(){
    $('.wizard-card').each(function(){
        $wizard = $(this);
        index = $wizard.bootstrapWizard('currentIndex');
        refreshAnimation($wizard, index);
        $('.moving-tab').css({
            'transition': 'transform 0s'
        });
    });
});
function refreshAnimation($wizard, index){
    total_steps = $wizard.find('li').length;
    move_distance = $wizard.width() / total_steps;
    step_width = move_distance;
    move_distance *= index;
    $wizard.find('.moving-tab').css('width', step_width);
    $('.moving-tab').css({
        'transform':'translate3d(' + move_distance + 'px, 0, 0)',
        'transition': 'all 0.3s ease-out'
    });
}
function debounce(func, wait, immediate) {
	var timeout;
	return function() {
		var context = this, args = arguments;
		clearTimeout(timeout);
		timeout = setTimeout(function() {
			timeout = null;
			if (!immediate) func.apply(context, args);
		}, wait);
		if (immediate && !timeout) func.apply(context, args);
	};
};


let inpid = document.getElementsByName('NumIdentificacion');
inpid[0].onkeyup = function() {
    var patterns = /[^a-zA-Z¨¢¨¦¨ª¨®¨²A??????0-9]*$/;
    var caretPos = this.selectionStart;
    this.value = inpid[0].value.replace(patterns, '');
    this.setSelectionRange(caretPos, caretPos);
}