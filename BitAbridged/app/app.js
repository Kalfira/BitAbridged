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
            }).state('login', {
                url: '/login',
                templateUrl: 'app/views/login.html',
                controller: 'LoginController'
            }).state('languages', {
                url: '/languages/',
                templateUrl: 'app/views/languages.html',
                controller: 'LanguagesController'
            }).state('language', {
                url: '/languages/:lang',
                templateUrl: 'app/views/language.html',
                controller: 'LanguageController'
            });
    }
})();