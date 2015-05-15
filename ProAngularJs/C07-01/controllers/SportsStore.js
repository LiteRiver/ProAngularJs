angular.module("SportsStore")
    .constant("ProductsUrl", "/SportsStore/Products")
    .constant("OrderUrl", "/SportsStore/Orders")
    .controller("SportsStoreCtrl", function ($scope, $http, ProductsUrl, OrderUrl) {
        $scope.data = {};
        $http.get(ProductsUrl).success(function (data) {
            $scope.products = data;
        }).error(function (error, errorStatus) {
            $scope.error = error;
            $scope.errorStatus = errorStatus;
        });

        $scope.sendOrder = function (shippingDetails) {
            var order = angular.copy(shippingDetails);
            order.products = cart.getProducts();

            $http.post(OrderUrl, order).success(function (data) {
                $scope.orderId = data.id;
                cart.getProducts().length = 0;
            }).error(function (error) {
                $scope.orderError = error;
            }).finally(function () {
                $location.path("/complete");
            });
        };
    });