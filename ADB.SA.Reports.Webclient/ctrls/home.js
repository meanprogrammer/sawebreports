//var app = angular.module('saApp', ['saResourceService', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tpls']);

angular.module('saApp').controller('HomeCtrl', ['$scope', function ($scope) {
    $scope.load = function () {
        console.log('home init');
    };

    $scope.load();
}]);
