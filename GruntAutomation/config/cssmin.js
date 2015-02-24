module.exports = function(grunt, options) {
    return {
        target: {
            files: [{
                expand: true,
                cwd: "<%= config.tmp %>/css/",
                src: ["*.css", "!*.min.css"],
                dest: "<%= config.tmp %>/css/",
                ext: ".min.css"
            }]
        }
    };
};