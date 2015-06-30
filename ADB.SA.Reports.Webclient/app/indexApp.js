var app = angular.module('saApp', ['saResourceService', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tpls']).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
            when('/home', { templateUrl: 'html/home.html', controller: 'HomeCtrl' }).
            when('/impactanalysis', { templateUrl: 'html/impactanalysis.html', controller: 'ImpactAnalysisCtrl' })
        .otherwise({ redirectTo: '/home' });
    }]);