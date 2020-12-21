using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Bogus;
using Bogus.DataSets;

using GM.ApplicationCore.Entities.Govbodies;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.MeetingsDto;
using GM.ApplicationCore.Entities.Speakers;
using GM.ApplicationCore.Entities.Topics;

namespace FakeData
{
    //public class Section
    //{
    //    public long Id { get; set; }
    //    public string Name { get; set; }
    //    public List<TopicDiscussion> TopicDiscussions { get; set; }
    //}

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string text;

            //FakeMeeting fm = new FakeMeeting();
            //Meeting meeting = fm.GenerateFake();
            //text = Newtonsoft.Json.JsonConvert.SerializeObject(meeting, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText(@"c:\tmp\fakemeeting.json", text);

            FakeTranscriptViewDto ft = new FakeTranscriptViewDto();
            ViewMeetingDto tvm = ft.GenerateFake();
            text = Newtonsoft.Json.JsonConvert.SerializeObject(tvm, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"c:\tmp\faketvm.json", text);

        }

    }
}
