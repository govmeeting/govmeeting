import {bootstrap}    from 'angular2/platform/browser'
import {AppComponent} from './app.component'
import 'rxjs/Rx';
import {TopicsService} from './topics/topics.service'

bootstrap(AppComponent, [TopicsService]);
