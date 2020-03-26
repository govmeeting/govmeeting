using System;
using System.IO;
using Microsoft.Extensions.Options;
using GM.Configuration;

namespace GM.Workflow
{
    public class RetrieveOnlineFiles
    {
        // TODO - IMPLEMENT THIS CLASS
        
        /* RetrieveOnlineFiles will:
         * Read the meeting schedules for all government bodies in the database.
         * 1. If a current meeting may have taken place, it will:
         *    Check the website where either its transcript or a recording may be found.
         *    If found it will:
         * 2. Create a "meeting" record in the database for this meeting and set the WorkStatus field to "Retrieving".
         * 3. Start the file retrieval.
         * 4. Store the retieved file in the "Datafiles/RECEIVED" folder.
         * 5. Set the Workstatus on the meeting record to "Retrieved".
         * Repeat for each government body.
         *
         *  Files can also be placed in the RECEIVED folder by the phone app for recording a meeting.
         *  Files that are uploaded by a registered user are also placed in the RECEIVED folder.
         */

        AppSettings _config;

        public RetrieveOnlineFiles(
           IOptions<AppSettings> config
        )
        {
            _config = config.Value;
        }
       public void Run()
        {
        }
    }
}
