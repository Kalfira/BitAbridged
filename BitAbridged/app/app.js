(function() {
    'use strict';
    var app = angular.module('BitAbridged', ['ui.router']);

    app.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', Config]);

    function Config($stateProvider, $urlRouterProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: 'app/views/welcome.html',
                controller: 'WelcomeController'
            })
            .state('demo', {
                url: '/demo',
                controller: 'DemoController',
                templateUrl: 'app/views/demo.html'
            }).state('login', {
                url: '/login',
                templateUrl: 'app/views/login.html',
                controller: 'LoginController'
            }).state('preview', {
                url: '/preview',
                templateUrl: 'app/views/preview.html',
            });
    }

    //function Config($routeProvider, $locationProvider) {
    //    $locationProvider.html5Mode(true);
    //    $routeProvider.when('/', {
    //        templateUrl: 'app/views/welcome.html',
    //        controller: 'WelcomeController',
    //        controllerAs: 'vm'
    //    }).when('/demo', {
    //        templateUrl: 'app/views/demo.html',
    //        controller: 'DemoController',
    //        controllerAs: 'vm'
    //    }).when('/login', {
    //        templateUrl: 'app/views/login.html',
    //        controller: 'LoginController'
    //        })
    //        .otherwise({
    //        redirectTo: '/'
    //        });
        
    //}
})();