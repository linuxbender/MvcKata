module.exports = function(grunt, options) {
    return {
        options: {
            sourceMap: false
        },
        dist: {
            files: {
              "<%= config.tmp %>/css/app.css": "<%= config.style %>/app.scss"
            }
        }
    };
};