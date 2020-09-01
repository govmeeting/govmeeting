using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GM.DatabaseModel;
using GM.DatabaseRepositories;

namespace GM.DatabaseRepositories_Stub
{
    public class GovLocationRepository_Stub : IGovLocationRepository
    {

        public GovLocation Get(long govLocationId)
        {
            GovLocation govBody = testGovLocations.Single(m => m.Id == govLocationId);
            return govBody;
        }

        public long Add(GovLocation govLocation)
        {
            long id = testGovLocations.Count + 1;
            govLocation.Id = id;
            testGovLocations.Add(govLocation);
            return id;
        }

        private List<GovLocation> testGovLocations = new List<GovLocation>
        {
            new GovLocation()
            {
                Id = 1,
                Name = "United States of America",
                Code = "USA",
                GovLocationId = 0,
                Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
            },
            new GovLocation()
            {
                Id = 2,
                Name = "Pennsylvania",
                Code = "PA",
                GovLocationId = 1,
                Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
            },
            new GovLocation()
            {
                Id = 3,
                Name = "New Jersey",
                Code = "NJ",
                GovLocationId = 1,
                Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
            },
            new GovLocation()
            {
                Id = 4,
                Name = "Maine",
                Code = "ME",
                GovLocationId = 1,
                Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
            },
            new GovLocation()
            {
                Id = 5,
                Name = "Philadelphia",
                Code = "",
                GovLocationId = 2,
                Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
            },
            new GovLocation()
            {
                Id = 6,
                Name = "Little Falls",
                Code = "",
                GovLocationId = 3,
                Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
            },
            new GovLocation()
            {
                Id = 7,
                Name = "Boothbay Harbor",
                Code = "",
                GovLocationId = 4,
                Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
            },
            new GovLocation()
            {
                Id = 8,
                Name = "Australia",
                Code = "AUS",
                GovLocationId = 0,
                Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
            },
            new GovLocation()
            {
                Id = 9,
                Name = "Victoria",
                Code = "Vic",
                GovLocationId = 8,
                Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
            },
            new GovLocation()
            {
                Id = 10,
                Name = "Melbourne",
                Code = "",
                GovLocationId = 9,
                Languages = new List<Language> {new Language {Id = 1, Name = "en"} }
            }
        };

    }
}
