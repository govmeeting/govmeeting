using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Govmeeting.Backend.Model
{
    /// <summary>
    /// A topic at a meeting and the list of talks associated with it.
    /// </summary>
    public class TopicDiscussion
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        /// <value>
        /// The topic.
        /// </value>
        public Topic Topic { get; set; }

        /// <summary>
        /// Gets or sets the talks.
        /// </summary>
        /// <value>
        /// The talks.
        /// </value>
        public List<Talk> Talks { get; set; }

        /// <summary>
        /// Gets or sets the sequence number withiing context of meeting.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to containing meeting.
        /// </summary>
        /// <value>
        /// The meeting identifier.
        /// </value>
        public int MeetingId { get; set; } 
    }
}
