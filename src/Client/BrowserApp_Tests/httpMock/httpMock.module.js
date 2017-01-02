(function() {
    'use strict';
    
    angular
        .module('http-mock', [
            'httpMock.config',
            'httpMock.interceptor',
            'httpMock.service']);
})();