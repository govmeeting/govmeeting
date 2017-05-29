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

        private const string STEP2_BASE_NAME = "Step 2 - transcript from Youtube";
        private const string STEP3_BASE_NAME = "Step 3 - transcript corrected for errors";
        private const string EXTENSION = "json";

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

        // We are currently storing the data under the following structure. Directories under Datafiles are
        // named as follows: 
        //    <country>_<state>_<county>_<town-or-city>_<gov-entity>/<date>
        // Example, calling:
        //     Get("johnpank", "USA", "PA", "Philadelphia", "Philadelphia", "CityCouncil", "2016-03-17")
        // gets data from:
        //     "Datafiles/USA_PA_Philadelphia_Philadelphia_CityCouncil/2016-03-17"
        // We will likely change this convention once the number of files grows and we need a deeper folder structure.
        public Fixasr Get(string username, string country, string state, string county, string city, string govEntity, string meetingDate)
        {
            // Todo - check permissions

            string subpath = country + "_" + state + "_" + county + "_" + city + "_" + govEntity + "/" + meetingDate;

            // If we already edited it, return the latest edit.
            var fullpath = getFullPath(subpath);
            string latestCopy = getLatestFile(fullpath, STEP3_BASE_NAME, EXTENSION);
            if (File.Exists(latestCopy))
            {
                return GetByPath(latestCopy);
            }
            // Otherwise return the unedited one from step 2.
            else
            {
                string filename = fullpath + "/" + STEP2_BASE_NAME + "." + EXTENSION;
                return GetByPath(filename);
            }
        }

        private string getFullPath(string path)
        {
            return System.IO.Path.Combine(Common.getDataPath(), path);
        }

        public Fixasr GetByPath(string path)
        {
            string fixasrString = Common.Readfile(path);
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
            string fixasrString = Common.Readfile(path);
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
            // const string STEP3_BASE_NAME = "x";   // for testing
            const string SUFFIX = "-LAST";
            const string SEPERATOR = " - ";

            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            var fullpath = getFullPath(path);
            string numOfNextLatest = "01";          // Assume the next latest is "01".

            // Find out what the current latest is.
            string latestCopy = getLatestFile(fullpath, STEP3_BASE_NAME, EXTENSION);
            if (latestCopy != null)
            {
                numOfNextLatest = getNumberOfNextLatest(latestCopy, SUFFIX, EXTENSION);
                RenameLatestCopy(latestCopy, SUFFIX);
            }

            string nextLatestCopy = fullpath + "/" + STEP3_BASE_NAME + SEPERATOR + numOfNextLatest + SUFFIX + "." + EXTENSION;
            File.WriteAllText(nextLatestCopy, stringValue);
        }

        // get filename of latest copy
        private string getLatestFile(string fullpath, string basename, string extension)
        {
            const string SUFFIX = "-LAST";

            string[] files = Directory.GetFiles(fullpath, basename + "*" + SUFFIX + "." + extension);
            if (files.Length == 1)
            {
                return files[0];
            }
            return null;
        }

        private void RenameLatestCopy(string latestCopy, string suffix)
        {
            string newname = latestCopy.Replace(suffix, "");
            File.Move(latestCopy, newname);
        }

        // get number of next latest copy (as string)
        private string getNumberOfNextLatest(string latestCopy, string suffix, string extension)
        {
            const int MAX_BACKUPS = 20;

            int numLast;
            int startOfnumLast = latestCopy.Length - suffix.Length - extension.Length - 3;

            string numpart = latestCopy.Substring(startOfnumLast, 2);
            bool res = int.TryParse(numpart, out numLast);
            if (!res)
            {
                // todo - handle error
                return "01";
            }
            if (++numLast > MAX_BACKUPS)
            {
                numLast = 1;
            }
            // http://timtrott.co.uk/string-formatting-examples/
            return String.Format("{0:d2}", numLast);
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
