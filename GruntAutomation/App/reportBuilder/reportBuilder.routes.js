(function() {
    "use strict";

    var core = angular.module("feature.reportBuilder");

    core.config(configure);

    configure.$inject = ["$routeProvider"];

    /* @ngInject */
    function configure($routeProvider) {
        $routeProvider
            .when("/reportBuilder", {
                templateUrl: "app/reportBuilder/reportBuilder.html",
                controller: "reportBuilder.controller",
                controllerAs: "vm",
                resolve: {
                    initialData: initialData
                }
            });
        
        initialData.$inject = ["reportBuilder.service"];
        /* @ngInject */
        function initialData(reportBuilderService) {
            return reportBuilderService.getInitialData();
        }
    }
})();