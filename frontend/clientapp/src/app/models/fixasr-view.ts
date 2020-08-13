// This is the JSON format of the text to be fixed.

export class FixasrView {
  lastedit: number;
  asrsegments: AsrSegment[];
}

export class AsrSegment {
  startTime: string;
  said: string;
}
