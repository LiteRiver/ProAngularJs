angular.module("SportsStore")
    .controller("CartSummaryCtrl", function ($scope, Cart) {
        $scope.cartData = Cart.getProducts();

        $scope.total = function () {
            var total = 0;
            for (var i = 0; i < $scope.cartData.length; i++) {
                total += ($scope.cartData[i].price * $scope.cartData[i].count);
            }

            return total;
        };

        $scope.remove = function (id) {
            Cart.removeProduct(id);
        };
    });