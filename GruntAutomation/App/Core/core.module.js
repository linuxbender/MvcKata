(function () {
    "use strict";
    angular
        .module("app.core", [
        /*
        * Angular modules
        */
        "ngAnimate",
        "ngRoute",
        "ngSanitize",
        /*
        * common modules
        */
        "common.logger",
        "common.exception",
        "common.offline",
        "common.busyIndicator",
        "common.localStorage"
        ]);
})();