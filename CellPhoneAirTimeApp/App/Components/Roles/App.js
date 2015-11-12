var roleModule = angular.module("role", ["common"])
    .config([
        "$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
            $routeProvider.
                when("/security/roles",
                {
                    templateUrl: "/App/Components/Roles/Views/RolesList.html",
                    controller: "RolesListController"
                });
            $routeProvider.when("/security/roles/new",
                {
                    templateUrl: "/App/Components/Roles/Views/RolForm.html",
                    controller: "NewRoleController"
                });
            $routeProvider.otherwise({ redirectTo: "/security/roles" });
            $locationProvider.html5Mode(true);
        }
    ]);

roleModule.factory("roleService", ["$rootScope", "$http", "$q", "$location", "viewModelHelper",
    function ($rootScope, $http, $q, $location, viewModelHelper) {
        return MyApp.roleService($rootScope, $http, $q, $location, viewModelHelper);
    }]);

(
    function (myApp) {
        var roleService = function ($rootScope, $http, $q, $location, viewModelHelper) {

            var self = this;

            self.id = "";
            self.name = "";
            self.description = "";

            return this;
        };

        myApp.roleService = roleService;

    }(window.MyApp)
);