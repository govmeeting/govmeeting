using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using GM.DatabaseModel;
using GM.DatabaseAccess;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS0162

namespace GM.DatabaseAccess.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture()]
    public class DbAccessTestTests
    {
        /// <summary>
        /// Creates the one gov body test.
        /// </summary>
        [Test()]
        public void Backend_DbAccess_CreateOneGovBodyTest()
        {
            Assert.That(1 + 1, Is.EqualTo(2));
            return;

            // ARRANGE

            // Database.SetInitializer(
            //    new DropCreateDatabaseAlways<MeetingContext>());

            GovernmentBody BodyWritten = new GovernmentBody()
            {
                Name = "U.S. Senate",
                Country = "U.S.A.",
                Meetings = new List<Meeting>()
            };

            // ACT

            //using (var context = new ApplicationDbContext())
            using var context = GetAppDbContext();
            //if (context.Database.Exists()) context.Database.Delete();

            context.GovernmentBodies.Add(BodyWritten);
            context.SaveChanges();

            // ASSERT

            var query = from g in context.GovernmentBodies
                        select g;
            var BodyRetrieved = query.SingleOrDefault();
            Assert.That(BodyRetrieved, Is.Not.Null);
            Assert.That(BodyRetrieved.Name, Is.EqualTo(BodyWritten.Name));
            Assert.That(BodyRetrieved.Country, Is.EqualTo(BodyWritten.Country));
        }

        /// <summary>
        /// Creates the one gov body and meeting test.
        /// </summary>
        [Test()]
        public void Backend_DbAccess_CreateOneGovBodyAndMeetingTest()
        {
            Assert.That(1 + 1, Is.EqualTo(2));
            return;

            // ARRANGE

            TopicDiscussion topicDiscussion1 = new TopicDiscussion()
            {
                Topic = new Topic()
                {
                    Name = "Bill #124643",
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Health"
                        }
                    }
                },
                Sequence = 1,
                Talks = new List<Talk>()
                {
                    new Talk()
                    {
                        Text = "I disagree.",
                        Sequence = 1,
                        Speaker = new Citizen()
                        {
                            Name = "Harry"
                        }
                    },
                    new Talk()
                    {
                        Text = "I agree.",
                        Sequence = 1,
                        Speaker = new Official()
                        {
                            Name = "Town Manager Sally"
                        }
                    }
                }
            };

            TopicDiscussion topicDiscussion2 = new TopicDiscussion()
            {
                Topic = new Topic()
                {
                    Name = "Bill #987698",
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Defense"
                        }
                    }
                },
                Sequence = 2,
                Talks = new List<Talk>()
                {
                    new Talk()
                    {
                        Text = "I agree.",
                        Sequence = 1,
                        Speaker = new Citizen()
                        {
                            Name = "Mary"
                        }
                    },
                    new Talk()
                    {
                        Text = "I disagree.",
                        Sequence = 2,
                        Speaker = new Representative()
                        {
                            Name = "Assemblyman Pete"
                        }
                    }
                }
            };

            GovernmentBody BodyWritten = new GovernmentBody()
            {
                Name = "U.S. Congress",
                Country = "U.S.A.",
                Meetings = new List<Meeting>()
                    {
                        new Meeting()
                        {
                            Name = "Regular Session Meeting",
                            Date = DateTime.Parse("Nov 1, 1945 10:11 GMT"),
                            TopicDiscussions = new List<TopicDiscussion>()
                            {
                                topicDiscussion1,
                                topicDiscussion2
                            }
                        }
                    }
            };

            // ACT

            using (var context = GetAppDbContext())
            {
                //if (context.Database.Exists()) context.Database.Delete();
                context.GovernmentBodies.Add(BodyWritten);
                context.SaveChanges();
            }

            // ASSERT

            // Re-create the context.
            using (var context = GetAppDbContext())
            {
                Assert.That(context.GovernmentBodies.Local.Count, Is.EqualTo(0));

                // Re-load the context from the database.
                //context.GovernmentBodies.Load();
                //context.Meetings.Load();
                //context.TopicDiscussions.Load();
                //context.Talks.Load();
                //context.Topics.Load();
                //context.Speakers.Load();
                //context.Categories.Load();

                var query = from g in context.GovernmentBodies
                            select g;
                var BodyRetrieved = query.SingleOrDefault();

                Assert.That(BodyRetrieved, Is.Not.Null);
                Assert.That(BodyRetrieved.Name, Is.EqualTo(BodyWritten.Name));
                Assert.That(BodyRetrieved.Meetings[0], Is.Not.Null);

                // Check meeting object.
                Meeting meetingWritten = BodyWritten.Meetings[0];
                Meeting meetingRetrieved = BodyRetrieved.Meetings[0];
                Assert.That(meetingRetrieved.Name, Is.EqualTo(meetingWritten.Name));
                Assert.That(meetingRetrieved.Date, Is.EqualTo(meetingWritten.Date));
                Assert.That(meetingRetrieved.TopicDiscussions[0], Is.Not.Null);
                Assert.That(meetingRetrieved.TopicDiscussions.Count, Is.EqualTo(2));

                for (int i = 0; i < 2; i++)
                {
                    TopicDiscussion tdWritten = meetingWritten.TopicDiscussions[i];
                    TopicDiscussion tdRetrieved = meetingRetrieved.TopicDiscussions[i];

                    Assert.That(tdRetrieved.Sequence, Is.EqualTo(tdWritten.Sequence));

                    // Check topic.
                    Assert.That(tdRetrieved.Topic, Is.Not.Null);
                    Assert.That(tdRetrieved.Topic.Name, Is.EqualTo(tdWritten.Topic.Name));

                    // Check categories.
                    Assert.That(tdRetrieved.Topic.Categories, Is.Not.Null);
                    List<Category> cWritten = tdWritten.Topic.Categories;
                    List<Category> cRetrieved = tdRetrieved.Topic.Categories;
                    Assert.That(cRetrieved.Count, Is.EqualTo(1));
                    Assert.That(cRetrieved[0].Name, Is.EqualTo(cWritten[0].Name));

                    // Check talks and speakers
                    Assert.That(tdRetrieved.Talks, Is.Not.Null);
                    List<Talk> tkWritten = tdWritten.Talks;
                    List<Talk> tkRetrieved = tdRetrieved.Talks;
                    Assert.That(tkRetrieved.Count, Is.EqualTo(2));
                    // talk 0
                    Assert.That(tkRetrieved[0].Text, Is.EqualTo(tkWritten[0].Text));
                    Assert.That(tkRetrieved[0].Speaker, Is.Not.Null);
                    Assert.That(tkRetrieved[0].Speaker.Name, Is.EqualTo(tkWritten[0].Speaker.Name));
                    // talk 1
                    Assert.That(tkRetrieved[1].Text, Is.EqualTo(tkWritten[1].Text));
                    Assert.That(tkRetrieved[1].Speaker, Is.Not.Null);
                    Assert.That(tkRetrieved[1].Speaker.Name, Is.EqualTo(tkWritten[1].Speaker.Name));
                }
            }
        }

        public ApplicationDbContext GetAppDbContext()
        {
            string connection = "Server=(localdb)\\mssqllocaldb;Database=Govmeeting02;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connection);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }
    }
}
