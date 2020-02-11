import {NavItem} from './nav-item';

// Each menu item has: DisplayName, iconName, Depth, children array or route

let aboutpages = new NavItem('About', null, 0,
[
  new NavItem('Purpose', 'info', 1, 'info-city'),
  new NavItem('Overview', 'toc', 1, 'info-city'),
  new NavItem('Workflow', 'trending_up', 1, 'info-city'),
  new NavItem('Auto Processing', 'directions_boat', 1, 'info-city'),
  new NavItem('Manual Processing', 'rowing', 1, 'info-city'),
  new NavItem('Extend Govmeeting', 'build', 1, 'info-city'),
  new NavItem('[All Pages]', 'school', 1, 'info-city')
])

let boothbayharbor = new NavItem('Select Location', null, 0,
[
  new NavItem('Boothbay Harbor', 'location_city', 1, null
  // [
  //   new NavItem('Selectmen', null, 2, 'dashboard/govinfo'),
  //   new NavItem('Board of Ed.', null, 2, 'dashboard/govinfo'),
  //   new NavItem('Planning Board', null, 2, 'dashboard/govinfo'),
  //   new NavItem('All Depts.', null, 2, 'dashboard/govinfo'),
  // ]
  ),
  new NavItem('Lincoln County', 'landscape', 1, null
  // [
  //   new NavItem('Commissioners', null, 2, 'dashboard/infocounty'),
  //   new NavItem('Transportation', null, 2, 'dashboard/infocounty'),
  //   new NavItem('Both Depts.', null, 2, 'dashboard/infocounty'),
  // ]
  ),
  new NavItem('State of Maine', 'star', 1,
  [
    new NavItem('Senate', null, 2, 'info-state'),
    new NavItem('House', null, 2, 'info-state')
    // new NavItem('Both chambers', null, 2, 'info-state')
  ]),
  new NavItem('United States', 'flag', 1,
  [
    new NavItem('Senate', null, 2, 'info-federal'),
    new NavItem('House', null, 2, 'info-federal')
    // new NavItem('Both chambers', null, 2, 'info-federal')
  ]),
  new NavItem('Non-Government', 'group', 1,
  [
    new NavItem('Glendale HOA', null, 2, 'info-HOA'),
  ])
]);

// ];


export let austin = new NavItem('Select Location', null, 0,
[
  new NavItem('Austin', 'location_city', 1,
  [
    new NavItem('City Council', 'group', 2, 'dashboard/govinfo'),
    new NavItem('Board of Education', 'school', 2, 'dashboard/govinfo'),
    new NavItem('Planning Board', 'group', 2, 'dashboard/govinfo'),
    new NavItem('All Depts.', 'group', 2, 'dashboard/govinfo'),
  ]),
  new NavItem('Travis County', 'group', 1,
  [
    new NavItem('Commissioners', 'group', 2, 'dashboard/infocounty'),
    new NavItem('Transportation', 'group', 2, 'dashboard/infocounty'),
    new NavItem('Both Depts.', 'group', 2, 'dashboard/infocounty'),
  ]),
  new NavItem('State of Texas', 'star', 1,
  [
    new NavItem('Senate', 'group', 2, 'info-state'),
    new NavItem('House', 'group', 2, 'info-state'),
    new NavItem('Both chambers', 'group', 2, 'info-state')
  ]),
  new NavItem('United States', 'flag', 1,
  [
    new NavItem('Senate', 'group', 2, 'info-federal'),
    new NavItem('House', 'group', 2, 'info-federal'),
    new NavItem('Both chambers', 'group', 2, 'info-federal')
  ]),
  new NavItem('Non-Government', 'group', 1,
  [
    new NavItem('Glendale HOA', 'group', 2, 'info-HOA'),
  ])
]);


export let navigationItems = [
  aboutpages,
  // change nxt line to "austin" use Austin.
  boothbayharbor
  // austin
]

