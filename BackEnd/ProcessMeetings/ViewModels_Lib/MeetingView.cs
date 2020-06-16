using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM.ViewModels
{
    /* The model of the meeting data for the JSON
     * data is different from that of the database
     * model. The types "TopicDiscussion", "Talk" &
     * "Meeting" are also defined in the database model.
     */


    public class ViewtranscriptView
    {
        public MeetingForView meeting { get; set; }
        public string[] topicNames { get; set; }
        public string[] speakerNames { get; set; }
        public TopicdiscussionForView[] topicDiscussions { get; set; }
    }

    public class TopicdiscussionForView
    {
        public string name { get; set; }
        public TalkForView[] talks { get; set; }
    }

    public class TalkForView
    {
        public string Speaker { get; set; }
        public string Text { get; set; }
    }

    public class MeetingForView
    {
        public long meetingId { get; set; }
        public long locationId { get; set; }
        public string governmentBody { get; set; }
        public string language { get; set; }
        public string date { get; set; }
        public int meetingLength { get; set; }

    }
}
