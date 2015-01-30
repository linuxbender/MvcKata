var gulp = require('gulp');
var args = require('yargs').argv;
// config file
var config = require('./gulp.config')();
// load all gulp plugin lazy
var $ = require('gulp-load-plugins')({lazy: true});

gulp.task('vet', function () {
    log('Analyzing source with JSHint and JSCS');
	return gulp
	.src(config.allJs)
    .pipe($.if(args.verbose, $.print()))
	.pipe($.jscs())
	.pipe($.jshint())
	.pipe($.jshint.reporter('jshint-stylish', {verbose: true}))
    .pipe($.jshint.reporter('fail'));
});

// helper function
function log(msg) {
    if (typeof (msg) === 'object') {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors.blue(msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors.blue(msg));
    }
}