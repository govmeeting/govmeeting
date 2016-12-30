# Asp.Net Web App and Angular App integration
			
## Changes to WebApp to serve up the BrowserApp distribution files.

### Copy JS, CS and assets files

Copy files from PublicSystem/Client/BrowserApp to PublicSystem/Server/WebApp:

    copy dist/prod/css/main.css to wwwroot/css
    copy dist/prod/js/app.js & shims.js to wwwroot/js
    copy dist/prod/assets/ to wwwroot

### Modify views/home/index.cshtml

The following replaces the original sample contents of this file:

    @{ ViewData["Title"] = "Home Page";	}
    <sd-app>Loading...</sd-app>

### Modify views/shared/_Layout.cshtml

BrowserApp/dist/prod/index.html is built from BrowserApp/src/client/index.html.
We copy the JS & CSS references from this file to _Layout.cshtml
We also include some specific script element contents over.
These get added for environment "Production"

#### reference css file

The following css files get added to the "Production" section in  "head"

    <link rel="stylesheet" href="~/css/main.css">

#### Add 'module' function

	<script>
	// Fixes undefined module function in SystemJS bundle
	function module() {}
	</script>

#### reference js files

The following js files get added to the "Prodduction" section  in body.

	<script src="~/js/shims.js?1463764236153"></script>
	<script src="~/js/app.js?1463764236155"></script>
    
# Integrate developer configuration of BrowserApp with WebApp

The above integration is for the production BrowserApp files -- those in BrowserApp/dist/prod.
The production files are just four: main.cs, app.js, shim.js and index.html. We integrated the
production files by copying the processed files into WebApp/wwwroot.
We do NOT want to do the same for the all the source files.

For development we want to use the original source files in BrowserApp before there is any
minification, ulglification and combining of files.

The developer files are all the individual css and js files, after any Less or Typescript transpiling
is done.  Normally the web server will only allow access to
files that are under wwwroot. But we can modify startup.cs and define a new "PhysicalFileProvider". We point
this provider at the BrowserApp source file folder.

### Modify startup.cs and define the "ba" PhysicalFileProvider path.

	// Add a PhysicalFileProvider for the BrowserApp folder.
	... set "browserAppPath" to location of BrowserApp source files ...
	app.UseStaticFiles(new StaticFileOptions()
	{
		FileProvider = new PhysicalFileProvider(browserAppPath),
			RequestPath = new PathString("/ba")
	});

### Modify views/shared/_Layout.cshtml

BrowserApp/dist/dev/index.html is also built from BrowserApp/src/client/index.html.
We copy the JS & CSS references from this file to _Layout.cshtml
We also include some specific script element contents over.
These get added for environment "Development"

* All the .css and .js files that are included.
* The system.config block 
* Modify the paths to use the "ba" PhysicalFileProvider.

## Modify .vs/config/applicationhost.config

The following changes was made to the requestFiltering tag.

	<requestFiltering allowDoubleEscaping="true">
	
Otherwise all the URLs in the app which contain a "+" character (+about, +addtags, etc) are rejected with a 404 error.

Later I combined _LayoutDev.cshtml with _Layout.cshtml and used the Production/Development environment setting.
The environment can be set in the WebApp project setting under Debug.
When the environment is Development, it diplays "Govmeeting (dev)" in the menu bar instead of "Govmeeting".

# Combine BrowserApp & WebApp navigation bars

The WebApp has its own navbar. On the right side are the Register and Login links.
The BrowserApp has its navbar with all the links on the left for the Single Page Application.
We modify the WebApp navbar to include the SPA links and hide the BrowerApp's navbar when the WebApp
is serving the pages.

This approach allow us to code and debug the BrowserApp separately without needing a server.
For example, we can load the BrowserApp folder in Visual Studio Code. 

## Modify WebApp/Views/Shared/_Layout.cshtml

### Replace links on left side of navbar ----

	<ul class="nav navbar-nav">
	- <li><a asp-controller="Home" asp-action="Index">Home</a></li>
	- <li><a asp-controller="Home" asp-action="About">About</a></li>
	- <li><a asp-controller="Home" asp-action="Contact">Contact</a></li>
	+ <li><a href="/">HOME</a></li>
	+ <li><a href="/about">ABOUT</a></li>
	+ <li><a href="/meeting">MEETING</a></li>
	+ <li><a href="/addtags">ADD TAGS</a></li>
	</ul>

##  Modify BrowserApp/src/client/app/app.component.html - for hiding app's navbar

	-<sd-toolbar></sd-toolbar>
	-<sd-navbar></sd-navbar>
	+<div class="hide-webapp">
	+    <sd-toolbar></sd-toolbar>
	+    <sd-navbar></sd-navbar>
	+</div>

