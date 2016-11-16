using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.IO;

namespace WebApp.Models
{
    public class AddtagsRepository : IAddtagsRepository
    {
        static ConcurrentDictionary<string, Addtags> _addtags = new ConcurrentDictionary<string, Addtags>();

        public AddtagsRepository()
        {
        //    Add(new Addtags { Name = "Item1" });
        }

        /*public IEnumerable<Addtags> GetAll()
        {
            return _addtags.Values;
        }*/

        /*public void Add(Addtags item)
        {
            item.Key = Guid.NewGuid().ToString();
            _addtags[item.Key] = item;
        }*/

        public Addtags Find(string key)
        {
            Addtags item;
            _addtags.TryGetValue(key, out item);
            return item;
        }

        // Example: Get("johnpank", "Philadelphia", "CityCouncil", "2016-03-17")
        public Addtags Get(string username, string city, string govEntity, string meetingDate)
        {
            // TODO - check permissions

            // Todo - change to get a default entity
            if (govEntity == null) govEntity = "CityCouncil";

            // Todo - change to get the latest meeting
            if (meetingDate == null) meetingDate = "2016-03-17";

            string path = city + "_" + govEntity + "_" + meetingDate + ".json";
            return GetByPath("assets/" + path);
        }

        public Addtags GetByPath(string path)
        {
            string addtagsString = Readfile(path);
            //string addtagsString = getTagEditsString();
            if (addtagsString != null)
            {
                Addtags addtags = JsonConvert.DeserializeObject<Addtags>(addtagsString);
                return addtags;
            } else
            {
                return null;
            }
        }

        public string GetStringByPath(string path)
        {
            string addtagsString = Readfile(path);
            if (addtagsString != null)
            {
                return addtagsString;
            }
            else
            {
                return null;
            }
        }

        public void PutByPath(string path, Addtags value)
        {
            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);
            //File.WriteAllText(outfile, stringValue);

        }

        /*public Addtags Remove(string key)
           {
               Addtags item;
               _addtags.TryGetValue(key, out item);
               _addtags.TryRemove(key, out item);
               return item;
           }*/

        public void Update(Addtags item)
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
            {speaker: 'Joe', said: 'Waz up', section: 'Invocation', topic: null, showSetTopic: false},
            {speaker: 'Mary', said: 'nutten', section: null, topic: null, showSetTopic: false},
            {speaker: 'Jo', said: 'haiyall', section: null, topic: null, showSetTopic: false},
            {speaker: 'Joe', said: '1111', section: 'Reports', topic: null, showSetTopic: false},
            {speaker: 'Mary', said: '1111111', section: null, topic: 'Topic1', showSetTopic: false},
            {speaker: 'Jo', said: '11111111', section: null, topic: null, showSetTopic: false},
            {speaker: 'Jose', said: '22', section: null, topic: null, showSetTopic: false},
            {speaker: 'Mary', said: '2222', section: null, topic: null, showSetTopic: false},
            {speaker: 'Jo', said: '2222222', section: null, topic: null, showSetTopic: false},
            {speaker: 'Joe', said: '33', section: 'Public Comment', topic: null, showSetTopic: false},
            {speaker: 'Mary', said: '33333', section: null, topic: 'Topic2', showSetTopic: false},
            {speaker: 'Jo', said: '33333333', section: null, topic: null, showSetTopic: false}
            ] }";
        }

    }
}
