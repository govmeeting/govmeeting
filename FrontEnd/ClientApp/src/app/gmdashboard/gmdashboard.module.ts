// Modules - external
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';

// Modules - internal
import { DemoMaterialModule } from '../material';
import { AboutModule } from './about/about.module';
import { VolunteerModule } from './volunteer/volunteer.module';
import { HomeModule } from './home/home.module';
import { SampleCardComponent } from './sample-card/sample-card.component';
import { GMDashboardComponent } from './gmdashboard.component';
import { ProjectStatusModule } from './project-status/project-status.module';
import { NeededFeaturesModule } from './needed-features/needed-features.module';
import { ChatModule } from '../gmdashboard/chat/chat.module';
import { ConversationModule } from './conversation/conversation.module';
import { FormsModule } from '@angular/forms';

// Components
import { NavlistComponent } from './navlist/navlist.component';
import { QuickviewComponent } from './quickview/quickview.component';
import { UserDropdownComponent } from './user-dropdown/user-dropdown.component';
import { YourEventsComponent } from './your-events/your-events.component';
import { RecentDocumentsComponent } from './recent-documents/recent-documents.component';
import { DashFooterComponent } from './dash-footer/dash-footer.component';
import { FinanceComponent } from './finance/finance.component';
import { MainCardComponent } from './main-card/main-card.component';
import { OverviewComponent } from './overview/overview.component';
import { OverviewCardComponent } from './overview-card/overview-card.component';
import { QuickviewItemComponent } from './quickview-item/quickview-item.component';
import { SidenavMenuComponent } from './sidenav-menu/sidenav-menu.component';
import { QuickviewHeaderComponent } from './quickview-header/quickview-header.component';
import { SidenavHeaderComponent } from './sidenav-header/sidenav-header.component';
import { DashSearchComponent } from './dash-search/dash-search.component';
import { DashHeaderComponent } from './dash-header/dash-header.component';
import { MainCardsComponent } from './main-cards/main-cards.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { TestgridComponent } from './testgrid/testgrid.component';
import { AmguageComponent } from './amguage/amguage.component';

// Services
import { ChatService } from './chat/chat.service';
import { MessagingService } from './conversation/messaging.service';
import { DataFactoryService } from './data-factory.service';
import { ShoutoutsComponent } from './shoutouts/shoutouts.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    LayoutModule,
    AboutModule,
    VolunteerModule,
    HomeModule,
    ProjectStatusModule,
    NeededFeaturesModule,
    ChatModule,
    ConversationModule,
    FormsModule
    ],
  declarations: [
    SampleCardComponent,
    GMDashboardComponent,
    NavlistComponent,
    QuickviewComponent,
    QuickviewItemComponent,
    UserDropdownComponent,
    OverviewComponent,
    OverviewCardComponent,
    MainCardComponent,
    YourEventsComponent,
    RecentDocumentsComponent,
    FinanceComponent,
    DashFooterComponent,
    SidenavMenuComponent,
    QuickviewHeaderComponent,
    SidenavHeaderComponent,
    DashSearchComponent,
    DashHeaderComponent,
    MainCardsComponent,
    SidenavComponent,
    TestgridComponent,
    AmguageComponent,
    ShoutoutsComponent
  ],
  exports: [
    GMDashboardComponent,
  ],
  providers: [
    ChatService,
    MessagingService,
    DataFactoryService
  ]
})
export class GmDashboardModule { }
