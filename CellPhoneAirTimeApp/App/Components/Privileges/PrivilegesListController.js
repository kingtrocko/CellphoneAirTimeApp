angular.module('privilege').controller('PrivilegesListController', [
    '$scope', 'privilegeService', '$http', '$q', '$routeParams', '$window', '$location', 'viewModelHelper',
    function ($scope, privilegeService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

        $scope.privilegeService = privilegeService;

        $scope.goToNewPrivilegeForm = function() {
            viewModelHelper.navigateTo("security/privileges/new");
        }

        var getPrivileges = function() {
            viewModelHelper.apiGet('api/privileges', null,
              function (result) {
                  $('.dt-privileges').DataTable({
                      data: result.data,
                      "columns": [
                          { "data": "id" },
                          { "data": "name" },
                          { "data": "description" }
                      ]
                  });
              }, function (result) {
                    alert('error');
                });
        }

        var initialize = function() {
            getPrivileges();
        }

        initialize();
    }
]);