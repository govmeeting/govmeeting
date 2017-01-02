
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


/*
    beforeEach(inject(function($injector) {
        // Set up the mock http service responses
        $httpBackend = $injector.get('$httpBackend');
        // Set up our backend service
        backEnd = $injector.get('BackEndSrvWithCtrl');
        // backend definition common for all tests
        authRequestHandler = $httpBackend.when('GET', '/testdata/BBH-2014-09-08.json')
                                .respond({userId: 'userX'}, {'A-Token': 'xxx'});
    }));
*/
/*
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
*/
    it("TEST3", function () {
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

        //$httpBackend.expectGet('testdata\\BBH-2014-09-08.json').respond(headingResponse);

//        var ss = backEnd.getFour();
//        expect(ss).ToEqual("Four");

//        var deferredResponse = backEnd.getMeetingData();
/*        var heading;
        deferredResponse.then(function (response) {
            heading = response.data;
        });

        backEnd.getMeetingInfo(this);

        $httpBackend.flush();

        expect(this.meetingInfo.name).toEqual(headingResponse.name)

        // Just trying to get something to pass:
         // expect(1).toEqual(1);
*/
    });

});




