import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-edittranscript',
  templateUrl: './edittranscript.html',
  styleUrls: ['./edittranscript.css']
})
export class EditTranscriptComponent implements OnInit {
    showhelp: boolean = true;
    showhidehelp: string = "Hide";

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
