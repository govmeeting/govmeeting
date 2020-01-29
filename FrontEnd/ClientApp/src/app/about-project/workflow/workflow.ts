import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-workflow',
  templateUrl: './workflow.html',
  styleUrls: ['./workflow.scss']
})
export class WorkflowComponent implements OnInit {
  @Input() showtitle: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}
