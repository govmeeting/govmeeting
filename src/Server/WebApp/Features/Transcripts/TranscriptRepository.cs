using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.IO;

namespace WebApp.Models
{
    public class TranscriptRepository : ITranscriptRepository
    {
        static ConcurrentDictionary<string, Transcript> _transcripts = new ConcurrentDictionary<string, Transcript>();
        private const string STEP5_BASE_NAME = "Step 5 - processed transcript";
        private const string EXTENSION = "json";

        public TranscriptRepository()
        {
        //    Add(new Transcript { Name = "Item1" });
        }

        /*public IEnumerable<Transcript> GetAll()
        {
            return _transcripts.Values;
        }*/

        /*public void Add(Transcript item)
        {
            item.Key = Guid.NewGuid().ToString();
            _transcripts[item.Key] = item;
        }*/

        public Transcript Find(string key)
        {
            Transcript item;
            _transcripts.TryGetValue(key, out item);
            return item;
        }

        public Transcript Get(string username, string country, string state, string county, string city, string govEntity, string meetingDate)
        {
            // Todo - check permissions

            string subpath = country + "_" + state + "_" + county + "_" + city + "_" + govEntity + "/" + meetingDate;

            var fullpath = getFullPath(subpath);
            string latestCopy = fullpath + "/" + STEP5_BASE_NAME + "." + EXTENSION;
            if (File.Exists(latestCopy))
            {
                return GetByPath(latestCopy);
            }
            // Otherwise return the unedited one from step 2.
            else
            {
                return null;
            }
        }

        // Example: Get("BoothbayHarbor", "Selectmen", "2014-09-08")
        public Transcript Get(string city, string govEntity, string meetingDate)
        {
            // Todo - change to get a default entity
            if (govEntity == null) govEntity = "Selectmen";

            // Todo - change to get the latest meeting
            if (meetingDate == null) meetingDate = "2014-09-08";

            string path = city + "_" + govEntity + "_" + meetingDate + ".json";
            return GetByPath("assets/" + path);
        }

        public Transcript GetByPath(string path)
        {
            string transcriptString = Common.Readfile(path);
            if (transcriptString != null)
            {
                Transcript transcript = JsonConvert.DeserializeObject<Transcript>(transcriptString);
                return transcript;
            } else
            {
                return null;
            }
        }

        /*public Transcript Remove(string key)
         {
             Transcript item;
             _transcripts.TryGetValue(key, out item);
             _transcripts.TryRemove(key, out item);
             return item;
         }*/

        public void Update(Transcript item)
        {
            //Write out JSON data.
            //string output = JsonConvert.SerializeObject(gto, Formmatting.Indented);
            //    _transcripts[item.key] = item;
        }

        private string getFullPath(string path)
        {
            return System.IO.Path.Combine(Common.getDataPath(), path);
        }

    }
}
