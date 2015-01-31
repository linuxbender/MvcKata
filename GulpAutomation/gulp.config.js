module.exports = function () {
    'use strict';
    
    var client = './';
    var clientApp = client + 'Scripts/App/';
    var tmp = './tmp/';
    
    var config = {
        tmp: tmp,
        allJs: ['Scripts/App/**/*.js', './*.js'],
        client: client + 'Views/Shared/',
        css: tmp + 'app.css',
        index: client + 'Views/Shared/_Layout.cshtml',
        js: [
        	clientApp + '**/*.module.js',
        	clientApp + '**/*.js',
        	'!' + clientApp + '**/*.spec.js'
        ],
        sass: client + 'Styles/app.scss',
        bower: {
        	json: require('./bower.json'),
        	directory: './bower_modules/',
        	ignorePath: '../..'
        }
    };

    config.getWiredepDefaultoptions = function() {
    	var options = {
    		bowerJson: config.bower.json,
    		directory: config.bower.directory,
    		ignorePath: config.bower.ignorePath
    	};
    	return options;
    };
    
    return config;
};