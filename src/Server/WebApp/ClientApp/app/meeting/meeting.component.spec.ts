import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MeetingComponent } from './meeting.component';

describe('MeetingComponent', () => {
  let component: MeetingComponent;
  let fixture: ComponentFixture<MeetingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MeetingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MeetingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});



/*
 * This is old test code that was done when we were still using Angular 1.
 *  I don't know if any of this is still useful. The UserchoiceService was
 * called "UserChoicSrv" then and the MeetingService was called "httpBackEnd"


   describe('Client_utilities_', function () {
    beforeEach(module('utilities'));

    describe('userChoices ->', function () {

        it('set/get speaker', inject(function (UserChoiceSrv) {
            UserChoiceSrv.setSpeaker("John Henry");
            expect(UserChoiceSrv.getSpeaker()).toEqual("John Henry");
        }));

        it('set/get topic', inject(function (UserChoiceSrv) {
            UserChoiceSrv.setTopic("Construction of ice rink");
            expect(UserChoiceSrv.getTopic()).toEqual("Construction of ice rink");
        }));
    });
});



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
});

*/
