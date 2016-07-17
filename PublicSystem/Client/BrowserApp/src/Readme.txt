This folder "src" contains the user application. All of the other files and folders are part of the
angular2-seed Github project: https://github.com/mgechev/angular2-seed. angular2-seed contains the
tooling that allows us to develop in a very modular fashion. The tasks in the tools folder processes
all of the individual folders and generates a very compact production set of files. Normally the
final files are only a single index.html, a main.js, a shim.js and a single main.css file.

The configuration for the tools is in tools/config/seed.config.ts. And project specific configuration
goes into tools/config/project.config.ts.

==============================
Updating angular2-seed
==============================
Updating to a newer version of angular2-seed normally means three steps:
 (1) downloading the latest Github release
 (2) substituting the src folder with our own.
 (3) substituting tools/config/project.config.ts with our own.

However I left the sample app that comes with angular2-seed in the src folder. When a new version of angular2-seed
comes out, the sample gets updated. It helps to have examples of how to use any changed features.
The sample also represents the best current practices as Angular 2 keeps changing.

Therefore we have these additional steps.
 (4) Copy the following folders from the new released version of angular2-seed into src:
	src\client\app\+about  - sample about page
	src\client\app\+home  - sample page with a form
	src\client\app\shared/name-list  - used by +home
	src\client\app\shared/navbar
	src\client\app\shared/toolbar
	[ navbar & toolbar are only used when developing with VS Code. When run in production or when developing
	  with VS, the navbar in the WebApp's _layout.cshtml is used. ]
 (5) Combine our links and that of Angular2-seed in src/shared/navbar/navbar.component.html.
 (6) Modify src\client\app\+home\home.routes.ts and change "path" to '/sample'. This prevents the sample app from
     being the actual home page. We can still get to the sample by typing "sample" in the address bar.


=======================================
Adding our own external dependencies 
=======================================
(See github.com/mgechev/angular2-seed/wiki/Add-external-scripts-and-styles)

For example, to add bootstrap:

Step 1 - Install bootstrap.
	npm install bootstrap --save

Step 2 - Declare the bootstrap.min.css and bootstrap.min.js file as injectable in ./tools/config/project.config.ts.
    Add these lines to the this.NPM_DEPENDENCIES array:
	  {src: 'bootstrap/dist/js/bootstrap.min.js', inject: 'libs'},
	  {src: 'bootstrap/dist/css/bootstrap.min.css', inject: true}, // inject into css section

However later I replaced bootrap with bootrap-grid-only

* I ran the following:
	npm install bootstrap-grid-only --save
* I replaced the two lines above for bootstrap in project.config.ts with:
	{src: 'bootstrap-grid-only/bootstrap.css', inject: true} // inject into css section

==============================
New Angular2 routing method
==============================

I downloaded the latest angular2seed on 2016-07-08. I got errors after the install. This was
because the latest angular2seed uses the newer routing method in angular 2. The new way is to
bootstrap our app with an array of routes using the provideRouter function. 
Angular2seed also added a config service in app\shared\config.

Each routable component folder now has a "<name>.routes.ts" file. And there is a "app.routes.ts"
file in /app.

I modified app\app.routes.ts and added this:
  at top:
	import { AddtagsRoutes } from './+addtags/index';
	import { MeetingRoutes } from './+meeting/index';
  in RouterConfig array: 
	...AddtagsRoutes,
	...MeetingRoutes

To add routing for AddtagsComponent, I did the following:
(1) I created a new file src/client/app/+addtags/addtags.routes.ts
 with the following:
	import { RouterConfig } from '@angular/router';
	import { AddtagsComponent } from './index';
	export const AddtagsRoutes: RouterConfig = [
	  {
	    path: 'addtags',
	    component: AddtagsComponent
	  }
	];
(2) I added the following to src/client/app/+addtags/index.ts:
	export * from './addtags.routes';

I did the same thing for MeetingComponent.