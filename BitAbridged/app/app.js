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
                views: {
                    '':{templateUrl:'app/views/demo.html'},
                    'columnOne@demo': { template: 'columnOne!' },
                    'columnTwo@demo': {template: 'columnTwo!'}
                }
            }).state('login', {
                url: '/login',
                templateUrl: 'app/views/login.html',
                controller: 'LoginController'
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