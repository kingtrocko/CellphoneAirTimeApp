var commonModule = angular.module('common', ['ngRoute']);
var mainModule = angular.module('main', ['common']);

commonModule.factory('viewModelHelper', [ '$http', '$q', '$window', '$location',
    function($http, $q, $window, $location) {
         return MyApp.viewModelHelper($http, $q, $window, $location);
    }]);

commonModule.factory('validator', function () { return valJs.validator(); });

commonModule.factory('blockUiService', function () {
        var hasError = true;
        return {
            setError: function(e) {
                hasError = e;
            },
            blockPage: function () {
                $.blockUI({
                    message: '<span class="text-semibold"><i class="icon-spinner4 spinner position-left"></i>&nbsp; Guardando</span>',
                    timeout: 0,
                    overlayCSS: {
                        backgroundColor: '#1b2024',
                        opacity: 0.8,
                        cursor: 'wait'
                    },
                    css: {
                        border: 0,
                        color: '#fff',
                        padding: 0,
                        backgroundColor: 'transparent'
                    },
                    onUnblock: function() {
                        var title = '', text = '', icon = '', type = '', addclass = '';

                        if (!hasError) {
                            title = 'Exito';
                            text = 'La información se guardó exitosamente.';
                            icon = 'icon-checkmark3';
                            type = 'success';
                        } else {
                            title = 'Error al Guardar';
                            text = 'Por favor revisa los errores.';
                            addclass = 'alert-styled-right';
                            type = 'error';
                        }
                        var msg = new PNotify({
                            title: title,
                            text: text,
                            icon: icon,
                            addclass: addclass,
                            type: type,
                            buttons: {
                                closer: true,
                                sticker: false
                            }
                        });
                    }
                });
            }
        };
    }
);


(function (myApp) {
    var viewModelHelper = function ($http, $q, $window, $location) {

        var self = this;

        self.modelIsValid = true;
        self.modelErrors = [];

        self.resetModelErrors = function () {
            self.modelErrors = [];
            self.modelIsValid = true;
        }

        self.apiGet = function (uri, data, success, failure, always) {
            self.modelIsValid = true;
            $http.get(MyApp.rootPath + uri, data)
                .then(function (result) {
                    success(result);
                    if (always != null)
                        always();
                }, function (result) {
                    if (failure != null) {
                        failure(result);
                    }
                    else {
                        var errorMessage = result.status + ':' + result.statusText;
                        if (result.data != null && result.data.Message != null)
                            errorMessage += ' - ' + result.data.Message;
                        self.modelErrors = [errorMessage];
                        self.modelIsValid = false;
                    }
                    if (always != null)
                        always();
                });
        }

        self.apiPost = function(uri, data, success, failure, always) {
            self.modelIsValid = true;
            $http.post(MyApp.rootPath + uri, data)
                .then(function(result) {
                    success(result);
                    if (always != null)
                        always();
                }, function(result) {
                    if (failure != null) {
                        failure(result);
                    } else {
                        var errorMessage = result.status + ':' + result.statusText;
                        if (result.data != null && result.data.Message != null)
                            errorMessage += ' - ' + result.data.Message;
                        self.modelErrors = [errorMessage];
                        self.modelIsValid = false;
                    }
                    if (always != null)
                        always();
                });
        }

        self.apiPut = function(uri, data, success, failure, always) {
            self.modelIsValid = true;
            $http.put(MyApp.rootPath + uri, data)
                .then(function(result) {
                    success(result);
                    if (always != null)
                        always();
                }, function(result) {
                    if (failure != null) {
                        failure(result);
                    } else {
                        var errorMessage = result.status + ':' + result.statusText;
                        if (result.data != null && result.data.Message != null)
                            errorMessage += ' - ' + result.data.Message;
                        self.modelErrors = [errorMessage];
                        self.modelIsValid = false;
                    }
                    if (always != null)
                        always();
                });
        }


        self.goBack = function () {
            $window.history.back();
        }

        self.navigateTo = function (path) {
            $location.path(MyApp.rootPath + path);
        }

        self.refreshPage = function (path) {
            $window.location.href = MyApp.rootPath + path;
        }

        self.clone = function (obj) {
            return JSON.parse(JSON.stringify(obj));
        }

        return this;
    };
    myApp.viewModelHelper = viewModelHelper;
}(window.MyApp));
