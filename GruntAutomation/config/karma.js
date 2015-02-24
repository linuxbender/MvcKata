module.exports = function(grunt, options) {
    return {
        unit: {
            configFile: "<%= config.test %>/karma.conf.js",
            singleRun: true
        }
    };
};