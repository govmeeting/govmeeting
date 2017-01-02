using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Govmeeting.Backend.Model
{
    /// <summary>
    /// A category of topics discussed at meetings. The categories should be globally meaningful for all
    /// types of government bodies. For example: "health", "environment", "safety"
    /// This is in contrast to topics, which may only have meaning within thecontext of a specific government
    /// body. For example: "Repaving Main Street", "Funds for new sewer plant"
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
