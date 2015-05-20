angular.module("SportsStoreAdmin")
    .constant("AuthUrl", "/user/login")
    .constant("OrdersUrl", "/SportsStore/Orders")
    .constant("ProductsUrl", "/Products")
    .config(function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
    })
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
    })
    .controller("ProductsCtrl", function ($scope, $resource, ProductsUrl) {
        $scope.productsResource = $resource(ProductsUrl + "/:id", { id: "@id" });

        $scope.listProducts = function () {
            $scope.products = $scope.productsResource.query();
        };

        $scope.deleteProduct = function (product) {
            product.$delete().then(function () {
                $scope.products.splice($scope.products.indexOf(product), 1);
            });
        };

        $scope.createProduct = function (product) {
            new $scope.productsResource(product).$save().then(function (newProduct) {
                $scope.products.push(newProduct);
                $scope.editedProduct = null;
            });
        };

        $scope.updateProduct = function (product) {
            product.$save();
            $scope.editedProduct = null;
        };

        $scope.startEdit = function (product) {
            $scope.editedProduct = product;
        };

        $scope.cancelEdit = function () {
            $scope.editedProduct = null;
        };

        $scope.listProducts();
    });