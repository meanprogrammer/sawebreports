//var app = angular.module('saApp', []);

angular.module('saApp').controller('IndexCtrl', ['$scope', 'EntityService', '$routeParams', function ($scope, EntityService, $routeParams) {
    $scope.load = function () {
        EntityService.one.get({ recordId: $routeParams.recordId }, function (data) {
            console.log(data);
        });
    };

    $scope.load();
}]);
