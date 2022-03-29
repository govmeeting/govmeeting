import { Component, EventEmitter, OnInit, Output, AfterViewInit } from '@angular/core';
import { EditTranscriptService } from '../edittranscript.service';
import { EditTranscript, Talk, Word, Caption, PlayPhraseData } from '../../../models/edittranscript-view';

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-talks',
  templateUrl: './talks.html',
  styleUrls: ['./talks.css'],
})
export class TalksComponent implements OnInit, AfterViewInit {
  private ClassName: string = this.constructor.name + ': ';

  @Output() playVideo: EventEmitter<PlayPhraseData>;

  errorMessage: string ='';
  talks: Talk[] | null = null;
  gotTalks = false;
  edittranscript: EditTranscript = { sections: [''], topics: [''], talks: [] };
  topics: string[] = [];
  highlightedTopic: string = '';
  shownTopicSelection = -1; // index of where we are displaying topic choice.

  wordColor = 'lightgreen';

  priorCaption: Caption | null = null;

  scroller: any;
  scrollerHeight: number = 0;
  output: any;
  toX: any;

  wordColors = ['lightblue', 'lightgreen', 'yellow', 'pink'];
  getWordColor(speaker: number): string {
    return speaker <= this.wordColors.length ? this.wordColors[speaker - 1] : 'brown';
  }

  // getCaptionColor(caption: Caption) {
  //   return 'lightgreen';
  // }

  getCaptionColor(hilite: boolean) {
    return hilite ? 'lightgreen' : '';
  }

  constructor(private _edittranscriptService: EditTranscriptService) {
    this.playVideo = new EventEmitter<PlayPhraseData>();
    // this.talks = addtagsService.getTalks();
  }

  ///////////////////////////////////////////////////////////////
  //  Get the data that we need.
  ///////////////////////////////////////////////////////////////

  ngOnInit() {
    NoLog || console.log(this.ClassName + 'ngOnInit');
    this.getTalks();

    // The following would get the list in memory.
    // this.talks = this._talkService.getTalksFromMemory();

    // this.getTopics();
  }

  ngAfterViewInit() {
    this.scroller = document.querySelector('#scrolling_div');
    this.scrollerHeight = Math.round(this.scroller.clientHeight);

    // For debugging. This gets element to which we will output info.
    // this.output = document.querySelector('#output');
    // this.toX = document.querySelector('#toX');

    // For debugging. This displays the current scrollTop of #scrolling_div.
    // this.scroller.addEventListener('scroll', (event) => {
    //   let x = this.scroller.scrollTop;
    //   x = Math.round(x);
    //   this.output.textContent = `scrollTop: ${x}`;
    // });
  }

  getTalks() {
    if (!this.gotTalks) {
      this.gotTalks = true;
      NoLog || console.log(this.ClassName + 'getTalks');
      this._edittranscriptService.getTalks().subscribe(
        (edittranscript : any) => {
          (this.edittranscript = edittranscript), (this.talks = edittranscript.talks);
        },
        (error: any) => (this.errorMessage = error as any)
      );
    }
  }

  ///////////////////////////////////////////////////////////////
  //  Save changed data.
  ///////////////////////////////////////////////////////////////

  // TODO activate Save button only if changes were made.
  saveChanges() {
    NoLog || console.log(this.ClassName + 'saveTranscript');
    this._edittranscriptService.postChanges(this.edittranscript);
    // .subscribe(
    // t => t
    // );
    // error => this.errorMessage = <any>error);
    NoLog || console.log(this.ClassName + 'exit saveTranscript');
  }

  ///////////////////////////////////////////////////////////////
  //  Handle user entry of new topic
  ///////////////////////////////////////////////////////////////

  // Capture the "topicSelect" event and set the new topic.
  onTopicSelect(newTopic: string, talk: Talk) {
    NoLog || console.log(this.ClassName + 'OnTopicSelect ', newTopic);
    if (newTopic === '') {
      talk.topic = '';
    } else {
      talk.topic = newTopic;
      talk.showSetTopic = false;
    }
  }

  // Capture the "textSelected" event and set the input box to the new data.
  handleTextSelected(highlighted: string) {
    NoLog || console.log(this.ClassName + 'handleTextSelected: ', highlighted);
    this.highlightedTopic = highlighted;
  }

  ///////////////////////////////////////////////////////////////
  //  Handle moving the section up or down
  ///////////////////////////////////////////////////////////////

