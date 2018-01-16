using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace WebApp.Models
{
    // We are currently storing the data under the following structure.
    // Directories under Datafiles are named as follows: <country>_<state>_<town-or-city>_<gov-entity>/<date>
    // Example: Get("johnpank", "USA", "PA", "Philadelphia", "CityCouncil", "2016-03-17")
    // will get the file in the directory "Datafiles/USA_PA_Philadelphia_CityCouncil/2016-03-17".
    // We will likely change this convention once the number of files grows and we need a deeper folder structure.


    public class AddtagsRepository : IAddtagsRepository
    {
        //static ConcurrentDictionary<string, Addtags> _addtags = new ConcurrentDictionary<string, Addtags>();
        private TypedOptions _options { get; set; }

        // https://www.mikesdotnetting.com/article/302/server-mappath-equivalent-in-asp-net-core
        //private IHostingEnvironment _env;
        public AddtagsRepository(IOptions<TypedOptions> options)
        {
            _options = options.Value;
            //    Add(new Addtags { Name = "Item1" });
        }

        public Addtags Get(string username, string country, string state, string county, string city, string govEntity, string meetingDate)
        {
            // Todo-g - check permissions
            //      - change to get a default govEntity
            //      - change to get the latest meeting

            string path = country + "_" + state + "_" + city + "_" + county + "_" + govEntity + "\\" + meetingDate + "\\" + "Step 3 - JSON output.json";

            return GetByPath(Path.Combine(_options.DatafilesPath, path));
        }

        //public void Put(string value)
        public void Put(Addtags value, string username, string country, string state, string county, string city, string govEntity, string meetingDate)
        {
            string path = country + "_" + state + "_" + city + "_" + county + "_" + govEntity + "\\" + meetingDate + "\\" + "Step 4 - Add tags.json";
            string fullpath = Path.Combine(_options.DatafilesPath, path);

            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            File.WriteAllText(fullpath, stringValue);

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

        //public void PutByPath(string path, string value)
        public void PutByPath(string path, Addtags value)
        {
            string stringValue = JsonConvert.SerializeObject(value, Formatting.Indented);

            //var webRoot = _env.WebRootPath;
            //var fullpath = Path.Combine(webRoot, path);

            File.WriteAllText(path, stringValue);

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

        //public string GetStringByPath(string path)
        //{
        //    string addtagsString = Readfile(path);
        //    if (addtagsString != null)
        //    {
        //        return addtagsString;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public void Update(Addtags item)
        //{
        //    Write out JSON data.
        //    string output = JsonConvert.SerializeObject(gto, Formatting.Indented);
        //        _transcriptEdits[item.key] = item;
        //}

    }
}
