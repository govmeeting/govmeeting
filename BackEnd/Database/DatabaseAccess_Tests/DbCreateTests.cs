﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using GM.DatabaseModel;
using GM.DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using DeepEqual;
using DeepEqual.Syntax;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Data.Sqlite;

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
            using var context = GetAppDbContext_InMemoryProvider();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.GovernmentBodies.Add(bodyWritten);
            context.SaveChanges();

            // ASSERT

            var query = from g in context.GovernmentBodies
                        select g;
            var bodyRetrieved = query.SingleOrDefault();

            Assert.That(bodyRetrieved, Is.Not.Null);
            Assert.That(bodyWritten.IsDeepEqual(bodyRetrieved));
        }

        /// <summary>
        /// Creates the one gov body and meeting test.
        /// </summary>
        [Test()]
        public void Backend_DbAccess_CreateOneGovBodyAndMeetingTest()
        {
            // ARRANGE

            GovernmentBody bodyWritten = new GovernmentBody()
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

            using var context = GetAppDbContext_InMemoryProvider();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.GovernmentBodies.Add(bodyWritten);
            context.SaveChanges();

            var query = from g in context.GovernmentBodies
                        select g;
            var bodyRetrieved = query.SingleOrDefault();

            // ASSERT

            Assert.That(bodyRetrieved, Is.Not.Null);
            Assert.That(bodyWritten.IsDeepEqual(bodyRetrieved));
        }

        public ApplicationDbContext GetAppDbContext_LocalDb()
        {
            string connection = "Server=(localdb)\\mssqllocaldb;Database=GovmeetingTest;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connection);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }

        public ApplicationDbContext GetAppDbContext_InMemoryProvider()
        {
            InMemoryDatabaseRoot databaseRoot = new InMemoryDatabaseRoot();
            string connectionString = Guid.NewGuid().ToString();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(connectionString, databaseRoot);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }

        public ApplicationDbContext GetAppDbContext_InMemorySqliteProvider()
        {
            string connectionString = "DataSource=:memory:";
            SqliteConnection connection;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            connection = new SqliteConnection(connectionString);
            connection.Open();
            optionsBuilder.UseSqlite(connection);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }

        public ApplicationDbContext GetAppDbContext_SqliteProvider()
        {
            string connectionString = $"DataSource={Guid.NewGuid()}.db";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite(connectionString);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }


        // SAMPLE DATA //

        private readonly TopicDiscussion sampleDiscussion1 = new TopicDiscussion()
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
        readonly TopicDiscussion sampleDiscussion2 = new TopicDiscussion()
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
