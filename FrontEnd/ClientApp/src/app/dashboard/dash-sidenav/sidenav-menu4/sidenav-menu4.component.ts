import {Component, ViewChild, ElementRef, ViewEncapsulation, AfterViewInit} from '@angular/core';
import {VERSION} from '@angular/material';
import {NavItem} from './nav-item';
import {NavService} from './nav.service';

@Component({
  selector: 'gm-sidenav-menu4',
  templateUrl: 'sidenav-menu4.component.html',
  styleUrls: ['sidenav-menu4.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SidenavMenu4Component implements AfterViewInit {
  @ViewChild('appDrawer', {static: false}) appDrawer: ElementRef;
  version = VERSION;

  navItems2: NavItem[];

  BuildSidenavMenu() {
    this.navItems2.push(
      new NavItem('Government', 'group'),
      new NavItem('Non-Government', 'group')
      )
    this.navItems2[0].children.push(
      new NavItem('Austin', 'group'),
      new NavItem('Traves County', 'group'),
      new NavItem('State of Texas', 'group'),
      new NavItem('United States', 'group')
    )
    this.navItems2[0][0].children.pus(

    )
    this.navItems2[1].children.push(
      new NavItem('Glendale HOA', 'group'),
      new NavItem('Paws Rescue', 'group'),
    )
}

  navItems: NavItem[] = [
    {
      displayName: 'Government',
      iconName: 'recent_actors',
      children: [
      {
        displayName: 'Austin',
        iconName: 'recent_actors',
        children: [
          {
            displayName: 'All departments',
            iconName: 'group',
            route: 'material-design/Government/Austin'
          },
          {
            displayName: 'City Council',
            iconName: 'speaker_notes',
            route: 'what-up-web'
          },
          {
            displayName: 'Board of Education',
            iconName: 'speaker_notes',
            route: 'my-ally-cli'
          },
          {
            displayName: 'Planning Board',
            iconName: 'speaker_notes',
            route: 'become-angular-tailer'
          }
        ]
      },
      {
        displayName: 'Travis County',
        iconName: 'recent_actors',
        children: [
          {
            displayName: 'All departments',
            iconName: 'group',
            route: 'michael-prentice'
          },
          {
            displayName: 'Commissioners',
            iconName: 'speaker_notes',
            route: 'stephen-fluin'
          },
          {
            displayName: 'Transportation',
            iconName: 'speaker_notes',
            route: 'feedback'
          }
        ]
      },
      {
        displayName: 'State of Texas',
        iconName: 'recent_actors',
        children: [
          {
            displayName: 'All branches',
            iconName: 'group',
            route: 'mike-brocchi'
          },
          {
            displayName: 'Senate',
            iconName: 'speaker_notes',
            route: 'what-up-web'
          },
          {
            displayName: 'House of Representatives',
            iconName: 'speaker_notes',
            route: 'what-up-web'
          }
        ]
      },
      {
        displayName: 'US Congress',
        iconName: 'recent_actors',
        children: [
          {
            displayName: 'All branches',
            iconName: 'group',
            route: 'material-design'
          },
          {
            displayName: 'Senate',
            iconName: 'speaker_notes',
            route: 'what-up-web'
          },
          {
            displayName: 'House of Representatives',
            iconName: 'speaker_notes',
            route: 'what-up-web'
          }
        ]
      }
    ]
  },
  {
    displayName: 'Non-Government',
    iconName: 'recent_actors',
    children: [
    {
      displayName: 'Glendale HOA',
      iconName: 'recent_actors',
      children: [
        {
          displayName: 'Board & Committes',
          iconName: 'group',
          route: 'material-design'
        },
        {
          displayName: 'Governing Board',
          iconName: 'speaker_notes',
          route: 'what-up-web'
        },
        {
          displayName: 'Covenance Committee',
          iconName: 'speaker_notes',
          route: 'what-up-web'
        }
      ]
    },
    {
      displayName: 'Paws Rescue',
      iconName: 'recent_actors',
      children: [
        {
          displayName: 'Trustees',
          iconName: 'group',
          route: 'material-design'
        }
      ]
    }
  ]
}

];








  constructor(private navService: NavService) {
  }

  ngAfterViewInit() {
    this.navService.appDrawer = this.appDrawer;
  }
}
