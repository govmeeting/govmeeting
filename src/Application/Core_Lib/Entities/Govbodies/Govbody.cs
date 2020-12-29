using Ardalis.GuardClauses;
using GM.Application.AppCore.Entities.GovLocations;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.AppCore.Entities.Topics;
using GM.Application.AppCore.Interfaces;
using System;
using System.Collections.Generic;

namespace GM.Application.AppCore.Entities.Govbodies
{
    /// <summary>
    /// The Government body .. Senate, Lower House, Council etc.
    /// </summary>
    public class Govbody : AuditEntity, IAggregateRoot
    {
        private Govbody() { }  // for EF

        public Govbody(string name, GovLocation parentLocation, int id = 0)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.Null(parentLocation, nameof(parentLocation));

            Name = name;
            ParentLocation = parentLocation;

            Id = id;  // TODO - Remove this kludge to get a test working
        }

        public override int Id { get; protected set; }

        public string Name { get; set; }

        // "LongName" consists of the names of its GovLocation ancestors and itself, separated by "_".
        // This could be built by traversing its ancestors, but for convenience, it's a property.
        // Example: "USA_NJ_Essex_Nutley_TownCouncil"
        public string LongName { get; set; }

        public GovLocation ParentLocation { get; set; }

        private readonly List<Meeting> _meetings = new List<Meeting>();
        public IReadOnlyCollection<Meeting> Meetings => _meetings.AsReadOnly();

        private readonly List<Topic> _topics = new List<Topic>();
        public IReadOnlyCollection<Topic> Topics => _topics.AsReadOnly();

        private readonly List<ScheduledMeeting> _scheduledMeetings = new List<ScheduledMeeting>();
        public IReadOnlyCollection<ScheduledMeeting> ScheduledMeetings => _scheduledMeetings.AsReadOnly();


        public void AddMeeting(
            string name,
            DateTime dateTime,
            string language,
            SourceType sourceType,
            string sourceFileName)
        {
            _meetings.Add(new Meeting(dateTime, sourceType, sourceFileName, name, language));
        }

        public void AddScheduledMeeting(ScheduledMeeting sm)
        {
            _scheduledMeetings.Add(sm);
        }
    }
}
