// NOTE: This is prior code for proofreading the transcription.
// It is being replaced by the EditTranscript module.

// This is the JSON format of the text to be fixed.

export class FixasrView {
  lastedit: number;
  asrsegments: AsrSegment[];
}

export class AsrSegment {
  startTime: string;
  said: string;
}
