(function() {
    "use strict";

    angular
        .module("feature.reportBuilder")
        .factory("reportBuilder.service", reportBuilderService);

    reportBuilderService.$inject = ["common", "logger", "$http"];

    /* @ngInject */
    function reportBuilderService(common, logger, $http) {
        var service = {
            getReportSource: getReportSource,
            getTableMetaData: getTableMetaData,
            getReportRule: getReportRule,
            getInitialData: getInitialData
        };

        return service;

        function getReportSource() {
            return $http.get("/api/v1/ReportBuilder/ReportSource")
                .then(function(response) {
                    return response.data;
                });
        }

        function getTableMetaData(id) {
        	return $http.get("/api/v1/ReportBuilder/TableMetaData/" + id)
                .then(function(response) {
                    return response.data;
                });
            //return common.q.when('getTableMetaData');
        }

        function getReportRule(id) {
            return $http.get("/api/v1/ReportBuilder/ReportRule/" + id)
                .then(function(response) {
                    return response.data;
                });
        }

        function getInitialData() {
            var promises = [getReportSource()];

            return common.q.all(promises).then(function(results) {
                return results;
            });
        }
    }
})();