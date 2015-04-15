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
blockSize();
blockSize2();
$(window).resize(blockSize);
$(window).resize(blockSize2);