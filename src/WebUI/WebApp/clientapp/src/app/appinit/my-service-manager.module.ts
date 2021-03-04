import { ModuleWithProviders, NgModule } from "@angular/core";
import { AppInitService } from "./appinit.service";
import { MyServiceLoader } from "./my-service-loader";
import { MyService } from "./myservice";
import { MyServiceStub } from "./myservice-stub";

// this factory needs AppInitService to know if our web server is running
// in order to select our service
export function myServiceFactory(
  appInitService: AppInitService
): MyService | MyServiceStub {
  return appInitService.isRunning ? new MyService() : new MyServiceStub();
}

@NgModule()
export class MyServiceManagerModule {
  static forRoot(): ModuleWithProviders<MyServiceManagerModule> {
    return {
      ngModule: MyServiceManagerModule,
      providers: [
        // our service factory
        {
          provide: MyServiceLoader,
          useFactory: myServiceFactory,
          deps: [AppInitService]
        }
      ]
    };
  }
}
