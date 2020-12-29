using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DatabaseAccess
{
    /* NOT WORKING
     * Running "dotnet ef migrations add InitialCreate --verbose" gives this error:
     * "Startup project 'InfrastructureCore_Lib.csproj' targets framework '.NETStandard'. There is no runtime associated with this framework, and projects targeting it cannot be executed directly. To use the Entity Framework Core .NET Command-line Tools with this project, add an executable project targeting .NET Core or .NET Framework that references this project, and set it as the startup project using --startup-project; or, update this project to cross-target .NET Core or .NET Framework. For more information on using the Entity Framework Tools with .NET Standard projects, see https://go.microsoft.com/fwlink/?linkid=2034781"
     */

    /* This class is used during the design-time to obtain a DbContext, by some of the EF tools
     * commands, for example "ef add migrations" and "ef database update".
     * Its existence is optional. If not present, the tools will try to obtain the DbContext object 
     * from the application's service provider. The tools first try to obtain the service provider
     * by invoking Program.CreateHostBuilder(), calling Build(), then accessing the Services property.
     */
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    //{
    //    public ApplicationDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Govmeeting;Trusted_Connection=True;MultipleActiveResultSets=true");

    //        return new ApplicationDbContext(null, optionsBuilder.Options);
    //    }
    //}
}
