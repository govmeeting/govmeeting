###########################################
Asp.Net Web App and Angular App integration
###########################################


=== Copy JS, CS and assets files ===

Copy files from PublicSystem/Client/BrowserApp to PublicSystem/Server/WebApp:
	copy dist/prod/css/main.css to wwwroot/css
	copy dist/prod/js/app.js & shims.js to wwwroot/js
	copy dist/prod/assets/ to wwwroot


=== Modify views/home/index.cshtml ===


  The following replaces the original sample contents of this file:
			@{ ViewData["Title"] = "Home Page";	}
			<sd-app>Loading...</sd-app>

=== Modify views/shared/_Layout.cshtml ===

  ------------------
  reference css file
  ------------------

  The following css files get added to <environment names="Development"> in <head>
            <link rel="stylesheet" href="~/css/main.css">

  ---------------------
  Add 'module' function
  ---------------------

  <script>
  // Fixes undefined module function in SystemJS bundle
  function module() {}
  </script>


  ------------------
  reference js files
  ------------------

  The following js files get added to <environment names="Development"> in <body>
        <script src="~/js/shims.js?1463764236153"></script>
        <script src="~/js/app.js?1463764236155"></script>

###########################################
Combine BrowserApp & WebApp navigation bars
###########################################


=== Modify WebApp/Views/Shared/_Layout.cshtml ===

--- Replace links on left side ----

					 <ul class="nav navbar-nav">
	-                    <li><a asp-controller="Home" asp-action="Index">Home</a></li>
	-                    <li><a asp-controller="Home" asp-action="About">About</a></li>
	-                    <li><a asp-controller="Home" asp-action="Contact">Contact</a></li>
	+                    <li><a href="/">HOME</a></li>
	+                    <li><a href="/about">ABOUT</a></li>
	+                    <li><a href="/meeting">MEETING</a></li>
	+                    <li><a href="/addtags">ADD TAGS</a></li>
					 </ul>


=== Modify BrowserApp/src/client/app/app.component.html - for hiding app's navbar ===

	-<sd-toolbar></sd-toolbar>
	-<sd-navbar></sd-navbar>
	+<div class="hide-webapp">
	+    <sd-toolbar></sd-toolbar>
	+    <sd-navbar></sd-navbar>
	+</div>

=== Modify BrowserApp/src/client/css/main.css  - for hiding app's navbar ===

	+.hide-webapp{display: none}

THis hides the BrowserApp navbar. But while working in Visual Studio Code, we need to have
the navbar. A temporary solution is to 
(1) comment it out in main.css while using VS Code
(2) Uncomment it before running "npm run build.prod" 
    [OR]
    Run "npm run build.prod" and then add ".hide-webapp{display: none}" to the start
	of the generated dist/prod/css/main.css.

We need to create a task to modify the generated main.css automatically when
we run "npm run build.prod".


=== Modify startup.cs - add route definition ===


+                routes.MapRoute(
+                    name: "spa-fallback",
+                    template: "{*url}",
+                    defaults: new { controller = "Home", action = "index" });



###########################################################
Integrate developer configuration of BrowserApp with WebApp
###########################################################

The above integrations was for the production BrowserApp file -- those in BrowserApp/dist/prod.
The production files are just four: main.cs, app.js, shim.js and index.html.
The developer files are all of the individual css and js files, after any Less or Typescript transpiling
is done. Integrating these involves a bit more work.

=== Modify startup.cs and define the "ba" PhysicalFileProvider path. === 

	Define new PhysicalFileProvider for ...PublicSystem\Client\BrowserApp

=== Create seperate _LayoutDev.cshtml ===

Start by making it a copy of _Layout.cshtml.
Then copy the information from BrowserApp/dist/dev/index.html into the file:
	* All the .css and .js files that are included.
	* The system.config block 
	* Modify the paths to use the "ba" PhysicalFileProvider.

=== Modify .vs/config/applicationhost.config ==
	The following changes was made to the requestFiltering tag.
      <requestFiltering allowDoubleEscaping="true">
	Otherwise all the URLs in the app which contain a "+" character (+about, +addtags, etc) are rejected with a 404 error.

Later I combined _LayoutDev.cshtml with _Layout.cshtml and used the Production/Development environment setting.
The environment can be set in the WebApp project setting under Debug.
When the environment is Development, it diplays "Govmeeting (dev)" in the menu bar instead of "Govmeeting".


###########################################################
Use Visual Studio Task Runner to build BrowserApp project.
###########################################################


I added a binding in Task Runner Explorer. I bound build.dev.watch to Project Open.
When I ran this task from Task Runner Explorer, it failed. At the end of the output log, it displayed the
versions of node and Npm that it was using: node -v v0.10.31 and npm -v 1.4.9.
The versions that I have in a command window are: node -v v4.3.0 and npm -v 3.7.5.
I found this link to a post by Mads Kristensen on setting the versions to be used:
https://blogs.msdn.microsoft.com/webdev/2015/03/19/customize-external-web-tools-in-visual-studio-2015/
Go to Tools –> Options –> Projects and Solutions –> External Web Tools.
I moved $(PATH) to be above $(DevEnvDir)\Extensions\Microsoft\Web Tools\External.
This ensures that the global PATH is used before the path to VS's internal tools.

###########################################################
Fix Intellisense error for RxJs
###########################################################

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

Other onlne suggestions in were to upgrade node and npm to the latest version.
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