### Modify WebApp/wwwroot/css/site.css

	+.hide-webapp{display: none}

This hides the BrowserApp navbar when the BrowserApp is being served by WebApp.
While working in Visual Studio Code, we have the SPA navbar, but without the Register and Login links that
are added by WebApp.

### Modify startup.cs - add route definition

    +  routes.MapRoute(
    +    name: "spa-fallback",
    +    defaults: new { controller = "Home", action = "index" });

This is for Angular SPA routes. When someone does a browser refresh or uses a 
bookmark that's a deep link into the SPA, a request is sent to the server, instead
of being handled by the SPA. The server does not find a controller for this route
and returns a 404, Not Found. This map route redirects the request immediately to
the index page of the Home controller. This returns the page containing the SPA. Once
the SPA is running, it sees the URL that is being requested and handles it properly.

# Use Visual Studio Task Runner to build BrowserApp project.

This will watch for any code changes within the BrowserApp and automatically run the build.

I added a binding in Task Runner Explorer. I bound build.dev.watch to Project Open.
When I ran this task from Task Runner Explorer, it failed. At the end of the output log, it displayed the
versions of node and Npm that it was using: node -v v0.10.31 and npm -v 1.4.9.
The versions that I have in a command window are: node -v v4.3.0 and npm -v 3.7.5.
I found this link to a post by Mads Kristensen on setting the versions to be used:
https://blogs.msdn.microsoft.com/webdev/2015/03/19/customize-external-web-tools-in-visual-studio-2015/
Go to Tools –> Options –> Projects and Solutions –> External Web Tools.
I moved $(PATH) to be above $(DevEnvDir)\Extensions\Microsoft\Web Tools\External.
This ensures that the global PATH is used before the path to VS's internal tools.

An alternate method is to not use Task Runner and instead run the build.dev.watch task from the command line:

	C:\Govmeeting>cd C:\Govmeeting\PublicSystem\Client\BrowserApp
	C:\Govmeeting\PublicSystem\Client\BrowserApp>npm run build.dev.watch

# Fix Intellisense error for RxJs

There were many Intellisense errors for all methods from RxJs. For example:

	Error	TS2339	Property 'of' does not exist on type 'typeof Observable'.
	
There was a red squiggly under node_modules/rxjs. Hovering over it, showed many errors saying:

	Invalid module name in  Augmentation ...
	
Here are links about this problem:

	https://github.com/ReactiveX/rxjs/issues/1696
	
It appears thatthat VS uses a different version of node/npm than that installed globally and
the version that is being used by the angular2-seed tools and used when developing in VS Code.
To change this we need to 
* go to the project's Options -> Project and Solutions -> External Tools
* Add a new entry and move it to the top "C:\Program Files\nodejs".

I tried this and it did not solve the problem.

Other onlne suggestions were to upgrade node and npm to the latest version.
http://josharepoint.com/2016/05/04/how-to-configure-visual-studio-2015-integration-with-latest-version-of-node-js-and-npm/
I installed the latest versions: npm 3.10.3 and node v6.3.0.
This also did not solve the problem.

The Typescript intellisense must depend on the version of the Typescript compiler that VS is using.
This link has the typescript downloads for VS2015:

	https://www.microsoft.com/en-us/download/details.aspx?id=48593
	
I downloaded Typescript 1.8.6 and installed it.
This link shows how to see which version is being used:

	http://stackoverflow.com/questions/35715015/where-is-the-typescript-tools-version-set-in-an-asp-net-5-project
	
It is in C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\TypeScript\Microsoft.TypeScript.targets
Mine now shows: <TypeScriptToolsVersion Condition="'$(TypeScriptToolsVersion)'==''">1.8</TypeScriptToolsVersion>
This change also did not solve the problem.

I drilled down into squiggly lines under node_modules/rsjs/
It took me to node_modules/rsjs/add/observable/of.d.ts and other files with the red lines.
I opened a few files to look inside and then !MAGIC!, the red squiggly lines disappeared.
If I reopened a certain file they came back. At a moment when they were gone, I closed the node_modules
folder. They seem to be staying away for now.
The problem returned.

I found this solution:

	https://github.com/Microsoft/TypeScript/issues/8518#issuecomment-229506507
	
The solution is: "For VS 2015 (Update 3):

	Install VS 2015 Update 3
	Replace C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TypeScript\typescriptServices.js
	with the file in https://raw.githubusercontent.com/Microsoft/TypeScript/Fix8518-U3/lib/typescriptServices.js.
	First take a local backup though."
