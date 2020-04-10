import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-overview',
  templateUrl: '../../../assets/docs/overview.md',
  styleUrls: ['../../../assets/docs/overview.scss']
})
export class OverviewComponent implements OnInit {
  // @Input() showtitle: boolean = true;

  constructor() { }

  ngOnInit() {
  }

  showtranscript: boolean = false;
  showhidetranscript: string = "Show";

  showindex: boolean = false;
  showhideindex: string = "Show";

  CheckShowTranscript(): boolean {
      return this.showtranscript;
  }
  ToggleTranscript() {
      this.showhidetranscript = this.showtranscript ? "Show" : "Hide";
      this.showtranscript = !this.showtranscript;
  }

  CheckShowIndex(): boolean {
      return this.showindex;
  }
  ToggleIndex() {
      this.showhideindex = this.showindex ? "Show" : "Hide";
      this.showindex = !this.showindex;
  }

}
