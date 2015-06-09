function blockSize() {
	$('.hall-bg-image').height(function () {
		console.log("resize");
		return $(this).width();
	});
}

function blockSize2() {
	$('.form-block').height(function () {
		if (window.innerWidth < 767) {
			return 540;
		}
		if (window.innerWidth < 992) {
			return 600;
		}
		else {
			return 530;
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
