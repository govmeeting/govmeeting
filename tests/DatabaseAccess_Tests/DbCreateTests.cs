using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using GM.DatabaseModel;
using DeepEqual.Syntax;

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
        /// Creates one GovBody.
        /// </summary>
        [Test()]
        public void Backend_DbAccess_CreateOneGovBodyTest()
        {
            // ARRANGE

            GovBody bodyWritten = new GovBody()
            {
                Name = "U.S. Senate",
            };

            // ACT

            // We have our choice of using 4 different DB providers. See GetAppDbContext.
            using var context = GetAppDbContext.GetInMemoryProvider();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.GovBodies.Add(bodyWritten);
            context.SaveChanges();

            // ASSERT

            var query = from g in context.GovBodies
                        select g;
            var bodyRetrieved = query.SingleOrDefault();

            Assert.That(bodyRetrieved, Is.Not.Null);
            Assert.That(bodyWritten.IsDeepEqual(bodyRetrieved));
        }

        ///// <summary>
        ///// Creates one GovBodyand Meeting.
        ///// </summary>
        //[Test()]
        //public void Backend_DbAccess_CreateOneGovBodyAndMeetingTest()
        //{
        //    // ARRANGE

        //    TopicDiscussion sampleDiscussion1 = new TopicDiscussion()
        //    {
        //        Topic = new Topic()
        //        {
        //            Name = "Bill #124643",
        //            Categories = new List<Category>()
        //    {
        //        new Category()
        //        {
        //            Name = "Health"
        //        }
        //    }
        //        },
        //        Sequence = 1,
        //        Talks = new List<Talk>()
        //        {
        //            new Talk()
        //            {
        //                Text = "I disagree.",
        //                Sequence = 1,
        //                Speaker = new Citizen()
        //                {
        //                    Name = "Harry"
        //                }
        //            },
        //            new Talk()
        //            {
        //                Text = "I agree.",
        //                Sequence = 1,
        //                Speaker = new Official()
        //                {
        //                    Name = "Town Manager Sally"
        //                }
        //            }
        //        }
        //    };

        //    TopicDiscussion sampleDiscussion2 = new TopicDiscussion()
        //    {
        //        Topic = new Topic()
        //        {
        //            Name = "Bill #987698",
        //            Categories = new List<Category>()
        //                {
        //                    new Category()
        //                    {
        //                        Name = "Defense"
        //                    }
        //                }
        //        },
        //        Sequence = 2,
        //        Talks = new List<Talk>()
        //        {
        //            new Talk()
        //            {
        //                Text = "I agree.",
        //                Sequence = 1,
        //                Speaker = new Citizen()
        //                {
        //                    Name = "Mary"
        //                }
        //            },
        //            new Talk()
        //            {
        //                Text = "I disagree.",
        //                Sequence = 2,
        //                Speaker = new Representative()
        //                {
        //                    Name = "Assemblyman Pete"
        //                }
        //            }
        //        }
        //    };


        //    Section sampleSection1 = new Section()
        //    {
        //        TopicDiscussions = new List<TopicDiscussion>()
        //        {
        //            sampleDiscussion1,
        //            sampleDiscussion2
        //        }
        //    };

        //    Section sampleSection2 = new Section()
        //    {
        //        TopicDiscussions = new List<TopicDiscussion>()
        //        {
        //            sampleDiscussion1,
        //            sampleDiscussion2
        //        }
        //    };

        //    GovBody bodyWritten = new GovBody()
        //    {
        //        Name = "U.S. Congress",
        //        Meetings = new List<Meeting>()
        //        {
        //            new Meeting()
        //            {
        //                Name = "Regular Session Meeting",
        //                Date = DateTime.Parse("Nov 1, 1945 10:11 GMT"),
        //                Sections = new List<Section>()
        //                {
        //                    sampleSection1,
        //                    sampleSection2
        //                },
        //            }
        //        }
        //    };


        //    // ACT

        //    using var context = GetAppDbContext.GetInMemoryProvider();
        //    context.Database.EnsureDeleted();
        //    context.Database.EnsureCreated();

        //    context.GovBodies.Add(bodyWritten);
        //    context.SaveChanges();

        //    var query = from g in context.GovBodies
        //                select g;
        //    var bodyRetrieved = query.SingleOrDefault();

        //    // ASSERT

        //    Assert.That(bodyRetrieved, Is.Not.Null);
        //    Assert.That(bodyWritten.IsDeepEqual(bodyRetrieved));
        //}

    }
}
