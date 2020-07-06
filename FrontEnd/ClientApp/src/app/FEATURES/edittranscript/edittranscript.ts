import { Component, OnInit,  ViewChild } from '@angular/core';
import { ElementRef } from '@angular/core';

import { VideoComponent } from '../../COMMON/video/video';


@Component({
  selector: 'gm-edittranscript',
  templateUrl: './edittranscript.html',
  styleUrls: ['./edittranscript.css']
})
export class EditTranscriptComponent implements OnInit {
    showhelp: boolean = true;
    showhidehelp: string = "Hide";

    @ViewChild('myInput', { static: false }) input: ElementRef;

    @ViewChild(VideoComponent, { static: false })
    private videoComponent: VideoComponent;

    constructor() { }

    ngOnInit() {
    }

    CheckShowHelp(): boolean {
        return this.showhelp;
    }
    ToggleHelp() {
        this.showhidehelp = this.showhelp ? "Show" : "Hide";
        this.showhelp = !this.showhelp;
    }
}
