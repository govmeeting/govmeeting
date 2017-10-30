Angular Modules (NgModule)

# Minimal App (summary of main parts) 

## index.html
    System.import('app/main')

## app/app.module.ts
    @NgModule({
    bootstrap: [AppComponent] })
    export class AppModule {}
  
## app/app.component.ts
    @Component({
    selector: 'my-app',
    export class AppComponent {
        
## app/main.ts
    platformBrowserDynamic().bootstrapModule(AppModule);
    
    
# Add a directive

## app/highlight.directive.ts
    @Directive({ selector: '[highlight]' })
    export class HighlightDirective {

## Modify app/app.component.ts
    template: '<h1 highlight>{{title}}</h1>'

## Modify app/app.module.ts
    declarations: [
    AppComponent,
    HighlightDirective,
    ],    

    
# Put title in its own component

## app/title.component.html
    <h1 highlight>{{title}} {{subtitle}}</h1>

## app/title.component.ts
    @Component({
    selector: 'app-title',
    template: '<h1 highlight>{{title}} {{subtitle}}</h1>',
    })
    <h1 highlight>{{title}} {{subtitle}}</h1> ....
    
## Modify app/app.component.ts
    declarations: [ ...     TitleComponent .... ],
   
    
# Add a User Service

## app/user.service.ts
    @Injectable()
    export class UserService { userName = 'Sherlock Holmes'; }
    
## Modify app/title.component.html
    .... <i>Welcome, {{user}}</i> ....
    
# Modify app/title.component.ts
    constructor(userService: UserService) {
    this.user = userService.userName; }
    
## Modify app/app.module.ts
    providers: [ UserService ],
   
    
# Create new Contact component,directive, pipe and service.

## Modify app/app.component.ts (template)
    <app-contact></app-contact>
    
## app/contact/contact.component.html 
// This uses the new "highlight" directive and "awesome" pipe
    <h2>Contact of {{userName}}</h2>
    <h3 highlight>{{ contact.name | awesome }}</h3>
    
## app/contact/contact.component.ts
    @Component({
    selector: 'app-contact', ... })
    export class ContactComponent ....
    constructor(..., userService: UserService)
// contact.component.ts does not refer to the new "awesome" pipe

##  app/contact/contact.service.ts
    @Injectable()
    export class ContactService {
    
## app/contact/awesome.pipe.ts
    @Pipe({ name: 'awesome' })
    export class AwesomePipe implements PipeTransform { ....
    
## app/contact/highlight.directive.ts
(note this is new directive with same name as in app/highlight.directive.ts)
    @Directive({ selector: '[highlight], input' })
    export class HighlightDirective { ....
    
## Modify app/app.module.ts
    imports: [ BrowserModule, FormsModule ],
// FormsModule is imported because NgForm is used in Contact.component.html)
    import { HighlightDirective as ContactHighlightDirective
    } from './contact/highlight.directive';
    .....
    declarations: [ ... AwesomePipe, ContactComponent, ContactHighlightDirective ],
    providers: [ ContactService, UserService ],
  
    
# Make Contact a feature module

## contact.module.ts
    @NgModule({
    imports: [ CommonModule, FormsModule ],
    declarations: [ ContactComponent, HighlightDirective, AwesomePipe ], ...
    export class ContactModule { }
    // Note that we do not need an alias for HighlightDirective.

## Modify app/app.module.ts
// app.module.ts is the only existing file that needs to change.
// Remove FormsModule from imports array.
// Remove AwesomePipe, ContactComponent & ContactHighlightDirective
// from declarations array.
// Note that ContactService remains in providers array.
