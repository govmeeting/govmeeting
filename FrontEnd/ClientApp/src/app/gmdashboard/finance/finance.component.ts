import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'gm-finance',
  templateUrl: './finance.component.html',
  styleUrls: ['./finance.component.scss']
})
export class FinanceComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

// Draw the chart
  renderChart() {
      // const chart = this.AmCharts.makeChart( "chartdiv", {
        const chart = ({
    "type": "serial",
    "theme": "light",
    "dataProvider": [ {
      "month": "Jan",
      "visits": 2025
    }, {
      "month": "Feb",
      "visits": 1882
    }, {
      "month": "Mar",
      "visits": 1809
    }, {
      "month": "Apr",
      "visits": 1322
    }, {
      "month": "May",
      "visits": 1122
    }, {
      "month": "Jun",
      "visits": 1114
    }, {
      "month": "Jul",
      "visits": 984
    }, {
      "month": "Aug",
      "visits": 711
    }, {
      "month": "Sept",
      "visits": 665
    }, {
      "month": "Oct",
      "visits": 580
    } ],
    "valueAxes": [ {
      "gridColor": "#FFFFFF",
      "gridAlpha": 0.2,
      "dashLength": 0
    } ],
    "gridAboveGraphs": true,
    "startDuration": 1,
    "graphs": [ {
      "balloonText": "[[category]]: <b>[[value]]</b>",
      "fillAlphas": 0.8,
      "lineAlpha": 0.2,
      "type": "column",
      "valueField": "visits"
    } ],
    "chartCursor": {
      "categoryBalloonEnabled": false,
      "cursorAlpha": 0,
      "zoomable": false
    },
    "categoryField": "month",
    "categoryAxis": {
      "gridPosition": "start",
      "gridAlpha": 0,
      "tickPosition": "start",
      "tickLength": 20
    },
    "export": {
      "enabled": false
    }
  });
}


}