  moveSectionUp(talk: Talk, i: number) {
    this.clearShownTopicSelection();
    if (this.talks && i > 0) {
      this.talks[i - 1].section = talk.section;
      talk.section = '';
    }
  }

  moveSectionDown(talk: Talk, i: number) {
    this.clearShownTopicSelection();
    if (this.talks && i < this.talks.length - 1) {
      this.talks[i + 1].section = talk.section;
      talk.section = '';
    }
  }

  ///////////////////////////////////////////////////////////////
  //  Handle moving the topic up or down
  ///////////////////////////////////////////////////////////////

  moveTopicUp(talk: Talk, i: number) {
    this.clearShownTopicSelection();
    if (this.talks && i > 0) {
      this.talks[i - 1].topic = talk.topic;
      talk.topic = '';
    }
  }

  moveTopicDown(talk: Talk, i: number) {
    this.clearShownTopicSelection();
    if (this.talks && i < this.talks.length - 1) {
      this.talks[i + 1].topic = talk.topic;
      talk.topic = '';
    }
  }

  showTopicSelection(talk: Talk, i: number) {
    this.clearShownTopicSelection();
    talk.showSetTopic = true;
    // save index of where we are displaying topic choice.
    this.shownTopicSelection = i;
  }

  clearShownTopicSelection() {
    if (this.shownTopicSelection !== -1) {
      if (this.talks) {
        this.talks[this.shownTopicSelection].showSetTopic = false;
        this.shownTopicSelection = -1;
      }
    }
  }

  ///////////////////////////////////////////////////////////////
  //  Handle video play
  ///////////////////////////////////////////////////////////////

  // The EditTranscriptComponent captures the playVideo event.
  onplayVideo(talk: Talk, i: number) {
    // we pass "i", the index into the talks array. But we don't use it as of now.
    // get the start time for this talk
    const starttime = talk.words[0].starttime;
    // get end time
    const endtime = talk.words[talk.words.length - 1].endtime;
    const data: PlayPhraseData = { start: starttime, duration: endtime - starttime };

    this.playVideo.emit(data);
  }

  ///////////////////////////////////////////////////////////////
  //  Scroll video
  ///////////////////////////////////////////////////////////////

  scrollToElement(elementId: string): void {
    const itemToScrollTo = document.getElementById(elementId);
    // null check to ensure that the element actually exists
    if (itemToScrollTo) {
      // itemToScrollTo.scrollIntoView(true);
      // itemToScrollTo.scrollIntoView({ behavior: 'smooth', block: 'center', inline: 'center' });
      // itemToScrollTo.scrollIntoView({ behavior: 'smooth', block: 'center' });

      const topPos = itemToScrollTo.offsetTop;
      // console.log('topPos of ' + elementId + ' = ' + topPos);
      // this.toX.innerText = 'To: ' + topPos;

      // let xx = document.getElementById('scrolling_div');
      // console.log('divTop = ' + xx.offsetTop);
      // let yy = document.getElementById('btnSave');
      // console.log('btnTop = ' + yy.offsetTop);
      // let zz = document.getElementById('0-0');
      // console.log('0-0Top = ' + zz.offsetTop);

      // The variable topPos is now set to the distance between the top of the scrolling div
      // and the element you wish to have visible (in pixels).

      // Now we tell the div to scroll to that position using scrollTop:
      // console.log('scroller scrollTop before: ' + this.scroller.scrollTop);

      // let zz = document.getElementById('0-0');
      // console.log('0-0 offsetTop: ' + zz.offsetTop);
      // zz = document.getElementById('1-0');
      // console.log('1-0 offsetTop: ' + zz.offsetTop);
      // zz = document.getElementById('2-0');
      // console.log('2-0 offsetTop: ' + zz.offsetTop);
      // console.log('div scrollTop before: ' + this.scroller.scrollTop);

      // Scroll text to middle of div, not top
      const scrollPos = topPos - this.scrollerHeight / 2;
      // let scrollPos = topPos;
      // console.log('scrollPos=', scrollPos);

      // @ts-ignore
      document.getElementById('scrolling_div').scrollTop = scrollPos;

      // console.log('div scrollTop after: ' + this.scroller.scrollTop);

      // let aa = 'To: ' + topPos;

      // itemToScrollTo.parentNode.scrollTop = itemToScrollTo.offsetTop;
      // } else {
      // let xx = 1;
    }
  }

  // For debugging. Scroll up 10
  // scrollup() {
  //   let $el = document.getElementById('scrolling_div');
  //   console.log('b sTop=' + $el.scrollTop);
  //   $el.scrollTop += 10;
  //   console.log('a sTop=' + $el.scrollTop);
  // }

