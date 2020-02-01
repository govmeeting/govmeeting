using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GM.DatabaseModel;
using GM.DatabaseAccess;
using GM.ViewModels;
using Microsoft.Extensions.Options;
using GM.Configuration;

/*    This is old code that needs to be re-done. Originally, the format of the transcript file
 *    that was being read and loaded into the database was in a different format.
 */

namespace GM.LoadDatabase
{
    /// <summary>
    /// load and parse a trancript into memory and write the data to the database.
    /// </summary>
    public class LoadTranscript
    {
        private readonly AppSettings _config;
        private dBOperations dbOps;

        public LoadTranscript(
            IOptions<AppSettings> config,
            dBOperations _dbOps
            )
        {
            _config = config.Value;
            dbOps = _dbOps;
        }

        // This method would load transcripts for which the Addtags processing has completed.
        public void Run()
        {
            // For now we will use a single test transcript.
            AddtagsView addtags = new AddtagsView(); 

        }

        /// <summary>
        /// Call methods on the ReadTranscriptFile object in the correct sequence to read and parse the data.
        /// When reading and parsing is complete, write the data to the database.
        /// </summary>
        /// <param name="readTranscript">The load transcript.</param>
        public void LoadAndSave(ReadTranscriptFile readTranscript)
        {
            //using (dBOperations dbOps = new dBOperations())
            //{
                List<Category> categories = dbOps.GetCategories();

                // Get the governent body info from the transcipt header
                GovernmentBody govBody = readTranscript.LoadHeadingInfo();
                if (govBody != null)
                {
                    GovernmentBody gBody;
                    List<Topic> topics;
                    // See if that government body already exists in the database
                    // If it is present, get the existing topics
                    if ((gBody = dbOps.GetOrAddGovernmentBody(govBody)) != null)
                    {
                        topics = dbOps.GetExistingTopics(govBody.Id);
                    }
                    // otherwise create a new empty list of topics
                    else
                    {
                        topics = new List<Topic>();
                    }

                    // Add new topics from new transcript to the topic list

                    // Get the meeting body info from the transcript
                    Meeting meeting = readTranscript.LoadMeetingData(categories, topics);
                    if (meeting != null)
                    {
                        // Add the meeting to the database
                        govBody.Meetings.Add(meeting);
                    }

                    dbOps.WriteChanges();

            }
            //}
        }
    }
}
