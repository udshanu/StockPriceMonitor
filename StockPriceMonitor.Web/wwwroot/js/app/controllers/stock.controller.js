stockApp.controller("StockController", function ($scope, $timeout, StockControllerService) {

    $scope.stop = false;
    //$scope.PriceSourceId = 0;
    //$scope.TickerId = 0;

    //$scope.isInitialState = true;


    //$scope.InitialConfigurations = function () {
    //    $scope.GetAllPriceSourcesAndAllRelatedTickers();


    //    $scope.isInitialState = false;
    //}

    //$scope.GetAllTickers = function () {
    //    StockControllerService.GetAllTickers().then(function (response) {
    //        if (response.status == 200) {
    //            $scope.AllTickerList = response.data;
    //            //$scope.GetSelectedTickerList($scope.PriceSourceId);
    //        }
    //        else {

    //        }
    //    });
    //}

    //$scope.GetAllPriceSources = function () {
    //    StockControllerService.GetAllPriceSources().then(function (response) {
    //        if (response.status == 200) {
    //            $scope.PriceSourceList = response.data;
    //            $scope.PriceSourceId = $scope.PriceSourceList[0].id;

    //        }
    //        else {

    //        }
    //    });
    //}

    $scope.GetAllPriceSourcesAndAllRelatedTickers = function () {

        if ($scope.stop) return;

        StockControllerService.GetAllPriceSourcesAndAllRelatedTickers().then(function (response) {
            if (response.status == 200) {
                $scope.PriceSourceList = response.data.priceSourceList;

                $scope.PriceSourceId = $scope.PriceSourceList[0].id;

                $scope.AllTickerList = response.data.tickerList;

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
            if (response.status == 200) {
                $scope.TableDataResult = response.data;
            }
            else {

            }
        });

        $timeout($scope.GetLastFiveStockPrices, 2000);
    }

});