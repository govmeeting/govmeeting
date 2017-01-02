# WebApp files

## Configuration (startup.cs)

We define where to find the BrowserApp files.
```
	  // Path to browser ap is ...PublicSystem\Client\BrowserApp
		string browserAppPath = s.Substring(0, i) + @"\Client\BrowserApp"; 
	app.UseStaticFiles(new StaticFileOptions()
	{
		FileProvider = new PhysicalFileProvider(browserAppPath),
			RequestPath = new PathString("/ba")
	});
```

## Home Controller (Controllers\HomeController.cs)

Index Action returns the Index view, which will also display the shared layouts.

	public IActionResult Index() { return View(); }
	
## Shared layout (Views\Shared\_Layout.cshtml)

It loads in the CSS files

	production
		server's bootstrap.min.css & site.min.css
		client's main.css from dist\prod\css
	development
		server's bootstrap.css & site.css
		client's dist\dev\css\main.css
		
It defines the main navbar

```
<ul class="nav navbar-nav">
	<li><a href="/">HOME</a></li>
	<li><a href="/about">ABOUT</a></li>
	<li><a href="/meeting">MEETING</a></li>
	<li><a href="/addtags">ADD TAGS</a></li>
</ul>
```
	
It loads the javascript files

	production
		server's jquery-2.1.4.min.js, bootstrap.min.js & site.min.js 
		client's ba\dist\prod\js\shims.js & ba\dist\prod\js\app.js
	development
		client's shim.min.js & system.src.js
			System.config({ ....
		server's jquery.js, bootstrap.js & site.js
		client's zone.js, Rx.js
			System.import('ba/dist/dev/app/main')
			
Note that in production, we only need to load "app.js". Within this:
	We will find system.src.js, zone.js & Rx.js
	We will call "System.config" & "System.import"
	System.import executes the code in main.ts (see below)
					 
		
## Shared login layout (Views\Shared\_LoginPartial.cshtml)

It defines the account navbar.
```
<ul class="nav navbar-nav navbar-right">
	@*<li><a asp-controller="Admin" asp-action="Index">Admin</a></li>*@
	<li><a asp-controller="Account" asp-action="Register">Register</a></li>
	<li><a asp-controller="Account" asp-action="Login">Log in</a></li>
</ul>
```

## Home Index view (Views\Home\Index.cshtml)

This contains the app's main tag

	<sd-app>Loading...</sd-app>

	
# BrowserApp files

    For prod, these files are all included in the bundled file ba\dist\prod\js\app.js	
    For dev, they are retreived from under "\ba\src\client\app\".
	
## Boot the main Angular component (ba/src/client/app/main.ts)

```	
bootstrap(AppComponent, [
  disableDeprecatedForms(),
  provideForms(),
// provide('Name', {useValue: params.name}),
  APP_ROUTER_PROVIDERS,
  {
	provide: APP_BASE_HREF,
	useValue: '<%= APP_BASE %>'
  }
]);
```


