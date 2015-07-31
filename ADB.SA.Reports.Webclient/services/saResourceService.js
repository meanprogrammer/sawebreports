'use strict';

angular.module('saResourceService', ['ngResource'])
	   .factory(
		'MenuService',
		function ($resource) {
		    return $resource('/api/service/Menu',
					{}, {
					    get: { method: 'GET', isArray: true }
					});
		}).factory(
		'HomeService',
		function ($resource) {
		    return $resource('/api/service/Home',
					{}, {
					    get: { method: 'GET', isArray: false }
					});
		}).factory(
		'EntityService',
		function ($resource) {
		    return $resource('/api/service/Index/:recordId',
					{}, {
					    get: { method: 'GET', isArray: false }
					});
		}).factory(

		'DiagramResizeService',
		function ($resource) {
		    return $resource('/api/DiagramResize/Resize/:recordId/:percentage',
					{}, {
					    get: { method: 'POST', isArray: false }
					});
		}).factory(
		'DetailService',
		function ($resource) {
		    return $resource('/api/service/Detail/Index/:recordId',
					{}, {
					    get: { method: 'GET', isArray: false }
					});
		});
