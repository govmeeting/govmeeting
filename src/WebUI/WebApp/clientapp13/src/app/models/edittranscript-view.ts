// import { AutoMap } from '@automapper/classes';

// This is the JSON format of the text to be tagged

export class EditTranscript {
  sections: string[] = [];
  topics: string[] = [];
  talks: Talk[] = [];
}

export class Talk {
  speaker: string = '';
  said: string = '';
  section: string = '';
  topic: string = '';
  showSetTopic: boolean = false;
  confidence: number = 0;
  wordcount: number = 0;
  words: Word[] = [];
  captions: [Caption] | null = null;
}

export class Word {
  word: string = '';
  confidence: number = 0;
  starttime: number = 0;
  endtime: number = 0;
  speaker: number = 0;
  wordnum: number = 0;
}

export class Caption {
  Id: number = 0;
  text: string = '';
  hilite: boolean = false;
}

export class PlayPhraseData {
  start: number = 0;
  duration: number = 0;
}
