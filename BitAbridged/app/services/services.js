(function() {
    'use strict';
    angular.module('BitAbridged')
        .factory('authService', function($http, $q, $window) {
            var service = {};
            service.login = login;
            service.logout = logout;
            service.isLoggedIn = isLoggedIn;

            function login(username, password) {
                var deferred = $q.defer();
                $http({
                    url: '/api/Token',
                    method: 'POST',
                    data: 'username=' + username + '&password=' + password + '&grant_type=password',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success(function(data) {
                    $window.sessionStorage.setItem('token', data.access_token);
                    deferred.resolve();
                }).error(function(err) {
                    console.log(err);
                    deferred.reject();
                });
                return deferred.promise;
            }

            function logout() {
                $window.sessionStorage.removeItem('token');
                service.thirdParty = null;
            }

            function isLoggedIn() {
                var loggedIn = $window.sessionStorage.getItem('token');
                if (loggedIn) {
                    return true;
                } else {
                    return false;
                }
            }

            return service;
        });

    angular.module('BitAbridged')
        .factory('searchService', function ($http, $q) {
            var service = {};
            var searchable;
            service.preload = preload;
            function preload() {
                var deferred = $q.defer();
                $http({
                    url: '/api/Search',
                    method: 'GET'
                }).success(function (data) {
                    searchable = data;
                    deferred.resolve(searchable);
                }).error(function (err) {
                    console.log(err);
                    deferred.reject();
                });
                return deferred.promise;
            }

            return service;
        });

})();