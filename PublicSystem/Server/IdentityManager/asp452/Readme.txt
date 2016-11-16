This project is an interface to Microsoft Identity. It allows a admin user to:
 * See a list of current users
 * Add a new user
 * Edit an existing user's information: password, email, phone and settings, etc.
 * Add roles
 * Assign a role to a user
It uses Brock Allen's Identity Manager project on Github:
   https://github.com/IdentityManager/IdentityManager
Unfortunately, it is currently working on Asp.Net 4.5.2 and not Asp.Net 5. So we can
not integrate it into our Asp.Net 5 WebApp. Also, it uses Microsoft Identity 2 and 
our WebApp is using Microsoft Identity 3. There were changes in the structure of the
user table for MI 3. Otherwise, we would have been able to point this program at our
database and manage identities that way.
It may be possible to do the following:
  * Use MI 2 within our WebApp
  * Use Asp.Net Core so that we can still access the OWIN pipeline and therefore include
    the Identity Manager Github components. See the following discussion:
============	
https://www.scottbrady91.com/ASPNET-Identity/Identity-Manager-using-ASPNET-Identity#comment-2874280442
John Pankowicz  • 21 hours ago  
HI @Scott - I have Identity Manager working in an ASP.NET 4.5.2 app. But I need to manage identities for my ASP 5 app. There are many changes in the new version of Microsoft Identity. For example, the table layout for dbo.AspNetUsers has changed. 
Can you suggest a good way for me to proceed? Is it possible to get Identity Manager working in an ASP 5 app? If not is there another solution for managing identity in an ASP 5 app that I might not be aware of?

Scott Brady Mod > John Pankowicz  • 20 hours ago  
Unfortunately there's no IdentityManager for .NET Core and ASP.NET Core yet. This is something that will probably be done, just not any time soon.
Maybe look into an ASP.NET Core site running on .NET Framework, using ASP.NET Identity 2. If I recall correctly you can still access the OWIN pipeline in ASP.NET Core.
  
John Pankowicz > Scott Brady  • 19 hours ago  
Thanks @Scott -- But even if I got the component to work in the pipeline, wouldn't I hit a roadblock because of the changes to the user table format in the database?
 
Scott Brady Mod > John Pankowicz  • 6 hours ago  
You'd have to use ASP.NET Identity v2 still, including the database schema that comes with it. I'm unsure of ASP.NET Identity 3's compatibility with .NET Framework.
==============

This project was created as follows:
* Create a new Asp.Net 4.5.2 Web app, selecting MVC. We start with the template
	file created by Visual Studio and make changes.
* Add the new file:	App_Start\IdentityManagerConfig.cs
	This contains the method ConfigureIdentityManager(), within the partial class "Startup"
* Add the new file: Models\IdentityManagerModel.cs
	This contains the classes: ApplicationUserStore, ApplicationRoleStore, ApplicationRoleManager
	  & ApplicationIdentityManagerService
* Within startup.cs, add the call: ConfigureIdentityManager(app);
* Within IdentityConfig.cs
	replace occurances of IUserStore<ApplicationUser> with ApplicationUserStore
* Within Web.config, set the databse connection string to:
	"Data Source=(LocalDb)\MSSQLLocalDB;database=IdentityManagerTest;Integrated Security=True"
* Click on the project in Solution Explorer and in the Properties window:
	Set SSL Enabled = Enabled
	Copy the "SSL URL" and paste it into the "Project URL" box in the Web tab of the project's properties pages.