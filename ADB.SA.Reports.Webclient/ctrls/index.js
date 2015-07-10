//var app = angular.module('saApp', []);

angular.module('saApp').controller('IndexCtrl', ['$scope', 'EntityService', '$routeParams', function ($scope, EntityService, $routeParams) {
    $scope.load = function () {
        EntityService.get({ recordId: $routeParams.recordId }, function (data) {
            $scope.data = data;
            $scope.templateUrl = $scope.getCorrectTemplate(data.Content.DiagramType);
        });
    };

    $scope.getTemplateUrl = function () { return $scope.templateUrl; };

    $scope.getCorrectTemplate = function (type) {
        console.log(type);
        var templateUrl = '';
        switch (type) {
            case 111:
                templateUrl = 'process.html'
                break;
            case 142:
                templateUrl = 'subprocess.html'
                break;
            case 145:
                templateUrl = 'strategy2020.html'
                break;
            default:
                templateUrl = 'generic.html'
                break;
        }
        return templateUrl;
    };

    $scope.load();
}]);
