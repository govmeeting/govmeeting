import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'gm-manual-processing',
  templateUrl: './manual-processing.html',
  styleUrls: ['./manual-processing.scss']
})
export class ManualProcessingComponent implements OnInit {
  @Input() showtitle: boolean = true;

  constructor() { }

  ngOnInit() {
  }
}
