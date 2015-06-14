function blockSize() {
	$('.hall-bg-image').height(function () {
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

blockSize();
blockSize2();

$(window).resize(blockSize);
$(window).resize(blockSize2);
