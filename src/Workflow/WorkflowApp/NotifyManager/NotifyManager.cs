using System;
using System.IO;
using Microsoft.Extensions.Options;
using GM.Application.Configuration;

namespace GM.WorkflowApp
{

    /* Notify manager if action approval is needed to proceed with workflow.
    * The manager(s) are notified:
    *    If there are new files in the RECEIVED folder.
    *    If proofreading is completed on a transcribed transctipt
    *    If adding of tags is completed on a transcript
    * This component will send a message to the manager(s) via email or text based on
    * their preferences. The manager can then log in and
    * review the content of the files or completed work.
    * If indicated that it is valid, the next step in the process will be activated. 
    */

    public class NotifyManager : INotifyManager
    {
        // TODO - IMPLEMENT THIS CLASS
        
        /*
         *
         */

        AppSettings _config;

        public NotifyManager(
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
