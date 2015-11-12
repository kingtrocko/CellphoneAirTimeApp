angular.module('privilege').controller('NewPrivilegeController', [
    '$scope', 'privilegeService', '$http', '$q', '$routeParams', '$window', '$location', 'viewModelHelper',
    function ($scope, privilegeService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

        $scope.privilegeService = privilegeService;


        $scope.navigateToPrivilegesLis = function() {
            viewModelHelper.navigateTo("security/privileges");
        }
    }
]);