using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Http.Authentication;

namespace WebApp.Controllers
{
    /* This code is copied from the video "Advanced aspNET Core Authorization - Barry Dorrans.mp4"
     * It is missing code at the bottom. His display did not show all the code.
     */
    public class ClaimsController : Controller
    {
        public async Task<IActionResult> Unauthorized(string returnUrl = null)
        {
            const string Issuer = "https://contoso.com";
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "barry", ClaimValueTypes.String, Issuer));
            claims.Add(new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String, Issuer));
            claims.Add(new Claim("EmployeeId", "123", ClaimValueTypes.String, Issuer));
    
            claims.Add(new Claim(ClaimTypes.DateOfBirth, "1970-06-08", ClaimValueTypes.Date));

            var userIdentity = new ClaimsIdentity("SuperSecureLogin");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,

                });

            // I added this to remove the compiler error.
            // I don't know what code was actually here.
            return Ok();
        }
    }
}
