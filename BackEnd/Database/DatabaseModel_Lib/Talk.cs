using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DatabaseModel
{
    /// <summary>
    /// A talk represents the text that was said and the speaker who said it.
    /// </summary>
    public class Talk
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public int Sequence { get; set; }
        public Speaker Speaker { get; set; }
        public long TopicDiscussionId { get; set; }
    }
}
