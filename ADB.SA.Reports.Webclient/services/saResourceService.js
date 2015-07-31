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
		}).factory(
		'DiagramResizeService',
		function ($resource) {
		    return $resource('/api/Index/Resize/:recordId/:percentage',
					{}, {
					    get: { method: 'POST', isArray: false }
					});
		}).factory(
		'DetailService',
		function ($resource) {
		    return $resource('/api/Detail/Index/:recordId',
					{}, {
					    get: { method: 'GET', isArray: false }
					});
		});
