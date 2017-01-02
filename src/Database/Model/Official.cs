using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Govmeeting.Backend.Model
{
    /// <summary>
    /// A Government official - works for and acts on the government's behalf,
    /// but is not elected by the citizens.
    /// </summary>
    public class Official : Speaker
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to containing government entity.
        /// </summary>
        /// <value>
        /// The government body identifier.
        /// </value>
        public int GovernmentBodyId { get; set; }
    }
}
