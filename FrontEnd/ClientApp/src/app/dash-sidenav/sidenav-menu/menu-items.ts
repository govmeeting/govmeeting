import {NavItem, EntryType} from './nav-item';

// Each menu item has: DisplayName, iconName, Depth, children array or route

let unitedStates = new NavItem(EntryType.location, 'United States', 'flag',
  [
    new NavItem(EntryType.agency, 'Senate', null),
    new NavItem(EntryType.agency, 'House', null)
  ])

let maine =   new NavItem(EntryType.location, 'State of Maine', 'star',
[
  new NavItem(EntryType.agency, 'Senate', null),
  new NavItem(EntryType.agency, 'House', null)
])

let lincolnCounty = new NavItem(EntryType.location, 'Lincoln County', 'landscape', null);

let boothbayHarbor = new NavItem(EntryType.location, 'Boothbay Harbor', 'location_city', null);

let austin =   new NavItem(EntryType.location, 'Austin', 'location_city',
[
  new NavItem(EntryType.agency, 'City Council', 'group'),
  new NavItem(EntryType.agency, 'Board of Education', 'school'),
  new NavItem(EntryType.agency, 'Planning Board', 'group')
]);

let travisCounty = new NavItem(EntryType.location, 'Travis County', 'group');

let texas = new NavItem(EntryType.location, 'State of Texas', 'star',
[
  new NavItem(EntryType.agency, 'Senate', 'group'),
  new NavItem(EntryType.agency, 'House', 'group')
])

let nonGovernment = new NavItem(null, 'Non-Government', 'group',
[
  new NavItem(EntryType.location, 'Glendale HOA', 'group'),
]);

///////////////////////////////////////////////////////////////////////////////

let aboutpagesMenu = new NavItem(null, 'About', null,
[
  new NavItem(EntryType.link, 'Purpose', 'info', 'purpose'),
  new NavItem(EntryType.link, 'Overview', 'toc', 'overview'),
  new NavItem(EntryType.link, 'Workflow', 'trending_up', 'workflow'),
  new NavItem(null, 'Developer Notes', 'school',
  [
    new NavItem(EntryType.link, 'Page 1 - Setup', 'directions_boat', 'autoprocessing'),
    new NavItem(EntryType.link, 'Page 2', 'rowing', 'manualprocessing'),
    new NavItem(EntryType.link, 'Page 3', 'build', 'developernotes'),
  ])
])


let boothbayHarborMenu = new NavItem(null, 'Select Location', null,
[
  boothbayHarbor,
  lincolnCounty,
  maine,
  unitedStates,
  nonGovernment
]);


export let austinMenu = new NavItem(null, 'Select Location', null,
[
  austin,
  travisCounty,
  texas,
  unitedStates,
  nonGovernment
]);


export let navigationItems = [
  aboutpagesMenu,
  boothbayHarborMenu
  // austinMenu
]

