//var app = angular.module('saApp', []);

angular.module('saApp').controller('IndexCtrl', ['$scope', 'EntityService', '$routeParams', function ($scope, EntityService, $routeParams) {
    $scope.load = function () {
        EntityService.get({ recordId: $routeParams.recordId }, function (data) {
            $scope.data = data;
            console.log(data);
            $scope.templateUrl = $scope.getCorrectTemplate(data.Content.DiagramType);
            console.log($scope.templateUrl);
        });
    };

    $scope.getTemplateUrl = function () { return $scope.templateUrl; };

    $scope.getCorrectTemplate = function (type) {
        var templateUrl = '';
        switch (type) {
            case 111:
                templateUrl = 'process.html'
                break;
            case 142:
                templateUrl = 'subprocess.html'
                break;
            default:
                break;
        }
        return templateUrl;
    };

    $scope.load();
}]);
