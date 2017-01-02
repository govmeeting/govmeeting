/// <reference path="..\Scripts\jasmine.js" />
/// <reference path="..\Scripts\angular.js" />
/// <reference path="..\Scripts\angular-mocks.js" />
/// <reference path="..\..\BrowserApp\app\SingleMeeting\backEndWithCtrl.js" />
/// <reference path="..\..\BrowserApp\app\SingleMeeting\singleMeeting.js" />


// http://www.i-avington.com/Posts/Post/unit-testing-a-service-that-makes-an-api-call-using-httpbackend
// https://docs.angularjs.org/api/ngMock/service/$httpBackend
// http://www.jeremyzerr.com/angularjs-backend-less-development-using-httpbackend-mock
// http://michalostruszka.pl/blog/2013/05/27/easy-stubbing-out-http-in-angularjs-for-backend-less-frontend-development/
// http://stackoverflow.com/questions/25953482/how-to-debug-jasmine-unit-test-with-visual-studio-2013



describe('Client_SingleMeeting_backEnd', function () {
    var backEnd,
    $httpBackend;

    var headingResponse = [
    {
        "name": "Clifton Town Council",
        "date": "April 3, 2015"
    }
    ];
    var AuthRequestHandler;

    beforeEach(function () {
        module('singleMeeting');
        inject(function (_$httpBackend_, _BackEndSrvWithCtrl_) {
            $httpBackend = _$httpBackend_;
            backEnd = _BackEndSrvWithCtrl_;
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

//    it("TEST2", function () {
//        expect(true).toBe(true);
//    });
/*
    xit("TEST1", function () {
//        authRequestHandler = $httpBackend.when('GET', 'testdata/BBH-2014-09-08.json')
//        authRequestHandler = $httpBackend.when('GET', 'whatever.json')
//            .respond({ userId: 'userX' }, { 'A-Token': 'xxx' });
//            .respond({ "name": 'Clifton Council' }, { 'date': 'April 3, 2015' });
        // it('Get request for meeting data and return heading', function () {

        // From Angular docs: When an Angular application needs some data from a server,
        // it calls the $http service, which sends the request to a real server using
        // $httpBackend service. With dependency injection, it is easy to inject $httpBackend
        // mock (which has the same API as $httpBackend) and use it to verify the requests
        // and respond with some testing data without sending a request to a real server.

        $httpBackend.expectGET('testdata\\BBH-2014-09-08.json').respond(headingResponse);

        console.log("TEST1===============================");

        var deferredResponse = backEnd.getMeetingInfo();

        console.log("TEST2===============================");

        var heading;
        deferredResponse.then(function (response) {
            heading = response.data;
        });

        console.log("TEST3===============================");

        // backEnd.getMeetingInfo(this);

        console.log("TEST3===============================");

        $httpBackend.flush();

//        expect(this.heading.name).toEqual(headingResponse.name)

        // expect(this.meetingInfo.name).toEqual(headingResponse.name)

        // Just trying to get something to pass:
         // expect(1).toEqual(1);

    });
*/
});




