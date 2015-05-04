var marryApp = angular.module('marryApp', [])

marryApp.controller('appCtrl', function ($scope, $http, api) {
	$http.defaults.useXDomain = true;
	// $http.defaults.headers.post["Content-Type"] = "application/x-www-form-urlencoded";

	var currentYear = new Date().getFullYear();

	completenessOfTheMonths(currentYear);
	allRooms();

	$scope.halls = {};
	$scope.times = [];
	$scope.Man = {};
	$scope.Woman = {};
	$scope.submitData = {};




	$('.responsive-calendar').responsiveCalendar({
		onDayClick: function (events) {
			$scope.selectedYear = $(this).data('year');
			$scope.selectedMonth = $(this).data('month');
			$scope.selectedDay = $(this).data('day');
			$scope.$apply();

			if ($scope.submitData.RoomId != null || $scope.submitData.RoomId != undefined) {
				dayInfo($scope.submitData.RoomId, $scope.selectedYear, $scope.selectedMonth, $scope.selectedDay);
			}

			var year = $scope.selectedYear;
			var month = $scope.selectedMonth;
			var day = $scope.selectedDay;

			var selectedDate = new Date(year, month - 1, day);
			var currentDate = new Date();
			var delay = (selectedDate - currentDate) / 1000 / 60 / 60 / 24;

			$scope.isCorrectDate = false;
			if (delay > 3) {
				$scope.isCorrectDate = true;
			}

			if (month < 9) {
				month = '0' + month;
			}
			if (day < 9) {
				day = '0' + day;
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

	$scope.applyForm = function () {
		$scope.submitData.Man = $scope.Man;
		$scope.submitData.Woman = $scope.Woman;
		var object = $scope.submitData;
		submit(object);
	}

	$scope.timeClick = function (time) {

		var temp = time.split(':');
		var hour = temp[0];
		var minutes = temp[1];
		var year = $scope.selectedYear;
		var month = $scope.selectedMonth;
		var day = $scope.selectedDay;
		$scope.submitData.RegistrationDate = new Date(year, month - 1, day, hour, minutes);
	} //выбор времени

	$scope.hallClick = function (clickedId) {
		$scope.submitData.RoomId = clickedId;
		console.log($scope.submitData.RoomId + ' ' + $scope.selectedYear + ' ' + $scope.selectedMonth + ' ' + $scope.selectedDay + ' ' + 'hall')
		dayInfo(clickedId, $scope.selectedYear, $scope.selectedMonth, $scope.selectedDay);
	} //event выбор зала

	$scope.yearChange = function (flag) {
		if (flag == 1) {
			currentYear++;
		}
		else {
			currentYear--;
		}
		completenessOfTheMonths(currentYear);
	} // event смена года

	function completenessOfTheDays(year, month) {
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


	};// заполнение дней месяца(%)

	function completenessOfTheMonths(year) {
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

		function getM(persents) {
			for (var i = 0; i < 12; i++) {
				$scope.monthsInfo.push({
					name: months[i],
					persent: persents[i]
				})
			}
		} //добавление объектов в массив
	} //заполнение месяцов(%)

	function dayInfo(roomId, year, month, day) {

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
	}// заполнение дня(время)

	function getHolidays(year, month) {
		$http({
			method: 'GET',
			url: api.calendar.holidays,
			params: { 'year': year, 'month': month }
		}).success(function (data, status, headers, config) {
			console.log(data, status);
		}).error(function (data, status) {

		});
	} // праздники(список)

	function roomInfo(id) {
		$http({
			method: 'GET',
			url: api.room.info,
			params: { 'roomId': id }
		}).success(function (data, status, headers, config) {
			console.log(data, status);
		}).error(function (data, status) {

		});
	}//инфо по комнате

	function allRooms() {
		$http({
			method: 'GET',
			url: api.room.all,
		}).success(function (data, status, headers, config) {
			$scope.halls = data;
		}).error(function (data, status) {

		});
	} // все комнаты

	function submit(object) {
		console.log(object);
		$http({
			method: 'POST',
			url: api.submit,
			data: JSON.stringify(object),
			headers: { 'Content-Type': 'application/json' }
		}).success(function (data, status) {

		}).error(function (data, status, headers, config) {
			alert('error' + status)
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
