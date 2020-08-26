using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DatabaseModel
{
    public class Section
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<TopicDiscussion> TopicDiscussions { get; set; }
    }
}
