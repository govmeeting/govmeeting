using Ardalis.GuardClauses;
using GM.Application.AppCore.Entities.Speakers;

namespace GM.Application.AppCore.Entities.Meetings
{
    /// <summary>
    /// A talk represents the text that was said and the speaker who said it.
    /// </summary>
    public class Talk : BaseEntity
    {
        private Talk() { }  // for EF Core

        public Talk(Speaker speaker, string text)
        {
            Speaker = speaker;
            Text = text;

            Guard.Against.Null(speaker, nameof(speaker));
            Guard.Against.NullOrEmpty(text, nameof(text));
        }

        public string Text { get; set; }
        public Speaker Speaker { get; set; }
        public long TopicDiscussionId { get; set; }
        // Sequence of Talks within TopicDiscussion. This is used for
        // re-constructing the transcript.
        public int Sequence { get; set; }   // sequence within TopicDiscussion
    }
}
