module.exports = function(grunt, options) {
    var app = options.app;
    return {
        options: {
            sourceMap: false
        },
        dist: {
            files: {
              "<%= app.tmp %>/css/app.css": "<%= app.style %>/app.scss"
            }
        }
    };
};