angular.module("ExampleApp.Directives", []).directive("highlight", function ($filter) {
    var dayFilter = $filter("dayName");

    return function (scope, element, attrs) {

        if (dayFilter(scope.day) == attrs["highlight"]) {
            element.css("color", "red");
        }
    };
});