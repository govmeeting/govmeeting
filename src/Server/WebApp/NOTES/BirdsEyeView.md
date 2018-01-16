Features\Shared\_Layout.cshtml
    <script>
        window.APP_DATA = { isServerRunning: true, isDataFromMemory: false }
    </script>
	...
    <div class="container body-content">
        @RenderBody()
    </div>

Features\Home\index.cshtml
	<app-root asp-prerender-module="ClientApp/dist/main-server">Loading...</app-root>

WebApp\ClientApp\boot.browser.ts
	const modulePromise = platformBrowserDynamic().bootstrapModule(AppModule);

WebApp\ClientApp\app\app.module.browser.ts
	    bootstrap: [ AppComponent ],

WebApp\ClientApp\app\app.module.shared.ts
	providers: [AppData,
        {
            provide: AppData,
            useValue: { isServerRunning: false, isDataFromMemory: false }
	}

WebApp\ClientApp\app\app.component.ts
	selector: 'app-root',
	constructor(appData:AppData) {
    		console.log('AppComponent - ', appData);
	}

WebApp\ClientApp\app\app.component.html
	<gm-navbar></gm-navbar>
        <router-outlet></router-outlet>

WebApp\ClientApp\app\navmenu\navmenu.component.ts
	selector: 'gm-navbar',
	templateUrl: './navmenu.component.html',

WebApp\ClientApp\app\navmenu\navmenu.component.html
	<li [routerLinkActive]="['link-active']">
		<a [routerLink]="['/home']">
		  <span class='glyphicon glyphicon-home'></span> Home
		</a>
	</li>
	<li [routerLinkActive]="['link-active']">
		<a [routerLink]="['/about']">
		  <span class='glyphicon glyphicon-book '></span> About
		</a>
	</li>
	<li [routerLinkActive]="['link-active']">
		<a [routerLink]="['/fixasr']">
		  <span class='glyphicon glyphicon-edit '></span> Fix ASR
		</a>
	</li>
	  ...

talk.service.ts
	import { AppData } from '../../appdata';
        if (this.appData.isDataFromMemory) {
            return Observable.of(this.testData);

				