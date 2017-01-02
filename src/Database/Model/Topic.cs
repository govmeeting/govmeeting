using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Govmeeting.Backend.Model
{
    /// <summary>
    /// A topic of discussion
    /// </summary>
    public class Topic
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the topic discussions.
        /// </summary>
        /// <value>
        /// The topic discussions.
        /// </value>
        public List<TopicDiscussion> TopicDiscussions { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to government body.
        /// </summary>
        /// <value>
        /// The government body identifier.
        /// </value>
        public int GovernmentBodyId { get; set; }
    }
}
