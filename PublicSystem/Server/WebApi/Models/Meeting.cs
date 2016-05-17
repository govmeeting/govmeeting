using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{

    public class Meeting
    {
        public string key;
        public string country;
        public string state;
        public string municipality;
        public Meetinginfo meetingInfo;
        public string path;
    }
}
