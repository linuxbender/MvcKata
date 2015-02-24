module.exports = function(grunt, options) {
    return {
        clean: [
            "<%= config.tmp %>/css/*.css",
            "!<%= config.tmp %>/css/*.min.css"
        ]
    };
};