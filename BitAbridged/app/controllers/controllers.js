(function() {
    'use strict';
    angular.module('BitAbridged')
        .controller('WelcomeController', ['$scope', 'searchService', welcomeController])
        .controller('LoginController', ['authService', '$location', '$scope', loginController])
        .controller('HeaderController', ['$scope', '$rootScope', 'searchService', 'authService', headerController])
        .controller('LanguageController', ['$scope', '$rootScope', '$stateParams', '$location', languageController])
        .filter('SearchFilter', [
            function() {
                return function(items, searchText) {
                    var filtered = [];
                    if (searchText && items[0].Name) {
                        searchText = searchText.toLowerCase();
                        angular.forEach(items, function (item) {
                            if (item.Name.toLowerCase().indexOf(searchText) >= 0 || item.Use.toLowerCase().indexOf(searchText) >= 0) filtered.push(item);
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

    function headerController($scope, $rootScope, searchService, authService) {
        var vm = this;
        $scope.mouseOver = true;
        vm.clear = function () { $scope.query = '' }
        vm.searchable = 
        searchService.load().then(function (data) {
            $rootScope.languages = data;
            $rootScope.loaded = true;
            vm.languages = data;
            vm.loaded = true;
        });
        vm.isLoggedIn = function () {
            if (authService.isLoggedIn()) {
                return true;
            } else {
                return false;
            }
        };
        vm.logout = authService.logout;
        $scope.vm = vm;
    }

    function loginController(authService, $location, $scope) {
        var vm = this;
        $scope.vm = vm;
        vm.login = function () {
            authService.login(vm.username, vm.password).then($location.path('/'), console.log("controller error"));
        }
    }

    function languageController($scope, $rootScope, $stateParams, $location) {
        var vm = this;
        if (!$rootScope.languages) {
            $location.path('/');
        } else {
            vm.languages = $rootScope.languages;
        }
        vm.lang = $stateParams.lang;
        vm.language = vm.languages.filter(function(data) {
            return vm.lang == data.Name;
        });
        console.log(vm.language[0].FF1);
        vm.catagories;
        $scope.vm = vm;
    }
})();