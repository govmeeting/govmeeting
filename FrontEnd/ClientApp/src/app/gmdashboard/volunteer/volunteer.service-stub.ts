import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WorkProgress, WorkItem, Volunteer, Location } from '../../models/workprogress-view';
import { MeetingForView } from '../../models/meetingforview'

@Injectable()
export class FixasrService {

    constructor() {
        console.log('VolunteerService stub constructor');
    }
    // We will return the data for location 6633 (Linden, NJ - USA)
    getWorkInProgress(locationId: number = 5633): Observable<WorkProgress> {
        console.log('getWorkInProgress from memory');
        return Observable.of(this.workinprogress);
    }

// The data below represents:
// The work being done on a meeting of the Linden, NJ (USA) City Council held on 2017/04/21.
// The meeting was 2833 seconds long (47 minutes and 13 seconds).
// The work was split into 5 work items. The first four are each 10 minutes long (600 seconds).
// The last work item is 7 minutes and 13 seconds (433 seconds).
// The status of each work item is as follows:
// Item #1 is being worked on by volunteer #43. It was edited up to the 420 second point.
//    The last edit was done on 2017 - 04 - 23 18: 25: 43.511 Zulu time.
// Item #2 is completed.
// Item #3 is being worked on by volunteer #88, edited up to 322 seconds.
//    Last edit was at 2017 - 04 - 22 15: 25: 12.332.
// Item #4 - No work was done yet on this items.
// Item #5 - No work was done yet on this items.
// The volunteers working on this meeting are:
//   #43 User name is "JillS".Her location is Linden, NJ (the same as the meeting).
//   #88 User name is "Chineye". His location is Nakuru, Kenya.

// We use an ISO 8601 date format:
// https://stackoverflow.com/a/15952652/1978840

    private workinprogress: WorkProgress = {
        "locationId": 5633,
        "meeting": {
            "meetingId": 24356,
            "locationId": 5633,
            "governmentBody": "CityCouncil",
            "language": "en",
            "date": "2017-04-21",
            "meetingLength": 2833
        },

        workitems: [
            {
                "workItemId": 343402,
                "partId": 1,
                "isDone": false,
                "volunteerId": 43,
                "lastEdit": 420,
                "lastEditTime": "2017-04-23T18:25:43.511Z",
                "length": 600
            },
            {
                "workItemId": 343403,
                "partId": 2,
                "isDone": true,
                "volunteerId": 0,
                "lastEdit": 0,
                "lastEditTime": "",
                "length": 600
            },
             {
                "workItemId": 343404,
                "partId": 3,
                "isDone": false,
                "volunteerId": 88,
                "lastEdit": 322,
                "lastEditTime": "2017-04-22T15:25:12.332Z",
                "length": 600
            },
            {
                "workItemId": 343405,
                "partId": 4,
                "isDone": false,
                "volunteerId": 0,
                "lastEdit": 0,
                "lastEditTime": "",
                "length": 600
            },
            {
                "workItemId": 343406,
                "partId": 5,
                "isDone": false,
                "volunteerId": 0,
                "lastEdit": 0,
                "lastEditTime": "",
                "length": 433
            }
        ],
        "volunteers": [
            {
                "volunteerId": 43,
                "userName": "JillS",
                "locationId": 5633,
                "workItemId": 992
            },
            {
                "volunteerId": 88,
                "userName": "Chineye",
                "locationId": 8723,
                "workItemId": 343402
            }
        ],
        "locations": [
            {
                "locationId": 5633,
                "country": "USA",
                "state": "NJ",
                "county": "Union",
                "municipality": "Linden"
            },
            {
                "locationId": 8723,
                "country": "KE",
                "state": "",
                "county": "Nakuru",
                "municipality": "Nakuru"
            }
        ]
    }
}