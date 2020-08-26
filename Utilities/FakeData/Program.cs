using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Bogus;
using Bogus.DataSets;
using GM.DatabaseModel;

namespace FakeData
{
    //public class Section
    //{
    //    public long Id { get; set; }
    //    public string Name { get; set; }
    //    public List<TopicDiscussion> TopicDiscussions { get; set; }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Meeting meeting = GenerateFakeMeeting();

            string text = Newtonsoft.Json.JsonConvert.SerializeObject(meeting, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(@"c:\tmp\fakemeeting.json", text);
            Console.WriteLine("Created meeting" + "\n" + text);
        }

        static Meeting GenerateFakeMeeting()
        {
            int msInMinute = 60 * 1000;
            int minLen = 50 * msInMinute;
            int maxLen = 90 * msInMinute;

            var fakeSpeaker = new Faker<Speaker>()
               .RuleFor(x => x.Id, f => f.Random.Number(1, 20))
               .RuleFor(x => x.Name, f => f.Person.FullName);

            var fakeTalk = new Faker<Talk>()
               .RuleFor(x => x.Id, f => f.Random.Number(1, 20))
               .RuleFor(x => x.Speaker, f => fakeSpeaker)
               .RuleFor(x => x.Text, f => f.WaffleText(1));

            var fakeTopic = new Faker<Topic>()
                .RuleFor(x => x.Id, f => f.Random.Number(1, 20))
                .RuleFor(x => x.Name, f => RandomTopic());

            //Talk talk = fakeTalk.Generate(1)[0];

            //List<Talk> talks = fakeTalk.Generate(3);

            var fakeDiscussions = new Faker<TopicDiscussion>()
                .RuleFor(x => x.Id, f => f.Random.Number(1, 20))
                .RuleFor(x => x.Talks, f => fakeTalk.Generate(2));

            //List<TopicDiscussion> discussions = fakeDiscussions.Generate(2);

            var fakeSection = new Faker<Section>()
                .RuleFor(x => x.Id, f => f.Random.Number(1, 20))
                .RuleFor(x => x.Name, f => GetSectionName())
                .RuleFor(x => x.TopicDiscussions, f => fakeDiscussions.Generate(2));

            //List<Section> sections = fakeSection.Generate(2);

            var fakeMeeting = new Faker<Meeting>()
                .RuleFor(x => x.Id, f => f.Random.Number(100, 199))
                .RuleFor(x => x.Name, f => "Town Council")
                .RuleFor(x => x.Date, f => f.Date.Recent())
                .RuleFor(x => x.Length, f => f.Random.Number(minLen, maxLen))
                .RuleFor(x => x.Sections, f => fakeSection.Generate(2));
            ;

            Meeting meeting = fakeMeeting.Generate(1)[0];

            return meeting;
        }

        static string RandomTopic()
        {
            List<string> topics = new List<string>()
            {
                "school safety",
                "town manager search",
                "police hiring",
                "traffic signal",
                "senior transportation",
                "peddlers licenses",
                "town budget",
                "public housing",
                "shade tree commission",
                "recycling center",
                "parking ordinances",
                "liquor licenses",
                "bids for covid-19 testing",
                "property liens",
                "recreation center",
                "workers' compensatin claims",
                "cell tower installation",
                "sidewalk improvements",
                "animal shelter",
                "town complex landscaping",
                "renters' ordinance",
                "plastic bag ban",
                "used car lot ordinance",
                "hazardous material storage",
                "open space preservation",
                "census committee",
                "sewer utility rates",
                "business area parking",
                "city center beautification",
                "city pools",
                "bond issuance",
                "vaccination program",
                "vaping ban",
                "handicapped parking",
                "fire station alterations",
                "vending machine concession",
                "emergency alert system",
                "park improvements",
                "water storage facility",
                "disciplinary hearing",
                "waste collection",
                "volunteer expo",
                "officer salaries",
                "employee retirements"
            };

            var rand = new Random();
            int x = rand.Next(0, topics.Count - 1);
            return topics[x];
        }

        static string GetSectionName()
        {
            int x = 0;

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

            if (x > sections.Count) { x = 1; }

            return sections[x];
        }
    }
}
