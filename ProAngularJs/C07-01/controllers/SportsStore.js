angular.module("SportsStore")
    .constant("ProductsUrl", "/SportsStore/Products")
    .constant("PlaceOrderUrl", "/SportsStore/PlaceOrder")
    .controller("SportsStoreCtrl", function ($scope, $http, $location, ProductsUrl, PlaceOrderUrl, Cart) {
        $scope.data = {};
        $http.get(ProductsUrl).success(function (data) {
            $scope.products = data;
        }).error(function (error, errorStatus) {
            $scope.error = error;
            $scope.errorStatus = errorStatus;
        });

        $scope.sendOrder = function (shippingDetails) {
            var order = angular.copy(shippingDetails);
            order.products = Cart.getProducts();

            $http.post(PlaceOrderUrl, order).success(function (data) {
                $scope.orderId = data.id;
                Cart.getProducts().length = 0;
            }).error(function (error) {
                $scope.orderError = error;
            }).finally(function () {
                $location.path("/complete");
            });
        };
    });