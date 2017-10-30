# How the routes in the navbar get defined

## Add to navbar.component.html: (each link in the navbar):
    <a [routerLink]="['/']" [routerLinkActive]="['router-link-active']" [routerLinkActiveOptions]="{exact:true}">HOME</a>
    <a [routerLink]="['/about']" [routerLinkActive]="['router-link-active']" [routerLinkActiveOptions]="{exact:true}">ABOUT</a>
    <a [routerLink]="['/meeting']" [routerLinkActive]="['router-link-active']" [routerLinkActiveOptions]="{exact:true}">MEETING</a>
    <a [routerLink]="['/addtags']" [routerLinkActive]="['router-link-active']" [routerLinkActiveOptions]="{exact:true}">ADD TAGS</a>

## Add to xxxxx-routing.module.ts for each route: (example is for "about")
    RouterModule.forChild([{ path: 'about', component: AboutComponent }])
 
## Add to xxxxx.module.ts for each route: (example is for "about")
    import { AboutRoutingModule } from './about-routing.module';
    ...
    imports: [CommonModule, AboutRoutingModule]
    
## Add to app.module.ts:  (example is for "about")
    import { AboutModule } from './about/about.module';
    ...
    imports: [..., AboutModule, ..., ],

## app-routing.module.ts - No changes here when adding a feature route.
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
    

