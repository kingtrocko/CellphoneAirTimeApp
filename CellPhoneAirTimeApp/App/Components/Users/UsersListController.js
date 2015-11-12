angular.module('users').controller('UsersListController', [
    '$scope', 'usersService', '$http', '$q', '$routeParams', '$window', '$location', 'viewModelHelper',
    function($scope, usersService, $http, $q, $routeParams, $window, $location, viewModelHelper) {
        
        $scope.usersService = usersService;

        var getUsers = function () {
            viewModelHelper.apiGet('api/users', null,
               function (result) {
                   $('.dt-users').DataTable({
                       data: result.data,
                       "columns": [
                           { "data": "id" },
                           { "data": "fullName" },
                           { "data": "userName" },
                           { "data": "email" },
                           { "data": "address1" },
                           { "data": "phoneNumber" },
                           { "data": "status" }
                       ]
                   });
               }, function (result) {
                   
               });
        };


        var initialize = function() {
            getUsers();
        };

        $scope.goToNewUserForm = function() {
            viewModelHelper.navigateTo('security/users/new');
        }


        initialize();
    }
]);