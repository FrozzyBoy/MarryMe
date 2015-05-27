(function () {
	var width, height, canvas, canvas2 = true;
	initHeader();
	function initHeader() {
		width = window.innerWidth;
		height = window.innerHeight;
		canvas = document.getElementById('pollyfill-canvas1');
		canvas.width = width;
		canvas.height = height;
		if (height > 688 && width > 1370) {
			document.getElementById('mission').setAttribute("style", "height:" + height + "px");
			document.getElementById('services').setAttribute("style", "height:" + height + "px");
			document.getElementById('portfolio').setAttribute("style", "height:" + height + "px");
		}
	}
})();