'use strict';

angular.module('saResourceService', ['ngResource'])
	    .factory('EntityService', function ($resource) {
	        return {

	            one: $resource('/api/Entity/:recordId', {}, {
	                get: {
	                    method: 'GET',
	                    isArray: false
	                }
	            })
	        };
	    }).factory(
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
		});
