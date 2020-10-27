import { ViewTranscript } from '../viewtranscript-view';
export { ViewTranscript };

export let ViewTranscriptSample: ViewTranscript = {
  // private viewMeeting: ViewTranscript = {
  meeting: {
    meetingId: 1,
    locationId: 1,
    governmentBody: 'Selectmen',
    language: 'en',
    date: 'Sept. 8, 2014',
    meetingLength: 1800,
  },
  topicNames: [
    'SHOW ALL',
    'Introductions',
    'Anouncements',
    'Treasurer Report',
    'Prior Minutes',
    'Public Works',
    'Wharves & Wiers',
    'Public Restrooms',
    'Music',
    'Executive Session',
  ],
  speakerNames: [
    'SHOW ALL',
    'Denise Griffin',
    'Jay Warren',
    'Wendy Wolf',
    'Russell Hoffman',
    'William Hamblen',
    'Thomas Woodin',
    'Kellie Bigos',
    'Julia Latter',
    'Man 1',
    'Mike',
  ],
  topicDiscussions: [
    {
      name: 'Introductions',
      talks: [
        // tslint:disable-next-line:max-line-length
        {
          Speaker: 'Denise Griffin',
          Text:
            'Meeting to order. Today is Monday, Sept. 8th. Welcome to the selectmen�s meeting, the first meeting in September. On my left is Kellie Bigos, Recording Secretary and Tom Woodin, our town manager, selectmens Jay Warren, Russ Hoffman, myself Denise Griffin, Will Hamblen and Wendy Wolf. And in the audience, we have our financial treasurer, Julia Latter. Okay, Tom, town manager announcements?',
        },
      ],
    },
    {
      name: 'Anouncements',
      talks: [
        // tslint:disable-next-line:max-line-length
        {
          Speaker: 'Thomas Woodin',
          Text:
            'Thank You. The only one I have right off is just that Bike Maine is coming up. As of Wednesday morning there will be support vehicles showing up with all their gear. The riders will start to come into town between 1 and 4 on Wednesday. There is about 300 riders coming into town and about 50 volunteers. And they�ll be staying through Thursday. There is going to be a lobster bake for them at the footbridge parking lot at 5 to 7. After that there�s live music at the Opera House, that�s open to the public. ',
        },
      ],
    },
    {
      name: 'Treasurer Report',
      talks: [
        { Speaker: 'Denise Griffin', Text: 'Good. Julia, financials.' },
        // tslint:disable-next-line:max-line-length
        {
          Speaker: 'Julia Latter',
          Text:
            '?? Total revenue is 82 million, ?? thousand, 868 dollars and 75 cents. Total expenses year to date are ??? Does anyone have any questions on ?? ?? ??? You do not have your graph sheet again. ??? issues with scheduling. Hopefully, ??? copies for you guys before the next selectmen�s meeting.?? presentation then. They assured me they will be bringing the ?? accounts payable is 296 thousand, 156 dollars and 32 cents. And the bank balance is 2 million, 631 thousand, 175 dollars and 95 cents.   (Julia Latter was not using a mic.)',
        },
        { Speaker: 'Denise Griffin', Text: 'Questions?' },
        { Speaker: 'Wendy Wolf', Text: 'Julia, maybe you can tell me: what�s the last time we competed the audit?' },
        { Speaker: 'Julia Latter', Text: 'Completed it?' },
        { Speaker: 'Wendy Wolf', Text: 'No, competed it for change of auditor or new audit?' },
        { Speaker: 'Man 1', Text: 'This is my fifth year so it�s been at least 5 years.' },
        { Speaker: 'Julia Latter', Text: 'Yeah, so it�s been about 5 years.' },
        // tslint:disable-next-line:max-line-length
        {
          Speaker: 'Wendy Wolf:',
          Text: 'Yeah, that�s something we should look at. That�s a long time to have the same audit firm.',
        },
        // tslint:disable-next-line:max-line-length
        {
          Speaker: 'Man 1',
          Text:
            'Yeah, we plan to do that anyway for the next audit season. There was a change in personnel at the audit company. It was late in the process so we didn�t have time to requite it out, so we will do that for the next one.',
        },
        { Speaker: 'Wendy Wolf', Text: 'OK, great.' },
        { Speaker: 'Denise Griffin', Text: 'You�re thinking that every 5 years, we should put it out for bid?' },
        { Speaker: 'Wendy Wolf', Text: 'Yes' },
        { Speaker: 'Julia Latter', Text: '??' },
      ],
    },
  ],
};
