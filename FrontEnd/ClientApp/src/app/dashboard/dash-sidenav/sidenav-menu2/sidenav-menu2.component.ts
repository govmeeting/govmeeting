import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'gm-sidenav-menu2',
  templateUrl: './sidenav-menu2.component.html',
  styleUrls: ['./sidenav-menu2.component.scss']
})
export class SidenavMenu2Component implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  appitems = [
    {
        label: 'GOVERNMENT',
        disabled: true
        // faIcon: 'fas fa-city'
        // imageIcon: '/assets/batman.jpg'
        // link: 'https://www.npmjs.com/package/ng-material-multilevel-menu',
        // externalRedirect: true
    },
    {
        label: 'City of Austin',
        faIcon: 'fas fa-city',
        items: [
            {
                label: 'City Council',
                link: '/item-1-1',
                faIcon: 'fab fa-accusoft'
            },
            {
                label: 'Board of Education',
                link: '/item-1-1',
                faIcon: 'fab fa-accessible-icon',
                disabled: false,
                onSelected: function() {
                  console.log('Item 1.2.2.1');
              }
            },
            {
              label: 'Planning Board',
              link: '/item-1-1',
              faIcon: 'fab fa-accessible-icon',
              disabled: false,
              onSelected: function() {
                console.log('Item 1.2.2.1');
            }
          }
      ]
    },

    {
      label: 'Travis County',
      faIcon: 'far fa-image',
      items: [
          {
              label: 'Commissioners',
              link: '/item-1-1',
              faIcon: 'fab fa-accusoft'
          },
          {
              label: 'Transportation',
              link: '/item-1-1',
              faIcon: 'fab fa-accessible-icon',
              disabled: false,
              onSelected: function() {
                console.log('Item 1.2.2.1');
            }
          }
    ]
  },

  {
    label: 'State of Texas',
    faIcon: 'fas fa-star',
    items: [
        {
            label: 'Senate',
            link: '/item-1-1',
            faIcon: 'fab fa-accusoft'
        },
        {
            label: 'House of Representatives',
            link: '/item-1-1',
            faIcon: 'fab fa-accessible-icon',
            disabled: false,
            onSelected: function() {
              console.log('Item 1.2.2.1');
          }
        }
  ]
},

{
  label: 'US Congress',
  faIcon: 'fas fa-flag',
  items: [
      {
          label: 'Senate',
          link: '/item-1-1',
          faIcon: 'fab fa-accusoft'
      },
      {
          label: 'House of Representatives',
          link: '/item-1-1',
          faIcon: 'fab fa-accessible-icon',
          disabled: false,
          onSelected: function() {
            console.log('Item 1.2.2.1');
        }
      }
]
},

{
  label: 'NON-GOVERNMENT',
  disabled: true
},

{
  label: 'Glendale HOA',
  faIcon: 'far fa-building',
  items: [
      {
          label: 'Governing Board',
          link: '/item-1-1',
          faIcon: 'fab fa-accusoft'
      },
      {
          label: 'Covenance Committee',
          link: '/item-1-1',
          faIcon: 'fab fa-accessible-icon',
          disabled: false,
          onSelected: function() {
            console.log('Item 1.2.2.1');
        }
      }
]
},
{
  label: 'Paws Rescue',
  faIcon: 'fas fa-paw',
  items: [
      {
          label: 'Trustees',
          link: '/item-1-1',
          faIcon: 'fab fa-accusoft'
      },
      {
          label: 'Special Meetings',
          link: '/item-1-1',
          faIcon: 'fab fa-accessible-icon',
          disabled: false,
          onSelected: function() {
            console.log('Item 1.2.2.1');
        }
      }
    ]
  },

  {
    label: 'DOCUMENTATION',
    disabled: true
  },

  ]





/*     {
        label: 'Item 2',
        icon: 'alarm',
        items: [
        {
            label: 'Item 2.1',
            link: '/item-2-1',
            icon: 'favorite_border',
            activeIcon: 'favorite',
            disabled: true,
        },
        {
            label: 'Item 2.2',
            link: '/item-2-2',
            icon: 'favorite_border',
            activeIcon: 'favorite',
            navigationExtras: {
                queryParams: { order: 'popular', filter: 'new' },
            }
        }
        ]
    },
    {
        label: 'Item 3',
        icon: 'offline_pin',
        onSelected: function() {
            console.log('Item 3');
        }
    },
    {
        label: 'Item 4',
        link: '/item-4',
        icon: 'star_rate',
        hidden: true
    }
];
 */

config = {
  paddingAtStart: true,
  interfaceWithRoute: true,
  classname: 'my-custom-class',
  listBackgroundColor: `rgb(208, 241, 239)`,
  fontColor: `rgb(8, 54, 71)`,
  backgroundColor: `rgb(208, 241, 239)`,
  selectedListFontColor: `blue`,
  highlightOnSelect: true,
  collapseOnSelect: true,
  rtlLayout: false
};

selectedItem(event) {

}

selectedLabel($event) {

}

}
