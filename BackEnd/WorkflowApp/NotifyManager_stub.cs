using System;
using System.IO;
using Microsoft.Extensions.Options;
using GM.Configuration;

namespace GM.Workflow
{

    /* Notify manager if action approval is needed to proceed with workflow.
     * THis stub will proceed without approval.
    */

    public class NotifyManager_Stub : INotifyManager
    {
        // TODO - IMPLEMENT THIS CLASS
        
        /*
         *
         */

        AppSettings _config;

        public NotifyManager_Stub(
           IOptions<AppSettings> config
        )
        {
            _config = config.Value;
        }
       public void Run()
        {
            // Check if any new files received.
        }
    }
}
