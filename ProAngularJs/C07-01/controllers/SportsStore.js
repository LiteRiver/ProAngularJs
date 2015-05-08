angular.module("SportsStore")
    .constant("ProductsUrl", "/SportsStore/Products")
    .controller("SportsStoreCtrl", function ($scope, $http, ProductsUrl) {
        $scope.data = {};
        $http.get(ProductsUrl)
            .success(function (data) {
                $scope.products = data;
            }).error(function (error, errorStatus) {
                $scope.error = error;
                $scope.errorStatus = errorStatus;
            });
    });