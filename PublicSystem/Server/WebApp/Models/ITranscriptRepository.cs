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

        Transcript GetByPath(string path);
        Transcript Find(string key);
        //Transcript Remove(string key);
        void Update(Transcript item);
    }
}
