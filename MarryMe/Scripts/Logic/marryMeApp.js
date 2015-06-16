
var marryApp = angular.module('marryApp', ['uiGmapgoogle-maps', 'ui.bootstrap'])

marryApp.controller('mapCtrl', function ($scope) {
	$scope.map = { center: { latitude: 53.894672, longitude: 30.331377 }, zoom: 16 };
	$scope.marker = { idKey: 2, coords: { latitude: 53.894672, longitude: 30.331377 } }
});

marryApp.controller('appCtrl', function ($scope, $http, api, $modal, $log) {


	window.location.href = '/#intro'; 

	$scope.hide = true;

	$scope.timeLoader = true;
	$scope.timeElement = false;
	$scope.timeNextButton = true;
	$scope.timeElement1 = false;

	$scope.hallsImages = ["url(\"../../img/Halls/mog_gold.jpg\") 50% 50% no-repeat", "url(\"../../img/Halls/mog_diam.jpg\") 50% 50% no-repeat", "url(\"../../img/Halls/mog_ice.jpg\") 50% 50% no-repeat", "url(\"../../img/Halls/mog_ping.jpg\") 50% 50% no-repeat"];

	$scope.myStyleFunction = function (hall) {
		switch (hall.Id) {
			case 1:
				return {
					'background': $scope.hallsImages[0]
				}
			case 2:
				return {
					'background': $scope.hallsImages[1]
				}
			case 3:
				return {
					'background': $scope.hallsImages[2]
				}
			case 4:
				$(window).resize();
				return {
					'background': $scope.hallsImages[3]
				}
		};
	}


	$http.defaults.useXDomain = true;

	var currentYear = new Date().getFullYear();
	var currentMonth = new Date().getMonth();

	setMonth();
	
	var monthsDictionary = {};
	monthsDictionary["Январь"] = "01";
	monthsDictionary["Февраль"] = "02";
	monthsDictionary["Март"] = "03";
	monthsDictionary["Апрель"] = "04";
	monthsDictionary["Май"] = "05";
	monthsDictionary["Июнь"] = "06";
	monthsDictionary["Июль"] = "07";
	monthsDictionary["Август"] = "08";
	monthsDictionary["Сентябрь"] = "09";
	monthsDictionary["Октябрь"] = "10";
	monthsDictionary["Ноябрь"] = "11";
	monthsDictionary["Декабрь"] = "12";

	completenessOfTheMonths(currentYear);
	allRooms();

	$scope.halls = {};
	$scope.times = [];
	$scope.Man = {};
	$scope.Woman = {};
	$scope.submitData = {};
	$scope.InputValid = {};

	completenessOfTheDays(currentYear, currentMonth);

	$scope.applyForm = function (size, inputForm) {

		var modalInstance = $modal.open({
			animation: true,
			templateUrl: '/Home/Modal',
			controller: 'ModalController',
			size: size,
			resolve: {
				submitData: function () {
					return $scope.submitData;
				},
				InputForm: function () {
					return inputForm;
				},
				inputValid: function () {
					return $scope.InputValid;
				}

			}
		});

		$scope.submitData.Man = $scope.Man;
		$scope.submitData.Woman = $scope.Woman;
		var object = $scope.submitData;
	}

	$scope.isSelectedHall = function (hall) {
		return $scope.selectedHall === hall;
	}

	$scope.isSelectedTime = function (time) {
		return $scope.selectedTime === time;
	}

	$scope.isSelectedMonth = function (month) {
		return $scope.selectedMonthUI === month;
	}

	$scope.isSelectedNav = function (nav) {
		return $scope.selectedNav === nav;
	}

	$scope.navClick = function (nav) {
		$scope.selectedNav = nav;
	}

	$scope.timeClick = function (time, timeObject) {

		$scope.selectedTime = timeObject;
		$scope.InputValid.TimeValid = true;
		var temp = time.split(':');
		var hour = temp[0];
		var minutes = temp[1];
		var year = $scope.selectedYear;
		var month = $scope.selectedMonth;
		var day = $scope.selectedDay;
		
		$scope.submitData.RegistrationDate = new Date(Date.UTC(year, month - 1, day, hour, minutes));
	}

	$scope.monthClick = function (month, monthObject) {

		$scope.selectedMonthUI = monthObject;

		var dateString = currentYear + "-" + monthsDictionary[month];
		currentMonth = monthsDictionary[month];

		$('.responsive-calendar').responsiveCalendar(dateString);
		$(".responsive-calendar").responsiveCalendar('setCurrMonth', currentMonth);

		completenessOfTheDays(currentYear, currentMonth);

	}

	$scope.moveMonthClick = function (flag) {
		if (flag == 1) {
			currentMonth++;

			if (currentMonth > 12) {
				currentYear++;
				currentMonth = "01";
			}			
		} else {
			currentMonth--;

			if (currentMonth < 1) {
				currentYear--;
				currentMonth = "12";
			}
		}
		var dateString = currentYear + "-" + currentMonth;

		$('.responsive-calendar').responsiveCalendar(dateString);
		$(".responsive-calendar").responsiveCalendar('setCurrMonth', currentMonth);
		completenessOfTheDays(currentYear, currentMonth);
	}

	function setMonth() {
		currentMonth++;
		if (currentMonth < 9) {
			currentMonth = '0' + currentMonth;
		}
	}

	function changeElementStyle(clickedId) {
		var halls = [];
		var hall = $('#' + clickedId);
		for (var i = 1; i < 5; i++) {
			halls.push($('#' + i));
			halls[i - 1].removeClass('hall-background-color-click');
		}
		hall.addClass("hall-background-color-click");
	}

	$scope.hallClick = function (clickedId) {
		$scope.selectedHall = clickedId;
		$scope.timeElement = true;
		$scope.submitData.RoomId = clickedId;

		if ($scope.timeElement1) {
			dayInfo(clickedId, $scope.selectedYear, $scope.selectedMonth, $scope.selectedDay);
		}

		$scope.InputValid.HallValid = true;
		$scope.InputValid.TimeValid = false;
	} 

	$scope.yearChange = function (flag) {

		if (flag == 1) {
			currentYear++;
		}
		else {
			currentYear--;
		}

		var dateString = currentYear + "-01";
		$('.responsive-calendar').responsiveCalendar(dateString);

		completenessOfTheMonths(currentYear);
		$(".responsive-calendar").responsiveCalendar('setCurrYear', currentYear);
	} 

	function completenessOfTheDays(year, month) {
		$http({
			method: 'GET',
			async: false,
			url: api.calendar.days,
			params: { 'year': year, 'month': month }
		}).success(function (data) {
			$('.responsive-calendar').responsiveCalendar({
				onInit: function () {
					$(".responsive-calendar").responsiveCalendar('setMonthData', data);
				},
				onDayClick: function (events) {
					$scope.timeElement1 = true;
					$scope.selectedYear = $(this).data('year');
					$scope.selectedMonth = $(this).data('month');
					$scope.selectedDay = $(this).data('day');
					$scope.InputValid.TimeValid = false;
					$scope.$apply();

					if ($scope.submitData.RoomId != null || $scope.submitData.RoomId != undefined) {

						dayInfo($scope.submitData.RoomId, $scope.selectedYear, $scope.selectedMonth, $scope.selectedDay);
					}

					var year = $scope.selectedYear;
					var month = $scope.selectedMonth;
					var day = $scope.selectedDay;

					var monthsList = ["Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноябрь", "Декабрь"];
					$scope.selectedMonthToUi = monthsList[month-1];

					var selectedDate = new Date(year, month - 1, day);
					var currentDate = new Date();
					var delay = (selectedDate - currentDate) / 1000 / 60 / 60 / 24;


					if (delay > 3) {
						$scope.InputValid.dayValid = true;
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
					
					$scope.$apply();
				}
			});
			$(".responsive-calendar").responsiveCalendar('setMonthData', data);
		});
	}

	function completenessOfTheMonths(year) {
		var months = ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"];
		$scope.monthsInfo = [];
		$http({
			method: 'GET',
			url: api.calendar.months,
			params: { 'year': year }
		}).success(function (data) {
			getM(data);
		}).error(function (data, status) {

		});

		function getM(persents) {
			for (var i = 0; i < 12; i++) {
				if (persents[i] == -1) {
					persents[i] = 'Нет данных';
				}

				$scope.monthsInfo.push({
					name: months[i],
					persent: persents[i]
				})
			}
		} 
	} 

	function dayInfo(roomId, year, month, day) {

		beginLoadTime();

		$http({
			async: true,
			method: 'GET',
			url: api.room.schedule,
			params: { 'roomId': roomId, 'time': year + '-' + month + '-' + day }
		}).success(function (data, status, headers, config) {
			endLoadTime();
			$scope.times = splitTime(data);
		}).error(function (data, status) {
			endLoadTime();
		});

		function splitTime(data) {
			angular.forEach(data, function (item, key) {
				var temp = item.Time.split(':');
				item.Time = temp[0] + ':' + temp[1];
			});
			return data;
		}
	}

	function getHolidays(year, month) {
		$http({
			method: 'GET',
			url: api.calendar.holidays,
			params: { 'year': year, 'month': month }
		}).success(function (data, status, headers, config) {
		}).error(function (data, status) {

		});
	} 

	function roomInfo(id) {
		var response;
		$http({
			method: 'GET',
			url: api.room.info,
			params: { 'roomId': id }
		}).success(function (data, status, headers, config) {
			response = data;
		}).error(function (data, status) {

		});
		return response;
	}

	function allRooms() {
		$http({
			method: 'GET',
			url: api.room.all,
		}).success(function (data, status, headers, config) {
			$scope.halls = data;
		}).error(function (data, status) {

		});
	} 

	function beginLoadTime() {
		if (window.innerWidth > 1199) {
			$scope.timeLoader = false;
			$scope.timeNextButton = true;
		}
		else {
			$scope.timeNextButton = false;
		}
		$scope.timeElement = true;
	}

	function endLoadTime() {
		if (window.innerWidth > 1199) {
			$scope.timeLoader = true;
		}
		$(window).resize();
		$scope.timeNextButton = false;
		$scope.timeElement = true;
	}

	$(window).load(function () {
		$scope.hide = false;
		$scope.$apply();
		blockSize();
		setTimeout(function () {
			$("#load").fadeOut("slow");
		}, 1000);
		$scope.map = { center: { latitude: 53.894672, longitude: 30.331377 }, zoom: 16 };
		$scope.marker = { idKey: 2, coords: { latitude: 53.894672, longitude: 30.331377 } }
	});
}).controller('ModalController', function ($scope, $http, api, $modalInstance, submitData, InputForm, inputValid) {
	$scope.SubmitData = submitData;
	$scope.InputForm = InputForm;
	$scope.InputValid = inputValid;
	$scope.FullValid = false;
	$scope.isSending = false;
	$scope.reCaptcha = false;
	$scope.alerts = [];
	$scope.messages = [];
	

	if ($scope.InputForm.$valid == false) {
		if ($scope.InputForm.manFirstName.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните имя жениха.' });
		}
		if ($scope.InputForm.manLastName.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните фамилию жениха.' });
		}
		if ($scope.InputForm.manMiddleName.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните отчество жениха.' });
		}
		if ($scope.InputForm.manTelephoneNumber.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните номер мобильного телефона жениха.' });
		}
		if ($scope.InputForm.manPassportNumber.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните личный номер(паспорт) жениха.' });
		}
		if ($scope.InputForm.womanFirstName.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните имя невесты.' });
		}
		if ($scope.InputForm.womanLastName.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните фамилию невесты.' });
		}
		if ($scope.InputForm.womanMiddleName.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните отчество невесты.' });
		}
		if ($scope.InputForm.womanTelephoneNumber.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните номер мобильного телефона невесты.' });
		}
		if ($scope.InputForm.womanPassportNumber.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните личный номер(паспорт) невесты.' });
		}
		if ($scope.InputForm.manEmail.$error.required == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Заполните е-mail.' });
		}
		if ($scope.InputForm.manFirstName.$error.pattern == true ||
			$scope.InputForm.manMiddleName.$error.pattern == true ||
			$scope.InputForm.manLastName.$error.pattern == true ||
			$scope.InputForm.womanFirstName.$error.pattern == true ||
			$scope.InputForm.womanLastName.$error.pattern == true ||
			$scope.InputForm.womanMiddleName.$error.pattern == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Используйте кириллицу' });
		}
		if ($scope.InputForm.manEmail.$error.email == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Не валидный е-mail.' });
		}
		if ($scope.InputForm.manPassportNumber.$error.pattern == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Не верно введен личный номер жениха.' });
		}
		if ($scope.InputForm.womanPassportNumber.$error.pattern == true) {
			$scope.alerts.push({ type: 'danger', msg: 'Не верно введен личный номер невесты.' });
		}

	}

	if ($scope.InputValid.dayValid == undefined || $scope.InputValid.dayValid == false) {
		$scope.alerts.push({ type: 'danger', msg: 'Выберите дату. Дата не должна быть раньше чем через 3 дня от текущей' });
	}
	if ($scope.InputValid.HallValid == undefined || $scope.InputValid.HallValid == false) {
		$scope.alerts.push({ type: 'danger', msg: 'Не выбран зал' });
	}
	if ($scope.InputValid.TimeValid == undefined || $scope.InputValid.TimeValid == false) {
		$scope.alerts.push({ type: 'danger', msg: 'Не выбрано время' });
	}
	if ($scope.InputValid.dayValid == true && $scope.InputValid.HallValid == true && $scope.InputValid.TimeValid == true && $scope.InputForm.$valid == true) {
		$scope.FullValid = true;
	}


	if (submitData.RegistrationDate != undefined) {
		dateObjectParse(submitData.RegistrationDate.toString());
	}


	$scope.cancel = function () {
		$modalInstance.dismiss('cancel');
	};

	function dateObjectParse(date) {
		var object = new Date(date);
		$scope.selectedDay = object.getDate();
		$scope.selectedMonth = object.getMonth() + 1;
		$scope.selectedYear = object.getFullYear();
		$scope.selectedTime = object.getUTCHours() + ':' + object.getUTCMinutes();
	}

	$scope.submit = function () {
		$http.defaults.useXDomain = true;
		if (captcha) {
			$scope.isSending = true;
			$scope.$apply();
			$scope.messages = [];
			$http({
				method: 'POST',
				url: '/api/submit',
				data: JSON.stringify($scope.SubmitData),
				headers: { 'Content-Type': 'application/json' }
			}).success(function (data, status) {
				$scope.messages.push({ type: 'success', msg: 'На ваш e-mail отправлено письмо, пройдите по ссылке в письме для окончания регистрации' });
				$scope.isSending = false;
			}).error(function (data, status, headers, config) {
				$scope.messages.push({ type: 'danger', msg: data.Message });
				$scope.isSending = false;
			});
		}
		else {
			$scope.messages.push({ type: 'danger', msg: 'Пройдите капчу'});
		}
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
var onloadCallback = function () {
	grecaptcha.render('html_element', {
		'sitekey': '6LdNoAcTAAAAALiDNn06dsqGiTiEThjpRDoT6iDo',
		'callback': function (response) {
			captcha = true;
		}
	});
};
var captcha = false;