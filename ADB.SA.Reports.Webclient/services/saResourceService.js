'use strict';

angular.module('saResourceService', ['ngResource'])
	   .factory(
		'MenuService',
		function ($resource) {
		    return $resource('/api/Menu',
					{}, {
					    get: { method: 'GET', isArray: true }
					});
		}).factory(
		'HomeService',
		function ($resource) {
		    return $resource('/api/Home',
					{}, {
					    get: { method: 'GET', isArray: false }
					});
		}).factory(
		'EntityService',
		function ($resource) {
		    return $resource('/api/Index/Index/:recordId',
					{}, {
					    get: { method: 'GET', isArray: false }
					});
		});
