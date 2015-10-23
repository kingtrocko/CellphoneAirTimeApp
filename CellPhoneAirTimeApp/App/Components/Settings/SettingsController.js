angular.module('settings').controller('MySettingsController',
    ['$scope', 'settingsService', '$http', '$q', '$routeParams', '$window', '$location', 'viewModelHelper',
    function ($scope, settingsService, $http, $q, $routeParams, $window, $location, viewModelHelper) {
        console.log('getting here');
        $scope.viewModelHelper = viewModelHelper;
        $scope.settingsService = settingsService;


        var initialize = function () {
            $scope.headingCaptionSettings = 'Caption from Controller';
            $scope.randomText = 'Some Random Text';
        }

        initialize();
    
}]);
