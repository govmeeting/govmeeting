import {bootstrap}    from 'angular2/platform/browser'
import {AppComponent} from './app.component'
import 'rxjs/Rx';
import {BackendService} from './utilities/backend.service'

bootstrap(AppComponent, [BackendService]);
