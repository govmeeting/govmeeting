using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using NUnit.Framework;
using Govmeeting.Backend.Model;
using Govmeeting.Backend.DbAccess;

namespace Govmeeting.Backend.LoadTranscriptIntoDb.Tests
{
    [TestFixture()]
    public class LoadTranscriptIntoDbTests
    {
        string temporaryFilename = ".\\LoadTranscriptIntoDb_Test.txt";

        [OneTimeSetUp]
         public void PerFixtureSetup()
         {
             // Drop and recreate database
             using (dBOperations dbOps = new dBOperations())
             {
                 dbOps.DropAndRecreateDb();
             }
         }

        [OneTimeTearDown]
        public void PerFixtureTeardown()
        {
            File.Delete(temporaryFilename);
        }

        [Test()]
        public void Backend_LoadTranscriptIntoDb_Simple()
        {
            // ARRANGE
            string text = @"Body: Anyville Town Council
Meeting: Town Council Regular Meeting
Country: United States
Date: Sep 4, 2013
Topic: Fire equipment purchase
Category: Safety
Speaker:  Louise Dinkins
This equipment is badly needed.
Speaker: Joe Hammer
We need to consider the costs involved in purchasing this equipment.
";
            string testfilePath = CreateTestFile(text);

            // ACT
            if (testfilePath != null)
            {
                // NOTE: We can add " debug" to testfilePath to attach a debugger to LoadTranscriptIntoDb.exe.
                var process = Process.Start(@"..\..\..\LoadTranscriptIntoDb\bin\Debug\LoadTranscriptIntoDb.exe", testfilePath);
                process.WaitForExit();
            }

            // ASSERT
            using (dBOperations dbOps = new dBOperations())
            {
                List<GovernmentBody> govBodies = dbOps.GetGovernmentBodies();
                Assert.That(govBodies.Count(), Is.EqualTo(1));

                GovernmentBody gBody = govBodies[0];
                Assert.That(gBody.Name, Is.EqualTo("Anyville Town Council"));

                List<Category> categories = dbOps.GetCategories();
                Assert.That(categories.Count(), Is.EqualTo(1));
                Assert.That(categories[0].Name, Is.EqualTo("Safety"));

                List<Topic> topics = dbOps.GetExistingTopics(gBody.Id);
                Assert.That(topics.Count(), Is.EqualTo(1));
                Assert.That(topics[0].Name, Is.EqualTo("Fire equipment purchase"));

                List<Meeting> meetings = dbOps.GetMeetings(gBody.Id);
                Assert.That(meetings.Count(), Is.EqualTo(1));
                Meeting meeting = (meetings[0]);
                Assert.That(meeting.Name, Is.EqualTo("Town Council Regular Meeting"));
                Assert.That(meeting.Date, Is.EqualTo(DateTime.Parse("Sep 4, 2013")));

                List<TopicDiscussion> TopicDiscussions = dbOps.GetTopicDiscussions(meeting.Id);
                Assert.That(TopicDiscussions.Count(), Is.EqualTo(1));
                TopicDiscussion td = TopicDiscussions[0];

                List<Talk> Talks = dbOps.GetTalks(td.Id);
                Assert.That(td.Talks.Count(), Is.EqualTo(2));
                Assert.That(td.Talks[0].Text, Is.EqualTo("This equipment is badly needed."));
                // Todo(gm): Get speaker names. Right now we only see SpeakerId.
                // Assert.That(td.Talks[0].Speaker.Name, Is.EqualTo("Louise Dinkins"));
                Assert.That(td.Talks[1].Text, Is.EqualTo("We need to consider the costs involved in purchasing this equipment."));
                // Assert.That(td.Talks[1].Speaker.Name, Is.EqualTo("Joe Hammer"));
            }
        }

        // Todo(gm): write this test for a more complete transcript file than the simple example above.
        //[Test()]
        //public void Backend_LoadTranscriptIntoDb_Full()
        //{
        //    // ARRANGE
        //    string filename = @"..\..\..\testdata\Boothbay Harbor Selectmen meeting - 2014-09-08 - with topics.txt";

        //    // ACT
        //    Process.Start("LoadTranscriptIntoDb.exe", filename);

        //    // ASSERT

        //}
        static string CreateTestFile(string text)
        {
            FileInfo fi = new FileInfo("LoadTranscriptIntoDb_Test.txt");

            try
            {
                // Check if file already exists. If yes, delete it. 
                if (fi.Exists)
                {
                    fi.Delete();
                }

                // Create a new file 
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.Write(text);
                }

            }

            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return null;
            }
            return fi.FullName;
        }
    }
}
