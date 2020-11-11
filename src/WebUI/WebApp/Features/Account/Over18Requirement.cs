using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM.WebApp.Models

{
    /*
     * I found this code on stackoverflow. http://stackoverflow.com/questions/31464359/custom-authorizeattribute-in-asp-net-5-mvc-6
     * It looked interesting and possibly useful later.

    public class Over18Requirement : AuthorizationHandler<Over18Requirement>, IAuthorizationRequirement
    {
        public override void Handle(AuthorizationContext context, Over18Requirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                context.Fail();
                return;
            }

            var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            if (age >= 18)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }



     // Then in your ConfigureServices() function you'd wire it up:

        options.AddPolicy("Over18", 
            policy => policy.Requirements.Add(new Authorization.Over18Requirement()));

     // And finally apply it to a controller or action method with:

        [Authorize(Policy = "Over18")]


    */
}
