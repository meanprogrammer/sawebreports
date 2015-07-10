var app = angular.module('saApp', ['saResourceService', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tpls']).
    config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider.
            //when('/', { templateUrl: 'html/home.html', controller: 'HomeCtrl' }).
            when('/index', { templateUrl: 'html/home.html', controller: 'HomeCtrl' }).
            when('/index/:recordId', { templateUrl: 'html/indexContent.html', controller: 'IndexCtrl' }).
            when('/impactanalysis', { templateUrl: 'html/impactanalysis.html', controller: 'ImpactAnalysisCtrl' })
        .otherwise({ redirectTo: '/index' });
        //$locationProvider.html5Mode(true);
    }]);

app.directive('showtab',
    function () {
        return {
            link: function (scope, element, attrs) {
                element.click(function (e) {
                    e.preventDefault();
                    $(element).tab('show');
                });
            }
        };
    });