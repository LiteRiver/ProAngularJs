angular.module("SportsStore")
    .constant("ProductListActiveClass", "btn-primary")
    .constant("ProductListItemsPerPage", 3)
    .controller("ProductListCtrl", function ($scope, $filter, ProductListActiveClass, ProductListItemsPerPage) {
        var selectedCategory = null;

        $scope.selectedPage = 1;
        $scope.pageSize = ProductListItemsPerPage;

        $scope.selectCategory = function (newCategory) {
            selectedCategory = newCategory;
            $scope.selectedPage = 1;
        };

        $scope.selectPage = function (newPage) {
            $scope.selectedPage = newPage;
        };

        $scope.categoryFilterFn = function (product) {
            return selectedCategory == null || product.category == selectedCategory;
        };

        $scope.getCategoryClass = function (category) {
            return selectedCategory == category ? ProductListActiveClass : "";
        };

        $scope.getPageClass = function (page) {
            return $scope.selectedPage == page ? ProductListActiveClass : "";
        };
    });