import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {InfoCityComponent} from '../sidenav-info/info-city/component';
import {InfoCountyComponent} from '../sidenav-info/info-county/component';
import {InfoStateComponent} from '../sidenav-info/info-state/component';
import {InfoFederalComponent} from '../sidenav-info/info-federal/component';

const routes: Routes = [
  {path: '', component: InfoFederalComponent, pathMatch: 'full'},
  // {path: 'info-federal/:id/:location', component: InfoFederalComponent, outlet:"sidenav"},
  {path: 'info-federal', component: InfoFederalComponent, outlet:"sidenav"},
  {path: 'info-city', component: InfoCityComponent, outlet:"sidenav"},
  {path: 'info-county', component: InfoCountyComponent, outlet:"sidenav"},
  {path: 'info-state', component: InfoStateComponent, outlet:"sidenav"}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class SidenavMenuRoutingModule {
}


/*
  When an item is selected, menu-list-item.component.ts calls:
    onItemSelected(item: NavItem)
  which calls:.
    this.router.navigate([{outlets: {sidenav: item.route}}]);

  This will load the content of the selected component into:
      <router-outlet name="sidenav"></router-outlet>
  in sidenav-menu4.component.html.

*/
