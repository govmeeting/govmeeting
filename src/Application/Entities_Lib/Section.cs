using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DatabaseModel
{
    public class Section
    {
        public Section()
        {
            CreateCollections();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public long MeetingId { get; set; }
        // Sequence of Section within Meeting. This is used for
        // re-constructing the transcript
        public int Sequence { get; set; }    // sequence within Meeting
        // TopicDiscussions is a convenience property. It's not part of the
        // DB table but is useful when re-constructing the transcript
        public List<TopicDiscussion> TopicDiscussions { get; private set; }
        private void CreateCollections()
        {
            TopicDiscussions = new List<TopicDiscussion>();
        }
    }
}
