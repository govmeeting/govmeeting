using Ardalis.GuardClauses;
using System.Collections.Generic;

namespace GM.Application.AppCore.Entities.Meetings
{
    public class Section : BaseEntity
    {
        private Section() { }  // for EF

        public Section(string name)
        {
            Name = name;

            Guard.Against.NullOrEmpty(name, nameof(name));
        }
        public string Name { get; set; }
        public long MeetingId { get; set; }
        // Sequence of Section within Meeting. Used for re-constructing the transcript
        public int Sequence { get; set; }

        private readonly List<TopicDiscussion> _topicDiscussions = new List<TopicDiscussion>();
        public IReadOnlyCollection<TopicDiscussion> TopicDiscussions => _topicDiscussions.AsReadOnly();
    }
}
