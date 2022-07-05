stockApp.factory('StockControllerService', function ($http) {
    var service = {
        GetLastFiveStockPrices: function (tickerId) {
            return $http.get("https://localhost:44386/api/StockPrice/GetLastFiveStockPrices/" + tickerId);
        },
        GetAllPriceSourcesAndAllRelatedTickers: function () {
            return $http.get("https://localhost:44386/api/PriceSource/GetAllPriceSourcesAndAllRelatedTickers");
        },
    };

    return service;
});