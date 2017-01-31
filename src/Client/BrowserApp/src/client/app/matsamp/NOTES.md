# This folder contains a sample of using Angular Material

## progblog sample

This info is from:
https://progblog.io/Angular-2-Tutorial-Create-an-App-With-Angular-CLI-and-Angular-Material-Design/

His steps were:

> npm install -g angular-cli
> ng new my-project-name
> cd my-project-name
> ng serve

Open your browser and point it to http://localhost:4200

> npm install --save @angular/material

Add to app.module.ts:
  import { MaterialModule } from '@angular/material';
  MaterialModule.forRoot()        // add to imports array

Add to index.html:
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">

Add material elements to app.component.html

Add CSS styles to app.component.css

Add to styles.css: (for whole app)
  body {
    margin: 0;
  }

Create the file src/assets/custom-theme.scss with our custom theme
Add to angular-cli.json:
  "styles": [
        "styles.css",
     	 "./assets/custom-theme.scss"
      ],


## Angular-seed integration

https://github.com/mgechev/angular-seed/wiki/Integration-with-AngularMaterial2

1. Add the NPM packages.
npm install --save @angular/material


2. Add pre-built material theme to be injected/bundled in project.config.ts.
    this.NPM_DEPENDENCIES = [
      ...this.NPM_DEPENDENCIES,
      /* Select a pre-built Material theme */
         {src: '@angular/material/core/theming/prebuilt/indigo-pink.css', inject: true}
    ];


3. Add Material configuration to SystemJS in project.config.ts.
   this.addPackageBundles({
     name:'@angular/material',
     path:'node_modules/@angular/material/bundles/material.umd.js',
     packageMeta:{
       main: 'index.js',
       defaultExtension: 'js'
     }
   });


4. Import the Angular Material NgModule.
import { MaterialModule } from '@angular/material';
// other imports 
@NgModule({
  imports: [ MaterialModule.forRoot() ],
  ...
})
export class FooAppModule { }

## Errors

I get the following error in the F12 console window in Chrome:
    material.umd.js:3258 Could not find HammerJS. Certain Angular Material components may not work correctly.

I did the following but I still get the error:
> mpm install hammerjs