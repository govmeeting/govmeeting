// This is the JSON format of the text to be tagged

export class Addtags {
  sections: string[];
  topics: string[];
  talks: Talk[] | null;
}

export class Talk {
  speaker: string | null;
  said: string;
  section: string | null;
  topic: string | null;
  showSetTopic: boolean;
}
