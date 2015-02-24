module.exports = function (grunt, options) {
	//grunt.log.write(JSON.stringify(options.app));
  return {
  	options: {
    	reporter: require("jshint-stylish")
    },
    all: [
      //"Gruntfile.js",
      "grunt/*.js"
    ]
  };
};