using System;
using System.Collections.Generic;

namespace GM.DatabaseModel
{
    /// <summary>
    /// The Government body .. Senate, Lower Houese, Council etc.
    /// </summary>
    public class GovBody
    {
        public long Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        ///  All GovBodies have a GovLocation as a parent
        /// </summary>
        public long GovLocationId { get; set; }
        
        public List<Meeting> Meetings { get; set; }

        public List<Topic> Topics { get; set; }

        public List<ScheduledMeeting> ScheduledMeetings { get; set; }

        public GovBody()
        {
        }
        public GovBody(string name, int locationId)
        {
            Name = name;
            GovLocationId = locationId;
         }

    }
}
