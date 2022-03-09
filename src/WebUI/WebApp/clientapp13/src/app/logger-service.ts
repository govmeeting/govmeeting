import { ReplaySubject } from 'rxjs';

// This code is for debugging timing issues with services.
// It lets us see console output messages without using Chrome Dev tools (which may affect out timing issues).
// See comments at end of app.component.ts for futher information.

export let replaySubjectLog = new ReplaySubject(99);
replaySubjectLog.next('logger-service. The first replay msg sent.');
