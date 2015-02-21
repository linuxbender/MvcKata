(function() {
    "use strict";

    var core = angular.module("app");

    core.config(configure);

    configure.$inject = ["$routeProvider"];
    /* @ngInject */
    function configure($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "app/layout/main.html",
                controller: "mainController",
                controllerAs: "vm"
            })
            .otherwise({
                redirectTo: "/"
            });
    }
})();