function mainImage() {
	var width, height, canvas, canvas2 = true;
	initHeader();
	function initHeader() {
		width = window.innerWidth;
		height = window.innerHeight;
		canvas = document.getElementById('pollyfill-canvas1');
		canvas.width = width;
		canvas.height = height;
	}
}
mainImage();
$(window).resize(mainImage);

