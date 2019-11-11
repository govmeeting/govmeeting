import { Component, OnInit } from '@angular/core';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";

@Component({
  selector: 'gm-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.scss']
})
export class PieChartComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    // Create chart instance
    let chart = am4core.create("chartdiv", am4charts.PieChart);
    chart.data = this.chartdata;

    // Add and configure Series
    let pieSeries = chart.series.push(new am4charts.PieSeries());
    pieSeries.dataFields.value = "comments";
    pieSeries.dataFields.category = "issue";
  }

  chartdata = [{
    "issue": "Pave John St.",
    "comments": 501.9
  }, {
    "issue": "Police Hires",
    "comments": 301.9
  }, {
    "issue": "Ireland",
    "comments": 201.1
  }, {
    "issue": "Germany",
    "comments": 165.8
  }, {
    "issue": "Australia",
    "comments": 139.9
  }, {
    "issue": "Austria",
    "comments": 128.3
  }, {
    "issue": "UK",
    "comments": 99
  }, {
    "issue": "Belgium",
    "comments": 60
  }, {
    "issue": "The Netherlands",
    "comments": 50
  }];
}
