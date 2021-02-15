// import { AutoMap } from '@automapper/classes';

// This is the JSON format of the text to be tagged

export class EditTranscript {
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
  confidence: number;
  wordcount: number;
  words: Word[];
}

export class Word {
  word: string;
  confidence: number;
  starttime: number;
  endtime: number;
  speaker: number;
  wordnum: number;
}
