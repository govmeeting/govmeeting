using System;
using Ardalis.GuardClauses;

namespace GM.Application.AppCore.Entities.Speakers
{
    /// <summary>
    /// A speaker at a meeting
    /// </summary>
    public class Speaker : BaseEntity
    {
        private Speaker() { }  // for EF

        public Speaker(string name, long meetingId)
        {
            Name = name;
            MeetingId = meetingId;

            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NegativeOrZero(meetingId, nameof(meetingId));
        }
        public string Name { get; set; }
        public long MeetingId { get; set; }
    }
}
