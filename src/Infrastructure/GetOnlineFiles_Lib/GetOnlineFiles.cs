using System;
using GM.ApplicationCore.Entities.Govbodies;
using GM.ApplicationCore.Entities.Meetings;

namespace GM.GetOnlineFiles
{

    /* This is a placeholder for code to be written for retrieving transcripts or recordings from a remote site.
     * It will be called from WorkflowApp.
     * It will call lower level routines in the OnlineAccess component.
     */

    public interface IRetrieveNewFiles
    {
        public string RetrieveFile(Govbody govbody, DateTime scheduled, out DateTime actual, out SourceType type);
    }

    public class RetrieveNewFiles : IRetrieveNewFiles
    {
        public string RetrieveFile(Govbody govbody, DateTime scheduled, out DateTime actual, out SourceType type)
        {
            // TODO - implement
            actual = DateTime.Now;
            type = SourceType.Recording;
            return "";
        }
    }
}


/*
* Navigate to the start page for Austin City Council transcripts:
* https://www.austintexas.gov/department/city-council/council/council_meeting_info_center.htm
* Under "Recent Meetings", find the most recent. 
* Save the text on that line and navigate to the "Meeting Details" link on that line.
* Search for "Closed Caption Transcript" and download the document: "Transcript,  xxxkb"
*
*
*
*
*
*/