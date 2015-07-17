angular.module('saApp').controller('ReportCtrl', ['$scope', '$routeParams', '$location', '$window', function ($scope, $routeParams, $location, $window) {
    $scope.generateReport = function () {
        
        var baseUrl = $location.host();
                var port = $location.port().toString();

        if (port.length > 0)
        {
            baseUrl = baseUrl + ":" + port;
        }

        $window.open("http://"+baseUrl+"/api/report/report/"+$routeParams.recordId);

    };
}]);
