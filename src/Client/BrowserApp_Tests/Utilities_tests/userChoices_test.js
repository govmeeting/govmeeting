/// <reference path="..\Scripts\jasmine.js" />
/// <reference path="..\Scripts\angular.js" />
/// <reference path="..\scripts\angular-mocks.js" />
/// <reference path="..\..\BrowserApp\app\Utilities\userChoices.js" />
/// <reference path="..\..\BrowserApp\app\Utilities\utilities.js" />



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
