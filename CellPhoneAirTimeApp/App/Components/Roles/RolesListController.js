angular.module("role").controller("RolesListController", [
    '$scope', 'roleService', '$http', '$q', '$routeParams', '$window', '$location', 'viewModelHelper',
    function ($scope, roleService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

        $scope.roleService = roleService;

        $scope.navigateToNewRoleForm = function() {
            viewModelHelper.navigateTo('security/roles/new');
        }

        var getRoles = function() {
            viewModelHelper.apiGet('api/roles', null,
               function (result) {
                   $('.dt-roles').DataTable({
                       data: result.data,
                       "columns": [
                           { "data": "id" },
                           { "data": "name" },
                           { "data": "description" },
                           { "data": "isSysAdmin" }
                       ]
                   });
               }, function (result) {

               });
        }

        var initialize = function() {
            getRoles();
        }

        initialize();

    }
]);