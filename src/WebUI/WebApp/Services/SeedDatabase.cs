using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.GovLocations;
using GM.Infrastructure.InfraCore.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GM.WebUI.WebApp.Services
{
    public interface ISeedDatabase
    {
        public  void Seed();
    }

    public class SeedDatabase : ISeedDatabase
    {
        ApplicationDbContext _context;

        public SeedDatabase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
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
            Govbody council = null;
            List<ElectedOfficial> electedOfficials = null;
            List<AppointedOfficial> appointedOfficials = null;

            ////////////////// Little Falls, NJ USA ////////////////////////////
                
            country = AddLocation("United States", GovlocTypes.Country, null);
            state = AddLocation("New Jersey", GovlocTypes.StateOrProvince, country);
            county = AddLocation("Passaic County", GovlocTypes.County, state);

            AddGovbody("Board of Freeholders", county);
            local = AddLocation("Little Falls", GovlocTypes.Township, county, "https://www.lfnj.com/");
            council = AddGovbody("City Council", local, "https://www.youtube.com/channel/UCnXmZfXIxB9n_b6PMoh0kmA/videos");

            electedOfficials = new List<ElectedOfficial>()
            {
                new ElectedOfficial() { Name = "James Damiano", Title = "Mayor"},
                new ElectedOfficial() { Name = "Anthony Sgobba", Title = "President, Councilman"},
                new ElectedOfficial() { Name = "Albert Kahwaty", Title = "Councilman"},
                new ElectedOfficial() { Name = "Christopher Vancheri", Title = "Councilman"},
                new ElectedOfficial() { Name = "Christine Hablitz", Title = "Councilwoman"},
                new ElectedOfficial() { Name = "Tanya Seber", Title = "Councilwoman"}
            };
            AddElectedOfficials(electedOfficials, council);

            appointedOfficials = new List<AppointedOfficial>()
            {
                new AppointedOfficial() { Name = "Charles Cuccia", Title = "Township Administrator"},
                new AppointedOfficial() { Name = "Cynthia Kraus, RMC", Title = "Township Clerk"},
                new AppointedOfficial() { Name = "Steven Post", Title = "Chief of Police"},
                new AppointedOfficial() { Name = "Richard Hamilton", Title = "Tax Assessor"},
                new AppointedOfficial() { Name = "James Di Maria", Title = "Construction Official"},
                new AppointedOfficial() { Name = "Charles Cuccia", Title = "CMFO/Treasurer"},
                new AppointedOfficial() { Name = "John E. Biegel III", Title = "Health Officer"},
                new AppointedOfficial() { Name = "Ronald Campbell", Title = "DPW Superintendent"},
            };
            AddAppointedOfficials(appointedOfficials, council);

            AddGovbody("Zoning Board", local);

            ////////////////// Boothbay Harbor, ME USA ////////////////////////////

            country = AddLocation("United States", GovlocTypes.Country, null);
            state = AddLocation("Maine", GovlocTypes.StateOrProvince, country);
            county = AddLocation("Lincoln County", GovlocTypes.County, state);

            local = AddLocation("Boothbay Harbor", GovlocTypes.Township, county, "https://www.boothbayharbor.org/");
            council = AddGovbody("Board of Selectmen", local, "https://www.boothbaytv.com/on-demand");

            electedOfficials = new List<ElectedOfficial>()
            {
                new ElectedOfficial() { Name = "Wendy Wolf", Title = "Selectperson"},
                new ElectedOfficial() { Name = "Michael Tomko", Title = "Chair"},
                new ElectedOfficial() { Name = "Denise Griffin ", Title = "Councilman"},
                new ElectedOfficial() { Name = "Tricia Warren ", Title = "Vice Chair"}
            };
            AddElectedOfficials(electedOfficials, council);

            appointedOfficials = new List<AppointedOfficial>()
            {
                new AppointedOfficial() { Name = "Michelle Farnham", Title = "Town Clerk"},
                new AppointedOfficial() { Name = "Robert Hasch", Title = "Police Chief"},
                new AppointedOfficial() { Name = "Julia Latter", Title = "Town Manager"},
                new AppointedOfficial() { Name = "Jeff Lowell", Title = "Harbor Master"},
                new AppointedOfficial() { Name = "Geoff Smith", Title = "Code Enforcement Officer"}
            };
            AddAppointedOfficials(appointedOfficials, council);

            AddGovbody("Planning Board", local);

            /////////////////// City of Whittlesea & City of Greater Bebdingo, Victoria, AU ///////////////////

            state = AddLocation("Pennsylvania", GovlocTypes.StateOrProvince, country);
            county = AddLocation("Philadelphia County", GovlocTypes.County, state);
            local = AddLocation("Philadelphia", GovlocTypes.City, county);
            AddGovbody("City Council", local);

            country = AddLocation("Australia", GovlocTypes.Country, null);
            state = AddLocation("Victoria", GovlocTypes.StateOrProvince, country);
            local = AddLocation("City of Whittlesea", GovlocTypes.City, state);
            AddGovbody("City Council", local);
            local = AddLocation("City of Greater Bebdingo", GovlocTypes.City, state, "https://www.bendigo.vic.gov.au/");
            AddGovbody("City Council", local, "https://www.youtube.com/user/CityOfGreaterBendigo/videos");
        }

        private GovLocation AddLocation(string name, GovlocTypes type, GovLocation parent, string recordingsUrl = null)
        {
            GovLocation loc = new GovLocation(name, type, null)
            {
                ParentLocation = parent,
                WebsiteUrl = recordingsUrl
            };
            _context.GovLocations.Add(loc);
            _context.SaveChanges();
            return loc;
        }

        private Govbody AddGovbody(string name, GovLocation loc, string recordingsUrl = null)
        {
            Govbody gov = new Govbody(name, loc)
            {
                RecordingsUrl = recordingsUrl
            };
            _context.Govbodies.Add(gov);
            _context.SaveChanges();
            return gov;
        }

        private void AddElectedOfficials(List<ElectedOfficial> officials, Govbody loc)
        {
            foreach (ElectedOfficial official in officials)
            {
                official.GovbodyId = loc.Id;
                _context.ElectedOfficials.Add(official);
            }
            _context.SaveChanges();
        }

        private void AddAppointedOfficials(List<AppointedOfficial> officials, Govbody loc)
        {
            foreach (AppointedOfficial official in officials)
            {
                official.GovbodyId = loc.Id;
                _context.AppointedOfficials.Add(official);
            }
            _context.SaveChanges();
        }

        private ApplicationDbContext GetLocalDbProvider()
        {
            string connection = "Server=(localdb)\\mssqllocaldb;Database=Govmeeting;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connection);
            // optionsBuilder.UseInMemoryDatabase(connection)
            ApplicationDbContext _context = new ApplicationDbContext(null, optionsBuilder.Options);
            return _context;
        }

    }
}

