using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.GovLocations;
using GM.Infrastructure.InfraCore.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GM.WebUI.WebApp.Services
{
    public static class SeedDatabase
    {
        static ApplicationDbContext _context;
        public static void Seed()
        {
            using (_context = GetLocalDbProvider())
            {
                // Check if the DB was already seeded.
                var query = from g in _context.GovLocations
                            where g.Name == "United States"
                            select g;
                var checkLoc = query.FirstOrDefault<GovLocation>();
                if (checkLoc != null)
                {
                    return;
                }

                GovLocation country = null;
                GovLocation state = null; // state or province
                GovLocation county = null;
                GovLocation local = null;

                country = AddLocation("United States", GovlocTypes.Country, null);
                state = AddLocation("New Jersey", GovlocTypes.StateOrProvince, country);
                county = AddLocation("Passaic County", GovlocTypes.County, state);
                AddGovbody("Board of Freeholders", county);
                local = AddLocation("Little Falls", GovlocTypes.Township, county, "https://www.youtube.com/channel/UCnXmZfXIxB9n_b6PMoh0kmA/videos");
                AddGovbody("City Council", local);
                AddGovbody("Zoning Board", local);

                state = AddLocation("Pennsylvania", GovlocTypes.StateOrProvince, country);
                county = AddLocation("Philadelphia County", GovlocTypes.County, state);
                local = AddLocation("Philadelphia", GovlocTypes.City, county);
                AddGovbody("City Council", local);

                country = AddLocation("Australia", GovlocTypes.Country, null);
                state = AddLocation("Victoria", GovlocTypes.StateOrProvince, country);
                local = AddLocation("City of Whittlesea", GovlocTypes.City, state);
                AddGovbody("City Council", local);
                local = AddLocation("City of Greater Bebdingo", GovlocTypes.City, state, "https://www.youtube.com/user/CityOfGreaterBendigo/videos");
                AddGovbody("City Council", local);
            }
        }

        private static GovLocation AddLocation(string name, GovlocTypes type, GovLocation parent, string recordingsUrl = null)
        {
            GovLocation loc = new GovLocation(name, type, null)
            {
                ParentLocation = parent,
                RecordingsUrl = recordingsUrl
            };
            _context.GovLocations.Add(loc);
            _context.SaveChanges();
            return loc;
        }

        private static void AddGovbody(string name, GovLocation loc)
        {
            Govbody gov = new Govbody(name, loc);
            _context.Govbodies.Add(gov);
            _context.SaveChanges();
        }

        private static ApplicationDbContext GetLocalDbProvider()
        {
            string connection = "Server=(localdb)\\mssqllocaldb;Database=Govmeeting;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connection);
            ApplicationDbContext _context = new ApplicationDbContext(null, optionsBuilder.Options);
            return _context;
        }

    }
}
