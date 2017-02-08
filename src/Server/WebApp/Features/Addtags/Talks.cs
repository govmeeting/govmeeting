using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    /* This class is used in the browser AddTags module for adding
     * tags to the transcript. Each time a new speaker says something
     * the topic of discussion, meeting section, etc. may change.
     */
    public class Talks
    {
        public string speaker;     // speaker name
        public string said;        // what they said
        public string section;     // section name - if this is the start of a new section
        public string topic;       // topic name - if this is the start of a new topic
        public bool showSetTopic;  // (This is used by the talks.component in the browser) 
    }
}
