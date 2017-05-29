using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.IO;
using Newtonsoft.Json;

namespace WebApp.Models
{
    public class MeetingRepository : IMeetingRepository
    {
        static ConcurrentDictionary<string, Meeting> _meetings = new ConcurrentDictionary<string, Meeting>();

        public MeetingRepository()
        {
            Add(new Meeting
            {
                key = "1",
                country = "USA",
                state = "ME",
                municipality = "Boothbay Harbor",
                meetingInfo = new Meetinginfo
                { name = "Boothbay Harbor Selectmen meeting", date = "Sept. 8, 2014" },
                path = "assets/BoothbayHarbor_Selectmen_2014-09-08.json"
            });
            Add(new Meeting
            {
                key = "2",
                country = "USA",
                state = "PA",
                municipality = "Philadelphia",
                meetingInfo = new Meetinginfo
                { name = "Philadelphia City Council meeting", date = "March 17, 2016" },
                path = "assets/Philadelphia_CityCouncil_2016-03-17.json"
            });
            Add(new Meeting
            {
                key = "3",
                country = "USA",
                state = "PA",
                municipality = "Philadelphia",
                meetingInfo = new Meetinginfo
                { name = "Philadelphia City Council meeting", date = "Sept. 25, 2014" },
                path = "assets/Philadelphia_CityCouncil_2014-09-25.json"
            });
        }

        public IEnumerable<Meeting> GetAll()
        {
            return _meetings.Values;
        }

        public void Add(Meeting item)
        {
            //item.Key = Guid.NewGuid().ToString();
            _meetings[item.key] = item;
        }

    }
}
