using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DatabaseModel
{
    public class TopicDiscussion
    {
        public TopicDiscussion()
        {
            CreateCollections();
        }
        public long Id { get; set; }
        public Topic Topic { get; set; }
        public long SectionId { get; set; }
        // Sequence of TopicDiscussion within Section. This is used for
        // re-constructing the transcript
        public int Sequence { get; set; }    // sequence within Section
        // Talks is a convenience property. It's not part of the
        // DB table but is useful when re-constructing the transcript
        public List<Talk> Talks { get; private set; }
        private void CreateCollections()
        {
            Talks = new List<Talk>();
        }
    }
}
