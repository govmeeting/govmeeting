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
    //public class FakeMeeting
    //{
    //    long mostRecentTDid = 0;
    //    int nextSectionName = 0;
    //    int talkSequence = 1;
    //    int tdSequence = 1;
    //    long governmentBodyId;
    //    long MeetingId = 0;

    //    public Meeting GenerateMeeting()
    //    {
    //        governmentBodyId = UniqueRandomInt(300, 399);
    //        MeetingId = UniqueRandomInt(200, 299);

    //        var fakeSpeaker = new Faker<Speaker>()
    //           .RuleFor(x => x.Id, f => UniqueRandomInt(101, 199))
    //           .RuleFor(x => x.Name, f => f.Person.FullName);

    //        var fakeTalk = new Faker<Talk>()
    //           .RuleFor(x => x.Id, f => UniqueRandomInt(2000, 2999))
    //           .RuleFor(x => x.Speaker, f => fakeSpeaker)
    //           .RuleFor(x => x.Text, f => Waffle(f, 1))
    //           .RuleFor(x => x.TopicDiscussionId, f => mostRecentTDid)
    //           .RuleFor(x => x.Sequence, f => talkSequence++);

    //        var fakeTopic = new Faker<Topic>()
    //            .RuleFor(x => x.Id, f => UniqueRandomInt(400, 499))
    //            .RuleFor(x => x.Name, f => RandomTopicName())
    //            .RuleFor(x => x.GovernmentBodyId, f => governmentBodyId);

    //        var fakeDiscussions = new Faker<TopicDiscussion>()
    //            .RuleFor(x => x.Id, f => RandomTPid())
    //            .RuleFor(x => x.Topic, f => fakeTopic.Generate(1)[0])
    //            .RuleFor(x => x.Talks, f => fakeTalk.Generate(2))
    //            .RuleFor(x => x.Sequence, f => tdSequence++)
    //            .RuleFor(x => x.MeetingId, f => MeetingId);

    //        var fakeSection = new Faker<Section>()
    //            .RuleFor(x => x.Id, f => UniqueRandomInt(600, 699))
    //            .RuleFor(x => x.Name, f => GetSectionName())
    //            .RuleFor(x => x.TopicDiscussions, f => fakeDiscussions.Generate(2));

    //        int msInMinute = 60 * 1000;
    //        int minLen = 50 * msInMinute;
    //        int maxLen = 90 * msInMinute;
    //        var fakeMeeting = new Faker<Meeting>()
    //            .RuleFor(x => x.Id, f => MeetingId)
    //            .RuleFor(x => x.Name, f => "Town Council")
    //            .RuleFor(x => x.Date, f => f.Date.Recent())
    //            .RuleFor(x => x.Language, f => "en")
    //            .RuleFor(x => x.Length, f => f.Random.Number(minLen, maxLen))
    //            .RuleFor(x => x.Sections, f => fakeSection.Generate(2))
    //            .RuleFor(x => x.GovbodyId, f => governmentBodyId);


    //        Meeting meeting = fakeMeeting.Generate(1)[0];

    //        return meeting;
    //    }

    //    long RandomTPid()
    //    {
    //        long id = UniqueRandomInt(500, 599);
    //        mostRecentTDid = id;
    //        return id;
    //    }

    //    string RandomTopicName()
    //    {
    //        List<string> topics = new List<string>()
    //        {
    //            "school safety",
    //            "town manager search",
    //            "police hiring",
    //            "traffic signal",
    //            "senior transportation",
    //            "peddlers licenses",
    //            "town budget",
    //            "public housing",
    //            "shade tree commission",
    //            "recycling center",
    //            "parking ordinances",
    //            "liquor licenses",
    //            "bids for covid-19 testing",
    //            "property liens",
    //            "recreation center",
    //            "workers' compensatin claims",
    //            "cell tower installation",
    //            "sidewalk improvements",
    //            "animal shelter",
    //            "town complex landscaping",
    //            "renters' ordinance",
    //            "plastic bag ban",
    //            "used car lot ordinance",
    //            "hazardous material storage",
    //            "open space preservation",
    //            "census committee",
    //            "sewer utility rates",
    //            "business area parking",
    //            "city center beautification",
    //            "city pools",
    //            "bond issuance",
    //            "vaccination program",
    //            "vaping ban",
    //            "handicapped parking",
    //            "fire station alterations",
    //            "vending machine concession",
    //            "emergency alert system",
    //            "park improvements",
    //            "water storage facility",
    //            "disciplinary hearing",
    //            "waste collection",
    //            "volunteer expo",
    //            "officer salaries",
    //            "employee retirements"
    //        };

    //        var rand = new Random();
    //        int x = rand.Next(0, topics.Count - 1);
    //        return topics[x];
    //    }

    //    string GetSectionName()
    //    {
    //        List<string> sections = new List<string>()
    //        {
    //            "Presentation",
    //            "Approval of Minutes",
    //            "City Manager Presentation",
    //            "Reading of Ordinances",
    //            "Committee Reports",
    //            "Resolutions",
    //            "Public Comment",
    //        };

    //        if (nextSectionName > sections.Count) { nextSectionName = 1; }

    //        return sections[nextSectionName++];
    //    }

    //    // Get specified # of sentences from waffle text
    //    string Waffle(Faker f, int sentences)
    //    {
    //        int i;
    //        string output = "";
    //        string text = f.WaffleText(1, false);
    //        char[] chars = { '.', '?', '!', '\n', '\r' };
    //        do
    //        {
    //            i = text.IndexOfAny(chars);
    //            if (i > 0)
    //            {
    //                output += text.Substring(0, i - 1);
    //            }
    //            else
    //            {
    //                output += text;
    //                break;
    //            }
    //            text = text[i..];
    //        } while (--sentences > 0);
    //        return output;
    //    }

    //    // We want to use random numbers for record Id's.
    //    // But we want the numbers to also be unique
    //    // so that there is no database conflicts during testing.
    //    List<int> randomList = new List<int>();
    //    int UniqueRandomInt(int min, int max)
    //    {
    //        var rand = new Random();
    //        int myNumber;
    //        do
    //        {
    //            myNumber = rand.Next(min, max);
    //        } while (randomList.Contains(myNumber));
    //        return myNumber;
    //    }
    //}
}
