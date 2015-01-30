module.exports = function () {
    'use strict';
    
    var client = './';
    
    var config = {
        tmp: './tmp/',
        allJs: ['Scripts/App/**/*.js', './*.js'],
        sass: client + 'Styles/app.scss'
    };
    
    return config;
};