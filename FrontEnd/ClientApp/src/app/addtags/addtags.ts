import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-addtags',
  templateUrl: './addtags.html',
  styleUrls: ['./addtags.css']
})
export class AddtagsComponent implements OnInit {
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
