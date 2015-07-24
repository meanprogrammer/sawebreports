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
            case 79:
                templateUrl = 'sysarch.html';
                break;
            default:
                templateUrl = 'generic.html'
                break;
        }
        return templateUrl;
    };



    $scope.openAcronymModal = function (id) {
         var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'acronymModal.html',
            controller: 'AcronymModalInstanceCtrl',
            size: 'md',
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

    $scope.openActivityOverviewModal = function (id) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'activityOverviewModal.html',
            controller: 'ActivityOverviewModalInstanceCtrl',
            size: 'md',
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

    $scope.openActivityUserModal = function (id) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'activityUserModal.html',
            controller: 'ActivityUserModalInstanceCtrl',
            size: 'md',
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

    $scope.openBrmActivityModal = function (id) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'activityOverviewModal.html',
            controller: 'BrmActivityModalInstanceCtrl',
            size: 'md',
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

    $scope.openHistoryUserModal = function (id) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'historyUserModal.html',
            controller: 'HistoryUserModalInstanceCtrl',
            size: 'md',
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

    $scope.generateReport2 = function () {
        console.log("generating reports");
    };

    $scope.load();
}]);

angular.module('saApp').controller('AcronymModalInstanceCtrl', function ($scope, $modalInstance, modalId, DetailService) {

        $scope.cancel = function () {
            $modalInstance.dismiss();
        };

        $scope.load = function () {
            DetailService.get({ recordId: modalId }, function (data) {
                $scope.data = data;
            });
        };

        $scope.load();
});

angular.module('saApp').controller('ActivityOverviewModalInstanceCtrl', function ($scope, $modalInstance, modalId, DetailService) {

    $scope.cancel = function () {
        $modalInstance.dismiss();
    };

    $scope.load = function () {
        DetailService.get({ recordId: modalId }, function (data) {
            $scope.data = data;
        });
    };

    $scope.load();
});

angular.module('saApp').controller('ActivityUserModalInstanceCtrl', function ($scope, $modalInstance, modalId, DetailService) {

    $scope.cancel = function () {
        $modalInstance.dismiss();
    };

    $scope.load = function () {
        DetailService.get({ recordId: modalId }, function (data) {
            $scope.data = data;
        });
    };

    $scope.load();
});

angular.module('saApp').controller('BrmActivityModalInstanceCtrl', function ($scope, $modalInstance, modalId, DetailService) {

    $scope.cancel = function () {
        $modalInstance.dismiss();
    };

    $scope.load = function () {
        DetailService.get({ recordId: modalId }, function (data) {
            $scope.data = data;
        });
    };

    $scope.load();
});

angular.module('saApp').controller('HistoryUserModalInstanceCtrl', function ($scope, $modalInstance, modalId, DetailService) {

    $scope.cancel = function () {
        $modalInstance.dismiss();
    };

    $scope.load = function () {
        DetailService.get({ recordId: modalId }, function (data) {
            $scope.data = data;
        });
    };

    $scope.load();
});