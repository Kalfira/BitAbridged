(function() {
    'use strict';
    angular.module('BitAbridged', ['ngRoute']).config(Config);

    function Config($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $routeProvider.when('/', {
            templateUrl: 'app/views/welcome.html',
            controller: 'WelcomeController',
            controllerAs: 'vm'
        }).when('/demo', {
            templateUrl: 'app/views/demo.html',
            controller: 'DemoController',
            controllerAs: 'vm'
        }).when('/login', {
            templateUrl: '/app/views/login.html',
            controller: 'LoginController'
            })
            .otherwise({
            redirectTo: '/'
            });
        
    }
})();