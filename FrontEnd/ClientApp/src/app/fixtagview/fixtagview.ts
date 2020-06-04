import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-fixtagview',
  templateUrl: './fixtagview.html',
  styleUrls: ['./fixtagview.css']
})
export class FixTagViewComponent implements OnInit {
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
