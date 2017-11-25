import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { HomeComponent } from '../home/home.component'
import { AboutComponent } from '../about/about.component';
import { MeetingComponent } from '../meeting/meeting.component'
import { AddtagsComponent } from '../addtags/addtags.component'
import { FixasrComponent } from '../fixasr/fixasr.component'
//import { MatsampComponent } from '../matsamp/matsamp.component'

import { HomeComponent } from '../components/home/home.component'
import { CounterComponent } from '../components/counter/counter.component';
import { FetchDataComponent } from '../components/fetchdata/fetchdata.component';

const routes: Routes = [
    //{
    //  path: '',
    //  component: HomeComponent,
    //},
    //{
    //  path: 'addtags',
    //  component: AddtagsComponent,
    //},
    //{
    //  path: 'fixasr',
    //  component: FixasrComponent,
    //},
    ////{
    ////  path: 'matsamp',
    ////  component: MatsampComponent,
    ////},

    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'meeting', component: MeetingComponent },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    { path: '**', redirectTo: 'home' }


];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ],
    declarations: []
})
export class AppRoutingModule { }


//RouterModule.forRoot([
//    { path: '', redirectTo: 'home', pathMatch: 'full' },
//    { path: 'home', component: HomeComponent },
//    { path: 'counter', component: CounterComponent },
//    { path: '**', redirectTo: 'home' }
//])

