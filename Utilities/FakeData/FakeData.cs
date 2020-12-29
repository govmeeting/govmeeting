using Bogus;
using System;
using System.Collections.Generic;
using GM.Application.DTOs.Meetings;

namespace GM.Utilities.FakeData
{
    public class FakeData
    {
        static Random random;
        readonly Faker faker = new Faker();
        int nextSectionName = 0;


        public FakeData()
        {
            random = new Random();
        }

        /*  A speaker may be a known official already in the database, an official not yet in the database
         *  or an anonymous citizen, for which we do not maintain a record in the database.
         *  For citizens, we temporarily use a unique key for the meeting, between 1 and 99.
         *  For known speakers, we would normally have the key from the database.
         *  For this RandomSpeaker method, we arbitrarily asign a key at random between 2000 and 2999. N
         *  We return at random either a known speaker or anonymous citizen.
         */
        public long RandomSpeaker(List<ViewMeetingSpeakerDto> Speakers)
        {
            ViewMeetingSpeakerDto s = new ViewMeetingSpeakerDto
            {
                Name = faker.Name.FullName()
            };
            int r = random.Next(1, 3);

            if (r == 1)
            {
                // new speaker
                s.SpeakerId = UniqueInt(1, 99);
                s.IsExisting = false;
            }
            else
            {
                // existing speaker
                s.SpeakerId = UniqueInt(2000, 2999);
                s.IsExisting = true;
            };
            // Add the speaker to the list
            Speakers.Add(s);
            return s.SpeakerId;

        }

        /*  The same logic described above for speakers is used for topics.
        */
        public long RandomTopic(List<ViewMeetingTopicDto> Topics)
        {
            int r = random.Next(1, 3);
            long id;
            ViewMeetingTopicDto t = new ViewMeetingTopicDto();

            if (r == 1)
            {
                // new topic
                t.Name = Topic(out id);
                t.TopicId = id;
                t.IsExisting = false;
                //mostRecentTDid = id;
            }
            else
            {
                // existing topic
                t.TopicId = UniqueInt(500, 599);
                t.Name = Topic(out id);
                t.IsExisting = true;
            }
            Topics.Add(t);
            return t.TopicId;
        }


        public string Topic(out long index)
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

            int x = random.Next(0, topics.Count - 1);
            index = x;
            return topics[x];
        }

        public string GetSectionName()
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




        // Get specified # of sentences from waffle text
        public string Text(Faker f, int sentences)
        {
            int i;
            string output = "";
            string text = f.WaffleText(1, false);
            char[] chars = { '.', '?', '!', '\n', '\r' };
            do
            {
                i = text.IndexOfAny(chars);
                if (i > 0)
                {
                    output += text.Substring(0, i - 1);
                }
                else
                {
                    output += text;
                    break;
                }
                text = text[i..];
            } while (--sentences > 0);
            return output;
        }

        // We want to use random numbers for record Id's.
        // But we want the numbers to also be unique
        // so that there is no database conflicts during testing.
        readonly List<int> randomList = new List<int>();
        public int UniqueInt(int min, int max)
        {
            int myNumber;
            do
            {
                myNumber = random.Next(min, max);
            } while (randomList.Contains(myNumber));
            return myNumber;
        }


    }
}
