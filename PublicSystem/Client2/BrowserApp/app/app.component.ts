import {Component} from 'angular2/core';
import {NavbarComponent} from './navigation/navbar.component'
import {FooterComponent} from './navigation/footer.component'
import {HeadingComponent} from './singlemeeting/heading.component'
import {BrowsemeetingComponent} from './singlemeeting/browsemeeting.component'

@Component({
    selector: 'my-app',
    templateUrl: './app/app.component.html',
    directives: [NavbarComponent, FooterComponent, HeadingComponent, BrowsemeetingComponent]
})
export class AppComponent {
}