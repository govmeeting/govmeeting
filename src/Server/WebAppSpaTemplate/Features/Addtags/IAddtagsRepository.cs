using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    /* This is the repository for the transcripts which are being
     * edited. The edits mostly involve adding tags to the "tags".
     * The tags represent:
     *  Topic   - that the topic of discussion is changing
     *  Section - that the meeting section is changing
     *  Bill    - that a specific bill is now being discussed
     */
    public interface IAddtagsRepository
    {
        //void Add(Addtags item);
        //IEnumerable<Addtags> GetAll();

        Addtags Get(string username, string country, string state, string county, string city, string govEntity, string meetingDate);
        Addtags GetByPath(string path);
        // string GetStringByPath(string path);
        void PutByPath(string path, Addtags value);
        //void PutByPath(string path, string value);
        //Addtags Find(string key);
        //Addtags Remove(string key);
        //void Update(Addtags item);
    }
}
