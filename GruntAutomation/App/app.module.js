(function() {
    "use strict";

    angular
        .module("app", [
            "app.core",
            "layout",
            /*
            Feature areas
            */
            "prototype.reportBuilder",
            /*
            Mock Data for local DEV - without a server
            */
            "reportBuilderServiceMock"
        ]);
})();