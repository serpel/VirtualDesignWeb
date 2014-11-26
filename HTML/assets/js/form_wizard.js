$('#rootwizard').bootstrapWizard({
  		'tabClass': 'form-wizard',
  		'onNext': function(tab, navigation, index) {
  			var $valid = $("#commentForm").valid();
  			if(!$valid) {
  				$validator.focusInvalid();
  				return false;
  			}
			else{
				$('#rootwizard').find('.form-wizard').children('li').eq(index-1).addClass('complete');
				$('#rootwizard').find('.form-wizard').children('li').eq(index-1).find('.step').html('<i class="icon-ok"></i>');	
			}
  		}
 });
