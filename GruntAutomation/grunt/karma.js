module.exports = function(grunt, options) {
    var app = options.app;
    return {
        unit: {
            configFile: "<%= app.test %>/karma.conf.js",
            singleRun: true
        }
    };
};