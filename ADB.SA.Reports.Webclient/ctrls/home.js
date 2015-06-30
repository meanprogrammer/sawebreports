//var app = angular.module('saApp', ['saResourceService', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tpls']);

angular.module('saApp').controller('HomeCtrl', ['$scope', 'HomeService', function ($scope, HomeService) {
    $scope.load = function () {
        HomeService.get(function (data) {
            $scope.homeData = data;
        });
    };

    $scope.load();
}]);
