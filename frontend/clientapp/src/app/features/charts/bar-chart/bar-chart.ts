import { Component, OnInit } from '@angular/core';
import * as am4core from '@amcharts/amcharts4/core';
import * as am4charts from '@amcharts/amcharts4/charts';
import { chartdata } from './bar-chart-sample-data';

@Component({
  selector: 'gm-bar-chart',
  templateUrl: './bar-chart.html',
  styleUrls: ['./bar-chart.scss'],
})
export class BarChartComponent implements OnInit {
  constructor() {}

  ngOnInit() {
    /**
     * ---------------------------------------
     * This demo was created using amCharts 4.
     *
     * For more information visit:
     * https://www.amcharts.com/
     *
     * Documentation is available at:
     * https://www.amcharts.com/docs/v4/
     * ---------------------------------------
     */

    // Themes
    // am4core.useTheme(am4themes_animated);
    // am4core.useTheme(am4themes_dataviz);

    // Create chart instance
    const chart = am4core.create('chartdiv', am4charts.XYChart);
    chart.numberFormatter.numberFormat = '#';

    // Add data
    chart.data = chartdata;

    // Create axes
    const categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
    categoryAxis.dataFields.category = 'year';
    categoryAxis.renderer.grid.template.location = 0;
    categoryAxis.renderer.minGridDistance = 20;
    categoryAxis.renderer.inside = true;
    categoryAxis.renderer.labels.template.valign = 'top';
    categoryAxis.renderer.labels.template.fontSize = 20;
    categoryAxis.renderer.cellStartLocation = 0.1;
    categoryAxis.renderer.cellEndLocation = 0.9;

    const valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    valueAxis.min = 0;
    valueAxis.title.text = 'Alerts';

    // Create series
    function createSeries(field, name, something) {
      const series = chart.series.push(new am4charts.ColumnSeries());
      series.dataFields.valueY = field;
      series.dataFields.categoryX = 'year';
      series.name = name;
      series.columns.template.tooltipText = '{name}: [bold]{valueY}[/]';
      series.columns.template.width = am4core.percent(95);

      const bullet = series.bullets.push(new am4charts.LabelBullet());
      bullet.label.text = '{name}';
      bullet.label.rotation = 90;
      bullet.label.truncate = false;
      bullet.label.hideOversized = false;
      bullet.label.horizontalCenter = 'left';
      bullet.locationY = 1;
      bullet.dy = 10;
    }

    chart.paddingBottom = 150;
    chart.maskBullets = false;

    createSeries('safety', 'Safety', false);
    createSeries('health', 'Health', true);
    createSeries('education', 'Education', false);
    createSeries('environ', 'Environment', true);
    createSeries('community', 'Community', true);
    createSeries('building', 'Building', true);
  }

  XngOnInit() {
    // Create chart instance
    const chart = am4core.create('chartdiv', am4charts.XYChart);
    chart.data = chartdata;

    // Create axes
    const categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
    categoryAxis.title.text = 'Issues';
    categoryAxis.dataFields.category = 'issue';

    const valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    valueAxis.title.text = 'Alerts';

    // Create series
    const series = chart.series.push(new am4charts.ColumnSeries());
    series.dataFields.valueY = 'alerts';
    series.dataFields.categoryX = 'issue';
    series.name = 'Issues';
    series.columns.template.tooltipText = 'Issue: {categoryX}\nAlerts: {valueY}';

    const bullet = series.bullets.push(new am4charts.LabelBullet());
    bullet.label.text = '{categoryX}';
    bullet.label.rotation = 90;
    bullet.label.truncate = false;
    bullet.label.hideOversized = false;

    bullet.label.horizontalCenter = 'left';
    bullet.locationY = 1;
    bullet.dy = 10;

    chart.paddingBottom = 150;
    chart.maskBullets = false;

    // const gradient = new am4core.LinearGradient();
    // gradient.addColor(am4core.color('red'));
    // gradient.addColor(am4core.color('lightblue'));
    // gradient.rotation = 90;

    // Gradient for top to bottom of each column
    // series.columns.template.fill = gradient;

    // Parallel gradient
    // const max = 250;
    // const red = am4core.color('red');
    // const blue = am4core.color('lightblue');
    // series.columns.template.adapter.add('fill', (fill, column) => {
    //   const columnGradient = new am4core.LinearGradient();
    //   columnGradient.rotation = 90;
    //   // interpolate(min.rgb, max.rgb, percent)
    //   // columnGradient.addColor(am4core.color( am4core.colors.interpolate(blue.rgb, red.rgb, column.dataItem.dataContext.alerts / max) ), 1, 0);
    //   columnGradient.addColor(blue, 1, 1);
    //   return columnGradient;
    // });
  }
}
