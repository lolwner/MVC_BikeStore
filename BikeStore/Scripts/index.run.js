var app = angular.module('BikeStore', [])
.run(function () {
}).config(['$controllerProvider', function ($controllerProvider) {
    $controllerProvider.allowGlobals();
    }])
;