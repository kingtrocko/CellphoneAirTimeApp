angular.module('settings').controller('MySettingsController',
    ['$scope', 'settingsService', '$http', '$q', '$routeParams', '$window', '$location', 'viewModelHelper',
    function ($scope, settingsService, $http, $q, $routeParams, $window, $location, viewModelHelper) {
        console.log('getting here');
        $scope.viewModelHelper = viewModelHelper;
        $scope.settingsService = settingsService;

        var resetPasswordObj = {
            password: '',
            confirmPassword: ''
        }

        var initialize = function () {
            $scope.getSettings();
            $scope.passwordObject = resetPasswordObj;
        }

        $scope.getSettings = function() {
            viewModelHelper.apiGet('api/account/settings', null, function (result) {
                var user = {};
                user = result.data;
                user.role = 'Administrador';

                $scope.user = user;
                console.log(result);

            });
        }

        $scope.resetPassword = function() {
            viewModelHelper.apiPut('api/account/settings', null, function(result) {

            });
        }

        initialize();
    
}]);
