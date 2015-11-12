angular.module('users').controller('NewUserController', [
    '$scope', 'usersService', '$http', '$q', '$routeParams', '$window', '$location', 'viewModelHelper',
    function ($scope, usersService, $http, $q, $routeParams, $window, $location, viewModelHelper) {
        $scope.viewModelHelper = viewModelHelper;
        $scope.usersService = usersService;

        var getSystemRoles = function() {
            var roles =
            [
                { id: 1, roleName: "Sys Admin" },
                { id: 2, roleName: "Administrador" },
                { id: 3, roleName: "Usuario Estándar" }
            ];

            var optionTemplate = '<option value="{0}">{1}</option>';
            roles.forEach(function (r) {
                var option = optionTemplate.replace('{0}', r.id).replace('{1}', r.roleName);
                $('.system-roles-listbox').append(option);
            });
            $('.system-roles-listbox').trigger('bootstrapDualListbox.refresh');
        };

        var initialize = function () {
            getSystemRoles();
        };

        initialize();

    }
]);