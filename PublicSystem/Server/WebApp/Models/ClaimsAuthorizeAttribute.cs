using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ClaimsAuthorize : AuthorizeAttribute
    {
        public string SubjectID { get; set; }
        public string LocationID { get; set; }

        //protected override bool IsAuthorized(HttpActionContext actionContext)
        //{
        //    ClaimsIdentity claimsIdentity;
        //    var httpContext = HttpContext.Current;
        //    if (!(httpContext.User.Identity is ClaimsIdentity))
        //    {
        //        return false;
        //    }

        //    claimsIdentity = httpContext.User.Identity as ClaimsIdentity;
        //    var subIdClaims = claimsIdentity.FindFirst("SubjectId");
        //    var locIdClaims = claimsIdentity.FindFirst("LocationId");
        //    if (subIdClaims == null || locIdClaims == null)
        //    {
        //        // just extra defense
        //        return false;
        //    }

        //    var userSubId = subIdClaims.Value;
        //    var userLocId = subIdClaims.Value;

        //    // use your desired logic on 'userSubId' and `userLocId', maybe Contains if I get your example right?
        //    if (!this.SubjectID.Contains(userSubId) || !this.LocationID.Contains(userLocId))
        //    {
        //        return false;
        //    }

        //    //Continue with the regular Authorize check
        //    return base.IsAuthorized(actionContext);
        //}
    }
}