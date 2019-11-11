import { Component, OnInit } from '@angular/core';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";


interface IChartData {
  country: string;
  litres: number;
  units: number;
}

@Component({
  selector: 'gm-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.scss']
})
export class BarChartComponent implements OnInit {

  constructor() { }

  ngOnInit() {

// Create chart instance
let chart = am4core.create("chartdiv", am4charts.XYChart);
chart.data = this.chartdata;


// Create axes
let categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
categoryAxis.dataFields.category = "country";
categoryAxis.title.text = "Countries";

var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
valueAxis.title.text = "Litres sold (M)";

// Create series
var series = chart.series.push(new am4charts.ColumnSeries());
series.dataFields.valueY = "litres";
series.dataFields.categoryX = "country";
series.name = "Sales";
series.columns.template.tooltipText = "Series: {name}\nCategory: {categoryX}\nValue: {valueY}";

var gradient = new am4core.LinearGradient();
gradient.addColor(am4core.color("red"));
gradient.addColor(am4core.color("blue"));
gradient.rotation = 90;

// Gradient for top to bottom of each column
// series.columns.template.fill = gradient;

// Parallel gradient
var max = 500;
var red = am4core.color('red');
var blue = am4core.color('blue');
series.columns.template.adapter.add('fill', function(fill, column) {
  var columnGradient = new am4core.LinearGradient();
  columnGradient.rotation = 90;
  // interpolate(min.rgb, max.rgb, percent)
  //columnGradient.addColor(am4core.color( am4core.colors.interpolate(blue.rgb, red.rgb, column.dataItem.dataContext.litres / max) ), 1, 0);
  columnGradient.addColor(blue, 1, 1);
  return columnGradient;
});
}

chartdata: IChartData[] = [{
  "country": "Lithuania",
  "litres": 501.9,
  "units": 250
}, {
  "country": "Czech Republic",
  "litres": 301.9,
  "units": 222
}, {
  "country": "Ireland",
  "litres": 201.1,
  "units": 170
}, {
  "country": "Germany",
  "litres": 165.8,
  "units": 122
}, {
  "country": "Australia",
  "litres": 139.9,
  "units": 99
}, {
  "country": "Austria",
  "litres": 128.3,
  "units": 85
}, {
  "country": "UK",
  "litres": 99,
  "units": 93
}, {
  "country": "Belgium",
  "litres": 60,
  "units": 50
}, {
  "country": "The Netherlands",
  "litres": 50,
  "units": 42
}];


}
