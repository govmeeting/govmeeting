using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public interface IMeetingRepository
    {
        void Add(Meeting item);
        IEnumerable<Meeting> GetAll();
        // Meeting Find(string key);
        // Meeting Remove(string key);
        // void Update(Meeting item);
    }
}
