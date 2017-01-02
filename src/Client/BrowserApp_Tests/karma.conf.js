// Karma configuration
// Generated on Fri Mar 18 2016 18:51:37 GMT-0400 (Eastern Daylight Time)

module.exports = function(config) {
  config.set({

    // base path that will be used to resolve all patterns (eg. files, exclude)
    basePath: '',


    // frameworks to use
    // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
    frameworks: ['jasmine'],

    // TODO - probably best to use angular.js and angular-route.js from BrowserApp project.
    // list of files / patterns to load in the browser
    files: [
        'Scripts/angular.js',
        'Scripts/angular-mocks.js',
        'Scripts/angular-route.js',
	    '../BrowserApp/app/Utilities/utilities.js',
	    '../BrowserApp/app/Utilities/userChoices.js',
	    '../BrowserApp/app/SingleMeeting/heading.js',
	    '../BrowserApp/app/SingleMeeting/browseMeeting.js',
	    '../BrowserApp/app/SingleMeeting/backEndWithCtrl.js',
	    '../BrowserApp/app/Utilities/backEnd.js',
	    '../BrowserApp/app/SingleMeeting/meetingOptions.js',
	    '../BrowserApp/app/SingleMeeting/singleMeeting.js',
        'Utilities_tests/backEnd_test.js'
    ],
//        'SingleMeeting_tests/**/*.js'
//        'test/**/*.js'


    // list of files to exclude
    exclude: [
    ],


    // preprocess matching files before serving them to the browser
    // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
    preprocessors: {
    },


    // test results reporter to use
    // possible values: 'dots', 'progress'
    // available reporters: https://npmjs.org/browse/keyword/karma-reporter
    reporters: ['progress'],


    // web server port
    port: 9876,


    // enable / disable colors in the output (reporters and logs)
    colors: true,


    // level of logging
    // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
    logLevel: config.LOG_INFO,


    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: false,


    // start these browsers
    // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
    // browsers: ['Chrome', 'PhantomJS'],
    browsers: ['Chrome'],


    // Continuous Integration mode
    // if true, Karma captures browsers, runs the tests and exits
    singleRun: true,

    // Concurrency level
    // how many browsers should be started simultaneous
    // concurrency: Infinity
    concurrency: 0
  })
}
