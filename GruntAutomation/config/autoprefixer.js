module.exports = function(grunt, options) {
    return {
        options: {
        	browsers: ["last 2 versions","ie 7","ie 8", "ie 9"]
        },
        multiple_files: {
            expand: true,
            flatten: true,
            src: ["<%= config.tmp %>/css/*.css"],
            dest: "<%= config.tmp %>/css/"
        }
    };
};