(function() {
    "use strict";

    angular
        .module("feature.reportBuilder")
        .controller("reportBuilder.controller", reportBuilderController);

    reportBuilderController.$inject = ["reportBuilder.service", "common","logger","initialData"];

    /* @ngInject */
    function reportBuilderController(reportBuilderService, common, logger, initialData) {
        /*jshint validthis: true */
        var vm = this;
        vm.title = "Report Builder Controller";
        vm.tableList = initialData[0];
        vm.tableSelectedOption;
        vm.tableMetaData;
        vm.disableRuleTemplate = true;

        vm.getTableMetaData = getTableMetaData;

        function getTableMetaData(id){
            
            if (common.isNullOrEmpty(id)) {
                id = 0;
            }

        	reportBuilderService.getTableMetaData(id)
        				.then(function(data){
        		vm.tableMetaData = data;
                vm.disableRuleTemplate = common.hasNoData(data);
        	});
        }

        //InitialData();

        function InitialData()
        {
        	var promises = [getReportSource()];

        	return common.q.all(promises).then(function(results) {
        		vm.tableList = results[0];
                logger.info("Report Sources loaded!");
            });
        }

        function getReportSource()
        {
        	return reportBuilderService.getReportSource().then(function(data) {
                return data;
            });
        }
    }
})();