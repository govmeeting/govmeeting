using System;
using System.Collections.Generic;
using System.Linq;

using GM.DatabaseModel;

namespace GM.DatabaseAccess
{
    /// <summary>
    /// Routines for accessing the database
    /// </summary>
    //public class dBOperations : IDisposable
    public class DBOperations
    {
        /// <summary>
        /// The meeting context
        /// </summary>
        readonly ApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBOperations" /> class.
        /// </summary>
        public DBOperations(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
            //applicationDbContext = new ApplicationDbContext();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        //public void Dispose()
        //{
        //    applicationDbContext.Dispose();
        //}

        /// <summary>
        /// Create the database.
        /// </summary>
        //public static void InitializeDb()
        //{
        //    using (var context = new ApplicationDbContext())
        //    {

        //        /* 
        //         * We are using Entity Framework code-first to create the database.
        //         * The Model classes within the Model project are simple POCO classes with just property definitions
        //         * with no reference to E.F..
        //         * The MeetingContext class within the DbAcess project contains the DbSet definitions.
        //         */

        //        // The following single line of procedural code is all that is needed to create the database.
        //        //context.Database.Initialize(force: false);
        //    }
        //}

        /// <summary>
        /// Drop and recreate the database.
        /// </summary>
        //public void DropAndRecreateDb()
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        //Database.SetInitializer(
        //        //    new DropCreateDatabaseAlways<MeetingContext>());

        //        //context.Database.Initialize(force: true);
        //    }
        //}
        /// <summary>
        /// Writes the changes to the database.
        /// </summary>
        public void WriteChanges()
        {
            applicationDbContext.SaveChanges();
        }

        public Meeting GetMeeting(long meetingId)
        {
            Meeting meeting;
            var query = from m in applicationDbContext.Meetings
                        where m.Id == meetingId
                        select m;
            meeting = query.SingleOrDefault();
            return meeting;

        }

        public GovBody GetGovBody(long govBodyId)
        {
            GovBody gBody;
            var query = from g in applicationDbContext.GovBodies
                        where g.Id == govBodyId
                        select g;
            gBody = query.SingleOrDefault();
            return gBody;
        }

        /// <summary>
        /// Gets the existing government bodies.
        /// </summary>
        /// <returns>list of government bodies</returns>
        public List<GovBody> GetGovBodies()
        {
            return applicationDbContext.GovBodies.ToList();
        }


        /// <summary>
        /// Gets the meetings for a specified government body.
        /// </summary>
        /// <param name="govBodyId">The government body identifier.</param>
        /// <returns></returns>
        public List<Meeting> GetMeetings(int govBodyId)
        {
            var query = from m in applicationDbContext.Meetings
                        where m.GovBodyId == govBodyId
                        select m;
            return query.ToList();
        }


        public GovLocation GetGovLocation(long govLocationId)
        {
            GovLocation govLocation;
            var query = from g in applicationDbContext.GovLocations
                        where g.Id == govLocationId
                        select g;
            govLocation = query.SingleOrDefault();
            return govLocation;
        }

        /// <summary>
        /// Gets the existing government locations.
        /// </summary>
        /// <returns>list of government locations</returns>
        public List<GovLocation> GetGovLocation()
        {
            return applicationDbContext.GovLocations.ToList();
        }


        /// <summary>
        /// Gets the existing categories.
        /// </summary>
        /// <returns>list of existing categories</returns>
        public List<Category> GetCategories()
        {
            return applicationDbContext.Categories.ToList();
            // return new List<Category>();
        }

        /// <summary>
        /// Gets existing topics for a specific govenrment body.
        /// </summary>
        /// <param name="govBodyId">The gov body identifier.</param>
        /// <returns>existing topics associated with specific govenrment body.</returns>
        public List<Topic> GetExistingTopics(long govBodyId)
        {
            var query = from t in applicationDbContext.Topics
                        where t.GovernmentBodyId == govBodyId
                        select t;
            return query.ToList();
        }

        /// <summary>
        /// Gets the topic discussions at a specific meeting.
        /// </summary>
        /// <param name="meetingId">The meeting identifier.</param>
        /// <returns></returns>
        public List<TopicDiscussion> GetTopicDiscussions(int meetingId)
        {
            var query = from td in applicationDbContext.TopicDiscussions
                        where td.Id == meetingId
                        select td;
            return query.ToList();
        }

        /// <summary>
        /// Gets the talks on a specific topic discussion.
        /// </summary>
        /// <param name="topicDiscussionId">The topic discussion identifier.</param>
        /// <returns></returns>
        public List<Talk> GetTalks(int topicDiscussionId)
        {
            var query = from t in applicationDbContext.Talks
                        where t.TopicDiscussionId == topicDiscussionId
                        select t;
            return query.ToList();
        }

        /* TODO complete method to get speakers at meeting.
        /// <summary>
        /// Gets the speakers at a specific meeting.
        /// </summary>
        /// <param name="meetingId">The meeting identifier.</param>
        /// <returns></returns>
        public List<Speaker> GetSpeakers(int meetingId)
        {
            //var query = from td in meetingContext.TopicDiscussions
            //            where td.Id == meetingId
            return query.ToList();
        }
        */
    }
}
