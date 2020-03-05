import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-developer-notes',
  templateUrl: './developer-notes.html',
  styleUrls: ['./developer-notes.scss']
})
export class DeveloperNotesComponent implements OnInit {
  @Input() showtitle: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}
