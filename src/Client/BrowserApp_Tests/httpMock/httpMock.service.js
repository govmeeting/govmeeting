(function() {
    'use strict';

    angular
        .module('httpMock.service', [])
        .service('httpMock', Service);
    
    Service.$inject = [];
    
    function Service() {
        var m = {
            urls: {}
        };
        
        function handlers(url) {
            return m.urls[url];
        }

        function when(method, url, data) {
            if (!m.urls[url]) {
                m.urls[url] = [];
            }
            
            var handlers = m.urls[url];

            var expectedData = angular.copy(data);
            
            var handler = {
                test: function(config) {
                    return method === config.method
                        && (!angular.isDefined(expectedData) || angular.equals(expectedData, config.data));
                },
                response: {
                    status: 200,
                    data: undefined,
                    headers: {}
                }
            };
            
            handlers.push(handler);
            
            return {
                respond: respond(handler)
            };
        }
        
        function respond(handler) {
            return function(data, status, headers) {
                handler.response.data = data;
                
                if (status) {
                    handler.response.status = status;
                }
                
                if (headers) {
                    handler.response.headers = headers;
                }
            }
        }

        return {
            handlers: handlers,
            when: when
        };
    }
})();