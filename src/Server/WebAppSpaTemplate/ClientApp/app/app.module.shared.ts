import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

//import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing/app-routing.module';
//import { MeetingModule } from './meeting/meeting.module'
//import { AddtagsModule } from './addtags/addtags.module'
//import { FixasrModule } from './fixasr/fixasr.module'
//import { SharedModule } from './shared/shared.module'
//import { HomeModule } from './home/home.module';
import { AboutModule } from './about/about.module';
//import { MatsampModule } from './matsamp/matsamp.module';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,

        AppRoutingModule,
        //HomeModule,
        AboutModule
        //MeetingModule,
        //AddtagsModule,
        //FixasrModule,
        //MatsampModule,
        //SharedModule,


        //RouterModule.forRoot([
        //    { path: '', redirectTo: 'home', pathMatch: 'full' },
        //    { path: 'home', component: HomeComponent },
        //    { path: 'counter', component: CounterComponent },
        //    { path: 'fetch-data', component: FetchDataComponent },
        //    { path: '**', redirectTo: 'home' }
        //])
    ]
    //exports: [ AppComponent]
})
export class AppModuleShared {
}
