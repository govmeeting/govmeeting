import {NavItem} from './nav-item';

// Each menu item has: DisplayName, iconName, Depth, children array or route

let aboutpages = new NavItem('About', null,
[
  new NavItem('Purpose', 'info'),
  new NavItem('Overview', 'toc'),
  new NavItem('Workflow', 'trending_up'),
  new NavItem('Auto Processing', 'directions_boat'),
  new NavItem('Manual Processing', 'rowing'),
  new NavItem('Extend Govmeeting', 'build'),
  new NavItem('[All Pages]', 'school')
])

let boothbayharbor = new NavItem('Select Location', null,
[
  new NavItem('Boothbay Harbor', 'location_city', null),
  new NavItem('Lincoln County', 'landscape', null),
  new NavItem('State of Maine', 'star',
  [
    new NavItem('Senate', null),
    new NavItem('House', null)
  ]),
  new NavItem('United States', 'flag',
  [
    new NavItem('Senate', null),
    new NavItem('House', null)
  ]),
  new NavItem('Non-Government', 'group',
  [
    new NavItem('Glendale HOA', null),
  ])
]);

// ];


export let austin = new NavItem('Select Location', null,
[
  new NavItem('Austin', 'location_city',
  [
    new NavItem('City Council', 'group'),
    new NavItem('Board of Education', 'school'),
    new NavItem('Planning Board', 'group')
  ]),
  new NavItem('Travis County', 'group'),
  new NavItem('State of Texas', 'star',
  [
    new NavItem('Senate', 'group'),
    new NavItem('House', 'group')
  ]),
  new NavItem('United States', 'flag',
  [
    new NavItem('Senate', 'group'),
    new NavItem('House', 'group')
  ]),
  new NavItem('Non-Government', 'group',
  [
    new NavItem('Glendale HOA', 'group'),
  ])
]);


export let navigationItems = [
  aboutpages,
  // change nxt line to "austin" use Austin.
  boothbayharbor
  // austin
]

