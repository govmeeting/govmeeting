import { Injectable } from '@angular/core';
import { VideoService } from './video.service';

const NoLog = true; // set to false for console logging

// TODO - Use the server API to return the video.
// Until then we need to specify the full path of the video file.
// var location: string = 'api/video/3/1';  // This would be for MeetingID=3 Part=1

@Injectable()
export class VideoServiceReal implements VideoService {
  private ClassName: string = this.constructor.name + ': ';

  getLocation(): string {
    // throw new Error('Method not implemented.');

    const location = 'datafiles/PROCESSING/USA_ME_LincolnCounty_BoothbayHarbor_Selectmen_en/2017-02-15/Edit/part01/';
    const fileBasename = 'ToEdit';

    NoLog || console.log(this.ClassName + 'location=' + location);

    return location;
  }

  getFileBasename(): string {
    const fileBasename = 'ToEdit';
    return fileBasename;
  }
}
