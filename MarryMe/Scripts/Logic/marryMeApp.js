var marryApp = angular.module('marryApp', [])

marryApp.controller('appCtrl', function ($scope, $http,api) {
    $http.defaults.useXDomain = true;
  
    completenessOfTheMonths(2015);
    completenessOfTheDays(2015, 4);
    getHolidays(2015, 4);
    roomCount();
    roomInfo(0);
    allRooms();

    $('.responsive-calendar').responsiveCalendar({
        onDayClick: function (events) {
            var year = $(this).data('year');
            var month = $(this).data('month') - 1;
            var day = $(this).data('day');

            var selectedDate = new Date(year, month, day);
            var currentDate = new Date();
 
            var delay = (selectedDate - currentDate) / 1000 / 60 / 60 / 24;
            var response = false;

            if (delay > 3) {
                response = true;
                dayInfo(0, year, month, day);
            }                   
        }
    });
    
    $scope.bridegroom = [];
    $scope.bride = [];

    function completenessOfTheDays(year,month) { // заполнение дней месяца(%)
        $http({
            method: 'GET',
            url: api.calendar.days,
            params: { 'year': year, 'month': month }
        }).success(function (data) {
            console.log(data)

        }).error(function (data, status) {

        });
    };

    function completenessOfTheMonths(year) { //заполнение месяцов(%)
        $http({ 
            method: 'GET',
            url: api.calendar.months,
            params: { 'year': year}
        }).success(function (data) {
            console.log(data)
        }).error(function (data, status) {

        });
    }

    function dayInfo(roomId,year,month,day) {
        // заполнение дня
        $http({
            method: 'GET',
            url: api.room.schedule,
            params: { 'roomId': roomId, 'time': new Date(year, month, day).toLocaleDateString('en-US') }
        }).success(function (data, status, headers, config) {
            console.log(data, status);
            $scope.dayTimes = data;
        }).error(function (data, status) {
            alert('err')
        });
    }
    function getHolidays(year, month) {
        $http({ // праздники
            method: 'GET',
            url: api.calendar.holidays,
            params: { 'year': year, 'month':month }
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
            params: { 'roomId':id }
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

var site = 'http://marryme.somee.com/api';
marryApp.constant('api', {
    calendar: {
        days: 'http://marryme.somee.com/api' + '/calendar/days',
        months: 'http://marryme.somee.com/api' + '/calendar/months',
        holidays: 'http://marryme.somee.com/api' + '/calendar/holidays'
    },
    room: {
        count: 'http://marryme.somee.com/api' + '/room/count',
        info: 'http://marryme.somee.com/api' + '/room/info',
        all: 'http://marryme.somee.com/api' + '/room/all',
        schedule: 'http://marryme.somee.com/api' + '/room/schedule'
    },
    submit: 'http://marryme.somee.com/api' + '/submit'
});
