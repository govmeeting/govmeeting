using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DatabaseModel
{
    /// <summary>
    /// The Government body
    /// </summary>
    public class GovernmentBody
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string Municipality { get; set; }
        public List<Language> Languages { get; set; }
        public List<Meeting> Meetings { get; set; }
        public List<Topic> Topics { get; set; }

        public GovernmentBody()
        {
        }
        public GovernmentBody(string country, string state, string county, string municipality)
        {
            Country = country;
            State = state;
            County = county;
            Municipality = municipality;
        }

    }
}
