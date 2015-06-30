//var app = angular.module('saApp', ['saResourceService', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tpls']);

angular.module('saApp').controller('ImpactAnalysisCtrl', ['$scope', function ($scope) {
    $scope.load = function () {
        console.log('ia init');
    };

    $scope.load();
}]);
