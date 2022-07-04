stockApp.controller("StockController", function ($scope, StockControllerService) {

    $scope.InitialConfigurations = function () {
        $scope.GetAllTickers();
        $scope.GetAllPriceSources();
        $scope.GetLastFiveStockPrices(3);
    }

    $scope.GetAllTickers = function () {
        StockControllerService.GetAllTickers().then(function (response) {
            if (response.status == 200) {
                $scope.AllTickerList = response.data;
                $scope.GetSelectedTickerList($scope.PriceSourceId);
            }
            else {

            }
        });
    }

    $scope.GetAllPriceSources = function () {
        StockControllerService.GetAllPriceSources().then(function (response) {
            if (response.status == 200) {
                $scope.PriceSourceList = response.data;
                $scope.PriceSourceId = $scope.PriceSourceList[0].id;
            }
            else {

            }
        });
    }

    $scope.GetSelectedTickerList = function (sourceId) {
        $scope.TickerList = $scope.AllTickerList.filter(x => x.priceSourceId == sourceId);
    }

    $scope.GetLastFiveStockPrices = function (tickerId) {
        StockControllerService.GetLastFiveStockPrices(tickerId).then(function (response) {
            if (response.status == 200) {
                $scope.TableDataResult = response.data;
            }
            else {

            }
        });
    }
});