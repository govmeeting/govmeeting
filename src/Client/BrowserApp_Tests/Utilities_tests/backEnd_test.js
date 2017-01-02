/// <reference path="..\Scripts\jasmine.js" />
/// <reference path="..\Scripts\angular.js" />
/// <reference path="..\Scripts\angular-mocks.js" />
/// <reference path="..\..\BrowserApp\app\Utilities\backEnd.js" />
/// <reference path="..\..\BrowserApp\app\Utilities\utilities.js" />


// http://www.i-avington.com/Posts/Post/unit-testing-a-service-that-makes-an-api-call-using-httpbackend
// https://docs.angularjs.org/api/ngMock/service/$httpBackend
// http://www.jeremyzerr.com/angularjs-backend-less-development-using-httpbackend-mock
// http://michalostruszka.pl/blog/2013/05/27/easy-stubbing-out-http-in-angularjs-for-backend-less-frontend-development/
// http://stackoverflow.com/questions/25953482/how-to-debug-jasmine-unit-test-with-visual-studio-2013


describe('Client_Utilities_backEnd', function () {
    var backEnd,
    $httpBackend;
    var meetingData = {};

    var headingResponse = [
    {
        "name": "Clifton Town Council",
        "date": "April 3, 2015"
    }
    ];

    beforeEach(function () {
        module('utilities');
        inject(function (_$httpBackend_, _BackEndSrv_) {
            $httpBackend = _$httpBackend_;
            backEnd = _BackEndSrv_;
        })
    });

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest()
    });


    it('getMeetingInfo should be defined', function () {
        expect(backEnd.getMeetingInfo).toBeDefined();
    });

    it('getMeetingData should be defined', function () {
        expect(backEnd.getMeetingData).toBeDefined();
    });

    it('Get meeting info', function () {

        // From Angular docs: When an Angular application needs some data from a server,
        // it calls the $http service, which sends the request to a real server using
        // $httpBackend service. With dependency injection, it is easy to inject $httpBackend
        // mock (which has the same API as $httpBackend) and use it to verify the requests
        // and respond with some testing data without sending a request to a real server.

        // We expect the backend to request this URL and respond with the heading.
        $httpBackend.expectGET('testdata\\BBH-2014-09-08.json').respond(headingResponse);

        var deferredResponse = backEnd.getMeetingInfo(meetingData);

        var heading;
        deferredResponse.then(function (response) {
            heading = response.data;
        });

        $httpBackend.flush();

//        console.log("heading ===============================");
//        console.log(heading);

        expect(heading.name).toEqual(headingResponse.name)

        expect(heading.date).toEqual(headingResponse.date)
    });

});




