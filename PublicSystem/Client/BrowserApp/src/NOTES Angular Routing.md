# How the routes in the navbar get defined

## In the AboutRoutingModule definition, we find:
    RouterModule.forChild([{ path: 'about', component: AboutComponent }])
 
## In the AboutModule definition, we find:
    imports: [CommonModule, AboutRoutingModule]
    
## In the AppModule definition, we find:
    imports: [..., AboutModule, ..., ],
    
## In navbar.component.html, for each link in the navbar, we find:
    <a [routerLink]="['/']" [routerLinkActive]="['router-link-active']" [routerLinkActiveOptions]="{exact:true}">HOME</a>
