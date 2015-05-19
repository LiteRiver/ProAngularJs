angular.module("SportsStoreAdmin")
    .constant("AuthUrl", "/user/login")
    .constant("OrdersUrl", "/SportsStore/Orders")
    .controller("AuthCtrl", function ($scope, $http, $location, AuthUrl) {
        $scope.authenticate = function (username, password) {
            $http.post(AuthUrl, {
                username: username,
                password: password
            }, {
                withCredentials: true
            }).success(function (data) {
                $location.path("/main");
            }).error(function (error, status) {
                $scope.authenticateError = error;
                $scope.authenticationStatus = status;
            });
        };
    })
    .controller("MainCtrl", function ($scope) {
        $scope.screens = ["Products", "Orders"];
        $scope.current = $scope.screens[0];

        $scope.setScreen = function (index) {
            $scope.current = $scope.screens[index];
        };

        $scope.getScreen = function () {
            return $scope.current === "Products" ? "views/AdminProducts.html" : "views/AdminOrders.html";
        };
    })
    .controller("OrdersCtrl", function ($scope, $http, OrdersUrl) {
        $http.get(OrdersUrl, { withCredentials: true }).success(function (data) {
            $scope.orders = data;
        }).error(function (error, status) {
            $scope.error = error;
        });

        $scope.selectOrder = function (order) {
            $scope.selectedOrder = order;
        };

        $scope.calcTotal = function (order) {
            var total = 0;
            for (var i = 0; i < order.products.length; i++) {
                total += order.products[i].count * order.products[i].price;
            }
            return total;
        };
    });