using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    // Class to inialize the database with the first admin user. See:
    // https://stackoverflow.com/questions/40027388/cannot-get-the-usermanager-class/40046290#40046290
    public static class DbInitializer
    {
        static ApplicationDbContext context;
        static UserManager<ApplicationUser> userManager;
        static RoleManager<IdentityRole> roleManager;
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        //public static async Task Initialize(IApplicationBuilder app)
        {
            // Get the db context of the Application
            //var context = app.ApplicationServices.GetService<ApplicationDbContext>();
            // Get the user manager
            //var userManager = app.ApplicationServices.GetService<UserManager<ApplicationUs‌​er>>();
            // Get the role manager
            //var roleManager = app.ApplicationServices.GetService<RoleManager<IdentityRole>‌​>();
            // So you can simply use the app parameter to get the required service.



            // Ensure that the database exists and all pending migrations are applied.
            context.Database.Migrate();

            // The following was from before we switch to using claims.
            //// Create roles. This adds them to the table dbo.AspNetRoles.
            //string[] roles = new string[] { "UserManager", "StaffManager" };
            //foreach (string role in roles)
            //{
            //    if (!await roleManager.RoleExistsAsync(role))
            //    {
            //        await roleManager.CreateAsync(new IdentityRole(role));
            //    }
            //}

            // Create admin user. This adds it to the table dbo.AspNetUsers
            string admin_username = configuration["AdminUser:Username"];
            string admin_password = configuration["AdminUser:Password"];
            string admin_email = configuration["AdminUser:Email"];
            if (!context.Users.Any())
            {
                await userManager.CreateAsync(new ApplicationUser() { UserName = admin_username, Email = admin_email }, admin_password);
            }

            // Confirm the admin's email
            ApplicationUser admin_user;
            admin_user = await userManager.FindByEmailAsync(admin_email);
            var emailConfirmationCode = await userManager.GenerateEmailConfirmationTokenAsync(admin_user);
            var confirmResult = await userManager.ConfirmEmailAsync(admin_user, emailConfirmationCode);

            // The following was from before we switch to using claims.
            //// assign admin privileges. This adds and enty in table dbo.AspNetUserRoles
            //ApplicationUser admin = await userManager.FindByEmailAsync("info@example.com");
            //foreach (string role in roles)
            //{
            //    await userManager.AddToRoleAsync(admin, role);
            //}


            // assign admin privileges. This adds and enty in table AspNetUserClaims
            var claims = await userManager.GetClaimsAsync(admin_user);
            var jobClaim = claims.FirstOrDefault(c => c.Type == "role");
            if (jobClaim == null)
            {
                await userManager.AddClaimAsync(admin_user, new Claim("role", "Administrator"));
            }
        }
    }
}

/*                                                SUMMARY
 *                   CALL                                    CREATES ENTRY IN TABLE
 * roleManager.CreateAsync(new IdentityRole( ... ))          dbo.AspNetRoles
 * userManager.CreateAsync(new ApplicationUser() { ... }     dbo.AspNetUsers
 * userManager.AddToRoleAsync( ... )                         dbo.AspNetUserRoles
 * userManager.AddClaimAsync(user, new Claim( ... )          dbo.AspNetUserClaims
 * 
 *      OTHER IDENTITY TABLES
 *      dbo.AspNetRoleClaims
 *      dbo.AspNetUserLogins
 *      dbo.AspNetUserTokens
 * */
