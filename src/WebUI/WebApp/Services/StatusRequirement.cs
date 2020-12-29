using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GM.WebUI.WebApp.Services
{

    /* This method of authorization is taken from:
     * "The State of Security in ASP.NET 5 and MVC 6: Authorization" by Dominick Baier on
     * https://leastprivilege.com/2015/10/12/the-state-of-security-in-asp-net-5-and-mvc-6-authorization/
     */
    //public class StatusRequirement : AuthorizationHandler<StatusRequirement>, IAuthorizationRequirement
    //{
    //    private readonly string _status;
    //    private readonly string _department;

    //    public StatusRequirement(string department, string status, bool isSupervisorAllowed = true)
    //    {
    //        _department = department;
    //        _status = status;
    //    }

    //    protected override void Handle(AuthorizationContext context, StatusRequirement requirement)
    //    {
    //        if (context.User.IsInRole("supervisor"))
    //        {
    //            context.Succeed(requirement);
    //            return;
    //        }

    //        if (context.User.HasClaim("department", _department) &&
    //            context.User.HasClaim("status", _status))
    //        {
    //            context.Succeed(requirement);
    //        }
    //    }
    //}
}
