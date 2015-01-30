
'use strict';
var gulp = require('gulp');
var args = require('yargs').argv;
var del = require('del');

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

gulp.task('styles', ['clean-styles'], function() {
    
    log('Comiling Sass to Css');
    
    return gulp
    .src(config.sass)
    .pipe($.sass())
    .on('error',errorLogger)
    .pipe($.autoprefixer({browsers:['last 2 version', '> 5%']}))
    .pipe(gulp.dest(config.tmp));
    
});

gulp.task('clean-styles', function(done) {
    
    var files = config.tmp + '**/*.css';
    clean(files, done); 
});

gulp.task('sass-watcher', function() {
    
    gulp.watch([config.sass],['styles']);
});

// 
//
// helper function
function clean(files, done) {
    log('clean task is running ' + $.util.colors.red(files));
    del(files, done);
}

function errorLogger(error) {
    log('*** Start of Error ***');
    log(error);
    log('*** End of Error ***');
    this.emit('end');
}

function log(msg) {
    if (typeof (msg) === 'object') {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors.cyan(msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors.cyan(msg));
    }
}