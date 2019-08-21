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

        public LoadTranscript(
            IOptions<AppSettings> config
            )
        {
            _config = config.Value;
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
