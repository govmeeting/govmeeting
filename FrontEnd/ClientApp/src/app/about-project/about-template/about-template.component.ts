import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'gm-about-template',
  templateUrl: './about-template.component.html',
  styleUrls: ['./about-template.component.scss']
})
export class AboutTemplateComponent implements OnInit {
  @Input() title: string;

  panelOpenState: boolean = false;
  subtitle: string = "qiruiueiie"

  constructor() { }

  ngOnInit() {
  }

}
