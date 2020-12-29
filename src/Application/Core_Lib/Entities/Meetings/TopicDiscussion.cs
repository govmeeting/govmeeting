using Ardalis.GuardClauses;
using GM.Application.AppCore.Entities.Topics;
using System.Collections.Generic;

namespace GM.Application.AppCore.Entities.Meetings
{
    public class TopicDiscussion : BaseEntity
    {
        private TopicDiscussion() { }  // for EF

        public TopicDiscussion(Topic topic, long sectionId) 
        {
            Topic = topic;
            SectionId = sectionId;

            Guard.Against.Null(topic, nameof(topic));
            Guard.Against.NegativeOrZero(sectionId, nameof(sectionId));
        }

        public Topic Topic { get; set; }
        public long SectionId { get; set; }

        // Sequence of TopicDiscussion within Section. Used for re-constructing the transcript
        public int Sequence { get; set; }

        private readonly List<Talk> _talks = new List<Talk>();
        public IReadOnlyCollection<Talk> Talks => _talks.AsReadOnly();
    }
}
