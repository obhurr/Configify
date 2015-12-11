var configIndex = angular.module("configIndex", ['ngRoute', 'configDataService']);

configIndex.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "configsController",
        templateUrl:"/app/views/configIndex/configsView.html"
    });

    $routeProvider.when("/:configId", {
        controller: "singleConfigController",
        templateUrl: "/app/views/configIndex/configView.html"
    });

    $routeProvider.otherwise("/");
}]);


configIndex.controller('configsController', ['$scope', '$http', 'dataService',
    function ($scope, $http, dataService) {
        $scope.data = dataService;
        $scope.isBusy = false;

        if (!dataService.isReady()) {
            $scope.isBusy = true;

            dataService.getConfigs()
                .then(function() {
                        //success
                    },
                    function() {
                        //error
                        alert('Error loading configurations');
                    })
                .then(function() {
                    $scope.isBusy = false;
                });
        }
    }
]);

configIndex.controller('singleConfigController', ['$scope', '$http', '$routeParams','$window', 'dataService',
    function($scope, $http, $routeParams, $window, dataService) {
        $scope.isBusy = true;
        $scope.config = null;
        $scope.workingConfig = null;

        dataService.getConfigById($routeParams.configId)
            .then(function(cfg) {
                    //success
                    $scope.config = cfg;

                    //Create a working copy for editing in the UI
                    $scope.workingConfig = angular.copy($scope.config);
                },
                function() {
                    //error
                    $window.location = "#/";
                })
            .then(function() {
                $scope.isBusy = false;
            });

        $scope.save = function () {
            $scope.isBusy = true;

            //todo: save the config to the database

            //Update the config from the working copy
            angular.copy($scope.workingConfig, $scope.config);

            $scope.isBusy = false;

            $window.location = "#/";
        }

        $scope.cancel = function () {
            //revert the working copy back to the original
            angular.copy($scope.config, $scope.workingConfig);
            $window.location = "#/";
        }

    }
]);

