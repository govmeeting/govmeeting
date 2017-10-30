# The "matsamp" folder contains a sample of using Angular Material

This sample is from:
https://progblog.io/Angular-2-Tutorial-Create-an-App-With-Angular-CLI-and-Angular-Material-Design/

His steps were:

> npm install -g angular-cli
> ng new my-project-name
> cd my-project-name
> ng serve

Open your browser and point it to http://localhost:4200

> npm install --save @angular/material

Add to app.module.ts:

> import { MaterialModule } from '@angular/material';  
> MaterialModule.forRoot()        // add to imports array  

Add link for icons in index.html:
```
<link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
```

Add material elements to app.component.html

```
<md-sidenav-layout [class.m2app-dark]="isDarkTheme">
  <md-sidenav #sidenav mode="side" class="app-sidenav">
    Sidenav
  </md-sidenav>
  .. etc ...
``` 


Add CSS styles to app.component.css
```
md-sidenav-layout.m2app-dark {
  background: black;
}
... etc ...
```

Add application wide styles in styles.css:
```
  body {
    margin: 0;
  }
```

Create a custom theme in src/assets/custom-theme.scss:
```
@import '~@angular/material/core/theming/all-theme';
@include md-core();

$primary: md-palette($md-light-blue);
$accent:  md-palette($md-amber, A200, A100, A400);
... etc ...
```

Reference the style sheets in angular-cli.json:
```
  "styles": [
        "styles.css",
     	 "./assets/custom-theme.scss"
      ],
```

## Angular-seed integration

https://github.com/mgechev/angular-seed/wiki/Integration-with-AngularMaterial2

1. Add the NPM packages.

> npm install --save @angular/material


2. Add pre-built material theme to be injected/bundled in project.config.ts.
```
    this.NPM_DEPENDENCIES = [
      ...this.NPM_DEPENDENCIES,
      /* Select a pre-built Material theme */
         {src: '@angular/material/core/theming/prebuilt/indigo-pink.css', inject: true}
    ];
```

3. Add Material configuration to SystemJS in project.config.ts.
```
   this.addPackageBundles({
     name:'@angular/material',
     path:'node_modules/@angular/material/bundles/material.umd.js',
     packageMeta:{
       main: 'index.js',
       defaultExtension: 'js'
     }
   });
```

4. Import the Angular Material NgModule.
```
import { MaterialModule } from '@angular/material';
// other imports 
@NgModule({
  imports: [ MaterialModule.forRoot() ],
  ...
})
export class FooAppModule { }
```

## Errors

I get the following error in the F12 console window in Chrome:

    material.umd.js:3258 Could not find HammerJS. Certain Angular Material components may not work correctly.

I did the following but I still get the error:
> mpm install hammerjs


# Upgrade to latest Angular Material 2017-10-29

This upgrade was done concurrent with switching from using angular-seed to angular-cli.
Material was installed new using the instructions on: 
https://material.angular.io/guide/getting-started

  Install npm modules:
    npm install --save @angular/material @angular/cdk

    npm install --save angular/material2-builds angular/cdk-builds

    npm install --save @angular/animations

  Include in app:
    import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
    ...
    @NgModule({
      ...
      imports: [BrowserAnimationsModule],

  MaterialModule, which previously included all the Material sub-modules, was deprecated.
  A local "MaterialsModule" was created which includes all of the Material modules. This was included
  in the MatsampModule (the sample Material code).

  Add to style.css:
    @import "~@angular/material/prebuilt-themes/indigo-pink.css";

  Some components (mat-slide-toggle, mat-slider, matTooltip) rely on HammerJS for gestures.
  These require the following (but I did not do this yet):
    Install npm module
      npm install --save hammerjs
    Add to src/main.ts
      import 'hammerjs';

  If we want the Material Design Icons, we will need to add this to index.html:
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">