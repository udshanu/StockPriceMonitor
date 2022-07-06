stockApp.controller("StockController", function ($scope, $timeout, StockControllerService) {

    $scope.stop = false;

    $scope.GetAllPriceSourcesAndAllRelatedTickers = function () {

        StockControllerService.GetAllPriceSourcesAndAllRelatedTickers().then(function (response) {
            if (response.data.responseCode == 200) {
                $scope.PriceSourceList = response.data.data.priceSourceList;

                $scope.PriceSourceId = $scope.PriceSourceList[0].id;

                $scope.AllTickerList = response.data.data.tickerList;

                $scope.GetSelectedTickerList();
            }
            else {
                console.log('Something went wrong!!!');
            }
        });

    }

    $scope.GetSelectedTickerList = function () {
        $scope.TickerList = $scope.AllTickerList.filter(x => x.priceSourceId == $scope.PriceSourceId);

        $scope.TickerId = $scope.TickerList[0].id;

        $scope.GetLastFiveStockPrices();
    }

    $scope.GetLastFiveStockPrices = function () {

        if ($scope.stop) return;

        StockControllerService.GetLastFiveStockPrices($scope.TickerId).then(function (response) {
            if (response.data.responseCode == 200) {

                if (response.data.data == 0) {

                }

                $scope.TableDataResult = response.data.data;
            }
            else {
                console.log('Something went wrong!!!');
            }
        });

        $timeout($scope.GetLastFiveStockPrices, 2000);
    }

});