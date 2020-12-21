using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Bogus;
using Bogus.DataSets;

using GM.ApplicationCore.Entities.Govbodies;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.Speakers;
using GM.ApplicationCore.Entities.Topics;

namespace FakeData
{
    public class FakeMeeting
    {
        FakeData fakeData = new FakeData();
        long mostRecentTDid = 0;
        int talkSequence = 1;
        int tdSequence = 1;
        long governmentBodyId;
        long MeetingId = 0;

        public Meeting GenerateFake()
        {
            //governmentBodyId = UniqueRandomInt(300, 399);
            governmentBodyId = fakeData.UniqueInt(300, 399);
            MeetingId = fakeData.UniqueInt(200, 299);

            var fakeSpeaker = new Faker<Speaker>()
               .RuleFor(x => x.Id, f => fakeData.UniqueInt(101, 199))
               .RuleFor(x => x.Name, f => f.Person.FullName);

            var fakeTalk = new Faker<Talk>()
               .RuleFor(x => x.Id, f => fakeData.UniqueInt(2000, 2999))
               .RuleFor(x => x.Speaker, f => fakeSpeaker)
               .RuleFor(x => x.Text, f => fakeData.Text(f, 1))
               .RuleFor(x => x.TopicDiscussionId, f => mostRecentTDid)
               .RuleFor(x => x.Sequence, f => talkSequence++);

            long topicIndex;
            var fakeTopic = new Faker<Topic>()
                .RuleFor(x => x.Id, f => fakeData.UniqueInt(400, 499))
                .RuleFor(x => x.Name, f => fakeData.Topic(out topicIndex))
                .RuleFor(x => x.GovernmentBodyId, f => governmentBodyId);

            var fakeDiscussions = new Faker<TopicDiscussion>()
                .RuleFor(x => x.Id, f => RandomTPid())
                .RuleFor(x => x.Topic, f => fakeTopic.Generate(1)[0])
                .RuleFor(x => x.Talks, f => fakeTalk.Generate(2))
                .RuleFor(x => x.Sequence, f => tdSequence++);
                //.RuleFor(x => x.MeetingId, f => MeetingId);

            var fakeSection = new Faker<Section>()
                .RuleFor(x => x.Id, f => fakeData.UniqueInt(600, 699))
                .RuleFor(x => x.Name, f => fakeData.GetSectionName())
                .RuleFor(x => x.TopicDiscussions, f => fakeDiscussions.Generate(2));

            int msInMinute = 60 * 1000;
            int minLen = 50 * msInMinute;
            int maxLen = 90 * msInMinute;
            var fakeMeeting = new Faker<Meeting>()
                .RuleFor(x => x.Id, f => MeetingId)
                .RuleFor(x => x.Name, f => "Town Council")
                .RuleFor(x => x.Date, f => f.Date.Recent())
                .RuleFor(x => x.Language, f => "en")
                .RuleFor(x => x.Length, f => f.Random.Number(minLen, maxLen))
                .RuleFor(x => x.Sections, f => fakeSection.Generate(2))
                .RuleFor(x => x.GovbodyId, f => governmentBodyId);


            Meeting meeting = fakeMeeting.Generate(1)[0];

            return meeting;
        }

        long RandomTPid()
        {
            long id = fakeData.UniqueInt(500, 599);
            mostRecentTDid = id;
            return id;
        }
    }
}
