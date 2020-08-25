using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Bogus;
using Bogus.DataSets;
using GM.DatabaseModel;

namespace FakeData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GenerateFakeMeeting();
        }

        static void GenerateFakeMeeting()
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

            var fakeDiscussions = new Faker<TopicDiscussion>()
                .RuleFor(x => x.Id, f => f.Random.Number(1, 20))
                .RuleFor(x => x.Talks, f => fakeTalk.Generate(5));

            var fakeSection = new Faker<Section>()
                .RuleFor(x => x.Id, f => f.Random.Number(1, 20))
                .RuleFor(x => x.Discussions, f => fakeDiscussions.Generate(5));

            var fakeMeeting = new Faker<Meeting>()
                .RuleFor(x => x.Id, f => f.Random.Number(100, 199))
                .RuleFor(x => x.Name, f => "Town Council")
                .RuleFor(x => x.Date, f => f.Date.Recent())
                .RuleFor(x => x.Length, f => f.Random.Number(minLen, maxLen));

            var meeting = fakeMeeting.Generate(1);

//            return meeting;
        }

        static string RandomTopic()
        {
            List<string> topics = new List<string>()
            {
                "School Safety",
                "Town Manager search",
                "Police hiring"
            };

            var rand = new Random();
            int x = rand.Next(0, topics.Count - 1);
            return topics[x];
        }
    }

    class Section
    {
        public int Id;
        public List<TopicDiscussion> Discussions;
    }
}
