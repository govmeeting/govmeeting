using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using GM.DatabaseAccess;
using GM.Configuration;
using Microsoft.Extensions.Options;

namespace GM.WebApp.Services
{
    public interface IDbInitializer
    {
        //Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
        //    RoleManager<IdentityRole> roleManager, IConfiguration configuration);
        Task<bool> Initialize();
    }

    // Class to inialize the database with the first admin user. See:
    // https://stackoverflow.com/questions/40027388/cannot-get-the-usermanager-class/40046290#40046290
    public class DbInitializer : IDbInitializer
    {
        public DbInitializer(
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            //IConfiguration configuration,
            IOptions<AppSettings> config)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            //_configuration = configuration;
            _config = config.Value;
        }

        ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        //IConfiguration _configuration;
        private readonly AppSettings _config;

        //public async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
        //    RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        public async Task<bool> Initialize()
        {
            // Ensure that the database exists and all pending migrations are applied.
            // TODO - Remove this when we have real data and use SQL scripts instead.
            // REMOVED MIGRATE
            _context.Database.Migrate();

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
            string admin_username = _config.DbAdmin.Username;
            string admin_password = _config.DbAdmin.Password;
            string admin_email = _config.DbAdmin.Email;
            if (!_context.Users.Any())
            {
                await _userManager.CreateAsync(new ApplicationUser() { UserName = admin_username, Email = admin_email }, admin_password);
            }

            ApplicationUser admin_user;
            admin_user = await _userManager.FindByEmailAsync(admin_email);

            // TODO WE need to set the admin's email as confirmed. The following code awaits confirmation from the user.
            // We should just set the bit directly.
            //// Confirm the admin's email
            //var emailConfirmationCode = await _userManager.GenerateEmailConfirmationTokenAsync(admin_user);
            //var confirmResult = await _userManager.ConfirmEmailAsync(admin_user, emailConfirmationCode);

            // The following was from before we switch to using claims.
            //// assign admin privileges. This adds and enty in table dbo.AspNetUserRoles
            //ApplicationUser admin = await userManager.FindByEmailAsync("info@example.com");
            //foreach (string role in roles)
            //{
            //    await userManager.AddToRoleAsync(admin, role);
            //}

            // assign admin privileges. This adds an entry in table AspNetUserClaims
            var claims = await _userManager.GetClaimsAsync(admin_user);
            var jobClaim = claims.FirstOrDefault(c => c.Type == "role");
            if (jobClaim == null)
            {
                await _userManager.AddClaimAsync(admin_user, new Claim("role", "Administrator"));
            }

            // TODO add error handling and return success/fail
            return true;
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
