(function() {
    'use strict';
    angular.module('BitAbridged')
        .controller('WelcomeController', ['$scope', 'searchService', welcomeController])
        .controller('LoginController', ['authService', '$location', '$scope', loginController])
        .controller('HeaderController', ['$scope', 'searchService', headerController])
        .controller('DemoController', demoController)
        .filter('SearchFilter', [
            function() {
                return function(items, searchText) {
                    var filtered = [];
                    if (searchText && items[0].Name) {
                        searchText = searchText.toLowerCase();
                        angular.forEach(items, function (item) {
                            if (item.Name.toLowerCase().indexOf(searchText) >= 0 || item.Description.toLowerCase().indexOf(searchText) >= 0) filtered.push(item);
                        });
                    } 
                    return filtered;
                }
            }
        ]);

    function welcomeController($scope) {
        var vm = this;
        vm.message = 'Welcome!';
        $scope.vm = vm;
    }

    function headerController($scope, searchService) {
        var vm = this;
        vm.searchable = 
        searchService.preload().then(function (data) {
            vm.searchable = data;
        });
        $scope.vm = vm;
        $scope.isLoggedIn = function () {
            return true;
        }
    }

    function loginController(authService, $location, $scope) {
        var vm = this;
        $scope.vm = vm;
        vm.login = function () {
            authService.login(vm.username, vm.password).then($location.path('/'), console.log("controller error"));
        }
    }

    function demoController() {
        var vm = this;
        vm.message = 'demo page!';
    }
})();