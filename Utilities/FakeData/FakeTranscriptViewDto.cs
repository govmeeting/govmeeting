using Bogus;
using Bogus.DataSets;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.MeetingsDto;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace FakeData
{
    public class FakeTranscriptViewDto
    {
        readonly int MeetingId = 0;
        readonly FakeData fakeData = new FakeData();
        readonly string meetingDate = DateTime.Now.AddDays(-4).ToString("d");
        readonly List<ViewMeetingTopicDto> Topics = new List<ViewMeetingTopicDto>();
        readonly List<ViewMeetingSpeakerDto> Speakers = new List<ViewMeetingSpeakerDto>();
        readonly Faker faker = new Faker();

        public ViewMeetingDto GenerateFake()
        {
            // A "talk" is a speaker and what he/she said.
            var talk = new Faker<ViewMeetingTalkDto>()
               .RuleFor(x => x.SpeakerId, f => GenerateSpeaker())
               .RuleFor(x => x.Text, f => fakeData.Text(f, 1));

            // A topicDiscussion is a series of talks on a single topic.
            var topicDiscussion = new Faker<ViewMeetingTopicDiscussionDto>()
                .RuleFor(x => x.TopicId, f => GenerateTopic())
                .RuleFor(x => x.Talks, f => Generate(talk, 2));

            // A section is a series of topicDiscussions.
            var section = new Faker<ViewMeetingSectionDto>()
                .RuleFor(x => x.Name, f => GenerateSection())
                .RuleFor(x => x.TopicDiscussions, f => Generate(topicDiscussion, 2));

            // A meetingViewDto is a series of sections
            var dto = new Faker<ViewMeetingDto>()
               .RuleFor(x => x.MeetingId, f => MeetingId)
               .RuleFor(x => x.GovbodyName, f => "City Council")
               .RuleFor(x => x.LocationName, f => "United States - Texas - Potter County - Amarillo")
               .RuleFor(x => x.Date, f => meetingDate)
               .RuleFor(x => x.Sections, f => Generate(section, 2));

            ViewMeetingDto meetingViewDto = dto.Generate(1)[0];

            meetingViewDto.Topics = Topics;
            meetingViewDto.Speakers = Speakers;

            return meetingViewDto;
        }

        // These short methods are broken out of the above rules, so that it is easier to set
        // breakpoints on them. 

        // Generate specified count of TalkView objects
        private List<ViewMeetingTalkDto> Generate(Faker<ViewMeetingTalkDto> f, int count) => f.Generate(count);

        // Generate specified count of TopicDiscussionView objects. These include TalkView objects.
        private List<ViewMeetingTopicDiscussionDto> Generate(Faker<ViewMeetingTopicDiscussionDto> f, int count) => f.Generate(count);

        // Generate specified count of SectionView objects. These include TopicDiscussionView objects
        // which in turn include TalkView objects
        private List<ViewMeetingSectionDto> Generate(Faker<ViewMeetingSectionDto> f, int count) => f.Generate(count);

        // Get a random speaker name, create speaker object and add it to the Speakers list.
        private long GenerateSpeaker() => fakeData.RandomSpeaker(Speakers);

        // Get a random topic name, create topic object and add it to the Topics list.
        private long GenerateTopic() => fakeData.RandomTopic(Topics);

        // Get the next section name.
        private string GenerateSection() => fakeData.GetSectionName();
    }
}
