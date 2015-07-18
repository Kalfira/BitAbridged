(function() {
    'use strict';
    angular.module('BitAbridged')
        .controller('WelcomeController', welcomeController)
        .controller('LoginController', ['authService', loginController])
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

    function loginController() {
        var vm = this;
        vm.login = function () {
            authService.login(vm.username, vm.password).then();
        }
    }

    function demoController() {
        var vm = this;
        vm.message = 'demo page!';
    }
})();