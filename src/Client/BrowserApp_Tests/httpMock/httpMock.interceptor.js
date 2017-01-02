(function() {
    'use strict';
    
    angular
        .module('httpMock.interceptor', [])
        .service('httpMockInterceptor', Interceptor);
        
    Interceptor.$inject = ['$q', 'httpMock'];
    
    function Interceptor($q, httpMock) {
        return {
            request: function(config) {
                var handlers = httpMock.handlers(config.url);
                
                if (!handlers) {
                    return config;
                }
                
                var response;
                
                for(var i=0; i<handlers.length; i++) {
                    var handler = handlers[i];
                    
                    if (handler.test(config)) {
                        response = handler.response;
                        break;
                    }
                }
                
                if (!response) {
                    return config;
                }
                
                var rejection = {
                    reason: 'mock',
                    status: response.status,
                    data: response.data,
                    headers: function header(name) {
                        return name ? response.headers[angular.lowercase(name)] || null : response.headers;
                    },
                    config: config
                };

                return $q.reject(rejection);
            },
            responseError: function(rejection) {
                if (rejection && rejection.reason === 'mock') {
                    var response = {
                        data: rejection.data,
                        status: rejection.status,
                        headers: rejection.headers,
                        config: rejection.config
                    };
                    
                    if (rejection.status < 200 || rejection.status >= 300) {
                        return $q.reject(response);
                    }
                    
                    return $q.when(response);
                }
                
                return $q.reject(rejection);
            }
        };
    }
})();