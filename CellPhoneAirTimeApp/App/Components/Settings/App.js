
var settingsModule = angular.module("settings", ["common"])
    .config([
        "$routeProvider", "$locationProvider", function($routeProvider, $locationProvider) {
            $routeProvider.
                when("/mysettings",
                {
                    templateUrl: "App/Components/Settings/Views/MySettingsInfo.html",
                    controller: "MySettingsController"
                });
            $routeProvider.otherwise({ redirectTo: "/mysettings" });
            $locationProvider.html5Mode(true);
        }
    ]);

settingsModule.factory("settingsService", ["$rootScope", "$http", "$q", "$location", "viewModelHelper",
    function ($rootScope, $http, $q, $location, viewModelHelper) {
    return MyApp.settingsService($rootScope, $http, $q, $location, viewModelHelper);
}]);

(
    function(myApp) {
        var settingsService = function($rootScope, $http, $q, $location, viewModelHelper) {

            var self = this;

            self.firstName = "";
            self.lastName = "";
            self.address1 = "";
            self.address2 = "";
            self.userName = "";
            self.email = "";
            self.phoneNumber = "";
            self.fullName = "";
            self.role = "";
            self.password = "";
            self.confirmPassword = "";

            return this;
        };

        myApp.settingsService = settingsService;

    }(window.MyApp)
);
