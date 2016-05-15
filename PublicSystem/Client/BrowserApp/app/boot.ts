import {bootstrap}    from 'angular2/platform/browser'
import {AppComponent} from './app.component'
import 'rxjs/Rx';
import {BackendService} from './utilities/backend.service'
import {UserchoiceService, IUserChoiceSrv} from './utilities/userchoice.service'

bootstrap(AppComponent, [BackendService, UserchoiceService]);
