'use strict';

angular.module('saResourceService', ['ngResource'])
	    .factory('EntityService', function ($resource) {
		    return {

		        one: $resource('/Entity/:recordId', {}, {
		            get: {
		                method: 'GET'
		            }
		        })
		    };
		});