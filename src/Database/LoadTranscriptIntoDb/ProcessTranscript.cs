using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Govmeeting.Backend.Model;
using Govmeeting.Backend.ReadTranscript;
using Govmeeting.Backend.DbAccess;

namespace Govmeeting.Backend.LoadTranscriptIntoDb
{
    /// <summary>
    /// load and parse a trancript into memory and write the data to the database.
    /// </summary>
    public class ProcessTranscript
    {
        /// <summary>
        /// Call methods on the ReadTranscriptFile object in the correct sequence to read and parse the data.
        /// When reading and parsing is complete, write the data to the database.
        /// </summary>
        /// <param name="readTranscript">The load transcript.</param>
        public void LoadAndSave(ReadTranscriptFile readTranscript)
        {
            using (dBOperations dbOps = new dBOperations())
            {
                List<Category> categories = dbOps.GetCategories();

                GovernmentBody govBody = readTranscript.LoadHeadingInfo();
                if (govBody != null)
                {
                    GovernmentBody gBody = null;
                    List<Topic> topics;
                    if ((gBody = dbOps.GetOrAddGovernmentBody(govBody)) != null)
                    {
                        topics = dbOps.GetExistingTopics(govBody.Id);
                    }
                    else
                    {
                        topics = new List<Topic>();
                    }
                    Meeting meeting = readTranscript.LoadMeetingData(categories, topics);
                    if (meeting != null)
                    {
                        govBody.Meetings.Add(meeting);
                        dbOps.WriteChanges();
                    }
                }
            }
        }
    }
}
