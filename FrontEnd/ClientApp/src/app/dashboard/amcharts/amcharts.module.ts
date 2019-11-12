import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GaugeComponent } from './gauge/gauge.component';
import { PieChartComponent } from './pie-chart/pie-chart.component';
// import { BarChartComponent } from './bar-chart/bar-chart.component';



@NgModule({
  declarations: [
	  GaugeComponent,
    PieChartComponent
    // BarChartComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
	  GaugeComponent,
    PieChartComponent
    // BarChartComponent
  ]
})
export class AmchartsModule { }
