import { MeetingForView } from './meetingforview';

export class WorkProgress {
  locationId: number;
  meeting: MeetingForView;
  workitems: WorkItem[];
  volunteers: Volunteer[];
  locations: Location[];
}

export class WorkItem {
  workItemId: number; // unique ID for this work item.
  partId: number; // part number within the meeting.
  // If a meeting is split into 8 work items, this is a number from 1 to 8.
  isDone: boolean; // Is this work item finished.
  volunteerId: number; // ID of the volunteer who is working on this item.
  lastEdit: number;
  lastEditTime: string;
  length: number;
}

export class Volunteer {
  volunteerId: number; // Unique ID for this volunteer
  userName: string; // user chosen user name
  locationId: number; // Home location
  workItemId: number; // Item that the volunteer is currently working on.
}

export class Location {
  locationId: number;
  country: string;
  state: string;
  county: string;
  municipality: string;
}
