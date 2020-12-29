using System;
using System.IO;
using GM.Application.DTOs.Meetings;

namespace GM.Utilities.FakeData
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
