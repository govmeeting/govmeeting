## Mobile App that uses voice commands to fix errors

The <a [routerLink]="['/fixasr']">Fix ASR</a> page shows a program for
correcting errors in the generated text.
A user needs to TYPE the corrections. This new feature would allow a user to SPEAK the corrections.
A user would listen to the meeting and watch the scrolling generated text. At any time, they could
SPEAK a correction.

For example, suppose they hear "The street will be <b>paid</b> next week.". They could speak the correction
by saying "will be <b>paved</b>". The software will use the start and/or ending words of the spoken correction
as the "context" of the change. It this case, it would find "will be" in the immediate prior text and substitute
the non-matching word "paved".

"Speech recognition" is recognition of words of a single speaker. For a computer, this is much easier than conversional "voice recognition".
The error rate for the spoken corrections should be much less than that of the original transcription.

Users could use this method on smartphones and other mobile devices without keyboards.

## App or component to enlist proofreading help </h3>

Create a way for communites to use outside help proofreading voice recognition text. <br/>
See <a href="https://github.com/govmeeting/govmeeting/issues/69">Github issue #69</a>
