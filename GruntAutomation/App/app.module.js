(function() {
    "use strict";

    angular
        .module("app", [
            "app.core",
            /*
            Feature areas
            */
            "feature.reportBuilder",
            /*
            Mock Data for local DEV - without a server
            */
            "feature.reportBuilder.service.mock"
        ]);
})();