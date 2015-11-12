angular.module('settings').controller('MySettingsController',
[
    '$scope', 'settingsService', '$http', '$q', '$routeParams', '$window', '$location', 'viewModelHelper', 'blockUiService',
    function($scope, settingsService, $http, $q, $routeParams, $window, $location, viewModelHelper, blockUiService) {


        $scope.viewModelHelper = viewModelHelper;
        $scope.settingsService = settingsService;


        var initialize = function() {
            getSettings();
            $scope.remoteErrors = [];
            $scope.showGenericServerError = false;
        }

        function getSettings() {
            $scope.remoteErrors = [];
            $scope.showGenericServerError = false;

            viewModelHelper.apiGet('api/account/settings', null,
                function(result) {
                    settingsService.firstName = result.data.firstName;
                    settingsService.lastName = result.data.lastName;
                    settingsService.address1 = result.data.address1;
                    settingsService.address2 = result.data.address2;
                    settingsService.userName = result.data.userName;
                    settingsService.email = result.data.email;
                    settingsService.phoneNumber = result.data.phoneNumber;
                    settingsService.fullName = result.data.fullName;
                    settingsService.role = 'Administrador';

                }, function(result) {
                    $scope.showGenericServerError = true;
                });
        }

        $scope.onSubmitSettingsForm = function() {
            //$('#server-errors-list').remove();
            //$('form[name="settings-form"]').prepend('<div server-errors></div>');

            $scope.remoteErrors = [];
            $scope.showGenericServerError = false;

            if ($('form[name="settings-form"]').valid()) {
                blockUiService.blockPage();
                viewModelHelper.apiPut('api/account/settings/update', settingsService,
                    function(result) {
                        console.log('onSuccess');
                        blockUiService.setError(false);
                    },
                    function(result) {
                        console.log('onError');
                        blockUiService.setError(true);
                        if (result.status === 400) {
                            $scope.remoteErrors = result.data.errors;
                        } else {
                            $scope.showGenericServerError = true;
                        }
                    },
                    function() {
                        setTimeout($.unblockUI, 500);
                    });
            }
        }

        $scope.onSubmitResetPasswordForm = function() {
            $scope.remoteErrors = [];
            $scope.showGenericServerError = false;

            if ($('form[name="reset-password-form"]').valid()) {
                var data = {
                    password: settingsService.password,
                    confirmPassword: settingsService.confirmPassword
                }

                // Block page
                blockUiService.blockPage();

                viewModelHelper.apiPut('api/account/settings/reset-password', data,
                    function(result) {
                        console.log('onSuccess');
                        blockUiService.setError(false);
                    },
                    function(result) {
                        blockUiService.setError(true);
                        //if (result.status === 400) {
                        //    $scope.remoteErrors = result.data.errors;
                        //} else {
                        //    $scope.showGenericServerError = true;
                        //}
                    },
                    function() {
                        setTimeout($.unblockUI, 500);
                    });
            }
        }

        initialize();
    }
]).directive("serverErrors", function() {
    return {
        templateUrl: "App/ServerErrors.html"
    };
});