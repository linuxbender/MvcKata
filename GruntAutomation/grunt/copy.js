module.exports = function(grunt, options) {
    var app = options.app;
    return {
        main: {
            files: [{
                expand: true,
                src: "<%= app.tmp %>/css/*.min.css",
                dest: "<%= app.content %>/",
                flatten: true,
                filter: "isFile"
            }]
        }
    };
};
