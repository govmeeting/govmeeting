using Bogus;
using Bogus.DataSets;
using GM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeData
{
    public class FakeTranscriptViewModel
    {
        long MeetingId = 0;
        //long governmentBodyId;
        //long mostRecentTDid = 0;
        int nextSectionName = 0;
        RandomData RD = new RandomData();
        Random random = new Random();
        string meetingDate = DateTime.Now.AddDays(-4).ToString("d");
        List<TopicView> Topics = new List<TopicView>();
        List<SpeakerView> Speakers = new List<SpeakerView>();
        Faker faker = new Faker();

        public MeetingViewDto GenerateFake()
        {
            var fakeTalk = new Faker<TalkView>()
               .RuleFor(x => x.SpeakerId, f => RandomSpeaker())
               .RuleFor(x => x.Text, f => RD.Waffle(f, 1));

            var fakeDiscussions = new Faker<TopicDiscussionView>()
                .RuleFor(x => x.TopicId, f => RandomTopic())
                .RuleFor(x => x.Talks, f => fakeTalk.Generate(2));

            var fakeSection = new Faker<SectionView>()
                .RuleFor(x => x.Name, f => GetSectionName())
                .RuleFor(x => x.TopicDiscussions, f => fakeDiscussions.Generate(2));

            var fakeTVM = new Faker<MeetingViewDto>()
               .RuleFor(x => x.MeetingId, f => MeetingId)
               .RuleFor(x => x.GovBodyName, f => "City Council")
               .RuleFor(x => x.LocationName, f => "United States - Texas - Potter County - Amarillo")
               .RuleFor(x => x.Date, f => meetingDate)
               .RuleFor(x => x.Sections, f => fakeSection.Generate(2));

            MeetingViewDto transcriptViewModel = fakeTVM.Generate(1)[0];

            transcriptViewModel.Topics = Topics;
            transcriptViewModel.Speakers = Speakers;

            return transcriptViewModel;
        }

        long RandomSpeaker()
        {
            SpeakerView s = new SpeakerView();
            s.Name = faker.Name.FullName();
            int r = random.Next(1, 3);

            if (r == 1)
            {
                // new speaker
                s.SpeakerId = RD.UniqueRandomInt(1, 99);
                s.IsExisting = false;
            } else
            {
                // existing speaker
                s.SpeakerId = RD.UniqueRandomInt(2000, 2999);
                s.IsExisting = true;
            };
            Speakers.Add(s);
            return s.SpeakerId;

        }

        long RandomTopic()
        {
            int r = random.Next(1, 3);
            long id;
            TopicView t = new TopicView();

            if (r == 1)
            {
                // new topic
                t.Name = RD.RandomTopicName(out id);
                t.TopicId = id;
                t.IsExisting = false;
                //mostRecentTDid = id;
            }
            else
            {
                // existing topic
                t.TopicId = RD.UniqueRandomInt(500, 599);
                t.Name = RD.RandomTopicName(out id);
                t.IsExisting = true;
            }
            Topics.Add(t);
            return t.TopicId;
        }

        string GetSectionName()
        {
            List<string> sections = new List<string>()
                {
                    "Presentation",
                    "Approval of Minutes",
                    "City Manager Presentation",
                    "Reading of Ordinances",
                    "Committee Reports",
                    "Resolutions",
                    "Public Comment",
                };

            if (nextSectionName > sections.Count) { nextSectionName = 1; }

            return sections[nextSectionName++];
        }

    }
}
