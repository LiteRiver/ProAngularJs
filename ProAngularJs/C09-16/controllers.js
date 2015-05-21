angular.module("ExampleApp.Controllers", [])
    .controller("DayCtrl", function ($scope, Days) {
        $scope.day = Days.today;
    })
    .controller("TomorrowCtrl", function ($scope, Days) {
        $scope.tomorrow = Days.tomorrow;
    });