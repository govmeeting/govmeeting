export * from './editMeeting.service';
import { EditMeetingService } from './editMeeting.service';
export * from './govLocation.service';
import { GovLocationService } from './govLocation.service';
export * from './govbody.service';
import { GovbodyService } from './govbody.service';
export * from './healthCheck.service';
import { HealthCheckService } from './healthCheck.service';
export * from './video.service';
import { VideoService } from './video.service';
export * from './viewMeeting.service';
import { ViewMeetingService } from './viewMeeting.service';
export * from './weatherForecast.service';
import { WeatherForecastService } from './weatherForecast.service';
export const APIS = [EditMeetingService, GovLocationService, GovbodyService, HealthCheckService, VideoService, ViewMeetingService, WeatherForecastService];
