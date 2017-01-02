using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Govmeeting.Backend.Model
{
    /// <summary>
    /// The meeting object is all the data associated with one specific meeting.
    /// </summary>
    public class Meeting
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
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the topic discussions.
        /// </summary>
        /// <value>
        /// The topic discussions.
        /// </value>
        public List<TopicDiscussion> TopicDiscussions { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to containing government entity.
        /// </summary>
        /// <value>
        /// The government body identifier.
        /// </value>
        public int GovernmentBodyId { get; set; }

        /*
         * If we were to say: public virtual List<Talk> ....
         * then EF would lazy load these as they are accessed.
         */
    }
}
