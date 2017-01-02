using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Govmeeting.Backend.Model
{
    /// <summary>
    /// A talk represents the text that was said and the speaker who said it.
    /// </summary>
    public class Talk
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the sequence number withiing context of topic.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the speaker.
        /// </summary>
        /// <value>
        /// The speaker.
        /// </value>
        public Speaker Speaker { get; set; }

        /// <summary>
        /// Gets or sets the speaker identifier.
        /// </summary>
        /// <value>
        /// The speaker identifier.
        /// </value>
        public int SpeakerId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to containing topic.
        /// </summary>
        /// <value>
        /// The topic discussion identifier.
        /// </value>
        public int TopicDiscussionId { get; set; }
    }
}
