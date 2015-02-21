(function() {
    "use strict";

    angular.module("common.localStorage")
        .factory("storage", storage);

    function storage() {

        var service = {
            add: add,
            remove: remove,
            get: get,
            clear: clear
        };
        
        return service;

        function add(key, value) {
            localStorage.addItem(key, value);
        }

        function remove(key) {
            localStorage.removeItem(key);
        }

        function get(key) {
            return localStorage.getItem(key);
        }

        function clear() {
            localStorage.clear();
        }
    }
})();