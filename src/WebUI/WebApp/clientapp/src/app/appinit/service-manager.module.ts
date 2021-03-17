import { ModuleWithProviders, NgModule } from '@angular/core';
import { AppInitService } from './appinit.service';
import { MyService } from './my-service';
import { MyServiceReal } from './my-service-real';
import { MyServiceStub } from './my-service-stub';
import { EditTranscriptServiceReal } from '../features/edittranscript/edittranscript.service-real';
import { EditTranscriptServiceStub } from '../features/edittranscript/edittranscript.service-stub';
import { HttpClient } from '@angular/common/http';
import { ErrorHandlingService } from '../common/error-handling/error-handling.service';
import { AppData } from '../appdata';
import { RegisterGovBodyService } from '../features/register-gov-body/register-gov-body.service';
import { RegisterGovBodyServiceStub } from '../features/register-gov-body/register-gov-body.service-stub';
import { RegisterGovBodyServiceReal } from '../features/register-gov-body/register-gov-body.service-real';
import { GovbodyMapper } from '../models/govbody-mapper';
import { GovbodyClient, GovLocationClient } from '../apis/api.generated.clients';
import { ViewTranscriptServiceReal } from '../features/viewtranscript/viewtranscript.service-real';
import { ViewTranscriptServiceStub } from '../features/viewtranscript/viewtranscript.service-stub';
import { VideoService } from '../common/video/video.service';
import { VideoServiceReal } from '../common/video/video.service-real';
import { VideoServiceStub } from '../common/video/video.service-stub';
import { EditTranscriptService } from '../features/edittranscript/edittranscript.service';

// The factories need AppInitService to know if our web server is running
// in order to select our services.

// This is a sample service factory for developing this module
function myServiceFactory(appInitService: AppInitService, httpClient: HttpClient): MyServiceReal | MyServiceStub {
  return appInitService.isRunning ? new MyServiceReal(httpClient) : new MyServiceStub();
}

export function editMeetingServiceFactory(
  appInitService: AppInitService,
  appData: AppData,
  httpClient: HttpClient,
  errHandling: ErrorHandlingService
): EditTranscriptService {
  return appInitService.isRunning
    ? new EditTranscriptServiceReal(httpClient, errHandling)
    : new EditTranscriptServiceStub(appData, httpClient, errHandling);
}

export function RegisterGovBodyServiceFactory(
  appInitService: AppInitService,
  govbodyClient: GovbodyClient,
  govLocationClient: GovLocationClient
): RegisterGovBodyService {
  return appInitService.isRunning
    ? new RegisterGovBodyServiceReal(govbodyClient, govLocationClient)
    : new RegisterGovBodyServiceStub();
}

export function VideoServiceFactory(appInitService: AppInitService): VideoService {
  return appInitService.isRunning ? new VideoServiceReal() : new VideoServiceStub();
}

// TODO "isAspServerRunning" should be removed and we should reley only on what AppInitService finds.
const isAspServerRunning = false; // Is the Asp.Net server running?
const isBeta = false; // Is this the beta release version?
const isLargeEditData = false; // Are we using the large data for EditTranscript? (Little Falls, etc.)

@NgModule()
export class ServiceManagerModule {
  static forRoot(): ModuleWithProviders<ServiceManagerModule> {
    return {
      ngModule: ServiceManagerModule,

      providers: [
        {
          provide: MyService,
          useFactory: myServiceFactory,
          deps: [AppInitService, HttpClient],
        },
        {
          provide: AppData,
          useValue: { isAspServerRunning, isBeta, isLargeEditData },
        },
        {
          provide: EditTranscriptService,
          useFactory: editMeetingServiceFactory,
          deps: [AppInitService, AppData, HttpClient, ErrorHandlingService],
        },
        {
          provide: ViewTranscriptServiceReal,
          useClass: isAspServerRunning ? ViewTranscriptServiceReal : ViewTranscriptServiceStub,
        },
        {
          provide: RegisterGovBodyService,
          useFactory: RegisterGovBodyServiceFactory,
          deps: [AppInitService, GovbodyClient, GovLocationClient],
        },
        {
          provide: VideoService,
          useFactory: VideoServiceFactory,
          deps: [AppInitService],
        },
      ],
    };
  }
}
