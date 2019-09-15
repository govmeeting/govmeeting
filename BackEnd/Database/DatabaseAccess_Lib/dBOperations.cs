using System;
using System.Collections.Generic;
using System.Linq;

using GM.DatabaseModel;

namespace GM.DatabaseAccess
{
    /// <summary>
    /// Routines for accessing the database
    /// </summary>
    public class dBOperations : IDisposable
    {
        /// <summary>
        /// The meeting context
        /// </summary>
        ApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="dBOperations" /> class.
        /// </summary>
        public dBOperations()
        {
            applicationDbContext = new ApplicationDbContext();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            applicationDbContext.Dispose();
        }

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

        public GovernmentBody GetGovernmentBody(long governmentBodyId)
        {
            GovernmentBody gBody;
            var query = from g in applicationDbContext.GovernmentBodies
                        where g.Id == governmentBodyId
                        select g;
            gBody = query.SingleOrDefault();
            return gBody;
        }

        /// <summary>
        /// Gets the existing government bodies.
        /// </summary>
        /// <returns>list of government bodies</returns>
        public List<GovernmentBody> GetGovernmentBodies()
        {
            return applicationDbContext.GovernmentBodies.ToList();
        }

        /// <summary>
        /// Gets an existing government body if it is in the database.
        /// Otherwise it add the one that is passed
        /// </summary>
        /// <param name="govBody">The gov body.</param>
        /// <returns>existing government body already exists in the database, return that one. Otherwise
        /// return null so that call will use the one that was passed to this routine.</returns>
        public GovernmentBody GetOrAddGovernmentBody(GovernmentBody govBody)
        {
            GovernmentBody gBody = GetExistingBody(govBody);

            // If the government body is already in the database, use it.
            if (gBody != null)
            {
                return gBody;
            }
            else
            {
                // Otherwise add the new one that the caller created.
                // Create an empty meeting list.
                govBody.Meetings = new List<Meeting>();
                applicationDbContext.GovernmentBodies.Add(govBody);
                return null;
            }
        }

        /// <summary>
        /// Gets an existing government body in the database.
        /// </summary>
        /// <param name="govBody">The gov body.</param>
        /// <returns>existing government body or null.</returns>
        public GovernmentBody GetExistingBody(GovernmentBody govBody)
        {
            GovernmentBody gBody;
            var query = from g in applicationDbContext.GovernmentBodies
                        where g.Name == govBody.Name
                        && g.Country == govBody.Country
                        && g.State == govBody.State
                        && g.County == govBody.County
                        && govBody.Municipality == govBody.Municipality
                        select g;
            gBody = query.SingleOrDefault();
            return gBody;
        }

        /// <summary>
        /// Gets the meetings for a specified government body.
        /// </summary>
        /// <param name="govBodyId">The government body identifier.</param>
        /// <returns></returns>
        public List<Meeting> GetMeetings(int govBodyId)
        {
            var query = from m in applicationDbContext.Meetings
                        where m.GovernmentBodyId == govBodyId
                        select m;
            return query.ToList();
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
        public List<Topic> GetExistingTopics(int govBodyId)
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
