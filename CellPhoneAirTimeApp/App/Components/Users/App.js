var usersModule = angular.module('users', ['common'])
    .config([
        "$routeProvider", "$locationProvider", function($routeProvider, $locationProvider) {
            $routeProvider.
                when("/security/users",
                {
                    templateUrl: "/App/Components/Users/Views/UsersList.html",
                    controller: "UsersListController"
                });
            $routeProvider.
                when("/security/users/new",
                {
                    templateUrl: "/App/Components/Users/Views/UserForm.html",
                    controller: "NewUserController"
                });
            $routeProvider.otherwise({ redirectTo: "/security/users" });
            $locationProvider.html5Mode(true);
        }
    ]);


usersModule.factory("usersService", ["$rootScope", "$http", "$q", "$location", "viewModelHelper",
    function ($rootScope, $http, $q, $location, viewModelHelper) {
        return MyApp.usersService($rootScope, $http, $q, $location, viewModelHelper);
    }]);

(
    function (myApp) {
        var usersService = function ($rootScope, $http, $q, $location, viewModelHelper) {

            var self = this;

            self.id = "";
            self.address1 = "";
            self.userName = "";
            self.email = "";
            self.phoneNumber = "";
            self.fullName = "";
            self.status = "";

            return this;
        };

        myApp.usersService = usersService;

    }(window.MyApp)
);