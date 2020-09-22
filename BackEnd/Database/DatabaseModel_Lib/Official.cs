using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DatabaseModel
{
    /// <summary>
    /// A Government official - works for and acts on the government's behalf,
    /// but is not elected by the citizens.
    /// </summary>
    public class Official
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long GovernmentBodyId { get; set; }
        public bool IsElected { get; set; }
    }
}
