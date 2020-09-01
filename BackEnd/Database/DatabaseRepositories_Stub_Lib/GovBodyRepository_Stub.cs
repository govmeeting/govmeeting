using GM.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GM.DatabaseRepositories;

namespace GM.DatabaseRepositories_Stub
{
    public class GovBodyRepository_Stub : IGovBodyRepository
    {
        public GovBody Get(long govBodyId)
        {
            GovBody govBody = testGovBodies.Single(m => m.Id == govBodyId);
            return govBody;
        }

        public long Add(GovBody govBody)
        {
            long id = testGovBodies.Count + 1;
            govBody.Id = id;
            testGovBodies.Add(govBody);
            return id;
        }

        public List<GovBody> FindThoseWithScheduledMeetings()
        {
            return new List<GovBody>();
        }


        private List<GovBody> testGovBodies = new List<GovBody>
        {
            new GovBody()
            {
                Id = 1,
                Name = "Board of Selectmen",
                GovLocationId = 7   // Boothbay Harbor
            },
            new GovBody()
            {
                Id = 1,
                Name = "City Council",
                GovLocationId = 5,   // Philadelphia
                ScheduledMeetings = new List<ScheduledMeeting>()
                {
                    new ScheduledMeeting()
                    {
                        Id = 1,
                        Date = DateTime.Now.AddDays(-2)
                    }
                }
            }
        };

    }
}
