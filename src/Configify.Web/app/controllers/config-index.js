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
        $scope.origConfig = null;

        dataService.getConfigById($routeParams.configId)
            .then(function(cfg) {
                    //success
                    $scope.config = cfg;
                    $scope.origConfig = angular.copy($scope.config);
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

            //todo: save the config

            $scope.isBusy = false;

            $window.location = "#/";
        }

        $scope.cancel = function () {
            //revert back to the original
            angular.copy($scope.origConfig, $scope.config);
            $window.location = "#/";
        }

    }
]);

