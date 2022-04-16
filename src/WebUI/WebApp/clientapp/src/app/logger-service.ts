import { ReplaySubject } from 'rxjs';

  //////////////////////////////////////////////////
  // The code below is for debugging timing issues with services.
  // It lets us see console output messages without using Chrome Dev tools (which may affect timing issues).

  // In order to use this code:
  // To app.component.ts,
  //    Add:
  //        import { replaySubjectLog, addLogMessageWithTime } from './logger-service';
  //    Add:
  //        ngOnInit() {
  //          // Subscribe to the replaySubjectLog service.
  //          // "replaySubjectLog.next" writes a message to the <ul> list.
  //          let msg = 'AppComponent:ngOnInit. Enter';
  //          addLogMessageWithTime(msg);
  //          replaySubjectLog.subscribe((data) => this.addLogMessageWithTime('' + data));
  //          replaySubjectLog.next('AppComponent:ngOnInit. Talking to myself after subscribing.');
  //        }
  //    Add OnInit to the "implements" list of AppComponent.
  //  Add the following to some html:
  //        <ul id="replaySubjectLogOutput"></ul>
  //     The log messages will be displayed in this element.
  //     I added it in place of <router-outlet></router-outlet> in app.component.html,
  //       since I didn't need the dashboard UI.
  //  Wherever you want to displayed a message with time, call:
  //      replaySubjectLog.next("some message")


  export let replaySubjectLog = new ReplaySubject(99);
  export function addLogMessageWithTime(msg: string) {
    const fullmsg = msg + ' ' + getNow();
    addLogMessage(fullmsg);
  }

  replaySubjectLog.next('logger-service. The first replay msg sent.');

  let OUTPUT_ID = 'replaySubjectLogOutput';

  function addLogMessage(val: any) {
    const node = document.createElement('li');
    const textnode = document.createTextNode(val);
    node.appendChild(textnode);
  // ToDo - I added the "!" to avoid the error "object is possibly null"
  // but this should be better handled.
  document.getElementById(OUTPUT_ID)!.appendChild(node);
}

  function getNow(): string {
    const now = Date.now();
    const sec = Math.floor(now / 1000) % 100;
    const ms = now % 1000;
    return sec.toString() + ':' + ms.toString();
  }


