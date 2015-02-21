(function() {
    "use strict";

    var app = angular.module("feature.reportBuilder.service.mock", ["ngMockE2E"]);
    
    app.run(reportBuilderFakeBackend);

    reportBuilderFakeBackend.$inject = ["$httpBackend"];

    /* @ngInject */
    function reportBuilderFakeBackend ($httpBackend){


    	/*
    	* Mock Data for GetReportSource 
    	*/
    	var getReportSourceUrl = "/api/v1/ReportBuilder/ReportSource";

    	var getReportSource = [
    		{ "tableName": "Report Source - Table A", "id": 1 }, 
        	{ "tableName": "Report Source - Table B", "id": 2 },
        	{ "tableName": "Report Source - Table C", "id": 3 },
        	{ "tableName": "Report Source - Table D", "id": 4 },
        	{ "tableName": "Report Source - Table E", "id": 5 },
        	{ "tableName": "Report Source - Table F", "id": 6 },
            { "tableName": "Report Source - Table G", "id": 7 }
    	];

    	$httpBackend.whenGET(getReportSourceUrl).respond(getReportSource);

    	/*
    	* Mock Data for getTableMetaData
    	*/
    	var getTableMetaDataUrl = "/api/v1/ReportBuilder/TableMetaData";

    	var getTableMetaData = [

    		{"Id": 1, "TableId": 1, "colName": "HalterId", "colType":"Number"},
    		{"Id": 2, "TableId": 1, "colName": "HalterName", "colType":"String"},
    		{"Id": 3, "TableId": 1, "colName": "HalterVorname", "colType":"String"},
    		{"Id": 4, "TableId": 1, "colName": "StammNr", "colType":"String"},
    		{"Id": 5, "TableId": 1, "colName": "VersichersName", "colType":"String"},
    		{"Id": 6, "TableId": 1, "colName": "FahrzeugType", "colType":"string"},
    		{"Id": 7, "TableId": 1, "colName": "AnzahlMotoren", "colType":"Number"},

    		{"Id": 8, "TableId": 2, "colName": "HalterId", "colType":"Number"},
    		{"Id": 9, "TableId": 2, "colName": "HalterName", "colType":"String"},
    		{"Id": 10, "TableId": 2, "colName": "HalterVorname", "colType":"String"},
    		{"Id": 11, "TableId": 2, "colName": "LeistungsCode", "colType":"String"},
    		{"Id": 12, "TableId": 2, "colName": "LeistungsBeschreibung", "colType":"String"},
    		{"Id": 13, "TableId": 2, "colName": "Kosten", "colType":"Number"},
    		{"Id": 14, "TableId": 2, "colName": "Frist", "colType":"Datum"},
    		{"Id": 15, "TableId": 2, "colName": "IstBezahlt", "colType":"Bool" },

    		{"Id": 16, "TableId": 3, "colName": "HalterId", "colType":"Number"},
    		{"Id": 17, "TableId": 3, "colName": "HalterName", "colType":"String"},
    		{"Id": 18, "TableId": 3, "colName": "HalterVorname", "colType":"String"},
    		{"Id": 19, "TableId": 3, "colName": "AdmasId", "colType":"Number"},
    		{"Id": 20, "TableId": 3, "colName": "AdmasStatus", "colType":"String"},
    		{"Id": 21, "TableId": 3, "colName": "AdmasBeschreibung", "colType":"String"},
    		{"Id": 22, "TableId": 3, "colName": "Kosten", "colType":"Number"},
    		{"Id": 23, "TableId": 3, "colName": "AdmasVon", "colType":"Datum"},
    		{"Id": 24, "TableId": 3, "colName": "AdmasBis", "colType":"Datum"},
    		{"Id": 25, "TableId": 3, "colName": "IstBezahlt", "colType":"Bool"},

    		{"Id": 26, "TableId": 4, "colName": "HalterId", "colType":"Number"},
    		{"Id": 27, "TableId": 4, "colName": "HalterName", "colType":"String"},
    		{"Id": 28, "TableId": 4, "colName": "HalterVorname", "colType":"String"},
    		{"Id": 29, "TableId": 4, "colName": "StammNr", "colType":"String"},
    		{"Id": 30, "TableId": 4, "colName": "VersichersName", "colType":"String"},
    		{"Id": 31, "TableId": 4, "colName": "FahrzeugType", "colType":"string"},
    		{"Id": 32, "TableId": 4, "colName": "AnzahlMotoren", "colType":"Number"},

    		{"Id": 33, "TableId": 5, "colName": "HalterId", "colType":"Number"},
    		{"Id": 34, "TableId": 5, "colName": "HalterName", "colType":"String"},
    		{"Id": 35, "TableId": 5, "colName": "HalterVorname", "colType":"String"},
    		{"Id": 36, "TableId": 5, "colName": "LeistungsCode", "colType":"String"},
    		{"Id": 37, "TableId": 5, "colName": "LeistungsBeschreibung", "colType":"String"},
    		{"Id": 38, "TableId": 5, "colName": "Kosten", "colType":"Number"},
    		{"Id": 39, "TableId": 5, "colName": "Frist", "colType":"Datum"},
    		{"Id": 40, "TableId": 5, "colName": "IstBezahlt", "colType":"Bool"},

    		{"Id": 41, "TableId": 6, "colName": "HalterId", "colType":"Number"},
    		{"Id": 42, "TableId": 6, "colName": "HalterName", "colType":"String"},
    		{"Id": 43, "TableId": 6, "colName": "HalterVorname", "colType":"String"},
    		{"Id": 44, "TableId": 6, "colName": "AdmasId", "colType":"Number"},
    		{"Id": 45, "TableId": 6, "colName": "AdmasStatus", "colType":"String"},
    		{"Id": 46, "TableId": 6, "colName": "AdmasBeschreibung", "colType":"String"},
    		{"Id": 47, "TableId": 6, "colName": "Kosten", "colType":"Number"},
    		{"Id": 48, "TableId": 6, "colName": "AdmasVon", "colType":"Datum"},
    		{"Id": 49, "TableId": 6, "colName": "AdmasBis", "colType":"Datum"},
    		{"Id": 50, "TableId": 6, "colName": "IstBezahlt", "colType":"Bool"},

            {"Id": 51, "TableId": 7, "colName": "HalterId", "colType":"Number"},
            {"Id": 52, "TableId": 7, "colName": "HalterName", "colType":"String"},
            {"Id": 53, "TableId": 7, "colName": "HalterVorname", "colType":"String"},
            {"Id": 54, "TableId": 7, "colName": "AdmasId", "colType":"Number"},
            {"Id": 55, "TableId": 7, "colName": "AdmasStatus", "colType":"String"},
            {"Id": 56, "TableId": 7, "colName": "AdmasBeschreibung", "colType":"String"},
            {"Id": 57, "TableId": 7, "colName": "Kosten", "colType":"Number"},
            {"Id": 58, "TableId": 7, "colName": "AdmasVon", "colType":"Datum"},
            {"Id": 59, "TableId": 7, "colName": "AdmasBis", "colType":"Datum"},
            {"Id": 60, "TableId": 7, "colName": "IstBezahlt", "colType":"Bool"}
    	];

    	getTableMetaDataUrl = getById(getTableMetaDataUrl);
    	
    	$httpBackend.whenGET(getTableMetaDataUrl).respond(function(method, url, data) {
    		var Id = getId(url);
    		var metaData = _.where(getTableMetaData, { 'TableId': Id });
    		return returnData(metaData);
    	});

    	/*
    	* Mock Data for GetReportSource 
    	*/
    	var getReportRuleUrl = "/api/v1/ReportBuilder/ReportRule";

    	var getReportRule = [
	    	{
	    		"Id": 1,
	    		"Name": "Rule 1",
	    		"Erstellt Am": "01.10.2014"
	    	},
	    	{
	    		"Id": 2,
	    		"Name": "Rule 2",
	    		"Erstellt Am": "02.10.2014"
	    	},
	    	{
	    		"Id": 3,
	    		"Name": "Rule 3",
	    		"Erstellt Am": "03.10.2014"
	    	},
	    	{
	    		"Id": 4,
	    		"Name": "Rule 4",
	    		"Erstellt Am": "04.10.2014"
	    	},
	    	{
	    		"Id": 5,
	    		"Name": "Rule 5",
	    		"Erstellt Am": "05.10.2014"
	    	},
	    	{
	    		"Id": 6,
	    		"Name": "Rule 6",
	    		"Erstellt Am": "06.10.2014"
	    	}
    	];
    	
    	getReportRuleUrl = getById(getReportRuleUrl);

    	$httpBackend.whenGET(getReportRuleUrl).respond(function(method, url, data) {
    		var Id = getId(url);
    		var rule = _.where(getTableMetaData, { 'Id': Id });
    		return returnData(rule);
    	});

    	/*
    		Bypass Url's
    	*/
    	$httpBackend.when(/app\/.*/).passThrough();
    	$httpBackend.whenGET(/app\/.*/).passThrough();
    	$httpBackend.whenPOST(/app\/.*/).passThrough();
    	$httpBackend.whenPUT(/app\/.*/).passThrough();
    	$httpBackend.whenDELETE(/app\/.*/).passThrough();
    	//$httpBackend.whenHEAD(/app\/.*/).passThrough();
    	$httpBackend.whenPATCH(/app\/.*/).passThrough();
    	$httpBackend.whenJSONP(/app\/.*/).passThrough();

    	/*
			Helper's	
    	*/

    	function getId(url) {
    		var paramters = url.split("/");
    		var length = paramters.length;    		
    		var Id = parseInt(paramters[length -1]);
    		return Id;
    	}

    	function getById(url) {
    		var reg = new RegExp(url + "/[0-9][0-9]*", "");
    		return reg;
    	}

    	function returnData(data)
    	{
    		if (_.size(data) > 0) {
    			return [200,data, {}];
    		} else {
    			return [204,null, {}];
    		}
    	}
    }
})();