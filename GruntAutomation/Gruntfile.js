"use strict";
module.exports = function(grunt) {
	var path = require("path");

	var appConfig = {
		app: require("./bower.json").appPath,
		style: "Styles",
		tmp:"tmp",
		test:"test",
		content: "Content"
	};

	require("load-grunt-config")(grunt,{
		configPath: path.join(process.cwd(), "config"),
		init: true,
		data: {
			config: appConfig
		}
	});

	grunt.registerTask("default", "Log some stuff.", function() {
    	grunt.log.write("Logging some stuff...").ok();
  	});
};