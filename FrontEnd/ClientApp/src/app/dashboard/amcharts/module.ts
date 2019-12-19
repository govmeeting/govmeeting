import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AmgaugeComponent } from './gauge/component';
import { PieChartComponent } from './pie-chart/component';
import { BarChartComponent } from './bar-chart/component';



@NgModule({
  declarations: [
	  AmgaugeComponent,
    PieChartComponent,
    BarChartComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
	  AmgaugeComponent,
    PieChartComponent,
    BarChartComponent
  ]
})
export class AmchartsModule { }
