var TC = angular.module('BikeStore');


TC.directive('goodcard', function () {
    var directive = {
        restrict: 'E',
        templateUrl: '../Scripts/Card/goodcard.html',
        scope: {
            item: '=',
            id: "@"
        },
        controller: GoodCardController,
        controllerAs: 'goodcard',
        bindToController: true,
        link: function (scope, elem, attrs) {
            elem.on('click', function (e) {
                this.style.zoom = this.style.zoom ? '' : 1.4;
            });
        }
    };
    return directive;


    function GoodCardController($scope, $filter) {
        var vm = this;
    }
});