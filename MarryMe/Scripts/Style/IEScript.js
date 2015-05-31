var user = detect.parse(navigator.userAgent);

if (user.browser.family == 'IE') {
	$('#introImage').removeAttr("data-parallax");
	$('#introImage').removeAttr("data-image-src");
	$('#introImage').addClass("introBgImage");

	$('#portfolioImage').removeAttr("data-parallax");
	$('#portfolioImage').removeAttr("data-image-src");
	$('#portfolioImage').addClass("portfolioBgImage");
}