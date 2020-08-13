import { Component, OnInit } from '@angular/core';
import * as am4core from '@amcharts/amcharts4/core';
import * as am4charts from '@amcharts/amcharts4/charts';
import am4themes_animated from '@amcharts/amcharts4/themes/animated';

/*
  This example is from https://www.amcharts.com/docs/v4/getting-started/basics/
  The example on https://www.amcharts.com/docs/v4/getting-started/integrations/using-angular2/
    is more complicated. It uses the NgZone service and adds an ngAfterViewInit method which creates the chart.
    I am not sure what the advantage is. I was not able to get a chart working in the component's html doing this.
*/

const NoLog = true; // set to false for console logging

@Component({
  selector: 'gm-gauge',
  templateUrl: './gauge.html',
  styleUrls: ['./gauge.scss'],
})
export class AmgaugeComponent implements OnInit {
  private ClassName: string = this.constructor.name + ': ';
  // private chart: am4charts.GaugeChart;
  // private hand: { showValue: (arg0: number, arg1: number, arg2: (t: number) => number) => void; };

  constructor() {}

  ngOnInit() {
    /* Chart code */
    // Themes begin
    am4core.useTheme(am4themes_animated);
    // Themes end

    // create chart
    const chart = am4core.create('chartdiv', am4charts.GaugeChart);
    chart.hiddenState.properties.opacity = 0; // this makes initial fade in effect

    chart.innerRadius = -25;

    // let axis = chart.xAxes.push(new am4charts.ValueAxis());
    const axis = chart.xAxes.push(new am4charts.ValueAxis<am4charts.AxisRendererCircular>());

    axis.min = 0;
    axis.max = 100;
    axis.strictMinMax = true;
    axis.renderer.grid.template.stroke = new am4core.InterfaceColorSet().getFor('background');
    axis.renderer.grid.template.strokeOpacity = 0.3;

    const colorSet = new am4core.ColorSet();

    const range0 = axis.axisRanges.create();
    range0.value = 0;
    range0.endValue = 50;
    range0.axisFill.fillOpacity = 1;
    range0.axisFill.fill = colorSet.getIndex(0);
    range0.axisFill.zIndex = -1;

    const range1 = axis.axisRanges.create();
    range1.value = 50;
    range1.endValue = 80;
    range1.axisFill.fillOpacity = 1;
    range1.axisFill.fill = colorSet.getIndex(2);
    range1.axisFill.zIndex = -1;

    const range2 = axis.axisRanges.create();
    range2.value = 80;
    range2.endValue = 100;
    range2.axisFill.fillOpacity = 1;
    range2.axisFill.fill = colorSet.getIndex(4);
    range2.axisFill.zIndex = -1;

    const hand = chart.hands.push(new am4charts.ClockHand());

    NoLog || console.log(this.ClassName + 'this is hand: ');
    NoLog || console.log(this.ClassName, hand);
    // using chart.setTimeout method as the timeout will be disposed together with a chart
    chart.setTimeout(randomValue, 2000);

    function randomValue() {
      NoLog || console.log(this.ClassName + 'this is hand in randomValue: ');
      NoLog || console.log(this.ClassName + hand);
      hand.showValue(Math.random() * 100, 1000, am4core.ease.cubicOut);
      chart.setTimeout(randomValue, 2000);
    }
  }
}
