var app = angular.module('saApp', ['saResourceService', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tpls']).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
            when('/index', { templateUrl: 'index/indexContent.html', controller: 'IndexCtrl' }).
            otherwise({ redirectTo: '/index' });
    }]);