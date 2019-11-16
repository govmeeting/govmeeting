import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {FirstComponent} from './first/first.component';
import {SecondComponent} from './second/second.component';
import {ThirdComponent} from './third/third.component';
import {FourthComponent} from './fourth/fourth.component';

const routes: Routes = [
  {path: '', component: FirstComponent, pathMatch: 'full'},
  {path: 'material-design/:id/:location', component: FirstComponent, outlet:"sidenav"},
  {path: 'what-up-web', component: SecondComponent, outlet:"sidenav"},
  {path: 'my-ally-cli', component: ThirdComponent, outlet:"sidenav"},
  {path: 'become-angular-tailer', component: FourthComponent, outlet:"sidenav"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})
export class SidenavMenu4RoutingModule {
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
