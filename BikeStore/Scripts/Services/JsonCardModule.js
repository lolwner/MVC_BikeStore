var JsonCard = angular
    .module('BikeStore');

JsonCard.controller('JsonCardController', function ($scope, JsonCardService) {


    getGoods();
    function getGoods() {
        JsonCardService.getGoods()
            .success(function (g) {
                $scope.goods = g;
            })
            .error(function (error) {
                $scope.status = 'Unable to data: ' + error.message;
                console.log($scope.status);
            });
    };
});

JsonCard.factory('JsonCardService', ['$http', function ($http) {

    var JsonCardService = {};
    JsonCardService.getGoods = function () {
        return $http.get('/Store/GetGoods');
    };
    return JsonCardService;

}]);