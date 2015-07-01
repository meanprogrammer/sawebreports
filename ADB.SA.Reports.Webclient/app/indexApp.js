var app = angular.module('saApp', ['saResourceService', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tpls']).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
            when('/', { templateUrl: 'html/home.html', controller: 'HomeCtrl' }).
            when('/Entity/:recordId', { templateUrl: 'html/process.html', controller: 'IndexCtrl' }).
            when('/impactanalysis', { templateUrl: 'html/impactanalysis.html', controller: 'ImpactAnalysisCtrl' })
        .otherwise({ redirectTo: '/' });
    }]);