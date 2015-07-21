(function() {
    'use strict';
    angular.module('BitAbridged')
        .controller('WelcomeController', ['$scope', 'searchService', welcomeController])
        .controller('LoginController', ['authService', '$location', '$scope', loginController])
        .controller('HeaderController', ['$scope', 'searchService', headerController])
        .controller('DemoController', ['$scope', demoController])
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
        vm.clear = function (){$scope.query = ''}
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

    function demoController($scope) {
        var vm = this;
        vm.catagories =
            [
                {
                    'Name': 'Data Types', 'Items': [
                      {
                          'Name': 'All',
                          'Contents': {
                              'Description' : "Python variable types don't have to be explicitly declared. The type declaration happens automatically when a value is assigned.",
                              'Syntax': 'variable_name = value',
                              'Example': 'x = 5'}
                      }]
                },
               {
                   'Name': 'Data Structures', 'Items': [
                     {
                         'Name': 'List',
                         'Contents': {
                             'Description': "Holds elements in sequence. List indexing begins on zero and items do not have to be of the same data type.",
                             'Syntax': 'list = [element1, element2, element3];',
                             'Example': 'list = ["blue", "yellow", 1, 2];\n\t print(list[1])'
                         }
                     },
                    {
                        'Name': 'Dictionary',
                        'Contents': {
                            'Description': 'A structure containing items which consist of a key and a value.',
                            'Syntax': 'dict = {key1 : value1, key2 : value2}'
                        }
                    }]
               },
                {
                    'Name': 'File IO', 'Items': [
                      {
                          'Name': 'Read',
                          'Contents': {
                              'Description': "Open a file for reading.",
                              'Syntax': 'file_object = open(filename, access_mode)',
                              'Example': "foo = open('file.txt', 'r')"}
                      },
                    {
                        'Name':'Write',
                        'Contents':{
                            'Description': 'Open a file for writting',
                            'Syntax': 'file_object = open(filename, access_mode)',
                            'Example': "foo = open('file.txt', 'w')",
                            'Opens file.txt for writing. Overwrites file if it exists and creates the file it does not.':''
                        }
                    }]}];
        vm.message = 'demo page!';
        $scope.vm = vm;
    }
})();