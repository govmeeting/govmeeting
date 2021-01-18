using Bogus;
using System;
using System.Collections.Generic;
using GM.Application.DTOs.Meetings;

namespace GM.Utilities.FakeData
{
    public class FakeTranscriptViewDto
    {
        readonly int MeetingId = 0;
        readonly FakeData fakeData = new FakeData();
        readonly string meetingDate = DateTime.Now.AddDays(-4).ToString("d");
        readonly List<ViewMeetingTopic_Dto> Topics = new List<ViewMeetingTopic_Dto>();
        readonly List<ViewMeetingSpeaker_Dto> Speakers = new List<ViewMeetingSpeaker_Dto>();
        readonly Faker faker = new Faker();

        public ViewMeeting_Dto GenerateFake()
        {
            // A "talk" is a speaker and what he/she said.
            var talk = new Faker<ViewMeetingTalk_Dto>()
               .RuleFor(x => x.SpeakerId, f => GenerateSpeaker())
               .RuleFor(x => x.Text, f => fakeData.Text(f, 1));

            // A topicDiscussion is a series of talks on a single topic.
            var topicDiscussion = new Faker<ViewMeetingTopicDiscussion_Dto>()
                .RuleFor(x => x.TopicId, f => GenerateTopic())
                .RuleFor(x => x.Talks, f => Generate(talk, 2));

            // A section is a series of topicDiscussions.
            var section = new Faker<ViewMeetingSection_Dto>()
                .RuleFor(x => x.Name, f => GenerateSection())
                .RuleFor(x => x.TopicDiscussions, f => Generate(topicDiscussion, 2));

            // A meetingViewDto is a series of sections
            var dto = new Faker<ViewMeeting_Dto>()
               .RuleFor(x => x.MeetingId, f => MeetingId)
               .RuleFor(x => x.GovbodyName, f => "City Council")
               .RuleFor(x => x.LocationName, f => "United States - Texas - Potter County - Amarillo")
               .RuleFor(x => x.Date, f => meetingDate)
               .RuleFor(x => x.Sections, f => Generate(section, 2));

            ViewMeeting_Dto meetingViewDto = dto.Generate(1)[0];

            meetingViewDto.Topics = Topics;
            meetingViewDto.Speakers = Speakers;

            return meetingViewDto;
        }

        // These short methods are broken out of the above rules, so that it is easier to set
        // breakpoints on them. 

        // Generate specified count of TalkView objects
        private List<ViewMeetingTalk_Dto> Generate(Faker<ViewMeetingTalk_Dto> f, int count) => f.Generate(count);

        // Generate specified count of TopicDiscussionView objects. These include TalkView objects.
        private List<ViewMeetingTopicDiscussion_Dto> Generate(Faker<ViewMeetingTopicDiscussion_Dto> f, int count) => f.Generate(count);

        // Generate specified count of SectionView objects. These include TopicDiscussionView objects
        // which in turn include TalkView objects
        private List<ViewMeetingSection_Dto> Generate(Faker<ViewMeetingSection_Dto> f, int count) => f.Generate(count);

        // Get a random speaker name, create speaker object and add it to the Speakers list.
        private long GenerateSpeaker() => fakeData.RandomSpeaker(Speakers);

        // Get a random topic name, create topic object and add it to the Topics list.
        private long GenerateTopic() => fakeData.RandomTopic(Topics);

        // Get the next section name.
        private string GenerateSection() => fakeData.GetSectionName();
    }
}
