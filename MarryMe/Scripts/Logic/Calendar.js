$(document).ready(function () {
	$(".responsive-calendar").responsiveCalendar({
		onDayClick: function (events) {
			var month = $(this).data('month');
			var day = $(this).data('day');
			if (month < 9) {
				month = '0' + month;
			}
			if (day < 9) {
				day = '0' + day;
			}
			var key = $(this).data('year') + '-' + month + '-' + day;
			var qwe = {};
			qwe[key] = {};
			$(".responsive-calendar").responsiveCalendar('clearAll');
			$(".responsive-calendar").responsiveCalendar('getCurrMonth');
			$(".responsive-calendar").responsiveCalendar('edit', qwe);
			var currMonth = $(".responsive-calendar").responsiveCalendar.qwerty();
			if (month - currMonth == 0 || month - currMonth == 12) {
				$(".responsive-calendar").responsiveCalendar('prev');
			}
			if (month - currMonth == 2 || month - currMonth == -10) {
				$(".responsive-calendar").responsiveCalendar('next');
			}
		}
	});
});