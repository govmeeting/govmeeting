using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
// upgrade to SDK 2.0
//using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;

namespace GM.WebUI.WebApp.Features.Manage
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        // upgrade to SDK 2.0
        public IList<AuthenticationScheme> OtherLogins { get; set; }
        //public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
