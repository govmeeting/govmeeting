using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using GM.ViewModels;
using GM.DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using GM.DatabaseModel;

namespace GM.LoadDatabase
{
    public class LoadDatabase
    {

        public void LoadSampleData(string file)
        {
            string sample = File.ReadAllText(file);
            TranscriptViewModel transcript = JsonConvert.DeserializeObject<TranscriptViewModel>(sample);

            GovLocation govlocation = new GovLocation()
            {
                Name = "USA"
            };


            using var context = GetLocalDbProvider();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.GovLocations.Add(govlocation);
            context.SaveChanges();
        }


        private ApplicationDbContext GetLocalDbProvider()
        {
            string connection = "Server=(localdb)\\mssqllocaldb;Database=GovmeetingTest;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connection);
            ApplicationDbContext _context = new ApplicationDbContext(optionsBuilder.Options);
            return _context;
        }


    }
}
