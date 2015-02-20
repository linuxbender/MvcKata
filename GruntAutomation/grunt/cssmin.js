module.exports = function(grunt, options) {
    var app = options.app;
    return {
        target: {
            files: [{
                expand: true,
                cwd: "<%= app.tmp %>/css/",
                src: ["*.css", "!*.min.css"],
                dest: "<%= app.tmp %>/css/",
                ext: ".min.css"
            }]
        }
    };
};