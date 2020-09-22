using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeData
{
    public class RandomData
    {
        static Random random;

        public RandomData()
        {
            random = new Random();
        }

        public string RandomTopicName(out long index)
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


        // Get specified # of sentences from waffle text
        public string Waffle(Faker f, int sentences)
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
        List<int> randomList = new List<int>();
        public int UniqueRandomInt(int min, int max)
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
