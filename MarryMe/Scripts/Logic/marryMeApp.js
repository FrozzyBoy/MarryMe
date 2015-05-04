var marryApp = angular.module('marryApp', [])

marryApp.controller('appCtrl', function ($scope, $http, api) {
	$http.defaults.useXDomain = true;
	var currentYear = new Date().getFullYear()
	completenessOfTheMonths(currentYear);

	$scope.halls = ["Бриллиантовый", "Золотой", "Розовый", "Хрустальный"];
	$scope.times = [];

	completenessOfTheDays(2015, 4);
	getHolidays(2015, 4);
	roomCount();
	roomInfo(0);
	allRooms();



	$('.responsive-calendar').responsiveCalendar({
		onDayClick: function (events) {
			$scope.selectedYear = $(this).data('year');
			$scope.selectedMonth = $(this).data('month');
			$scope.selectedDay = $(this).data('day');

			var year = $scope.selectedYear;
			var month = $scope.selectedMonth;
			var day = $scope.selectedDay;

			var selectedDate = new Date(year, month - 1, day);
			var currentDate = new Date();
			var delay = (selectedDate - currentDate) / 1000 / 60 / 60 / 24;

			$scope.isCorrectDate = false;
			if (delay > 3) {
				dayInfo(0, year, month - 1, day);
				$scope.isCorrectDate = true;
			}
			else {
				$scope.$apply();
			}



			if ($scope.selectedMonth < 9) {
				month = '0' + $scope.selectedMonth;
			}
			if ($scope.selectedDay < 9) {
				day = '0' + $scope.selectedDay;
			}
			var key = $(this).data('year') + '-' + month + '-' + day
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

	$scope.bridegroom = [];
	$scope.bride = [];

	function getTimesForMe() {
		for (var i = 8; i < 18; i++) {

			for (var j = 0; j < 41; j += 20) {

				var time = j;

				if (j == 0) {
					time = "00";
				}

				$scope.times1.push(i.toString() + '.' + time);
			}

		}
		$scope.$apply();
	}
	$scope.times1 = [];
	getTimesForMe();

	$scope.yearChange = function (flag) {
		if (flag == 1) {
			currentYear++;
		}
		else {
			currentYear--;
		}

		completenessOfTheMonths(currentYear);
	} // event yearChange

	function completenessOfTheDays(year, month) { // заполнение дней месяца(%)
		var persents;
		$http({
			method: 'GET',
			url: api.calendar.days,
			params: { 'year': year, 'month': month }
		}).success(function (data) {
			persents = data;
			console.log(data)
		}).error(function (data, status) {

		});


	};

	function completenessOfTheMonths(year) { //заполнение месяцов(%)
		var months = ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"];
		$scope.monthsInfo = [];
		$http({
			method: 'GET',
			url: api.calendar.months,
			params: { 'year': year }
		}).success(function (data) {
			console.log(data)
			getM(data);
		}).error(function (data, status) {

		});

		function getM(persents) { //добавление объектов в массив
			for (var i = 0; i < 12; i++) {
				$scope.monthsInfo.push({
					name: months[i],
					persent: persents[i]
				})
			}
		}
	}

	function dayInfo(roomId, year, month, day) {
		// заполнение дня
		$http({
			method: 'GET',
			url: api.room.schedule,
			params: { 'roomId': roomId, 'time': year + '-' + month + '-' + day }
		}).success(function (data, status, headers, config) {
			console.log(data, status);
			$scope.times = data;
		}).error(function (data, status) {
			alert('err')
		});
	}

	function getHolidays(year, month) {
		$http({ // праздники
			method: 'GET',
			url: api.calendar.holidays,
			params: { 'year': year, 'month': month }
		}).success(function (data, status, headers, config) {
			console.log(data, status);
		}).error(function (data, status) {

		});
	}

	function roomCount() {
		$http({ // кол-во комнат
			method: 'GET',
			url: api.room.count,
		}).success(function (data, status, headers, config) {
			console.log(data, status);
		}).error(function (data, status) {

		});
	}

	function roomInfo(id) {
		$http({ //инфо по комнате
			method: 'GET',
			url: api.room.info,
			params: { 'roomId': id }
		}).success(function (data, status, headers, config) {
			console.log(data, status);
		}).error(function (data, status) {

		});
	}

	function allRooms() {
		$http({ // все комнаты
			method: 'GET',
			url: api.room.all,
		}).success(function (data, status, headers, config) {
			console.log(data, status);
		}).error(function (data, status) {

		});
	}
});


marryApp.constant('api', {
	calendar: {
		days: '/api/calendar/days',
		months: '/api/calendar/months',
		holidays: '/api/calendar/holidays'
	},
	room: {
		count: '/api/room/count',
		info: '/api/room/info',
		all: '/api/room/all',
		schedule: '/api/room/schedule'
	},
	submit: '/api/submit'
});
