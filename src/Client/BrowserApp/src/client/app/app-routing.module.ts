import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    RouterModule.forRoot([
      /* define app module routes here, e.g., to lazily load a module
         (do not place feature module routes here, use an own -routing.module.ts in the feature instead)
       */
    ])
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }

/* === How the routes in the navbar get defined ===
 * In the AboutRoutingModule definition, we find:
 *     RouterModule.forChild([{ path: 'about', component: AboutComponent }])
 * In the AboutModule definition, we find:
 *     imports: [CommonModule, AboutRoutingModule]
 * In the AppModule definition, we find:
 *     imports: [..., AboutModule, ..., ],
 * In navbar.component.html, for each link in the navbar, we find:
 *     <a [routerLink]="['/']" [routerLinkActive]="['router-link-active']" [routerLinkActiveOptions]="{exact:true}">HOME</a>
 */