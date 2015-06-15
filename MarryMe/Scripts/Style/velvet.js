$(function () {

	$('a.smooth-scroll').click(function (e) {
		e.preventDefault();
		var target = $($.attr(this, 'href'));
		if (target.offset() != undefined) {
			$('body,html').animate({ 'scrollTop': target.offset().top }, 1500, function () { animating = false; });
		}
	});



});

function smoothScroll(target) {
	animating = true;
	$('body,html').animate({ 'scrollTop': target.offset().top }, 500, function () { animating = false; });
}