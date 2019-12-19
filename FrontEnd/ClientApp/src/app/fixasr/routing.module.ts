import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FixasrComponent } from './component';


const routes: Routes = [
    {
        path: '',
        component: FixasrComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FixasrRoutingModule { }
