import { Component, OnInit } from '@angular/core';
import * as am4core from '@amcharts/amcharts4/core';
import * as am4charts from '@amcharts/amcharts4/charts';
// import { PieChart } from '@amcharts/amcharts4/charts';

@Component({
  selector: 'gm-pie-chart',
  templateUrl: './pie-chart.html',
  styleUrls: ['./pie-chart.scss'],
})
export class PieChartComponent implements OnInit {
  constructor() {}

  chartdata = [
    {
      issue: 'Concerts',
      comments: 201.1,
    },
    {
      issue: 'Recycling',
      comments: 165.8,
    },
    {
      issue: 'Paving',
      comments: 139.9,
    },
    {
      issue: 'Housing Finance',
      comments: 128.3,
    },
    {
      issue: 'Homeless',
      comments: 99,
    },
    {
      issue: 'Voting Rights',
      comments: 60,
    },
    {
      issue: 'City Holiday',
      comments: 50,
    },
  ];

  ngOnInit() {
    // Create chart instance
    const chart = am4core.create('chartdiv', am4charts.PieChart);
    chart.data = this.chartdata;

    // Add and configure Series
    const pieSeries = chart.series.push(new am4charts.PieSeries());
    pieSeries.dataFields.value = 'comments';
    pieSeries.dataFields.category = 'issue';
  }
}
