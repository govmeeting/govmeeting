## Get debugging working

Currently I am trying to get debugging working. I could not do so in the full BrowserApp project so I am
trying with some smaller projects in F:\GOVMEETING\CODE\EXPERIMENTS\VsCode Debugging
	angular2-tour-of-heroes-master is a copy from F:\GOVMEETING\CODE\SAMPLES\angular2-tour-of-heroes-master.
	
The lastest version of angular-seed had fixes to get debugging working in VSCode. I downloaded this and now I
am moving my code over to the new version.



## Pass a value into the angular app that indicates whether we are running standalone or with the WebApp

### changes to index.html 	

// Modify system.import call

//System.import('<%= BOOTSTRAP_MODULE %>').then(
//  module =>
//    module.main(
//      {
//        name: "notasp"
//      }
//  ).catch(function (e) {
//    console.error(e,
//      'Report this error at https://github.com/mgechev/angular2-seed/issues');
//  });
  
  
### changes to app/main.ts

// Modify bootstrap call

// export function main(params) {
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
// }

// The commented out code above is for injecting a variable "Name" into the Angular app.
// This is for the purpose of telling whether BrowserApp is running inside of the ASP.NET server
// or if it is running alone. IT would be running alone while developing within VsCode. When it is running
// alone, it will not call the Web Api to get data, but will instead use test data files. 

// // To use the Name provider in some component:
// export class SomeComponent {
//    constructor(@Inject('Name') public username: string) {
//    }
//
// The above code needs to go in backend.service.ts and talks.service.ts

// Notes from stackoverflow:
//
// This seems a soluton to passing a constant to the angular app with value "NotRunningInAspNet"
// http://stackoverflow.com/questions/37312018/pass-constant-values-to-angular-2-from-layout-cshtml/37384567#37384567
// or this:
// http://stackoverflow.com/questions/37337185/passing-asp-net-server-parameters-to-angular-2-app

// In order to start the Service Worker located at "./worker.js"
// uncomment this line. More about Service Workers here
// https://developer.mozilla.org/en-US/docs/Web/API/Service_Worker_API/Using_Service_Workers
//
// if ('serviceWorker' in navigator) {
//   (<any>navigator).serviceWorker.register('./worker.js').then((registration: any) =>
//       console.log('ServiceWorker registration successful with scope: ', registration.scope))
//     .catch((err: any) =>
//       console.log('ServiceWorker registration failed: ', err));
// }
