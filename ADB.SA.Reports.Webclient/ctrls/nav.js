//var app = angular.module('saApp', ['saResourceService', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tpls']);

angular.module('saApp').controller('NavCtrl', ['$scope', 'MenuService', function ($scope, MenuService) {
    $scope.load = function () {
        MenuService.get(function (data) {
            $scope.nav = data;
        });
    };

    $scope.load();
}]);
