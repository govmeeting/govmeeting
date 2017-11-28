using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.IO;
using WebApp.Services;
using Microsoft.Extensions.Options;

namespace WebApp.Models
{
    public class MeetingRepository : IMeetingRepository
    {
        static ConcurrentDictionary<string, Meeting> _meetings = new ConcurrentDictionary<string, Meeting>();
        private const string STEP5_BASE_NAME = "Step 5 - processed transcript";
        private const string EXTENSION = "json";
        private DatafilesOptions _options { get; set; }

        public MeetingRepository(IOptions<DatafilesOptions> settings)
        {
            _options = settings.Value;
        }

        public Meeting Get(string country, string state, string county, string city, string govEntity, string meetingDate)
        {
            // Todo-g - check permissions

            string subpath = country + "_" + state + "_" + county + "_" + city + "_" + govEntity + "\\" + meetingDate;

            string latestCopy = Path.Combine(_options.DatafilesPath, subpath, STEP5_BASE_NAME + "." + EXTENSION);

            if (File.Exists(latestCopy))
            {
                return GetByPath(latestCopy);
            }
            else
            {
                return null;
            }
        }

        private Meeting GetByPath(string path)
        {
            string meetingString = Common.Readfile(path);
            if (meetingString != null)
            {
                Meeting meeting = JsonConvert.DeserializeObject<Meeting>(meetingString);
                return meeting;
            } else
            {
                return null;
            }
        }
    }
}
