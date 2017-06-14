using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Meeting
    {
        public Meetinginfo meetingInfo { get; set; }
        public string[] topicNames { get; set; }
        public string[] speakerNames { get; set; }
        public Topicdiscussion[] topicDiscussions { get; set; }
    }

    public class Meetinginfo
    {
        public string name { get; set; }
        public string date { get; set; }
    }

    public class Topicdiscussion
    {
        public string name { get; set; }
        public Speaker[] speakers { get; set; }
    }

    public class Speaker
    {
        public string name { get; set; }
        public string text { get; set; }
    }


}
