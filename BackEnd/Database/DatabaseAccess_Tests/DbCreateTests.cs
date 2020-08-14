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
            // ARRANGE

            GovernmentBody bodyWritten = new GovernmentBody()
            {
                Name = "U.S. Senate",
                Country = "U.S.A.",
                Meetings = new List<Meeting>()
            };

            // ACT

            //using (var context = new ApplicationDbContext())
            using var context = GetAppDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.GovernmentBodies.Add(bodyWritten);
            context.SaveChanges();

            // ASSERT

            var query = from g in context.GovernmentBodies
                        select g;
            var bodyRetrieved = query.SingleOrDefault();
            Assert.That(bodyRetrieved, Is.Not.Null);
            Assert.That(bodyRetrieved.Name, Is.EqualTo(bodyWritten.Name));
            Assert.That(bodyRetrieved.Country, Is.EqualTo(bodyWritten.Country));
        }

        /// <summary>
        /// Creates the one gov body and meeting test.
        /// </summary>
        [Test()]
        public void Backend_DbAccess_CreateOneGovBodyAndMeetingTest()
        {
            // ARRANGE

            GovernmentBody bW = new GovernmentBody()
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
                            sampleDiscussion1,
                            sampleDiscussion2
                        }
                    }
                }
            };

            // ACT

            using (var context = GetAppDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.GovernmentBodies.Add(bW);
                context.SaveChanges();

                // ASSERT

                //Assert.That(context.GovernmentBodies.Local.Count, Is.EqualTo(0));

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
                var bR = query.SingleOrDefault();

                Assert.That(bR, Is.Not.Null);
                Assert.That(bR.Name, Is.EqualTo(bW.Name));
                Assert.That(bR.Meetings[0], Is.Not.Null);

                // Check meeting object.
                Meeting mW = bW.Meetings[0];
                Meeting mR = bR.Meetings[0];
                Assert.That(mR.Name, Is.EqualTo(mW.Name));
                Assert.That(mR.Date, Is.EqualTo(mW.Date));
                Assert.That(mR.TopicDiscussions[0], Is.Not.Null);
                Assert.That(mR.TopicDiscussions.Count, Is.EqualTo(2));

                for (int i = 0; i < 2; i++)
                {
                    TopicDiscussion tW = mW.TopicDiscussions[i];
                    TopicDiscussion tR = mR.TopicDiscussions[i];

                    Assert.That(tR.Sequence, Is.EqualTo(tW.Sequence));

                    // Check topic.
                    Assert.That(tR.Topic, Is.Not.Null);
                    Assert.That(tR.Topic.Name, Is.EqualTo(tW.Topic.Name));

                    // Check categories.
                    Assert.That(tR.Topic.Categories, Is.Not.Null);
                    List<Category> cW = tW.Topic.Categories;
                    List<Category> cR = tR.Topic.Categories;
                    Assert.That(cR.Count, Is.EqualTo(1));
                    Assert.That(cR[0].Name, Is.EqualTo(cW[0].Name));

                    // Check talks and speakers
                    Assert.That(tR.Talks, Is.Not.Null);
                    List<Talk> tkW = tW.Talks;
                    List<Talk> tkR = tR.Talks;
                    Assert.That(tkR.Count, Is.EqualTo(2));
                    // talk 0
                    Assert.That(tkR[0].Text, Is.EqualTo(tkW[0].Text));
                    Assert.That(tkR[0].Speaker, Is.Not.Null);
                    Assert.That(tkR[0].Speaker.Name, Is.EqualTo(tkW[0].Speaker.Name));
                    // talk 1
                    Assert.That(tkR[1].Text, Is.EqualTo(tkW[1].Text));
                    Assert.That(tkR[1].Speaker, Is.Not.Null);
                    Assert.That(tkR[1].Speaker.Name, Is.EqualTo(tkW[1].Speaker.Name));
                }
            }
        }

        public ApplicationDbContext GetAppDbContext()
        {
            string connection = "Server=(localdb)\\mssqllocaldb;Database=GovmeetingTest;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connection);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }

        // SAMPLE DATA //

        private TopicDiscussion sampleDiscussion1 = new TopicDiscussion()
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

        TopicDiscussion sampleDiscussion2 = new TopicDiscussion()
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

    }
}
