using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    // Class to inialize the database with the first admin user. See:
    // https://stackoverflow.com/questions/40027388/cannot-get-the-usermanager-class/40046290#40046290
    public static class DbInitializer
    {
        static Data.ApplicationDbContext context;
        static UserManager<Models.ApplicationUser> userManager;
        static RoleManager<IdentityRole> roleManager;
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
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

            // Create roles
            string[] roles = new string[] { "UserManager", "StaffManager" };
            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create admin user
            if (!context.Users.Any())
            {
                await userManager.CreateAsync(new ApplicationUser() { UserName = "info@example.com", Email = "info@example.com" }, "p@ssw0rd");
            }

            // Ensure admin privileges
            ApplicationUser admin = await userManager.FindByEmailAsync("info@example.com");
            foreach (string role in roles)
            {
                await userManager.AddToRoleAsync(admin, role);
            }
        }
    }
}
