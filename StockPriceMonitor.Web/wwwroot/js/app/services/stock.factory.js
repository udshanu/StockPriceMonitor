stockApp.factory('StockControllerService', function ($http) {
    var service = {
        GetAllPriceSources: function () {
            return $http.get("https://localhost:44386/api/PriceSource");
        },
    };

    return service;
});