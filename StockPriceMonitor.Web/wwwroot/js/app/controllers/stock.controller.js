stockApp.controller("StockController", function ($scope, StockControllerService) {
    $scope.WelcomeMessage = "This is a welcome message";

    $scope.GetAllPriceSources = function () {
        StockControllerService.GetAllPriceSources().then(function (response) {
            if (response.data.ResponseCode == 200) {

            }
            else {

            }
        });
    }
});