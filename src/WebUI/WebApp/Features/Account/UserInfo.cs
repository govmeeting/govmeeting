using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Models
{
    public class UserInfo
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public IList<ClaimInfo> claims { get; set; }
    }
}
