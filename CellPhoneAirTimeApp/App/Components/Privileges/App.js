var privilegesModule = angular.module('privilege', ['common'])
    .config([
        "$routeProvider", "$locationProvider", function($routeProvider, $locationProvider) {
            $routeProvider.
                when("/security/privileges",
                {
                    templateUrl: "/App/Components/Privileges/Views/PrivilegesList.html",
                    controller: "PrivilegesListController"
                });
            $routeProvider.
                when("/security/privileges/new",
                {
                    templateUrl: "/App/Components/Privileges/Views/PrivilegeForm.html",
                    controller: "NewPrivilegeController"
                });
            $routeProvider.otherwise({ redirectTo: "/security/privileges" });
            $locationProvider.html5Mode(true);
        }
    ]);

privilegesModule.factory("privilegeService", ["$rootScope", "$http", "$q", "$location", "viewModelHelper",
    function ($rootScope, $http, $q, $location, viewModelHelper) {
        return MyApp.privilegeService($rootScope, $http, $q, $location, viewModelHelper);
    }]);

(
    function (myApp) {
        var privilegeService = function ($rootScope, $http, $q, $location, viewModelHelper) {

            var self = this;

            self.id = "";
            self.name = "";
            self.descripcion = "";
            return this;
        };

        myApp.privilegeService = privilegeService;

    }(window.MyApp)
);