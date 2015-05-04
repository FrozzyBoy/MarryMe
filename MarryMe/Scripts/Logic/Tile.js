function blockSize() {
	$('.tile').height(function () {
		return $(this).width();
	});
}

function blockSize2() {
	$('.form-block').height(function () {
		if (window.innerWidth < 767) {
			return 400;
		}
		if (window.innerWidth < 992) {
			return 400;
		}
		else {
			return 250;
		}
	});
}

//function buttonPosition() {
//	var eTop = $('#backButton').offset().top;
//	var d = $('#nextButton');
//	d.offset({ top: eTop, left: d.offsetLeft });
//}

//function buttonPosition2() {
//	var eTop = $('#backButton2').offset().top;
//	var d = $('#nextButton2');
//	d.offset({ top: eTop, left: d.offsetLeft });
//}

blockSize();
blockSize2();

$(window).resize(blockSize);
$(window).resize(blockSize2);