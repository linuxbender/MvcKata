module.exports = function(grunt, options) {
    var app = options.app;
    return {
        main: {
            files: [{
                expand: true,
                src: "<%= app.tmp %>/css/*.min.css",
                dest: "<%= app.app %>/assets/css/",
                flatten: true,
                filter: "isFile"
            }]
        }
    };
};
