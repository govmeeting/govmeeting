using GM.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GM.DatabaseRepositories
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
                GovLocationId = 5   // Philadelphia
            }
        };

    }
}
