//var app = angular.module('saApp', []);

angular.module('saApp').controller('IndexCtrl', ['$scope', function ($scope) {
    $scope.load = function () {
        console.log('Index load');
    };

    $scope.load();
}]);
