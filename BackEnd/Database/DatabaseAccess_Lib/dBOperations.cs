using System;
using System.Collections.Generic;
using System.Linq;

using GM.DatabaseModel;

namespace GM.DatabaseAccess
{
    public interface IDBOperations
    {
        public void WriteChanges();
        public Meeting GetMeeting(long meetingId);
        public List<Meeting> GetMeetings(int govBodyId);
        public GovBody GetGovBody(long govBodyId);
        public List<GovBody> GetGovBodies();
        public GovLocation GetGovLocation(long govLocationId);
        public List<GovLocation> GetGovLocation();
        public List<Category> GetCategories();
        public List<Topic> GetExistingTopics(long govBodyId);
        public List<TopicDiscussion> GetTopicDiscussions(int meetingId);
        public List<Talk> GetTalks(int topicDiscussionId);
        public long Add(Meeting m);
        public long Add(GovLocation govLocation);
        public long Add(GovBody govBody);
        public List<Meeting> FindMeetings(SourceType? sourceType, WorkStatus? workStatus, bool? approved);
    }




    //public class dBOperations : IDisposable
    public class DBOperations : IDBOperations
    {
        readonly ApplicationDbContext applicationDbContext;

        public DBOperations(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
            //applicationDbContext = new ApplicationDbContext();
        }

        // ////////////// Database //////////////////////////////////

        //public void Dispose()
        //{
        //    applicationDbContext.Dispose();
        //}

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

        //public void DropAndRecreateDb()
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        //Database.SetInitializer(
        //        //    new DropCreateDatabaseAlways<MeetingContext>());

        //        //context.Database.Initialize(force: true);
        //    }
        //}

        public void WriteChanges()
        {
            applicationDbContext.SaveChanges();
        }

        // ////////////// Meeting //////////////////////////////////

        public Meeting GetMeeting(long meetingId)
        {
            Meeting meeting;
            var query = from m in applicationDbContext.Meetings
                        where m.Id == meetingId
                        select m;
            meeting = query.SingleOrDefault();
            return meeting;

        }

        public List<Meeting> GetMeetings(int govBodyId)
        {
            var query = from m in applicationDbContext.Meetings
                        where m.GovBodyId == govBodyId
                        select m;
            return query.ToList();
        }

        public long Add(Meeting m)
        {
            // TODO - Implement
            return 0;
        }

        public long Add(GovLocation govLocation)
        {
            // TODO - Implement
            return 0;
        }

        public long Add(GovBody govBody)
        {
            // TODO - Implement
            return 0;
        }

        public List<Meeting> FindMeetings(SourceType? sourceType, WorkStatus? workStatus, bool? approved)
        {
            // TODO - Implement
            return new List<Meeting>();
        }


        // ////////////// GovBody //////////////////////////////////

        public GovBody GetGovBody(long govBodyId)
        {
            GovBody gBody;
            var query = from g in applicationDbContext.GovBodies
                        where g.Id == govBodyId
                        select g;
            gBody = query.SingleOrDefault();
            return gBody;
        }

        public List<GovBody> GetGovBodies()
        {
            return applicationDbContext.GovBodies.ToList();
        }


        // ////////////// GovLocation //////////////////////////////////

        public GovLocation GetGovLocation(long govLocationId)
        {
            GovLocation govLocation;
            var query = from g in applicationDbContext.GovLocations
                        where g.Id == govLocationId
                        select g;
            govLocation = query.SingleOrDefault();
            return govLocation;
        }

        public List<GovLocation> GetGovLocation()
        {
            return applicationDbContext.GovLocations.ToList();
        }

        // ////////////// Topic & Category //////////////////////////////////

        public List<Category> GetCategories()
        {
            return applicationDbContext.Categories.ToList();
            // return new List<Category>();
        }

        public List<Topic> GetExistingTopics(long govBodyId)
        {
            var query = from t in applicationDbContext.Topics
                        where t.GovernmentBodyId == govBodyId
                        select t;
            return query.ToList();
        }

        // ////////////// TopicDiscusion //////////////////////////////////

        public List<TopicDiscussion> GetTopicDiscussions(int meetingId)
        {
            var query = from td in applicationDbContext.TopicDiscussions
                        where td.Id == meetingId
                        select td;
            return query.ToList();
        }

        public List<Talk> GetTalks(int topicDiscussionId)
        {
            var query = from t in applicationDbContext.Talks
                        where t.TopicDiscussionId == topicDiscussionId
                        select t;
            return query.ToList();
        }

        // ////////////// Speaker //////////////////////////////////

        /* TODO complete method to get speakers at meeting.
        public List<Speaker> GetSpeakers(int meetingId)
        {
            //var query = from td in meetingContext.TopicDiscussions
            //            where td.Id == meetingId
            return query.ToList();
        }
        */
    }
}
