using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public interface IMeetingRepository
    {
        Meeting Get(string country, string state, string county, string city, string govEntity, string meetingDate);
    }
}
