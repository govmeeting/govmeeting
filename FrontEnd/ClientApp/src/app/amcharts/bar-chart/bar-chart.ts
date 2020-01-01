import { Component, OnInit } from '@angular/core';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";


interface IChartData {
  issue: string;
  alerts: number;
  units: number;
}

@Component({
  selector: 'gm-bar-chart',
  templateUrl: './bar-chart.html',
  styleUrls: ['./bar-chart.scss']
})
export class BarChartComponent implements OnInit {

  constructor() { }

  ngOnInit() {

// Create chart instance
let chart = am4core.create("chartdiv", am4charts.XYChart);
chart.data = this.chartdata;


// Create axes
let categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
categoryAxis.dataFields.category = "issue";
categoryAxis.title.text = "Issues";

var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
valueAxis.title.text = "Alerts set";

// Create series
var series = chart.series.push(new am4charts.ColumnSeries());
series.dataFields.valueY = "alerts";
series.dataFields.categoryX = "issue";
series.name = "Issues";
series.columns.template.tooltipText = "Series: {name}\nCategory: {categoryX}\nValue: {valueY}";

var gradient = new am4core.LinearGradient();
gradient.addColor(am4core.color("red"));
gradient.addColor(am4core.color("blue"));
gradient.rotation = 90;

// Gradient for top to bottom of each column
// series.columns.template.fill = gradient;

// Parallel gradient
var max = 250;
var red = am4core.color('red');
var blue = am4core.color('blue');
series.columns.template.adapter.add('fill', function(fill, column) {
  var columnGradient = new am4core.LinearGradient();
  columnGradient.rotation = 90;
  // interpolate(min.rgb, max.rgb, percent)
  //columnGradient.addColor(am4core.color( am4core.colors.interpolate(blue.rgb, red.rgb, column.dataItem.dataContext.alerts / max) ), 1, 0);
  columnGradient.addColor(blue, 1, 1);
  return columnGradient;
});
}

chartdata: IChartData[] = [{
  "issue": "Concerts",
  "alerts": 201.1,
  "units": 170
}, {
  "issue": "Recycling",
  "alerts": 165.8,
  "units": 122
}, {
  "issue": "Paving",
  "alerts": 139.9,
  "units": 99
}, {
  "issue": "Housing Finance",
  "alerts": 128.3,
  "units": 85
}, {
  "issue": "Homeless",
  "alerts": 99,
  "units": 93
}, {
  "issue": "Voting Rights",
  "alerts": 60,
  "units": 50
}, {
  "issue": "City Holiday",
  "alerts": 50,
  "units": 42
}];


}
