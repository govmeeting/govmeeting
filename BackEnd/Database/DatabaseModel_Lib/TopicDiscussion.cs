using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DatabaseModel
{
    public class TopicDiscussion
    {
        public long Id { get; set; }
        public Topic Topic { get; set; }
        public List<Talk> Talks { get; set; }
        public int Sequence { get; set; }
        public long MeetingId { get; set; } 
    }
}
