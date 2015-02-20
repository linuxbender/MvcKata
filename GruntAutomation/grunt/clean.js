module.exports = function(grunt, options) {
    var app = options.app;
    return {
        clean: [
            "<%= app.tmp %>/css/*.css",
            "!<%= app.tmp %>/css/*.min.css"
        ]
    };
};