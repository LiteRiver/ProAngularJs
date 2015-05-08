angular.module("Cart", [])
    .factory("Cart", function () {
        var cartData = [];
        return {
            addProduct: function (id, name, price) {
                var addToExistingItem = false;

                for (var i = 0; i < cartData.length; i++) {
                    if (cartData[i].id === id) {
                        cartData[i].count++;
                        addToExistingItem = true;
                        break;
                    }
                }

                if (!addToExistingItem) {
                    cartData.push({
                        count: 1,
                        id: id,
                        price: price,
                        name: name
                    });
                }
            },
            removeProduct: function (id) {
                for (var i = 0; i < cartData.length; i++) {
                    if (cartData[i].id === id) {
                        cartData.splice(i, 1);
                        break;
                    }
                }
            },
            getProducts: function () {
                return cartData;
            }
        };
    })
    .directive("cartSummary", function (Cart) {
        return {
            restrict: 'E',
            templateUrl: "components/cart/CartSummary.html",
            controller: function ($scope) {
                var cartData = Cart.getProducts();

                $scope.total = function () {
                    var total = 0;
                    for (var i = 0; i < cartData.length; i++) {
                        total += (cartData[i].price * cartData[i].count);
                    }
                    return total;
                };

                $scope.itemCount = function () {
                    var total = 0;
                    
                    for (var i = 0; i < cartData.length; i++) {
                        total += cartData[i].count;
                    }

                    return total;
                };
            }
        };
    });