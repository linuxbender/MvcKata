module.exports = function(grunt, options) {
    var app = options.app;
    return {
        options: {
        	browsers: ['last 2 versions','ie 7','ie 8', 'ie 9']
        },
        multiple_files: {
            expand: true,
            flatten: true,
            src: ['<%= app.tmp %>/css/*.css'],
            dest: '<%= app.tmp %>/css/'
        }
    };
};