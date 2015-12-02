var configDataService = angular.module("configDataService",[]);

configDataService.factory('dataService', function ($http, $q) {
    var _configs = [];
    var _isInit = false;

    var _isReady = function() {
        return _isInit;
    }

    var _getConfigs = function () {

        var deferred = $q.defer();

        $http.get('api/configs')
            .then(function(result) {
                ///success
                angular.copy(result.data, _configs);
                deferred.resolve();
            }, function() {
                //error
                deferred.reject();
            }).then(function() {
                _isInit = true;
            });

        return deferred.promise;
    };

    var _getConfigById = function(id) {
        var deferred = $q.defer();

        if (_isReady()) {
            var config = _findConfig(id);
            if (config) {
                deferred.resolve(config);
            } else {
                deferred.reject();
            }
        } else {
            _getConfigs()
                .then(function() {
                    //success
                    var config = _findConfig(id);
                    if (config) {
                        deferred.resolve(config);
                    } else {
                        deferred.reject();
                    }
                }, function() {
                    //error
                    deferred.reject();
                });
        }

        return deferred.promise;
    }

    function _findConfig(id) {
        var config = null;

        $.each(_configs, function (i, cfg) {
            if (cfg.id === id) {
                config = cfg;
                return false;
            }
            return true;
        });

        return config;
    }

    return {
        isReady: _isReady,
        configs: _configs,
        getConfigs: _getConfigs,
        getConfigById: _getConfigById
    }
});


