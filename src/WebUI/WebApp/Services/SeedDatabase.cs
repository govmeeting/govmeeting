using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using GM.DatabaseAccess;
using GM.ApplicationCore.Entities.Govbodies;
using GM.ApplicationCore.Entities.GovLocations;

namespace GM.WebApp.Services
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            using (var context = GetLocalDbProvider())
            {
                // Check if the DB was already seeded.
                var query = from g in context.GovLocations
                            where g.Name == "United States"
                            select g;
                var checkLoc = query.FirstOrDefault<GovLocation>();
                if (checkLoc != null)
                {
                    return;
                }

                // Write four GovLocations
                List<GovLocation> locs = new List<GovLocation>
                {
                    /* TODO - I am using the "code" field key wrongly here.
                     * "code" should be its official location code.
                     * I should set an "abbreviation" property and use it, concatenated with its parent, as "LongName" 
                     */
                    new GovLocation("United States", GovlocTypes.Country, "USA"),
                    new GovLocation("New Jersey", GovlocTypes.StateOrProvince, "NJ"),
                    new GovLocation("Passaic County", GovlocTypes.County, "Passaic"),
                    new GovLocation("Little Falls", GovlocTypes.Township, "LittleFalls")
                };
                GovLocation parentGovLoc = null;
                foreach (GovLocation loc in locs)
                {
                    loc.ParentLocation = parentGovLoc;
                    context.GovLocations.Add(loc);
                    context.SaveChanges();
                    parentGovLoc = loc;
                }

                // Write one Govbody for the last GovLocation
                Govbody gov = new Govbody("Town Council", parentGovLoc);
                context.Govbodies.Add(gov);
                context.SaveChanges();
            }
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
