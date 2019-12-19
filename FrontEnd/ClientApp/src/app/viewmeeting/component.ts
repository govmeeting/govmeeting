import { Component, OnInit } from '@angular/core';
import { UserchoiceService } from './userchoice.service';

@Component({
  selector: 'gm-meeting',
  templateUrl: './component.html',
  styleUrls: ['./component.css'],
  providers: [
    UserchoiceService
  ]
})
export class ViewMeetingComponent implements OnInit {
    showhelp: boolean = true;
    showhidehelp: string = "Hide";

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
