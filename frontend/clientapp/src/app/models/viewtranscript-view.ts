import { MeetingForView } from './meetingforview';

export class ViewTranscript {
  // meetingInfo: MeetingInfo;
  meeting: MeetingForView;
  topicNames: string[];
  speakerNames: string[];
  topicDiscussions: TopicDiscussion[];
}

export class TopicDiscussion {
  name: string; // change field name to "topicName".
  talks: Talk[];
}

export class Talk {
  Speaker: string;
  Text: string;
}
