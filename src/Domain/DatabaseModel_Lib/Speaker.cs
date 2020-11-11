using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DatabaseModel
{
    /// <summary>
    /// A speaker at a meeting
    /// </summary>
    public class Speaker
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long MeetingId { get; set; }
    }
}
