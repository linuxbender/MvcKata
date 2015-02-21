(function () {
    "use strict";
    angular
        .module("app.core", [
        /*
        * Angular modules
        */
        "ngSanitize",
        "ngRoute",
        "ngAnimate",
        /*
        * common modules
        */
        "common.localStorage"
        ]);
})();