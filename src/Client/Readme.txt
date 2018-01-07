This folder used to contain a "BrowserApp" project, which contained the client side Typescript/Angular code for the WebApp.
WebApp accessed this project by creating a PhysicalFileProvider
     in WebApp/Startup.cs which resolved to src\ClientBrowserApp.

But when BrowserApp was changed from using "angular-seed" to using "SpaTemplates", 
BrowserApp is moved to WebApp\ClientApp. This was just easiest at the time to
get the SpaTemplates version working.

We should working on moving the client-side code back into its own folder and project.