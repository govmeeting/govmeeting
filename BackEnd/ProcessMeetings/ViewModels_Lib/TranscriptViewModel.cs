using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM.ViewModels
{
    public class TranscriptViewModel
    {
        public MeetingViewModel meeting { get; set; }
        public string[] topicNames { get; set; }
        public string[] speakerNames { get; set; }
        public TopicdiscussionViewModel[] topicDiscussions { get; set; }
    }

    public class TopicdiscussionViewModel
    {
        public string name { get; set; }
        public TalkViewModel[] talks { get; set; }
    }

    public class TalkViewModel
    {
        public string Speaker { get; set; }
        public string Text { get; set; }
    }

    public class MeetingViewModel
    {
        public long meetingId { get; set; }
        public long locationId { get; set; }
        public string governmentBody { get; set; }
        public string language { get; set; }
        public string date { get; set; }
        public int meetingLength { get; set; }

    }
}
