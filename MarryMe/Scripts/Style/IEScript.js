var user = detect.parse(navigator.userAgent);

if (user.browser.family == 'IE') {
	$('#introImage').removeAttr("data-parallax");
	$('#introImage').removeAttr("data-image-src");
	$('#introImage').addClass("introBgImage");

	$('#missionImage').removeAttr("data-parallax");
	$('#missionImage').removeAttr("data-image-src");
	$('#missionImage').addClass("missionBgImage");

	$('#servicesImage').removeAttr("data-parallax");
	$('#servicesImage').removeAttr("data-image-src");
	$('#servicesImage').addClass("servicesBgImage");

	$('#portfolioImage').removeAttr("data-parallax");
	$('#portfolioImage').removeAttr("data-image-src");
	$('#portfolioImage').addClass("portfolioBgImage");
}