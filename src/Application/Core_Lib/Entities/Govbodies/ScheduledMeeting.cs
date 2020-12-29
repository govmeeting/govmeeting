using Ardalis.GuardClauses;
using System;

namespace GM.Application.AppCore.Entities.Govbodies
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
