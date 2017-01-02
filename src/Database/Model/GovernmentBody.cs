using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Govmeeting.Backend.Model
{
    /// <summary>
    /// The Government body
    /// </summary>
    public class GovernmentBody
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
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        /// <value>
        /// The county.
        /// </value>
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the municipality.
        /// </summary>
        /// <value>
        /// The municipality.
        /// </value>
        public string Municipality { get; set; }

        /// <summary>
        /// Gets or sets the meetings.
        /// </summary>
        /// <value>
        /// The meetings.
        /// </value>
        public List<Meeting> Meetings { get; set; }

        /// <summary>
        /// Gets or sets the topics.
        /// </summary>
        /// <value>
        /// The topics.
        /// </value>
        public List<Topic> Topics { get; set; }
    }
}