  // For debugging. Scroll down 10
  // scrolldown() {
  //   let $el = document.getElementById('scrolling_div');
  //   console.log('b sTop=' + $el.scrollTop);
  //   $el.scrollTop -= 10;
  //   console.log('a sTop=' + $el.scrollTop);
  // }

  ///////////////////////////////////////////////////////////////
  //  Hilite text when spoken
  ///////////////////////////////////////////////////////////////

  hiliteCaptionText(captionId: number) {
    // The <video> element captionIds are sequential from the start of the video.
    // But the Ids on the caption text are not. They are created as "x-y" where
    // "x" = the index of the talk in the talks[] array and
    // "y" = the index of the phrase in the specific talk.
    const [caption, elId] = this.findCaption(captionId);
    if (this.priorCaption !== null) {
      this.priorCaption.hilite = false;
    }
    caption.hilite = true;
    this.priorCaption = caption;
    this.scrollToElement(elId);
    // console.log('hilite ' + elId);
  }

  // find the caption with specific Id in talks array.
        // @ts-ignore
        findCaption(Id: number): [Caption, string] {
    let i = 0;
        // @ts-ignore
        for (const talk of this.talks) {
      let j = 0;
        // @ts-ignore
        for (const caption of talk.captions) {
        if (caption.Id === Id) {
          const elementId: string = i.toString(10) + '-' + j.toString(10);
          return [caption, elementId];
        }
        j++;
      }
      i++;
    }
  }

  removePriorHilite() {
    if (this.priorCaption !== null) {
      this.priorCaption.hilite = false;
    }
  }

  ///////////////////////////////////////////////////////////////
  //  Utilities
  ///////////////////////////////////////////////////////////////

  convertToSeconds(time: string) {
    const array = time.split(':');
    let count = array.length;
    let seconds = 0;
    while (count > 0) {
      seconds = seconds + Number(array[count - 1]) * Math.pow(60, array.length - count);
      NoLog || console.log(this.ClassName + 'In convertToSeconds, seconds=' + seconds);
      count--;
    }
    return seconds;
  }
}
/*  ======  Smooth scrolling to an element inside an element  ===============
https://newbedev.com/how-to-scroll-to-an-element-inside-a-div

========  Method 1 ====================

var box = document.querySelector('.box'),
    targetElm = document.querySelector('.boxChild'); // <-- Scroll to here within ".box"

document.querySelector('button').addEventListener('click', function(){
   scrollToElm( box, targetElm , 600 );
});


/////////////

function scrollToElm(container, elm, duration){
  var pos = getRelativePos(elm);
  scrollTo( container, pos.top , 2);  // duration in seconds
}

function getRelativePos(elm){
  var pPos = elm.parentNode.getBoundingClientRect(), // parent pos
      cPos = elm.getBoundingClientRect(), // target pos
      pos = {};

  pos.top    = cPos.top    - pPos.top + elm.parentNode.scrollTop,
  pos.right  = cPos.right  - pPos.right,
  pos.bottom = cPos.bottom - pPos.bottom,
  pos.left   = cPos.left   - pPos.left;

  return pos;
}

function scrollTo(element, to, duration, onDone) {
    var start = element.scrollTop,
        change = to - start,
        startTime = performance.now(),
        val, now, elapsed, t;

    function animateScroll(){
        now = performance.now();
        elapsed = (now - startTime)/1000;
        t = (elapsed/duration);

        element.scrollTop = start + change * easeInOutQuad(t);

        if( t < 1 )
            window.requestAnimationFrame(animateScroll);
        else
            onDone && onDone();
    };

    animateScroll();
}

function easeInOutQuad(t){ return t<.5 ? 2*t*t : -1+(4-2*t)*t };


.box{ width:80%; border:2px dashed; height:180px; overflow:auto; }
.boxChild{
  margin:600px 0 300px;
  width: 40px;
  height:40px;
  background:green;
}

<button>Scroll to element</button>
<div class='box'>
  <div class='boxChild'></div>
</div>

===========   Method 3 - Using CSS scroll-behavior =================

.box {
  width: 80%;
  border: 2px dashed;
  height: 180px;
  overflow-y: scroll;
  scroll-behavior: smooth;
}

#boxChild {
  margin: 600px 0 300px;
  width: 40px;
  height: 40px;
  background: green;
}

<a href='#boxChild'>Scroll to element</a>
<div class='box'>
  <div id='boxChild'></div>
</div>

*/
