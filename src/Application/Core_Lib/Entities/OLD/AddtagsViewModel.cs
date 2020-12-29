using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM.OldViewModels
{
    /* These classes are used in the browser AddTags module for adding
     * tags to the transcript. Each time a new speaker says something
     * the topic of discussion and meeting section may change.
     * If the value is null for either, it means that it did not change.
     */

    public class AddtagsViewModel
    {
        public List<string> sections { get; set; }
        public List<string> topics { get; set; }
        public List<TalksView> talks { get; set; }
    }

    public class TalksView
    {
        public string speaker;     // speaker name
        public string said;        // what they said
        public string section;     // section name - if this is the start of a new section
        public string topic;       // topic name - if this is the start of a new topic
        public bool showSetTopic;  // (This is used by the talks.component in the browser) 
    }

}
