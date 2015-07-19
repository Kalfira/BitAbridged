(function() {
    'use strict';
    angular.module('BitAbridged')
        .controller('WelcomeController', welcomeController)
        .controller('LoginController', ['authService', '$location', '$scope', loginController])
        .controller('HeaderController', ['$scope', headerController])
        .controller('DemoController', demoController);

    function welcomeController() {
        var vm = this;
        vm.message = "Welcome!";
    }

    function headerController($scope) {
        $scope.isLoggedIn = function() {
            return true;
        }
    }

    function loginController(authService, $location, $scope) {
        var vm = this;
        $scope.vm = vm;
        console.log(vm);
        vm.login = function () {
            authService.login(vm.username, vm.password).then($location.path('/'), console.log("controller error"));
        }
    }

    function demoController() {
        var vm = this;
        vm.message = 'demo page!';
    }
})();