using System;
using Ardalis.GuardClauses;

namespace GM.ApplicationCore.Entities.Meetings
{
    public class ScheduledMeeting : BaseEntity
    {
        private ScheduledMeeting() { }  // for EF

        public ScheduledMeeting(DateTime dateTime)
        {
            Date = dateTime;

            Guard.Against.Null(dateTime, nameof(dateTime));
        }

        public DateTime Date { get; set; }
    }
}
