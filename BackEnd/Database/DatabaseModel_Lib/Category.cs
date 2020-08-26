using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DatabaseModel
{
    /// <summary>
    /// A category of topics discussed at meetings. The categories should be globally meaningful for all
    /// types of government bodies. For example: "health", "environment", "safety"
    /// This is in contrast to topics, which may only have meaning within thecontext of a specific government
    /// body. For example: "Repaving Main Street", "Funds for new sewer plant"
    /// </summary>
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
