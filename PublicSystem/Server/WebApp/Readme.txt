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

=== Create seperate _LayoutDev.cshtml ===

[Later we need to combine this with _Layout.cshtml and use the Production/Development environment setting.]


