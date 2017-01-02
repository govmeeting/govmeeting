(function() {
    'use strict';

    angular
        .module('httpMock.config',[])
        .config(Config);

    Config.$inject = ['$httpProvider'];

    function Config($httpProvider) {
        $httpProvider.interceptors.unshift('httpMockInterceptor');
    }
})();