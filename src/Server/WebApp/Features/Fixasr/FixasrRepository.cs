using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApp.Models
{
    public class FixasrRepository : IFixasrRepository
    {
        static ConcurrentDictionary<string, Fixasr> _fixasr = new ConcurrentDictionary<string, Fixasr>();

        //public FixasrRepository()
        //{
        ////    Add(new Fixasr { Name = "Item1" });
        //}

        // https://www.mikesdotnetting.com/article/302/server-mappath-equivalent-in-asp-net-core
        private IHostingEnvironment _env;
        public FixasrRepository(IHostingEnvironment env)
        {
            _env = env;
            //    Add(new Fixasr { Name = "Item1" });
        }


        /*public IEnumerable<Fixasr> GetAll()
        {
            return _fixasr.Values;
        }*/

        /*public void Add(Fixasr item)
        {
            item.Key = Guid.NewGuid().ToString();
            _fixasr[item.Key] = item;
        }*/

        public Fixasr Find(string key)
        {
            Fixasr item;
            _fixasr.TryGetValue(key, out item);
            return item;
        }

        // We are currently storing the data under the following structure. Directories under assets/data are
        // named as follows: 
        //    <country>_<state>_<county>_<town-or-city>_<gov-entity>/<date>
        // Example, calling:
        //     Get("johnpank", "USA", "PA", "Philadelphia", "Philadelphia", "CityCouncil", "2016-03-17")
        // gets data from:
        //     "wwwroot/assets/data/USA_PA_Philadelphia_Philadelphia_CityCouncil/2016-03-17"
        // We will likely change this convention once the number of files grows and we need a deeper folder structure.
        public Fixasr Get(string username, string country, string state, string county, string city, string govEntity, string meetingDate)
        {
            // Todo - check permissions


            //string path = "assets\\data\\" + country + "_" + state + "_" + county + "_" + city + "_" + govEntity + "\\" + meetingDate + "\\" + "Step 2 - transcript from Youtube.json";
            string path = "assets/data/" + country + "_" + state + "_" + county + "_" + city + "_" + govEntity + "/" + meetingDate + "/" + "Step 2 - transcript from Youtube.json";
            return GetByPath(path);
        }

        public Fixasr GetByPath(string path)
        {
            var webRoot = _env.WebRootPath;
            var fullpath = System.IO.Path.Combine(webRoot, path);

            string fixasrString = Readfile(fullpath);
            //string fixasrString = getTagEditsString();
            if (fixasrString != null)
            {
                Fixasr fixasr = JsonConvert.DeserializeObject<Fixasr>(fixasrString);
                return fixasr;
            } else
            {
                return null;
            }
        }

        public string GetStringByPath(string path)
        {
            string fixasrString = Readfile(path);
            if (fixasrString != null)
            {
                return fixasrString;
            }
            else
            {
                return null;
            }
        }

        //public void PutByPath(string path, string value)
        public void PutByPath(string path, Fixasr value)
        {
            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);
            //string stringValue = value;

            var webRoot = _env.WebRootPath;
            var fullpath = System.IO.Path.Combine(webRoot, path);
            var filename = "Step 3 - transcript corrected for errors.json";
            var fullname = fullpath + "/" + filename;
 
            // If file exists, make backup
            if (File.Exists(fullname))
            {
                MakeBackup(fullpath, filename);
            }   

            File.WriteAllText(fullname, stringValue);

        }

        // The backups will be (for example) "... backup 01.json", "... backup 02.json", .... "... backup 07 - last.json"
        // The " - last" is the last backup made. The reason that we need this is because we will recyle the numbers once
        // we hit the maximum backups. Thus if the maximum is 20, after "... backup 20.json" will come "... backup 01.json",
        // which, if it is the last, will be named "... backup 01 - last.json"
        private void MakeBackup(string fullpath, string filename)
        {
            string[] files = Directory.GetFiles(fullpath, "*Step 3*- last.json");
            var fullname = fullpath + "/" + filename;

            //File.Copy(fullname, newFile);

            //while (File.Exists(nextBackup))
            //{

            //}
            // http://timtrott.co.uk/string-formatting-examples/
        }

        /*public Fixasr Remove(string key)
           {
               Fixasr item;
               _fixasr.TryGetValue(key, out item);
               _fixasr.TryRemove(key, out item);
               return item;
           }*/

        public void Update(Fixasr item)
        {
            //Write out JSON data.
            //string output = JsonConvert.SerializeObject(gto, Formatting.Indented);
            //    _transcriptEdits[item.key] = item;
        }

        private string Readfile(string path)
        {
            try
            {
                string text = System.IO.File.ReadAllText(path);
                return text;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static string getTagEditsString()
        {
            return @"{ 'data': [
                { startTime: '0:00', said: 'the tuesday october $YEAR 11 selectmen'},
                { startTime: '0:02', said: 'meeting i will apologize apologize for'},
                { startTime: '0:06', said: 'my voice i can hardly speak i woke up'},
                { startTime: '0:08', said: 'Saturday with a terrible cold so if you'},
                { startTime: '0:10', said: 'can\'t hear me just speak up and i\'ll try'},
                { startTime: '0:13', said: 'to speak louder and you may want to stay'},
                { startTime: '0:14', said: 'in the back yeah you guys today in the'},
                { startTime: '0:17', said: 'background is yeah I\'m like have our'},
                { startTime: '0:20', said: 'full board with us tonight and we have'},
                { startTime: '0:24', said: 'our recording secretary Kelly the ghost'},
                { startTime: '0:26', said: 'town manager Tom women and selected'},
                { startTime: '0:30', said: 'Trish Warren wendy wolf myself Denise'}
            ] }";
        }

    }
}
