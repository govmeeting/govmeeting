using System;
using System.Collections.Generic;

namespace GM.DatabaseModel
{
    /// <summary>
    /// The Government body .. Senate, Lower Houese, Council etc.
    /// </summary>
    public class GovBody
    {
        public GovBody()
        {
            CreateCollections();
        }
        public GovBody(string name, int locationId)
        {
            Name = name;
            GovLocationId = locationId;
            CreateCollections();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        // The "LongName" consists of the names of its GovLocation ancestors and itself, separated by "_".
        // This could be built by traversing its ancestors, but for convenience, it's a property.
        // Example: "USA_NJ_Essex_Nutley_TownCouncil"
        public string LongName { get; set; }
        /// <summary>
        ///  All GovBodies have a GovLocation as a parent
        /// </summary>
        public long GovLocationId { get; set; }
        public List<Meeting> Meetings { get; private set; }
        public List<Topic> Topics { get; private set; }
        public List<ScheduledMeeting> ScheduledMeetings { get; private set; }
        private void CreateCollections()
        {
            Meetings = new List<Meeting>();
            Topics = new List<Topic>();
            ScheduledMeetings = new List<ScheduledMeeting>();
        }
    }
}
