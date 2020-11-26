using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;


namespace GM.DatabaseModel
{
    /// <summary>
    /// The Government body .. Senate, Lower House, Council etc.
    /// </summary>
    public class GovBody : BaseEntity, IAggregateRoot
    {
        private GovBody() { }  // for EF

        public GovBody(string name, int locationId, int id)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.Null(locationId, nameof(locationId));

            Name = name;
            GovLocationId = locationId;

            Id = id;  // TODO - this is a kludge to get a test working
        }

        public override int Id { get; protected set; }

        public string Name { get; set; }

        // The "LongName" consists of the names of its GovLocation ancestors and itself, separated by "_".
        // This could be built by traversing its ancestors, but for convenience, it's a property.
        // Example: "USA_NJ_Essex_Nutley_TownCouncil"
        public string LongName { get; set; }

        public long GovLocationId { get; set; }

        private readonly List<Meeting> _meetings = new List<Meeting>();
        public IReadOnlyCollection<Meeting> Meetings => _meetings.AsReadOnly();

        private readonly List<Meeting> _topics = new List<Meeting>();
        public IReadOnlyCollection<Meeting> Topics => _topics.AsReadOnly();

        private readonly List<ScheduledMeeting> _scheduledMeetings = new List<ScheduledMeeting>();
        public IReadOnlyCollection<ScheduledMeeting> ScheduledMeetings => _scheduledMeetings.AsReadOnly();


        public void AddScheduledMeeting(ScheduledMeeting sm)
        {
            _scheduledMeetings.Add(sm);
        }

        //public List<Meeting> Meetings { get; private set; }
        //public List<Topic> Topics { get; private set; }
        //public List<ScheduledMeeting> ScheduledMeetings { get; private set; }
        //private void CreateCollections()
        //{
        //    Meetings = new List<Meeting>();
        //    Topics = new List<Topic>();
        //    ScheduledMeetings = new List<ScheduledMeeting>();
        //}
    }
}
