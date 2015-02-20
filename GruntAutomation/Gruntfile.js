"use strict";
module.exports = function(grunt) {
	var path = require("path");

	var config = {
		app: require("./bower.json").appPath,
		style: "Styles",
		tmp:"tmp",
		test:"test"
	};

	require("load-grunt-config")(grunt,{
		configPath: path.join(process.cwd(), "grunt"),
		init: true,
		data: {
			app: config
		}
	});

	grunt.registerTask("default", "Log some stuff.", function() {
    	grunt.log.write("Logging some stuff...").ok();
  	});
};