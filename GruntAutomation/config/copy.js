module.exports = function(grunt, options) {
    return {
        main: {
            files: [{
                expand: true,
                src: "<%= config.tmp %>/css/*.min.css",
                dest: "<%= config.content %>/",
                flatten: true,
                filter: "isFile"
            }]
        }
    };
};
