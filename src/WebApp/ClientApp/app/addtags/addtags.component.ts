import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-addtags',
  templateUrl: './addtags.component.html',
  styleUrls: ['./addtags.component.css']
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
