//var app = angular.module('saApp', []);

angular.module('saApp').controller('IndexCtrl', ['$scope', 'EntityService', '$routeParams', '$modal', '$log', function ($scope, EntityService, $routeParams, $modal, $log) {
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

    $scope.openAcronymModal = function (id) {
        console.log(id);
        var modalInstance = $modal.open({
            templateUrl: 'test.html',
            controller: 'ModalInstanceCtrl',
            resolve: {
                modalId: function () {
                    return id;
                }
            }
        });

        modalInstance.result.then(function (result) {
            
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };


    $scope.load();
}]);

angular.module('saApp').controller('ModalInstanceCtrl', function ($scope, $modalInstance, modalId, DetailService) {

        $scope.ok = function () {
            $modalInstance.close('closed');
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        $scope.load = function () {
            console.log(modalId);
            DetailService.get({ recordId: modalId }, function (data) {
                $scope.data = data;
            });
        };
        $scope.load();
    });