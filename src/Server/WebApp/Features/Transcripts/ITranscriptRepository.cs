using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public interface ITranscriptRepository
    {
        //void Add(Transcript item);
        //IEnumerable<Transcript> GetAll();

        Transcript Get(string username, string country, string state, string county, string city, string govEntity, string meetingDate);
        Transcript Get(string city, string govEntity, string meetingDate);
        Transcript GetByPath(string path);
        Transcript Find(string key);
        //Transcript Remove(string key);
        void Update(Transcript item);
    }
}
